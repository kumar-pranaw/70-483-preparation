using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ThreadStaticDemo
    {
        [ThreadStatic]
        public static int _field;
        public static void ThreadStaticMethod()
        {
            Thread t1 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread A {0}", _field);
                }

            }));
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread B {0}", _field);
                }
            }));
            t2.Start();
        }
        public static void ThreadPoolMethod()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from the threadpool");
            });
            Console.ReadLine();
        }
        public static void ThreadMethod()
        {
            //Task t = Task.Run(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.Write("*");
            //    }
            //});
            //t.Wait();
            Task t = Task.Run(action: ThreadCallerMethod);
            t.Wait();

        }
        public static void ThreadCallerMethod()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("*");
            }
        }
        public static void ContinuationThreadMethod()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });

            t = t.ContinueWith((i) =>
            {
                return i.Result * 2;
            });
            Console.WriteLine(t.Result);
        }

        // In this we can use more task continuation 
        // for ex: continutaion if faulty or if success
        public static void ContinuationMethod()
        {
            Task<int> t = Task.Run(() =>
             {
                 //throw new Exception(); n
                 return 42;
             });
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Success");
            });
            Console.WriteLine(t.Result);
        }

    }
}
