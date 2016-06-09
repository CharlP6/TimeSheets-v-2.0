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
        Font tsFont;
        FontLoader fl = new FontLoader();


        [DefaultValue("Regular")]
        public FontStyle fStyle
        {
            get;
            set;
        }

        [DefaultValue(12)]
        public float FontSize
        {
            get;
            set;
        }

        public TSButton()
        {
            this.SetStyle(ControlStyles.StandardDoubleClick, false);
            InitializeComponent();
            fStyle = FontStyle.Regular;
            FontSize = 12;
        }

        void PaintText(Graphics g)
        {
            tsFont = fl.LoadCustomFont(FontSize, fStyle);

            float length = g.MeasureString(this.Text, Font).Width;
            float height = g.MeasureString(this.Text, Font).Height;

            g.DrawString(Text, Font, new SolidBrush(MainColor), new PointF((this.Width - length) / 2, (this.Height - height) / 2));
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
