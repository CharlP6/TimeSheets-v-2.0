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
            tsCalendar.CurrentDate = DateTime.Today;
            tsCalendar.SelectedDays.Add(tsCalendar.CurrentDate);

            LoadDatabase();
            InitializeUI();

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
        }
        
        #region UpdateUI

        private void InitializeUI()
        {
            lstTimeSheets.Activities = dba.Activities;
            lstTimeSheets.AdditionalTables = dba.AdditionalTables;
            lstTimeSheets.Domains = dba.Domains;
            lstTimeSheets.Functions = dba.Functions;
            lstTimeSheets.Projects = dba.Projects;
            lstTimeSheets.Roles = dba.Roles;

            lstTimeSheets.DisplayMember = "WorkDate";
            lstTimeSheets.DataSource = dba.TimeSheetEntries.Where(w => w.WorkDate == tsCalendar.CurrentDate).ToList();

            gListDomains.DisplayMember = "Name";
            gListDomains.ValueMember = "ID";
            gListDomains.DataSource = dba.Domains;
            if (gListDomains.SelectedItem != null)
            {
                gListFunctions.DisplayMember = "Name";
                gListFunctions.ValueMember = "ID";
                gListFunctions.DataSource = dba.Functions.Where(w => w.DomainID == (gListDomains.SelectedItem as DomainTable).ID).ToList();
            }

            if (gListFunctions.SelectedItem != null)
            {
                gListActivities.DisplayMember = "Name";
                gListActivities.ValueMember = "ID";
                gListActivities.DataSource = dba.Activities.Where(w => w.FunctionID == (gListFunctions.SelectedItem as FunctionTable).ID).ToList();
            }

            if (dba.UserProjectList.Count > 0)
            {
                gListProjects.DisplayMember = "PName";
                gListProjects.ValueMember = "ID";
                gListProjects.DataSource = dba.UserProjectList.ConvertAll<ProjectTable>(new Converter<UserProjects, ProjectTable>(ConvertUserProject));
            }


            gListRole.DisplayMember = "Name";
            gListRole.ValueMember = "ID";
            gListRole.DataSource = dba.Roles;

            tsCalendar.BoldDays = dba.TimeSheetEntries.Select(s => s.WorkDate).Distinct().ToList();
        }

        private void tsCalendar_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void gListDomains_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gListDomains.SelectedItem != null)
            {
                gListFunctions.DisplayMember = "Name";
                gListFunctions.ValueMember = "ID";
                gListFunctions.DataSource = dba.Functions.Where(w => w.DomainID == (gListDomains.SelectedItem as DomainTable).ID).ToList();
            }
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

        void UpdateList()
        {
            try
            {
                lstTimeSheets.DataSource = null;
                lstTimeSheets.DisplayMember = "WorkDate";
                lstTimeSheets.DataSource = dba.TimeSheetEntries.Where(w => w.WorkDate >= tsCalendar.SelectedDays.Min() && w.WorkDate <= tsCalendar.SelectedDays.Max()).ToList();
                tsCalendar.BoldDays = dba.TimeSheetEntries.Select(s => s.WorkDate).Distinct().ToList();
            }
            catch 
            {
                
            }

        }
        #endregion

        #region ManipulateData

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            using (UserProjectForm uprform = new UserProjectForm())
            {
                uprform.AllProjects = dba.Projects;
                uprform.UserProjectList.AddRange(dba.UserProjectList);

                DialogResult dr = uprform.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (UserProjects up in uprform.UserProjectList)
                    {
                        if (!dba.UserProjectList.Select(s => s.ProjectID).Contains(up.ProjectID))
                        {
                            dba.AddUserProject(up.ProjectID, up.RoleID);
                        }
                    }
                    foreach (UserProjects up in dba.UserProjectList)
                    {
                        if (!uprform.UserProjectList.Contains(up))
                        {
                            dba.DeleteItemFromTable("UserProjects", "ID", up.ID);
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
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            DateTime entryDate = tsCalendar.CurrentDate;
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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTimeSheets.SelectedIndex != -1)
            {
                if (MessageBox.Show("Are you sure you want to delete the entry? Undo not available.", "Warning", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        int DeleteID = (lstTimeSheets.SelectedItem as TimeSheetEntry).ID;
                        dba.DeleteItemFromTable("TimeSheets", "ID", DeleteID);
                        dba.RefreshTimeSheets();
                        UpdateList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime entryDate = tsCalendar.CurrentDate;
            float entryHours = (float)numericUpDown1.Value;
            int prID = (gListProjects.SelectedItem as ProjectTable).ID;
            int domID = (gListDomains.SelectedItem as DomainTable).ID;
            int funcID = (gListFunctions.SelectedItem as FunctionTable).ID;
            int actID = (gListActivities.SelectedItem as ActivitiesTable).ID;
            int? addID = gListAdditional.SelectedIndex != -1 ? (gListAdditional.SelectedItem as AdditionalTable).ID : new int?();

            int roleID = (gListRole.SelectedItem as RSTable).ID;

            object[] editEntry = { entryDate, entryHours, prID, domID, funcID, actID, roleID, "", txtComments.Text, DateTime.Now.RomoveMiliSeconds(), addID };
            string[] Headers = { "Work Date", "Time", "Project ID", "Domain ID", "Function ID", "Activity ID", "Role ID", "Software Package", "Comments", "Time Stamp", "Additional ID" };

            dba.ModifyItemInTable("TimeSheets", Headers, editEntry, "ID", (lstTimeSheets.SelectedItem as TimeSheetEntry).ID);
            dba.RefreshTimeSheets();

            UpdateList();
        }

        #endregion
        
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
