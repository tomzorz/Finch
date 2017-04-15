using System;
using System.IO;
using Finch.Sequences;

namespace Finch
{
    public partial class FinchConsole
    {
        private readonly TextWriter _out;

        public FinchConsole()
        {
            Internals.EnsureInitialized();
            _out = Console.Out;
        }
    }
}
