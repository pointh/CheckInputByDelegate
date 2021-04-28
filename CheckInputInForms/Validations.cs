using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CheckInputInForms
{
    public static class Validations
    {
        public delegate bool CheckInputFunc(string s, List<string> e);

        public static bool CheckedInputWithErrors(CheckInputFunc[] f, string input, List<string> errors)
        {
            bool b = true, thisOK = true;
            foreach (var x in f)
            {
                thisOK = x(input, errors);
                b = b && thisOK;
            }
            return b;
        }

        public static bool StringLongerThan2(string s, List<string> errorList)
        {
            if (s.Length > 2)
            {
                return true;
            }
            else
            {
                errorList.Add("String musí být delší než 2 znaky");
                return false;
            }
        }

        public static bool StringCanBeInt(string s, List<string> errorList)
        {
            if (int.TryParse(s, out int result))
            {
                return true;
            }
            else
            {
                errorList.Add($"{s} nemůže být celé číslo");
                return false;
            }
        }
    }
}
