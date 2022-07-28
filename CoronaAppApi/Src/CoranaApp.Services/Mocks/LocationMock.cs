using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Mocks
{
    public class LocationMock : ILocationRepository
    {
        public ICollection<Dal.Models.Location> GetAll()
        {
            return null;
        }

        public Task<ICollection<Dal.Models.Location>> GetAllAsync()
        {
            return null;
        }

        public Task<ICollection<Dal.Models.Location>> GetByAgeAsync(int age)
        {
            return null;
        }

        public ICollection<Dal.Models.Location> GetByCity(string city)
        {
            return null;
        }

        public Task<ICollection<Dal.Models.Location>> GetByCityAsync(string city)
        {
            return null;
        }

        public ICollection<Dal.Models.Location> GetByDatesRange(LocationSearch locationSearch)
        {
            return null;
        }

        public Task<ICollection<Dal.Models.Location>> GetByDatesRangeAsync(LocationSearch locationSearch)
        {
            return null;
        }

        public Task<ICollection<Dal.Models.Location>> GetByLocationSearchAsync(LocationSearch locationSearch)
        {
            return null;
        }

        public ICollection<Dal.Models.Location> GetByPatientId(string patientId)
        {
            return null;
        }

        public Task<ICollection<Dal.Models.Location>> GetByPatientIdAsync(string patientId)
        {
            return null;
        }

        public void Post(Dal.Models.Location location)
        {
            return;
        }

        public Task PostAsync(Dal.Models.Location location)
        {
            throw new NotImplementedException();
        }
    }
}
