using System;
using System.Diagnostics;
using System.Linq;

namespace QuickSort_and_Parallel_QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int j = 10000;
            for (int k=0; k<=7; k++)
            {
                Console.WriteLine($"=======\n {j} elements");
                int[] tab = new int[j];
                Console.WriteLine("Creating array of random integers");
                Random rnd = new Random();
                for (int i = 0; i < j; i++)
                    tab[i] = rnd.Next(-10000000, 10000000);

                int[] tab2 = new int[j];
                int[] tab3 = new int[j];
                Array.Copy(tab, 0, tab2, 0, j);
                Array.Copy(tab, 0, tab3, 0, j);


                Console.WriteLine("continue\n");
                Array.Sort(tab);
                Console.WriteLine("tab2 sorted? " + tab2.SequenceEqual(tab));
                Console.WriteLine("Sequentally sorting the array. Please be patient.\n");
                // Porównanie złożoności czasowej

                Stopwatch sw = new Stopwatch();
                sw.Reset();
                sw.Start();
                QuickSort.SequentialSort(tab2, 0, j - 1);
                sw.Stop();
                TimeSpan seq = sw.Elapsed;
                sw.Reset();
                Console.WriteLine("Sequential Quicksort Time: " + seq);
                Console.WriteLine("tab2 sorted? " + tab2.SequenceEqual(tab));

                Console.WriteLine("tab3 sorted? " + tab3.SequenceEqual(tab));
                Console.WriteLine("Paralelly sorting the array. Please be patient.\n");

                sw.Start();
                QuickSort.ParallelSort(tab3, 0, j - 1);
                sw.Stop();
                TimeSpan par = sw.Elapsed;
                sw.Reset();
                Console.WriteLine("Parallel Quicksort Time: " + par);
                Console.WriteLine("tab3 sorted? " + tab3.SequenceEqual(tab));

                sw.Reset();

                Console.WriteLine("\n\n\n" + (seq - par));

                j *= 5;
            }
            

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
