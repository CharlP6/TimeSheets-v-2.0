using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSheetsV2_0
{
    public partial class Form1 : Form
    {


        string dbConnectionString = @"provider=Microsoft.ACE.OLEDB.12.0; Data Source=\\g5ho-fs02\Public-ENC\Design and Planning\Timesheets\V2\ProtoDB.accdb ";
        OleDbConnection TimeSheetConnection;

        DataSet TimeSheetDataSet = new DataSet();
        OleDbDataAdapter TimesheetDataAdapter;

        void ConnectToDatabase(string ConnectionString)
        {
            try
            {
                TimeSheetConnection = new OleDbConnection(ConnectionString);
            }
            catch
            {
                MessageBox.Show("Failed to connect to the database, please make sure you have access to the stored folder.");
            }

            try
            {
                string DataCommandString = "SELECT * FROM DataCapture WHERE User='" +Environment.UserName+"'";
                OleDbCommand TimesheetCommand = new OleDbCommand(DataCommandString, TimeSheetConnection);

                TimesheetDataAdapter = new OleDbDataAdapter(TimesheetCommand);
                TimesheetDataAdapter.SelectCommand = TimesheetCommand;
                TimeSheetDataSet = new DataSet();
                TimeSheetConnection.Open();

                TimesheetDataAdapter.Fill(TimeSheetDataSet, "DataCapture");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve data from database." + Environment.NewLine + ex.Message);
            }
            finally
            {
                TimeSheetConnection.Close();
            }            
        }


        public Form1()
        {
            InitializeComponent();
            ConnectToDatabase(dbConnectionString);
        }
        




        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            DataTable TimesheetData = TimeSheetDataSet.Tables["DataCapture"];

            string strColumns = "";

            List<string> TsData = new List<string>();

            foreach(DataColumn dc in TimesheetData.Columns)
            {
                strColumns += dc.ColumnName + "\t";
            }

            foreach(DataRow dr in TimesheetData.Rows)
            {
                string strRow = "";
                for(int i = 0; i < TimesheetData.Columns.Count; i++)
                {
                    strRow += dr[i] + "\t";
                }

                TsData.Add(strRow);
            }

            listBox1.Items.Add(strColumns);
            listBox1.Items.AddRange(TsData.ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //TimeSheetConnection = new OleDbConnection(dbConnectionString);
                TimeSheetConnection.Open();

                OleDbCommand UpdateComm = TimeSheetConnection.CreateCommand();

                UpdateComm.Parameters.AddWithValue("@User","svaneck");

                UpdateComm.CommandText = @"UPDATE DataCapture SET [User]=@User WHERE ID=2";
                UpdateComm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update the record" + Environment.NewLine + ex.Message);
            }
            finally
            {
                TimeSheetConnection.Close();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            Random r = new Random();

            try
            {
                TimeSheetConnection.Open();

                OleDbCommand CommandString = TimeSheetConnection.CreateCommand();

                CommandString.Parameters.Add("@User", OleDbType.VarChar).Value = Environment.UserName;
                CommandString.Parameters.Add("@Date", OleDbType.Date).Value = monthCalendar1.SelectionStart.ToShortDateString();
                CommandString.Parameters.Add("@Time", OleDbType.Date).Value = DateTime.Now.ToShortTimeString();
                CommandString.Parameters.Add("@Hours", OleDbType.Single).Value = (float)r.NextDouble()*2;

                CommandString.CommandText = @"INSERT INTO DataCapture ([User],[Date],[Time],[Hours]) VALUES (@User, @Date, @Time, @Hours)";

                CommandString.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update the record." + Environment.NewLine + ex.Message);
            }
            finally
            {
                TimeSheetConnection.Close();
            }
        }


    }
}
