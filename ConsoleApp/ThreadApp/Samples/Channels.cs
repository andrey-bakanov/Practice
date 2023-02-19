using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ThreadApp.Samples
{

    /*
     https://www.dotnetcurry.com/dotnetcore/1509/async-dotnetcore-pattern
     */
    internal class ProdConsChannels
    {
        public static  void Run() {

            CancellationTokenSource cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;


            UnboundedChannelOptions options = new UnboundedChannelOptions();
            options.SingleReader = true;
            
            Channel<long> sharedChannel = Channel.CreateUnbounded<long>(options);

            var consumerTask = Task.Run( async () => { 
            
                while(await sharedChannel.Reader.WaitToReadAsync(cancellationToken))
                {
                    while (sharedChannel.Reader.TryRead(out long val))
                    {
                        Console.WriteLine(val);                        
                    }
                }

            });

            var producers = Enumerable.Range(0, 5).Select(_ => Task.Run(async () => {

                long i = 0;
                while(!cancellationToken.IsCancellationRequested)
                {
                    for (long k = i; k < (i + 1000); k++, i++)
                    {
                        await sharedChannel.Writer.WriteAsync(i, cancellationToken);


                        var rndIndex = Random.Shared.Next(10, 30);
                        if(k % rndIndex == 0)
                        {
                            await Task.Delay(rndIndex * 10);
                        }
                    }
                }

            })).ToArray();



            Console.WriteLine("tasks started....");
            Console.ReadLine();

            cts.Cancel();
            Task.WaitAll(producers);

            Console.Read();

        }
    }
}
