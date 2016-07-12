using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudyLog4net_Email
{
    class Program
    {
        static void Main(string[] args)
        {
            my.myss();
            Console.ReadKey();

        }
    }

    public class my
    {
        public static void myss()
        {

            Log4net.Info("3个邮箱", "email");
            try
            {
                List<string> s = new List<string>();
                s = null;
                foreach (var item in s)
                {

                }
            }
            catch (Exception ex)
            {
                Log4net.Error(MethodBase.GetCurrentMethod(), ex, "email");
            }
        }


    }
}
