using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudyLog4net_Console
{
    /// <summary>
    /// 把日志输出到控制台
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 1; i++)
                {
                    Log4net.Info("ssss", "ConsoleAppender");
                }
                DataTable tb = new DataTable();
                DataRow ro = tb.Rows[0];
            }
            catch (Exception ex)
            {
                //Log4net.Fatal(MethodBase.GetCurrentMethod(),ex,"ConsoleAppender");
                Log4net.Error(MethodBase.GetCurrentMethod(), ex, "ConsoleAppender");
            }
            Console.ReadKey();
        }
    }
}
