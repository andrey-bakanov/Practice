using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.Review
{

    public class Person
    {
        public string DocumentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Bus
    {
        private int TrackId;
        private Person Driver;
        private int _currentNumber = 0;
        private string coordinate;

        public Bus(Person p, int id)
        {
            Driver = p;
            TrackId = id;
            Passengers = new ConcurrentDictionary<int, Person>();
        }

        public void Register(Person p)
        {
            Passengers[_currentNumber++] = p;
        }

        private static object _sync = new object();
        public async void CheckCoordinate()
        {
            Monitor.Enter(_sync);
            try
            {
                string temp = await Navigator.GetCoordinate();
                if (!coordinate.Equals(temp))
                {
                    coordinate = temp;
                }
            }
            catch (Exception e)
            {
                Monitor.Exit(_sync);
            }
        }

        public void ChangeDriver(string fn, string ln, string doc)
        {
            Driver.FirstName = fn;
            Driver.LastName = ln;
        }

        public async void StartTrack()
        {
            await TrackDb.StartAsync(TrackId, JsonSerializer.Serialize(Passengers));
            await TrackKafkaQueue.SendStartAsync(TrackId, JsonSerializer.Serialize(Passengers));
        }
        public ConcurrentDictionary<int, Person> Passengers { get; set; }
    }

    internal class TrackKafkaQueue
    {
        internal static Task SendStartAsync(int trackId, object value)
        {
            throw new NotImplementedException();
        }
    }

    internal class TrackDb
    {
        internal static Task StartAsync(int trackId, object value)
        {
            throw new NotImplementedException();
        }
    }

    internal class Navigator
    {
        internal static Task<string> GetCoordinate()
        {
            throw new NotImplementedException();
        }
    }
}
