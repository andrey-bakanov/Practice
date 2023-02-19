using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ThreadApp.Samples
{
    /*
     https://www.dotnetcurry.com/patterns-practices/1407/producer-consumer-pattern-dotnet-csharp
     */
    internal class BlockCollection
    {
        public static void Run() {

            BlockingCollection<int> coll = new BlockingCollection<int>();

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken cancellationToken = cts.Token;

            Action consumerAction = () =>
            {
                var buffLength = 23;
                var buff = ArrayPool<int>.Shared.Rent(buffLength);

                int counter = 0;
                foreach (var element in coll.GetConsumingEnumerable(cancellationToken))
                {
                    if(counter < buffLength)
                    {
                        buff[counter++] = element;
                    }
                    else
                    {
                        Console.WriteLine(buff.Length + "->" + JsonSerializer.Serialize(buff));
                        counter = 0;
                        Array.Clear(buff);
                    }
                }

                ArrayPool<int>.Shared.Return(buff, true);
            };

            Action producerAction = async () => { 
                while(!cancellationToken.IsCancellationRequested)
                {
                    for(int i=0; i < 1000; i++)
                    {
                        coll.Add(i);

                        if(cancellationToken.IsCancellationRequested)
                        {
                            return;
                        }

                        int randomIndex = Random.Shared.Next(10, 200);
                        if (i % randomIndex == 0) { 
                            await Task.Delay(randomIndex);
                        }
                    }
                }

            };

            var tasks = Enumerable.Range(0, 5).Select(_ => Task.Factory.StartNew(producerAction, TaskCreationOptions.LongRunning)).ToArray();

            var task = Task.Run(consumerAction);

            Console.WriteLine("tasks started....");
            Console.ReadLine();

            cts.Cancel();
            Task.WaitAll(tasks);

            Console.Read();
        }
    }
}
