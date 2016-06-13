using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetUserInterface
{
    class ColorOperations
    {
        public Color Tint(Color BaseColor, float Amount)
        {
            return Mix(BaseColor, Color.White, Amount);
        }

        public Color Shade(Color BaseColor, float Amount)
        {
            return Mix(BaseColor, Color.Black, Amount);
        }

        
        public Color Mix(Color BaseColor, Color Additive, float Amount)
        {
            int r = BaseColor.R + (int)((Additive.R - BaseColor.R) * Amount);
            int g = BaseColor.G + (int)((Additive.G - BaseColor.G) * Amount);
            int b = BaseColor.B + (int)((Additive.B - BaseColor.B) * Amount);

            return Color.FromArgb(r, g, b);

        }

    }
}
