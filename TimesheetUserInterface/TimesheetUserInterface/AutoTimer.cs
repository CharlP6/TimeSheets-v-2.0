﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimesheetUserInterface
{
    public partial class AutoTimer : BaseForm.BaseForm
    {

        public AutoTimer(string DisplayHours)
        {
            InitializeComponent();
            label2.Text = DisplayHours;
        }

        private void tsButton1_Click(object sender, EventArgs e)
        {

        }

        private void AutoTimer_Load(object sender, EventArgs e)
        {

        }
    }
}
