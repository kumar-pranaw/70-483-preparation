using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        // Using Task.WaitAll (1-14)
        // In these if we are using multiple task it will wait
        // for finshing of the all task before it moves on
        public static void TaskAllThread()
        {
            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Task 1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Task 2");
                return 1;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Task 3");
                return 1;
            });
            Task.WaitAll(tasks);
        }

        // Tasks.WaitAny Function (1-15)
        // It will wait for any function to finish
        public static void TaskWaitAny()
        {
            Task<int>[] tasks = new Task<int>[3];
            tasks[0] = Task.Run(() =>
             {
                 Thread.Sleep(2000);
                 return 1;
             });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return 3;
            });
            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];
                Console.WriteLine(completedTask.Result);
                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }
        }

        // Using Paraller.FOr and Parallel.Foreach (1-16)
        public static void ParallelThread()
        {
            //for(int i=0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //    Thread.Sleep(1000);
            //}

            //Parallel.For(0, 10, (i) =>
            //{
            //    Console.WriteLine(i);
            //    Thread.Sleep(1000);
            //});

            int[] myArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //foreach(int x in myArray)
            //{
            //    Console.WriteLine(x);
            //    Thread.Sleep(1000);
            //}

            Parallel.ForEach(myArray, (i) =>
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            });
        }
    }
}

