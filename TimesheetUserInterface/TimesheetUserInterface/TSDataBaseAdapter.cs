using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimesheetUserInterface
{
    class TSDataBaseAdapter
    {
        string dbConnectionString; // = @"provider=Microsoft.ACE.OLEDB.12.0; Data Source=\\g5ho-fs02\Public-ENC\Design and Planning\Timesheets\V2\ProtoDB.accdb ";
        OleDbConnection TimeSheetConnection;

        string UserName = "";

        DataSet TimeSheetDataSet = new DataSet();

        public List<string[]> UserData = new List<string[]>();

        public List<RolesTable> Roles = new List<RolesTable>();
        public List<ActivitiesTable> Activities = new List<ActivitiesTable>();
        public List<FunctionTable> Functions = new List<FunctionTable>();
        public List<DomainTable> Domains = new List<DomainTable>();        
        public List<ProjectTable> Projects = new List<ProjectTable>();

        public List<string[]> TimeSheetData = new List<string[]>();

        private int userID = -1;

        public int UserID
        {
            get
            {
                return userID;
            }
        }

        public TSDataBaseAdapter(string ConnectionString, string userName)
        {
            dbConnectionString = ConnectionString;
            UserName = userName;
            GetUserID();
            LoadDomains();
            LoadFunctions();
            LoadActivities();
            LoadProjects();
            LoadTimeSheets();
        }

        void GetUserID()
        {
            string UserDataQuery = "SELECT * FROM Users WHERE 'Login ID=@Login ID'";

            using(OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(UserDataQuery, DBConnection);

                UserDataAdapter.SelectCommand.Parameters.Add("@Login ID", OleDbType.VarChar).Value = Environment.UserName;
                try
                {
                    DBConnection.Open();
                    UserDataAdapter.Fill(TimeSheetDataSet, "Users");
                    if(TimeSheetDataSet.Tables["Users"].Rows.Count > 0)
                    {
                        userID = (int)TimeSheetDataSet.Tables["Users"].Rows[0][0];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void LoadTimeSheets()
        {
            TimeSheetData.Clear();
            if(userID != -1)
            {

                string TSDataQuery = "SELECT * FROM TimeSheets";

                using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
                {
                    OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(TSDataQuery, DBConnection);
                    try
                    {
                        DBConnection.Open();
                        UserDataAdapter.Fill(TimeSheetDataSet, "TimeSheets");
                        if (TimeSheetDataSet.Tables["TimeSheets"].Rows.Count > 0)
                        {
                            foreach (DataRow DR in TimeSheetDataSet.Tables["TimeSheets"].Rows)
                            {
                                string ID = ((int)DR["ID"]).ToString();
                                string Date = ((DateTime)DR["Work Date"]).ToShortDateString(); ;
                                string Time = ((float)DR["Time"]).ToString();
                                string Project = Projects.Where(w => w.ID == (int)DR["Project ID"]).Select(s => s.Name).First();
                                string Domain = Domains.Where(w => w.ID == (int)DR["Domain ID"]).Select(s => s.Name).First();
                                string Function = Functions.Where(w => w.ID == (int)DR["Function ID"]).Select(s => s.Name).First();
                                string Activity = Activities.Where(w => w.ID == (int)DR["Activity ID"]).Select(s => s.Name).First();
                                string Role = "rrr"; // = Activities.Where(w => w.ID == (int)DR[7]).Select(s => s.Name).First();
                                string Comments = "ccc"; // = Activities.Where(w => w.ID == (int)DR[7]).Select(s => s.Name).First();

                                string[] output = { Date, Time, Project, Domain, Function, Activity, Role, Comments, ID };

                                TimeSheetData.Add(output);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        void LoadActivities()
        {
            Activities.Clear();

            string ActivitiesDataQuery = "SELECT * FROM Activities";

            using(OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(ActivitiesDataQuery, DBConnection);
                try
                {
                    DBConnection.Open();
                    UserDataAdapter.Fill(TimeSheetDataSet, "Activities");
                    if (TimeSheetDataSet.Tables["Activities"].Rows.Count > 0)
                    {
                        foreach (DataRow DR in TimeSheetDataSet.Tables["Activities"].Rows)
                        {
                            if (DR[3] ==  DBNull.Value)
                            {
                                Activities.Add(new ActivitiesTable((int)DR[0], (string)DR[1], (int)DR[2], ""));

                            }
                            else
                            {
                                Activities.Add(new ActivitiesTable((int)DR[0], (string)DR[1], (int)DR[2], (string)DR[3]));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void LoadFunctions()
        {
            Functions.Clear();

            string FunctionDataQuery = "SELECT * FROM Functions";

            using(OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(FunctionDataQuery, DBConnection);
                try
                {
                    DBConnection.Open();
                    UserDataAdapter.Fill(TimeSheetDataSet, "Functions");
                    if (TimeSheetDataSet.Tables["Functions"].Rows.Count > 0)
                    {
                        foreach(DataRow DR in TimeSheetDataSet.Tables["Functions"].Rows)
                        {
                            Functions.Add(new FunctionTable((int)DR[0], (string)DR[1], (int)DR[2]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void LoadDomains()
        {
            Domains.Clear();
            string DomainDataQuery = "SELECT * FROM Domains";

            using(OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(DomainDataQuery, DBConnection);
                try
                {
                    DBConnection.Open();
                    UserDataAdapter.Fill(TimeSheetDataSet, "Domains");
                    if (TimeSheetDataSet.Tables["Domains"].Rows.Count > 0)
                    {
                        foreach (DataRow DR in TimeSheetDataSet.Tables["Domains"].Rows)
                        {
                            Domains.Add(new DomainTable((int)DR[0], (string)DR[1]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void LoadProjects()
        {
            Projects.Clear();
            string ProjectDataQuery = "SELECT * FROM Projects";

            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(ProjectDataQuery, DBConnection);
                try
                {
                    DBConnection.Open();
                    UserDataAdapter.Fill(TimeSheetDataSet, "Projects");
                    if (TimeSheetDataSet.Tables["Projects"].Rows.Count > 0)
                    {
                        foreach (DataRow DR in TimeSheetDataSet.Tables["Projects"].Rows)
                        {
                            Projects.Add(new ProjectTable((int)DR[0], (string)DR[1], (string)DR[2]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void AddUserParameters(string FirstName, string LastName)
        {
            string UserDataInsert = "INSERT INTO Users ([Login ID], [User Name], [Last Name]) VALUES (?, ?, ?)";
            
            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter("SELECT * FROM Users", DBConnection);

                DataTable Table = new DataTable("Users");
                UserDataAdapter.Fill(Table);

                DataRow row = Table.NewRow();
                Table.Rows.Add(row);

                UserDataAdapter.InsertCommand = new OleDbCommand(UserDataInsert, DBConnection);

                UserDataAdapter.InsertCommand.Parameters.Add("@Login ID", OleDbType.VarChar).Value = Environment.UserName;
                UserDataAdapter.InsertCommand.Parameters.Add("@User Name", OleDbType.VarChar).Value = FirstName;
                UserDataAdapter.InsertCommand.Parameters.Add("@Last Name", OleDbType.VarChar).Value = LastName;

                try
                {
                    DBConnection.Open();
                    UserDataAdapter.Update(Table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }


    public class DomainTable
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public DomainTable(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }

    public class FunctionTable
    {
        public int ID;
        public string Name;
        public int DomainID;

        public FunctionTable(int id, string name, int domainid)
        {
            ID = id;
            Name = name;
            DomainID = domainid;
        }
    }

    public class ActivitiesTable
    {
        public int ID;
        public string Name;
        public int FunctionID;
        public string AddTable;

        public ActivitiesTable(int id, string name, int functionID, string addtable)
        {
            ID = id;
            Name = name;
            FunctionID = functionID;
            AddTable = addtable;
        }        
    }

    public class RolesTable
    {
        public int ID;
        public string Name;

        public RolesTable(int id, string name)
        {
            ID = id;
            Name = name;
        }        
    }

    public class ProjectTable
    {
        public int ID;
        public string Name;
        public string ProjectNumber;
      
        public ProjectTable(int id, string name, string projectnum)
        {
            ID = id;
            Name = name;
            ProjectNumber = projectnum;
        }
    }
       

}
