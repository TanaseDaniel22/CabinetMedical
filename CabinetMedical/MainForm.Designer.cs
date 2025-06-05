namespace CabinetMedical
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            doctorsToolStripMenuItem = new ToolStripMenuItem();
            patientsToolStripMenuItem = new ToolStripMenuItem();
            prescriptionsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { doctorsToolStripMenuItem, patientsToolStripMenuItem, prescriptionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // doctorsToolStripMenuItem
            // 
            doctorsToolStripMenuItem.Name = "doctorsToolStripMenuItem";
            doctorsToolStripMenuItem.Size = new Size(60, 20);
            doctorsToolStripMenuItem.Text = "Doctors";
            doctorsToolStripMenuItem.Click += this.doctorsToolStripMenuItem_Click;
            // 
            // patientsToolStripMenuItem
            // 
            patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            patientsToolStripMenuItem.Size = new Size(61, 20);
            patientsToolStripMenuItem.Text = "Patients";
            patientsToolStripMenuItem.Click += this.patientsToolStripMenuItem_Click;
            // 
            // prescriptionsToolStripMenuItem
            // 
            prescriptionsToolStripMenuItem.Name = "prescriptionsToolStripMenuItem";
            prescriptionsToolStripMenuItem.Size = new Size(87, 20);
            prescriptionsToolStripMenuItem.Text = "Prescriptions";
            prescriptionsToolStripMenuItem.Click += this.prescriptionsToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Cabinet Medical - Tanase Daniel-Mihai";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem doctorsToolStripMenuItem;
        private ToolStripMenuItem patientsToolStripMenuItem;
        private ToolStripMenuItem prescriptionsToolStripMenuItem;
    }
}