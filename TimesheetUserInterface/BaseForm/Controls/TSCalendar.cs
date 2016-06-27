using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseForm
{
    public class TSCalendar : BaseControl
    {
        private int headerHeight = 17;
        private int width = 224;
        private int height = 137;

        private Rectangle HeaderRectangle = new Rectangle(0, 0, 224, 17);
        private Rectangle DaysRectangle = new Rectangle(0, 17, 224, 20);

        private Rectangle PrevRect = new Rectangle(0, 0, 17, 17);
        private Rectangle NextRect = new Rectangle(224 - 17, 0, 17, 17);

        private Rectangle CalendarRectangle = new Rectangle(0, 37, 224, 120);

        private Rectangle[] DayButtons = new Rectangle[42];
        private Size DayButtonSize = new Size(32, 20);
        private DateTime[] DisplayDays = new DateTime[42];
        
        private List<DateTime> DraggedDays = new List<DateTime>();

        public List<DateTime> SelectedDays = new List<DateTime>();
        public List<DateTime> BoldDays = new List<DateTime>();

        private Rectangle currentRect;
        private int currentButton = -1;

        private DateTime initDate;
        private DateTime date;

        public DateTime CurrentDate
        {
            get
            {
                if (date == initDate)
                    return DateTime.Today;
                return date;
            }
            set
            {
                date = value;
                fillDays();
                this.Invalidate();
                this.Update();
            }
        }

        public TSCalendar()
        {
            InitializeComponent();
            InitializeRectangles();
        }

        void InitializeRectangles()
        {
            for (int i = 0; i <= 41; i++)
            {
                int column = i % 7;
                int row = (i - column) / 7;
                DayButtons[i] = new Rectangle(new Point(column * DayButtonSize.Width, row * DayButtonSize.Height+CalendarRectangle.Top), DayButtonSize);
            }
            fillDays();

        }

        private void fillDays()
        {
            DateTime day1 = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
            DateTime monday1 = day1.StartOfWeek(DayOfWeek.Monday);

            for(int i = 0; i <= 41; i++)
            {
                DisplayDays[i] = monday1.AddDays(i);
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (CalendarRectangle.Contains(e.Location))
            {
                try
                {
                    DraggedDays.Clear();
                    DraggedDays.Add(DisplayDays[currentButton]);
                    DraggedDays.Add(DisplayDays[currentButton]);

                    SelectedDays.Clear();
                    SelectedDays.Add(DisplayDays[currentButton]);
                }
                catch
                {

                }
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if (CalendarRectangle.Contains(e.Location))
            {
                SelectedDays.Clear();
                try
                {
                    DateTime sDate = DraggedDays.Min();
                    DateTime eDate = DraggedDays.Max();

                    SelectedDays.Add(sDate);
                    while (sDate < eDate)
                    {
                        SelectedDays.Add(sDate.AddDays(1));
                        sDate = sDate.AddDays(1);
                    }

                    DraggedDays.Clear();
                    this.Invalidate();
                    this.Update();
                    base.OnMouseUp(e);
                }
                catch
                {
                    SelectedDays.Add(CurrentDate);
                    DraggedDays.Clear();
                    this.Invalidate();
                    this.Update();
                    base.OnMouseUp(e);
                }

            }
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            Rectangle cRect = DayButtons.Where(db => db.Contains(e.Location)).FirstOrDefault();

            if(cRect != currentRect)
            {
                currentRect = cRect;
                int row = (((e.Y - CalendarRectangle.Y) * 6) / (CalendarRectangle.Height));
                int col = ((e.X * 7) / width);
                currentButton = row * 7 + col;
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    try
                    {
                        DraggedDays[1] = DisplayDays[currentButton];
                    }
                    catch
                    {

                    }

                }
                this.Invalidate();
                this.Update();
            }
            if (!CalendarRectangle.Contains(e.Location))
            {
                currentButton = -1;
                this.Invalidate();
                this.Update();
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            currentButton = -1;
            this.Invalidate();
            this.Update();
            base.OnMouseLeave(e);
        }

        protected override void OnClick(EventArgs e)
        {
            if (currentButton != -1)
            {
                try
                {
                    SelectedDays.Clear();

                    DateTime sDate = DraggedDays.Min();
                    DateTime eDate = DraggedDays.Max();

                    SelectedDays.Add(sDate);
                    while (sDate < eDate)
                    {
                        SelectedDays.Add(sDate.AddDays(1));
                        sDate = sDate.AddDays(1);
                    }

                    CurrentDate = DisplayDays[currentButton];
                    fillDays();
                    this.Invalidate();
                    this.Update();
                }
                catch
                {

                }
            }

            base.OnClick(e);
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            if (NextRect.Contains(e.Location))
            {
                CurrentDate = CurrentDate.AddMonths(1);
                SelectedDays.Clear();
                SelectedDays.Add(date);
            }
            if (PrevRect.Contains(e.Location))
            {
                CurrentDate = CurrentDate.AddMonths(-1);
                SelectedDays.Clear();
                SelectedDays.Add(date);
            }

            base.OnMouseClick(e);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            PaintHeader(e.Graphics);
            PaintButtons(e.Graphics);
        }

        private void PaintHeader(Graphics g)
        {
            using(SolidBrush B = new SolidBrush(Palette.Tint1))
            {
                g.FillRectangle(B, HeaderRectangle);
                
                //Prepare to paint month name
                string HeaderText = CurrentDate.ToString("MMMM") + " " + CurrentDate.Year.ToString();
                int sLen = (int)g.MeasureString(HeaderText, this.Font).Width;
                int sHeight = (int)g.MeasureString(HeaderText, this.Font).Height;

                int sX = (width - sLen) / 2;
                int sY = (headerHeight - sHeight) / 2;

                B.Color = Palette.Shade2;

                g.DrawString(HeaderText, this.Font, B, new PointF(sX, sY));

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;

                Point[] triangle = { new Point(5, 8), new Point(11, 14), new Point(11, 2) };
                g.FillPolygon(B, triangle);

                triangle[0] = new Point(HeaderRectangle.Width - 5, 8);
                triangle[1] = new Point(HeaderRectangle.Width - 11, 14);
                triangle[2] = new Point(HeaderRectangle.Width - 11, 2);

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                g.FillPolygon(B, triangle);

                for (int i = 0; i <= 6; i++)
                {
                    string day = string.Join("", ((DaysOfTheWeek)i).ToString().Take(3));
                    sLen = (int)g.MeasureString(day, this.Font).Width;
                    sHeight = (int)g.MeasureString(day, this.Font).Height;
                    sX = (i * width) / 7 - sLen / 2 + DayButtonSize.Width/2;
                    sY = DaysRectangle.Y + DaysRectangle.Height / 2 - sHeight / 2;
                    g.DrawString(day, this.Font, B, new PointF(sX, sY));
                }

            }
        }

        private void PaintButtons(Graphics g)
        {

            Font btnFont = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, FontStyle.Regular);
            Font boldFont = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);

            int i = 0;

            using (SolidBrush B = new SolidBrush(Palette.Shade2))
            {
                foreach (Rectangle db in DayButtons)
                {
                    Point centre = new Point(db.X + db.Width / 2, db.Y + db.Height / 2);
                    string text = DisplayDays[i].Day.ToString();

                    int sLen = (int)g.MeasureString(text, btnFont).Width;
                    int sHeight = (int)g.MeasureString(text, btnFont).Height;
                    Point drawPoint = new Point(centre.X - sLen / 2, centre.Y - sHeight / 2);

                    if (DisplayDays[i] != DateTime.Today)
                    {
                        if (SelectedDays.Contains(DisplayDays[i]) || CurrentDate == DisplayDays[i])
                        {
                            g.FillRectangle(new SolidBrush(Palette.Tint1), db);
                        }
                        else if(currentButton == i)
                        {
                            g.FillRectangle(new SolidBrush(Palette.Tint2), db);                            
                        }
                        else if(DraggedDays.Count > 0)
                        {
                            if(DisplayDays[i] >= DraggedDays.Min() && DisplayDays[i] <= DraggedDays.Max())
                            {
                                g.FillRectangle(new SolidBrush(Palette.Tint2), db);
                            }
                        }
                        if(BoldDays.Contains(DisplayDays[i]))
                        {
                            g.DrawString(text, boldFont, B, drawPoint);
                        }
                        else
                        {
                            g.DrawString(text, btnFont, B, drawPoint);
                        }

                    }
                    else
                    {
                        if (currentButton == i)
                        {
                            g.FillRectangle(new SolidBrush(Palette.Tint2), db);
                            g.DrawString(text, btnFont, B, drawPoint);
                        }
                        else
                        {
                            g.FillRectangle(new SolidBrush(Palette.Shade1), db);
                            g.DrawString(text, btnFont, new SolidBrush(this.Palette.Tint2), drawPoint);
                        }

                    }

                    i++;
                }
            }

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TSCalendar
            // 
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(224, 137);
            this.ResumeLayout(false);

        }
    }
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }
    }

    public enum DaysOfTheWeek
    {
        Mon = 0,
        Tue,
        Wed,
        Thu,
        Fri,
        Sat,
        Sun,
    }

}
