using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace StudyLog4net_Size
{
    public abstract class Log4net
    {
        //创建日志记录组件实例
        private static ILog log = null;

        #region 记录错误日志
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="method">方法名</param>
        /// <param name="ex">异常信息</param>
        public static void Error(string method, Exception ex, string logConfig)
        {
            log = log4net.LogManager.GetLogger(logConfig);
            log.Error(method, ex);
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="method">方法名</param>
        /// <param name="ex">异常信息</param>
        public static void Error(MethodBase method, Exception ex, string logConfig)
        {
            log = log4net.LogManager.GetLogger(logConfig);
            string fullName = "";
            if (method != null)
            {
                fullName = method.ReflectedType.FullName;
                fullName = fullName + "." + method.Name;
            }
            log.Error(fullName, ex);
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="method">方法名</param>
        /// <param name="ex">异常信息</param>
        public static void Error(string method, Exception ex)
        {
            if (log == null)
            {
                log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            }
            log.Error(method, ex);
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="method">方法名</param>
        /// <param name="ex">异常信息</param>
        public static void Error(MethodBase method, Exception ex)
        {
            if (log == null)
            {
                log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            }
            string fullName = "";
            if (method != null)
            {
                fullName = method.ReflectedType.FullName;
                fullName = fullName + "." + method.Name;
            }
            log.Error(fullName, ex);
        }
        #endregion

        #region 记录严重错误
        /// <summary>
        /// 记录严重错误
        /// </summary>
        /// <param name="method">方法名</param>
        /// <param name="ex">异常信息</param>
        public static void Fatal(string method, Exception ex, string logConfig)
        {
            log = log4net.LogManager.GetLogger(logConfig);
            log.Fatal(method, ex);
        }

        /// <summary>
        /// 记录严重错误
        /// </summary>
        /// <param name="method">方法名</param>
        /// <param name="ex">异常信息</param>
        public static void Fatal(MethodBase method, Exception ex, string logConfig)
        {
            log = log4net.LogManager.GetLogger(logConfig);
            string fullName = "";
            if (method != null)
            {
                fullName = method.ReflectedType.FullName;
                fullName = fullName + "." + method.Name;
            }
            log.Fatal(fullName, ex);
        }

        /// <summary>
        /// 记录严重错误
        /// </summary>
        /// <param name="method">方法名</param>
        /// <param name="ex">异常信息</param>
        public static void Fatal(string method, Exception ex)
        {
            if (log == null)
            {
                log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            }
            log.Fatal(method, ex);
        }

        /// <summary>
        /// 记录严重错误
        /// </summary>
        /// <param name="method">方法名</param>
        /// <param name="ex">异常信息</param>
        public static void Fatal(MethodBase method, Exception ex)
        {
            if (log == null)
            {
                log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            }
            string fullName = "";
            if (method != null)
            {
                fullName = method.ReflectedType.FullName;
                fullName = fullName + "." + method.Name;
            }
            log.Fatal(fullName, ex);
        }
        #endregion

        #region 记录一般信息
        /// <summary>
        /// 记录一般信息
        /// </summary>
        /// <param name="message">信息内容</param>
        public static void Info(string message, string logConfig)
        {
            log = log4net.LogManager.GetLogger(logConfig);
            log.Info(message);
        }

        /// <summary>
        /// 记录一般信息
        /// </summary>
        /// <param name="message">信息内容</param>
        public static void Info(string message)
        {
            if (log == null)
            {
                log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            }
            log.Info(message);
        }
        #endregion

        #region 记录调试信息
        /// <summary>
        /// 记录调试信息
        /// </summary>
        /// <param name="message">信息内容</param>
        public static void Debug(string message, string logConfig)
        {
            log = log4net.LogManager.GetLogger(logConfig);
            log.Debug(message);
        }

        /// <summary>
        /// 记录调试信息
        /// </summary>
        /// <param name="message">信息内容</param>
        public static void Debug(string message)
        {
            if (log == null)
            {
                log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            }
            log.Debug(message);
        }
        #endregion

        #region 记录警告信息
        /// <summary>
        /// 记录警告信息
        /// </summary>
        /// <param name="message">信息内容</param>
        public static void Warn(string message, string logConfig)
        {
            log = log4net.LogManager.GetLogger(logConfig);
            log.Warn(message);
        }

        /// <summary>
        /// 记录警告信息
        /// </summary>
        /// <param name="message">信息内容</param>
        public static void Warn(string message)
        {
            if (log == null)
            {
                log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            }
            log.Warn(message);
        }
        #endregion
    }
}
