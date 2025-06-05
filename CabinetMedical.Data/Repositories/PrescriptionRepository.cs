using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabinetMedical.Core.Entitati;
using System.Xml.Linq;

namespace CabinetMedical.Data.Repositories
{
    public class PrescriptionRepository
    {
        // 1. Stocare “in memory” partajata intre instante
        //    astfel incat lista ramane comuna oricarui PrescriptionRepository nou creat.
        private static List<Prescription> _storage = new List<Prescription>();
        private static int _nextId = 1;

        public PrescriptionRepository()
        {
            // Constructorul nu trebuie sa faca altceva,
            // datele sunt pastrate deja in _storage (static).
        }

        // 2. Returneaza toate prescriptiile din stocare
        public IEnumerable<Prescription> GetAll()
        {
            // Returnam o copie a listei pentru a preveni modificari accidentale
            return _storage.ToList();
        }

        // 3. Cauta si returneaza o prescriere dupa ID
        public Prescription? GetById(int id)
        {
            return _storage.FirstOrDefault(p => p.ID == id);
        }

        // 4. Adauga o noua prescriere in stocare
        public void Add(Prescription p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            // Generam un ID nou
            p.ID = _nextId++;
            _storage.Add(p);
        }

        // 5. Actualizeaza o prescriere existenta (daca ID-ul exista)
        public void Update(Prescription p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            // Gasim instanta existenta dupa ID
            var existing = GetById(p.ID);
            if (existing == null) return;

            // Suprascriem toate campurile relevante
            existing.DateIssued = p.DateIssued;
            existing.Medication = p.Medication;
            existing.Dosage = p.Dosage;
            existing.Notes = p.Notes;

            // Deoarece Prescription.Doctor si .Patient sunt obiecte
            // atribuite in forma de editare, le copiem direct
            existing.Doctor = p.Doctor;
            existing.Patient = p.Patient;
        }

        // 6. Sterge o prescriere dupa ID
        public void Delete(int id)
        {
            var toRemove = GetById(id);
            if (toRemove != null)
            {
                _storage.Remove(toRemove);
            }
        }
    }
}