using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadApp.Samples
{
    internal class MonitorSample
    {
        public static void Run()
        {
            object syncRoot = new object();
            Semaphore semaphore = new Semaphore(2, 2);

            Action a = () =>
            {
                semaphore.WaitOne();

                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                try
                {
                    Thread.Sleep(2000);
                }
                finally
                {
                    semaphore.Release();
                }
            };
            var tasks = Enumerable.Range(0, 5).Select(_ => Task.Run(a));

            Task.WaitAll(tasks.ToArray());
        }
    }
}
