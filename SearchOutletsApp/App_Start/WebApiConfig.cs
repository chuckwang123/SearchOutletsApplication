using System.Web.Http;
using SearchOutletsApp.Model;

namespace SearchOutletsApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            config.Formatters.Insert(0, new BrowserJsonFormatter(json));
        }
    }
}
