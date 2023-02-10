using System;

namespace UnitTestReview
{
    class Program
    {
        static void Main(string[] args)
        {
            static string TimeOfDay()
            {
                DateTime tod = DateTime.Now;
                string output;
                if (tod.Hour < 12)
                {
                    Console.WriteLine("Good morning!");
                }
                else if (tod.Hour < 18)
                {
                    Console.WriteLine("Good afternoon!");
                }
                else
                {
                    Console.WriteLine("Good evening!");
                }
            }
        }
    }
}
