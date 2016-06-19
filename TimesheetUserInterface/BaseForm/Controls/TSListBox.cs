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
using BaseForm;
using DataAdapter;

namespace BaseForm
{
    public class TSListBox : ListBox
    {
        private List<Rectangle> HeaderRects = new List<Rectangle>();

        public List<string[]> items = new List<string[]>();

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

        TSDataBaseAdapter dba;

        public List<string[]> UserData = new List<string[]>();
        public List<RSTable> Software = new List<RSTable>();
        public List<RSTable> Roles = new List<RSTable>();
        public List<AdditionalTable> AdditionalTables = new List<AdditionalTable>();
        public List<ActivitiesTable> Activities = new List<ActivitiesTable>();
        public List<FunctionTable> Functions = new List<FunctionTable>();
        public List<DomainTable> Domains = new List<DomainTable>();
        public List<ProjectTable> Projects = new List<ProjectTable>();

        public TSListBox()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            

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
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Invalidate();
                this.Update();
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            PaintLines(e.Graphics);
            PaintHeaders(e.Graphics);
            PaintItems(e.Graphics);
            PaintBorder(e.Graphics);
            //base.OnPaint(e);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            //base.OnDrawItem(e);
            e.Graphics.Clear(BackColor);
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

            int j = ItemHeight;

            int f = 0;
            string printString = "";

            foreach (object o in Items)
            {
                

                string[] s = ToStringArray(o);
                //string[] s = ((IEnumerable<string>)o).Select(x => x).ToArray();

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

        string[] ToStringArray(object arg)
        {
            TimeSheetEntry tse = arg as TimeSheetEntry;
            List<string> str = new List<string>();

            str.Add(tse.WorkDate.ToShortDateString());
            str.Add(tse.Time.ToString());
            str.Add(Projects.Where(w => w.ID == tse.ProjectID).First().PName);
            str.Add(Domains.Where(w => w.ID == tse.DomainID).First().Name);
            str.Add(Functions.Where(w => w.ID == tse.FunctionID).First().Name);

            string act = Activities.Where(w => w.ID == tse.ActivityID).First().Name;
            if(Activities.Where(w => w.ID == tse.ActivityID).First().AddTable != "")
            {
                string actadd = AdditionalTables.Where(w => w.ID == tse.AdditionalID).First().Name;
                str.Add(act + " - " + actadd);            
            }
            else
            {
                str.Add(act);
            }

            str.Add(Roles.Where(w => w.ID == tse.RoleID).First().Name);
            str.Add(tse.Comments);
            str.Add(tse.ID.ToString());

            return str.ToArray();
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
