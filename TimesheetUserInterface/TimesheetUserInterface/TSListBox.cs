using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TimesheetUserInterface
{
    class TSListBox : BaseControl
    {

        ColorOperations co = new ColorOperations();

        public List<string[]> Items = new List<string[]>();

        public string[] Columns
        {
            get;
            set;
        }

        private int DisplayedItems;

        public int ItemHeight { get; set; }

        public TSListBox()
        {
            ItemHeight = this.Font.Height + 2;
            DisplayedItems = (this.Height / ItemHeight) + 1;            
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            PaintLines(e.Graphics);
            base.OnPaint(e);

        }

        void PaintLines(Graphics g)
        {
            ItemHeight = this.Font.Height + 2;
            DisplayedItems = (this.Height / ItemHeight) + 1;
            using (Pen brush = new Pen(co.Tint(this.SecondaryColor, 0.3f), 1))
            {
                float[] dash = { 1, 1 };
                brush.DashPattern = dash;
                for (int i = 1; i <= DisplayedItems; i += 1)
                {
                    g.DrawLine(brush, 0, i * ItemHeight, this.Width, i * ItemHeight);
                }
            }
        }
    }
}
