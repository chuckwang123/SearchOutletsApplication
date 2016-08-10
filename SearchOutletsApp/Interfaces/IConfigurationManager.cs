using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchOutletsApp.Interfaces
{
    public interface IConfigurationManager
    {
        string FileLocation { get; }
        string ContactsFile { get; }
        string OutletsFile { get; }
    }
}
