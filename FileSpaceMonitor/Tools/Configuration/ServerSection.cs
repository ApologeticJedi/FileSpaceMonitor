using System.Configuration;

namespace FileSpaceMonitor.Tools.Configuration
{
    public class ServerSection : ConfigurationSection
    {
        #region fields/properties

        private static ConfigurationProperty _serverCollection;
        private static ConfigurationPropertyCollection _properties;

        [ConfigurationProperty("servers", IsRequired = true)]
        public ServerElementCollection ServerCollection
        {
            get { return (ServerElementCollection)base[_serverCollection]; }
        }

        #endregion

        #region .ctor

        static ServerSection()
        {
            _serverCollection = new ConfigurationProperty("servers", typeof(ServerElementCollection), null,
                ConfigurationPropertyOptions.IsRequired);

            _properties = new ConfigurationPropertyCollection {_serverCollection};
        }

        #endregion

    }
}
