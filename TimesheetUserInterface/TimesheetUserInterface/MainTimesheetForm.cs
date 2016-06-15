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
        TSDataBaseAdapter dba;

        public MainTimesheetForm()
        {
            InitializeComponent();
            dba = new TSDataBaseAdapter(@"provider=Microsoft.ACE.OLEDB.12.0; Data Source=E:\v2\Engineering Timesheets Dev Test.accdb", Environment.UserName); //\\g5ho-fs02\Public-ENC\Design and Planning\Timesheets\V2\Engineering Timesheets Dev Test.accdb ", Environment.UserName);
        }

        private void tsButton1_Click(object sender, EventArgs e)
        {            
            tsListBox1.DataSource = dba.TimeSheetData;

            gListDomains.DisplayMember = "Name";
            gListDomains.ValueMember = "ID";
            gListDomains.DataSource = dba.Domains;
            if (gListDomains.SelectedItem != null)
            {
                gListFunctions.DisplayMember = "Name";
                gListFunctions.ValueMember = "ID";
                gListFunctions.DataSource = dba.Functions.Where(w => w.DomainID == (gListDomains.SelectedItem as DomainTable).ID).ToList();
            }

            if(gListFunctions.SelectedItem != null)
            {
                gListActivities.DisplayMember = "Name";
                gListActivities.ValueMember = "ID";
                gListActivities.DataSource = dba.Activities.Where(w => w.FunctionID == (gListFunctions.SelectedItem as FunctionTable).ID).ToList();
            }


            gListProjects.DisplayMember = "PName";
            gListProjects.ValueMember = "ID";
            gListProjects.DataSource = dba.Projects;

            gListRole.DisplayMember = "Name";
            gListRole.ValueMember = "ID";
            gListRole.DataSource = dba.Roles;

        }

        private void tsButton2_Click(object sender, EventArgs e)
        {
            dba.AddUserParameters("Charl2", "Pretorius");
        }

        private void gListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gListDomains.SelectedItem != null)
            {
                gListFunctions.DisplayMember = "Name";
                gListFunctions.ValueMember = "ID";
                gListFunctions.DataSource = dba.Functions.Where(w => w.DomainID == (gListDomains.SelectedItem as DomainTable).ID).ToList();
            }
        }

        private void MainTimesheetForm_Load(object sender, EventArgs e)
        {

        }

        private void gListFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gListFunctions.SelectedItem != null)
            {
                gListActivities.DisplayMember = "Name";
                gListActivities.ValueMember = "ID";
                gListActivities.DataSource = dba.Activities.Where(w => w.FunctionID == (gListFunctions.SelectedItem as FunctionTable).ID).ToList();
            }
        }

        private void tsButton3_Click(object sender, EventArgs e)
        {
            dba.AddTimeSheetEntry(DateTime.Today, 4.5f, (gListProjects.SelectedItem as ProjectTable).ID, (gListDomains.SelectedItem as DomainTable).ID, (gListFunctions.SelectedItem as FunctionTable).ID, (gListActivities.SelectedItem as ActivitiesTable).ID, (gListRole.SelectedItem as RSTable).ID, "test soft", "comments", DateTime.Now);
            dba.RefreshTimeSheets();
            tsListBox1.DataSource = dba.TimeSheetData;
        }

    }
}
