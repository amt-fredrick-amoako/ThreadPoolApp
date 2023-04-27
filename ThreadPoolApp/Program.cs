namespace ThreadPoolApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the CLR Thread Pool *****\n");
            Console.WriteLine($"Main thread started. ThreadID = {Thread.CurrentThread.ManagedThreadId}");

            Printer printer = new Printer();

            WaitCallback workItem = PrintTheNumbers;

            // Queue the method ten times.
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, printer);
            }

            Console.WriteLine("All tasks queued");
            Console.ReadLine();
        }

        private static void PrintTheNumbers(object? state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }
    }
}