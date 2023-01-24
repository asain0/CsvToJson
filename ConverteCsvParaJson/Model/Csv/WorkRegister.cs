using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverteCsvParaJson.Model.Csv
{
    internal class WorkRegister
    {
        public WorkRegister(string department, string year, string mes, EmployeeCsvModel employeeCsv)
        {
            Department = department;
            Year = year;
            Month = mes;
            EmployeeCsv = employeeCsv;
        }

        public string Department { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public EmployeeCsvModel EmployeeCsv { get; set; }
    }
}
