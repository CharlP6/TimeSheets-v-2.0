using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Diagnostics;
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
            string SettingsString = Application.StartupPath + "/Management/Config.cfg";

            using (FileStream fs = new FileStream(SettingsString, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string connectionString = sr.ReadLine();
                    dba = new TSDataBaseAdapter(connectionString, Environment.UserName);
                }
            }
            //dba = new TSDataBaseAdapter(@"provider=Microsoft.ACE.OLEDB.12.0; Data Source=E:\\V2\Engineering Timesheets Dev Test.accdb ", Environment.UserName);

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

            if (!dba.UserProjectList.Select(s => s.ProjectID).Contains(156))
                dba.AddUserProject(156, -1);
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
                gListRole.DisplayMember = "Name";
                gListRole.ValueMember = "ID";
                gListRole.DataSource = dba.Roles.Where(w => w.FunctionID == (gListFunctions.SelectedItem as FunctionTable).ID).ToList();

                gListActivities.DisplayMember = "Name";
                gListActivities.ValueMember = "ID";
                gListActivities.DataSource = dba.Activities.Where(w => w.FunctionID == (gListFunctions.SelectedItem as FunctionTable).ID && w.BimRole == (gListRole.SelectedItem as RSTable).BimRole).ToList();
            }

            UpdateProjects();

            tsCalendar.BoldDays = dba.TimeSheetEntries.Select(s => s.WorkDate).Distinct().ToList();
            tsCalendar.DisplayDate = tsCalendar.CurrentDate;
            UpdateList();
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

                DomainTable dt = gListDomains.SelectedItem as DomainTable;

                gListFunctions.DataSource = dba.Functions.Where(w => w.DomainID == dt.ID).OrderBy(o => o.Name).ToList();

                UpdateProjects();

                if (gListProjects.Items.Count > 0)
                {
                    gListProjects.SelectedIndex = 0;
                }
            }
        }

        private void gListFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gListFunctions.SelectedItem != null)
            {
                IEnumerable<ActivitiesTable> acts;
                FunctionTable ft = gListFunctions.SelectedItem as FunctionTable;

                //if (ft.Name == "Research and Development")
                //{

                //}

                gListRole.DisplayMember = "Name";
                gListRole.ValueMember = "ID";
                gListRole.DataSource = dba.Roles.Where(w => w.FunctionID == ft.ID).ToList();


                gListActivities.DataSource = null;

                gListActivities.DisplayMember = "Name";
                gListActivities.ValueMember = "ID";
                gListActivities.DataSource = dba.Activities.Where(w => w.FunctionID == ft.ID && w.BimRole == (gListRole.SelectedItem as RSTable).BimRole).OrderBy(o => o.Name).ToList();

                if (gListActivities.Items.Count == 0)
                {
                    gListAdditional.DataSource = null;
                }
            }
        }

        private void gListActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((gListActivities.SelectedItem as ActivitiesTable).AddTable != "")
            {
                gListAdditional.DisplayMember = "Name";
                gListAdditional.ValueMember = "ID";
                gListAdditional.DataSource = dba.AdditionalTables.Where(w => w.TableName == (gListActivities.SelectedItem as ActivitiesTable).AddTable).OrderBy(o => o.Name).ToList();
            }
            else
            {
                gListAdditional.DataSource = null;
            }
        }

        ProjectTable ConvertUserProject(UserProjects up)
        {
            return dba.Projects.Where(w => w.ID == up.ProjectID).FirstOrDefault();
        }

        bool mouseClicked = false;

        private void lstTimeSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mouseClicked)
            {
                TimeSheetEntry tse = lstTimeSheets.SelectedItem as TimeSheetEntry;

                ProjectTable pt = dba.Projects.Where(w => w.ID == tse.ProjectID).First();

                //MessageBox.Show(tse.ProjectID.ToString());
                tsCalendar.CurrentDate = tse.WorkDate;
                gListDomains.SelectedValue = tse.DomainID;
                gListFunctions.SelectedValue = tse.FunctionID;
                gListRole.SelectedValue = tse.RoleID;
                gListActivities.SelectedValue = tse.ActivityID;
                gListAdditional.SelectedValue = tse.AdditionalID;

                numericUpDown1.Value = (decimal)tse.Time;
                txtComments.Text = tse.Comments;

                if (!gListProjects.Items.Contains(pt))
                {
                    dba.AddUserProject(tse.ProjectID, -1);
                    dba.RefreshUserProjects();
                    gListProjects.DisplayMember = "PName";
                    gListProjects.ValueMember = "ID";
                    gListProjects.DataSource = dba.UserProjectList.ConvertAll<ProjectTable>(new Converter<UserProjects, ProjectTable>(ConvertUserProject));
                }
                gListProjects.SelectedItem = pt;
            }
            mouseClicked = false;
        }

        private void lstTimeSheets_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClicked = true;
        }

        private void lstTimeSheets_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
        }

        private void gListRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gListRole.SelectedIndex != -1)
            {
                gListActivities.DataSource = null;
                gListActivities.DisplayMember = "Name";
                gListActivities.ValueMember = "ID";
                gListActivities.DataSource = dba.Activities.Where(w => w.FunctionID == (gListFunctions.SelectedItem as FunctionTable).ID && w.BimRole == (gListRole.SelectedItem as RSTable).BimRole).OrderBy(o => o.Name).ToList();

                if (gListActivities.Items.Count == 0)
                {
                    gListAdditional.DataSource = null;
                }
            }
        }

        void UpdateList()
        {
            try
            {
                lstTimeSheets.DataSource = null;
                lstTimeSheets.DisplayMember = "WorkDate";
                lstTimeSheets.DataSource = dba.TimeSheetEntries.Where(w => w.WorkDate >= tsCalendar.SelectedDays.Min() && w.WorkDate <= tsCalendar.SelectedDays.Max()).ToList();
                lstTimeSheets.SelectedItems.Clear();
                tsCalendar.BoldDays = dba.TimeSheetEntries.Select(s => s.WorkDate).Distinct().ToList();
                lblStatus.Text = "Hours Today: " + dba.TimeSheetEntries.Where(w => w.WorkDate == DateTime.Today).Sum(s => s.Time).ToString();
                lblStatus.Text += "   -   Hours Selected: " + dba.TimeSheetEntries.Where(w => w.WorkDate >= tsCalendar.SelectedDays.Min() && w.WorkDate <= tsCalendar.SelectedDays.Max()).Sum(s => s.Time).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update timesheet list." + Environment.NewLine + ex.Message);
            }
            txtComments.Text = "";
        }

        void UpdateProjects()
        {
            if (dba.UserProjectList.Count > 0)
            {
                DomainTable dt = gListDomains.SelectedItem as DomainTable;

                List<ProjectTable> DisplayList = dba.UserProjectList.ConvertAll<ProjectTable>(new Converter<UserProjects, ProjectTable>(ConvertUserProject));

                if(dt.Name == "Services")
                {
                    gListProjects.DisplayMember = "PName";
                    gListProjects.ValueMember = "ID";
                    gListProjects.DataSource = DisplayList.Where(w => !w.Name.Contains("Admin")).ToList();
                }
                else if(dt.Name != "Admin")
                {
                    gListProjects.DisplayMember = "PName";
                    gListProjects.ValueMember = "ID";
                    gListProjects.DataSource = DisplayList.Where(w => w.Name.Contains("Admin")).ToList();
                }
                else
                {
                    gListProjects.DisplayMember = "PName";
                    gListProjects.ValueMember = "ID";
                    gListProjects.DataSource = DisplayList;
                }


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

                uprform.StartPosition = FormStartPosition.CenterParent;

                //uprform.Top = Top - (Height / 2) - (uprform.Height / 2);

                DialogResult dr = uprform.ShowDialog();

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (UserProjects up in dba.UserProjectList)
                    {
                        if (!uprform.UserProjectList.Contains(up))
                        {
                            dba.DeleteItemFromTable("UserProjects", "ID", up.ID);
                        }
                    }
                    dba.RefreshUserProjects();

                    foreach (UserProjects up in uprform.UserProjectList)
                    {
                        if (!dba.UserProjectList.Select(s => s.ProjectID).Contains(up.ProjectID))
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
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            if (tsCalendar.CurrentDate < new DateTime(2016, 7, 1))
            {
                MessageBox.Show("For timesheet entries older than 1 July 2016, please click on the \"Pre-July 2016\" button below to open the old application.");
            }
            else
            {


                if (tsCalendar.SelectedDays.Count != 1)
                {
                    MessageBox.Show("Please select only one date from the calendar.");
                }
                else
                {
                    DateTime entryDate = tsCalendar.CurrentDate;
                    float entryHours = (float)numericUpDown1.Value;
                    int prID = (gListProjects.SelectedItem as ProjectTable).ID;
                    int domID = (gListDomains.SelectedItem as DomainTable).ID;
                    int funcID = (gListFunctions.SelectedItem as FunctionTable).ID;
                    int? actID = gListActivities.SelectedIndex != -1 ? (gListActivities.SelectedItem as ActivitiesTable).ID : new int?();
                    int? addID = gListAdditional.SelectedIndex != -1 ? (gListAdditional.SelectedItem as AdditionalTable).ID : new int?();
                    int? roleID = gListRole.SelectedIndex != -1 ? (gListRole.SelectedItem as RSTable).ID : new int?();

                    dba.AddTimeSheetEntry(entryDate, entryHours, prID, domID, funcID, actID, addID, roleID, "", txtComments.Text, DateTime.Now.RomoveMiliSeconds());

                    dba.RefreshTimeSheets();

                    UpdateList();
                    txtComments.Text = "";
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstTimeSheets.SelectedIndex != -1)
            {
                TimeSheetEntry tse = lstTimeSheets.SelectedItem as TimeSheetEntry;

                DateTime entryDate = tsCalendar.CurrentDate;
                float entryHours = (float)numericUpDown1.Value;
                int prID = (gListProjects.SelectedItem as ProjectTable).ID;
                int domID = (gListDomains.SelectedItem as DomainTable).ID;
                int funcID = (gListFunctions.SelectedItem as FunctionTable).ID;
                int? actID = gListActivities.SelectedIndex != -1 ? (gListActivities.SelectedItem as ActivitiesTable).ID : new int?();
                int? addID = gListAdditional.SelectedIndex != -1 ? (gListAdditional.SelectedItem as AdditionalTable).ID : new int?();
                int? roleID = gListRole.SelectedIndex != -1 ? (gListRole.SelectedItem as RSTable).ID : new int?();

                object[] editEntry = { entryDate, entryHours, prID, domID, funcID, actID, roleID, "", txtComments.Text, tse.TimeStamp, addID };
                string[] Headers = { "Work Date", "Time", "Project ID", "Domain ID", "Function ID", "Activity ID", "Role ID", "Software Package", "Comments", "Time Stamp", "Additional ID" };

                dba.ModifyItemInTable("TimeSheets", Headers, editEntry, "ID", (lstTimeSheets.SelectedItem as TimeSheetEntry).ID);
                dba.RefreshTimeSheets();

                UpdateList();
            }
            else
            {
                MessageBox.Show("No entry edited, please select an entry to edit.");
            }
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
        #endregion

        private void gListDomains_Click(object sender, EventArgs e)
        {
            if (gListDomains.SelectedIndex != -1)
            {
                string searchString = (gListDomains.SelectedItem as DomainTable).Name;
                if (dba.Descriptions.Select(s => s.Item).Contains(searchString))
                {
                    lblDescription.Text = searchString + ": " + dba.Descriptions.Where(w => w.Item == searchString).First().Description;
                }
                else
                    lblDescription.Text = searchString;
            }
        }

        private void gListFunctions_Click(object sender, EventArgs e)
        {
            if (gListFunctions.SelectedIndex != -1)
            {
                string searchString = (gListFunctions.SelectedItem as FunctionTable).Name;
                if (dba.Descriptions.Select(s => s.Item).Contains(searchString))
                {
                    lblDescription.Text = searchString + ": " + dba.Descriptions.Where(w => w.Item == searchString).First().Description;
                }
                else
                    lblDescription.Text = searchString;
            }
        }

        private void gListRole_Click(object sender, EventArgs e)
        {
            if (gListRole.SelectedIndex != -1)
            {
                string searchString = (gListRole.SelectedItem as RSTable).Name;
                if (dba.Descriptions.Select(s => s.Item).Contains(searchString))
                {
                    lblDescription.Text = searchString + ": " + dba.Descriptions.Where(w => w.Item == searchString).First().Description;
                }
                else
                    lblDescription.Text = searchString;
            }
        }

        private void gListActivities_Click(object sender, EventArgs e)
        {
            if (gListActivities.SelectedIndex != -1)
            {
                string searchString = (gListActivities.SelectedItem as ActivitiesTable).Name;
                if (dba.Descriptions.Select(s => s.Item).Contains(searchString))
                {
                    lblDescription.Text = searchString + ": " + dba.Descriptions.Where(w => w.Item == searchString).First().Description;
                }
                else
                    lblDescription.Text = searchString;
            }
        }

        private void btnSuggestion_Click(object sender, EventArgs e)
        {
            SuggestionBox frmSuggestion = new SuggestionBox();
            frmSuggestion.StartPosition = FormStartPosition.CenterParent;
            DialogResult DR = frmSuggestion.ShowDialog();

            if(DR == System.Windows.Forms.DialogResult.OK)
            {
                string[] headers = { "User", "TimeStamp", "Suggestion" };
                object[] Data = new object[3];

                Data[0] = Environment.UserName;
                Data[1] = DateTime.Now.RomoveMiliSeconds();
                Data[2] = frmSuggestion.Area + " - " + frmSuggestion.Content;
                dba.InsertDataIntoTable("SuggestionTable", headers, Data);
            }
        }

        private void gListAdditional_Click(object sender, EventArgs e)
        {
            if (gListAdditional.SelectedIndex != -1)
            {
                string searchString = (gListAdditional.SelectedItem as AdditionalTable).Name;
                if (dba.Descriptions.Select(s => s.Item).Contains(searchString))
                {
                    lblDescription.Text = searchString + ": " + dba.Descriptions.Where(w => w.Item == searchString).First().Description;
                }
                else
                    lblDescription.Text = searchString;
            }
        }

        private void tsButton1_Click(object sender, EventArgs e)
        {
            //string[] displayEntry = new string[5];

            //displayEntry[0] = DateTime.Today.ToShortDateString();
            //displayEntry[2] = (gListDomains.SelectedItem as DomainTable).Name + " - " + (gListFunctions.SelectedItem as FunctionTable).Name;
            //displayEntry[1] = (gListProjects.SelectedItem as ProjectTable).PName;
            //displayEntry[3] = gListActivities.SelectedIndex != -1 ? (gListActivities.SelectedItem as ActivitiesTable).Name : " - ";
            //displayEntry[3] += " - " + (gListAdditional.SelectedIndex != -1 ? (gListAdditional.SelectedItem as AdditionalTable).Name : "");
            //displayEntry[4] = gListRole.SelectedIndex != -1 ? (gListRole.SelectedItem as RSTable).Name : " - ";


            //AutoTimer frmAutoTime = new AutoTimer(string.Join("   |   ", displayEntry));
            //frmAutoTime.StartPosition = FormStartPosition.CenterParent;

            //frmAutoTime.ShowDialog();

        }

        private void tsButton2_Click(object sender, EventArgs e)
        {
            //Process LegacyProcess = new Process();
            //LegacyProcess.StartInfo.FileName = Application.StartupPath + "/TimeSheets-Legacy.exe"  ;
            //LegacyProcess.Start();
        }

        private void gListProjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainTimesheetForm_Load(object sender, EventArgs e)
        {

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
