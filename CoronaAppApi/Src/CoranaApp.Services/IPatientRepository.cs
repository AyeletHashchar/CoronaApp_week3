using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services
{
    public interface IPatientRepository
    {
        public Patient Get(string id);
        public void Save(Patient patient);
        public ICollection<Patient> GetByAge(int age);

    }
}
