﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsGambit
{
    class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public override void KingUnderAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
