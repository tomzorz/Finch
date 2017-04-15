using System;
using System.Collections.Generic;
using System.Text;
using Finch.Sequences;

namespace Finch
{
    public partial class FinchConsole
    {
        public void SwitchToNewAlternateBuffer()
        {
            Write(VT100.SequenceBufferNewAlternate);
        }

        public void SwitchToMainBuffer()
        {
            Write(VT100.SequenceBufferMain);
        }
    }
}
