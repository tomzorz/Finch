using Finch.Data;
using Finch.Sequences;

namespace Finch
{
    public partial class FinchConsole
    {
        public void SetBackgroundColor(Color c) => Write($"{VT100.SequenceStarter}{string.Format(VT100.SequenceGraphicsRenditionFormatBackgroundRGB, c.R, c.G, c.B)}{VT100.SequenceTerminatorGraphicsRendition}");

        public void SetForegroundColor(Color c) => Write($"{VT100.SequenceStarter}{string.Format(VT100.SequenceGraphicsRenditionFormatForegroundRGB, c.R, c.G, c.B)}{VT100.SequenceTerminatorGraphicsRendition}");

        public void SetInvertedColors(bool isEnabled) => Write($"{VT100.SequenceStarter}{(isEnabled ? VT100.SequenceGraphicsRenditionNegative : VT100.SequenceGraphicsRenditionPositive)}{VT100.SequenceTerminatorGraphicsRendition}");

        public void SetUnderline(bool isEnabled) => Write($"{VT100.SequenceStarter}{(isEnabled ? VT100.SequenceGraphicsRenditionUnderline : VT100.SequenceGraphicsRenditionNoUnderline)}{VT100.SequenceTerminatorGraphicsRendition}");

        public void ResetStyles() => Write($"{VT100.SequenceStarter}{VT100.SequenceGraphicsRenditionDefault}{VT100.SequenceTerminatorGraphicsRendition}");

        // Not implemented as 'Dim' doesn't work on windows, and as a result of that 'Bright' is irreversible

        //public void SetBright() => Write($"{VT100.SequenceStarter}{VT100.SequenceGraphicsRenditionBright}{VT100.SequenceTerminatorGraphicsRendition}");

        //public void SetDim() => Write($"{VT100.SequenceStarter}{VT100.SequenceGraphicsRenditionDim}{VT100.SequenceTerminatorGraphicsRendition}");
    }
}
