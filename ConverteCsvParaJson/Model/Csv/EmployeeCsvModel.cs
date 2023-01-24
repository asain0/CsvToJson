using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverteCsvParaJson.Model.Csv
{
    internal class EmployeeCsvModel
    {
        public EmployeeCsvModel(int id, string name, JobCsvModel job)
        {
            Id = id;
            Name = name;
            Job = job;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public JobCsvModel Job { get; set; }
    }
}
