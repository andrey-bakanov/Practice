using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadApp.Samples
{
    internal class ProdConsStack
    {
        public void Run()
        {
            ConcurrentStack<int> queue = new System.Collections.Concurrent.ConcurrentStack<int>();

            CancellationTokenSource cts = new CancellationTokenSource();

            Task producerTask = Task.Run(() => {
                while (!cts.Token.IsCancellationRequested)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        queue.Push(i);
                        if (cts.Token.IsCancellationRequested)
                        {
                            return;
                        }
                        if (i % 100 == 0)
                        {
                            Task.Delay(1000).Wait();
                        }
                    }

                    Thread.Yield();
                }
            });


            Action consumerAction = () => {

                while (!cts.Token.IsCancellationRequested)
                {
                    if (queue.TryPop(out int val))
                    {
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "->" + val + "->" + queue.Count);
                        Thread.Sleep(Random.Shared.Next(0, 20));
                    }
                    else
                    {
                        Thread.Sleep(Random.Shared.Next(0, 20));
                    }
                }
            };

            var consumerTasks = Enumerable.Range(0, 5).Select(_ => Task.Run(consumerAction)).ToArray();

            Console.WriteLine("Iterations program");
            Console.Read();
            cts.Cancel();

            Task.WaitAll(consumerTasks);
            Console.WriteLine("Exit program");
        }
    }
}
