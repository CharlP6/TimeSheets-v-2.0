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
        AppSettingsReader ASR;// = new AppSettingsReader();

        string dbConnectionString;

        static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings.AllKeys.ToString();
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                return "";
            }
        }

        public Form1()
        {
            InitializeComponent();

        }
        


        OleDbConnection TimeSheetConnection;

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dbConnectionString = ReadSetting("Database Path");
            MessageBox.Show(dbConnectionString);
        }


    }
}
