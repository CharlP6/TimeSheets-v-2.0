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
    public partial class SuggestionBox : BaseForm.BaseForm
    {
        public SuggestionBox()
        {
            InitializeComponent();
        }

        public string Area = "";
        public string Content = "";

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtArea.Text == "" || txtContent.Text == "")
            {
                MessageBox.Show("Please enter a suggestion or click cancel.");
            }
            else
            {
                Area = txtArea.Text;
                Content = txtContent.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
