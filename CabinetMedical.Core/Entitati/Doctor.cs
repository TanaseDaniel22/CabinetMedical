using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMedical.Core.Entitati
{
    public class Doctor
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public List<Prescription> Prescriptions { get; set; } = new();
        public string GetFullName() => $"{FirstName} {LastName}";

    };
}
