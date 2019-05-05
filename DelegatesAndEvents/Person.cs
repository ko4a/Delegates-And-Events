using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class Person
    {

        public string Name { get; set; }
        public event EventHandler DoWork;
        public event EventHandler GoToSleep;


        public void TakeTime(DateTime time)
        {
            if (time.Hour < 8)
                GoToSleep?.Invoke(this, null);
            else
                DoWork?.Invoke(this, null);
        }
    }
}
