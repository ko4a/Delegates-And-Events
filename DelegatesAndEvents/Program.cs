using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public delegate void MyDelegate();
    class Program
    {
        public event MyDelegate Event;
        public delegate int ValueDelegate(int intvalue);
        public event Action EventAction;
        static void Main(string[] args)
        {
            #region delegate 
            MyDelegate myDelegate = () =>
            {
                Console.WriteLine("First Init");
            };

            myDelegate();
            Console.WriteLine(new string('-', 50));
            Console.ReadKey();
            myDelegate += SayHello;
            myDelegate();
            Console.ReadKey();
            Console.WriteLine(new string('-', 50));

            MyDelegate mydelegate2 = new MyDelegate(SayGoodBye);
            mydelegate2 += () => Console.ReadKey();
            mydelegate2.Invoke();
            Console.WriteLine(new string('-', 50));

            var mydelegate3 = mydelegate2 + myDelegate;
            mydelegate3.Invoke();
            mydelegate3 -= SayGoodBye;
            mydelegate3.Invoke();

            ValueDelegate valueDelegate = (int k) =>
            {
                Console.WriteLine(k);
                return k;
            };

            Action actionDelegate = SayHello;
            actionDelegate.Invoke();
            Console.ReadKey();

            Func<int, int> func = (int k) =>
              {
                  Console.WriteLine(k);
                  return k;
              };

            valueDelegate.Invoke(5);
            func.Invoke(150);
            Console.ReadKey();

            Predicate<int> predicate = (int
                k) =>
            {
                if (k > 5)
                {
                    Console.WriteLine("value biger 5");
                    return true;
                }
                else Console.WriteLine("value smaller 5");
                return false;
            };

            predicate?.Invoke(10);// если predicate!=null,то invoke его
            predicate?.Invoke(4);
            Console.ReadKey();
            #endregion
            #region event

            Person person = new Person
            {
                Name = "Вася"
            };
            person.GoToSleep += Person_GoToSleep;
            person.DoWork += Person_DoWork;
            person.TakeTime(DateTime.Parse("06.05.2019 21:12:01"));
            person.TakeTime(DateTime.Parse("06.05.2019 1:12:01"));

            #endregion
        }

        private static void Person_DoWork(object sender, EventArgs e)
        {
            if (sender is Person person)
                Console.WriteLine($"{person.Name} работает");
            Console.ReadKey();
        }

        private static void Person_GoToSleep()
        {
            Console.WriteLine("Человек пошёл спать.");
            Console.ReadKey();
        }

        public static void SayHello()
        {
            Console.WriteLine("Hello World");
        }
        public static void SayGoodBye()
        {
            Console.WriteLine("Good Bye");
        }
    }
}
