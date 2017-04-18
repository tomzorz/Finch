using System;
using System.Collections.Generic;
using System.Text;

namespace Finch.FrameBuffer
{
    public partial class FrameBuffer
    {
        private void RenderInternal()
        {
			// TODO:

			// o(n) for calculating diff between frames, + create code that changes it
			// cache for code between frames, so no recreation is needed for playback
			// maybe allow options for different algos that create shorter change code (eg. group similar chars together in different spots and move cursor only)
			// ooor maybe do that last thing automatically depending on the amount of color-pairs in the scene? this might be doable...
			// also: allow for double-vertical resolution content by using chars! (this disables text of course, but nicer images/gifs!)
        }
    }
}
