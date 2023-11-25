using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
    public class Company
    {
        public string Name;
        public string Position;
        public int Salary;
        private Company workPlace;

        public Company(string[] company)
        {
            this.Name = company[0];
            this.Position = company[1];
            this.Salary = Convert.ToInt32(company[2]);
        }

        public Company(Company workPlace)
        {
            this.workPlace = workPlace;
        }
    }
}

