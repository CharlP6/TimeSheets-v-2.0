﻿namespace TimesheetUserInterface
{
    partial class UserProfileForm
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
            BaseForm.ColorPalette colorPalette3 = new BaseForm.ColorPalette();
            this.tsButton1 = new BaseForm.TSButton();
            this.tsButton2 = new BaseForm.TSButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gListBox1 = new BaseForm.GListBox();
            this.gListBox2 = new BaseForm.GListBox();
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
            this.tsButton1.Location = new System.Drawing.Point(587, 327);
            this.tsButton1.Name = "tsButton1";
            this.tsButton1.Size = new System.Drawing.Size(85, 30);
            this.tsButton1.TabIndex = 0;
            this.tsButton1.Text = "OK";
            this.tsButton1.Click += new System.EventHandler(this.tsButton1_Click);
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
            this.tsButton2.Location = new System.Drawing.Point(496, 327);
            this.tsButton2.Name = "tsButton2";
            this.tsButton2.Size = new System.Drawing.Size(85, 30);
            this.tsButton2.TabIndex = 1;
            this.tsButton2.Text = "Cancel";
            this.tsButton2.Click += new System.EventHandler(this.tsButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(47, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(95, 68);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(32, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Surname:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(95, 103);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(100, 22);
            this.txtSurname.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label3.Location = new System.Drawing.Point(635, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "User: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gListBox1
            // 
            this.gListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListBox1.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListBox1.FormattingEnabled = true;
            this.gListBox1.ItemHeight = 16;
            this.gListBox1.Location = new System.Drawing.Point(232, 68);
            this.gListBox1.Name = "gListBox1";
            this.gListBox1.Size = new System.Drawing.Size(144, 224);
            this.gListBox1.TabIndex = 5;
            // 
            // gListBox2
            // 
            this.gListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListBox2.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListBox2.FormattingEnabled = true;
            this.gListBox2.ItemHeight = 16;
            this.gListBox2.Location = new System.Drawing.Point(389, 68);
            this.gListBox2.Name = "gListBox2";
            colorPalette3.Palette = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(42)))), ((int)(((byte)(103))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(204))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(193)))), ((int)(((byte)(230))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))))};
            colorPalette3.Primary = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(204)))));
            colorPalette3.Shade1 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            colorPalette3.Shade2 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(42)))), ((int)(((byte)(103)))));
            colorPalette3.Tint1 = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(193)))), ((int)(((byte)(230)))));
            colorPalette3.Tint2 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))));
            this.gListBox2.Palette = colorPalette3;
            this.gListBox2.Size = new System.Drawing.Size(144, 224);
            this.gListBox2.TabIndex = 5;
            // 
            // UserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(683, 369);
            this.Controls.Add(this.gListBox2);
            this.Controls.Add(this.gListBox1);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsButton2);
            this.Controls.Add(this.tsButton1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserProfileForm";
            this.Text = "User Profile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseForm.TSButton tsButton1;
        private BaseForm.TSButton tsButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label3;
        private BaseForm.GListBox gListBox1;
        private BaseForm.GListBox gListBox2;

    }
}