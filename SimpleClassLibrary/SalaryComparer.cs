using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
    public class SalaryComparer : IComparer<Worker>
    {
        public int Compare(Worker worker1, Worker worker2)
        {
            int worker1Salary = worker1.WorkPlace.Salary;
            int worker2Salary = worker2.WorkPlace.Salary;
            if (worker1Salary > worker2Salary)
                return 1;
            else if (worker1Salary < worker2Salary)
                return -1;
            else
                return 0;
        }
    }
}
