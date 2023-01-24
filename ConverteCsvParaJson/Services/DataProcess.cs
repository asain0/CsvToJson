using ConverteCsvParaJson.Model;
using ConverteCsvParaJson.Model.Csv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverteCsvParaJson.Services
{
    internal class DataProcess
    {
        internal static List<PaymentOrder> PaymentOrderProcess(List<WorkRegister> workRegisterList)
        {
            List<PaymentOrder> paymentoOrderList = new List<PaymentOrder> { };

            workRegisterList.ForEach(workRegister =>
            {
                PaymentOrder paymentOrder = new PaymentOrder(workRegister.Department, workRegister.Month, workRegister.Year);

                int paymentoOrderIndex = DataProcess.GetPaymentOrderIndex(paymentoOrderList, paymentOrder);
                bool isNewPaymentOrder = paymentoOrderIndex == -1;
                
                if (isNewPaymentOrder)
                    paymentoOrderList.Add(paymentOrder);

                paymentoOrderIndex = DataProcess.GetPaymentOrderIndex(paymentoOrderList, paymentOrder);

                paymentoOrderList[paymentoOrderIndex] = DataProcess.EmployeeProcess(workRegister.EmployeeCsv, paymentoOrderList[paymentoOrderIndex]);
            });
            return paymentoOrderList;
        }

        private static PaymentOrder EmployeeProcess(EmployeeCsvModel employeeCsvModel, PaymentOrder paymentOrder)
        {

            PaymentOrderEmployee paymentOrderEmployee = new PaymentOrderEmployee(employeeCsvModel.Id, employeeCsvModel.Name);
            int employeeIndex = DataProcess.GetEmployeeIndex(paymentOrder, paymentOrderEmployee);

            bool isNewEmployee = employeeIndex == -1;

            if (isNewEmployee) //se funcionario nao existe
                paymentOrder.EmployeesList.Add(paymentOrderEmployee);
            
            employeeIndex = DataProcess.GetEmployeeIndex(paymentOrder, paymentOrderEmployee);

            //Calcular jornada
            paymentOrder = DataProcess.JobProcess(employeeCsvModel.Job, employeeIndex, paymentOrder);

            return paymentOrder;
        }

        private static PaymentOrder JobProcess(JobCsvModel job, int employeeIndex, PaymentOrder paymentOrder)
        {
            PaymentOrderEmployee employee = paymentOrder.EmployeesList[employeeIndex];

            int workedDays = 0;
            int extraDays = 0;
            int absenceDays = 0;
            double extraHour = 0;
            double absenceHours = 0;
            double dailyWorkload = 8;
            double totalSalary = 0;

            bool isWorkDay = DataProcess.IsWorkDay(job.DateJob);

            //Se um dos pontos não foi registrado
            if (job.StartJobTime.TotalSeconds == 0)
            {
                if(isWorkDay)
                    absenceDays++;

            }
            else
            {
                //Verificar tempo trabalhadas
                double secondsWorked = job.FinishJobTime.TotalSeconds - job.StartJobTime.TotalSeconds;
                //03 - Calcular tempo de intervalo tirado - ok
                double secondsBreak = job.FinishBreakTime.TotalSeconds - job.StartBreakTime.TotalSeconds;
                //04 - Deduzir intervalo da hora trabalhada - ok
                double totalWorkedHours = (secondsWorked - secondsBreak)/3600.0;
                //valor a ser pago ao funcionario
                totalSalary = totalWorkedHours * job.HourCost;
            
                double diferencaHorasTrabalhadas = totalWorkedHours - dailyWorkload;


                if (isWorkDay)
                {
                    workedDays++;

                    if (diferencaHorasTrabalhadas > 0)
                        extraHour = diferencaHorasTrabalhadas;
                    else
                        absenceHours = diferencaHorasTrabalhadas * -1;
                }
                else
                {
                    extraDays++;
                
                    extraHour = totalWorkedHours;
                }
            }

            employee.TotalSalary    += totalSalary;
            employee.ExtraHour      += extraHour;
            employee.AbsenceHours   += absenceHours;
            employee.AbsenceDays    += absenceDays;
            employee.ExtraDays      += extraDays;
            employee.WorkedDays     += workedDays;

            paymentOrder.EmployeesList[employeeIndex] = employee;

            //Atualizando Ordem Pagamento
            var totalDeduction = absenceDays * dailyWorkload * job.HourCost;
            totalDeduction += absenceHours * job.HourCost;
            var totalExtras = extraDays * dailyWorkload * job.HourCost;
            totalExtras = extraHour * job.HourCost;
            
            paymentOrder.TotalExtra += totalExtras;
            paymentOrder.TotalDeduction += totalDeduction;
            paymentOrder.TotalPayment += totalSalary;


            return paymentOrder;

        }

        private static bool IsWorkDay(DateTime workedDay)
        {
            //int dia = workedDay.Day;
            //int month = workedDay.Month;
            //Console.WriteLine($"Teste: {dia}/{month}");
            //List<DateTime> holiday = new List<DateTime>();
            //holiday.Add('');
            bool isWorkDay = true;
            isWorkDay = !(workedDay.DayOfWeek == DayOfWeek.Saturday || workedDay.DayOfWeek == DayOfWeek.Sunday);

            return isWorkDay;
            
        }

        private static int GetEmployeeIndex(PaymentOrder paymentOrder, PaymentOrderEmployee newEmployee)
        {
            List<PaymentOrderEmployee> employeeList = paymentOrder.EmployeesList;
            int employeeIndex = employeeList.FindIndex(employee => employee.Id == newEmployee.Id);
            return employeeIndex;
        }

        internal static int GetPaymentOrderIndex(List<PaymentOrder> paymentOrderList, PaymentOrder newPaymentOrder)
        {
            int paymentoOrderIndex = paymentOrderList.FindIndex(paymentOrder =>
            {
                var condicao = (paymentOrder.CurrentYear == newPaymentOrder.CurrentYear &&
                paymentOrder.Department == newPaymentOrder.Department &&
                paymentOrder.CorrentMonth == newPaymentOrder.CorrentMonth);
                return condicao;
            });
            return paymentoOrderIndex;
        }

    }
}
