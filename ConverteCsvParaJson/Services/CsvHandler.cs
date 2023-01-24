using ConverteCsvParaJson.Extensions;
using ConverteCsvParaJson.Model.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverteCsvParaJson.Services
{
    internal class CsvHandler
    {
        public static List<WorkRegister> ReadFilesList(string[] csvFilePathList)
        {
            var workRegisterList = new List<WorkRegister>();

            foreach (string csvFilePath in csvFilePathList)
            {
                var workRegister = CsvHandler.ReadCsvFile(csvFilePath);
                workRegisterList.AddRange(workRegister);
            }
            return workRegisterList;
        }

        public static List<WorkRegister> ReadCsvFile(string csvFilePath)
        {
            Dictionary<string, string> fileNameDetails = CsvHandler.ReadFileName(csvFilePath);
                
            Stream stream = File.OpenRead(csvFilePath);

            string csvFile = new StreamReader(stream).ReadToEnd();

            List<string> csvFileLines = csvFile.Split('\n').ToList();

            Dictionary<string, int> layoutHeader = CsvExtensions.GetLayoutHeader(csvFileLines[0]);

            List<WorkRegister> workRegisterList = CsvExtensions.ReadCsvLines(csvFileLines, fileNameDetails, layoutHeader);

            return workRegisterList;
        }

        private static Dictionary<string, string> ReadFileName(string csvFilePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(csvFilePath);

            string[] splitedFileName = fileName.Split('-');

            string department = splitedFileName[0];
            string month = splitedFileName[1];
            string year = splitedFileName[2];
            
            return new Dictionary<string, string>()
            {
                {"department",department },
                {"month", month },
                {"year", year }
            };
        }
    }
}
