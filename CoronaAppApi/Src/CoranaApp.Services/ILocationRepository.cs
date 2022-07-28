using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILocationRepository
    {
        public Task<ICollection<Location>> GetAllAsync();
        public Task<ICollection<Location>> GetByPatientIdAsync(string patientId);
        public Task<ICollection<Location>> GetByCityAsync(string city);
        public Task<ICollection<Location>> GetByDatesRangeAsync(Models.LocationSearch locationSearch);
        public Task<ICollection<Location>> GetByAgeAsync(int age);
        public Task PostAsync(Location location);
        Task<ICollection<Location>> GetByLocationSearchAsync(Models.LocationSearch locationSearch);
    }
}
