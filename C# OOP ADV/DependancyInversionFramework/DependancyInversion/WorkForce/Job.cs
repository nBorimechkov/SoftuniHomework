using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    class Job
    {
        private string name;
        private int hoursRequired;

        public Job(Employee employee, string name, int workHours)
        {
            this.Name = name;
            this.HoursRequired = workHours;
        }

        public int HoursRequired
        {
            get { return hoursRequired; }
            set { hoursRequired = value; }
        }


        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

    }
}
