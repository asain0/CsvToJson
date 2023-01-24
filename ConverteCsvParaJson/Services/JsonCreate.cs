using ConverteCsvParaJson.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ConverteCsvParaJson.Services
{
    internal class JsonCreate
    {
        public static string PrepareContent( List<PaymentOrder> paymentOrderList)
        {
            string outputContent = "[\n";

            paymentOrderList.ForEach(paymentOrder =>
            {
                outputContent += " {\n";
                outputContent += $"  \"Departamento\": \"{paymentOrder.Department}\"," +
                $"\n  \"MesVigencia\":\"{paymentOrder.CorrentMonth}\"," +
                $"\n  \"AnoVigencia\":{paymentOrder.CurrentYear}," +
                $"\n  \"TotalPagar\":{paymentOrder.TotalPayment.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)},"+
                $"\n  \"TotalDescontos\":{paymentOrder.TotalDeduction.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)},"+
                $"\n  \"TotalExtras\":{paymentOrder.TotalExtra.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)},"+
                $"\n  \"Funcionarios\":[";
                paymentOrder.EmployeesList.ForEach(employee =>
                {
                    outputContent += "\n  {" +
                    $"\n   \"Nome\": \"{employee.Name}\"," +
                    $"\n   \"Codigo\":{employee.Id}," +
                    $"\n   \"TotalReceber\":{employee.TotalSalary.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)},"+
                    $"\n   \"HorasExtras\":{employee.ExtraHour.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)},"+
                    $"\n   \"HorasDebito\":{employee.AbsenceHours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)},"+
                    $"\n   \"DiasFalta\":{employee.AbsenceDays},"+
                    $"\n   \"DiasExtras\":{employee.ExtraDays},"+
                    $"\n   \"DiasTrabalhados\":{employee.WorkedDays}"
                    + "\n  },";
                });
                outputContent = outputContent.Remove(outputContent.Length - 1, 1);
                outputContent += "\n ]\n},";
            });
            outputContent = outputContent.Remove(outputContent.Length - 1, 1);

            outputContent += "]";

            return outputContent;

        }

        public static void SaveJsonFile(string path, string content)
        {
            path += ".json";
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                    sw.WriteLine(content);
            }
            else
                    using (StreamWriter sw = File.CreateText(path))
                        sw.WriteLine(content);
        }
    }

}
