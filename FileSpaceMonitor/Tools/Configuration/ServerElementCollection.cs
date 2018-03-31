using System.Configuration;


namespace FileSpaceMonitor.Tools.Configuration
{
    [ConfigurationCollection(typeof(ServerElement), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class ServerElementCollection : ConfigurationElementCollection
    {
        #region fields/properties

        private static ConfigurationPropertyCollection _properties;
        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        #endregion

        #region Indexers

        public ServerElement this[int index]
        {
            get { return (ServerElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null) BaseRemoveAt(index);
                BaseAdd(index, value);
            }
        }

        public new ServerElement this[string name]
        {
            get { return (ServerElement)BaseGet(name); }
        }

        #endregion

        #region .ctor

        static ServerElementCollection()
        {
            _properties = new ConfigurationPropertyCollection();
        }

        #endregion

        #region methods

        /// <summary>
        /// Creates a new configuration element
        /// </summary>
        /// <returns>new ServerElement</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServerElement();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element
        /// </summary>
        /// <param name="element">ConfigurationElemnt</param>
        /// <returns>Name of ServerElement</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServerElement)element).Name;
        }

        #endregion
    }
}
