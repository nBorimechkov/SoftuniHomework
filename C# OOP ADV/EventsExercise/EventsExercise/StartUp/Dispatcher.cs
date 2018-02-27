using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp
{
    class Dispatcher
    {
        public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);
        public event NameChangeEventHandler NameChange;
        public string Name
        {
            get { return this.Name; }
            set
                {
                if (NameChange != null)
                {
                    OnNameChange(new NameChangeEventArgs(value));
                }   
            }
        }

        private void OnNameChange(NameChangeEventArgs args)
        {
            if (NameChange != null)
            {
                NameChange(this, args);
            }
        }
    }
}
