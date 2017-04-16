using Finch.Sequences;

namespace Finch
{
    public partial class FinchConsole
    {
        public (int x, int y) GetScreenSize()
        {
            var cPos = GetCursorPosition();
            MoveCursorDown(999);
            MoveCursorRight(999);
            var size = GetCursorPosition();
            SetCursorPosition(cPos);
            return size;
        }

        public void ScrollUp(int i) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorViewportScrollDown}");

        public void ScrollDown(int i) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorViewportScrollUp}");

        public void FreezeLines(int top, int bottom)
        {
            var size = GetScreenSize();
            var cPos = GetCursorPosition();
            Write(VT100.SequenceStarter + string.Format(VT100.SequenceScrollingFormat, top + 1, size.x - bottom));
            SetCursorPosition(cPos);
        }

        public void UnfreezeLines() => FreezeLines(0, 0);
    }
}
