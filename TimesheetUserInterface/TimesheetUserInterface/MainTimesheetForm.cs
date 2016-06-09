using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimesheetUserInterface
{
    public partial class MainTimesheetForm : BaseForm
    {

        ColorOperations co = new ColorOperations();

        public MainTimesheetForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void tsButton1_Click(object sender, EventArgs e)
        {


        }

    }
}
