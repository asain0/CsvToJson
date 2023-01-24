using ConverteCsvParaJson.Model.Csv;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConverteCsvParaJson.Extensions
{
    internal class CsvExtensions
    {
        public static Dictionary<string, int> GetLayoutHeader(string header)
        {
            header = header.Replace("\r","");
            string[] titles = header.Split(';');

            Dictionary<string, int> layoutHeader = new Dictionary<string, int>();

            foreach (string title in titles)
                layoutHeader.Add(title.ToUpper(), layoutHeader.Count);
                //Console.WriteLine(Regex.Replace(t, "[^0-9a-zA-Z]+", ""));
            
            return layoutHeader;
        }

        internal static List<WorkRegister> ReadCsvLines(List<string> csvFileLines, Dictionary<string,string> fileNameDetails, Dictionary<string, int> layout)
        {
            csvFileLines.RemoveAt(0);

            List<WorkRegister> workRegisterList = new List<WorkRegister> { };

            csvFileLines.ForEach(
                csvFileLine =>
                {
                    string[] dataColumn = csvFileLine.Split(';');

                    int id = int.Parse(dataColumn[layout["CÓDIGO"]]);
                    string name = dataColumn[layout["NOME"]];
                    double hourCost = StringExtensions.TratarMoeda(dataColumn[layout["VALOR HORA"]]);
                    DateTime dateJob = DateTime.Parse(dataColumn[layout["DATA"]]);
                    TimeSpan startJobTime = TimeSpan.Parse(dataColumn[layout["ENTRADA"]]);
                    TimeSpan finishJobTime = TimeSpan.Parse(dataColumn[layout["SAÍDA"]]);
                    string[] breakTime = dataColumn[layout["ALMOÇO"]].Split('-');

                    TimeSpan startBreakTime = TimeSpan.Parse(breakTime[0]);
                    TimeSpan finishBreakTime = TimeSpan.Parse(breakTime[1]);

                    JobCsvModel job = new JobCsvModel(dateJob, hourCost, startJobTime, finishJobTime, startBreakTime, finishBreakTime);
                    EmployeeCsvModel employeeCsv = new EmployeeCsvModel(id, name, job);

                    WorkRegister newWorkRegister = new WorkRegister(fileNameDetails["department"], fileNameDetails["year"], fileNameDetails["month"], employeeCsv);
                    workRegisterList.Add(newWorkRegister);

                });
            return workRegisterList;
        }



    }
}
