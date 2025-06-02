using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMedical.Core.Entitati
{
    public class Prescription
    {
        public int ID { get; set; }
        public DateTime DateIssued { get; set; }
        public string Medication { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public Doctor Doctor { get; set; } = new Doctor();
        public Patient Patient { get; set; } = new Patient();
        public  string Notes { get; set; } = string.Empty;
    }
}
