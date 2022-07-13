using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public interface ILocationRepository
    {
        public ICollection<Location> GetAll();
        public ICollection<Location> GetByPatientId(string patientId);
        public ICollection<Location> GetByCity(string city);
        public ICollection<Location> GetByDatesRange(Models.LocationSearch locationSearch);
        public void Post(Location location);
    }
}
