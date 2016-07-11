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
            BaseForm.ColorPalette colorPalette1 = new BaseForm.ColorPalette();
            this.tsButton1 = new BaseForm.TSButton();
            this.gListBox1 = new BaseForm.GListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tsCalendar1 = new BaseForm.TSCalendar();
            this.tsListBox1 = new BaseForm.TSListBox();
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
            this.tsButton1.Location = new System.Drawing.Point(430, 36);
            this.tsButton1.Name = "tsButton1";
            this.tsButton1.PaintOnlyTop = false;
            this.tsButton1.Size = new System.Drawing.Size(88, 30);
            this.tsButton1.TabIndex = 0;
            this.tsButton1.Text = "tsButton1";
            this.tsButton1.Click += new System.EventHandler(this.tsButton1_Click);
            // 
            // gListBox1
            // 
            this.gListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListBox1.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gListBox1.FormattingEnabled = true;
            this.gListBox1.Location = new System.Drawing.Point(246, 36);
            this.gListBox1.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.gListBox1.Name = "gListBox1";
            this.gListBox1.Size = new System.Drawing.Size(174, 286);
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
            // tsListBox1
            // 
            this.tsListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tsListBox1.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsListBox1.FormattingEnabled = true;
            this.tsListBox1.ItemHeight = 15;
            this.tsListBox1.Location = new System.Drawing.Point(16, 328);
            this.tsListBox1.Name = "tsListBox1";
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
            this.tsListBox1.Palette = colorPalette1;
            this.tsListBox1.Size = new System.Drawing.Size(1223, 160);
            this.tsListBox1.TabIndex = 9;
            // 
            // frmManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1255, 503);
            this.Controls.Add(this.tsListBox1);
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
        private BaseForm.TSListBox tsListBox1;
    }
}

