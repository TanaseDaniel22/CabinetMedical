using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CabinetMedical.Core.Entitati;

namespace CabinetMedical
{
    public partial class DoctorEditForm : Form
    {
        // 1. Campul public care va tine obiectul de tip Doctor pe care-l modificam sau cream. Astfel, cand inchidem dialog box-ul, apelantul (DoctorForm)
        // poate citi aceasta propritate si stie ce doctor a fost modificat sau creat.
        public Doctor Doctor { get; private set; }
        // 2. Constructorul fara parametri, e folosit cand vrem sa cream un doctor nou
        public DoctorEditForm()
        {
            InitializeComponent();
            // Cand cream un formular pentru un doctor nou, initializam proprietatea Doctor cu un obiect gol:
            Doctor = new Doctor();
        }
        // 3. Constructorul cu parametru, e folosit cand vrem sa modificam un doctor existent
        // "doc" e obiectul preluat din lista de doctori, care va fi modificat. Il stocam in campul Doctor
        // completam TextBox-urile cu valorile sale, ca sa se vada ce modificam
        public DoctorEditForm(Doctor doc) : this()
        {
            // Verificam daca doc nu e null, altfel aruncam exceptie.
            Doctor = doc ?? throw new ArgumentNullException(nameof(doc), "Doctorul nu poate fi null.");
            txtFirstName.Text = doc.FirstName;
            txtLastName.Text = doc.LastName;
            txtSpecialization.Text = doc.Specialization;
        }
        // 4. Butonul de OK, care valideaza datele si inchide dialog box-ul
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Aici vom lua datele scrise in TextBox-uri si le vom pune in obiectul Doctor
            // (poate e nou creat sau unul existent, in functie de constructorul folosit)

            // *IMPORTANT*: validam simplu: verificam ca textul nu e gol, daca e gol, afisam o eroare
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtSpecialization.Text))
            {
                MessageBox.Show("Toate campurile sunt obligatorii!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // iesim din metoda, nu inchidem dialogul

            }
            // Daca toate sunt bune, actualizam proprietatea Doctor cu datele din TextBox-uri
            // copiem valorile din textbox-uri in proprietatile obiectului Doctor
            Doctor.FirstName = txtFirstName.Text.Trim();
            Doctor.LastName = txtLastName.Text.Trim();
            Doctor.Specialization = txtSpecialization.Text.Trim();

            // Inchidem dialogul cu DialogResult.OK, ca sa semnalam ca totul e ok
            DialogResult = DialogResult.OK;
            // si inchidem formularul
            this.Close();
        }
        // 5. Butonul de Cancel, care inchide dialog box-ul fara sa modifice nimic
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Inchidem dialogul cu DialogResult.Cancel, ca sa semnalam ca nu s-a facut nicio modificare
            DialogResult = DialogResult.Cancel;
            // si inchidem formularul          
            this.Close();
        }

            // Reseteaza (goleste) toate campurile din formular si recreeaza obiectul Doctor
            // Pentru a fi mai usor si rapid de utilizat
            public void ResetForm()
        {
            //1. Goleste text-ul din TextBox
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtSpecialization.Text = string.Empty;

            // 2. Daca vrei sa creezi un Doctor complet nou, astfel incat proprietatea Doctor sa nu mai pointeze la obiectul vechi:
            Doctor = new Doctor();

            // 3. Pune cursorul (Focus) pe primul camp FirstName duh, ca utilizatorul sa poata tasta imediat
            txtFirstName.Focus();
        }
    }
}
