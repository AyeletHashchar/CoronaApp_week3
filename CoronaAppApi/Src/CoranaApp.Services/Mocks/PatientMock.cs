using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services.Mocks
{
    public class PatientMock : IPatientRepository
    {
        public Patient Get(string id)
        {
            return null;
        }

        public ICollection<Patient> GetByAge(int age)
        {
            return null;
        }

        public void Save(Patient patient)
        {
            return;
        }
    }
}
