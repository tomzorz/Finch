using System;
using System.IO;
using System.Text;
using Finch.Sequences;

namespace Finch
{
    public sealed partial class FinchConsole
    {
        private readonly TextWriter _out;
        private readonly StringBuilder _buffer;

        private int _deferCounter;

        internal int DeferCounter
        {
            get => _deferCounter;
            set
            {
                var tmp = _deferCounter;
                _deferCounter = Math.Max(0, value);
                _deferWritesIntoBuffer = _deferCounter > 0;
                if (tmp == 1 && _deferCounter == 0) FlushBuffer();
            }
        }

        private bool _deferWritesIntoBuffer;

        public FinchConsole()
        {
            Internals.EnsureInitialized();
            _out = Console.Out;
            DeferCounter = 0;
            _buffer = new StringBuilder(128);
        }

        public void Reset() => Write(VT100.SequenceSoftReset);
    }
}
