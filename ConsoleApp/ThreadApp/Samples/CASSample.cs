using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadApp.Samples
{
    internal class CASSample
    {
        static volatile int syncRoot = 0;

        public static void Run()
        {

            CancellationTokenSource cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;

            Action a = () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var counter = 0L;
                    do
                    {
                        counter++;
                    }
                    while (0 != Interlocked.CompareExchange(ref syncRoot, 1, 0));

                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "->" + counter);
                    Thread.Sleep(20);

                    Interlocked.Decrement(ref syncRoot);
                }

            };
            var tasks = Enumerable.Range(0, 5).Select(_ => Task.Run(a)).ToArray();

            Console.WriteLine("tasks started....");
            Console.ReadLine();

            cts.Cancel();
            Task.WaitAll(tasks);

            Console.Read();
        }
    }
}
