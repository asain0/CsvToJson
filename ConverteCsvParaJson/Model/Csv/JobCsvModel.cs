using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverteCsvParaJson.Model.Csv
{
    internal class JobCsvModel
    {
        public JobCsvModel(DateTime dateJob, double hourCost, TimeSpan startJobTime, TimeSpan finishJobTime, TimeSpan startBreakTime, TimeSpan finishBreakTime)
        {
            DateJob = dateJob;
            HourCost = hourCost;
            StartJobTime = startJobTime;
            FinishJobTime = finishJobTime;
            StartBreakTime = startBreakTime;
            FinishBreakTime = finishBreakTime;
        }

        public DateTime DateJob { get; set; }
        public double HourCost { get; set; }
        public TimeSpan StartJobTime { get; set; }
        public TimeSpan FinishJobTime { get; set; }
        public TimeSpan StartBreakTime { get; set; }
        public TimeSpan FinishBreakTime { get; set; }
    }
}
