using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using ServiceStack.Redis;
using System.IO;

namespace FCA.Common
{
    //客户端方法使用说明：http://www.cnblogs.com/kissdodog/p/3572084.html
    public class RedisCommon
    {
        private static IRedisClientsManager clientManager = CreateRedisManager();
        private static Cache myCache = HttpRuntime.Cache;
        //private int timeout = 0;
        //private int timeoutByKey = 0;

        #region 获取Redis程序池
        /// <summary>
        /// 获取Redis程序池
        /// </summary>
        /// <returns></returns>
        private static PooledRedisClientManager CreateRedisManager()
        {
            try
            {
                string readWriteHosts = ConfigurationHelper.MasterRedisIP;
                string readOnlyHosts = ConfigurationHelper.SlaveRedisIP;
                string readOnlyHost = ConfigurationHelper.CEshiSlaveRedisI;
                if (readWriteHosts.Equals(readOnlyHosts))
                {
                    return new PooledRedisClientManager(new string[] { readWriteHosts });
                }
                else
                {
                    //建立读写分享的数据缓存,支持读写分离，均衡负载
                    return new PooledRedisClientManager(new string[] { readWriteHosts }, new string[] { readOnlyHosts, readOnlyHost }, new RedisClientManagerConfig

                    {
                        MaxWritePoolSize = 5,//“写”链接池数
                        MaxReadPoolSize = 5,//“读”链接池数
                        AutoStart = true,
                    });
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 读取数据
        /// <summary>
        /// 读取数据
        /// </summary>
        public static T Get<T>(string key)
        {
            using (IRedisClient rds = clientManager.GetReadOnlyClient())
            {
                List<string> cacheKey = GetCache<List<string>>("cacheKey");
                if (cacheKey != null)
                {
                    if (cacheKey.Contains(key))
                    {
                        return GetCache<T>(key);
                    }
                    else
                    {
                        return rds.Get<T>(key);
                    }
                }
                else
                {
                    T s = rds.Get<T>(key);
                    return s;
                }
            }
        }
        #endregion
        #region 添加数据
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="key">键的名称</param>
        /// <param name="val">存放的值</param>
        /// <param name="IsCache">是否存入Cache中</param>
        /// <returns></returns>
        public static bool Set<T>(string key, T val, bool IsCache)
        {
            using (IRedisClient rds = clientManager.GetClient())
            {
                if (IsCache)
                {
                    InsertCache(key, val, ConfigurationHelper.CacheTimeOut);
                    List<string> cacheKey = Get<List<string>>("cacheKey");
                    if (cacheKey == null)
                    {
                        cacheKey = new List<string>();
                        cacheKey.Add(key);
                        rds.Set<List<string>>("cacheKey", cacheKey);
                    }
                    else
                    {
                        if (!cacheKey.Contains(key))
                        {
                            cacheKey.Add(key);
                            rds.Set<List<string>>("cacheKey", cacheKey);
                        }
                    }
                }
                return rds.Set<T>(key, val);
            }
        }
        #endregion
        #region 删除数据根据键
        /// <summary>
        /// 删除数据根据键
        /// </summary>
        public static bool Remove(string key)
        {
            using (IRedisClient rds = clientManager.GetClient())
            {
                myCache.Remove(key);
                return rds.Remove(key);
            }
        }
        #endregion
        #region 根据传入的多个key移除多条记录
        /// <summary>
        ///  根据传入的多个key移除多条记录
        /// </summary>
        /// <param name="keys"></param>
        public static void RemoveAll(string[] keys)
        {
            using (IRedisClient rds = clientManager.GetClient())
            {
                rds.RemoveAll(keys);
            }
            foreach (string item in keys)
            {
                myCache.Remove(item);
            }

        }
        #endregion
        #region 清除所有数据
        /// <summary>
        /// 清除所有数据
        /// </summary>
        public static void FlushDb()
        {
            using (IRedisClient rds = clientManager.GetClient())
            {
                List<string> cacheKey = rds.Get<List<string>>("cacheKey");
                rds.FlushDb();
                rds.Set<List<string>>("cacheKey", cacheKey);
            }
        }
        #endregion
        #region 将多选放入到缓存中
        /// <summary>
        /// 将多选放入到缓存中
        /// </summary>
        /// <param name="ClientID"></param>
        /// <param name="values"></param>
        /// <param name="key"></param>
        public void InsertValues(int ClientID, string values, string key)
        {
            if (string.IsNullOrEmpty(values) || string.IsNullOrEmpty(key) || ClientID <= 0)
            {
                return;
            }
            string[] info = values.Split(',');
            List<ValuesKey> myList = Get<List<ValuesKey>>(key);
            if (myList != null && myList.Count > 0)
            {
                myList.RemoveAll(m => m.ID == ClientID);
            }
            if (myList == null)
            {
                myList = new List<ValuesKey>();
            }
            foreach (string item in info)
            {
                ValuesKey vk = new ValuesKey();
                vk.ID = ClientID;
                vk.Value = item;
                myList.Add(vk);
            }
            Set<List<ValuesKey>>(key, myList, false);
        }
        #endregion

        #region 增加Cache缓存
        /// <summary>
        /// 增加Cache缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="timeOut"></param>
        private static void InsertCache(string key, object val, int timeOut)
        {

            if (val != null)
            {
                if (timeOut > 0)
                {
                    myCache.Insert(key, val, null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(timeOut));
                }
                else
                {
                    myCache.Insert(key, val, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMilliseconds(1));
                }
            }
        }
        #endregion
        #region 获取Cache缓存
        /// <summary>
        /// 获取Cache缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        private static T GetCache<T>(string key)
        {

            if (myCache.Get(key) == null)
            {
                using (IRedisClient rds = clientManager.GetReadOnlyClient())
                {
                    T result = rds.Get<T>(key);
                    int timeOut = 0;
                    if (key == "cacheKey")
                    {
                        timeOut = ConfigurationHelper.CacheTimeOutByKey;
                        if (timeOut == 0)
                        {
                            if (ConfigurationManager.AppSettings["CacheTimeOutByKey"] != "0")
                            {
                                if (int.TryParse(ConfigurationManager.AppSettings["CacheTimeOutByKey"], out timeOut))
                                {
                                    ConfigurationHelper.CacheTimeOutByKey = timeOut;
                                }
                            }

                        }
                    }
                    else
                    {
                        timeOut = ConfigurationHelper.CacheTimeOut;
                    }
                    if (result != null)
                    {
                        InsertCache(key, result, timeOut);
                    }
                    return result;
                }
            }
            else
            {
                return (T)myCache.Get(key);
            }
        }
        #endregion


        #region 存文件
        public static void InsertByte(string Path)
        {
            using (FileStream da = new FileStream(Path, FileMode.Open))
            {

                byte[] by = new byte[1024 * 1024 * 3];
                int r = da.Read(by, 0, by.Length);

            }

        }
        #endregion

    }

    public class ValuesKey
    {
        private int _ID;
        private string _Value;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }




}
