using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
    public class Worker
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public double Premium { get; set; }

        public Company WorkPlace { get; set; }

        public Worker(string Name, int Year, int Month, double Premium, string[] WorkPlace)
        {
            this.Name = Name;
            this.Year = Year;
            this.Month = Month;
            this.Premium = Premium;
            this.WorkPlace = new Company(WorkPlace);
        }
        public int GetWorkExperience()
        {
            int totalMonth;
            DateTime date1 = new DateTime();
            TimeSpan date3 = new TimeSpan();
            DateTime date2 = new DateTime();
            date1 = date1.AddYears(DateTime.Now.Year); date1 = date1.AddMonths(DateTime.Now.Month);
            date2 = date2.AddYears(Year); date2 = date2.AddMonths(Month);
            date3 = date1.Subtract(date2);
            totalMonth = date3.Days / 30;
            return totalMonth;
        }

        public void GetTotalMoney(ref int totalMonth)
        {
            int totalMoney;
            totalMoney = WorkPlace.Salary * totalMonth;
            Console.WriteLine($"Total Money: {totalMoney}");
        }
    }

}
