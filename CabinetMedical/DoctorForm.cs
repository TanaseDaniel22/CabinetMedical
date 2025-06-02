using System;  // tipuri de baza (EventARgs, Exception etc.)
using System.Collections.Generic; // Pentru metodele LINQ (ToList(), FirstOrDefault(), Max() etc.)
using System.ComponentModel; // Pentru BindingList<T> si INotifyPropertyChanged
using System.Data; // Pentru DataTable, DataSet etc.
using System.Drawing; // Pentru tipuri de date grafice (Color, Font, Image etc.)
using System.Drawing.Text;
using System.Linq; // Pentru LINQ (Select, Where, OrderBy etc.)
using System.Text; // Pentru manipularea stringurilor
using System.Threading.Tasks; // Pentru Task, async/await
using System.Windows.Forms; // Pentru Windows Forms (Form, Button, TextBox DataGridView, MessageBox etc.)
using CabinetMedical.Core.Entitati; // Pentru entitatile de baza (Doctor, Patient, Prescription etc.)
using CabinetMedical.Core.Repo; // Pentru interfetele de IDoctorRepository
using CabinetMedical.Data.Repositories; // Pentru implementarea DoctorRepository

namespace CabinetMedical
{
    public partial class DoctorForm : Form
    {
        // ============================================================
        // CAMPO PRIVAT: _repo
        // ============================================================
        // Retine instanta repository-ului concret pentru Doctor
        // Folosim interfata IDoctorRepository pentru a decupla implementarea
        private readonly CoreDoctorRepository _repo;
        public DoctorForm()
        {
            InitializeComponent();
            // =========================================================
            // INITIALIZARE: _repo
            // ===========================================================
            // Cream o  noua instanata a repository-ului
            _repo = new DoctorRepository();
           
        }
    }
}

        // ============================================================
        // Eveniment Load al formularului
        // Se declanseaza cand fereastra e afisata prima data
        // ============================================================
        private void DoctorForm_Load(object sender, EventArgs e)
        {
            // apelam metoda refreshgrid pentru a popula datagridview-ul
            RefreshGrid();
        }
        // ============================================================
        // Metoda auxiliara: RefreshGrid
        // Populeaza DataGridView cu datele din repository
        // ============================================================
        private void RefreshGrid()
        {
            // 1. Preluam toti doctorii din repository (_repo.GetAll())
            // 2. .ToList() transforma IEnumerable<Doctor> intr-un List<Doctor>
            // astfel incat DataGridView-ul sa poata fi populat
            var list = _repo.GetAll().ToList();

            // 3. Setam DataSource-ul DataGridView-ului (dvgDoctors) cu aceasta lista
            dgvDoctors.DataSource = list;

            // 4. Daca vrem sa ascundem anumite coloane (de ex, ID, nu este necesara pentru utilizator)
            // putem face : dgvDoctors.Columns["Prescriptions"].Visible = false;
            // Dar la inceput, lasam toate coloanele vizibile (ID, FirstName, LastName, Specialization)
        }
        // ============================================================
        // Eveniment Click al butonului Add
        // Se declanseaza cand utilizatorul apasa butonul "Add"
        // ============================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. Cream un nou formular-mic (dialog) pentru a completa datele doctorului.
            // Folosim "using" ca sa ne asiguram ca formularul este distrus dupa ce inchidem dialogul, prin apelarea Dispose() la inchidere.
            using (var dlg = new DoctorEditForm())
            {
                // 2. Afisam dialogul in mod modal (blocheaza DoctorForm pana cand utilizatorul apasa OK sau Cancel)
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // 3. Daca utilizatorul a apasat OK, adaugam doctorul in repository
                    _repo.Add(dlg.Doctor);
                    // 4. Apoi, reimprospatam DataGridView-ul pentru a afisa noul doctor
                    RefreshGrid();
                    // 5. Afișăm un mesaj de succes
                    MessageBox.Show("Doctor adaugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // 6. Resetam formularul de editare pentru a putea adauga alti doctori
                    dlg.ResetForm();
                    // 7. Focus pe butonul Add pentru a putea adauga alti doctori rapid
                    btnAdd.Focus();

                }
            }
        }
        // ============================================================
        // Eveniment Click al butonului Edit
        // Se declanseaza cand utilizatorul apasa butonul "Edit"
        // ============================================================
        private void btnEdit_Click(object sender, EventArgs e)
{
    //1. Verificam daca s-a selectat un doctor in DataGridView
    if (dgvDoctors.CurrentRow == null)
    {
        // Daca nu s-a selectat nimic, afisam un mesaj de eroare
        MessageBox.Show("Selectati un doctor pentru a-l edita.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }
    // Iesim din metoda
    // 2. Preluam obiectul Doctor asociat cu linia selectata
    // DataBoundItem contine obiectul din List<Doctor> care a fost pus ca Data Source.
    var selected = dgvDoctors.CurrentRow.DataBoundItem as Doctor;
    if (selected == null)
    {
        // Daca nu s-a putut face conversia, afisam un mesaj de eroare
        MessageBox.Show("Selectati un doctor valid pentru a-l edita.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return; // Iesim din metoda
    }
    // 3. Cream un nou formular-mic (dialog) pentru a edita datele doctorului, trimitand constructorului obiectul existent.
    // in DoctorEditForm, (Doctor Existing) codul cloneaza acest obiect, ca sa nu modificam direct instanta originala pana la confirmare
    using (var dlg = new DoctorEditForm(selected))
    {
        // 4. Afisam dialogul si asteptam rezultatul :
        if (dlg.ShowDialog() == DialogResult.OK)
        { // 5. Daca utilizatorul a apasat OK, actualizam doctorul in repository
            _repo.Update(dlg.Doctor);
            // 6. Reimprospatam DataGridView-ul pentru a afisa modificarile
            RefreshGrid();
            // 7. Afișăm un mesaj de succes
            MessageBox.Show("Doctor actualizat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // 8. Resetam formularul de editare pentru a putea edita alti doctori
            dlg.ResetForm();
            // 9. Focus pe butonul Edit pentru a putea edita alti doctori rapid
            btnEdit.Focus();
        }
    }
}
        // 10. Daca utilizatorul a apasat Cancel, nu se intampla nimic.

        // ============================================================
        // Eveniment Click al butonului "Delete"
        // =============================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Verificam daca exista un rand selectat in DataGridView: 
            if (dgvDoctors.CurrentRow == null)
            {
                // Daca nu s-a selectat nimic, afisam un mesaj de eroare
                MessageBox.Show("Selectati un doctor pentru a-l sterge.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                // Iesim din metoda

                // 2. Preluam obiectul Doctor asociat cu linia selectata
                var selected = dgvDoctors.CurrentRow.DataBoundItem as Doctor;
                if (selected == null)
    {
        return; // Daca nu s-a putut face conversia, iesim din metoda
    }
    // daca legarea nu a mers, nu stergem
    // ============================================================
    // 2. Verificam daca doctorul are prescriptii asociate
    if (selected.Prescriptions != null && selected.Prescriptions.Any())
    {
        // Daca are, afisam un mesaj de eroare
        MessageBox.Show("Nu puteti sterge un doctor care are prescriptii asociate.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return; // Iesim din metoda
    }
    else
    {
        // 3. Daca nu are prescriptii, continuam cu stergerea:

        // 3. Confirmam stergerea cu un MessageBox: MessageBox cu butoane Yes/No si iconita Warning.
        var confirm = MessageBox.Show(
                    $"Sunteti sigur ca doriti sa stergeti doctorul {selected.FirstName} {selected.LastName}?",
                    "Confirmare Stergere",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // 4. Daca utilizatorul a apasat Yes, stergem doctorul din repository
                if (confirm == DialogResult.Yes)
                {
                    // 5. Apeleaza _repo.Delete(ID) pentru a elimina doctorul cu ID-ul dat
                    _repo.Delete(selected.ID);

                    // 6. Reimprospatam DataGridView-ul pentru a afisa modificarile
                    RefreshGrid();
                    // 7. Afișăm un mesaj de succes
                    MessageBox.Show("Doctor sters cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // 8. Daca utilizatorul a apasat No, nu se intampla nimic.

            }
        }
    }
