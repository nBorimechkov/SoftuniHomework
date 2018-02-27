
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public int WorkHoursPerWeek { get; set; }

        public Employee(string name, int workHours)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHours;
        }
    }
}
