namespace CabinetMedical
{
    partial class PrescriptionEditForm
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
            lblDoctor = new Label();
            cmbDoctor = new ComboBox();
            lblPatient = new Label();
            cmbPatient = new ComboBox();
            lblDateIssued = new Label();
            dtpDateIssued = new DateTimePicker();
            lblDosage = new Label();
            txtDosage = new TextBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            lblMedication = new Label();
            txtMedication = new TextBox();
            SuspendLayout();
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(20, 20);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(46, 15);
            lblDoctor.TabIndex = 0;
            lblDoctor.Text = "Doctor:";
            // 
            // cmbDoctor
            // 
            cmbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoctor.FormattingEnabled = true;
            cmbDoctor.Location = new Point(72, 20);
            cmbDoctor.Name = "cmbDoctor";
            cmbDoctor.Size = new Size(200, 23);
            cmbDoctor.TabIndex = 1;
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Location = new Point(292, 20);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new Size(47, 15);
            lblPatient.TabIndex = 2;
            lblPatient.Text = "Patient:";
            // 
            // cmbPatient
            // 
            cmbPatient.FormattingEnabled = true;
            cmbPatient.Location = new Point(345, 17);
            cmbPatient.Name = "cmbPatient";
            cmbPatient.Size = new Size(200, 23);
            cmbPatient.TabIndex = 3;
            // 
            // lblDateIssued
            // 
            lblDateIssued.AutoSize = true;
            lblDateIssued.Location = new Point(20, 76);
            lblDateIssued.Name = "lblDateIssued";
            lblDateIssued.Size = new Size(70, 15);
            lblDateIssued.TabIndex = 4;
            lblDateIssued.Text = "Date Issued:";
            // 
            // dtpDateIssued
            // 
            dtpDateIssued.Format = DateTimePickerFormat.Short;
            dtpDateIssued.Location = new Point(96, 76);
            dtpDateIssued.Name = "dtpDateIssued";
            dtpDateIssued.Size = new Size(176, 23);
            dtpDateIssued.TabIndex = 5;
            // 
            // lblDosage
            // 
            lblDosage.AutoSize = true;
            lblDosage.Location = new Point(20, 124);
            lblDosage.Name = "lblDosage";
            lblDosage.Size = new Size(49, 15);
            lblDosage.TabIndex = 6;
            lblDosage.Text = "Dosage:";
            // 
            // txtDosage
            // 
            txtDosage.Location = new Point(75, 124);
            txtDosage.Name = "txtDosage";
            txtDosage.Size = new Size(100, 23);
            txtDosage.TabIndex = 7;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(20, 179);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(41, 15);
            lblNotes.TabIndex = 8;
            lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(72, 179);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(200, 60);
            txtNotes.TabIndex = 9;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(20, 301);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 10;
            btnOK.Text = "Confirm";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(101, 301);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblMedication
            // 
            lblMedication.AutoSize = true;
            lblMedication.Location = new Point(292, 124);
            lblMedication.Name = "lblMedication";
            lblMedication.Size = new Size(70, 15);
            lblMedication.TabIndex = 12;
            lblMedication.Text = "Medication:";
            // 
            // txtMedication
            // 
            txtMedication.Location = new Point(368, 121);
            txtMedication.Name = "txtMedication";
            txtMedication.Size = new Size(100, 23);
            txtMedication.TabIndex = 13;
            txtMedication.TextChanged += textBox1_TextChanged;
            // 
            // PrescriptionEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 382);
            Controls.Add(txtMedication);
            Controls.Add(lblMedication);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(txtDosage);
            Controls.Add(lblDosage);
            Controls.Add(dtpDateIssued);
            Controls.Add(lblDateIssued);
            Controls.Add(cmbPatient);
            Controls.Add(lblPatient);
            Controls.Add(cmbDoctor);
            Controls.Add(lblDoctor);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PrescriptionEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Prescription Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDoctor;
        private ComboBox cmbDoctor;
        private Label lblPatient;
        private ComboBox cmbPatient;
        private Label lblDateIssued;
        private DateTimePicker dtpDateIssued;
        private Label lblDosage;
        private TextBox txtDosage;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnOK;
        private Button btnCancel;
        private Label lblMedication;
        private TextBox txtMedication;
    }
}