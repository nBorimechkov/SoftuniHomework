using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForce
{
    class PartTimeEmployee : Employee
    {
        public PartTimeEmployee(string name, int workHours) : base(name, 20)
        {
        }
    }
}
