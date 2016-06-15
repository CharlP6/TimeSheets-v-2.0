using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseForm;

namespace BaseForm
{
    public class GListBox : ListBox
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

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;                
                cp.Style = cp.Style & ~0x200000;
                return cp;
            }
        }

        public GListBox()
        {
            palette = null;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            this.Invalidate();
            this.Refresh();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            this.Invalidate();
            this.Refresh();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            this.Invalidate();
            this.Refresh();
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            this.Invalidate();
            this.Refresh();
        }

        protected override void OnSelectedValueChanged(EventArgs e)
        {
            base.OnSelectedValueChanged(e);
            this.Invalidate();
            this.Refresh();
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
            Graphics g = e.Graphics;

            //base.OnDrawItem(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            //e.Graphics.Clear(BackColor);
            PaintItems(e.Graphics);
            PaintBorder(e.Graphics);
            //base.OnPaint(e);
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
            int j = 0;
            using (SolidBrush b = new SolidBrush(Palette.Shade2))
            {
                if (SelectedIndex >= 0)
                {
                    try
                    {
                        g.FillRectangle(new SolidBrush(Palette.Tint1), new Rectangle(0, ItemHeight * (SelectedIndex - TopIndex), this.Width, ItemHeight));
                    }
                    catch
                    {

                    }
                }

                IEnumerable<object> objs = Items.Cast<object>();
                try
                {
                    foreach (object item in objs.Skip(TopIndex))
                    {
                        object o = item.GetType().GetProperty(DisplayMember).GetValue(item);
                        string s = o.ToString();

                        int sLen = (int)g.MeasureString(s, this.Font).Width;
                        int f = s.Length;

                        string printString = new string(s.Take(f).ToArray());
                        while (sLen > Width)
                        {
                            sLen = (int)g.MeasureString(printString, Font).Width;
                            printString = new string(s.Take(f).ToArray());
                            f--;
                        }

                        int sHgt = (int)g.MeasureString(s, Font).Height;
                        Point PaintPoint = new Point(2, (j + ItemHeight / 2) - sHgt / 2);

                        g.DrawString(printString, Font, new SolidBrush(Palette.Shade2), PaintPoint);
                        j += ItemHeight;
                    }
                }
                catch
                {

                }

                
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
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ResumeLayout(false);

        }
    }
}
