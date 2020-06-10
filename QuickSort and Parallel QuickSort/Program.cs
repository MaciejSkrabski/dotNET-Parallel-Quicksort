using System;
using System.Diagnostics;
using System.Linq;

namespace QuickSort_and_Parallel_QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int j = 777;
            Stopwatch sw = new Stopwatch();
            for (int k=0; k<=4; k++)
            {
                Console.WriteLine($"=======\n {j} elements");
                int[] tab = new int[j];
                Console.WriteLine("Creating array of random integers");
                Random rnd = new Random();
                for (int i = 0; i < j; i++)
                    tab[i] = rnd.Next(-10000000, 10000000);

                int[] seq = new int[j];
                int[] par = new int[j];
                int[] doublePS = new int[j];
                int[] fR = new int[j];
                Array.Copy(tab, 0, seq, 0, j);
                Array.Copy(tab, 0, par, 0, j);
                Array.Copy(tab, 0, doublePS, 0, j);
                Array.Copy(tab, 0, fR, 0, j);
                Array.Sort(tab);
                Console.WriteLine("Sorting the array. Please be patient.");
                
                // Porównanie złożoności czasowej
                

                sw.Start();
                QuickSort.SequentialSort(seq, 0, j - 1);
                sw.Stop();
                TimeSpan seqTime = sw.Elapsed;
                sw.Reset();
                Console.WriteLine("Sequential Quicksort Time: " + seqTime);

                sw.Start();
                QuickSort.ParallelSort(par, 0, j - 1);
                sw.Stop();
                TimeSpan parTime = sw.Elapsed;
                sw.Reset();
                Console.WriteLine("Parallel Quicksort Time: " + parTime);

                sw.Start();
                QuickSort.DoublePS(doublePS, 0, j - 1);
                sw.Stop();
                TimeSpan doubleRPSTime = sw.Elapsed;
                sw.Reset();
                Console.WriteLine("RecPar Quicksort Time: " + doubleRPSTime);

                sw.Start();
                QuickSort.FullRecursion(par, 0, j - 1);
                sw.Stop();
                TimeSpan fRTime = sw.Elapsed;
                sw.Reset();
                Console.WriteLine("fR Quicksort Time: " + fRTime);

                j *= 7;
            }
            

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
