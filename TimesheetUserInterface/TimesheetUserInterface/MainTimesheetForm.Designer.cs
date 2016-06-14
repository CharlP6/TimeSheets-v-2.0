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
            this.tsCalendar1 = new TimesheetUserInterface.TSCalendar();
            this.gListBox1 = new TimesheetUserInterface.GListBox();
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
            this.tsButton1.Location = new System.Drawing.Point(12, 196);
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
            this.tsListBox1.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.tsListBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsListBox1.ItemHeight = 17;
            this.tsListBox1.Location = new System.Drawing.Point(12, 232);
            this.tsListBox1.Name = "tsListBox1";
            this.tsListBox1.Size = new System.Drawing.Size(1135, 341);
            this.tsListBox1.TabIndex = 2;
            this.tsListBox1.Text = "tsListBox1";
            // 
            // tsCalendar1
            // 
            this.tsCalendar1.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.tsCalendar1.CurrentDate = new System.DateTime(2016, 6, 10, 0, 0, 0, 0);
            this.tsCalendar1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCalendar1.Location = new System.Drawing.Point(12, 33);
            this.tsCalendar1.Name = "tsCalendar1";
            this.tsCalendar1.Size = new System.Drawing.Size(224, 157);
            this.tsCalendar1.TabIndex = 3;
            this.tsCalendar1.Text = "tsCalendar1";
            // 
            // gListBox1
            // 
            this.gListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListBox1.BorderSwatch = TimesheetUserInterface.Swatch.Shade1;
            this.gListBox1.FormattingEnabled = true;
            this.gListBox1.ItemHeight = 16;
            this.gListBox1.Location = new System.Drawing.Point(430, 33);
            this.gListBox1.Name = "gListBox1";
            this.gListBox1.Size = new System.Drawing.Size(630, 96);
            this.gListBox1.TabIndex = 4;
            // 
            // MainTimesheetForm
            // 
            this.AccentColor = System.Drawing.Color.DodgerBlue;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderWidth = 2;
            this.ClientSize = new System.Drawing.Size(1159, 585);
            this.Controls.Add(this.gListBox1);
            this.Controls.Add(this.tsCalendar1);
            this.Controls.Add(this.tsListBox1);
            this.Controls.Add(this.tsButton1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(89)))), ((int)(((byte)(158)))));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainTimesheetForm";
            this.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.Text = "G5 Engineering Timesheets";
            this.ResumeLayout(false);

        }

        #endregion

        private TSButton tsButton1;
        private TSListBox tsListBox1;
        private TSCalendar tsCalendar1;
        private GListBox gListBox1;

    }
}