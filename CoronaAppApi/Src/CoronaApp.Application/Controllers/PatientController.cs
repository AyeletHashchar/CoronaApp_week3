using System.Collections.Generic;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;


namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{

    IPatientRepository _service;
    public PatientController(IPatientRepository service)
    {
        _service = service;
    }

    [HttpGet("id")]
    public Patient Get(string id)
    {
        return _service.Get(id);
    }

    [HttpGet]
    public ICollection<Patient> GetByAge([FromBody] Services.Models.LocationSearch locationSearch)
    {
        return _service.GetByAge(locationSearch.Age);
    }

    [HttpPost]
    public void Save([FromBody]Patient patient)
    {
        _service.Save(patient);
    }

}
