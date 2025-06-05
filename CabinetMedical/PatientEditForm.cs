using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CabinetMedical.Core.Entitati;

namespace CabinetMedical
{
    public partial class PatientEditForm : Form
    {
        // 1. Proprietate publica care tine obiectul Patient pe care il cream sau il modificam.
        //    Dupa ce inchidem dialogul cu OK, apelantul (PatientForm) poate citi acest obiect.
        public Patient Patient { get; private set; }

        // 2. Constructor fara parametru => folosim cand adaugam un nou pacient.
        public PatientEditForm()
        {
            InitializeComponent();
            // Cream un obiect gol pentru pacientul nou
            Patient = new Patient();
        }

        // 3. Constructor cu parametru => folosim cand editam un pacient existent.
        //    "p" este obiectul preluat din lista de pacienti, care va fi modificat.
        public PatientEditForm(Patient p) : this()
        {
            // Verificam daca p nu este null; daca e null => aruncam exceptie.
            Patient = p ?? throw new ArgumentNullException(nameof(p), "Pacientul nu poate fi nul.");

            // Pre-populam TextBox-urile cu valorile curente
            txtFirstName.Text = p.FirstName;
            txtLastName.Text = p.LastName;
            dtpBirthDate.Value = p.DateOfBirth;
        }

        // 4. Metoda care se executa la apasarea butonului OK.
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Validarea simpla: se verifica daca vreun camp este gol.
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show(
                    "Campurile de First Name si Last Name trebuie completate",   // mesaj fara diacritice
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return; // iesim din metoda fara a inchide dialogul
            }

            // Daca toate campurile sunt completate, actualizam proprietatea Patient
            Patient.FirstName = txtFirstName.Text.Trim();
            Patient.LastName = txtLastName.Text.Trim();
            Patient.DateOfBirth = dtpBirthDate.Value.Date; // preluam numai data

            // Semnalam ca dialogul s-a inchis cu succes
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 5. Metoda la apasarea butonului Cancel => inchidem dialog cu Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 6. Metoda optionala ResetForm: goleste campurile si recreeaza obiectul Patient
        public void ResetForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            dtpBirthDate.Value = DateTime.Now.Date;
            Patient = new Patient();    // cream un nou pacient gol
            txtFirstName.Focus();
        }
    }
}