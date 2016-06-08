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
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DefaultValue("DarkBlue")]
        public Color MainColor { get; set; }

        [DefaultValue("Color.FromArgb(163, 213, 255)")]
        public Color AccentColor { get; set; }

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

        [DefaultValue("Regular")]
        public FontStyle fStyle { get; set; }

        [DefaultValue(12)]
        public float FontSize { get; set; }

        Font tsFont;
        FontLoader fl = new FontLoader();

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
            colMax = AccentColor;
            colMin = AccentColor;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MouseDown += fMouseDown;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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
                colMax = AccentColor;
                colMin = AccentColor;
                this.Invalidate();//(new Rectangle(minBtn.X, 1, cornerButtonWidth * 3, cornerButtonHeight));
                this.Update();
            }


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PaintCornerButtons(e.Graphics);
            PaintBorder(e.Graphics);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            PaintTitle(e.Graphics);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (tsFont != null)
            {
                Graphics g = this.CreateGraphics();
                Size tS = g.MeasureString(this.Text, this.tsFont).ToSize();
                this.Invalidate(new Rectangle(new Point((this.Width - tS.Width) / 2, (this.TitleHeight - tS.Height) / 2 + 2), tS));
                this.Update();
            }

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

            Rectangle refreshRect = new Rectangle(this.Width - (cornerButtonWidth * 3), 1, cornerButtonWidth * 3, TitleHeight);

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
            colMax = AccentColor;
            colMin = AccentColor;
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
            using(Pen P = new Pen (this.MainColor,BorderWidth))
            {
                g.DrawRectangle(P, new Rectangle((int)(P.Width / 2), (int)(P.Width / 2), this.Width - (int)(P.Width), this.Height - (int)(P.Width)));
                //g.DrawRectangle(P, new Rectangle((int)(P.Width / 2), (int)(P.Width / 2), this.Width - (int)(P.Width), TitleHeight));

            }
        }

        void PaintTitle(Graphics g)
        {
            tsFont = fl.LoadCustomFont(FontSize, fStyle);

            float length = g.MeasureString(this.Text, tsFont).Width;
            float height = g.MeasureString(this.Text, tsFont).Height;

            g.DrawString(Text, tsFont, new SolidBrush(MainColor), new PointF((this.Width - length) / 2, (this.TitleHeight - height) / 2+2));
        }

        void PaintCornerButtons(Graphics g)
        {

            tsFont = fl.LoadCustomFont(10, FontStyle.Bold);

            if (closeHover)
                g.FillRectangle(new SolidBrush(colClose), closeBtn);
            if (maxHover)
                g.FillRectangle(new SolidBrush(colMax), maxBtn);
            if (minHover)
                g.FillRectangle(new SolidBrush(colMin), minBtn);

            using (Pen p = new Pen(MainColor, 1))
            {
                int centreX = maxBtn.Size.Width / 2 + maxBtn.X;
                int centreY = maxBtn.Size.Height / 2 + maxBtn.Y;

                g.DrawRectangle(p, new Rectangle(centreX - 5, centreY - 5, 10, 10));

                int centre = minBtn.Size.Width / 2 + minBtn.X;
                g.DrawLine(p, centre - 5, minBtn.Bottom - 7, centre + 5, minBtn.Bottom - 7);


                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
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
