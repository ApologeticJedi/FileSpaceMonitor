using System;


namespace FileSpaceMonitor.Tools.Logging
{
    public static class LogHelper
    {
        private static LogBase _logger = null;

        #region Log

        public static void Log(string source, string message)
        {
            Log(String.Format("{0,30}::{1}", source, message));
        }

        public static void Log(string message)
        {
            Log(LogTargetEnum.File, message);
        }

        public static void Log(LogTargetEnum target, string message)
        {
            Log(target, message, LogLevelEnum.Info);
        }

        public static void Log(LogTargetEnum target, string message, LogLevelEnum logLevel)
        {
            switch (target)
            {
                case LogTargetEnum.File:
                    _logger = new FileLogger();
                    break;

                case LogTargetEnum.EventLog:
                    break;

                case LogTargetEnum.Database:
                    break;
            }
            _logger.Log(message);
        }

        #endregion
    }
}
