using CoronaApp.Dal.Dtos;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILocationRepository
    {
        public Task<ICollection<Location>> GetAllAsync();
        public Task<ICollection<Location>> GetByPatientIdAsync(ClaimsPrincipal user);
        public Task<ICollection<Location>> GetByCityAsync(string? city);
        public Task<ICollection<Location>> GetByDatesRangeAsync(Models.LocationSearch locationSearch);
        public Task<ICollection<Location>> GetByAgeAsync(int age);
        public Task PostAsync(LocationDto location, ClaimsPrincipal user);
        Task<ICollection<Location>> GetByLocationSearchAsync(Models.LocationSearch locationSearch);
    }
}
