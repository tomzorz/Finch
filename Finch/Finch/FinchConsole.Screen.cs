using Finch.Sequences;

namespace Finch
{
    public partial class FinchConsole
    {
        public void SwitchToNewAlternateScreen()
        {
            Write(VT100.SequenceBufferNewAlternate);
        }

        public void SwitchToMainScreen()
        {
            Write(VT100.SequenceBufferMain);
        }
    }
}
