using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseForm
{
    public partial class TSScrollBar : VScrollBar
    {
        public TSScrollBar()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.UserMouse, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 19;
            LineLength = Height - (2 * Width);
        }

        #region Overrides

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = 19;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            UpHover = false;
            DownHover = false;
            base.OnMouseLeave(e);            
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (UpRect.Contains(e.Location))
            {
                UpHover = true;
                DownHover = false;
                this.Invalidate();
                this.Refresh();
            }
            else if (DownRect.Contains(e.Location))
            {
                UpHover = false;
                DownHover = true;
                this.Invalidate();
                this.Refresh();
            }
            else
            {
                UpHover = false;
                DownHover = false;
                this.Invalidate();
                this.Refresh();
            }

            base.OnMouseMove(e);
        }
        #endregion

        int LineLength = 0;

        bool UpHover = false;
        bool DownHover = false;

        Rectangle UpRect = new Rectangle();
        Rectangle DownRect = new Rectangle();

        void PaintButtons(Graphics g)
        {
            UpRect = new Rectangle(0, 0, Width - 1, Width - 1);
            DownRect = new Rectangle(0, Height - Width, Width - 1, Width - 1);

            if (UpHover)
            {
                g.FillRectangle(new SolidBrush(Palette.Primary), UpRect);
            }
            else if (DownHover)
            {
                g.FillRectangle(new SolidBrush(Palette.Primary), DownRect);
            }

            g.DrawRectangle(new Pen(Palette.Palette[borderSwatch], 1), UpRect);
            g.DrawRectangle(new Pen(Palette.Palette[borderSwatch], 1), DownRect);

        }

        void PaintBorder(Graphics g)
        {
            g.DrawLine(new Pen(Palette.Tint1, 1), Width / 2, Width, Width / 2, Height - Width);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PaintBorder(e.Graphics);
            PaintButtons(e.Graphics);
            base.OnPaint(e);
        }

        #region Pallete

        private ColorPalette palette;

        public ColorPalette Palette
        {
            get
            {
                if (ParentHasPalette() && palette == null)
                {
                    return GetParentPalette();
                }
                return palette;
            }
            set
            {
                palette = value;
                this.Invalidate();
                this.Update();
            }
        }

        private bool ParentHasPalette()
        {
            return this.FindForm() != null && this.FindForm().GetType().GetProperty("Palette") != null;
        }

        private ColorPalette GetParentPalette()
        {
            if (ParentHasPalette())
                return (ColorPalette)this.FindForm().GetType().GetProperty("Palette").GetValue(this.FindForm());
            else
                return new ColorPalette();
        }

        private bool ShouldSerializePalette()
        {
            return this.Palette != GetParentPalette();
        }

        private void ResetPalette()
        {
            this.Palette = GetParentPalette();
        }

        #endregion

        private int borderSwatch = 1;
        [Category("Appearance")]
        public Swatch BorderSwatch
        {
            get
            {
                return (Swatch)borderSwatch;
            }
            set
            {
                borderSwatch = (int)value;
                this.Invalidate();
                this.Update();
            }
        }

    }
}
