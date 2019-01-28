using System;
using System.Collections.Generic;
using System.Text;

namespace Finch.Utilities
{
    public static class Geometry
    {
        public static bool IsIntersecting((int x1, int x2, int y1, int y2) rect1, (int x1, int x2, int y1, int y2) rect2) 
            => !(rect1.x2 < rect2.x1 || rect2.x2 < rect1.x1 || rect1.y2 < rect2.y1 || rect2.y2 < rect1.y1);
    }
}
