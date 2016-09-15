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

            tsCalendar1.CurrentDate = DateTime.Today;
            tsCalendar1.DisplayDate = DateTime.Today;
            tsCalendar1.SelectedDays.Add(tsCalendar1.CurrentDate);
        }

        TSDataBaseAdapter dba;

        List<string> AllData = new List<string>();
        List<UserHours> UserHour = new List<UserHours>();

        void LoadDatabase()
        {
            string SettingsString = Application.StartupPath + "/Config.cfg";

            using (FileStream fs = new FileStream(SettingsString, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string connectionString = sr.ReadLine();
                    dba = new TSDataBaseAdapter(connectionString);
                }
            }
        }

            List<DateTime> Weeks = new List<DateTime>();

        private void tsButton1_Click(object sender, EventArgs e)
        {
            lvUserHours.Columns.Clear();
            lvUserHours.Items.Clear();
            UserHour.Clear();
            Weeks.Clear();

            lvUserHours.Columns.Add("User", 120);
                                  
            Weeks.Add(tsCalendar1.SelectedDays.First().StartOfWeek(DayOfWeek.Monday));

            while ((Weeks.Last() - tsCalendar1.SelectedDays.Last()).Days < -7)
            {
                Weeks.Add(Weeks.Last().AddDays(7));
            }

            foreach(DateTime w in Weeks)
            {
                lvUserHours.Columns.Add(w.ToLongDateString(), 100);
            }

            foreach (UserData user in dba.AllUsers)
            {

                string[] item = new string[lvUserHours.Columns.Count];
                item[0] = user.Name + " " + user.Surname;

                for (int i = 0; i < Weeks.Count; i++)
                {
                    item[i + 1] = dba.TimeSheetEntries.Where(w => w.UserID == user.ID && w.WorkDate >= Weeks[i] && w.WorkDate <= Weeks[i].AddDays(6)).Sum(s => s.Time).ToString();
                }

                ListViewItem lvi = new ListViewItem(item);
                lvUserHours.Items.Add(lvi);
            }
        }

        string EntryToList(TimeSheetEntry te)
        {
            try
            {
                string date = te.WorkDate.ToShortDateString().Replace(",", ";");
                string hour = te.Time.ToString().Replace(",", ";");

                var p = dba.AllProjects.Where(w => te.ProjectID == w.ID);
                string project = (p.Count() > 0 ? p.First().PName : "proj error").Replace(",", ";");

                var d = dba.Domains.Where(w => te.DomainID == w.ID);
                string domain = (d.Count() > 0 ? d.First().Name : "dom error").Replace(",", ";");

                var f = dba.Functions.Where(w => w.ID == te.FunctionID);
                string function = (f.Count() > 0 ? f.First().Name : "func error").Replace(",", ";");

                var a = dba.Activities.Where(w => w.ID == te.ActivityID);
                string activity = (a.Count() > 0 ? a.First().Name : "").Replace(",", ";");

                var ad = dba.AdditionalTables.Where(w => w.ID == te.AdditionalID);
                string add = (ad.Count() > 0 ? ad.First().Name : "").Replace(",", ";");

                var r = dba.Roles.Where(w => w.ID == te.RoleID);
                string role = (r.Count() > 0 ? r.First().Name : "").Replace(",", ";");

                var e = dba.AllUsers.Where(w => w.ID == te.UserID);
                string employee = (e.Count() > 0 ? e.First().LoginID : "empl error").Replace(",", ";");

                string recorded = (te.TimeStamp.ToShortDateString() + " " + te.TimeStamp.ToLongTimeString()).Replace(",", ";");

                string comments = te.Comments.Replace(",", ";");

                string weekstartdate = te.WorkDate.StartOfWeek(DayOfWeek.Monday).ToLongDateString().Replace(",", ";");

                var prt = dba.AllProjects.Where(w => w.ID == te.ProjectID);
                ProjectTable pt = prt.Count() > 0 ? prt.First() : null;

                if(pt != null)
                {
                    var ct = dba.ContractList.Where(w => w.ID == pt.ContractID);
                    string contractType = (ct.Count() > 0 ? ct.First().Name : "con error").Replace(",", ";");

                    var bu = dba.BUList.Where(w => w.ID == pt.BUID);
                    string BU = (bu.Count() > 0 ? bu.First().Name : "BU error").Replace(",", ";");

                    var pm = dba.PaymentList.Where(w => w.ID == pt.PaymentMethod);
                    string PM = (pm.Count() > 0 ? pm.First().Name : "pm error").Replace(",", ";");

                    var cn = dba.CountryList.Where(w => w.ID == pt.CountryID);
                    string Country = (cn.Count() > 0 ? cn.First().Name : "coun error").Replace(",", ";");

                    var se = dba.SectorList.Where(w => w.ID == pt.SectorID);
                    string Sector = (se.Count() > 0 ? se.First().Name : "sect error").Replace(",", ";");

                    var th = dba.ProjectHoursTable.Where(w => w.PID == pt.ID);
                    string targethours = (th.Count() > 0 ? th.First().TargetHours.ToString() : "");
                    string allocatedhours = (th.Count() > 0 ? th.First().AllocatedHours.ToString() : "");

                    return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}", date, hour, project, domain, function, activity, recorded, employee, comments, contractType, BU, PM, Country, Sector, weekstartdate, role, add, targethours, allocatedhours).Replace("\r\n", " ");
                }
                else
                {
                    return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}", date, hour, project, domain, function, activity, recorded, employee, comments, "proj error", "proj error", "proj error", "proj error", "proj error", weekstartdate, role, add, "proj error", "proj error").Replace("\r\n", " ");
                }

            }
            catch
            {

            }
            return "ERROR";
        }

        private void tsButton2_Click(object sender, EventArgs e)
        {
            DialogResult dr = SFD.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                using (FileStream fs = new FileStream(SFD.FileName, FileMode.Create, FileAccess.Write))
                {
                    using(StreamWriter sw = new StreamWriter(fs))
                    {
                        int debugCount = 0;
                        foreach(TimeSheetEntry tse in dba.TimeSheetEntries)
                        {
                            debugCount += 1;
                            if(debugCount == 1131)
                            {
                                MessageBox.Show(tse.ID.ToString());
                                MessageBox.Show(EntryToList(tse));
                            }
                            sw.WriteLine(EntryToList(tse));
                        }
                    }
                }
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
                    return User.Name + " " + User.Surname + "          " + "\t" + Hours.ToString();
                }
            }

        }

        private void frmManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
