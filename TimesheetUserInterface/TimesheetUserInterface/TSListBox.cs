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
    class TSListBox : BaseControl
    {

        ColorOperations co = new ColorOperations();

        private List<Rectangle> HeaderRects = new List<Rectangle>();

        private List<string[]> items = new List<string[]>();

        public List<string[]> Items
        {
            get { return items; }
        }

        Rectangle DateRect = new Rectangle(0, 0, 75, 18);
        Rectangle TimeRect = new Rectangle(75, 0, 35, 18);
        Rectangle ProjectRect = new Rectangle(75 + 35, 0, 220, 18);
        Rectangle DomainRect = new Rectangle(75 + 35 + 220, 0, 150, 18);
        Rectangle FunctionRect = new Rectangle(75 + 35 + 220 + 150, 0, 150, 18);
        Rectangle AcivityRect = new Rectangle(75 + 35 + 220 + 300, 0, 150, 18);
        Rectangle RoleRect = new Rectangle(75 + 35 + 220 + 450, 0, 120, 18);
        Rectangle CommentsRect = new Rectangle(75 + 35 + 220 + 450 + 120, 0, 200, 18);
        Rectangle IDRect = new Rectangle(75 + 35 + 220 + 450 + 120 + 200, 0, 35, 18);

        Rectangle DataRect;

        string[] HeaderText = { "Date", "Time", "Project", "Domain", "Function", "Activity", "Role", "Comments", "ID" };
        
        public int TopMostItem = 0;

        private int DisplayedItems;

        public int ItemHeight { get; set; }

        public TSListBox()
        {   
            HeaderRects.Clear();

            HeaderRects.Add(DateRect);
            HeaderRects.Add(TimeRect);
            HeaderRects.Add(ProjectRect);
            HeaderRects.Add(DomainRect);
            HeaderRects.Add(FunctionRect);
            HeaderRects.Add(AcivityRect);
            HeaderRects.Add(RoleRect);
            HeaderRects.Add(CommentsRect);
            HeaderRects.Add(IDRect);

            DataRect = new Rectangle(0, DateRect.Height, this.Width, this.Height - DateRect.Height);

            ItemHeight = this.Font.Height + 2;
            DisplayedItems = (DataRect.Height / ItemHeight) + 1;            
        }

        public void AddItem(string[] Entry)
        {
            items.Add(Entry);
            this.Invalidate();
            this.Update();
        }

        public void AddItems(List<string[]> Entries)
        {
            items.AddRange(Entries);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {

            PaintLines(e.Graphics);
            PaintHeaders(e.Graphics);
            PaintItems(e.Graphics);
            base.OnPaint(e);
        }

        void PaintLines(Graphics g)
        {
            DataRect = new Rectangle(0, DateRect.Height, this.Width, this.Height - DateRect.Height);

            ItemHeight = this.Font.Height + 2;
            DisplayedItems = (DataRect.Height / ItemHeight) + 1;
            using (Pen brush = new Pen(Palette.Tint2, 1))
            {
                for (int i = 1; i <= DisplayedItems; i += 1)
                {
                    g.DrawLine(brush, 0, i * ItemHeight, this.Width, i * ItemHeight);
                }
                for(int i = 1; i < HeaderRects.Count; i++)
                {
                    g.DrawLine(brush, HeaderRects[i].X, HeaderRects[i].Height, HeaderRects[i].X, this.Height);
                }
            }
        }

        void PaintHeaders(Graphics g)
        {
            Font HeaderFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);

            for(int i = 0 ; i < HeaderText.Length; i++)
            {
                int sLen = (int)g.MeasureString(HeaderText[i], HeaderFont).Width;
                int sHgt = (int)g.MeasureString(HeaderText[i], HeaderFont).Height;

                Point PaintPoint = new Point(HeaderRects[i].X + HeaderRects[i].Width / 2 - sLen / 2, (HeaderRects[i].Y + HeaderRects[i].Height / 2) - sHgt / 2);

                using(SolidBrush B = new SolidBrush(Palette.Palette[(int)BorderSwatch]))
                {
                    g.FillRectangle(B, HeaderRects[i]);
                    g.DrawString(HeaderText[i], HeaderFont, new SolidBrush(Palette.Tint2), PaintPoint);
                }

            }
        }

        void PaintItems(Graphics g)
        {
            Font StringFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Regular);

            int j = ItemHeight;

            int f = 0;
            string printString = "";

            foreach (string[] s in items)
            {
                for(int i = 0; i< HeaderRects.Count; i++)
                {
                    if (i < s.Length)
                    {
                        int sLen = (int)g.MeasureString(s[i], StringFont).Width;
                        f = s[i].Length;
                        printString = new string(s[i].Take(f).ToArray());
                        while(sLen > HeaderRects[i].Width)
                        {                            
                            sLen = (int)g.MeasureString(printString, StringFont).Width;
                            printString = new string(s[i].Take(f).ToArray());
                            f--;
                        }
                        
                        int sHgt = (int)g.MeasureString(s[i], StringFont).Height;
                        Point PaintPoint = new Point(HeaderRects[i].X + 2, (j + ItemHeight / 2) - sHgt / 2);

                        using(SolidBrush B = new SolidBrush(Palette.Palette[(int)BorderSwatch]))
                        {
                            g.SetClip(HeaderRects[i].Translate(-1, j));
                            g.DrawString(printString, StringFont, new SolidBrush(Palette.Shade2), PaintPoint);
                            g.ResetClip();
                        }
                    }
                }
                j += ItemHeight;
            }
        }
    }



    public static class RectExtensions
    {
        public static Rectangle Translate(this Rectangle rc, int xShfit, int yShift)
        {
            Rectangle retRect = rc;
            retRect.X += xShfit;
            retRect.Y = +yShift;

            return retRect;
        }
    }
}
