using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Finch;

namespace FinchDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new FinchConsole();

            c.ClearScreen();

            ViewTests(c);

            c.ClearScreen();
            
            Console.ReadKey();
        }

        private static void ViewTests(FinchConsole c)
        {
            c.WriteLine("TEST FROZEN LINE 1");
            c.WriteLine("TEST FROZEN LINE 2");

            var size = c.GetScreenSize();

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