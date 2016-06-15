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
        string dbConnectionString;

        string UserName = "";

        DataSet TimeSheetDataSet = new DataSet();

        public List<string[]> UserData = new List<string[]>();
        public List<RSTable> Software = new List<RSTable>();
        public List<RSTable> Roles = new List<RSTable>();
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
            TimeSheetDataSet = new DataSet();
            dbConnectionString = ConnectionString;
            UserName = userName;
            GetUserID();
            LoadDomains();
            LoadFunctions();
            LoadActivities();
            LoadRoles();
            LoadSoftware();
            LoadProjects();
            LoadTimeSheets();
        }

        void GetUserID()
        {
            string UserDataQuery = "SELECT * FROM Users WHERE [Login ID] = ?";

            using(OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(UserDataQuery, DBConnection);

                UserDataAdapter.SelectCommand.Parameters.Add("?", OleDbType.VarChar).Value = UserName;
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

        public void AddTimeSheetEntry(DateTime date, float hours,int project, int domain, int function, int activity, int role, string software, string comments, DateTime timestamp)
        {
            string insertString = "INSERT INTO TimeSheets ([User ID], [Work Date], [Time], [Project ID], [Domain ID], [Function ID], [Activity ID], [Role ID], [Software Package], [Comments], [Time Stamp]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter TSAdapter = new OleDbDataAdapter("SELECT * FROM TimeSheets WHERE [User ID] = ?", DBConnection);
                TSAdapter.SelectCommand.Parameters.Add("@UserID", OleDbType.Integer).Value = userID;
                try
                {
                    DataTable Table = new DataTable("TimeSheets");
                    TSAdapter.Fill(Table);

                    DataRow row = Table.NewRow();
                    Table.Rows.Add(row);

                    TSAdapter.InsertCommand = new OleDbCommand(insertString, DBConnection);

                    TSAdapter.InsertCommand.Parameters.Add("@uid", OleDbType.Integer).Value = UserID;
                    TSAdapter.InsertCommand.Parameters.Add("@wdate", OleDbType.Date).Value = date;
                    TSAdapter.InsertCommand.Parameters.Add("@time", OleDbType.Single).Value = hours;
                    TSAdapter.InsertCommand.Parameters.Add("@prj", OleDbType.Single).Value = project;
                    TSAdapter.InsertCommand.Parameters.Add("@domain", OleDbType.Integer).Value = domain;
                    TSAdapter.InsertCommand.Parameters.Add("@fun", OleDbType.Integer).Value = function;
                    TSAdapter.InsertCommand.Parameters.Add("@act", OleDbType.Integer).Value = activity;
                    TSAdapter.InsertCommand.Parameters.Add("@role", OleDbType.Integer).Value = role;
                    TSAdapter.InsertCommand.Parameters.Add("@soft", OleDbType.VarChar).Value = software;
                    TSAdapter.InsertCommand.Parameters.Add("@comm", OleDbType.VarChar).Value = comments;
                    TSAdapter.InsertCommand.Parameters.Add("@ts", OleDbType.Date).Value = timestamp;

                    try
                    {
                        DBConnection.Open();
                        TSAdapter.Update(Table);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                catch
                {

                }


            }          
        
        }

        public void RefreshTimeSheets()
        {
            TimeSheetDataSet.Tables["TimeSheets"].Clear();
            LoadTimeSheets();
        }

        void LoadTimeSheets()
        {
            TimeSheetData.Clear();
            
            if(userID != -1)
            {

                string TSDataQuery = "SELECT * FROM TimeSheets WHERE [User ID] = ?";

                using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
                {
                    OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(TSDataQuery, DBConnection);
                    
                    UserDataAdapter.SelectCommand.Parameters.Add("@UserID", OleDbType.Integer).Value = userID;
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
                                string Role = DR["Role ID"] == DBNull.Value ? "" : Roles.Where(w => w.ID == (int)DR["Role ID"]).Select(s => s.Name).First();
                                string Comments = DR["Comments"] == DBNull.Value ? "" : (string)DR["Comments"];

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

        void LoadSoftware()
        {
            Software.Clear();

            string RolesDataQuery = "SELECT * FROM Roles";

            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(RolesDataQuery, DBConnection);
                try
                {
                    DBConnection.Open();
                    UserDataAdapter.Fill(TimeSheetDataSet, "Software");
                    if (TimeSheetDataSet.Tables["Software"].Rows.Count > 0)
                    {
                        foreach (DataRow DR in TimeSheetDataSet.Tables["Software"].Rows)
                        {
                            Software.Add(new RSTable((int)DR[0], (string)DR[1]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void LoadRoles()
        {
            Roles.Clear();

            string RolesDataQuery = "SELECT * FROM Roles";

            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(RolesDataQuery, DBConnection);
                try
                {
                    DBConnection.Open();
                    UserDataAdapter.Fill(TimeSheetDataSet, "Roles");
                    if (TimeSheetDataSet.Tables["Roles"].Rows.Count > 0)
                    {
                        foreach (DataRow DR in TimeSheetDataSet.Tables["Roles"].Rows)
                        {
                                Roles.Add(new RSTable((int)DR[0], (string)DR[1]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
        public int ID { get; set; }
        public string Name { get; set; }
        public int DomainID { get; set; }

        public FunctionTable(int id, string name, int domainid)
        {
            ID = id;
            Name = name;
            DomainID = domainid;
        }
    }

    public class ActivitiesTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int FunctionID { get; set; }
        public string AddTable { get; set; }

        public ActivitiesTable(int id, string name, int functionID, string addtable)
        {
            ID = id;
            Name = name;
            FunctionID = functionID;
            AddTable = addtable;
        }        
    }

    public class RSTable
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public RSTable(int id, string name)
        {
            ID = id;
            Name = name;
        }        
    }

    public class ProjectTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ProjectNumber { get; set; }
        public string PName
        {
            get
            {
                return ProjectNumber + " " + Name;
            }
        }
      
        public ProjectTable(int id, string name, string projectnum)
        {
            ID = id;
            Name = name;
            ProjectNumber = projectnum;
        }
    }

    public class TimeSheetEntry
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime WorkDate { get; set; }
        public DateTime Time { get; set; }
        public int ProjectID { get; set; }
        public int DomainID { get; set; }
        public int FunctionID { get; set; }
        public int ActivityID { get; set; }
        public int AdditionalID { get; set; }
        public int RoleID { get; set; }
        public string SoftwarePackage { get; set; }
        public string Comments { get; set; }
        public DateTime TimeStamp { get; set; }

        public TimeSheetEntry()
        {

        }



    }
       

}
