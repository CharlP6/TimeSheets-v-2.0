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
            Color s2 = Color.FromArgb(108, 41, 0);
            Color s1 = Color.FromArgb(156, 60, 0);
            Color p = Color.FromArgb(242, 93, 0);
            Color t1 = Color.FromArgb(255, 121, 37);
            Color t2 = Color.FromArgb(255, 210, 182);

            //this.Palette = new ColorPalette(s2,s1,p,t1,t2);

            string[] test = { "a", "b", "c" };

            tsListBox1.AddItem(test);


        }

    }
}
