using CoronaApp.Dal.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Functions
{
    public class LocationFunc : ILocationRepository
    {
        private readonly IConfiguration _configuration;

        public LocationFunc(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ICollection<Location>> GetAllAsync()
        {
            await using (var db = new CoronaContext(_configuration))
            {
                return db.Locations.ToList();
            }
        }
        public async Task<ICollection<Location>> GetByPatientIdAsync(string patientId)
        {
            await using (var db = new CoronaContext(_configuration))
            {
                return db.Locations.Where(l => l.Patient.Id == patientId).ToList();
            }
        }
        public async Task<ICollection<Location>> GetByCityAsync(string city)
        {
            await using (var db = new CoronaContext(_configuration))
            {
                return db.Locations.Where(l => l.City.Contains(city)).ToList();
            }
        }
        public async Task<ICollection<Location>> GetByDatesRangeAsync(Models.LocationSearch locationSearch)
        {
            await using (var db = new CoronaContext(_configuration))
            {
                return db.Locations.Where(l => 
                        l.StartDate >= (locationSearch == null || locationSearch.StartDate == null ? l.StartDate : locationSearch.StartDate) && 
                        l.EndDate <= (locationSearch == null || locationSearch.EndDate == null ? l.EndDate : locationSearch.EndDate)
                    ).ToList();
            }
        }
        public async Task<ICollection<Location>> GetByAgeAsync(int age)
        {
            await using (CoronaContext db = new CoronaContext(_configuration))
            {
                return db.Locations.Where(l => l.Patient.Age == age).ToList();
            }
        }
        public async Task<ICollection<Location>> GetByLocationSearchAsync(Models.LocationSearch locationSearch)
        {
            ICollection<Location> l1 = await GetByDatesRangeAsync(locationSearch);
            ICollection<Location> l2 = await GetByAgeAsync((int)locationSearch?.Age);
            return l1.Intersect(l2).ToList(); 
        }
        public async Task PostAsync(Location location)
        {
            if (location == null || location.Patient == null || location.Patient.Id == null)
                throw new InvalidOperationException();

            await using (var db = new CoronaContext(_configuration))
            {
                Patient Exitpatient = db.Patients.FirstOrDefault(p => p.Id == location.Patient.Id);
                if (Exitpatient == null)
                {
                    await db.Locations.AddAsync(location); //If the patient does'nt exist, he'll be created automatically by this line.
                }
                else
                {
                    if (Exitpatient.Locations == null)
                        Exitpatient.Locations = new List<Location>();
                    Exitpatient.Locations.Add(location);
                }

                await db.SaveChangesAsync();
            }
        }
    }
}
