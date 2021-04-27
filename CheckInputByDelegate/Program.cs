using System;
using System.Diagnostics;
using System.Globalization;

namespace CheckInputByDelegate
{
    public delegate bool CheckInputFunc(string s);

    struct CriteriaRecord
    {
        public CheckInputFunc f;
        public string ErrMsg;
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
                        Console.WriteLine($"Špatný vstup: {r.ErrMsg}");
                        isOK = false;
                        //break;
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

        static bool DoubleFrom100To1000(string s)
        {
            CultureInfo czechCultureInfo = CultureInfo.GetCultureInfo("cs-CZ");
            
            double resultLocal = double.NaN, resultCz = double.NaN;

            bool localIsOK = double.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out resultLocal);
            bool CzIsOK = double.TryParse(s, NumberStyles.Float, czechCultureInfo, out resultCz);

            if (localIsOK || CzIsOK)
            {
                if (resultLocal >= 100.0 && resultLocal <= 1000.0)
                    return true;
                if (resultCz >= 100.0 && resultLocal < 1000.0)
                    return true;
                return false;
            }

            return false;
        }

        static void Main()
        {
            Console.WriteLine("Delší než 2 znaky:");
            string TwoAndLonger = CheckedInput(StringLongerThan2);
            Console.WriteLine($"OK: {TwoAndLonger}\n");

            Console.WriteLine("Integer jako string:");
            string IntInString = CheckedInput(StringCanBeInt);
            Console.WriteLine($"OK: {IntInString}\n");

            Console.WriteLine("Double v rozsahu 100 až 1000");
            string doubleLongerThan2Positions = CheckedInputMultiCriteria(
                new CriteriaRecord[] {
                    new CriteriaRecord {
                        f = StringLongerThan2,
                        ErrMsg = "String není delší než 2 znaky"
                    },
                    new CriteriaRecord
                    {
                        f = DoubleFrom100To1000,
                        ErrMsg = "String musí být převoditelný na double <100.0;1000.0>"
                    }
                }
                );
            Console.WriteLine($"OK: {doubleLongerThan2Positions}\n");
        }
    }
}
