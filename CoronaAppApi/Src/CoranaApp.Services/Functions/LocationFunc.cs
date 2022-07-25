using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronaApp.Services.Functions
{
    public class LocationFunc : ILocationRepository
    {
        public ICollection<Location> GetAll()
        {
            using (var db = new CoronaContext())
            {
                return db.Locations.ToList();
            }
        }
        public ICollection<Location> GetByPatientId(string patientId)
        {
            using (var db = new CoronaContext())
            {
                return db.Locations.Where(l => l.Patient.Id == patientId).ToList();
            }
        }
        public ICollection<Location> GetByCity(string city)
        {
            using (var db = new CoronaContext())
            {
                return db.Locations.Where(l => l.City.Contains(city)).ToList();
            }
        }
        public ICollection<Location> GetByDatesRange(Services.Models.LocationSearch locationSearch)
        {
            using (var db = new CoronaContext())
            {
                return db.Locations.Where(l => l.StartDate >= locationSearch.StartDate && l.EndDate <= locationSearch.EndDate).ToList();
            }
        }
        public void Post(Location location)
        {
            using (var db = new CoronaContext())
            {
                    if (location == null)
                        return;
                    if(location.Patient==null || location.Patient.Id == null)
                        throw new InvalidOperationException();

                    Patient Exitpatient = db.Patients.FirstOrDefault(p => p.Id == location.Patient.Id);
                    if (Exitpatient != null)
                    {
                        if (Exitpatient.Locations == null)
                        {
                            Exitpatient.Locations = new List<Location>();
                        }
                        Exitpatient.Locations.Add(location);
                    }
                    else
                    {
                        db.Locations.Add(location);
                    }
                    db.SaveChanges();
            }
        }
    }
}
