
namespace FileSpaceMonitor.Tools.SpaceManager
{
    public enum MessagingType
    {
        msg,            //asynchronous msg command 
        messagebox,     //messagebox warning                WARNING: debug only, freezes background process
        email,          //email a distribution list
        slack,          //json post to slack channel
        none            //turn off notification
    }
}
