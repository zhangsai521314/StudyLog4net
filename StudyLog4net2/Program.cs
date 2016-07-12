using StudyLog4net_Size;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudyLog4net_Size
{
    class Program
    {
        /// <summary>
        /// 此App.config是按文件大小分割日志，指定文件的大小
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 200; i++)
                {
                    Log4net.Info("2222", "StudyLog4net2");
                }
                DataTable tb = new DataTable();
                DataRow ro = tb.Rows[0];
            }
            catch (Exception ex)
            {

                for (int i = 0; i < 200; i++)
                {
                    Log4net.Error(MethodBase.GetCurrentMethod(), ex, "");
                }
            }
            Console.ReadKey();

        }
    }
}
