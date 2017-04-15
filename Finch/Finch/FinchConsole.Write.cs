using System;
using System.Collections.Generic;
using System.Text;

namespace Finch
{
    public partial class FinchConsole
    {
        public void Write(char s)
        {
            _out.Write(s);
        }

        public void Write(char[] s)
        {
            _out.Write(s);
        }

        public void Write(string s)
        {
            _out.Write(s);
        }

        public void WriteLine(char s)
        {
            _out.WriteLine(s);
        }

        public void WriteLine(char[] s)
        {
            _out.WriteLine(s);
        }

        public void WriteLine(string s = "")
        {
            _out.WriteLine(s);
        }
    }
}
