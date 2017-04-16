using System;

namespace Finch.Exceptions
{
    public abstract class FinchException : Exception
    {
        protected FinchException(string message) : base(message)
        {
        }

        protected FinchException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
