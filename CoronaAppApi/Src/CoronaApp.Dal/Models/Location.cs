using System;

namespace CoronaApp.Dal.Models
{
    public class Location
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public Patient Patient { get; set; }
    }
}