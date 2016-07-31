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
            this.gListBox1 = new BaseForm.GListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tsCalendar1 = new BaseForm.TSCalendar();
            this.gListBox2 = new BaseForm.GListBox();
            this.tsButton2 = new BaseForm.TSButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
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
            this.tsButton1.Location = new System.Drawing.Point(242, 36);
            this.tsButton1.Name = "tsButton1";
            this.tsButton1.PaintOnlyTop = false;
            this.tsButton1.Size = new System.Drawing.Size(88, 30);
            this.tsButton1.TabIndex = 0;
            this.tsButton1.Text = "Overview";
            this.tsButton1.Click += new System.EventHandler(this.tsButton1_Click);
            // 
            // gListBox1
            // 
            this.gListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListBox1.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gListBox1.FormattingEnabled = true;
            this.gListBox1.Location = new System.Drawing.Point(12, 202);
            this.gListBox1.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.gListBox1.Name = "gListBox1";
            this.gListBox1.Size = new System.Drawing.Size(174, 351);
            this.gListBox1.Sorted = true;
            this.gListBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(13, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 13);
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
            this.tsCalendar1.Size = new System.Drawing.Size(224, 137);
            this.tsCalendar1.TabIndex = 8;
            this.tsCalendar1.Text = "tsCalendar1";
            // 
            // gListBox2
            // 
            this.gListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListBox2.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gListBox2.FormattingEnabled = true;
            this.gListBox2.Location = new System.Drawing.Point(196, 202);
            this.gListBox2.Name = "gListBox2";
            this.gListBox2.Size = new System.Drawing.Size(284, 351);
            this.gListBox2.Sorted = true;
            this.gListBox2.TabIndex = 9;
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
            this.tsButton2.Location = new System.Drawing.Point(242, 143);
            this.tsButton2.Name = "tsButton2";
            this.tsButton2.PaintOnlyTop = false;
            this.tsButton2.Size = new System.Drawing.Size(85, 30);
            this.tsButton2.TabIndex = 10;
            this.tsButton2.Text = "tsButton2";
            this.tsButton2.Click += new System.EventHandler(this.tsButton2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(336, 75);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(144, 121);
            this.listBox1.TabIndex = 11;
            // 
            // frmManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(492, 567);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tsButton2);
            this.Controls.Add(this.gListBox2);
            this.Controls.Add(this.tsCalendar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gListBox1);
            this.Controls.Add(this.tsButton1);
            this.Name = "frmManagement";
            this.Text = "Timesheet Management System";
            this.ResumeLayout(false);

        }

        #endregion

        private BaseForm.TSButton tsButton1;
        private BaseForm.GListBox gListBox1;
        private System.Windows.Forms.Label label2;
        private BaseForm.TSCalendar tsCalendar1;
        private BaseForm.GListBox gListBox2;
        private BaseForm.TSButton tsButton2;
        private System.Windows.Forms.ListBox listBox1;
    }
}

