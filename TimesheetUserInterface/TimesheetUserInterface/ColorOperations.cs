using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TimesheetUserInterface
{
    public class ColorOperations
    {
        public Color Tint(Color BaseColor, float Amount)
        {
            int r = BaseColor.R + (int)((255 - BaseColor.R) * Amount);
            int g = BaseColor.G + (int)((255 - BaseColor.G) * Amount);
            int b = BaseColor.B +(int)((255 - BaseColor.B) * Amount);

            return Color.FromArgb(r, g, b);
        }

        public Color Shade(Color BaseColor, float Amount)
        {
            int r = (int)(BaseColor.R * (1 - Amount));
            int g = (int)(BaseColor.G * (1 - Amount));
            int b = (int)(BaseColor.B * (1 - Amount));

            return Color.FromArgb(r, g, b);
        }

    }
}
