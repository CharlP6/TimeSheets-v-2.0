using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAdapter
{
    public class TSDataBaseAdapter
    {
        string dbConnectionString;

        string UserName = "";

        DataSet TimeSheetDataSet = new DataSet();

        public List<TimeSheetEntry> TimeSheetEntries = new List<TimeSheetEntry>();
        public UserData CurrentUser;
        public List<RSTable> Software = new List<RSTable>();
        public List<RSTable> Roles = new List<RSTable>();
        public List<AdditionalTable> AdditionalTables = new List<AdditionalTable>();
        public List<ActivitiesTable> Activities = new List<ActivitiesTable>();
        public List<FunctionTable> Functions = new List<FunctionTable>();
        public List<DomainTable> Domains = new List<DomainTable>();
        public List<ProjectTable> Projects = new List<ProjectTable>();
        public List<UserProjects> UserProjectList = new List<UserProjects>();

        public List<string[]> TimeSheetData = new List<string[]>();

        public List<ItemDescriptions> Descriptions = new List<ItemDescriptions>();

        public List<UserData> AllUsers = new List<UserData>();
        public List<ProjectTable> AllProjects = new List<ProjectTable>();


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
            LoadAdditionalTable();
            LoadRoles();
            LoadProjects();
            LoadUserProjects();

            RefreshUserProjects();

            LoadDescriptions();

            LoadTimeSheets();
        }

        public TSDataBaseAdapter(string ConnectionString)
        {
            TimeSheetDataSet = new DataSet();

            dbConnectionString = ConnectionString;

            LoadAllUsers();
            LoadDomains();
            LoadFunctions();
            LoadActivities();
            LoadAdditionalTable();
            LoadRoles();
            LoadProjects();
            LoadProjectData();
            LoadAllTimeSheets();
        }

        /// <summary>
        /// A generic method for reading a data table from a database
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="SelectCommand"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        private DataTable LoadDataFromTable(string TableName, string SelectCommand, OleDbParameter[] Parameters)
        {
            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter SelectAdapter = new OleDbDataAdapter(SelectCommand, DBConnection);
                SelectAdapter.SelectCommand.Parameters.AddRange(Parameters);
                DataTable rTable = new DataTable(TableName);
                try
                {
                    DBConnection.Open();
                    SelectAdapter.Fill(rTable);
                    return rTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// A generic method for reading a data table from a database
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="SelectCommand"></param>
        /// <returns></returns>
        private DataTable LoadDataFromTable(string TableName, string SelectCommand)
        {
            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter SelectAdapter = new OleDbDataAdapter(SelectCommand, DBConnection);
                DataTable rTable = new DataTable(TableName);
                try
                {
                    DBConnection.Open();
                    SelectAdapter.Fill(rTable);
                    return rTable;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// A generic method to insert data into a specified table
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="ColumnHeaders"></param>
        /// <param name="Values"></param>
        public void InsertDataIntoTable(string TableName, string[] ColumnHeaders, object[] Values)
        {
            if (ColumnHeaders.Length == Values.Length)
            {
                string Columns = "([" + string.Join("], [", ColumnHeaders) + "])";
                string vals = "(" + string.Join(", ", Values.Select(s => "?").ToArray()) + ")";

                string InsertString = string.Format("INSERT INTO {0} {1} VALUES {2}", TableName, Columns, vals);

                using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
                {
                    OleDbDataAdapter InsertAdapter = new OleDbDataAdapter("SELECT * FROM " + TableName, DBConnection);
                    InsertAdapter.InsertCommand = new OleDbCommand(InsertString, DBConnection);

                    for (int i = 0; i < ColumnHeaders.Length; i++)
                    {
                        if (Values[i] == null)
                            InsertAdapter.InsertCommand.Parameters.AddWithValue("@" + ColumnHeaders[i], DBNull.Value);
                        else
                            InsertAdapter.InsertCommand.Parameters.AddWithValue("@" + ColumnHeaders[i], Values[i]);
                    }

                    DataTable Table = new DataTable(TableName);

                    try
                    {
                        DBConnection.Open();
                        InsertAdapter.Fill(Table);
                        Table.Rows.Add(Table.NewRow());
                        InsertAdapter.Update(Table);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error trying to insert data into" + TableName + Environment.NewLine + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error trying to insert data into" + TableName + ". Column and data count mismatch");
            }
        }

        public void DeleteItemFromTable(string TableName, string IDColumn, object ID)
        {

            string DeleteString = string.Format("DELETE FROM {0} WHERE [{1}] = ?", TableName, IDColumn);

            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter DeleteAdapter = new OleDbDataAdapter("SELECT * FROM " + TableName, DBConnection);
                DeleteAdapter.DeleteCommand = new OleDbCommand(DeleteString, DBConnection);
                DeleteAdapter.DeleteCommand.Parameters.AddWithValue("@did", ID);

                DataTable Table = new DataTable(TableName);

                try
                {
                    DBConnection.Open();
                    DeleteAdapter.DeleteCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void ModifyItemInTable(string TableName, string[] ColumnHeaders, object[] Values, string IDColumn, object ID)
        {
            if (ColumnHeaders.Length == Values.Length)
            {
                string change = "[";

                change += string.Join("] = ?, [", ColumnHeaders) + "] = ?";

                string UpdatetString = string.Format("UPDATE {0} SET {1} WHERE ID = ?", TableName, change);//, IDColumn);

                using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
                {
                    OleDbCommand UpdateCommand = new OleDbCommand(UpdatetString, DBConnection);
                    foreach (object val in Values)
                    {
                        if (val == null)
                            UpdateCommand.Parameters.AddWithValue("@?", DBNull.Value);
                        else
                            UpdateCommand.Parameters.AddWithValue("@?", val);
                    }
                    UpdateCommand.Parameters.AddWithValue("@?", ID);

                    try
                    {
                        DBConnection.Open();
                        UpdateCommand.ExecuteNonQuery();
                        DBConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error trying to update" + TableName + Environment.NewLine + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error trying to update" + TableName + ". Column and data count mismatch");
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
                            Roles.Add(new RSTable((int)DR["Role ID"], (string)DR["Role"], (bool)DR["Bim Role"], (int)DR["Function ID"]));
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

            DataTable DT = LoadDataFromTable("Activities", ActivitiesDataQuery);

            if (DT.Rows.Count > 0)
            {
                foreach (DataRow DR in DT.Rows)
                {
                    if (DR[3] == DBNull.Value)
                    {
                        Activities.Add(new ActivitiesTable((int)DR["Activity ID"], (string)DR["Activity"], (int)DR["Function ID"], "", (bool)DR["BIM Role"]));
                    }
                    else
                    {
                        Activities.Add(new ActivitiesTable((int)DR[0], (string)DR[1], (int)DR[2], (string)DR["Optional Table"], (bool)DR["BIM Role"]));
                    }
                }
            }
        }

        void LoadAdditionalTable()
        {
            AdditionalTables.Clear();
            string ActivitiesDataQuery = "SELECT * FROM AdditionalTables";

            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(ActivitiesDataQuery, DBConnection);
                try
                {
                    DBConnection.Open();
                    UserDataAdapter.Fill(TimeSheetDataSet, "AdditionalTables");
                    if (TimeSheetDataSet.Tables["AdditionalTables"].Rows.Count > 0)
                    {
                        foreach (DataRow DR in TimeSheetDataSet.Tables["AdditionalTables"].Rows)
                        {
                            AdditionalTables.Add(new AdditionalTable((int)DR[0], (string)DR["Addtional Info"], (string)DR["Table Name"]));
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

            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(FunctionDataQuery, DBConnection);
                try
                {
                    DBConnection.Open();
                    UserDataAdapter.Fill(TimeSheetDataSet, "Functions");
                    if (TimeSheetDataSet.Tables["Functions"].Rows.Count > 0)
                    {
                        foreach (DataRow DR in TimeSheetDataSet.Tables["Functions"].Rows)
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

            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
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
                            Projects.Add(new ProjectTable((int)DR["Project ID"], DR["Project Name"] == DBNull.Value ? "" : (string)DR["Project Name"], DR["Project Number"] == DBNull.Value ? "" : (string)DR["Project Number"], (bool)DR["Admin Only"]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    #region UserData
        void GetUserID()
        {
            string Table = "Users";
            string Command = string.Format("SELECT * FROM {0} WHERE [Login ID] = ?", Table);

            OleDbParameter[] parameters = new OleDbParameter[1];
            parameters[0] = new OleDbParameter("?", UserName);

            DataTable UserTable = LoadDataFromTable(Table, Command, parameters);

            if (UserTable.Rows.Count == 1)
            {
                DataRow DR = UserTable.Rows[0];
                userID = (int)DR["User ID"];
                CurrentUser = new UserData { ID = userID, LoginID = (string)DR["Login ID"], Name = (string)DR["User Name"], Surname = (string)DR["Last Name"] };
            }
            else if (UserTable.Rows.Count > 1)
            {
                MessageBox.Show("Error: Duplicate user data found.");
                Application.Exit();
            }
        }

        public void AddUserParameters(string FirstName, string LastName)
        {
            string[] Headers = { "Login ID", "User Name", "Last Name" };
            object[] Values = { Environment.UserName, FirstName, LastName };
            InsertDataIntoTable("Users", Headers, Values);
        }

        void LoadTimeSheets()
        {
            TimeSheetEntries.Clear();

            OleDbParameter[] parameters = { new OleDbParameter("?", UserID) };
            parameters[0].Value = UserID;

            if (userID != -1)
            {
                DataTable DT = LoadDataFromTable("TimeSheets", "SELECT * FROM TimeSheets WHERE [User ID] = ?", parameters);


                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow DR in DT.Rows)
                    {
                        int ID = (int)DR["ID"];
                        int UID = (int)DR["User ID"];
                        DateTime Date = (DateTime)DR["Work Date"];
                        float Time = (float)DR["Time"];
                        int Project = (int)DR["Project ID"];
                        int Domain = (int)DR["Domain ID"];
                        int Function = (int)DR["Function ID"];
                        int Activity = DR["Activity ID"] == DBNull.Value ? -1 : (int)DR["Activity ID"];
                        int Additional = DR["Additional ID"] == DBNull.Value ? -1 : (int)DR["Additional ID"];
                        int Role = DR["Role ID"] == DBNull.Value ? -1 : (int)DR["Role ID"];
                        string Software = DR["Software Package"] == DBNull.Value ? "" : (string)DR["Software Package"];
                        string Comments = DR["Comments"] == DBNull.Value ? "" : (string)DR["Comments"];
                        DateTime TimeStamp = (DateTime)DR["Time Stamp"];
                        TimeSheetEntries.Add(new TimeSheetEntry(
                                    ID,
                                    UID,
                                    Date,
                                    Time,
                                    Project,
                                    Domain,
                                    Function,
                                    Activity,
                                    Additional,
                                    Role,
                                    Software,
                                    Comments,
                                    TimeStamp));
                    }
                }
            }
        }

        public void AddTimeSheetEntry(DateTime date, float hours, int project, int domain, int function, int? activity, int? additional, int? role, string software, string comments, DateTime timestamp)
        {
            string[] Headers = { "User ID", "Work Date", "Time", "Project ID", "Domain ID", "Function ID", "Activity ID", "Additional ID", "Role ID", "Software Package", "Comments", "Time Stamp" };
            object[] Values = { UserID, date, hours, project, domain, function, activity, additional, role, software, comments, timestamp };
            InsertDataIntoTable("TimeSheets", Headers, Values);
        }

        public void RefreshTimeSheets()
        {
            try
            {
                TimeSheetDataSet.Tables["TimeSheets"].Reset();
            }
            catch
            {

            }
            LoadTimeSheets();
        }

        public void RefreshUserProjects()
        {
            try
            {
                if(UserID != -1)
                {
                    if (!UserProjectList.Select(s => s.ProjectID).Contains(156))
                        AddUserProject(156, -1);

                    TimeSheetDataSet.Tables["UserProjects"].Reset();
                }
            }
            catch
            {

            }
            LoadUserProjects();
        }

        void LoadUserProjects()
        {
            UserProjectList.Clear();
            string ProjectDataQuery = "SELECT * FROM UserProjects WHERE [User ID] = ?";

            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter(ProjectDataQuery, DBConnection);
                UserDataAdapter.SelectCommand.Parameters.Add("@uid", OleDbType.Integer).Value = userID;
                try
                {
                    DBConnection.Open();
                    UserDataAdapter.Fill(TimeSheetDataSet, "UserProjects");
                    if (TimeSheetDataSet.Tables["UserProjects"].Rows.Count > 0)
                    {
                        foreach (DataRow DR in TimeSheetDataSet.Tables["UserProjects"].Rows)
                        {
                            int pid = (int)DR["Project ID"];
                            string pn = Projects.Where(w => w.ID == pid).First().PName;
                            UserProjectList.Add(new UserProjects { ID = (int)DR["ID"], ProjectID = pid, RoleID = DR["Role ID"] != DBNull.Value ? (int)DR["Role ID"] : -1, UserID = (int)DR["User ID"], PName = pn });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void AddUserProject(int projectid, int roleid)
        {
            string UserDataInsert = "INSERT INTO UserProjects ([User ID], [Project ID], [Role ID]) VALUES (?, ?, ?)";

            using (OleDbConnection DBConnection = new OleDbConnection(dbConnectionString))
            {
                OleDbDataAdapter UserDataAdapter = new OleDbDataAdapter("SELECT * FROM UserProjects WHERE [User ID] = ?", DBConnection);
                UserDataAdapter.SelectCommand.Parameters.Add("@uid", OleDbType.Integer).Value = userID;

                DataTable Table = new DataTable("UserProjects");
                UserDataAdapter.Fill(Table);

                DataRow row = Table.NewRow();
                Table.Rows.Add(row);

                UserDataAdapter.InsertCommand = new OleDbCommand(UserDataInsert, DBConnection);

                UserDataAdapter.InsertCommand.Parameters.Add("@User ID", OleDbType.Integer).Value = userID;
                UserDataAdapter.InsertCommand.Parameters.Add("@Project ID", OleDbType.Integer).Value = projectid;
                UserDataAdapter.InsertCommand.Parameters.Add("@Role ID", OleDbType.Integer).Value = roleid;

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

        void LoadDescriptions()
        {
            Descriptions.Clear();
            DataTable DT = LoadDataFromTable("Descriptions", "SELECT * FROM Descriptions");
            foreach (DataRow DR in DT.Rows)
            {
                Descriptions.Add(new ItemDescriptions((string)DR["Item"], (string)DR["Description"]));
            }
        }
    #endregion

    #region Management Data

        void LoadAllTimeSheets()
        {
            TimeSheetEntries.Clear();
            DataTable DT = LoadDataFromTable("TimeSheets", "SELECT * FROM TimeSheets");

            if (DT.Rows.Count > 0)
            {
                foreach (DataRow DR in DT.Rows)
                {
                    int ID = (int)DR["ID"];
                    int UID = (int)DR["User ID"];
                    DateTime Date = (DateTime)DR["Work Date"];
                    float Time = (float)DR["Time"];
                    int Project = (int)DR["Project ID"];
                    int Domain = (int)DR["Domain ID"];
                    int Function = (int)DR["Function ID"];
                    int Activity = DR["Activity ID"] == DBNull.Value ? -1 : (int)DR["Activity ID"];
                    int Additional = DR["Additional ID"] == DBNull.Value ? -1 : (int)DR["Additional ID"];
                    int Role = DR["Role ID"] == DBNull.Value ? -1 : (int)DR["Role ID"];
                    string Software = DR["Software Package"] == DBNull.Value ? "" : (string)DR["Software Package"];
                    string Comments = DR["Comments"] == DBNull.Value ? "" : (string)DR["Comments"];
                    DateTime TimeStamp = (DateTime)DR["Time Stamp"];
                    TimeSheetEntries.Add(new TimeSheetEntry(
                                ID,
                                UID,
                                Date,
                                Time,
                                Project,
                                Domain,
                                Function,
                                Activity,
                                Additional,
                                Role,
                                Software,
                                Comments,
                                TimeStamp));
                }
            }

        }

        void LoadAllUsers()
        {
            DataTable DT = LoadDataFromTable("Users", "SELECT * FROM Users");
            foreach(DataRow DR in DT.Rows)
            {
                AllUsers.Add(new UserData { ID = (int)DR["User ID"], LoginID = (string)DR["Login ID"], Name = (string)DR["User Name"], Surname = (string)DR["Last Name"] });
            }
        }

        void LoadProjectData()
        {
            DataTable pt = LoadDataFromTable("Projects", "SELECT * FROM Projects");
            foreach(DataRow dr in pt.Rows)
            {
                int PID = (int)dr["Project ID"];
                string pName = dr["Project Name"] == DBNull.Value ? "" : (string)dr["Project Name"];
                string pNum = dr["Project Number"] == DBNull.Value ? "" : (string)dr["Project Number"];
                bool admin = (bool)dr["Admin Only"];

                int buid = dr["Business Unit ID"] == DBNull.Value ? -1 : (int)dr["Business Unit ID"];
                int sectorID = dr["Sector ID"] == DBNull.Value ? -1 :(int)dr["Sector ID"];
                int countryID = dr["Country ID"] == DBNull.Value ? -1 :(int)dr["Country ID"];
                int contractID = dr["Contract ID"] == DBNull.Value ? -1 :(int)dr["Contract ID"];
                int paymethod = dr["Pay Method ID"] == DBNull.Value ? -1 :(int)dr["Pay Method ID"];

                AllProjects.Add(new ProjectTable(PID, pName, pNum, admin, buid, sectorID, countryID, contractID, paymethod));
            }

        }
    #endregion
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
        public bool BimRole { get; set; }

        public ActivitiesTable(int id, string name, int functionID, string addtable, bool bimrole)
        {
            ID = id;
            Name = name;
            FunctionID = functionID;
            AddTable = addtable;
            BimRole = bimrole;
        }
    }

    public class RSTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool BimRole { get; set; }
        public int FunctionID { get; set; }

        public RSTable(int id, string name, bool bimrole, int functionid)
        {
            ID = id;
            Name = name;
            BimRole = bimrole;
            FunctionID = functionid;
        }
    }

    public class AdditionalTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TableName { get; set; }

        public AdditionalTable(int id, string name, string tablename)
        {
            ID = id;
            Name = name;
            TableName = tablename;
        }
    }

    public class ProjectTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ProjectNumber { get; set; }

        public int BUID, SectorID, ContractID, CountryID, PaymentMethod;

        public string PName
        {
            get
            {
                return (ProjectNumber + " " + Name).Trim();
            }
        }

        public bool AdminOnly { get; set; }

        public ProjectTable(int id, string name, string projectnum, bool adminonly)
        {
            ID = id;
            Name = name;
            ProjectNumber = projectnum;
            AdminOnly = adminonly;
        }

        public ProjectTable(int id, string name, string projectnum, bool adminonly, int buID, int sectorID, int countryID, int contractID, int paymethod)
        {
            ID = id;
            Name = name;
            ProjectNumber = projectnum;
            AdminOnly = adminonly;

            BUID = buID;
            SectorID = sectorID;
            ContractID = contractID;
            CountryID = countryID;
            PaymentMethod = paymethod;
        }


    }

    public class TimeSheetEntry
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime WorkDate { get; set; }
        public float Time { get; set; }
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

        public TimeSheetEntry(int id, int userid, DateTime workdate, float time,
            int projectid, int domainid, int functionid, int activityid, int additionalid,
            int roleid, string softwarepackage, string comments, DateTime timestamp)
        {
            ID = id;
            UserID = userid;
            WorkDate = workdate;
            Time = time;
            ProjectID = projectid;
            DomainID = domainid;
            FunctionID = functionid;
            ActivityID = activityid;
            AdditionalID = additionalid;
            RoleID = roleid;
            SoftwarePackage = softwarepackage;
            Comments = comments;
            TimeStamp = timestamp;
        }
    }

    public class UserData
    {
        public int ID { get; set; }
        public string LoginID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class UserProjects
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public int RoleID { get; set; }
        public string PName { get; set; }
    }

    public class ItemDescriptions
    {
        public string Item { get; set; }
        public string Description { get; set; }

        public ItemDescriptions(string item, string description)
        {
            Item = item;
            Description = description;
        }
    }

}
