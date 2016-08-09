using System;

namespace SearchOutletsApp.Model.Exceptions
{
    public class NotSingleException : Exception
    {
        public NotSingleException()
        {
        }

        public NotSingleException(string message): base(message)
        {
        }

        public NotSingleException(string message, Exception inner): base(message, inner)
        {
        }
    }
}
