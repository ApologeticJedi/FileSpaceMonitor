using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FileSpaceMonitor.Tools.CommandMessaging;
using FileSpaceMonitor.Tools.Configuration;
using FileSpaceMonitor.Tools.Logging;
using FileSpaceMonitor.Tools.MessageBox;
using FileSpaceMonitor.Tools.SlackMessaging;

namespace FileSpaceMonitor.Tools.SpaceManager
{
    public class FreeSpaceManager
    {
        #region fields/properties
                
        public ServerElement Server { get; private set; }

        private long _totalSize;
        private long _totalFreeSpace;
        private long _freeSpaceAvailable;        

        #endregion

        #region .ctor

        public FreeSpaceManager(ServerElement server)
        {
            Server = server;
        }

        #endregion

        #region CheckFileSpace

        public void CheckFileSpace()
        {
            GetServerFileSpace();
            AnalyseComsumedSpace();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Pulls back the file space of the server path of object
        /// </summary>
        private void GetServerFileSpace()
        {
            LogHelper.Log("FreeSpaceManager", "GetServerFileSpace on [" + Server.Name + "]");
            long freeBytesAvailable = 0;
            long totalNumberOfBytes = 0;
            long totalNumberOfFreeBytes = 0;
            if (GetDiskFreeSpaceEx(Server.Path, out freeBytesAvailable, out totalNumberOfBytes,
                out totalNumberOfFreeBytes))
            {
                _freeSpaceAvailable = freeBytesAvailable;
                _totalSize = totalNumberOfBytes;
                _totalFreeSpace = totalNumberOfFreeBytes;

                LogHelper.Log("FreeSpaceManager",
                    String.Format("{0,-25} [{1:0.00} GB]", "Total Drive Space",
                        FormatSpace(totalNumberOfBytes, DiskSizeUnit.GigaBytes)));
                LogHelper.Log("FreeSpaceManager",
                    String.Format("{0,-25} [{1:0.00} GB]", "Free Bytes Available",
                        FormatSpace(freeBytesAvailable, DiskSizeUnit.GigaBytes)));                
            }
        }

        /// <summary>
        /// Determines if server space has surpassed threshold
        /// </summary>
        private void AnalyseComsumedSpace()
        {
            double pctConsumed = (100.00 - (100 * _freeSpaceAvailable / (double)_totalSize));
            string warning = String.Format("{0} [{1}] is {2:0.00}% full.", Server.Name, Server.Path, pctConsumed);
            LogHelper.Log("FreeSpaceManager", "AnalyseComsumedSpace: " + warning);
            if (pctConsumed > Server.Threshold)
            {
                SendWarning(warning);
            }
        }
        
        /// <summary>
        /// Formats the space to DiskSizeUnit
        /// </summary>
        /// <param name="nativeBytes">totalspace</param>
        /// <param name="sizeUnit">DiskSizeUnit to format to</param>
        /// <returns>new formatted value</returns>
        private double FormatSpace(long nativeBytes, DiskSizeUnit sizeUnit)
        {
            return nativeBytes / Math.Pow(1024, (int)sizeUnit);
        }

        /// <summary>
        /// Sends out a warning
        /// </summary>
        /// <param name="text">warning message</param>
        private void SendWarning(string text)
        {
            MessagingType mt = (MessagingType) Enum.Parse(typeof(MessagingType), Server.NotificationMethod);         
            switch (mt)
            {
                case MessagingType.msg:
                    foreach (string user in ConfigurationManager.AppSettings.Get("NotifyCsv").Split(','))
                    {
                        CommandMessageHelper.ExecuteCommandAsync(user + ' ' + text);
                    }                    
                    break;

                case MessagingType.email:
                    break;

                case MessagingType.messagebox:
                    ScrollableMessageBox.Show(text, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case MessagingType.slack:
                    string slackWarn = ":warning: *Warning!*\n>" + text;
                    SlackClient client = new SlackClient();
                    client.PostMessage(slackWarn, "monitor-bot", AppConfig.SlackChannel);
                    break;

                case MessagingType.none:
                    break;
            }
        }

        #endregion

        #region external method call

        /// <summary>
        /// Exernal method from kernal used to grab disk info
        /// </summary>
        /// <param name="lpszPath">path of server</param>
        /// <param name="lpFreeBytesAvailable">returned free space available</param>
        /// <param name="lpTotalNumberOfBytes">returned total space on server</param>
        /// <param name="lpTotalNumberOfFreeBytes">returned full free bytes</param>
        /// <returns>boolean for success</returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool GetDiskFreeSpaceEx
            (
            string lpszPath,
            out long lpFreeBytesAvailable,
            out long lpTotalNumberOfBytes,
            out long lpTotalNumberOfFreeBytes
            );

        #endregion

    }
}
