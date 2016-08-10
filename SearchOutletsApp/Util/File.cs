using System;
using System.IO;
using System.Web.Hosting;
using SearchOutletsApp.Interfaces;

namespace SearchOutletsApp.Util
{
    public class FileReader : IFileReader
    {
        private readonly IConfigurationManager _webconfig = new WebConfig();

        public string GetFile(string fileName)
        {
            var content = "";
            // ReSharper disable once AssignNullToNotNullAttribute
            using (var sr = new StreamReader(HostingEnvironment.MapPath(_webconfig.FileLocation + fileName)))
            {
                var line = sr.ReadToEnd();
                content = line.Replace(Environment.NewLine, "");
            }
            return content;
        }
    }
}