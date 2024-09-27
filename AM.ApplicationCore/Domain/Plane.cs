using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Boing, AirBus }
    public class Plane
    {
        public int Planeid { get; set; }
        public int Capacity { get; set; }
        public PlaneType PlaneType { get; set; }
        public DateTime ManufatureDate { get; set; }
        public ICollection<Flight> flights { get; set; }
    }
}
