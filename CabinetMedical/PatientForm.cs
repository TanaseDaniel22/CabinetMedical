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
using CabinetMedical.Data.Repositories; // import repository-urile

namespace CabinetMedical
{
    public partial class PatientForm : Form
    {
        // 1. Camp privat: repository pentru pacienti
        private readonly PatientRepository _repo;

        public PatientForm()
        {
            InitializeComponent();
            // 2. Initializam repository-ul
            _repo = new PatientRepository();
        }

        // 3. Evenimentul Load al formularului
        private void PatientForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        // 4. Metoda de reimprospatare a gridului
        private void RefreshGrid()
        {
            var list = _repo.GetAll().ToList();
            dgvPatients.DataSource = list;
        }

        // 5. Handler pentru butonul Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new PatientEditForm())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Adaugam pacientul nou
                    _repo.Add(dlg.Patient);
                    RefreshGrid();
                    MessageBox.Show(
                        "Pacient adaugat!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    // Resetam formularul in cazul in care vrem sa-l refolosim
                    dlg.ResetForm();
                    btnAdd.Focus();
                }
            }
        }

        // 6. Handler pentru butonul Edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selectati un pacient pentru editare.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Preluam pacientul selectat din grid
            var selected = dgvPatients.CurrentRow.DataBoundItem as Patient;
            if (selected == null) return;

            using (var dlg = new PatientEditForm(selected))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _repo.Update(dlg.Patient);
                    RefreshGrid();
                    MessageBox.Show(
                        "Pacient actualizat!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    btnEdit.Focus();
                }
            }
        }

        // 7. Handler pentru butonul Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selectati un pacient pentru stergere.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            var selected = dgvPatients.CurrentRow.DataBoundItem as Patient;
            if (selected == null) return;

            var confirm = MessageBox.Show(
                "Sunteti sigur ca doriti sa stergeti acest pacient?" + selected.LastName + "?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                _repo.Delete(selected.ID);
                RefreshGrid();
                MessageBox.Show(
                    "Pacient sters cu succes",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}