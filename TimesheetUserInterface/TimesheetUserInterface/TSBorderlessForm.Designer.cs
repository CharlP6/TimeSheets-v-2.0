namespace TimesheetUserInterface
{
    partial class TSBorderlessForm
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
            this.tsClose = new TimesheetUserInterface.TSButton();
            this.tsMinimize = new TimesheetUserInterface.TSButton();
            this.SuspendLayout();
            // 
            // tsClose
            // 
            this.tsClose.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tsClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.tsClose.FontSize = 10F;
            this.tsClose.fStyle = System.Drawing.FontStyle.Regular;
            this.tsClose.Location = new System.Drawing.Point(552, 3);
            this.tsClose.Name = "tsClose";
            this.tsClose.Size = new System.Drawing.Size(19, 19);
            this.tsClose.TabIndex = 3;
            this.tsClose.Text = "X";
            this.tsClose.Click += new System.EventHandler(this.tsButton1_Click);
            // 
            // tsMinimize
            // 
            this.tsMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.tsMinimize.FontSize = 10F;
            this.tsMinimize.fStyle = System.Drawing.FontStyle.Regular;
            this.tsMinimize.Location = new System.Drawing.Point(513, 3);
            this.tsMinimize.Name = "tsMinimize";
            this.tsMinimize.Size = new System.Drawing.Size(19, 19);
            this.tsMinimize.TabIndex = 4;
            this.tsMinimize.Text = "_";
            this.tsMinimize.Click += new System.EventHandler(this.tsMinimize_Click);
            // 
            // TSBorderlessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(574, 352);
            this.Controls.Add(this.tsMinimize);
            this.Controls.Add(this.tsClose);
            this.FontSize = 16F;
            this.MainColor = System.Drawing.Color.Navy;
            this.Name = "TSBorderlessForm";
            this.TitleHeight = 24;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TSButton tsClose;
        private TSButton tsMinimize;



    }
}

