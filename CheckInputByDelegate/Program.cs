using System;

namespace CheckInputByDelegate
{
    class Program
    {
        delegate bool CheckInputFunc(string s);

        static bool StringLongerThan2(string s)
        {
            return s.Length > 2;
        }

        static bool StringCanBeInt(string s)
        {
            return int.TryParse(s, out int result);
        }

        static string CheckedInput(CheckInputFunc f)
        {
            string input;
            do
            {
                input = Console.ReadLine();
                if (f(input))
                    break;
                else
                    Console.WriteLine($"Špatný vstup {input}");
            } while (true);

            return input;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Delší než 2 znaky:");
            string TwoAndLonger = CheckedInput(StringLongerThan2);
            Console.WriteLine($"OK: {TwoAndLonger}\n");

            Console.WriteLine("Integer jako string:");
            string IntInString = CheckedInput(StringCanBeInt);
            Console.WriteLine($"OK: {IntInString}\n");
        }
    }
}
