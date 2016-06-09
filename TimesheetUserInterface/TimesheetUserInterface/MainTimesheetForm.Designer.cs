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
            this.SuspendLayout();
            // 
            // tsButton1
            // 
            this.tsButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton1.FontSize = 12F;
            this.tsButton1.fStyle = System.Drawing.FontStyle.Regular;
            this.tsButton1.Location = new System.Drawing.Point(14, 196);
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
            this.tsListBox1.Columns = null;
            this.tsListBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsListBox1.ItemHeight = 18;
            this.tsListBox1.Location = new System.Drawing.Point(12, 232);
            this.tsListBox1.Name = "tsListBox1";
            this.tsListBox1.Size = new System.Drawing.Size(896, 341);
            this.tsListBox1.TabIndex = 2;
            this.tsListBox1.Text = "tsListBox1";
            // 
            // MainTimesheetForm
            // 
            this.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderWidth = 2;
            this.ClientSize = new System.Drawing.Size(920, 585);
            this.Controls.Add(this.tsListBox1);
            this.Controls.Add(this.tsButton1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FontSize = 15F;
            this.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(101)))), ((int)(((byte)(102)))));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainTimesheetForm";
            this.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(221)))));
            this.Text = "G5 Engineering Timesheets";
            this.ResumeLayout(false);

        }

        #endregion

        private TSButton tsButton1;
        private TSListBox tsListBox1;

    }
}