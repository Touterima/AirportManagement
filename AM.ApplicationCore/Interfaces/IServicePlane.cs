using System;
using System.Collections.Generic;
using System.Linq;
using AM.ApplicationCore.Domain;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane:IService<Plane>
    {
        //public void Add(Plane P);
        //public void Save();

        //public IList<Plane> GetAll();

        public List<Passenger> GetPassenger(Plane plane);
        public IEnumerable<IGrouping<int, Flight>> GetFlights(int n);

        public bool IsAvailablePlane(int n,Flight flight);

    }
}
