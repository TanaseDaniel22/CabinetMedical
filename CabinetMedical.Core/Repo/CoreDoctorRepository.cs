using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabinetMedical.Core.Entitati;

namespace CabinetMedical.Core.Repo
{
    public interface CoreDoctorRepository
    {
        /// <summary> 
        /// Returneaza toti doctorii existenti 
        /// </summary>
        IEnumerable<Doctor> GetAll();

        /// <summary>
        /// Adauga un doctor nou
        /// </summary>
        void Add(Doctor doctor);

        /// <summary>
        /// Actualizeaza un doctor existent
        /// </summary>
        void Update(Doctor doctor);

        /// <summary>
        /// Sterger un doctor dupa ID
        /// </summary>
        void Delete(int id);

    }
}
