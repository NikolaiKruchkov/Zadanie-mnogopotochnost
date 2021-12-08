using System;
using System.Threading;
namespace Zadanie_mnogopotochnost
{
    class Program
    {
        static int i = 6;
        static int j = 4;
        static int[,] pole = new int[i, j];
        static object locker = new object();
         


        static void Sadovnik1()
        {
            
            lock (locker)
            {
                for (int k=j-1; k>=0; k--)
                {
                    for (int f =0; f<i; f++)
                    {
                        if (pole[f, k] == 0)
                        {
                            pole[f, k] = 1;
                            Console.WriteLine($"Садовник 1 обработал поле {f}, {k}");
                            
                        }
                        Thread.Sleep(100);

                    }
                }
                

            }

        }
        static void Sadovnik2()
        {

                for (int m = i - 1; m >= 0; m--)
                {
                    for (int o = 0; o < j; o++)
                    {
                        if (pole[m, o] == 0)
                        {
                            pole[m, o] = 1;
                            Console.WriteLine(new string (' ', 20)+$"Садовник 2 обработал поле {m}, {o}");
                            
                        }
                    Thread.Sleep(100);
                }
                }
    
        }

        static void Main(string[] args)
        {


            ThreadStart threadStart = new ThreadStart(Sadovnik2);
            Thread myThread = new Thread(threadStart);
            myThread.Start();
            Sadovnik1();
            Console.ReadKey();




        }
    }
}
