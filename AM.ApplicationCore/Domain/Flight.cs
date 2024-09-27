using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }

        public DateTime FlightDate { get; set; }

        public DateTime EffectiveArrival { get; set; }

        public int EsstimatedDuration { get; set; }

        public string Departure { get; set; }

        public string Destination { get; set; }

        public ICollection<Passenger> passengers { get; set; }

        public Plane plane { get; set; }

        public override string ToString()
        {
            return "FlightDate: "+ FlightDate+ " EffectiveArrival: "+ EffectiveArrival+" EsstimatedDuration: "+ EsstimatedDuration+ " Departure: "+ Departure+ " Destination: "+ Destination;
        }
    }
}
