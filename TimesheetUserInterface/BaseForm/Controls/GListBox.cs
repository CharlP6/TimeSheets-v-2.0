using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseForm;
using DataAdapter;

namespace BaseForm
{
    public class GListBox : ListBox
    {
        Rectangle SelectRect = new Rectangle(0, 0, 1, 1);
        int fade = 100;

        System.Timers.Timer FadeTimer = new System.Timers.Timer(10);

        public delegate void GetMousePos();
        public Delegate MouseDelegate;

        public GListBox()
        {
            palette = null;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            MouseDelegate = new GetMousePos(GetMousePosition);
            FadeTimer.Elapsed += new System.Timers.ElapsedEventHandler(FadeTimer_Tick);

            //FadeTimer.Enabled = true;
        }
        
        #region Overrides

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;                
                cp.Style = cp.Style & ~0x200000;
                //cp.ExStyle |= 0x20;
                return cp;
            }
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

            if (SelectedIndex >= 0)
            {
                SelectRect.Y = ItemHeight * (SelectedIndex - TopIndex);
                SelectRect.Width = Width;
                SelectRect.Height = ItemHeight;
            }
            else
                SelectRect = new Rectangle();

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

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            FadeTimer.Enabled = true;
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.Clear(BackColor);
            PaintItems(e.Graphics);
            //PaintBorder(e.Graphics);
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
            int j = 0;
            using (SolidBrush b = new SolidBrush(Palette.Shade2))
            {
                //if (SelectedIndex >= 0)
                //    g.FillRectangle(new SolidBrush(Color.FromArgb(100, Palette.Tint2)), SelectRect);

                IEnumerable<object> objs = Items.Cast<object>();

                Font DrawFont = new Font(Font.FontFamily, Font.Size, Font.Style);

                foreach (object item in objs.Skip(TopIndex))
                {
                    string s = item.GetType().GetProperty(DisplayMember).GetValue(item).ToString();

                    if (j / ItemHeight == SelectedIndex - TopIndex)
                    {
                        DrawFont = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
                        b.Color = Palette.Shade1;
                    }
                    else
                    {
                        DrawFont = new Font(Font.FontFamily, Font.Size, FontStyle.Regular);
                        b.Color = Color.FromArgb(fade, Palette.Shade2);
                    }


                    string printString = s.ReduceLength(Width, Font);
                    int sHgt = (int)g.MeasureString(s, DrawFont).Height;
                    Point PaintPoint = new Point(2, (j + ItemHeight / 2) - sHgt / 2);

                    g.DrawString(printString, DrawFont, b, PaintPoint);

                    j += ItemHeight;
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

        Point mPos = new Point();

        private void GetMousePosition()
        {
            mPos.X = this.Parent.PointToClient(Cursor.Position).X - this.Location.X;
            mPos.Y = this.Parent.PointToClient(Cursor.Position).Y - this.Location.Y;
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            this.Invoke(this.MouseDelegate);

            if (ClientRectangle.Contains(mPos))
                fade = fade + 10 <= 255 ? fade + 10 : 255;
            else
                fade = fade - 10 >= 100 ? fade - 10 : 100;
            if (fade <= 100)
            {
                FadeTimer.Enabled = false;
            }

            this.Invalidate();
            this.Refresh();
        }
    }

    public static class ExtensionMethods
    {
        public static string ReduceLength(this string s, int Width, Font font)
        {
            int sLen = (int)TextRenderer.MeasureText(s, font).Width;

            int f = s.Length;

            string printString = new string(s.Take(f).ToArray());
            if (sLen > Width)
            {
                printString += "...";

                while (sLen > Width)
                {
                    sLen = (int)TextRenderer.MeasureText(printString, font).Width;
                    printString = new string(s.Take(f).ToArray()) + "...";
                    f--;
                }
            }

            return printString;
        }
    }

}
