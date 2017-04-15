using System;
using System.Collections.Generic;
using System.Text;

namespace Finch.Sequences
{

    // from https://msdn.microsoft.com/en-us/library/windows/desktop/mt638032(v=vs.85).aspx

    internal static class VT100
    {
        #region Parts

        public const string SequenceStarter = "\x001b[";

        public const string SequenceStarterOperatingSystemCommand = "\x001b]";

        public const string SequenceTerminatorCursorUp = "A";

        public const string SequenceTerminatorCursorDown = "B";

        public const string SequenceTerminatorCursorForward = "C";

        public const string SequenceTerminatorCursorBackward = "D";

        public const string SequenceTerminatorCursorNextLine = "E";

        public const string SequenceTerminatorCursorPreviousLine = "F";

        public const string SequenceTerminatorCursorHorizontalAbsolute = "G";

        public const string SequenceTerminatorCursorVerticalAbsolute = "d";

        public const string SequenceCursorPositionFormat = "{0};{1}H";

        public const string SequenceTerminatorViewportScrollUp = "S";

        public const string SequenceTerminatorViewportScrollDown = "T";

        public const string SequenceTerminatorModifyInsertSpaceRight = "@";

        public const string SequenceTerminatorModifyDeleteRight = "P";

        public const string SequenceTerminatorModifyOverwriteWithSpaceRight = "X";

        public const string SequenceTerminatorModifyInsertLineDown = "L";

        public const string SequenceTerminatorModifyDeleteLineDown = "M";

        public const string SequenceTerminatorGraphicsRendition = "m";

        public const string SequenceGraphicsRenditionSeparator = ";";

        public const string SequenceGraphicsRenditionDefault = "0";

        public const string SequenceGraphicsRenditionBoldBright = "1";

        public const string SequenceGraphicsRenditionUnderline = "4";

        public const string SequenceGraphicsRenditionNoUnderline = "24";

        public const string SequenceGraphicsRenditionNegative = "7";

        public const string SequenceGraphicsRenditionPositive = "27";

        public const string SequenceGraphicsRenditionFormatForegroundRGB = "38;2;{0};{1};{2}"; // r, g, b

        public const string SequenceGraphicsRenditionFormatBackgroundRGB = "48;2;{0};{1};{2}"; // r, g, b

        public const string SequenceScrollingFormat = "{0};{1}r"; // freeze from top, freeze from bottom

        public const string SequenceWindowTitleFormat = "2;{0}\x0007"; // window title string

        #endregion Parts

        #region Prebuilt

        public const string SequenceCursorEnableBlinking = "\x001b[?12h";

        public const string SequenceCursorDisableBlinking = "\x001b[?12l";

        public const string SequenceCursorShow = "\x001b[?25h";

        public const string SequenceCursorHide = "\x001b[?25l";

        public const string SequenceModifyEraseDisplayFromBeginningToCursor = "\x001b[0J";

        public const string SequenceModifyEraseDisplayFromCursorToEnd = "\x001b[1J";

        public const string SequenceModifyEraseDisplay = "\x001b[2J";

        public const string SequenceModifyEraseLineFromBeginningToCursor = "\x001b[0K";

        public const string SequenceModifyEraseLineFromCursorToEnd = "\x001b[1K";

        public const string SequenceModifyEraseLine = "\x001b[2K";

        public const string SequenceReportPosition = "\x001b[6n"; // ESC[<r>;<c>R  Where <r> = cursor row and <c> = cursor column

        public const string SequenceDesignateCharacterSetDECLineDrawing = "\x001b(0";

        public const string SequenceDesignateCharacterSetASCII = "\x001b(B";

        public const string SequenceBufferNewAlternate = "\x001b[?1049h";

        public const string SequenceBufferMain = "\x001b[?1049l";

        public const string SequenceSoftReset = "\x001b[!p";

        #endregion Prebuilt

        #region Input

        public const string InputNormalUpArrow = "\x001b[A";

        public const string InputNormalDownArrow = "\x001b[B";

        public const string InputNormalRightArrow = "\x001b[C";

        public const string InputNormalLeftArrow = "\x001b[D";

        public const string InputNormalHome = "\x001b[H";

        public const string InputNormalEnd = "\x001b[F";

        public const string InputNormalCtrlUpArrow = "\x001b[1;5A";

        public const string InputNormalCtrlDownArrow = "\x001b[1;5B";

        public const string InputNormalCtrlRightArrow = "\x001b[1;5C";

        public const string InputNormalCtrlLeftArrow = "\x001b[1;5D";

        public const string InputBackspace = "\x007f";

        public const string InputPause = "\x001a";

        public const string InputEscape = "\x001b";

        public const string InputInsert = "\x001b[2~";

        public const string InputDelete = "\x001b[3~";

        public const string InputPageUp = "\x001b[5~";

        public const string InputPageDown = "\x001b[6~";

        public const string InputF1 = "\x001bOP";

        public const string InputF2 = "\x001bOQ";

        public const string InputF3 = "\x001bOR";

        public const string InputF4 = "\x001bOS";

        public const string InputF5 = "\x001b[15~";

        public const string InputF6 = "\x001b[16~";

        public const string InputF7 = "\x001b[17~";

        public const string InputF8 = "\x001b[18~";

        public const string InputF9 = "\x001b[19~";

        public const string InputF10 = "\x001b[20~";

        public const string InputF11 = "\x001b[21~";

        public const string InputF12 = "\x001b[22~";

        #endregion Input

        #region Other

        public const string DECLineDrawingCornerLeftTop = "j";

        public const string DECLineDrawingCornerBottomLeft = "k";

        public const string DECLineDrawingCornerRightBottom = "l";

        public const string DECLineDrawingCornerTopRight = "m";

        public const string DECLineDrawingCross = "n";

        public const string DECLineDrawingHorizontal = "q";

        public const string DECLineDrawingHorizontalAndTop = "v";

        public const string DECLineDrawingHorizontalAndBottom = "w";

        public const string DECLineDrawingVertical = "x";

        public const string DECLineDrawingVerticalAndRight = "t";

        public const string DECLineDrawingVerticalAndLeft = "u";

        #endregion Other
    }
}
