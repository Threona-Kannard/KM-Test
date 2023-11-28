using System;

namespace QuestionOne
{
    public class Program
    {
        public static string FizzBuzz(int turns)
        {
            string result = string.Empty;
            for (int i = 1; i <= turns; ++i)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    result += "FizzBuzz\n";
                }
                else if (i % 3 == 0)
                {
                    result += "Fizz\n";
                }
                else if (i % 5 == 0)
                {
                    result += "Buzz\n";
                }
                else
                {
                    result += i.ToString() + "\n";
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write(FizzBuzz(20));
            Console.Read();
        }
    }
}
