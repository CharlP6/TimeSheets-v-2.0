using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimesheetUserInterface
{
    public partial class TSButton : BaseControl
    {
        public TSButton()
        {
            this.SetStyle(ControlStyles.StandardDoubleClick, false);
            InitializeComponent();            
        }



        
        void PaintText(Graphics g)
        {
            //using (Pen P = new Pen(MainColor,1))
            //{
                g.DrawString(Text, DefaultFont, new SolidBrush(MainColor), new PointF(5, 5));
            //}
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PaintText(e.Graphics);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = AccentColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = default(Color);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.BackColor = SecondaryColor;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.BackColor = AccentColor;
        }
    }
}
