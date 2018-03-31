using System;
using System.Diagnostics;
using System.Threading;
using FileSpaceMonitor.Tools.MessageBox;

namespace FileSpaceMonitor.Tools.CommandMessaging
{
    public static class CommandMessageHelper
    {
        #region static methods

        /// <summary>
        /// Executes commandline msg message synchronously
        /// </summary>
        /// <param name="message">message to send</param>
        public static void ExecuteCommandSync(object message)
        {
            try
            {
                ProcessStartInfo pInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Windows\Sysnative\msg.exe",
                    Arguments = (string) message,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process p = new Process();
                p.StartInfo = pInfo;
                p.Start();

                string result = p.StandardOutput.ReadToEnd();
                if (result.Length > 0)
                    ScrollableMessageBox.Show("Result", result);
            }
            catch (Exception ex)
            {
                ScrollableMessageBox.Show("Exception", ex.Message);
            }
        }

        /// <summary>
        /// Executes commandline msg message asynchronously
        /// </summary>
        /// <param name="message">message to send</param>
        public static void ExecuteCommandAsync(string message)
        {
            try
            {
                Thread t = new Thread(new ParameterizedThreadStart(ExecuteCommandSync));
                t.IsBackground = true;
                t.Priority = ThreadPriority.AboveNormal;
                t.Start(message);
            }
            catch (ThreadStartException tsEx)
            {
                ScrollableMessageBox.Show("Thread Start Exception", tsEx.Message);
            }
            catch (ThreadAbortException taEx)
            {
                ScrollableMessageBox.Show("Thread Abort Exception", taEx.Message);
            }
            catch (Exception ex)
            {
                ScrollableMessageBox.Show("Exception", ex.Message);
            }
        }

        #endregion
    }
}
