using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21
{
    internal class Program
    {
        const int a = 5;
        const int b = 5;
        static int[,] Garden = new int[a, b];
        static void Main(string[] args)
        {
            Random random = new Random();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Garden[i, j] = random.Next(0, 10);
                    Console.Write($"{Garden[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();

            ThreadStart threadStart = new ThreadStart(Gardener1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardener2();

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write($"{Garden[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void Gardener1()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (Garden[i, j] >= 0)
                    {
                        int time = Garden[i, j];
                        Garden[i, j] = -1;
                        Thread.Sleep(time);
                    }
                }
            }
        }
        static void Gardener2()
        {
            for (int i = b - 1; i >= 0; i--)
            {
                for (int j = a - 1; j >= 0; j--)
                {
                    if (Garden[i, j] >= 0)
                    {
                        int time = Garden[i, j];
                        Garden[i, j] = -2;
                        Thread.Sleep(time);
                    }
                }
            }
        }
    }
}
