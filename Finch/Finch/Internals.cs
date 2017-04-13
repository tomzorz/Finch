using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Finch.Exceptions;

namespace Finch
{
    internal class Internals
    {
        public static void EnsureInitialized()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;

            var iStdIn = NativeWrappers.GetStdHandle(NativeWrappers.STD_INPUT_HANDLE);
            var iStdOut = NativeWrappers.GetStdHandle(NativeWrappers.STD_OUTPUT_HANDLE);

            if (!NativeWrappers.GetConsoleMode(iStdIn, out uint inConsoleMode))
            {
                throw new FinchInitializationException("Failed to get input console mode.");
            }
            if (!NativeWrappers.GetConsoleMode(iStdOut, out uint outConsoleMode))
            {
                throw new FinchInitializationException("Failed to get output console mode.");
            }

            inConsoleMode |= NativeWrappers.ENABLE_VIRTUAL_TERMINAL_INPUT;
            outConsoleMode |= NativeWrappers.ENABLE_VIRTUAL_TERMINAL_PROCESSING | NativeWrappers.DISABLE_NEWLINE_AUTO_RETURN;

            if (!NativeWrappers.SetConsoleMode(iStdIn, inConsoleMode))
            {
                throw new FinchInitializationException($"Failed to get input console mode, error code: {NativeWrappers.GetLastError()}.");
            }
            if (!NativeWrappers.SetConsoleMode(iStdOut, outConsoleMode))
            {
                throw new FinchInitializationException($"Failed to get output console mode, error code: {NativeWrappers.GetLastError()}.");
            }
        }
    }
}
