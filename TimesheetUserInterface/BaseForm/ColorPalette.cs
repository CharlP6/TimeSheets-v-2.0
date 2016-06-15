using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseForm
{

    public enum Swatch
    {
        Shade2 = 0,
        Shade1,
        Primary,
        Tint1,
        Tint2,
    }

    public class ColorPalette
    {        

        public ColorPalette()
        {
            Palette = new Color[5];

            Shade2 = Color.FromArgb(3, 42, 103);
            Shade1 = Color.FromArgb(7,66,160);
            Primary = Color.FromArgb(46, 107, 204);
            Tint1 = Color.FromArgb(170, 193, 230);
            Tint2 = Color.FromArgb(222, 231, 246);
        }

        public ColorPalette(Color shade2, Color shade1, Color primary, Color tint1, Color tint2)
        {
            Palette = new Color[5];

            Shade2 = shade2;
            Shade1 = shade1;
            Primary = primary;
            Tint1 = tint1;
            Tint2 = tint2;
        }

        public Color[] Palette
        {
            get;
            set;
        }

        public Color Shade2
        {
            get
            {
                return Palette[0];
            }
            set
            {
                Palette[0] = value;
            }
        }

        public Color Shade1
        {
            get
            {
                return Palette[1];
            }
            set
            {
                Palette[1] = value;
            }
        }

        public Color Primary
        {
            get
            {
                return Palette[2];
            }
            set
            {
                Palette[2] = value;
            }
        }

        public Color Tint1
        {
            get
            {
                return Palette[3];
            }
            set
            {
                Palette[3] = value;
            }
        }

        public Color Tint2
        {
            get
            {
                return Palette[4];
            }
            set
            {
                Palette[4] = value;
            }
        }
    }
}
