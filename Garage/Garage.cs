using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;



namespace Garage
{        /// <summary>
         /// En kollektion av fordon
         /// </summary>
         /// <typeparam name="T"></typeparam>

     // Implementering av garage klassen som en generisk samling av fordon och
     // begränsning med constraint "where". Begränsningen gör att garage klassen kan använda egenskapen Vehicle.
     // Begränsningen anger att alla objekt av typ T garanteras att vara antingen ett Vehicle objekt eller 
     // ett objekt som ärver från Vehicle.
    class Garage <T> : IEnumerable <T> where T : Vehicle
    {

     // 
        private T[] _vehicle;
        private int _Count = 0;
        private int _capacity;

        public Garage(int capacity)
        {
            _vehicle = new T[capacity];
            _capacity = capacity;
        }

        public T this[int index] // property
        {
            get { return _vehicle[index]; }
            set {_vehicle[index] = value;
                  _Count++; }
        }
        public int Capacity
        {
            get { return _capacity; }
            set {_vehicle = new T[value];
                 _capacity = value; }
        }

        public void DecreaseCount(int dec)
        {
            _Count -= dec;
        }

        public int Count()
        {
            return _Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_vehicle).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _vehicle.GetEnumerator();
        }

        internal void Park(T vehicle)
        {
            if(_Count <= Capacity)
            {
                for(int i=0;i< _vehicle.Length; i++)
                {
                    if(_vehicle[i]== null)
                    {
                        _vehicle[i] = vehicle;
                        _Count++;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Garage is full.");
            }
        }

    }
}
