using System;
using System.Collections.Generic;
using System.Text;
using Finch.Data;

namespace Finch.FrameBuffer
{
    public abstract partial class FrameBuffer
    {
        public abstract void DrawPoint((int x, int y) p);

        public abstract void DrawLine((int x, int y) p1, (int x, int y) p2);

        /*
         * MAYBE ADD:
         * - beziers
         * - arc
         * ... ?
         */

        public abstract void DrawTriangle((int x, int y) p1, (int x, int y) p2, (int x, int y) p3);

        public abstract void DrawRectangle((int x, int y) topLeft, (int x, int y) bottomRight);

        public abstract void DrawCircle((int x, int y) center, int radius);

        public abstract void FillTriangle((int x, int y) p1, (int x, int y) p2, (int x, int y) p3, Character fill);

        public abstract void FillRectangle((int x, int y) topLeft, (int x, int y) bottomRight, Character fill);

        public abstract void FillCircle((int x, int y) center, int radius, Character fill);

        public abstract void FillImageData(Color[] imageData, int height, int width, (int x, int y) topLeft);
    }
}
