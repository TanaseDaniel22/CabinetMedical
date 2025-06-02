using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMedical.Core.Entitati
{
    public class Patient
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } 
        public string Adress { get; set; } = string.Empty;
        public List<Prescription> Prescriptions { get; set; } = new();

        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age)) age--;
            return age;
        }
    }
}
