using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TimesheetUserInterface
{
    class GListBox : ListBox
    {
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

        public GListBox()
        {
            palette = null;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.Invalidate();
            this.Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.Invalidate();
            this.Update();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Invalidate();
                this.Update();
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            
            base.OnDrawItem(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            PaintBorder(e.Graphics);
            base.OnPaint(e);
        }        

        void PaintBorder(Graphics g)
        {
            using (Pen P = new Pen(Palette.Palette[borderSwatch], 1))
            {
                g.DrawRectangle(P, new Rectangle((int)(P.Width / 2), (int)(P.Width / 2), this.Width - (int)(P.Width), this.Height - (int)(P.Width)));
            }
        }

        void PaintItems(Graphics g)
        {
            Font StringFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Regular);

            foreach(object item in Items)
            {

            }
        }
        
        #region Pallete

        private ColorPalette palette;

        public ColorPalette Palette
        {
            get
            {
                if(ParentHasPalette() && palette == null)
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GListBox
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResumeLayout(false);

        }
    }
}
