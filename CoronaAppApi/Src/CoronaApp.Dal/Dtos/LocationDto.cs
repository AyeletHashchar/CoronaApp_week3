using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Dtos
{
    public class LocationDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public Location ToDal(Patient patient)
        {
            return new Location() { 
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                City = this.City, 
                Address = this.Address,
                Patient = patient
            };
        }
    }
}
