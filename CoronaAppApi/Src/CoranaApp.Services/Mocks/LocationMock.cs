using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services.Mocks
{
    public class LocationMock : ILocationRepository
    {
        public ICollection<Dal.Models.Location> GetAll()
        {
            return null;
        }

        public ICollection<Dal.Models.Location> GetByCity(string city)
        {
            return null;
        }

        public ICollection<Dal.Models.Location> GetByDatesRange(LocationSearch locationSearch)
        {
            return null;
        }

        public ICollection<Dal.Models.Location> GetByPatientId(string patientId)
        {
            return null;
        }

        public void Post(Dal.Models.Location location)
        {
            return;
        }
    }
}
