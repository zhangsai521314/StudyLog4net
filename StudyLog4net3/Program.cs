using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudyLog4net_Source
{
    class Program
    {
        /// <summary>
        /// 此App.config是把日志记录到指定的数据库
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    Log4net.Info("aa","sourec");
                }
                DataTable tb = new DataTable();
                DataRow ro = tb.Rows[0];
            }
            catch (Exception ex)
            {

                for (int i = 0; i < 20; i++)
                {
                    Log4net.Error(MethodBase.GetCurrentMethod(), ex, "sourec");
                }
            }
            Console.ReadKey();
        }
    }
}
