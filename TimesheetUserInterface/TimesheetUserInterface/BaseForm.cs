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
        public Color BorderColor { get; set; }

        [DefaultValue(25)]
        public int TitleHeight { get; set; }

        public BaseForm()
        {
            this.BorderColor = Color.DarkBlue;
            TitleHeight = 25;

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
        }
        
        void PaintBorder(Graphics g)
        {
            using(Pen P = new Pen (this.BorderColor,1))
            {
                g.DrawRectangle(P, new Rectangle((int)(P.Width / 2), (int)(P.Width / 2), this.Width - (int)(P.Width), this.Height - (int)(P.Width)));
                g.DrawRectangle(P, new Rectangle((int)(P.Width / 2), (int)(P.Width / 2), this.Width - (int)(P.Width), TitleHeight));

            }
        }

        
    }
}
