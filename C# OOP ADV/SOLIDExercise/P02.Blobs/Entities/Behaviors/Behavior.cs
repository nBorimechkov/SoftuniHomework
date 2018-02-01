using _02.Blobs.Interfaces;

namespace _02.Blobs.Entities.Behaviors
{
    public abstract class Behavior : IBehavior
    {
        public Behavior()
        {
            this.ToDelayRecurrentEffect = true;
        }

        public bool IsTriggered { get; set; }

        public bool ToDelayRecurrentEffect { get; set; }

        public abstract void Trigger(Blob source);

        public abstract void ApplyRecurrentEffect(Blob source);
    }
}