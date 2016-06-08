using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimesheetUserInterface
{
    public partial class TSBorderlessForm : BaseForm
    {
        public TSBorderlessForm()
        {
            InitializeComponent();
            //tsClose.Height = this.TitleHeight;
            //tsClose.Width = this.TitleHeight;
            //tsClose.Top = TitleHeight / 2;
            //tsClose.Left = this.Width - (TitleHeight / 2)-tsClose.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void tsButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
