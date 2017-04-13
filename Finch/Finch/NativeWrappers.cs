using System;
using System.Runtime.InteropServices;

namespace Finch
{
    internal static class NativeWrappers
    {
        // ReSharper disable InconsistentNaming

        public const int STD_INPUT_HANDLE = -10;

        public const int STD_OUTPUT_HANDLE = -11;

        public const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

        public const uint DISABLE_NEWLINE_AUTO_RETURN = 0x0008;

        public const uint ENABLE_VIRTUAL_TERMINAL_INPUT = 0x0200;

        // ReSharper restore InconsistentNaming

        [DllImport("kernel32.dll")]
        public static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();
    }
}
