using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetUserInterface
{
    class TSCalendar : BaseControl
    {

        private int headerHeight = 17;
        private int width = 224;
        private int height = 137;

        private Rectangle HeaderRectangle = new Rectangle(0, 0, 224, 17);
        private Rectangle DaysRectangle = new Rectangle(0, 17, 224, 20);

        private Rectangle CalendarRectangle = new Rectangle(0, 37, 224, 100);

        private Rectangle[] DayButtons = new Rectangle[42];
        private Size DayButtonSize = new Size(32, 20);

        private List<int> DraggedDays = new List<int>();
        private List<int> SelectedDays = new List<int>();

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
                string HeaderText = CurrentDate.ToString("MMMM");
                int sLen = (int)g.MeasureString(HeaderText, this.Font).Width;
                int sHeight = (int)g.MeasureString(HeaderText, this.Font).Height;

                int sX = (width - sLen) / 2;
                int sY = (headerHeight - sHeight) / 2;

                B.Color = Palette.Shade2;

                g.DrawString(HeaderText, this.Font, B, new PointF(sX, sY));
            }
        }

        private void PaintButtons(Graphics g)
        {
            int i = 0;
            DateTime day1 = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);

            DateTime monday1 = day1.StartOfWeek(DayOfWeek.Monday);

            using (SolidBrush B = new SolidBrush(Palette.Shade2))
            {
                foreach (Rectangle db in DayButtons)
                {
                    Point centre = new Point(db.X + db.Width / 2, db.Y + db.Height / 2);
                    string text = (monday1.AddDays(i)).Day.ToString();

                    int sLen = (int)g.MeasureString(text, this.Font).Width;
                    int sHeight = (int)g.MeasureString(text, this.Font).Height;

                    Point drawPoint = new Point(centre.X - sLen / 2, centre.Y - sHeight / 2);
                    g.DrawString(text, this.Font, B, drawPoint);

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
}
