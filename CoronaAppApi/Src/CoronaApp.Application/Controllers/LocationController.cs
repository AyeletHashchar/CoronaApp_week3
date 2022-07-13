using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using CoronaApp.Services.Functions;
using Microsoft.AspNetCore.Mvc;


namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        LocationFunc service = new LocationFunc();

        [HttpGet]
        public ICollection<Location> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet("patientId")]
        public ICollection<Location> GetByPatientId(string patientId)
        {
            return service.GetByPatientId(patientId);
        }

        [HttpGet("city")]
        public ICollection<Location> GetByCity(string city)
        {
            return service.GetByCity(city);
        }

        [HttpGet("range")]
        public ICollection<Location> GetByDatesRange([FromBody] Services.Models.LocationSearch locationSearch)
        {
            return service.GetByDatesRange(locationSearch);
        }

        [HttpPost]
        public void Post([FromBody] Location location)
        {
            service.Post(location);

        }



    }
}
