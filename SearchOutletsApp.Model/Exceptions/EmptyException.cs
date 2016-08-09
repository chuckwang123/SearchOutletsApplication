﻿using System;

namespace SearchOutletsApp.Model.Exceptions
{
    public class EmptyException : Exception
    {
        public EmptyException()
        {
        }

        public EmptyException(string message): base(message)
        {
        }

        public EmptyException(string message, Exception inner): base(message, inner)
        {
        }
    }
}