using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Finch.Data;
using Finch.Exceptions;
using Finch.Sequences;
using Finch.Utilities;

namespace Finch
{
    public sealed partial class FinchConsole
    {
        private readonly TextWriter _out;
        private readonly StringBuilder _buffer;
        private Color _lastKnownBackgroundColor;
        private Color _lastKnownForegroundColor;
        private bool _lastKnownUnderlineSetting;

        private int _deferCounter;

        internal int DeferCounter
        {
            get => _deferCounter;
            set
            {
                var tmp = _deferCounter;
                _deferCounter = Math.Max(0, value);
                _deferWritesIntoBuffer = _deferCounter > 0;
                if (tmp == 1 && _deferCounter == 0) FlushBuffer();
            }
        }

        private bool _deferWritesIntoBuffer;

        public FinchConsole()
        {
            Internals.EnsureInitialized();
            _out = Console.Out;
            DeferCounter = 0;
            _buffer = new StringBuilder(128);
            _framebufferLocations = new Dictionary<string, (int x1, int x2, int y1, int y2)>();
        }

        public void Reset() => Write(VT100.SequenceSoftReset);

        private readonly Dictionary<string, (int x1, int x2, int y1, int y2)> _framebufferLocations;

        public FrameBuffer.MixedFrameBuffer CreateMixedFrameBuffer(int left, int top, int width, int height, Character clearTo = null)
        {
            var size = GetSize();
            var id = Guid.NewGuid().ToString();
            var pos = (left, left + width, top, top + height);
            if (left < 1 || top < 1 || left > size.y || top > size.x)
            {
                throw new FinchFrameBufferException("Invalid position for the TopLeft point: it must be between [1,1] and [consoleSize.x, consoleSize.y]!");
            }
            if (top + height > size.x || left + width > size.y)
            {
                throw new FinchFrameBufferException("Invalid size: no part of the FrameBuffer can be out-of-bounds of the current screen.");
            }
            if (_framebufferLocations.Any(x => Geometry.IsIntersecting(x.Value, pos)))
            {
                throw new FinchFrameBufferException("Can't create a framebuffer that intersects an other one!");
            }
            _framebufferLocations.Add(id, pos);
            return new FrameBuffer.MixedFrameBuffer(this, clearTo ?? new Character
            {
                Background = _lastKnownBackgroundColor ?? ConsoleColor.Black.AsFinchColor(),
                Foreground = _lastKnownForegroundColor ?? ConsoleColor.Gray.AsFinchColor(),
                Content = ' ',
                IsUnderlined = _lastKnownUnderlineSetting
            }, id, pos);
        }

        public FrameBuffer.GraphicsFrameBuffer CreateGraphicsFrameBuffer(int left, int top, int width, int height, Character clearTo = null)
        {
            var size = GetSize();
            var id = Guid.NewGuid().ToString();
            var pos = (left, left + width, top, top + height);
            if (left < 1 || top < 1 || left > size.y || top > size.x)
            {
                throw new FinchFrameBufferException("Invalid position for the TopLeft point: it must be between [1,1] and [consoleSize.x, consoleSize.y]!");
            }
            if (top + height > size.x || left + width > size.y)
            {
                throw new FinchFrameBufferException("Invalid size: no part of the FrameBuffer can be out-of-bounds of the current screen.");
            }
            if (_framebufferLocations.Any(x => Geometry.IsIntersecting(x.Value, pos)))
            {
                throw new FinchFrameBufferException("Can't create a framebuffer that intersects an other one!");
            }
            _framebufferLocations.Add(id, pos);
            return new FrameBuffer.GraphicsFrameBuffer(this, clearTo ?? new Character
            {
                Background = _lastKnownBackgroundColor ?? ConsoleColor.Black.AsFinchColor(),
                Foreground = _lastKnownForegroundColor ?? ConsoleColor.Gray.AsFinchColor(),
                Content = ' ',
                IsUnderlined = false
            }, id, pos);
        }

        internal void RemoveFrameBuffer(string id) => _framebufferLocations.Remove(id);
    }
}
