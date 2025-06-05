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
using CabinetMedical.Data.Repositories;

namespace CabinetMedical
{
    public partial class PrescriptionEditForm : Form
    {
        // 1. Proprietate publica: va tine obiectul Prescription
        //    (fie cel nou creat, fie cel editat). Dupa inchidere, apelantul
        //    poate citi acest obiect.
        public Prescription Prescription { get; private set; }

        // 2. Constructor fara parametru => folosim cand adaugam o noua reteta
        public PrescriptionEditForm()
        {
            InitializeComponent();

            // Cream un Prescription nou (cu sub-obiecte Doctor/Patient goale)
            Prescription = new Prescription();

            // Incarcam listele de doctori si pacienti in cele doua ComboBox-uri
            LoadDoctors();
            LoadPatients();

            // Setam data curenta in DateTimePicker
            dtpDateIssued.Value = DateTime.Now.Date;
        }

        // 3. Constructor cu parametru => folosim cand editam o reteta existenta
        public PrescriptionEditForm(Prescription p) : this()
        {
            // Verificam daca p e null; daca da, aruncam exceptie
            Prescription = p ?? throw new ArgumentNullException(nameof(p), "Reteta nu poate fi goala.");

            // Setam ComboBox-ul de doctori la doctorul ales
            // Cand apelam LoadDoctors() in base constructor, DataSource a fost setat.
            cmbDoctor.SelectedItem = Prescription.Doctor;

            // Setam ComboBox-ul de pacienti
            cmbPatient.SelectedItem = Prescription.Patient;

            // Preluam celelalte valori in controale
            dtpDateIssued.Value = p.DateIssued;
            txtMedication.Text = p.Medication;
            txtDosage.Text = p.Dosage;
            txtNotes.Text = p.Notes;
        }

        // 4. Incarca lista doctorilor in ComboBox-ul cmbDoctor
        private void LoadDoctors()
        {
            // Cream repository-ul de doctori
            var repoDoc = new DoctorRepository();

            // Preluam toti doctorii (lista de obiecte Doctor)
            var list = repoDoc.GetAll().ToList();

            // Setam DataSource = lista de doctori
            cmbDoctor.DataSource = list;

            // Afisam numele complet (folosim metoda GetFullName())
            cmbDoctor.DisplayMember = "GetFullName";

            // ValueMember ar putea fi "ID", dar nu ne folosim direct de el
            cmbDoctor.ValueMember = "ID";
        }

        // 5. Incarca lista pacientilor in ComboBox-ul cmbPatient
        private void LoadPatients()
        {
            var repoPat = new PatientRepository();
            var list = repoPat.GetAll().ToList();
            cmbPatient.DataSource = list;
            cmbPatient.DisplayMember = "LastName";  // afisam doar numele
            cmbPatient.ValueMember = "ID";
        }

        // 6. Metoda la apasarea butonului OK
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Validam ca s-a selectat un doctor si un pacient
            if (cmbDoctor.SelectedItem == null || cmbPatient.SelectedItem == null)
            {
                MessageBox.Show(
                    "Va rugam selectati atat un doctor, cat si un pacient.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return; // iesim, nu inchidem dialogul
            }

            // Copiem valorile din controale in obiectul Prescription

            // I preluam referinta la Doctor-ul selectat
            Prescription.Doctor = cmbDoctor.SelectedItem as Doctor;

            // Preluam referinta la Patient-ul selectat
            Prescription.Patient = cmbPatient.SelectedItem as Patient;

            // Data emiterii
            Prescription.DateIssued = dtpDateIssued.Value.Date;

            // Textul din TextBox-uri
            Prescription.Medication = txtMedication.Text.Trim();
            Prescription.Dosage = txtDosage.Text.Trim();
            Prescription.Notes = txtNotes.Text.Trim();

            // Semnalam ca dialogul s-a inchis cu OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 7. Metoda la apasarea butonului Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 8. Metoda optionala ResetForm: ne permite sa refolosim dialogul
        //    fara a-l distruge, resetand campurile si creand un nou Prescription gol
        public void ResetForm()
        {
            // Reincarcam listele (in caz ca s-a schimbat ceva in Doctori/Pacienti)
            LoadDoctors();
            LoadPatients();

            // Resetam campurile la valori implicite
            dtpDateIssued.Value = DateTime.Now.Date;
            txtMedication.Text = string.Empty;
            txtDosage.Text = string.Empty;
            txtNotes.Text = string.Empty;

            // Cream un nou obiect gol de Prescription
            Prescription = new Prescription();

            // Punem focus pe primul camp util (doctor)
            cmbDoctor.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
