using System;

namespace Finch
{
    public partial class FinchConsole
    {
        /*
         *  NOTE:
         *  
         *  In my _totally_ _scientific_ test*, `delegates` performed around 30-40% worse against branching with `if`s.
         *  If my "science" is wrong, feel free to submit a PR with some proof included, thanks!
         *  
         *  [*] = `StringBuilder.Append("asd")` or `StringBuilder.AppendLine("1\r\n")` a zillion times, randomly changing which every `Random.Next(100)` iterations.
         *        Branching with `if`:    7.5696ms,  7.4061ms,  7.3937ms
         *        Switching `delegates`: 10.5812ms, 11.0132ms, 10.4492ms
         *  
         */

        public void Write(char s)
        {
            if (_deferWritesIntoBuffer)
            {
                _buffer.Append(s);
            }
            else
            {
                _out.Write(s);
            }
        }

        public void Write(char[] s)
        {
            if (_deferWritesIntoBuffer)
            {
                _buffer.Append(s);
            }
            else
            {
                _out.Write(s);
            }
        }

        public void Write(string s)
        {
            if (_deferWritesIntoBuffer)
            {
                _buffer.Append(s);
            }
            else
            {
                _out.Write(s);
            }
        }

        public void WriteLine(char s)
        {
            if (_deferWritesIntoBuffer)
            {
                _buffer.Append(s);
                _buffer.AppendLine();
            }
            else
            {
                _out.WriteLine(s);
            }
        }

        public void WriteLine(char[] s)
        {
            if (_deferWritesIntoBuffer)
            {
                _buffer.AppendLine(new string(s));
            }
            else
            {
                _out.WriteLine(s);
            }
        }

        public void WriteLine(string s = "")
        {
            if (_deferWritesIntoBuffer)
            {
                _buffer.AppendLine(s);
            }
            else
            {
                _out.WriteLine(s);
            }
        }


        public void StartBufferedWriting()
        {
            DeferCounter = 1;
        }

        public void EndBufferedWriting()
        {
            DeferCounter = 0;
        }

        private void FlushBuffer()
        {
            if(_buffer == null) return;
            Write(_buffer.ToString());
            _buffer.Clear();
        }

        public class DeferredWritingBlock : IDisposable
        {
            private readonly FinchConsole _console;

            internal DeferredWritingBlock(FinchConsole console)
            {
                _console = console;
                _console.DeferCounter += 1;
            }

            public void Dispose()
            {
                _console.DeferCounter -= 1;
            }
        }
    }
}
