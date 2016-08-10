using System;

namespace SearchOutletsApp.Model.Exceptions
{
    public class SearchOutletsException : Exception
    {
        public SearchOutletsException()
        {
        }

        public SearchOutletsException(string message): base(message)
        {
        }

        public SearchOutletsException(string message, Exception inner): base(message, inner)
        {
        }
    }
}
