using System.Linq;
using System.Reflection;
using System.Threading;
using Finch;
using ImageSharp;
using ImageSharp.Formats;
using Color = Finch.Data.Color;

namespace FinchDemos
{
    class Program
    {
        private delegate void Thing();

        static void Main(string[] args)
        {
            var c = new FinchConsole();

            c.WriteLine("Welcome to the Finch Demo app!");
            c.WriteLine();

            c.Write("Press any key for the VIEW demo...");
            c.ReadKey();

            c.ClearScreen();
            ViewDemos(c);
            c.ClearScreen();

            c.WriteLine("Press any key for the STYLE demo, please resize the window to be larger than 128x63...");
            c.WriteLine("... as the program won't let you continue until you do that :)");
            var cs = c.GetSize();
            c.ReadKey();
            while (cs.x < 63 || cs.y < 128)
            {
                c.ReadKey();
                cs = c.GetSize();
            }

            c.ClearScreen();
            StyleDemos(c);
            c.ClearScreen();

            c.Write("Press any key to quit...");
            c.ReadKey();
        }

        private static void StyleDemos(FinchConsole c)
        {
            c.SetCursorVisibility(false);
            var clsCounter = 0;
            var line = 1;
            c.StartBufferedWriting(); // I could buffer this per block instead of per line as well, I know
            for (var b = 0; b <= 255; b += 4)
            {
                for (var g = 0; g <= 255; g += 4)
                {
                    for (var r = 0; r <= 255; r += 4)
                    {
                        c.SetBackgroundColor(new Color((byte)r, (byte)g, (byte)b));
                        c.Write(' ');
                        line += 1;
                        if (line <= 128) continue;
                        clsCounter += 1;
                        line = 1;
                        c.WriteLine();
                        c.EndBufferedWriting();
                        if (clsCounter >= 32)
                        {
                            Thread.Sleep(33);
                            c.SetCursorPosition(1, 1);
                            clsCounter = 0;
                        }
                        c.StartBufferedWriting();
                    }
                }
            }
            c.EndBufferedWriting();
            c.ResetStyles();

            c.SetCursorPosition(1, 1);
            var assembly = Assembly.GetEntryAssembly();
            using (var rs = assembly.GetManifestResourceStream("FinchDemos.explosion.gif"))
            {
                using (var im = Image.Load(new Configuration(new GifFormat()), rs))
                {
                    using (var resized = im.Resize(128,63))
                    {
                        foreach (var resizedFrame in resized.Frames)
                        {
                            var fcc = 0;
                            c.StartBufferedWriting();
                            foreach (var resizedFramePixel in resizedFrame.Pixels)
                            {
                                c.SetBackgroundColor(new Color(resizedFramePixel.R, resizedFramePixel.G, resizedFramePixel.B));
                                c.Write(' ');
                                fcc += 1;
                                if (fcc != 128) continue;
                                c.MoveCursorDown();
                                c.MoveCursorInLine(1);
                                fcc = 0;
                            }
                            c.EndBufferedWriting();
                            Thread.Sleep(16);
                            c.SetCursorPosition(1, 1);
                        }
                    }
                }
            }          

            c.SetCursorVisibility(true);
        }

        private static void ViewDemos(FinchConsole c)
        {
            c.WriteLine("TEST FROZEN LINE 1");
            c.WriteLine("TEST FROZEN LINE 2");

            var size = c.GetSize();

            c.MoveCursorInColumn(size.x - 1);

            c.WriteLine("TEST FROZEN LINE 3");
            c.Write("TEST FROZEN LINE 4");

            c.SetCursorPosition(3, 0);

            c.FreezeLines(2, 2);

            foreach (var i in Enumerable.Range(1, 100))
            {
                c.WriteLine(i.ToString());
                Thread.Sleep(10);
            }

            for (var i = 0; i < 10; i++)
            {
                c.ScrollUp(1);
                Thread.Sleep(20);
            }

            for (var i = 0; i < 10; i++)
            {
                c.ScrollDown(1);
                Thread.Sleep(20);
            }

            c.UnfreezeLines();
        }
    }
}