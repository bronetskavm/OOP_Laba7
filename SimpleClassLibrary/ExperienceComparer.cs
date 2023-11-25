using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
    public class ExperienceComparer : IComparer<Worker>
    {
        public int Compare(Worker worker1, Worker worker2)
        {
            int worker1Experience = worker1.GetWorkExperience();
            int worker2Experience = worker2.GetWorkExperience();
            if (worker1Experience > worker2Experience)
                return 1;
            else if (worker1Experience < worker2Experience)
                return -1;
            else
                return 0;
        }
    }
}