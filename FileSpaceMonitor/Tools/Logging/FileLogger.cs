using System;
using System.Configuration;
using System.IO;


namespace FileSpaceMonitor.Tools.Logging
{
    public class FileLogger : LogBase
    {
        private const int MAX_LOG_SIZE = 20000;

        public int MaxSize { get; private set; }
        
        public string LogPath { get; private set; }
        public string ApplicationName { get; private set; }
        public string LogFile { get; private set; }

        public FileLogger()
        {
            ApplicationName = ConfigurationManager.AppSettings.Get("ApplicationName");
            LogPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + '\\' + ApplicationName;
            LogFile = LogPath + '\\' + ApplicationName + ConfigurationManager.AppSettings.Get("LogFileExtension");

            int max;
            MaxSize = int.TryParse(ConfigurationManager.AppSettings.Get("MaxLogSize"), out max) ? max : MAX_LOG_SIZE;

        }

        public override void Log(string message)
        {
            lock (LockObject)
            {
                FileSizeMainenance();
                using (StreamWriter streamWriter = File.AppendText(LogFile))
                {
                    streamWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff") + "|" + message);
                    streamWriter.Close();
                }
            }
        }

        private void FileSizeMainenance()
        {
            Directory.CreateDirectory(LogPath);
            FileInfo logFileInfo = new FileInfo(LogFile);            
            if (logFileInfo.Exists && logFileInfo.Length > MaxSize)
            {
                string oldLogFile = LogPath + '\\' + ApplicationName + ".backuplog";
                File.Copy(LogFile, oldLogFile, true);
                File.Delete(LogFile);
            }
        }
    }
}
