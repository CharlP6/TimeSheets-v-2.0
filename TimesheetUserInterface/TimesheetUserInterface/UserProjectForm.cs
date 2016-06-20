using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAdapter;

namespace TimesheetUserInterface
{
    public partial class UserProjectForm : BaseForm.BaseForm
    {
        public List<ProjectTable> AllProjects = new List<ProjectTable>();
        public List<UserProjects> UserProjectList = new List<UserProjects>();

        public UserProjectForm()
        {
            InitializeComponent();

        }

        private void UserProjectForm_Load(object sender, EventArgs e)
        {
            RefreshItems();
        }

        void RefreshItems()
        {
            glAllProjects.DataSource = null;
            glAllProjects.DisplayMember = "PName";
            glAllProjects.DataSource = AllProjects.Where(w => !UserProjectList.Select(s => s.ProjectID).Contains(w.ID)).ToList();

            glUProjects.DataSource = null;
            glUProjects.DisplayMember = "PName";
            glUProjects.DataSource = UserProjectList;
        }

        private void tsButton1_Click(object sender, EventArgs e)
        {
            if(glAllProjects.SelectedIndex != -1)
            {
                ProjectTable pt = glAllProjects.SelectedItem as ProjectTable;
                UserProjectList.Add(new UserProjects { PName = pt.PName, ProjectID = pt.ID, RoleID = -1 });
                RefreshItems();
            }
        }

        private void tsButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void tsButton4_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
