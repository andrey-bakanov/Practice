using System.Diagnostics;
using System.Text;

namespace ConsoleApp.Problems
{
    internal static  class CountLetters
    {
        public static void Run()
        {
            string source = "AAAGGTKKLLLTMMTTTSSS";

            Stopwatch sw = Stopwatch.StartNew();
            string result = Transform(source);
            sw.Stop();
            Console.WriteLine( sw.Elapsed +  ":" +  source + " -> " + result);
        }


        private static string Transform(string source)
        { 
            StringBuilder sb = new StringBuilder();

            int counter = 1;

            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] == source[i - 1])
                    counter++;
                else
                { 
                    sb.Append(counter);
                    sb.Append(source[i-1]);

                    counter = 1;
                }

            }
            sb.Append(counter);
            sb.Append(source[source.Length - 1]);
            return sb.ToString();
        
        }
    }
}
