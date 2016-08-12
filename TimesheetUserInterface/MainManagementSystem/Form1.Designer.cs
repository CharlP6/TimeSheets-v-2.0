namespace MainManagementSystem
{
    partial class frmManagement
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
            this.tsButton1 = new BaseForm.TSButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tsCalendar1 = new BaseForm.TSCalendar();
            this.tsButton2 = new BaseForm.TSButton();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.lvUserHours = new System.Windows.Forms.ListView();
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // tsButton1
            // 
            this.tsButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton1.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.tsButton1.BorderPaint = false;
            this.tsButton1.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsButton1.BorderWidth = 1;
            this.tsButton1.ClickSwatch = BaseForm.Swatch.Tint1;
            this.tsButton1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton1.ForeColor = System.Drawing.Color.White;
            this.tsButton1.HoverSwatch = BaseForm.Swatch.Primary;
            this.tsButton1.Location = new System.Drawing.Point(16, 202);
            this.tsButton1.Name = "tsButton1";
            this.tsButton1.PaintOnlyTop = false;
            this.tsButton1.Size = new System.Drawing.Size(88, 30);
            this.tsButton1.TabIndex = 0;
            this.tsButton1.Text = "Overview";
            this.tsButton1.Click += new System.EventHandler(this.tsButton1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(239, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(640, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "User Hours:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tsCalendar1
            // 
            this.tsCalendar1.BorderPaint = true;
            this.tsCalendar1.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsCalendar1.BorderWidth = 1;
            this.tsCalendar1.CurrentDate = new System.DateTime(2016, 7, 11, 0, 0, 0, 0);
            this.tsCalendar1.DisplayDate = new System.DateTime(2016, 7, 1, 0, 0, 0, 0);
            this.tsCalendar1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCalendar1.Location = new System.Drawing.Point(12, 36);
            this.tsCalendar1.Name = "tsCalendar1";
            this.tsCalendar1.PaintOnlyTop = false;
            this.tsCalendar1.Size = new System.Drawing.Size(224, 160);
            this.tsCalendar1.TabIndex = 8;
            this.tsCalendar1.Text = "tsCalendar1";
            // 
            // tsButton2
            // 
            this.tsButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton2.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.tsButton2.BorderPaint = false;
            this.tsButton2.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsButton2.BorderWidth = 1;
            this.tsButton2.ClickSwatch = BaseForm.Swatch.Tint1;
            this.tsButton2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton2.ForeColor = System.Drawing.Color.White;
            this.tsButton2.HoverSwatch = BaseForm.Swatch.Primary;
            this.tsButton2.Location = new System.Drawing.Point(151, 202);
            this.tsButton2.Name = "tsButton2";
            this.tsButton2.PaintOnlyTop = false;
            this.tsButton2.Size = new System.Drawing.Size(85, 30);
            this.tsButton2.TabIndex = 10;
            this.tsButton2.Text = "Export";
            this.tsButton2.Click += new System.EventHandler(this.tsButton2_Click);
            // 
            // OFD
            // 
            this.OFD.FileName = "openFileDialog1";
            // 
            // SFD
            // 
            this.SFD.Filter = "(*.csv)|*.csv";
            // 
            // lvUserHours
            // 
            this.lvUserHours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUserHours.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUser});
            this.lvUserHours.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvUserHours.ForeColor = System.Drawing.Color.Navy;
            this.lvUserHours.FullRowSelect = true;
            this.lvUserHours.GridLines = true;
            this.lvUserHours.Location = new System.Drawing.Point(242, 65);
            this.lvUserHours.Name = "lvUserHours";
            this.lvUserHours.Size = new System.Drawing.Size(640, 556);
            this.lvUserHours.TabIndex = 11;
            this.lvUserHours.UseCompatibleStateImageBehavior = false;
            this.lvUserHours.View = System.Windows.Forms.View.Details;
            // 
            // colUser
            // 
            this.colUser.Text = "User";
            this.colUser.Width = 124;
            // 
            // frmManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(897, 633);
            this.Controls.Add(this.lvUserHours);
            this.Controls.Add(this.tsButton2);
            this.Controls.Add(this.tsCalendar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tsButton1);
            this.Name = "frmManagement";
            this.Text = "Timesheet Management System";
            this.Load += new System.EventHandler(this.frmManagement_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BaseForm.TSButton tsButton1;
        private System.Windows.Forms.Label label2;
        private BaseForm.TSCalendar tsCalendar1;
        private BaseForm.TSButton tsButton2;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.ListView lvUserHours;
        private System.Windows.Forms.ColumnHeader colUser;
    }
}

