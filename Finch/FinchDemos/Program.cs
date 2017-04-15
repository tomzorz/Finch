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

            c.WriteLine("TEST FROZEN LINE 1");
            c.WriteLine("TEST FROZEN LINE 2");

            var size = c.GetScreenSize();

            c.MoveCursorInColumn(size.x - 1);

            c.WriteLine("TEST FROZEN LINE 3");
            c.Write("TEST FROZEN LINE 4");

            c.SetCursorPosition(3, 0);

            c.FreezeLines(2, 2);

            foreach (var i in Enumerable.Range(1,1000))
            {
                c.WriteLine(i.ToString());
                Thread.Sleep(20);
            }

            Console.ReadKey();
        }
    }
}