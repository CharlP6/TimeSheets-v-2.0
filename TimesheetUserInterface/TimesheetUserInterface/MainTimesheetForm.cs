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
using BaseForm;
using DataAdapter;

namespace TimesheetUserInterface
{
    public partial class MainTimesheetForm : BaseForm.BaseForm
    {
        TSDataBaseAdapter dba;

        public MainTimesheetForm()
        {
            InitializeComponent();
            tsCalendar2.CurrentDate = DateTime.Today;
            tsCalendar2.SelectedDays.Add(tsCalendar2.CurrentDate);
            LoadDatabase();

            this.Text = "G5 Engineering Timesheets - Logged in as " + dba.CurrentUser.Name + " " + dba.CurrentUser.Surname;
        }

        private void LoadDatabase()
        {
            dba = new TSDataBaseAdapter(@"provider=Microsoft.ACE.OLEDB.12.0; Data Source=\\g5ho-fs02\Public-ENC\Design and Planning\Timesheets\V2\Engineering Timesheets Dev Test.accdb ", Environment.UserName);
            if (dba.UserID == -1)
            {
                UserProfileForm upf = new UserProfileForm();
                DialogResult fdr = upf.ShowDialog();
                if (fdr == System.Windows.Forms.DialogResult.OK)
                {
                    dba.AddUserParameters(upf.uName, upf.sName);
                    LoadDatabase();
                }
                else
                {
                    Application.Exit();
                }
            }

            tsListBox1.Activities = dba.Activities;
            tsListBox1.AdditionalTables = dba.AdditionalTables;
            tsListBox1.Domains = dba.Domains;
            tsListBox1.Functions = dba.Functions;
            tsListBox1.Projects = dba.Projects;
            tsListBox1.Roles = dba.Roles;

            tsListBox1.DisplayMember = "WorkDate";
            tsListBox1.DataSource = dba.TimeSheetEntries.Where(w => w.WorkDate == tsCalendar2.CurrentDate).ToList();

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

            if(dba.UserProjectList.Count > 0)
            {
                gListProjects.DisplayMember = "PName";
                gListProjects.ValueMember = "ID";
                gListProjects.DataSource = dba.UserProjectList.ConvertAll<ProjectTable>(new Converter<UserProjects, ProjectTable>(ConvertUserProject));
            }


            gListRole.DisplayMember = "Name";
            gListRole.ValueMember = "ID";
            gListRole.DataSource = dba.Roles;

            tsCalendar2.BoldDays = dba.TimeSheetEntries.Select(s => s.WorkDate).Distinct().ToList();
        }

        private void tsButton1_Click(object sender, EventArgs e)
        {

        }

        private void tsButton2_Click(object sender, EventArgs e)
        {
            UserProjectForm uprform = new UserProjectForm();
            uprform.AllProjects = dba.Projects;
            uprform.UserProjectList.AddRange(dba.UserProjectList);

            DialogResult dr = uprform.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (UserProjects up in uprform.UserProjectList)
                {
                    if(!dba.UserProjectList.Select(s => s.ProjectID).Contains(up.ProjectID))
                    {
                        dba.AddUserProject(up.ProjectID, up.RoleID);
                    }
                }
                dba.RefreshUserProjects();
                if (dba.UserProjectList.Count > 0)
                {
                    gListProjects.DisplayMember = "PName";
                    gListProjects.ValueMember = "ID";
                    gListProjects.DataSource = dba.UserProjectList.ConvertAll<ProjectTable>(new Converter<UserProjects, ProjectTable>(ConvertUserProject));
                }
            }

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
            DateTime entryDate = tsCalendar2.CurrentDate;
            float entryHours = (float)numericUpDown1.Value;
            int prID = (gListProjects.SelectedItem as ProjectTable).ID;
            int domID = (gListDomains.SelectedItem as DomainTable).ID;
            int funcID = (gListFunctions.SelectedItem as FunctionTable).ID;
            int actID = (gListActivities.SelectedItem as ActivitiesTable).ID;
            int? addID = gListAdditional.SelectedIndex != -1 ? (gListAdditional.SelectedItem as AdditionalTable).ID : new int?();

            int roleID = (gListRole.SelectedItem as RSTable).ID;

            dba.AddTimeSheetEntry(entryDate, entryHours, prID, domID, funcID, actID, addID, roleID, "", txtComments.Text, DateTime.Now.RomoveMiliSeconds());
            
            dba.RefreshTimeSheets();


            UpdateList();
            //tsListBox1.Invalidate(); tsListBox1.Refresh();
        }

        private void gListActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((gListActivities.SelectedItem as ActivitiesTable).AddTable != "")
            {
                gListAdditional.DisplayMember = "Name";
                gListAdditional.ValueMember = "ID";
                gListAdditional.DataSource = dba.AdditionalTables.Where(w => w.TableName == (gListActivities.SelectedItem as ActivitiesTable).AddTable).ToList();
            }
            else
            {
                gListAdditional.DataSource = null;
            }
        }

        private void tsCalendar2_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        void UpdateList()
        {
            tsListBox1.DataSource = null;
            tsListBox1.DisplayMember = "WorkDate";
            tsListBox1.DataSource = dba.TimeSheetEntries.Where(w => w.WorkDate >= tsCalendar2.SelectedDays.Min() && w.WorkDate <= tsCalendar2.SelectedDays.Max()).ToList();
            tsCalendar2.BoldDays = dba.TimeSheetEntries.Select(s => s.WorkDate).Distinct().ToList();
        }

        private void tsListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        ProjectTable ConvertUserProject(UserProjects up)
        {
            return dba.Projects.Where(w => w.ID == up.ProjectID).FirstOrDefault();
        }
    }

    public static class ExtestionMethods
    {
        public static DateTime RomoveMiliSeconds(this DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }
    }
}
