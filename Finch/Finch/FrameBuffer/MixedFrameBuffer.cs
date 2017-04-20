using System;
using System.Collections.Generic;
using System.Text;
using Finch.Data;

namespace Finch.FrameBuffer
{
    /// <summary>
    /// A regular framebuffer that allows for mixed graphical and textual content
    /// </summary>
    public class MixedFrameBuffer : FrameBuffer
    {
        internal MixedFrameBuffer(FinchConsole console, Character clearCharacter, string id, (int x1, int x2, int y1, int y2) pos) : base(console, clearCharacter, id, pos)
        {
        }

        // TODO:

        // o(n) for calculating diff between frames, + create code that changes it
        // cache for code between frames, so no recreation is needed for playback
        // maybe allow options for different algos that create shorter change code (eg. group similar chars together in different spots and move cursor only)
        // ooor maybe do that last thing automatically depending on the amount of color-pairs in the scene? this might be doable...
        // also: allow for double-vertical resolution content by using chars! (this disables text of course, but nicer images/gifs!)

        protected override (int height, int width) GetLogicalSize()
        {
            throw new NotImplementedException();
        }

        protected override void RenderInternal()
        {
            
        }

        public override void DrawPoint((int x, int y) p)
        {
            throw new NotImplementedException();
        }

        public override void DrawLine((int x, int y) p1, (int x, int y) p2)
        {
            throw new NotImplementedException();
        }

        public override void DrawTriangle((int x, int y) p1, (int x, int y) p2, (int x, int y) p3)
        {
            throw new NotImplementedException();
        }

        public override void DrawRectangle((int x, int y) topLeft, (int x, int y) bottomRight)
        {
            throw new NotImplementedException();
        }

        public override void DrawCircle((int x, int y) center, int radius)
        {
            throw new NotImplementedException();
        }

        public override void FillTriangle((int x, int y) p1, (int x, int y) p2, (int x, int y) p3, Character fill)
        {
            throw new NotImplementedException();
        }

        public override void FillRectangle((int x, int y) topLeft, (int x, int y) bottomRight, Character fill)
        {
            throw new NotImplementedException();
        }

        public override void FillCircle((int x, int y) center, int radius, Character fill)
        {
            throw new NotImplementedException();
        }

        public override void FillImageData(Color[] imageData, int height, int width, (int x, int y) topLeft)
        {
            throw new NotImplementedException();
        }
    }
}
