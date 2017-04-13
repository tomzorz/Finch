using System;
using System.Collections.Generic;
using System.Text;

namespace Finch
{
    public class FinchConsole
    {
        public FinchConsole()
        {
            Internals.EnsureInitialized();
        }
    }
}
