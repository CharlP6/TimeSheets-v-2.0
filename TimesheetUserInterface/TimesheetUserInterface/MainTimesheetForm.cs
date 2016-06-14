using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimesheetUserInterface
{
    public partial class MainTimesheetForm : BaseForm
    {
        public MainTimesheetForm()
        {
            InitializeComponent();
        }

        private void tsButton1_Click(object sender, EventArgs e)
        {
            TSDataBaseAdapter dba = new TSDataBaseAdapter(@"provider=Microsoft.ACE.OLEDB.12.0; Data Source=\\g5ho-fs02\Public-ENC\Design and Planning\Timesheets\V2\Engineering Timesheets Dev Test.accdb ", Environment.UserName);

            tsListBox1.DataSource = dba.TimeSheetData;

            gListBox1.DataSource = dba.Domains;
            gListBox1.DisplayMember = "Name";
            gListBox1.ValueMember = "ID";
        }

    }
}
