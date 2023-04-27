using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolApp
{
    internal class Printer
    {
        private object threadLock = new object();
        public void PrintNumbers()
        {
            Monitor.Enter(threadLock);
            try
            {
                // Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

                // Print out numbers.
                Console.WriteLine("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("{0} ", i);
                    Thread.Sleep(2000);
                }
                Console.WriteLine();
            }
            finally
            {

                Monitor.Exit(threadLock);
            }
        }
    }
}
