using System.Configuration;

namespace SearchOutletsApp.Util
{
    public class WebConfig
    {
        public string FileLocation => ConfigurationManager.AppSettings["FileLocation"];
        public string ContactsFile => ConfigurationManager.AppSettings["ContactsFile"];
        public string OutletsFile => ConfigurationManager.AppSettings["OutletsFile"];
    }
}
