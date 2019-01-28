using System;
using System.Collections.Generic;
using System.Text;

namespace Finch.Exceptions
{
    public class FinchFrameBufferException : FinchException
    {
        public FinchFrameBufferException(string message) : base(message)
        {
        }

        public FinchFrameBufferException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
