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
    public class BaseForm : Form
    {

        ColorOperations co = new ColorOperations();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private ColorPalette palette;

        [Category("Appearance"), Browsable(false)]
        public ColorPalette Palette
        {
            get
            {
                return palette;
            }
            set
            {
                palette = value;
                this.Invalidate();
                this.Update();
                foreach (Control c in this.Controls)
                {
                    c.Invalidate();
                    c.Update();
                }
            }
        }

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


        [DefaultValue("DarkBlue")]
        public Color MainColor { get; set; }

        Color accentColor;

        [DefaultValue("Color.FromArgb(163, 213, 255)")]
        public Color AccentColor 
        { 
            get
            {
                return accentColor;
            }
            set
            {
                accentColor = value;
                this.SecondaryColor = co.Tint(AccentColor, 0.618f);
                this.MainColor = co.Shade(AccentColor, (1 - 0.618f));
                this.Invalidate();
                this.Update();
            }
        }

        [DefaultValue("AliceBlue")]
        public Color SecondaryColor { get; set; }

        int titleHeight;

        [DefaultValue(25)]
        public int TitleHeight 
        { 
            get
            {
                return titleHeight;
            }
            set
            {
                titleHeight = value;
                cornerButtonHeight = value - BorderWidth * 2;
                cornerButtonWidth = (int)(1.618 * cornerButtonHeight);
            }
        }

        [DefaultValue(1)]
        public int BorderWidth { get; set; }

        [DefaultValue(0)]
        public int BorderOffset{ get; set; }

        int cornerButtonHeight = 25;
        int cornerButtonWidth = 25;

        Rectangle closeBtn, maxBtn, minBtn;
        bool closeHover = false;
        bool maxHover = false;
        bool minHover = false;

        Color colClose;
        Color colMax;
        Color colMin;

        public BaseForm()
        {
            MainColor = Color.DarkBlue;
            AccentColor = Color.FromArgb(163, 213, 255);
            SecondaryColor = Color.AliceBlue;

            TitleHeight = 25;
            BorderWidth = 1;
            BorderOffset = 1;

            closeBtn = new Rectangle(new Point(this.Width - BorderWidth - cornerButtonWidth, BorderWidth), new Size(cornerButtonWidth, cornerButtonHeight));
            maxBtn = new Rectangle(new Point(closeBtn.X - cornerButtonWidth, BorderWidth), new Size(cornerButtonWidth, cornerButtonHeight));
            minBtn = new Rectangle(new Point(maxBtn.X - cornerButtonWidth, BorderWidth), new Size(cornerButtonWidth, cornerButtonHeight));

            colClose = Color.LightCoral;
            colMax = Color.LightGray;
            colMin = Color.LightGray;

            this.Palette = new ColorPalette();

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MouseDown += fMouseDown;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void fMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            colClose = Color.Silver;
            colMax = Color.Silver;
            colMin = Color.Silver;
            this.Invalidate();//(new Rectangle(minBtn.X, 1, cornerButtonWidth * 3, cornerButtonHeight));
            this.Update();

            if (e.Button == MouseButtons.Left && e.Y <= TitleHeight && e.X <= this.Width - 3 * cornerButtonWidth)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                colClose = Color.LightCoral;
                colMax = Color.LightGray;
                colMin = Color.LightGray;
            }


        }

        protected override void WndProc(ref Message m)
        {
            const UInt32 WM_NCHITTEST = 0x0084;

            const UInt32 HTTOP = 12;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;

            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTBOTTOMRIGHT = 17;

            //const UInt32 HTCLOSE = 8;


            const int RESIZE_HANDLE_SIZE = 6;
            bool handled = false;


            if (m.Msg == WM_NCHITTEST)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);


                Rectangle TopBorder = new Rectangle(RESIZE_HANDLE_SIZE, 0, this.Width - RESIZE_HANDLE_SIZE * 2, RESIZE_HANDLE_SIZE);
                Rectangle BottomBorder = new Rectangle(RESIZE_HANDLE_SIZE, this.Height - RESIZE_HANDLE_SIZE, this.Width - RESIZE_HANDLE_SIZE * 2, RESIZE_HANDLE_SIZE);
                Rectangle LeftBorder = new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, this.Height - RESIZE_HANDLE_SIZE * 2);
                Rectangle RightBorder = new Rectangle(this.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, this.Height - RESIZE_HANDLE_SIZE * 2);

                Rectangle TL = new Rectangle(0, 0, this.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE);
                Rectangle TR = new Rectangle(this.Width - RESIZE_HANDLE_SIZE, 0, this.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE);
                Rectangle BL = new Rectangle(0, this.Height - RESIZE_HANDLE_SIZE, this.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE);
                Rectangle BR = new Rectangle(this.Width - RESIZE_HANDLE_SIZE, this.Height - RESIZE_HANDLE_SIZE, this.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE);

                if (TopBorder.Contains(clientPoint))
                {
                    m.Result = (IntPtr)HTTOP;
                    handled = true;
                }
                else if (BottomBorder.Contains(clientPoint))
                {
                    m.Result = (IntPtr)HTBOTTOM;
                    handled = true;
                }
                else if (LeftBorder.Contains(clientPoint))
                {
                    m.Result = (IntPtr)HTLEFT;
                    handled = true;
                }
                else if (RightBorder.Contains(clientPoint))
                {
                    m.Result = (IntPtr)HTRIGHT;
                    handled = true;
                }

                else if (TL.Contains(clientPoint))
                {
                    m.Result = (IntPtr)HTTOPLEFT;
                    handled = true;
                }
                else if (TR.Contains(clientPoint))
                {
                    m.Result = (IntPtr)HTTOPRIGHT;
                    handled = true;
                }
                else if (BL.Contains(clientPoint))
                {
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                    handled = true;
                }
                else if (BR.Contains(clientPoint))
                {
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                    handled = true;
                }
                //else if (closeBtn.Contains(clientPoint))
                //{
                //    m.Result = (IntPtr)HTCLOSE;
                //    handled = true;
                //}



            }
            if (!handled)
                base.WndProc(ref m);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            PaintBorder(e.Graphics);
            PaintCornerButtons(e.Graphics);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            PaintTitle(e.Graphics);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

                Graphics g = this.CreateGraphics();
                Size tS = g.MeasureString(this.Text, this.Font).ToSize();
                this.Invalidate(new Rectangle(0,0,this.Width,this.titleHeight));
                this.Update();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            closeBtn = new Rectangle(new Point(this.Width - BorderWidth - cornerButtonWidth, BorderWidth), new Size(cornerButtonWidth, cornerButtonHeight));
            maxBtn = new Rectangle(new Point(closeBtn.X - cornerButtonWidth, BorderWidth), new Size(cornerButtonWidth, cornerButtonHeight));
            minBtn = new Rectangle(new Point(maxBtn.X - cornerButtonWidth, BorderWidth), new Size(cornerButtonWidth, cornerButtonHeight));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point mousePoint = new Point(e.X, e.Y);

            Rectangle refreshRect = new Rectangle(this.Width - (cornerButtonWidth * 3)-1, 1, cornerButtonWidth * 3, TitleHeight);

            if(closeBtn.Contains(mousePoint) && !closeHover)
            {
                closeHover = true;
                this.Invalidate(refreshRect);
                this.Update();
            }
            else if(!closeBtn.Contains(mousePoint) && closeHover)
            {
                closeHover = false;
                this.Invalidate(refreshRect);
                this.Update();
            }
            if(maxBtn.Contains(mousePoint) && !maxHover)
            {
                maxHover = true;
                this.Invalidate(refreshRect);
                this.Update();
            }
            else if(!maxBtn.Contains(mousePoint) && maxHover)
            {
                maxHover = false;
                this.Invalidate(refreshRect);
                this.Update();
            }
            if(minBtn.Contains(mousePoint) && !minHover)
            {
                minHover = true;
                this.Invalidate(refreshRect);
                this.Update();
            }
            else if (!minBtn.Contains(mousePoint) && minHover)
            {
                minHover = false;
                this.Invalidate(refreshRect);
                this.Update();
            }



        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            colClose = Color.LightCoral;
            colMax = Color.LightGray;
            colMin = Color.LightGray;
            this.Invalidate();//(new Rectangle(minBtn.X, 1, cornerButtonWidth * 3, cornerButtonHeight));
            this.Update();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (closeHover)
                Application.Exit();
            if (minHover)
                this.WindowState = FormWindowState.Minimized;
        }

        void PaintBorder(Graphics g)
        {

            using (SolidBrush B = new SolidBrush(Palette.Palette[borderSwatch]))
            {
                g.FillRectangle(B, new Rectangle((int)(BorderWidth / 2), (int)(BorderWidth / 2), this.Width - (int)(BorderWidth), TitleHeight + BorderWidth));
            }

            using(Pen P = new Pen (Palette.Palette[borderSwatch],BorderWidth))
            {
                g.DrawRectangle(P, new Rectangle((int)(P.Width / 2), (int)(P.Width / 2), this.Width - (int)(P.Width), this.Height - (int)(P.Width)));
                //g.DrawRectangle(P, new Rectangle((int)(P.Width / 2), (int)(P.Width / 2), this.Width - (int)(P.Width), TitleHeight));

            }
        }

        void PaintTitle(Graphics g)
        {
            float length = g.MeasureString(this.Text, Font).Width;
            float height = g.MeasureString(this.Text, Font).Height;

            g.DrawString(Text, Font, new SolidBrush(Color.White), new PointF((this.Width - length) / 2, (this.TitleHeight - height) / 2 + 2));
        }

        void PaintCornerButtons(Graphics g)
        {
            if (closeHover)
                g.FillRectangle(new SolidBrush(colClose), closeBtn);
            if (maxHover)
                g.FillRectangle(new SolidBrush(colMax), maxBtn);
            if (minHover)
                g.FillRectangle(new SolidBrush(colMin), minBtn);

            using (Pen p = new Pen(Color.White, 1f))
            {
                int centreX = maxBtn.Size.Width / 2 + maxBtn.X;
                int centreY = maxBtn.Size.Height / 2 + maxBtn.Y;

                g.DrawRectangle(p, new Rectangle(centreX - 5, centreY - 5, 10, 10));

                int centre = minBtn.Size.Width / 2 + minBtn.X;
                g.DrawLine(p, centre - 5, minBtn.Bottom - 7, centre + 5, minBtn.Bottom - 7);


                //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                centreX = closeBtn.Size.Width / 2 + closeBtn.X;
                centreY = closeBtn.Size.Height / 2 + closeBtn.Y;
                g.DrawLine(p, centreX - 5, centreY - 5, centreX + 5, centreY + 5);
                g.DrawLine(p, centreX + 5, centreY - 5, centreX - 5, centreY + 5);
            }
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);

        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

    }
}
