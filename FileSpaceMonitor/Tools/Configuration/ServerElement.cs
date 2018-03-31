using System.Configuration;

namespace FileSpaceMonitor.Tools.Configuration
{
    public class ServerElement : ConfigurationElement
    {
        #region fields/properties

        private static ConfigurationProperty _name;
        private static ConfigurationProperty _path;
        private static ConfigurationProperty _threshold;
        private static ConfigurationProperty _notificationMethod;
        private static ConfigurationPropertyCollection _properties;

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)base[_name]; }
        }

        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return (string)base[_path]; }
        }

        [ConfigurationProperty("threshold", IsRequired = true)]
        public double Threshold
        {
            get { return (double)base[_threshold]; }
        }

        [ConfigurationProperty("notificationMethod", IsRequired = true)]
        public string NotificationMethod
        {
            get { return (string)base[_notificationMethod]; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }

        #endregion

        #region.ctor

        /// <summary>
        /// Server Element with attributes:
        ///    Name                -- Given server name (index)
        ///    Path                -- Network path to use for server
        ///    Threshold           -- the percent full a server can be before warnings are sent out
        ///    Notification Method -- method used to warn about filespace
        /// </summary>
        static ServerElement()
        {
            _name = new ConfigurationProperty("name", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            _path = new ConfigurationProperty("path", typeof(string), null, ConfigurationPropertyOptions.IsRequired);
            _threshold = new ConfigurationProperty("threshold", typeof(double), 90.0, ConfigurationPropertyOptions.IsRequired);
            _notificationMethod = new ConfigurationProperty("notificationMethod", typeof(string), null, ConfigurationPropertyOptions.IsRequired);

            _properties = new ConfigurationPropertyCollection {_name, _path, _threshold, _notificationMethod};
        }

        #endregion
    }
}
