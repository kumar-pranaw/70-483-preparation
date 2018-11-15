using System;

namespace ConsoleApp1
{
    class Program
    {
        public static bool stopped = false;
        static void Main(string[] args)
        {
            Console.WriteLine("**************************** THREADING ****************************");
            Console.WriteLine("\n\n");
            //ThreadProgram.AnotherThread();
            //ThreadProgram.BackGroundThreads();
            //ThreadProgram.ParameterizedThread();

            // Stop Thread Program using Lambda Function
            //Thread t = new Thread(new ThreadStart(() =>
            //{
            //    while (!stopped)
            //    {
            //        Console.WriteLine("Running...");
            //        Thread.Sleep(1000);
            //    }
            //    Console.WriteLine("Thread is stopped");
            //}));
            //t.Start();
            //Console.WriteLine("Press any key to stop the thread");
            //Console.ReadKey();
            //stopped = true;

            //ThreadStaticDemo.ThreadStaticMethod();
            //ThreadStaticDemo.ThreadMethod();
            //Console.WriteLine("\n\n");
            //Console.WriteLine("------------------- Some Extra Concepts of C# --------------------");
            //Console.WriteLine("\n\n");
            //Temprature.DisplayTemprature(DateTime.UtcNow, 12.5);

        }
    }
    class Temprature
    {
        public static void DisplayTemprature(DateTime date, double temp)
        {
            string output;
            //string lblMessage = output;
            output = string.Format("Temprature at {0:t} on {0:dd/mm/yy}", date, temp);
            Console.WriteLine(output);

        }
    }
}
