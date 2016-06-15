//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using BaseForm;

//namespace Other
//{
//    public partial class TSButton : BaseControl
//    {

//        private int backColorSwatch = 1;

//        [Category("Appearance")]
//        public Swatch BackColorSwatch
//        {
//            get
//            {
//                return (Swatch)backColorSwatch;
//            }
//            set
//            {
//                backColorSwatch = (int)value;                
//                this.Invalidate();
//                this.Update();
//            }
//        }

//        private int hoverSwatch = 2;

//        [Category("Appearance")]
//        public Swatch HoverSwatch
//        {
//            get
//            {
//                return (Swatch)hoverSwatch;
//            }
//            set
//            {
//                hoverSwatch = (int)value;
//                this.Invalidate();
//                this.Update();
//            }
//        }

//        private int clickSwatch = 3;

//        [Category("Appearance")]
//        public Swatch ClickSwatch
//        {
//            get
//            {
//                return (Swatch)clickSwatch;
//            }
//            set
//            {
//                clickSwatch = (int)value;
//                this.Invalidate();
//                this.Update();
//            }
//        }

//        public TSButton()
//        {
//            this.SetStyle(ControlStyles.StandardDoubleClick, false);

//            InitializeComponent();
//            //this.BackColor = Palette.Palette[backColorSwatch];
//            this.Invalidate();
//            this.Update();
//        }

//        void PaintText(Graphics g)
//        {
//            float length = g.MeasureString(this.Text, Font).Width;
//            float height = g.MeasureString(this.Text, Font).Height;

//            g.DrawString(Text, Font, new SolidBrush(ForeColor), new PointF((this.Width - length) / 2, (this.Height - height) / 2));
//        }

//        protected override void OnPaint(PaintEventArgs e)
//        {
//            base.OnPaint(e);            
//            PaintText(e.Graphics);
//        }

//        protected override void OnMouseEnter(EventArgs e)
//        {
//            base.OnMouseEnter(e);
//            this.BackColor = Palette.Palette[hoverSwatch];
//            this.BorderSwatch = HoverSwatch;
//        }

//        protected override void OnMouseLeave(EventArgs e)
//        {
//            base.OnMouseLeave(e);
//            this.BackColor = Palette.Palette[backColorSwatch];
//            this.BorderSwatch = BackColorSwatch;
//        }

//        protected override void OnMouseDown(MouseEventArgs e)
//        {
//            base.OnMouseDown(e);
//            this.BackColor = Palette.Palette[clickSwatch];
//            this.BorderSwatch = ClickSwatch;
//            this.ForeColor = Palette.Palette[0];
//        }

//        protected override void OnMouseUp(MouseEventArgs e)
//        {
//            base.OnMouseUp(e);
//            this.BackColor = Palette.Palette[hoverSwatch];
//            this.BorderSwatch = HoverSwatch;
//            this.ForeColor = Palette.Palette[3];
//        }

        
//    }
//}
