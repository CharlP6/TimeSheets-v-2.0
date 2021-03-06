﻿using System;
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

        public List<WorkPackage> ProjectHoursTable = new List<WorkPackage>();        

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

            LoadUserData();

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
            LoadAllData();

            LoadAllUsers();
            LoadDomains();
            LoadFunctions();
            LoadActivities();
            LoadAdditionalTable();
            LoadRoles();
            LoadProjectData();
            LoadAllTimeSheets();
        }


    #region Maniplate Data
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

                string UpdatetString = string.Format("UPDATE {0} SET {1} WHERE [{2}] = ?", TableName, change, IDColumn);//, IDColumn);

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
    #endregion

    #region LoadAuxData
        private void LoadAllData()
        {
            TimeSheetDataSet = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(dbConnectionString))
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

                        if (!sheetName.Contains("MSys"))
                        {
                            cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

                            DataTable dt = new DataTable();
                            dt.TableName = sheetName;

                            try
                            {
                                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                                da.Fill(dt);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            TimeSheetDataSet.Tables.Add(dt);
                        }
                    }

                    cmd = null;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadUserData()
        {
            TimeSheetDataSet = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(dbConnectionString))
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
                        if (!sheetName.Contains("MSys"))
                        {
                            if (sheetName == "TimeSheets")
                            {
                                cmd.CommandText = "SELECT * FROM [" + sheetName + "] WHERE [User ID] = ?";
                                cmd.Parameters.AddWithValue("UID", UserID);
                            }
                            else
                            {
                                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                            }

                            DataTable dt = new DataTable();
                            dt.TableName = sheetName;

                            try
                            {
                                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                                da.Fill(dt);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message); }
                            TimeSheetDataSet.Tables.Add(dt);
                        }
                    }

                    cmd = null;
                    conn.Close();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        void LoadActivities()
        {
            Activities.Clear();

            if (TimeSheetDataSet.Tables["Activities"].Rows.Count > 0)
            {
                foreach (DataRow DR in TimeSheetDataSet.Tables["Activities"].Rows)
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

            try
            {
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

        void LoadDomains()
        {
            Domains.Clear();
            try
            {
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

        void LoadFunctions()
        {
            Functions.Clear();

            try
            {
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

        void LoadProjects()
        {
            Projects.Clear();
            try
            {
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

        void LoadRoles()
        {
            Roles.Clear();
            try
            {
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
    #endregion

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

            if (userID != -1)
            {
                OleDbParameter[] param = new OleDbParameter[1];

                param[0] = new OleDbParameter("UID", userID);

                DataTable DT = LoadDataFromTable("TimeSheets","SELECT * FROM TimeSheets WHERE [User ID] = ?", param);

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

            OleDbParameter[] param = new OleDbParameter[1];

            param[0] = new OleDbParameter("UID", userID);

            DataTable DT = LoadDataFromTable("UserProjects", "SELECT * FROM UserProjects WHERE [User ID] = ?", param);

            try
            {
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow DR in DT.Rows)
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
            if (TimeSheetDataSet.Tables["Descriptions"].Rows.Count > 0)
            {
                foreach (DataRow DR in TimeSheetDataSet.Tables["Descriptions"].Rows)
                {
                    Descriptions.Add(new ItemDescriptions((string)DR["Item"], (string)DR["Description"]));
                }
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
            PopulateBUList();
            PopulateHoursTable();

            DataTable pt = TimeSheetDataSet.Tables["Projects"];
            foreach(DataRow dr in pt.Rows)
            {
                AllProjects.Add(new ProjectTable(dr, ProjectHoursTable));
            }
        }

        public List<GenericTable> BUList = new List<GenericTable>();
        public List<GenericTable> ContractList = new List<GenericTable>();
        public List<GenericTable> CountryList = new List<GenericTable>();
        public List<GenericTable> PaymentList = new List<GenericTable>();
        public List<GenericTable> SectorList = new List<GenericTable>();

        void PopulateBUList()
        {
            BUList.Clear();

            DataTable dt = TimeSheetDataSet.Tables["Business Units"];

            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    int id = (int)dr["Business Unit ID"];
                    string name = dr["BU Name"] == DBNull.Value ? "" : (string)dr["BU Name"];
                    BUList.Add(new GenericTable(id, name));
                }

            dt = TimeSheetDataSet.Tables["Contract Types"];
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    int id = (int)dr["Contract ID"];
                    string name = dr["Contract Type"] == DBNull.Value ? "" : (string)dr["Contract Type"];
                    ContractList.Add(new GenericTable(id, name));
                }

            dt = TimeSheetDataSet.Tables["Countries"];
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    int id = (int)dr["Country ID"];
                    string name = dr["Country"] == DBNull.Value ? "" : (string)dr["Country"];
                    CountryList.Add(new GenericTable(id, name));
                }

            dt = TimeSheetDataSet.Tables["Payment Methods"];
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    int id = (int)dr["Pay Method ID"];
                    string name = dr["Payment Method"] == DBNull.Value ? "" : (string)dr["Payment Method"];
                    PaymentList.Add(new GenericTable(id, name));
                }

            dt = TimeSheetDataSet.Tables["Sectors"];
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    int id = (int)dr["Sector ID"];
                    string name = dr["Sector"] == DBNull.Value ? "" : (string)dr["Sector"];
                    SectorList.Add(new GenericTable(id, name));
                }

        }

        void PopulateHoursTable()
        {
            DataTable ht = TimeSheetDataSet.Tables["ProjectHours"];
            foreach(DataRow dr in ht.Rows)
            {
                int id = (int)dr["ID"];
                int PID = (int)dr["Project ID"];
                int alloc = dr["Allocated Hours"] == DBNull.Value ? 0 : (int)dr["Allocated Hours"];
                int target = dr["Target Hours"] == DBNull.Value ? 0 : (int)dr["Target Hours"];
                ProjectHoursTable.Add(new WorkPackage(id, PID, target, alloc));
            }
        }

    #endregion
    }


    public class GenericTable
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public GenericTable(int id, string name)
        {
            ID = id;
            Name = name;
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

        public List<WorkPackage> WorkPackages = new List<WorkPackage>();

        public bool Visible = true;

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

        public ProjectTable(int id, string name, string projectnum, bool adminonly, int buID, int sectorID, int countryID, int contractID, int paymethod, bool visible)
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
            Visible = visible;
        }

        public ProjectTable(DataRow Datarow, List<WorkPackage> workPackages)
        {
            ID = (int)Datarow["Project ID"];
            Name = Datarow["Project Name"] == DBNull.Value ? "" : (string)Datarow["Project Name"];
            ProjectNumber = Datarow["Project Number"] == DBNull.Value ? "" : (string)Datarow["Project Number"];
            AdminOnly = (bool)Datarow["Admin Only"];

            BUID = Datarow["Business Unit ID"] == DBNull.Value ? -1 : (int)Datarow["Business Unit ID"];
            SectorID = Datarow["Sector ID"] == DBNull.Value ? -1 : (int)Datarow["Sector ID"];
            CountryID = Datarow["Country ID"] == DBNull.Value ? -1 : (int)Datarow["Country ID"];
            ContractID = Datarow["Contract ID"] == DBNull.Value ? -1 : (int)Datarow["Contract ID"];
            PaymentMethod = Datarow["Pay Method ID"] == DBNull.Value ? -1 : (int)Datarow["Pay Method ID"];
            Visible = Datarow["Visible"] == DBNull.Value ? true : (bool)Datarow["Visible"];

            WorkPackages = workPackages.Where(w => w.PID == ID).ToList();
        }
    }

    public class WorkPackage
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string Description { get; set; }
        public float TargetHours { get; set; }
        public float AllocatedHours { get; set; }

        public WorkPackage(int id, int pid, float target, float allocated)
        {
            ID = id;
            PID = pid;
            TargetHours = target;
            AllocatedHours = allocated;
        }

        public WorkPackage(DataRow Datarow)
        {
            ID = (int)Datarow["ID"];
            PID = (int)Datarow["Project ID"];
            Description = Datarow["Description"] == DBNull.Value ? "" : (string)Datarow["Description"];
            int alloc = Datarow["Allocated Hours"] == DBNull.Value ? 0 : (int)Datarow["Allocated Hours"];
            int target = Datarow["Target Hours"] == DBNull.Value ? 0 : (int)Datarow["Target Hours"];
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
        public int WorkPackageID { get; set; }

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
