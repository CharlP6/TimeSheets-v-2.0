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
            this.tsButton1 = new TimesheetUserInterface.TSButton();
            this.tsListBox1 = new TimesheetUserInterface.TSListBox();
            this.gListDomains = new TimesheetUserInterface.GListBox();
            this.tsButton2 = new TimesheetUserInterface.TSButton();
            this.gListFunctions = new TimesheetUserInterface.GListBox();
            this.gListActivities = new TimesheetUserInterface.GListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tsCalendar2 = new TimesheetUserInterface.TSCalendar();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gListProjects = new TimesheetUserInterface.GListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gListRole = new TimesheetUserInterface.GListBox();
            this.gListBox3 = new TimesheetUserInterface.GListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tsButton3 = new TimesheetUserInterface.TSButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsButton1
            // 
            this.tsButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton1.BackColorSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.tsButton1.BorderSwatch = TimesheetUserInterface.Swatch.Shade2;
            this.tsButton1.ClickSwatch = TimesheetUserInterface.Swatch.Tint1;
            this.tsButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton1.ForeColor = System.Drawing.Color.White;
            this.tsButton1.HoverSwatch = TimesheetUserInterface.Swatch.Primary;
            this.tsButton1.Location = new System.Drawing.Point(12, 236);
            this.tsButton1.Name = "tsButton1";
            this.tsButton1.Size = new System.Drawing.Size(85, 30);
            this.tsButton1.TabIndex = 1;
            this.tsButton1.Text = "tsButton1";
            this.tsButton1.Click += new System.EventHandler(this.tsButton1_Click);
            // 
            // tsListBox1
            // 
            this.tsListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tsListBox1.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.tsListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.tsListBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsListBox1.IntegralHeight = false;
            this.tsListBox1.ItemHeight = 17;
            this.tsListBox1.Location = new System.Drawing.Point(12, 360);
            this.tsListBox1.Name = "tsListBox1";
            this.tsListBox1.Size = new System.Drawing.Size(1136, 280);
            this.tsListBox1.TabIndex = 2;
            // 
            // gListDomains
            // 
            this.gListDomains.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListDomains.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.gListDomains.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.gListDomains.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListDomains.FormattingEnabled = true;
            this.gListDomains.ItemHeight = 16;
            this.gListDomains.Location = new System.Drawing.Point(450, 57);
            this.gListDomains.Name = "gListDomains";
            this.gListDomains.Size = new System.Drawing.Size(199, 96);
            this.gListDomains.TabIndex = 4;
            this.gListDomains.SelectedIndexChanged += new System.EventHandler(this.gListBox1_SelectedIndexChanged);
            // 
            // tsButton2
            // 
            this.tsButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton2.BackColorSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.tsButton2.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.tsButton2.ClickSwatch = TimesheetUserInterface.Swatch.Tint1;
            this.tsButton2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton2.ForeColor = System.Drawing.Color.White;
            this.tsButton2.HoverSwatch = TimesheetUserInterface.Swatch.Primary;
            this.tsButton2.Location = new System.Drawing.Point(12, 315);
            this.tsButton2.Name = "tsButton2";
            this.tsButton2.Size = new System.Drawing.Size(85, 30);
            this.tsButton2.TabIndex = 5;
            this.tsButton2.Text = "tsButton2";
            this.tsButton2.Click += new System.EventHandler(this.tsButton2_Click);
            // 
            // gListFunctions
            // 
            this.gListFunctions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListFunctions.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.gListFunctions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.gListFunctions.FormattingEnabled = true;
            this.gListFunctions.ItemHeight = 16;
            this.gListFunctions.Location = new System.Drawing.Point(450, 153);
            this.gListFunctions.Name = "gListFunctions";
            this.gListFunctions.Size = new System.Drawing.Size(199, 192);
            this.gListFunctions.TabIndex = 7;
            this.gListFunctions.SelectedIndexChanged += new System.EventHandler(this.gListFunctions_SelectedIndexChanged);
            // 
            // gListActivities
            // 
            this.gListActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListActivities.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.gListActivities.FormattingEnabled = true;
            this.gListActivities.ItemHeight = 16;
            this.gListActivities.Location = new System.Drawing.Point(649, 57);
            this.gListActivities.Name = "gListActivities";
            this.gListActivities.Size = new System.Drawing.Size(174, 288);
            this.gListActivities.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(489, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Domain and Function:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(709, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Activity:";
            // 
            // tsCalendar2
            // 
            this.tsCalendar2.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.tsCalendar2.CurrentDate = new System.DateTime(2016, 6, 14, 0, 0, 0, 0);
            this.tsCalendar2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCalendar2.Location = new System.Drawing.Point(12, 73);
            this.tsCalendar2.Name = "tsCalendar2";
            this.tsCalendar2.Size = new System.Drawing.Size(224, 157);
            this.tsCalendar2.TabIndex = 9;
            this.tsCalendar2.Text = "tsCalendar2";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(116, 41);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
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
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Time:";
            // 
            // gListProjects
            // 
            this.gListProjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListProjects.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.gListProjects.FormattingEnabled = true;
            this.gListProjects.ItemHeight = 16;
            this.gListProjects.Location = new System.Drawing.Point(258, 89);
            this.gListProjects.Name = "gListProjects";
            this.gListProjects.Size = new System.Drawing.Size(174, 160);
            this.gListProjects.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(297, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Project and Role:";
            // 
            // gListRole
            // 
            this.gListRole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListRole.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.gListRole.FormattingEnabled = true;
            this.gListRole.ItemHeight = 16;
            this.gListRole.Location = new System.Drawing.Point(258, 249);
            this.gListRole.Name = "gListRole";
            this.gListRole.Size = new System.Drawing.Size(174, 96);
            this.gListRole.TabIndex = 12;
            // 
            // gListBox3
            // 
            this.gListBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListBox3.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.gListBox3.FormattingEnabled = true;
            this.gListBox3.ItemHeight = 16;
            this.gListBox3.Location = new System.Drawing.Point(829, 57);
            this.gListBox3.Name = "gListBox3";
            this.gListBox3.Size = new System.Drawing.Size(140, 160);
            this.gListBox3.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(258, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 23);
            this.textBox1.TabIndex = 14;
            // 
            // tsButton3
            // 
            this.tsButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton3.BackColorSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.tsButton3.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.tsButton3.ClickSwatch = TimesheetUserInterface.Swatch.Tint1;
            this.tsButton3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton3.ForeColor = System.Drawing.Color.White;
            this.tsButton3.HoverSwatch = TimesheetUserInterface.Swatch.Primary;
            this.tsButton3.Location = new System.Drawing.Point(151, 236);
            this.tsButton3.Name = "tsButton3";
            this.tsButton3.Size = new System.Drawing.Size(85, 30);
            this.tsButton3.TabIndex = 15;
            this.tsButton3.Text = "tsButton3";
            this.tsButton3.Click += new System.EventHandler(this.tsButton3_Click);
            // 
            // MainTimesheetForm
            // 
            this.AccentColor = System.Drawing.Color.DodgerBlue;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderWidth = 2;
            this.ClientSize = new System.Drawing.Size(1160, 652);
            this.Controls.Add(this.tsButton3);
            this.Controls.Add(this.gListProjects);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gListBox3);
            this.Controls.Add(this.gListRole);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.tsCalendar2);
            this.Controls.Add(this.gListActivities);
            this.Controls.Add(this.gListFunctions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tsButton2);
            this.Controls.Add(this.gListDomains);
            this.Controls.Add(this.tsListBox1);
            this.Controls.Add(this.tsButton1);
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

        private TSButton tsButton1;
        private TSListBox tsListBox1;
        private GListBox gListDomains;
        private TSButton tsButton2;
        private GListBox gListFunctions;
        private GListBox gListActivities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private TSCalendar tsCalendar2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private GListBox gListProjects;
        private System.Windows.Forms.Label label5;
        private GListBox gListRole;
        private GListBox gListBox3;
        private System.Windows.Forms.TextBox textBox1;
        private TSButton tsButton3;

    }
}