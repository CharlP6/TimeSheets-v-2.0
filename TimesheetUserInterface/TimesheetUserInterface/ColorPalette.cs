using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetUserInterface
{

    enum Swatch
    {
        Shade2 = 0,
        Shade1,
        Primary,
        Tint1,
        Tint2,
    }

    class ColorPalette
    {


        public Color[] Palette
        {
            get;
            set;
        }

    }
}
