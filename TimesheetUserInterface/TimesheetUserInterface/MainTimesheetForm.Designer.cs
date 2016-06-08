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
            this.tsListBox1 = new TimesheetUserInterface.TSListBox();
            this.SuspendLayout();
            // 
            // tsListBox1
            // 
            this.tsListBox1.Location = new System.Drawing.Point(12, 227);
            this.tsListBox1.Name = "tsListBox1";
            this.tsListBox1.Size = new System.Drawing.Size(982, 286);
            this.tsListBox1.TabIndex = 0;
            this.tsListBox1.Text = "tsListBox1";
            // 
            // MainTimesheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 525);
            this.Controls.Add(this.tsListBox1);
            this.FontSize = 15F;
            this.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Name = "MainTimesheetForm";
            this.Text = "G5 Engineering Timesheets";
            this.ResumeLayout(false);

        }

        #endregion

        private TSListBox tsListBox1;

    }
}