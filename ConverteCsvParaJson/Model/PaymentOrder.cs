using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverteCsvParaJson.Model
{
    internal class PaymentOrder
    {
        public PaymentOrder(string department, string currentMonth, string currentYear)
        {
            Department = department;
            CorrentMonth = currentMonth;
            CurrentYear = currentYear;
            EmployeesList = new List<PaymentOrderEmployee> { };
        }

        public string Department { get; set; }
        public string CorrentMonth { get; set; }
        public string CurrentYear { get; set; }
        public double TotalPayment { get; set; }
        public double TotalDeduction { get; set; }
        public double TotalExtra { get; set; }
        public List<PaymentOrderEmployee> EmployeesList { get; set; }

    }
}
