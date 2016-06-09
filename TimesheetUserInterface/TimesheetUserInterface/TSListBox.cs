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
            using (SolidBrush brush = new SolidBrush(co.Tint(this.SecondaryColor,0.618f)))
            {
                for (int i = 0; i <= DisplayedItems; i += 2)
                {
                    g.FillRectangle(brush, new Rectangle(1, i * ItemHeight+1, this.Width-2, ItemHeight));
                }
            }
        }
    }
}
