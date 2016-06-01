using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSheetsV2_0
{
    public partial class Form1 : Form
    {

        System.Data.OleDb.OleDbConnection TimeSheetConnection = new System.Data.OleDb.OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\MINIPC\Users\Charl\Source\Repos\TimeSheets-v-2.0\Engineering Timesheets.accdb");
        System.Data.OleDb.OleDbCommand TimeSheetCommand = new System.Data.OleDb.OleDbCommand();



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSheetCommand.CommandText = @"SELECT * FROM Activities WHERE Activity = 'Test Activity'";
            TimeSheetCommand.CommandType = CommandType.Text;
            TimeSheetCommand.Connection = TimeSheetConnection;
            
            TimeSheetConnection.Open();

            System.Data.OleDb.OleDbDataReader r = TimeSheetCommand.ExecuteReader();
            TimeSheetConnection.Close();

            MessageBox.Show(r.ToString());
        }


    }
}
