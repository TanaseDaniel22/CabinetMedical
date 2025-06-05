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
    public partial class PrescriptionForm : Form
    {
        // 1. Camp privat: repository pentru retete
        private readonly PrescriptionRepository _repo;

        public PrescriptionForm()
        {
            InitializeComponent();
            // 2. Initializam repository-ul
            _repo = new PrescriptionRepository();
            
            dgvPrescriptions.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        }

        // 3. Eveniment Load al formularului
        private void PrescriptionForm_Load(object sender, EventArgs e)
        {
            // Populam initial gridul cu datele existente
            RefreshGrid();
        }

        // 4. Metoda de reimprospatare a gridului
        private void RefreshGrid()
        {
            // Preluam toate prescriptiile din repository
            var list = _repo.GetAll().ToList();

            // Setam DataSource pentru DataGridView
            //dgvPrescriptions.DataSource = list;
        }

        // 5. Handler pentru butonul Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Cream si afisam dialogul de editare pentru o reteta noua
            using (var dlg = new PrescriptionEditForm())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Daca dialogul s-a inchis cu OK, adaugam instanta noua in repository
                    _repo.Add(dlg.Prescription);

                    // Reimprospatam gridul
                    RefreshGrid();

                    // Avertizam utilizatorul
                    MessageBox.Show(
                        "Reteta adaugata cu succes",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Resetam dialogul (optional)
                    dlg.ResetForm();
                    btnAdd.Focus();
                }
            }
        }

        // 6. Handler pentru butonul Edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Daca nu e niciun rand selectat, afisam eroare
            if (dgvPrescriptions.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selectati o reteta pentru editare.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Preluam obiectul Prescription de pe randul selectat
            var selected = dgvPrescriptions.CurrentRow.DataBoundItem as Prescription;
            if (selected == null) return;

            // Deschidem dialogul folosind constructor cu parametru (edit)
            using (var dlg = new PrescriptionEditForm(selected))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Dupa Edit, updatam repository
                    _repo.Update(dlg.Prescription);
                    RefreshGrid();
                    MessageBox.Show(
                        "Reteta actualizata!!",
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
            // Daca nu e niciun rand selectat, afisam eroare
            if (dgvPrescriptions.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selectati o reteta pentru stergere.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Preluam Prescription-ul selectat
            var selected = dgvPrescriptions.CurrentRow.DataBoundItem as Prescription;
            if (selected == null) return;

            // Confirmam stergerea
            var confirm = MessageBox.Show(
                "Sunteti sigur ca doriti sa stergeti reteta aceasta?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                // Stergem din repository si reimprospatam gridul
                _repo.Delete(selected.ID);
                RefreshGrid();
                MessageBox.Show(
                    "Reteta stearsa cu succes!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}