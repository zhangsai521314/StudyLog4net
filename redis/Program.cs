using FCA.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace redis
{
    class Program
    {
        static void Main(string[] args)
        {
            if (RedisCommon.Set<string>("zhangsaisai", "zss", false))
            {
                //string redis = RedisCommon.Get<string>("zhangsaisai");
                ////if (RedisCommon.Remove("zhangsaisai"))
                ////{
                //    string shan = RedisCommon.Get<string>("zhangsaisai");

                //    string shan1 = RedisCommon.Get<string>("zhangsaisai");
                //    string shan2 = RedisCommon.Get<string>("zhangsaisai");
                //    string shan3 = RedisCommon.Get<string>("zhangsaisai");
                //    string shan4 = RedisCommon.Get<string>("zhangsaisai");
                //    string shan5 = RedisCommon.Get<string>("zhangsaisai");
                //    string shan6 = RedisCommon.Get<string>("zhangsaisai");
                //    string shan7 = RedisCommon.Get<string>("zhangsaisai");
                //    string shan8 = RedisCommon.Get<string>("zhangsaisai"); 
                //    string shan9 = RedisCommon.Get<string>("zhangsaisai");
                //    string shan0 = RedisCommon.Get<string>("zhangsaisai");
                //    string shan10 = RedisCommon.Get<string>("zhangsaisai");
                //    string shan11 = RedisCommon.Get<string>("zhangsaisai");
                //}

                //using (FileStream da = new FileStream("G:\\7675476_044322622000_2.jpg", FileMode.Open))
                //{
                //    byte[] by = new byte[1024 * 1024 * 3];
                //    int r = da.Read(by, 0, by.Length);
                //    //if (RedisCommon.Set<byte[]>("byte", by, false))
                //    //{
                //        byte[] getBy = RedisCommon.Get<byte[]>("byte");
                //        File.WriteAllBytes("D:\\1.jpg", getBy);//将数组转换成文件
                //    //}
                //}
                //Console.WriteLine(redis);
            }
            Console.ReadKey();
        }
    }
}
