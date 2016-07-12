using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace FCA.Common
{
    public class ConfigurationHelper
    {
        #region 私有变量
        private static string _MasterRedisIP;
        private static string _SlaveRedisIP;


        private static string _CEshiSlaveRedisI;



        private static int _CacheTimeOut;
        private static int _CacheTimeOutByKey;
        #endregion

        #region 获取Redis主服务器的IP信息
        /// <summary>
        /// 获取Redis主服务器的IP信息
        /// </summary>
        public static string MasterRedisIP
        {
            get
            {
                if (string.IsNullOrEmpty(_MasterRedisIP))
                {
                    _MasterRedisIP = ConfigurationManager.AppSettings["MasterRedisIP"];
                }
                return _MasterRedisIP;
            }

        }
        #endregion

        #region 获取Redis从服务器的IP信息
        /// <summary>
        /// 获取Redis从服务器的IP信息
        /// </summary>
        public static string SlaveRedisIP
        {
            get
            {
                if (string.IsNullOrEmpty(_SlaveRedisIP))
                {
                    _SlaveRedisIP = ConfigurationManager.AppSettings["SlaveRedisIP"];
                }
                return _SlaveRedisIP;
            }

        }
        #endregion




        public static string CEshiSlaveRedisI
        {
            get
            {
                if (string.IsNullOrEmpty(_CEshiSlaveRedisI))
                {
                    _CEshiSlaveRedisI = ConfigurationManager.AppSettings["CEshiSlaveRedisIP"];
                }
                return _CEshiSlaveRedisI;
            }
        }




        #region Cache过期时间
        /// <summary>
        /// Cache过期时间/小时
        /// </summary>
        public static int CacheTimeOut
        {
            get
            {
                if (_CacheTimeOut <= 0)
                {
                    _CacheTimeOut = ConfigurationManager.AppSettings["CacheTimeOut"] == null ? 0 : Convert.ToInt32(ConfigurationManager.AppSettings["CacheTimeOut"]);
                }
                return _CacheTimeOut;
            }
        }
        #endregion
        #region 获取Cacke键的过期时间
        /// <summary>
        /// 获取Cacke键的过期时间
        /// </summary>
        public static int CacheTimeOutByKey
        {
            get
            {
                if (_CacheTimeOutByKey <= 0)
                {
                    _CacheTimeOutByKey = ConfigurationManager.AppSettings["CacheTimeOutByKey"] == null ? 0 : Convert.ToInt32(ConfigurationManager.AppSettings["CacheTimeOutByKey"]);
                }
                return _CacheTimeOutByKey;
            }
            set
            {
                if (value > 0)
                {
                    _CacheTimeOutByKey = value;
                }
            }
        }
        #endregion

    }
}
