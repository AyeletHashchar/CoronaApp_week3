using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.Functions;
using Microsoft.AspNetCore.Mvc;


namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : Controller
{
    ILocationRepository _service;
    public LocationController(ILocationRepository service)
    {
        _service = service;
    }

    [HttpGet]
    public ICollection<Location> GetAll()
    {
           return _service.GetAll();
    }

    [HttpGet("patientId")]
    public ICollection<Location> GetByPatientId(string patientId)
    {
           return _service.GetByPatientId(patientId);
    }

    [HttpGet("city")]
    public ICollection<Location> GetByCity(string city)
    {
           return _service.GetByCity(city);
    }

    [HttpGet("range")]
    public ICollection<Location> GetByDatesRange([FromBody] Services.Models.LocationSearch locationSearch)
    {
           return _service.GetByDatesRange(locationSearch);
    }

    [HttpPost]
    public void Post([FromBody] Location location)
    {
           _service.Post(location);
    }
}
