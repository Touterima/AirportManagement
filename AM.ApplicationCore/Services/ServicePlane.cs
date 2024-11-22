using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        //IGenericRepository<Plane> _repository;

        //public ServicePlane(IGenericRepository<Plane> repository)
        //{
        //    _repository = repository;
        //}

        IUnitOfWork unitOfWork;

        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //public void Add(Plane P)
        //{
        //    //_repository.Add(P);
        //    unitOfWork.Repository<Plane>().Add(P);
        //}

        //public IList<Plane> GetAll()
        //{
        //   //return _repository.GetAll().ToList();
        //   return unitOfWork.Repository<Plane>().GetAll().ToList();
        //}

        //public void Save()
        //{
        //    //_repository.SubmitChanges();
        //    unitOfWork.Save();
        //}

        public List<Passenger> GetPassenger(Plane plane)
        {

            return GetById(plane.PlaneId).Flights.SelectMany(f => f.Tickets).Select(t => t.Passenger).ToList();
        }



        /*public IGrouping<int, List<Flight>> GetFlights(int n)
        {
            // Obtenir les n derniers avions
            var lastNPlanes = planes
                .OrderByDescending(p => p.PlaneId) // On suppose PlaneId comme indicateur temporel
                .Take(n);

            // Regrouper les vols par IdPlane, ordonnés par date de départ
            return lastNPlanes
                .SelectMany(p => p.Flights)
                .OrderBy(f => f.DepartureDate)
                .GroupBy(f => f.PlaneId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
        */

        public IEnumerable<IGrouping<int, Flight>> GetFlights(int n)
        {
            return GetMany().OrderByDescending(p => p.PlanId).Take(n)
                .SelectMany(p => p.Flights)
                .OrderBy(f => f.FlightDate)
                .GroupBy(f => f.PlaneId);
        }

        public bool IsAvailablePlane(int n, Flight flight)
        {
           

            // Calcul du nombre de places disponibles
            int capacity = Get(p=>p.Flights.Contains(flight)==true).Capacity;

            int nbPassenger = Flight.Tichets.Count();
            return capacity > (nbPassenger+n);   // Vérification si on peut réserver n places

        // select many qui hachti bch twallili source de donnée (bch naamch filtrage ...)
        //BoundedChannelFullMode tehseb nombre wla bch twalli relation naaml .fligh toul


        }

        public void deletePlanes()
        {
            var listePlane = GetMany().Where(p => (DateTime.Now - p.ManufactureDate).TotalDays > 0);
            foreach (var plane in listePlane)
            {
                Delete(plane);
            }
            Commit();
        }
    }
}
