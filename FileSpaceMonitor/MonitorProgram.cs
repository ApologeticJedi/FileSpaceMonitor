using FileSpaceMonitor.Tools.Configuration;
using FileSpaceMonitor.Tools.Logging;
using FileSpaceMonitor.Tools.SpaceManager;

namespace FileSpaceMonitor
{
    class MonitorProgram
    {
        static void Main()
        {
            LogHelper.Log("Monitor Program", "New Launch");            
            ServerSection serverSection = AppConfig.ServerMonitorSection;
            if (serverSection != null)
                foreach (ServerElement se in serverSection.ServerCollection)
                {
                    LogHelper.Log("Monitor Program", "----- Server [" + se.Name + "] -----");
                    FreeSpaceManager fsm = new FreeSpaceManager(se);
                    fsm.CheckFileSpace();
                }
        }
    }
}
