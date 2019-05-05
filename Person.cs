using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class Person
    {
        public event Action GoToSleep;
        public event EventHandler DoWork;

        public string Name { get; set; }

        public void TakeTime(DateTime now)
        {
            if(now.Hour <= 8 )
            {
                GoToSleep?.Invoke();
            }
            else
            {
                DoWork?.Invoke(this,null);
            }
        }
    }
}
