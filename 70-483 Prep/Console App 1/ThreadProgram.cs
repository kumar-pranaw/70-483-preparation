using System;
using System.Threading;

namespace ConsoleApp1
{
    public static class ThreadProgram
    {
        public static void ThreadMethod()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Threadproc: {0}", i);
                Thread.Sleep(0);
            }
        }
        public static void AnotherThread()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main Thread: Do Some work. ");
                Thread.Sleep(0);
            }
            t.Join();
            Console.WriteLine("After Thread: Do Some work. ");
        }

        public static void ThreadMethod2()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProcess: {0}", i);
                Thread.Sleep(1000);
            } 
        }
        public static void BackGroundThreads()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod2));
            t.IsBackground = true;// Changing isBackground to true will not reflect the changes application will quit
            t.Start();

            t.Join();
        }

        /// <summary>
        /// This method takes an argument which will be passing when thread will be started
        /// </summary>
        /// <param object="o"></param>
        public static void ThreadMethodWithParam(object o)
        {
            for(int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
            }
        }
        public static void ParameterizedThread()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethodWithParam));
            t.Start(15);
            t.Join();
        }
    }
}
