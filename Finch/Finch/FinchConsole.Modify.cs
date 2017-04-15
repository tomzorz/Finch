using System;
using System.Collections.Generic;
using System.Text;
using Finch.Sequences;

namespace Finch
{
    public partial class FinchConsole
    {
        public void InsertSpace(int i) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorModifyInsertSpaceRight}");

        public void InsertLine(int i) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorModifyInsertLineDown}");

        public void OverwriteWithSpace(int i) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorModifyOverwriteWithSpaceRight}");

        public void Delete(int i) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorModifyDeleteRight}");

        public void DeleteLine(int i) => Write($"{VT100.SequenceStarter}{i}{VT100.SequenceTerminatorModifyDeleteLineDown}");

        public void Erase(EraseKind kind, EraseRegion region)
        {
            // ReSharper disable SwitchStatementMissingSomeCases
            switch (kind)
            {
                case EraseKind.Line:
                    switch (region)
                    {
                        case EraseRegion.FromBeginningToCursor:
                            Write(VT100.SequenceModifyEraseLineFromBeginningToCursor);
                            break;
                        case EraseRegion.FromCursorToEnd:
                            Write(VT100.SequenceModifyEraseLineFromCursorToEnd);
                            break;
                        case EraseRegion.FromBeginningToEnd:
                            Write(VT100.SequenceModifyEraseLine);
                            break;
                    }
                    break;
                case EraseKind.Display:
                    switch (region)
                    {
                        case EraseRegion.FromBeginningToCursor:
                            Write(VT100.SequenceModifyEraseDisplayFromBeginningToCursor);
                            break;
                        case EraseRegion.FromCursorToEnd:
                            Write(VT100.SequenceModifyEraseDisplayFromCursorToEnd);
                            break;
                        case EraseRegion.FromBeginningToEnd:
                            Write(VT100.SequenceModifyEraseDisplay);
                            break;
                    }
                    break;
            }
            // ReSharper restore SwitchStatementMissingSomeCases
        }

        public void ClearScreen()
        {
            Erase(EraseKind.Display, EraseRegion.FromBeginningToEnd);
            SetCursorPosition(1, 1);
        }
    }
}
