using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseForm;
using DataAdapter;

namespace MainManagementSystem
{
    public partial class frmManagement : BaseForm.BaseForm
    {
        public frmManagement()
        {
            InitializeComponent();
            LoadDatabase();
            //
            tsCalendar1.CurrentDate = DateTime.Today;
            tsCalendar1.SelectedDays.Add(tsCalendar1.CurrentDate);
            //gListBox1.CustomTabOffsets.Clear();
            gListBox1.CustomTabOffsets.Add(100);
            gListBox1.UseTabStops = true;
        }

        TSDataBaseAdapter dba;

        List<string> AllData = new List<string>();
        List<UserHours> UserHour = new List<UserHours>();

        void LoadDatabase()
        {
            string SettingsString = Application.StartupPath + "/Management/Config.cfg";

            using (FileStream fs = new FileStream(SettingsString, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string connectionString = sr.ReadLine();
                    dba = new TSDataBaseAdapter(connectionString);
                }
            }
        }

        private void tsButton1_Click(object sender, EventArgs e)
        {
            UserHour.Clear();

            foreach (UserData user in dba.AllUsers)
            {
                float time = dba.TimeSheetEntries.Where(w => w.UserID == user.ID && w.WorkDate >= tsCalendar1.SelectedDays.Min() && w.WorkDate <= tsCalendar1.SelectedDays.Max()).Sum(s => s.Time);
                UserHour.Add(new UserHours(user, time));
            }

            gListBox1.DataSource = null;
            gListBox1.DisplayMember = "DisplayString";
            gListBox1.DataSource = UserHour;

            //gListBox2.DataSource = null;
            //gListBox2.DisplayMember = "Name";
            //gListBox2.DataSource = dba.ContractList;

            //EntryToList(dba.TimeSheetEntries[100]);
        }

        string EntryToList(TimeSheetEntry te)
        {
            string date = te.WorkDate.ToShortDateString();
            string hour = te.Time.ToString();
            string project = dba.AllProjects.Where(w => te.ProjectID == w.ID).First().PName;
            string domain = dba.Domains.Where(w => te.DomainID == w.ID).First().Name;
            string function = dba.Functions.Where(w => w.ID == te.FunctionID).First().Name;
            string activity = dba.Activities.Where(w => w.ID == te.ActivityID).First().Name;
            string recorded = te.TimeStamp.ToLongDateString();
            string employee = dba.AllUsers.Where(w => w.ID == te.UserID).First().LoginID;
            string comments = te.Comments;

            ProjectTable pt = dba.AllProjects.Where(w => w.ID == te.ProjectID).First();

            string contractType = dba.ContractList.Where(w => w.ID == pt.ContractID).First().Name;
            string BU = dba.BUList.Where(w => w.ID == pt.BUID).First().Name;
            string PM = dba.PaymentList.Where(w => w.ID == pt.PaymentMethod).First().Name;
            string Country = dba.CountryList.Where(w => w.ID == pt.CountryID).First().Name;
            string Sector = dba.SectorList.Where(w => w.ID == pt.SectorID).First().Name;

            string weekstartdate = te.WorkDate.StartOfWeek(DayOfWeek.Monday).ToLongDateString();

            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13} ,{14}", date, hour, project, domain, function, activity, recorded, employee, comments, contractType, BU, PM, Country, Sector, weekstartdate);
        }

        private void tsButton2_Click(object sender, EventArgs e)
        {

        }


    }

    public class UserHours
    {
        public UserData User { get; set; }
        public float Hours { get; set; }

        public UserHours(UserData user, float hours)
        {
            User = user;
            Hours = hours;
        }

        public string DisplayString
        {
            get
            {
                return User.Name + " " + User.Surname+ "          "  + "\t" + Hours.ToString();
            }
        }

    }
}
