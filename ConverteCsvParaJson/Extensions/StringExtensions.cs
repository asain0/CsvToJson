using ConverteCsvParaJson.Model.Csv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverteCsvParaJson.Extensions
{
    internal class StringExtensions
    {
        internal static double TratarMoeda(string inputString)
        {
            double value = Convert.ToDouble(inputString.Replace("R$ ", ""));
            return value;
        }
    }
}
