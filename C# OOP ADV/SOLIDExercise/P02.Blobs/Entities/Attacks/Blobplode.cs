using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs.Entities.Attacks
{
    class Blobplode : Attack
    {
        public override void Execute(Blob attacker, Blob target)
        {
            if ((attacker.Health /= 2) < 1)
            {
                attacker.Health = 1;
            }
            target.Respond(attacker.Damage * 2);
        }
    }
}
