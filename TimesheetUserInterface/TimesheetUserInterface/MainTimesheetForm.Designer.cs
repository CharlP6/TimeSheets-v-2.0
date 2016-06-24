namespace TimesheetUserInterface
{
    partial class MainTimesheetForm
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
            BaseForm.ColorPalette colorPalette4 = new BaseForm.ColorPalette();
            this.btnDelete = new BaseForm.TSButton();
            this.lstTimeSheets = new BaseForm.TSListBox();
            this.btnAddProject = new BaseForm.TSButton();
            this.gListFunctions = new BaseForm.GListBox();
            this.gListActivities = new BaseForm.GListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tsCalendar = new BaseForm.TSCalendar();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gListProjects = new BaseForm.GListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gListRole = new BaseForm.GListBox();
            this.gListAdditional = new BaseForm.GListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAddEntry = new BaseForm.TSButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gListDomains = new BaseForm.GListBox();
            this.btnUpdate = new BaseForm.TSButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.btnDelete.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.btnDelete.BorderSwatch = BaseForm.Swatch.Shade2;
            this.btnDelete.ClickSwatch = BaseForm.Swatch.Tint1;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.HoverSwatch = BaseForm.Swatch.Primary;
            this.btnDelete.Location = new System.Drawing.Point(1192, 315);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(154, 30);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete Entry";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstTimeSheets
            // 
            this.lstTimeSheets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTimeSheets.BackColor = System.Drawing.Color.White;
            this.lstTimeSheets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTimeSheets.BorderSwatch = BaseForm.Swatch.Shade1;
            this.lstTimeSheets.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstTimeSheets.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTimeSheets.IntegralHeight = false;
            this.lstTimeSheets.ItemHeight = 17;
            this.lstTimeSheets.Location = new System.Drawing.Point(15, 351);
            this.lstTimeSheets.Name = "lstTimeSheets";
            this.lstTimeSheets.Size = new System.Drawing.Size(1331, 334);
            this.lstTimeSheets.Sorted = true;
            this.lstTimeSheets.TabIndex = 2;
            // 
            // btnAddProject
            // 
            this.btnAddProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.btnAddProject.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.btnAddProject.BorderSwatch = BaseForm.Swatch.Shade1;
            this.btnAddProject.ClickSwatch = BaseForm.Swatch.Tint1;
            this.btnAddProject.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProject.ForeColor = System.Drawing.Color.White;
            this.btnAddProject.HoverSwatch = BaseForm.Swatch.Primary;
            this.btnAddProject.Location = new System.Drawing.Point(561, 315);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(85, 30);
            this.btnAddProject.TabIndex = 5;
            this.btnAddProject.Text = "Add Project";
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // gListFunctions
            // 
            this.gListFunctions.BackColor = System.Drawing.Color.White;
            this.gListFunctions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListFunctions.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListFunctions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.gListFunctions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListFunctions.FormattingEnabled = true;
            this.gListFunctions.ItemHeight = 16;
            this.gListFunctions.Location = new System.Drawing.Point(249, 169);
            this.gListFunctions.Name = "gListFunctions";
            this.gListFunctions.Size = new System.Drawing.Size(165, 176);
            this.gListFunctions.TabIndex = 7;
            this.gListFunctions.SelectedIndexChanged += new System.EventHandler(this.gListFunctions_SelectedIndexChanged);
            // 
            // gListActivities
            // 
            this.gListActivities.BackColor = System.Drawing.Color.White;
            this.gListActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListActivities.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListActivities.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListActivities.FormattingEnabled = true;
            this.gListActivities.ItemHeight = 16;
            this.gListActivities.Location = new System.Drawing.Point(780, 57);
            this.gListActivities.Name = "gListActivities";
            this.gListActivities.Size = new System.Drawing.Size(174, 288);
            this.gListActivities.TabIndex = 8;
            this.gListActivities.SelectedIndexChanged += new System.EventHandler(this.gListActivities_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(249, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Domain:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label3.Location = new System.Drawing.Point(780, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Activity:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsCalendar
            // 
            this.tsCalendar.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsCalendar.CurrentDate = new System.DateTime(2016, 6, 14, 0, 0, 0, 0);
            this.tsCalendar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCalendar.Location = new System.Drawing.Point(12, 73);
            this.tsCalendar.Name = "tsCalendar";
            this.tsCalendar.Size = new System.Drawing.Size(224, 157);
            this.tsCalendar.TabIndex = 9;
            this.tsCalendar.Text = "tsCalendar";
            this.tsCalendar.Click += new System.EventHandler(this.tsCalendar_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.White;
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(116, 44);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label4.Location = new System.Drawing.Point(12, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date and Hours:";
            // 
            // gListProjects
            // 
            this.gListProjects.BackColor = System.Drawing.Color.White;
            this.gListProjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListProjects.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListProjects.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListProjects.FormattingEnabled = true;
            this.gListProjects.ItemHeight = 16;
            this.gListProjects.Location = new System.Drawing.Point(420, 57);
            this.gListProjects.Name = "gListProjects";
            this.gListProjects.Size = new System.Drawing.Size(226, 256);
            this.gListProjects.Sorted = true;
            this.gListProjects.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label5.Location = new System.Drawing.Point(420, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Project:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gListRole
            // 
            this.gListRole.BackColor = System.Drawing.Color.White;
            this.gListRole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListRole.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListRole.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListRole.FormattingEnabled = true;
            this.gListRole.ItemHeight = 16;
            this.gListRole.Location = new System.Drawing.Point(652, 57);
            this.gListRole.Name = "gListRole";
            this.gListRole.Size = new System.Drawing.Size(122, 96);
            this.gListRole.TabIndex = 12;
            // 
            // gListAdditional
            // 
            this.gListAdditional.BackColor = System.Drawing.Color.White;
            this.gListAdditional.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListAdditional.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListAdditional.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListAdditional.FormattingEnabled = true;
            this.gListAdditional.ItemHeight = 16;
            this.gListAdditional.Location = new System.Drawing.Point(960, 57);
            this.gListAdditional.Name = "gListAdditional";
            this.gListAdditional.Size = new System.Drawing.Size(145, 288);
            this.gListAdditional.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(420, 322);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 23);
            this.textBox1.TabIndex = 14;
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.btnAddEntry.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.btnAddEntry.BorderSwatch = BaseForm.Swatch.Shade1;
            this.btnAddEntry.ClickSwatch = BaseForm.Swatch.Tint1;
            this.btnAddEntry.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEntry.ForeColor = System.Drawing.Color.White;
            this.btnAddEntry.HoverSwatch = BaseForm.Swatch.Primary;
            this.btnAddEntry.Location = new System.Drawing.Point(1192, 172);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(154, 30);
            this.btnAddEntry.TabIndex = 15;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(652, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Role:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label6.Location = new System.Drawing.Point(249, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Specify:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComments
            // 
            this.txtComments.BackColor = System.Drawing.Color.White;
            this.txtComments.Location = new System.Drawing.Point(1111, 57);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(235, 109);
            this.txtComments.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label7.Location = new System.Drawing.Point(1111, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Comments:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label8.Location = new System.Drawing.Point(960, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Specify:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gListDomains
            // 
            this.gListDomains.BackColor = System.Drawing.Color.White;
            this.gListDomains.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListDomains.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListDomains.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.gListDomains.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListDomains.FormattingEnabled = true;
            this.gListDomains.ItemHeight = 16;
            this.gListDomains.Location = new System.Drawing.Point(249, 57);
            this.gListDomains.Name = "gListDomains";
            colorPalette4.Palette = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(42)))), ((int)(((byte)(103))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(204))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(193)))), ((int)(((byte)(230))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))))};
            colorPalette4.Primary = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(204)))));
            colorPalette4.Shade1 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            colorPalette4.Shade2 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(42)))), ((int)(((byte)(103)))));
            colorPalette4.Tint1 = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(193)))), ((int)(((byte)(230)))));
            colorPalette4.Tint2 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))));
            this.gListDomains.Palette = colorPalette4;
            this.gListDomains.Size = new System.Drawing.Size(165, 96);
            this.gListDomains.TabIndex = 4;
            this.gListDomains.SelectedIndexChanged += new System.EventHandler(this.gListDomains_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.btnUpdate.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.btnUpdate.BorderSwatch = BaseForm.Swatch.Shade1;
            this.btnUpdate.ClickSwatch = BaseForm.Swatch.Tint1;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.HoverSwatch = BaseForm.Swatch.Primary;
            this.btnUpdate.Location = new System.Drawing.Point(1192, 208);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(154, 30);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update Entry";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // MainTimesheetForm
            // 
            this.AccentColor = System.Drawing.Color.DodgerBlue;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderWidth = 2;
            this.ClientSize = new System.Drawing.Size(1358, 697);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.gListProjects);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gListAdditional);
            this.Controls.Add(this.gListRole);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.tsCalendar);
            this.Controls.Add(this.gListActivities);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.gListDomains);
            this.Controls.Add(this.lstTimeSheets);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gListFunctions);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(89)))), ((int)(((byte)(158)))));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainTimesheetForm";
            this.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.Text = "G5 Engineering Timesheets";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseForm.TSButton btnDelete;
        private BaseForm.TSListBox lstTimeSheets;
        private BaseForm.TSButton btnAddProject;
        private BaseForm.GListBox gListFunctions;
        private BaseForm.GListBox gListActivities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private BaseForm.TSCalendar tsCalendar;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private BaseForm.GListBox gListProjects;
        private System.Windows.Forms.Label label5;
        private BaseForm.GListBox gListRole;
        private BaseForm.GListBox gListAdditional;
        private System.Windows.Forms.TextBox textBox1;
        private BaseForm.TSButton btnAddEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private BaseForm.GListBox gListDomains;
        private BaseForm.TSButton btnUpdate;

    }
}