using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_LibraryProject
{
    internal static class StringExtensions
    {
        public static int? ParseToInteger(this string userInput)
        {
            int numericInput;

            if (int.TryParse(userInput, out numericInput))
            {
                return numericInput;
            }
            else
            {
                return null;
            }
        }
    }
}
