
namespace FileSpaceMonitor.Tools.Logging
{
    public abstract class LogBase
    {
        protected readonly object LockObject = new object();
        public abstract void Log(string message);
    }
}
