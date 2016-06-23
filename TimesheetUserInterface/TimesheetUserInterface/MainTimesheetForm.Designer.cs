﻿namespace TimesheetUserInterface
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
            BaseForm.ColorPalette colorPalette1 = new BaseForm.ColorPalette();
            this.tsButton1 = new BaseForm.TSButton();
            this.tsListBox1 = new BaseForm.TSListBox();
            this.tsButton2 = new BaseForm.TSButton();
            this.gListFunctions = new BaseForm.GListBox();
            this.gListActivities = new BaseForm.GListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tsCalendar2 = new BaseForm.TSCalendar();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gListProjects = new BaseForm.GListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gListRole = new BaseForm.GListBox();
            this.gListAdditional = new BaseForm.GListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tsButton3 = new BaseForm.TSButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gListDomains = new BaseForm.GListBox();
            this.tsButton4 = new BaseForm.TSButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsButton1
            // 
            this.tsButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton1.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.tsButton1.BorderSwatch = BaseForm.Swatch.Shade2;
            this.tsButton1.ClickSwatch = BaseForm.Swatch.Tint1;
            this.tsButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton1.ForeColor = System.Drawing.Color.White;
            this.tsButton1.HoverSwatch = BaseForm.Swatch.Primary;
            this.tsButton1.Location = new System.Drawing.Point(994, 315);
            this.tsButton1.Name = "tsButton1";
            this.tsButton1.Size = new System.Drawing.Size(154, 30);
            this.tsButton1.TabIndex = 1;
            this.tsButton1.Text = "Delete Entry";
            this.tsButton1.Click += new System.EventHandler(this.tsButton1_Click);
            // 
            // tsListBox1
            // 
            this.tsListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsListBox1.BackColor = System.Drawing.Color.White;
            this.tsListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tsListBox1.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.tsListBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsListBox1.IntegralHeight = false;
            this.tsListBox1.ItemHeight = 17;
            this.tsListBox1.Location = new System.Drawing.Point(12, 351);
            this.tsListBox1.Name = "tsListBox1";
            this.tsListBox1.Size = new System.Drawing.Size(1136, 334);
            this.tsListBox1.Sorted = true;
            this.tsListBox1.TabIndex = 2;
            this.tsListBox1.SelectedIndexChanged += new System.EventHandler(this.tsListBox1_SelectedIndexChanged);
            // 
            // tsButton2
            // 
            this.tsButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton2.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.tsButton2.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsButton2.ClickSwatch = BaseForm.Swatch.Tint1;
            this.tsButton2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton2.ForeColor = System.Drawing.Color.White;
            this.tsButton2.HoverSwatch = BaseForm.Swatch.Primary;
            this.tsButton2.Location = new System.Drawing.Point(552, 200);
            this.tsButton2.Name = "tsButton2";
            this.tsButton2.Size = new System.Drawing.Size(85, 23);
            this.tsButton2.TabIndex = 5;
            this.tsButton2.Text = "Add Project";
            this.tsButton2.Click += new System.EventHandler(this.tsButton2_Click);
            // 
            // gListFunctions
            // 
            this.gListFunctions.BackColor = System.Drawing.Color.White;
            this.gListFunctions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListFunctions.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListFunctions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.gListFunctions.FormattingEnabled = true;
            this.gListFunctions.ItemHeight = 16;
            this.gListFunctions.Location = new System.Drawing.Point(258, 169);
            this.gListFunctions.Name = "gListFunctions";
            this.gListFunctions.Size = new System.Drawing.Size(199, 176);
            this.gListFunctions.TabIndex = 7;
            this.gListFunctions.SelectedIndexChanged += new System.EventHandler(this.gListFunctions_SelectedIndexChanged);
            // 
            // gListActivities
            // 
            this.gListActivities.BackColor = System.Drawing.Color.White;
            this.gListActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListActivities.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListActivities.FormattingEnabled = true;
            this.gListActivities.ItemHeight = 16;
            this.gListActivities.Location = new System.Drawing.Point(643, 57);
            this.gListActivities.Name = "gListActivities";
            this.gListActivities.Size = new System.Drawing.Size(174, 288);
            this.gListActivities.TabIndex = 8;
            this.gListActivities.SelectedIndexChanged += new System.EventHandler(this.gListActivities_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(258, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Domain:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label3.Location = new System.Drawing.Point(643, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Activity:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tsCalendar2
            // 
            this.tsCalendar2.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsCalendar2.CurrentDate = new System.DateTime(2016, 6, 14, 0, 0, 0, 0);
            this.tsCalendar2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCalendar2.Location = new System.Drawing.Point(12, 73);
            this.tsCalendar2.Name = "tsCalendar2";
            this.tsCalendar2.Size = new System.Drawing.Size(224, 157);
            this.tsCalendar2.TabIndex = 9;
            this.tsCalendar2.Text = "tsCalendar2";
            this.tsCalendar2.Click += new System.EventHandler(this.tsCalendar2_Click);
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
            this.gListProjects.Location = new System.Drawing.Point(463, 57);
            this.gListProjects.Name = "gListProjects";
            this.gListProjects.Size = new System.Drawing.Size(174, 144);
            this.gListProjects.Sorted = true;
            this.gListProjects.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label5.Location = new System.Drawing.Point(463, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Project:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gListRole
            // 
            this.gListRole.BackColor = System.Drawing.Color.White;
            this.gListRole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListRole.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListRole.FormattingEnabled = true;
            this.gListRole.ItemHeight = 16;
            this.gListRole.Location = new System.Drawing.Point(463, 249);
            this.gListRole.Name = "gListRole";
            this.gListRole.Size = new System.Drawing.Size(174, 96);
            this.gListRole.TabIndex = 12;
            // 
            // gListAdditional
            // 
            this.gListAdditional.BackColor = System.Drawing.Color.White;
            this.gListAdditional.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListAdditional.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListAdditional.FormattingEnabled = true;
            this.gListAdditional.ItemHeight = 16;
            this.gListAdditional.Location = new System.Drawing.Point(823, 57);
            this.gListAdditional.Name = "gListAdditional";
            this.gListAdditional.Size = new System.Drawing.Size(165, 288);
            this.gListAdditional.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(463, 200);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 23);
            this.textBox1.TabIndex = 14;
            // 
            // tsButton3
            // 
            this.tsButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton3.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.tsButton3.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsButton3.ClickSwatch = BaseForm.Swatch.Tint1;
            this.tsButton3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton3.ForeColor = System.Drawing.Color.White;
            this.tsButton3.HoverSwatch = BaseForm.Swatch.Primary;
            this.tsButton3.Location = new System.Drawing.Point(994, 172);
            this.tsButton3.Name = "tsButton3";
            this.tsButton3.Size = new System.Drawing.Size(154, 30);
            this.tsButton3.TabIndex = 15;
            this.tsButton3.Text = "Add Entry";
            this.tsButton3.Click += new System.EventHandler(this.tsButton3_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(463, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Role:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label6.Location = new System.Drawing.Point(258, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Specify:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtComments
            // 
            this.txtComments.BackColor = System.Drawing.Color.White;
            this.txtComments.Location = new System.Drawing.Point(994, 57);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(154, 109);
            this.txtComments.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label7.Location = new System.Drawing.Point(991, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Comments";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label8.Location = new System.Drawing.Point(823, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Specify:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.gListDomains.Location = new System.Drawing.Point(258, 57);
            this.gListDomains.Name = "gListDomains";
            colorPalette1.Palette = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(42)))), ((int)(((byte)(103))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(204))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(193)))), ((int)(((byte)(230))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))))};
            colorPalette1.Primary = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(204)))));
            colorPalette1.Shade1 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            colorPalette1.Shade2 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(42)))), ((int)(((byte)(103)))));
            colorPalette1.Tint1 = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(193)))), ((int)(((byte)(230)))));
            colorPalette1.Tint2 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))));
            this.gListDomains.Palette = colorPalette1;
            this.gListDomains.Size = new System.Drawing.Size(199, 96);
            this.gListDomains.TabIndex = 4;
            this.gListDomains.SelectedIndexChanged += new System.EventHandler(this.gListBox1_SelectedIndexChanged);
            // 
            // tsButton4
            // 
            this.tsButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton4.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.tsButton4.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsButton4.ClickSwatch = BaseForm.Swatch.Tint1;
            this.tsButton4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton4.ForeColor = System.Drawing.Color.White;
            this.tsButton4.HoverSwatch = BaseForm.Swatch.Primary;
            this.tsButton4.Location = new System.Drawing.Point(994, 208);
            this.tsButton4.Name = "tsButton4";
            this.tsButton4.Size = new System.Drawing.Size(154, 30);
            this.tsButton4.TabIndex = 18;
            this.tsButton4.Text = "Update Entry";
            this.tsButton4.Click += new System.EventHandler(this.tsButton4_Click);
            // 
            // MainTimesheetForm
            // 
            this.AccentColor = System.Drawing.Color.DodgerBlue;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderWidth = 2;
            this.ClientSize = new System.Drawing.Size(1160, 697);
            this.Controls.Add(this.tsButton4);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsButton3);
            this.Controls.Add(this.gListProjects);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gListAdditional);
            this.Controls.Add(this.gListRole);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.tsCalendar2);
            this.Controls.Add(this.gListActivities);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tsButton2);
            this.Controls.Add(this.gListDomains);
            this.Controls.Add(this.tsListBox1);
            this.Controls.Add(this.tsButton1);
            this.Controls.Add(this.gListFunctions);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(89)))), ((int)(((byte)(158)))));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainTimesheetForm";
            this.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.Text = "G5 Engineering Timesheets";
            this.Load += new System.EventHandler(this.MainTimesheetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseForm.TSButton tsButton1;
        private BaseForm.TSListBox tsListBox1;
        private BaseForm.TSButton tsButton2;
        private BaseForm.GListBox gListFunctions;
        private BaseForm.GListBox gListActivities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private BaseForm.TSCalendar tsCalendar2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private BaseForm.GListBox gListProjects;
        private System.Windows.Forms.Label label5;
        private BaseForm.GListBox gListRole;
        private BaseForm.GListBox gListAdditional;
        private System.Windows.Forms.TextBox textBox1;
        private BaseForm.TSButton tsButton3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private BaseForm.GListBox gListDomains;
        private BaseForm.TSButton tsButton4;

    }
}