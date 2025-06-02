using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CabinetMedical.Core.Entitati;
using CabinetMedical.Core.Repo;

namespace CabinetMedical.Data.Repositories
{
    public class DoctorRepository : CoreDoctorRepository
    {
        // Stocare temporara in memorie
        private readonly List<Doctor> _doctors = new();

        public IEnumerable<Doctor> GetAll()
        {
            /// Returnam o copie ca lista, ca sa nu modificam lista originala in mod neasteptat
            return _doctors.ToList();
        }
        public void Add(Doctor doctor)
        {
            if (doctor == null) throw new ArgumentNullException(nameof(doctor));

            /// Stabilim un ID simplu: 1 + maximul ID-urilor existente
            doctor.ID = (_doctors.Count == 0) ? 1 : _doctors.Max(d => d.ID) + 1;
            _doctors.Add(doctor);
        }
        public void Update(Doctor doctor)
        {
            if (doctor == null) throw new ArgumentNullException(nameof(doctor));

            /// Cautam doctorul dupa ID si inlocuim proprietatile
            var existingDoctor = _doctors.FirstOrDefault(d => d.ID == doctor.ID);
            if (existingDoctor == null)

                throw new InvalidOperationException($"Doctor cu ID={doctor.ID} nu exista.");
                
                /// modificam proprietatile dupa ce ne asiguram ca exista
                existingDoctor.FirstName = doctor.FirstName;
                existingDoctor.LastName = doctor.LastName;
                existingDoctor.Specialization = doctor.Specialization;
                /// Obs : Prescriptions nu este actualizat aici, deoarece presupunem ca nu se schimba
            }

            public void Delete(int doctorID)
            {
                var doctor = _doctors.FirstOrDefault(d => d.ID == doctorID);
                if (doctor == null)

                    throw new InvalidOperationException($"Doctor cu ID={doctorID} nu exista.");
                /// stergem dupa ce ne asiguram ca nu e null
                    _doctors.Remove(doctor);
                }    
            }
    }

