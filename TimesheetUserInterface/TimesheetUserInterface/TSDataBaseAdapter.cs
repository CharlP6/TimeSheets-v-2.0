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


        public List<FunctionTable> Functions = new List<FunctionTable>();
        public List<DomainTable> Domains = new List<DomainTable>();
        
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
        public int ID;
        public string Name;

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

}
