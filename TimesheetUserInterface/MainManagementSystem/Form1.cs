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

            foreach(UserData user in dba.AllUsers)
            {
                float time = dba.TimeSheetEntries.Where(w => w.UserID == user.ID && w.WorkDate >= tsCalendar1.SelectedDays.Min() && w.WorkDate <= tsCalendar1.SelectedDays.Max()).Sum(s => s.Time);
                UserHour.Add(new UserHours(user, time));
            }

            gListBox1.DataSource = null;
            gListBox1.DisplayMember = "DisplayString";
            gListBox1.DataSource = UserHour;

            gListBox2.DataSource = null;
            gListBox2.DisplayMember = "Name";
            gListBox2.DataSource = dba.ContractList;

            //EntryToList(dba.TimeSheetEntries[2]);
        }

        void EntryToList(TimeSheetEntry te)
        {
            string date = te.WorkDate.ToShortDateString();
            string hour = te.Time.ToString();
            string project = dba.AllProjects.Where(w => te.ProjectID == w.ID).First().PName;
            string domain = dba.Domains.Where(w => te.DomainID == w.ID).First().Name;
            string function = dba.Functions.Where(w => w.ID == te.FunctionID).First().Name;
            string activity = dba.Activities.Where(w => w.ID == te.ActivityID).First().Name;
            string recorded = te.TimeStamp.ToLongTimeString();
            string employee = dba.AllUsers.Where(w => w.ID == te.UserID).First().LoginID;
            string comments = te.Comments;
            MessageBox.Show(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", date, hour, project, domain, function, activity, recorded, employee, comments));
        }

        private string GetConnectionString()
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            // XLSX - Excel 2007, 2010, 2012, 2013
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = @"\\g5ho-fs02\Public-ENC\Design and Planning\Timesheets\V2\Projects.xlsx";

            // XLS - Excel 2003 and Older
            //props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            //props["Extended Properties"] = "Excel 8.0";
            //props["Data Source"] = "C:\\MyExcel.xls";

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }

        private DataSet ReadExcelFile()
        {
            DataSet ds = new DataSet();

            string connectionString = GetConnectionString();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    foreach (DataRow dr in dtSheet.Rows)
                    {
                        string sheetName = dr["TABLE_NAME"].ToString();

                        cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                        //cmd.Parameters.AddWithValue("TableName", sheetName);

                        DataTable dt = new DataTable();
                        dt.TableName = sheetName.Replace("\'", "").Replace("$", "");

                        try
                        {
                            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                            da.Fill(dt);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        ds.Tables.Add(dt);
                    }

                    cmd = null;
                    conn.Close();
                }
                catch { }
            }
            return ds;
        }

        private void tsButton2_Click(object sender, EventArgs e)
        {
            DataSet ds = ReadExcelFile();
            DataTable dt = ds.Tables["'Reference Table$'"];

            string[] Headers = { "Business Unit ID", "Sector ID", "Country ID", "Contract ID", "Pay Method ID" };
            
            foreach(DataRow dr in dt.Rows)
            {

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
                return User.Name + " " + User.Surname+ "          "  + "\t" + Hours.ToString();
            }
        }

    }
}
