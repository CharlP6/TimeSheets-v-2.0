namespace TimesheetUserInterface
{
    partial class UserProjectForm
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
            this.glAllProjects = new BaseForm.GListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tsButton1 = new BaseForm.TSButton();
            this.glUProjects = new BaseForm.GListBox();
            this.tsButton2 = new BaseForm.TSButton();
            this.tsButton3 = new BaseForm.TSButton();
            this.tsButton4 = new BaseForm.TSButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // glAllProjects
            // 
            this.glAllProjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.glAllProjects.BorderSwatch = BaseForm.Swatch.Shade1;
            this.glAllProjects.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.glAllProjects.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glAllProjects.FormattingEnabled = true;
            this.glAllProjects.ItemHeight = 16;
            this.glAllProjects.Location = new System.Drawing.Point(12, 54);
            this.glAllProjects.Name = "glAllProjects";
            this.glAllProjects.Size = new System.Drawing.Size(191, 160);
            this.glAllProjects.Sorted = true;
            this.glAllProjects.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(106, 220);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(97, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tsButton1
            // 
            this.tsButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton1.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.tsButton1.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsButton1.ClickSwatch = BaseForm.Swatch.Tint1;
            this.tsButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton1.ForeColor = System.Drawing.Color.White;
            this.tsButton1.HoverSwatch = BaseForm.Swatch.Primary;
            this.tsButton1.Location = new System.Drawing.Point(209, 73);
            this.tsButton1.Name = "tsButton1";
            this.tsButton1.PaintOnlyTop = false;
            this.tsButton1.Size = new System.Drawing.Size(51, 30);
            this.tsButton1.TabIndex = 2;
            this.tsButton1.Text = ">>";
            this.tsButton1.Click += new System.EventHandler(this.tsButton1_Click);
            // 
            // glUProjects
            // 
            this.glUProjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.glUProjects.BorderSwatch = BaseForm.Swatch.Shade1;
            this.glUProjects.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.glUProjects.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glUProjects.FormattingEnabled = true;
            this.glUProjects.ItemHeight = 16;
            this.glUProjects.Location = new System.Drawing.Point(266, 54);
            this.glUProjects.Name = "glUProjects";
            this.glUProjects.Size = new System.Drawing.Size(191, 160);
            this.glUProjects.Sorted = true;
            this.glUProjects.TabIndex = 3;
            // 
            // tsButton2
            // 
            this.tsButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton2.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.tsButton2.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsButton2.ClickSwatch = BaseForm.Swatch.Tint1;
            this.tsButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton2.ForeColor = System.Drawing.Color.White;
            this.tsButton2.HoverSwatch = BaseForm.Swatch.Primary;
            this.tsButton2.Location = new System.Drawing.Point(209, 149);
            this.tsButton2.Name = "tsButton2";
            this.tsButton2.PaintOnlyTop = false;
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
            this.tsButton2.Palette = colorPalette1;
            this.tsButton2.Size = new System.Drawing.Size(51, 30);
            this.tsButton2.TabIndex = 2;
            this.tsButton2.Text = "<<";
            this.tsButton2.Click += new System.EventHandler(this.tsButton2_Click);
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
            this.tsButton3.Location = new System.Drawing.Point(372, 220);
            this.tsButton3.Name = "tsButton3";
            this.tsButton3.PaintOnlyTop = false;
            this.tsButton3.Size = new System.Drawing.Size(85, 30);
            this.tsButton3.TabIndex = 4;
            this.tsButton3.Text = "OK";
            this.tsButton3.Click += new System.EventHandler(this.tsButton3_Click);
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
            this.tsButton4.Location = new System.Drawing.Point(266, 220);
            this.tsButton4.Name = "tsButton4";
            this.tsButton4.PaintOnlyTop = false;
            this.tsButton4.Size = new System.Drawing.Size(85, 30);
            this.tsButton4.TabIndex = 5;
            this.tsButton4.Text = "Cancel";
            this.tsButton4.Click += new System.EventHandler(this.tsButton4_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label5.Location = new System.Drawing.Point(9, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Search Projects:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "All Projects:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(263, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Displayed Projects:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(468, 260);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tsButton4);
            this.Controls.Add(this.tsButton3);
            this.Controls.Add(this.glUProjects);
            this.Controls.Add(this.tsButton2);
            this.Controls.Add(this.tsButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.glAllProjects);
            this.Name = "UserProjectForm";
            this.Text = "User Projects";
            this.Load += new System.EventHandler(this.UserProjectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseForm.GListBox glAllProjects;
        private System.Windows.Forms.TextBox textBox1;
        private BaseForm.TSButton tsButton1;
        private BaseForm.GListBox glUProjects;
        private BaseForm.TSButton tsButton2;
        private BaseForm.TSButton tsButton3;
        private BaseForm.TSButton tsButton4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}