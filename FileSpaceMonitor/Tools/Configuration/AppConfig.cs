using System;
using System.Collections;
using System.Configuration;

namespace FileSpaceMonitor.Tools.Configuration
{
    public static class AppConfig
    {
        #region constants

        private const string APPLICATION_NAME = "ApplicationName";
        private const string LOGFILE_EXTENSION = "LogFileExtension";
        private const string MAX_LOG_SIZE = "MaxLogSize";
        private const string NOTIFICATION_CSV = "NotifyCsv";
        private const string SLACK_URL = "SlackUrl";
        private const string SLACK_CHANNEL = "SlackChannel";
        private const string SERVER_SECTION = "serverSection";

        #endregion

        #region fields/properties

        public static string ApplicationName
        {
            get
            {
                string name;
                return TryGetAppSetting(APPLICATION_NAME, out name) ? name : "FileSpaceMonitor";
            }
        } 
        
        public static string LogPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + '\\' + ApplicationName; } }

        public static string LogFile
        {
            get
            {
                string extension;
                return TryGetAppSetting(LOGFILE_EXTENSION, out extension) 
                    ? LogPath + '\\' + ApplicationName + extension 
                    : LogPath + '\\' + ApplicationName + ".log";
            }
        }
                
        public static string BackupLogFile { get { return LogPath + '\\' + ApplicationName + ".backuplog"; } }

        public static int MaxLogSize
        {
            get
            {
                int maxSize;
                return TryGetAppSetting(MAX_LOG_SIZE, out maxSize) ? maxSize : 20000;
            }
        }

        public static IEnumerable NotificationUsers
        {
            get
            {
                string users;
                yield return TryGetAppSetting(NOTIFICATION_CSV, out users) ? users.Split(',') : null;                
            }
        }

        public static string SlackUrl
        {
            get
            {
                string url;
                return TryGetAppSetting(SLACK_URL, out url) ? url : string.Empty;                
            }
        }

        public static string SlackChannel
        {
            get
            {
                string channel;
                return TryGetAppSetting(SLACK_CHANNEL, out channel) ? channel : "general";
            }
        }

        public static ServerSection ServerMonitorSection { get { return ConfigurationManager.GetSection(SERVER_SECTION) as ServerSection; } }


        #endregion

        #region methods

        private static string GetAppSettingValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private static TValue GetAppSettingValue<TValue>(string key)
        {
            var value = GetAppSettingValue(key);
            return (string.IsNullOrEmpty(value)) ? default(TValue) : (TValue)Convert.ChangeType(value, typeof(TValue));
        }

        public static bool TryGetAppSetting<TValue>(string key, out TValue value)
        {
            try
            {
                value = GetAppSettingValue<TValue>(key);
                return true;
            }
            catch (Exception)
            {
                value = default(TValue);
                return false;
            }
        }

        #endregion
    }
}
