using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronaApp.Services.Functions
{
    public class PatientFunc : IPatientRepository
    {
        public Patient Get(string id)
        {
            using (CoronaContext db = new CoronaContext())
            {
                return db.Patients.FirstOrDefault(p => p.Id == id);
            }
        }

        public ICollection<Patient> GetByAge(int age)
        {
            using (CoronaContext db = new CoronaContext())
            {
                return db.Patients.Where(p => p.Age == age).ToList();
            }
        }
        public void Save(Patient patient)
        {
            using (CoronaContext db = new CoronaContext())
            {
                if (patient == null)
                    return;
                db.Patients.Add(patient);
                db.SaveChanges();
            }
        }
    }
}
