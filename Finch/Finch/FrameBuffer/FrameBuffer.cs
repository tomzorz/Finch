using System;
using System.Collections.Generic;
using System.Text;
using Finch.Data;
using Finch.Exceptions;

namespace Finch.FrameBuffer
{
    public abstract partial class FrameBuffer
    {
        protected readonly FinchConsole Console;
        protected readonly Character ClearCharacter;
        private readonly string _id;
        private readonly (int x1, int x2, int y1, int y2) _pos;
        private int _frameTimimg;
        protected readonly List<Character[,]> Frames;
        protected Character[,] RenderedState;

        /// <summary>
        /// The current frametime
        /// </summary>
        public TimeSpan FrameTime => new TimeSpan(0,0,0,0, _frameTimimg);

        /// <summary>
        /// The current frame count
        /// </summary>
        public int FrameCount => Frames.Count;

        /// <summary>
        /// Returns whether the FrameBuffer is playing it's contents
        /// </summary>
        public bool IsPlaying { get; private set; }

        protected FrameBuffer(FinchConsole console, Character clearCharacter, string id, (int x1, int x2, int y1, int y2) pos)
        {
            Console = console;
            ClearCharacter = clearCharacter;
            _id = id;
            _pos = pos;
            Frames = new List<Character[,]> {new Character[pos.x2 - pos.x1, pos.y2 - pos.y1]};
            RenderedState = new Character[pos.x2 - pos.x1, pos.y2 - pos.y1];
            IsPlaying = false;
        }

        protected abstract (int height, int width) GetLogicalSize();

        /// <summary>
        /// Set frame timing
        /// </summary>
        /// <param name="t">time to wait before rendering new frame during playback</param>
        public void SetFrameTiming(TimeSpan t) => _frameTimimg = Convert.ToInt32(Math.Floor(t.TotalMilliseconds));

        /// <summary>
        /// Renders the current frame to the screen
        /// </summary>
        public void Render()
        {
            if(IsPlaying) return;
            RenderInternal();
        }

        protected abstract void RenderInternal();

        /// <summary>
        /// Continously render the frames with the set timing
        /// </summary>
        public void Play()
        {
            if(IsPlaying) return;
            // TODO start playing
            IsPlaying = true;
        }

        /// <summary>
        /// Stop playing
        /// </summary>
        public void Stop()
        {
            if (!IsPlaying) return;
            // TODO stop playing
            IsPlaying = false;
        }

        /// <summary>
        /// Set how many frames are in the FrameBuffer
        /// </summary>
        /// <param name="count">count of frames</param>
        /// <remarks>If there're going to be less frames than before the last ones will be removed. When adding new frames, they'll be added at the end and cleared.</remarks>
        public void SetFrameCount(int count)
        {
            if(count == Frames.Count) return;
            if (count < 1) throw new FinchFrameBufferException("A FrameBuffer must have at least one frame!");
            if (count > Frames.Count)
            {
                while (count != Frames.Count) Frames.RemoveAt(Frames.Count - 1);
            }
            else
            {
                var diff = count - Frames.Count;
                for (var i = 0; i < diff; i++) Frames.Add(new Character[_pos.x2 - _pos.x1, _pos.y2 - _pos.y1]);
            }
        }
    }
}
