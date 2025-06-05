namespace CabinetMedical
{
    partial class PrescriptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvPrescriptions = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            DoctorName = new DataGridViewTextBoxColumn();
            PatientName = new DataGridViewTextBoxColumn();
            DateIssued = new DataGridViewTextBoxColumn();
            Medication = new DataGridViewTextBoxColumn();
            Dosage = new DataGridViewTextBoxColumn();
            Notes = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvPrescriptions).BeginInit();
            SuspendLayout();
            // 
            // dgvPrescriptions
            // 
            dgvPrescriptions.AllowUserToOrderColumns = true;
            dgvPrescriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrescriptions.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgvPrescriptions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPrescriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrescriptions.Columns.AddRange(new DataGridViewColumn[] { DoctorName, PatientName, DateIssued, Medication, Dosage, Notes });
            dgvPrescriptions.Dock = DockStyle.Top;
            dgvPrescriptions.Location = new Point(0, 0);
            dgvPrescriptions.MultiSelect = false;
            dgvPrescriptions.Name = "dgvPrescriptions";
            dgvPrescriptions.ReadOnly = true;
            dgvPrescriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrescriptions.Size = new Size(800, 232);
            dgvPrescriptions.TabIndex = 0;
            //dgvPrescriptions.CellContentClick += this.dataGridView1_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(20, 320);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += this.btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(101, 320);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += this.btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(182, 320);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += this.btnDelete_Click;
            // 
            // DoctorName
            // 
            DoctorName.HeaderText = "Doctor Name";
            DoctorName.Name = "DoctorName";
            DoctorName.ReadOnly = true;
            // 
            // PatientName
            // 
            PatientName.HeaderText = "Patient Name";
            PatientName.Name = "PatientName";
            PatientName.ReadOnly = true;
            // 
            // DateIssued
            // 
            DateIssued.HeaderText = "Date Issued";
            DateIssued.Name = "DateIssued";
            DateIssued.ReadOnly = true;
            // 
            // Medication
            // 
            Medication.HeaderText = "Medication";
            Medication.Name = "Medication";
            Medication.ReadOnly = true;
            // 
            // Dosage
            // 
            Dosage.HeaderText = "Dosage";
            Dosage.Name = "Dosage";
            Dosage.ReadOnly = true;
            // 
            // Notes
            // 
            Notes.HeaderText = "Notes";
            Notes.Name = "Notes";
            Notes.ReadOnly = true;
            // 
            // PrescriptionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvPrescriptions);
            Name = "PrescriptionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Prescriptions";
            ((System.ComponentModel.ISupportInitialize)dgvPrescriptions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPrescriptions;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridViewTextBoxColumn DoctorName;
        private DataGridViewTextBoxColumn PatientName;
        private DataGridViewTextBoxColumn DateIssued;
        private DataGridViewTextBoxColumn Medication;
        private DataGridViewTextBoxColumn Dosage;
        private DataGridViewTextBoxColumn Notes;
    }
}