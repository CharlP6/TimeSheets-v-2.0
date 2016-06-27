using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        TSDataBaseAdapter dba;

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
            foreach(TimeSheetEntry tse in dba.TimeSheetEntries)
            {
                gListBox1.Items.Add(tse.UserID.ToString());
            }
        }
    }
}
