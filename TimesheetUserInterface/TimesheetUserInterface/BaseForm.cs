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

        [DefaultValue(25)]
        public int TitleHeight { get; set; }

        [DefaultValue(1)]
        public int BorderWidth { get; set; }

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

        Font tsFont;
        FontLoader fl = new FontLoader();

        public BaseForm()
        {
            MainColor = Color.DarkBlue;
            AccentColor = Color.FromArgb(163, 213, 255);
            SecondaryColor = Color.AliceBlue;

            TitleHeight = 25;
            BorderWidth = 1;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MouseDown += fMouseDown;
        }

        private void fMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Y <= TitleHeight)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PaintBorder(e.Graphics);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            PaintTitle(e.Graphics);
        }
        
        void PaintBorder(Graphics g)
        {
            using(Pen P = new Pen (this.MainColor,BorderWidth))
            {
                g.DrawRectangle(P, new Rectangle((int)(P.Width / 2), (int)(P.Width / 2), this.Width - (int)(P.Width), this.Height - (int)(P.Width)));
                g.DrawRectangle(P, new Rectangle((int)(P.Width / 2), (int)(P.Width / 2), this.Width - (int)(P.Width), TitleHeight));

            }
        }

        void PaintTitle(Graphics g)
        {

            tsFont = fl.LoadCustomFont(FontSize, fStyle);

            float length = g.MeasureString(this.Text, tsFont).Width;
            float height = g.MeasureString(this.Text, tsFont).Height;

            g.DrawString(Text, tsFont, new SolidBrush(MainColor), new PointF((this.Width - length) / 2, (this.TitleHeight - height) / 2+2));
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
