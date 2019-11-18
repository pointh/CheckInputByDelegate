using System;
using System.Diagnostics;

namespace CheckInputByDelegate
{
    class Program
    {
        public delegate bool CheckInputFunc(string s);
        public static event CheckInputFunc Check;

        static bool StringLongerThan2(string s)
        {
            Debug.WriteLine("StringLongerThan2");
            return s.Length > 2;
        }

        static bool StringCanBeInt(string s)
        {
            Debug.WriteLine("StringCanBeInt");
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

        static string CheckedInputMulti(CheckInputFunc[] fArr)
        {
            bool isOK = false;
            string input;
            do
            {
                input = Console.ReadLine();
                foreach (var f in fArr)
                {
                    if (!f(input))
                    {
                        Console.WriteLine($"Špatný vstup {input}");
                        isOK = false;
                        break;
                    }
                    else
                        isOK = true;
                }
            } while (isOK == false);

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

            Check += StringLongerThan2;
            Check += StringCanBeInt;

            string IntLongerThan2Positions = CheckedInputMulti(new CheckInputFunc[] {StringCanBeInt, StringLongerThan2});
            Console.WriteLine($"OK: {IntLongerThan2Positions}\n");
        }
    }
}
