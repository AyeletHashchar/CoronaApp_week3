﻿using System;
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
    public class PatientController : ControllerBase
    {

        PatientFunc service = new PatientFunc();

        [HttpGet("id")]
        public Patient Get(string id)
        {
            return service.Get(id);
        }

        [HttpGet]
        public ICollection<Patient> GetByAge([FromBody] Services.Models.LocationSearch locationSearch)
        {
            return service.GetByAge(locationSearch.Age);
        }

        [HttpPost]
        public void Save([FromBody]Patient patient)
        {
            service.Save(patient);
        }

    }
}
