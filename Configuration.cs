using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace client
{
    public class Configuration
    {
        /// <summary>
        /// id
        /// </summary>
        private string _id;
        /// <summary>
        /// password
        /// </summary>
        private string _password;
        /// <summary>
        /// ip
        /// </summary>
        private string _ip;
        /// <summary>
        /// port
        /// </summary>
        private string _port;
        /// <summary>
        /// power
        /// </summary>
        private Power _p; 

        private string _config_path;
        private string _config_file;
        private static XmlDocument Config;
        private static XmlElement root;
        public string Id
        {
            get { return _id; }
        }
        public string Password
        {
            get { return _password; }
        }
        public string Ip
        {
            get { return _ip; }
        }
        public string Port
        {
            get { return _port; }
        }
        public Power P
        {
            get { return _p; }
        }

        public Configuration(string config_path)
        {
            _config_path = config_path;
            _config_file = _config_path+"config.xml";
            Config = new XmlDocument();
            Config.Load(_config_file);
            root = Config.DocumentElement;
        }
        public void Load()
        {
            _id = root.GetElementsByTagName("id").Item(0).InnerText;
            _password = root.GetElementsByTagName("password").Item(0).InnerText;
            _ip = root.GetElementsByTagName("ip").Item(0).InnerText;
            _port = root.GetElementsByTagName("port").Item(0).InnerText;
            if (BaseFunctions.IsNull(root.GetElementsByTagName("power").Item(0).InnerText))
            {
                _p = new Power();
                return;
            }
            _p = (Power)Int32.Parse(root.GetElementsByTagName("power").Item(0).InnerText);
        }
        public void Save(string id, string password, string ip, string port, Power p)
        {
            root.GetElementsByTagName("id").Item(0).InnerText = id;
            root.GetElementsByTagName("password").Item(0).InnerText = password;
            root.GetElementsByTagName("ip").Item(0).InnerText = ip;
            root.GetElementsByTagName("port").Item(0).InnerText = port;
            root.GetElementsByTagName("power").Item(0).InnerText = ((int)p).ToString();
            Config.Save(_config_file);
        }
    }
}
