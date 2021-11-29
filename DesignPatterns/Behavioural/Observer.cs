/**
 * GoF DEFINITION:
 * Define a one-to-many dependency between objects so that when one object changes 
 * state, all its dependents are notified and updated automatically.
 * 
 * CONCEPT:
 * In this pattern, there are many observers (objects) that are observing a particular subject 
 * (also an object). Observers want to be notified when there is a change made inside the 
 * subject. So, they register for that subject. When they lose interest in the subject, they 
 * simply unregister from the subject. Sometimes this model is called a Publisher-Subscriber 
 * (Pub-Sub) model. The whole idea can be summarized as follows: using this pattern, an 
 * object (subject) can send notifications to multiple observers (a set of objects) at the same 
 * time. Observers can decide how to respond to the notification, and they can perform 
 * specific actions based upon the notification. 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesignPatterns.Behavioural
{
    #region MANUAL_IMPLEMENTATION
    public interface IObserver
    {
        public void Update(Celebrity subject);
    }

    public class Observer1 : IObserver
    {
        public string Name { get; set; }

        public Observer1(string name)
        {
            Name = name;
        }

        public void Update(Celebrity subject)
        {
            Console.WriteLine($"{Name} notified. Inside {subject.Name}, the updated value is {subject.Flag}.");
        }
    }

    public class Observer2 : IObserver
    {
        public string Name { get; set; }

        public Observer2(string name)
        {
            Name = name;
        }

        public void Update(Celebrity subject)
        {
            Console.WriteLine($"{Name} has received an alert from {subject.Name}. Update value is {subject.Flag}.");
        }
    }

    public abstract class Celebrity
    {
        protected List<IObserver> _observersList = new();
        public string Name { get; }

        private int _flag;
        public int Flag 
        {
            get
            {
                return _flag;
            }
            set
            {
                _flag = value;
                NotifyRegisteredUsers();
            }
        }

        public Celebrity(string name)
        {
            Name = name; 
        }

        public abstract void Register(IObserver observer);
        public abstract void Unregister(IObserver observer);
        public abstract void NotifyRegisteredUsers();
    }

    public class Celebrity1 : Celebrity
    {
        public Celebrity1(string name) : base(name) { }

        public override void Register(IObserver observer)
        {
            base._observersList.Add(observer);
        }

        public override void Unregister(IObserver observer)
        {
            base._observersList.Remove(observer);
        }

        public override void NotifyRegisteredUsers()
        {
            foreach (var observer in base._observersList)
            {
                observer.Update(this);
            }
        }
    }
    #endregion

    #region IMPLEMENTAION_USING_BCL_TYPES
    /// 
    /// Complete explanation at <https://docs.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern>
    /// 

    /// DATA
    public class Temperature
    {
        private decimal _temp;
        private DateTime _date;

        public decimal Degrees => _temp;
        public DateTime Date => _date;

        public Temperature(decimal temperature, DateTime dateTime)
        { 
            _temp = temperature;
            _date = dateTime;
        }
    }

    /// PROVIDER
    public class TemperatureMonitor : IObservable<Temperature>
    {
        private List<IObserver<Temperature>> _observers = new();

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Temperature>> _observers;
            private IObserver<Temperature> _observer;

            public Unsubscriber(List<IObserver<Temperature>> observers, IObserver<Temperature> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer is not null)
                {
                    _observers.Remove(_observer);
                }
            }
        }

        public IDisposable Subscribe(IObserver<Temperature> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber(_observers, observer);
        }

        public void GetTemperature()
        {
            // Create an array of sample data to mimic a temperature device.
            decimal?[] temps = { 14.6m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m, 15.25m, 15.2m, 15.4m, 15.45m, null };
            // Store the previous temperature, so notification is only sent after at least .1 change.
            decimal? previous = null;
            bool start = true;

            foreach (var temp in temps)
            {
                Thread.Sleep(2500);
                if (temp.HasValue)
                {
                    if (start || (Math.Abs(temp.Value - previous.Value) >= 0.1m))
                    {
                        var tempData = new Temperature(temp.Value, DateTime.Now);
                        foreach (var observer in _observers)
                        {
                            observer.OnNext(tempData);
                        }

                        previous = temp;
                        if (start)
                        {
                            start = false;
                        }
                    }
                }
                else
                {
                    foreach (var observer in _observers.ToArray())
                    {
                        if (observer is not null)
                        {
                            observer.OnCompleted();
                        }
                    }

                    _observers.Clear();
                    break;
                }
            }
        }
    }

    /// OBSERVER
    public class TemperatureReport : IObserver<Temperature>
    {
        private IDisposable _unsubscriber;
        private bool _first = true;
        private Temperature _last;

        public virtual void Subscribe(IObservable<Temperature> provider)
        {
            _unsubscriber = provider.Subscribe(this); 
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("Additional temperature data will not be transmitted.");
        }

        public virtual void OnError(Exception exception)
        {
            // Nothing here 
        }

        public virtual void OnNext(Temperature temperature)
        {
            Console.WriteLine($"The temperature is {temperature.Degrees}C at {temperature.Date}");
            if (_first)
            {
                _last = temperature;
                _first = false;
            }
            else
            {
                Console.WriteLine($"     Change {temperature.Degrees - _last.Degrees} in {temperature.Date.ToUniversalTime() - _last.Date.ToUniversalTime()}");
            }
        }
    }
    #endregion
}
