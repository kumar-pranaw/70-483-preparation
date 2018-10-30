using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    public static class Thread
    {
        public static void ThreadMethod()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Threadproc: {0}", i);
                System.Threading.Thread.Sleep(0);
            }
        }
        public static void AnotherThread()
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadMethod));
            t.Start();

            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main Thread: Do Some work. ");
                System.Threading.Thread.Sleep(0);
            }
            t.Join();
        }

        public static void ThreadMethod2()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProcess: {0}", i);
                System.Threading.Thread.Sleep(1000);
            }
        }
        public static void BackGroundThreads()
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadMethod2));
            t.IsBackground = false;// Changing isBackground to true will not reflect the changes application will quit
            t.Start();
        }

        /// <summary>
        /// This method takes an argument which will be passing when thread will be started
        /// </summary>
        /// <param object="o"></param>
        public static void ThreadMethodWithParam(object o)
        {
            for(int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i)
;            }
        }
    }
}
