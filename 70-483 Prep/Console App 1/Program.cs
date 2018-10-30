using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************************** THREADING ****************************");
            Console.WriteLine("\n\n");
            //Thread.AnotherThread();
           // Thread.BackGroundThreads();
            Console.WriteLine("------------------- Some Extra Concepts of C# --------------------");
            Console.WriteLine("\n\n");
            Temprature.DisplayTemprature(DateTime.UtcNow, 12.5);

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
