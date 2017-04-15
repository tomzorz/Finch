using System;
using System.Collections.Generic;
using System.Text;

namespace Finch.Data
{
    public static class ColorExtensions
    {
        private static readonly Dictionary<ConsoleColor, Color> ConsoleColorMap = new Dictionary<ConsoleColor, Color>
        {
            [ConsoleColor.Black] = new Color(0, 0, 0),
            [ConsoleColor.Blue] = new Color(0, 0, 0xff),
            [ConsoleColor.Cyan] = new Color(0, 0xff, 0xff),
            [ConsoleColor.DarkBlue] = new Color(0, 0, 0x80),
            [ConsoleColor.DarkCyan] = new Color(0, 0x80, 0x80),
            [ConsoleColor.DarkGray] = new Color(0x64, 0x64, 0x64),
            [ConsoleColor.DarkGreen] = new Color(0, 0x80, 0),
            [ConsoleColor.DarkMagenta] = new Color(0x80, 0, 0x80),
            [ConsoleColor.DarkRed] = new Color(0x80, 0, 0),
            [ConsoleColor.DarkYellow] = new Color(0x80, 0x80, 0),
            [ConsoleColor.Gray] = new Color(0x80, 0x80, 0x80),
            [ConsoleColor.Green] = new Color(0, 0x80, 0),
            [ConsoleColor.Magenta] = new Color(0xff, 0, 0xff),
            [ConsoleColor.Red] = new Color(0xff, 0, 0),
            [ConsoleColor.White] = new Color(0xff, 0xff, 0xff),
            [ConsoleColor.Yellow] = new Color(0xff, 0xff, 0),
        };

        public static Color AsFinchColor(this ConsoleColor c) => ConsoleColorMap[c];
    }
}
