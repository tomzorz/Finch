using System;
using System.Collections.Generic;
using System.Text;

namespace Finch.Data
{
    public class Character
    {
        public Color Foreground { get; set; }

        public Color Background { get; set; }

        public char Content { get; set; }

        public bool IsUnderlined { get; set; }
    }
}
