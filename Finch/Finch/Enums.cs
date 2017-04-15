using System;
using System.Collections.Generic;
using System.Text;

namespace Finch
{
    public enum EraseKind
    {
        Line,
        Display
    }

    public enum EraseRegion
    {
        FromBeginningToCursor,
        FromCursorToEnd,
        FromBeginningToEnd
    }
}
