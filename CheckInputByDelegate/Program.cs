using System;
using System.Diagnostics;

namespace CheckInputByDelegate
{
    public delegate bool CheckInputFunc(string s);

    struct CriteriaRecord
    {
        internal CheckInputFunc f;
        internal string ErrMsg;
    }

    class Program
    {
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

        static string CheckedInputMultiCriteria(CriteriaRecord[] fArr)
        {
            bool isOK = false;
            string input;
            do
            {
                input = Console.ReadLine();
                foreach (var r in fArr)
                {
                    if (!r.f(input))
                    {
                        Console.WriteLine($"Špatný vstup {r.ErrMsg}");
                        isOK = false;
                        break;
                    }
                    else
                        isOK = true;
                }
            } while (isOK == false);

            return input;
        }

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

        static void Main()
        {
            Console.WriteLine("Delší než 2 znaky:");
            string TwoAndLonger = CheckedInput(StringLongerThan2);
            Console.WriteLine($"OK: {TwoAndLonger}\n");

            Console.WriteLine("Integer jako string:");
            string IntInString = CheckedInput(StringCanBeInt);
            Console.WriteLine($"OK: {IntInString}\n");

            string IntLongerThan2Positions = CheckedInputMultiCriteria(
                new CriteriaRecord[] {
                    new CriteriaRecord {
                        f =StringCanBeInt,
                        ErrMsg = "String není interpretovatelný jako číslo."
                    },
                    new CriteriaRecord {
                        f = StringLongerThan2,
                        ErrMsg = "String není delší než 2 znaky"
                    } }
                );
            Console.WriteLine($"OK: {IntLongerThan2Positions}\n");
        }
    }
}
