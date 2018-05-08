using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuSha.Framework.Common.Helper
{
    public class LogHelper
    {
        private LogHelper()
        {
        }

        public static void WriteDebug(string msg,Exception ex)
        {
            log4net.ILog logdebug = log4net.LogManager.GetLogger("logdebug");
            logdebug.Debug(msg,ex);
        }
        public static void WriteDebug(string msg)
        {
            WriteDebug(msg, null);
        }
        public static void WriteInfo(string msg, Exception ex)
        {
            log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
            loginfo.Info(msg,ex);
        }
        public static void WriteInfo(string msg)
        {
            WriteInfo(msg, null);
        }
        public static void WriteError(string msg, Exception ex)
        {
            log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");
            logerror.Info(msg,ex);
        }
        public static void WriteError(string msg)
        {
            WriteError(msg, null);
        }
    }
}
