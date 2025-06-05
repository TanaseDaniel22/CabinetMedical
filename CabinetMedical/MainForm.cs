using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetMedical
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true; // Setam ca acest formular este container MDI
        }

        // 1. Cand utilizatorul apasa pe "Doctors" in meniu
        private void doctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Deschidem DoctorForm
            var form = new DoctorForm();
            form.MdiParent = this;   // daca vrei sa fie MDI child (vezi sectiunea 4)
            form.Show();
        }

        // 2. Cand utilizatorul apasa pe "Patients" in meniu
        private void patientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PatientForm();
            form.MdiParent = this;   // daca MDI child
            form.Show();
        }

        // 3. Cand utilizatorul apasa pe "Prescriptions" in meniu
        private void prescriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PrescriptionForm();
            form.MdiParent = this;   // daca MDI child
            form.Show();
        }
    }
}