using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudyLog4net_File
{
    /// <summary>
    /// 此App.config是按日期分割日志，一天记录是一个文件
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {                                    
                    Log4net.Info("sss", "StudyLog4net");
                }
                DataTable tb = new DataTable();
                DataRow ro = tb.Rows[0];
            }
            catch (Exception ex)
            {
                 Log4net.Error(MethodBase.GetCurrentMethod(), ex, "");
                //Log4net.Error(MethodBase.GetCurrentMethod(), ex, "ConsoleAppender");
            }
            Console.ReadKey();
        }
    }
}
