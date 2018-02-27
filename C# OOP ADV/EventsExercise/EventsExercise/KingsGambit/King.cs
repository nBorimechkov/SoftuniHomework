using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsGambit
{
    class King
    {
        public event EventHandler UnderAttack;

        public string Name { get; private set; }

        public King(string name)
        {
            this.Name = name;
        }

        public void OnUnderAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");

            if (UnderAttack != null)
            {
                UnderAttack(this, new EventArgs());
            }
        }
    }
}
