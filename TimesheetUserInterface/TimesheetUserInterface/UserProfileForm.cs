using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseForm;

namespace TimesheetUserInterface
{
    public partial class UserProfileForm : BaseForm.BaseForm
    {
        public UserProfileForm()
        {
            InitializeComponent();
        }

        public string uName = "";
        public string sName = "";

        private void tsButton1_Click(object sender, EventArgs e)
        {
            if (txtName .Text == "" || txtSurname.Text == "")
            {
                sName = txtSurname.Text;
                uName = txtName.Text;
                MessageBox.Show("Please enter your name and surname");
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

        }

        private void tsButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
