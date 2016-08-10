using SearchOutletsApp.Interfaces;

namespace SearchOutletsApp.Util
{
    public class SearchOutletsFactory:IFactory
    {
        public IConfigurationManager WebConfig => new WebConfig();
        public IFileReader Files => new FileReader();
    }
}