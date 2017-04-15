using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Finch.Sequences;

namespace Finch
{
    public partial class FinchConsole
    {
        public (int x, int y) GetCursorPosition()
        {
            Write(VT100.SequenceReportPosition);
            var reply = "";
            var i = '0';
            while (i != 'R')
            {
                i  = ReadKey().KeyChar;
                reply += i;
            }
            var iSep = reply.IndexOf(';');
            var x = int.Parse(reply.Substring(2, iSep - 2));
            var y = int.Parse(reply.Substring(iSep + 1, reply.Length - (iSep + 2)));
            return (x, y);
        }

        private void SetCursorPosition((int, int) xy) => SetCursorPosition(xy.Item1, xy.Item2);

        public void SetCursorPosition(int x, int y) => Write(VT100.SequenceStarter + string.Format(VT100.SequenceCursorPositionFormat, x, y));

        #region Position

        private (int, int) _quickSavePosition = (0, 0);

        public void QuickSaveCursorPosition() => _quickSavePosition = GetCursorPosition();

        public void QuickRestoreCursorPosition() => SetCursorPosition(_quickSavePosition);

        private readonly Dictionary<string, (int, int)> _cursorPositions = new Dictionary<string, (int, int)>();

        public void SaveCursorPosition(string id) => _cursorPositions[id] = GetCursorPosition();

        public bool TryRestoreCursorPosition(string id)
        {
            var a = _cursorPositions.TryGetValue(id, out (int x, int y) pos);
            if (a) SetCursorPosition(pos);
            return a;
        }

        public void MoveCursorUp(int i = 1) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorCursorUp}");

        public void MoveCursorDown(int i = 1) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorCursorDown}");

        public void MoveCursorLeft(int i = 1) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorCursorBackward}");

        public void MoveCursorRight(int i = 1) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorCursorForward}");

        public void MoveCursorInLine(int i) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorCursorHorizontalAbsolute}");

        public void MoveCursorInColumn(int i) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorCursorVerticalAbsolute}");

        #endregion Position

        #region Appearance

        public void SetCursorVisibility(bool b) => Write(b ? VT100.SequenceCursorShow : VT100.SequenceCursorHide);

        public void SetCursorBlinking(bool b) => Write(b ? VT100.SequenceCursorEnableBlinking : VT100.SequenceCursorDisableBlinking);

        #endregion Appearance
    }
}
