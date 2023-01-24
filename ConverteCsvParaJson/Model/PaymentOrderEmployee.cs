using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverteCsvParaJson.Model
{
    internal class PaymentOrderEmployee
    {
        public PaymentOrderEmployee(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalSalary{ get; set; }
        public double ExtraHour { get; set; }
        public double AbsenceHours  { get; set; }
        public int AbsenceDays { get; set; }
        public int ExtraDays { get; set; }
        public int WorkedDays { get; set; }

    }
}
