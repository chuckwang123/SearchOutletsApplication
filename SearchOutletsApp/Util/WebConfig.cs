using System.Configuration;
using SearchOutletsApp.Interfaces;

namespace SearchOutletsApp.Util
{
    public class WebConfig : IConfigurationManager
    {
        public string FileLocation => ConfigurationManager.AppSettings["FileLocation"];
        public string ContactsFile => ConfigurationManager.AppSettings["ContactsFile"];
        public string OutletsFile => ConfigurationManager.AppSettings["OutletsFile"];
    }
}
