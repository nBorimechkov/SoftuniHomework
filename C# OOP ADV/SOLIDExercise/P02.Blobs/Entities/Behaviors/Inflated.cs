using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs.Entities.Behaviors
{
    class Inflated : Behavior
    {
        private static int InflatedHealthAddition = 50;
        private static int InflatedHealthDecrementer = 10;

        private int sourceInitialHealth;

        private void ApplyTriggerEffect(Blob source)
        {
            source.Health += InflatedHealthAddition;
        }

        public override void Trigger(Blob source)
        {
            this.IsTriggered = true;
            this.ApplyTriggerEffect(source);
        }

        public override void ApplyRecurrentEffect(Blob source)
        {
            if (this.ToDelayRecurrentEffect)
            {
                this.ToDelayRecurrentEffect = false;
            }
            else
            {
                source.Health -= InflatedHealthDecrementer;
            }
        }
    }
}
