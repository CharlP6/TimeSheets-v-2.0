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
            this.tsCalendar1 = new BaseForm.TSCalendar();
            this.gListBox1 = new BaseForm.GListBox();
            this.SuspendLayout();
            // 
            // tsButton1
            // 
            this.tsButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton1.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.tsButton1.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsButton1.ClickSwatch = BaseForm.Swatch.Tint1;
            this.tsButton1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton1.ForeColor = System.Drawing.Color.White;
            this.tsButton1.HoverSwatch = BaseForm.Swatch.Primary;
            this.tsButton1.Location = new System.Drawing.Point(430, 52);
            this.tsButton1.Name = "tsButton1";
            this.tsButton1.PaintOnlyTop = false;
            this.tsButton1.Size = new System.Drawing.Size(88, 30);
            this.tsButton1.TabIndex = 0;
            this.tsButton1.Text = "tsButton1";
            this.tsButton1.Click += new System.EventHandler(this.tsButton1_Click);
            // 
            // tsCalendar1
            // 
            this.tsCalendar1.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsCalendar1.CurrentDate = new System.DateTime(2016, 6, 27, 0, 0, 0, 0);
            this.tsCalendar1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCalendar1.Location = new System.Drawing.Point(12, 36);
            this.tsCalendar1.Name = "tsCalendar1";
            this.tsCalendar1.PaintOnlyTop = false;
            this.tsCalendar1.Size = new System.Drawing.Size(224, 137);
            this.tsCalendar1.TabIndex = 1;
            this.tsCalendar1.Text = "tsCalendar1";
            // 
            // gListBox1
            // 
            this.gListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListBox1.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gListBox1.FormattingEnabled = true;
            this.gListBox1.Location = new System.Drawing.Point(246, 52);
            this.gListBox1.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.gListBox1.Name = "gListBox1";
            this.gListBox1.Size = new System.Drawing.Size(174, 247);
            this.gListBox1.TabIndex = 2;
            // 
            // frmManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(530, 317);
            this.Controls.Add(this.gListBox1);
            this.Controls.Add(this.tsCalendar1);
            this.Controls.Add(this.tsButton1);
            this.Name = "frmManagement";
            this.Text = "Timesheet Management System";
            this.ResumeLayout(false);

        }

        #endregion

        private BaseForm.TSButton tsButton1;
        private BaseForm.TSCalendar tsCalendar1;
        private BaseForm.GListBox gListBox1;
    }
}

