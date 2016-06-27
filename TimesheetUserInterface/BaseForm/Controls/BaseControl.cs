using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseForm;

namespace BaseForm
{
    public class BaseControl : Control
    {
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

        public bool PaintOnlyTop { get; set; }

        public BaseControl()
        {
            palette = null;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PaintBorder(e.Graphics);
        }

        void PaintBorder(Graphics g)
        {
            using (Pen P = new Pen(Palette.Palette[borderSwatch], 1))
            {
                if (!PaintOnlyTop)
                    g.DrawRectangle(P, new Rectangle((int)(P.Width / 2), (int)(P.Width / 2), this.Width - (int)(P.Width), this.Height - (int)(P.Width)));
                else
                    g.DrawLine(P, 0, 0, Width, 0);
            }
        }
        
        #region Pallete

        private ColorPalette palette;

        public ColorPalette Palette
        {
            get
            {
                if(ParentHasPalette() && palette == null)
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
        
        #region MainColor
        private Color mainColor;
        public Color MainColor
        {
            get
            {
                if (mainColor == Color.Empty)
                {
                    if (ParentHasMainColor())
                    {
                        return GetParentMainColor();
                    }
                }
                return mainColor;
            }
            set
            {
                mainColor = value;
                this.Invalidate();
                this.Update();
            }
        }
        private bool ParentHasMainColor()
        {
            return this.FindForm() != null && this.FindForm().GetType().GetProperty("MainColor") != null;
        }
        private Color GetParentMainColor()
        {
            if (ParentHasMainColor())
            {
                return (Color)this.FindForm().GetType().GetProperty("MainColor").GetValue(this.FindForm());
            }
            else
            {
                return Color.DarkBlue;
            }
        }

        private bool ShouldSerializeMainColor()
        {
            return this.MainColor != GetParentMainColor();
        }
        private void ResetMainColor()
        {
            this.MainColor = GetParentMainColor();
        }
        #endregion

        #region AccentColor
        private Color accentColor;
        public Color AccentColor
        {
            get
            {
                if (accentColor == Color.Empty && ParentHasAccentColor())
                    return GetParentAccentColor();
                return accentColor;
            }
            set
            {
                if (accentColor != value)
                    accentColor = value;
                this.Invalidate();
                this.Update();
            }
        }
        private bool ParentHasAccentColor()
        {
            return this.FindForm() != null &&
                   this.FindForm().GetType().GetProperty("AccentColor") != null;
        }
        private Color GetParentAccentColor()
        {
            if (ParentHasAccentColor())
                return (Color)this.FindForm().GetType()
                                   .GetProperty("AccentColor").GetValue(this.FindForm());
            else
                return Color.FromArgb(163, 213, 255);
        }
        private bool ShouldSerializeAccentColor()
        {
            return this.AccentColor != GetParentAccentColor();
        }
        private void ResetAccentColor()
        {
            this.AccentColor = GetParentAccentColor();
        }
        #endregion

        #region SecondaryColor
        private Color secondaryColor;
        public Color SecondaryColor
        {
            get
            {
                if (secondaryColor == Color.Empty && ParentHasSecondaryColor())
                    return GetParentSecondaryColor();
                return secondaryColor;
            }
            set
            {
                if (secondaryColor != value)
                    secondaryColor = value;
                this.Invalidate();
                this.Update();
            }
        }
        private bool ParentHasSecondaryColor()
        {
            return this.FindForm() != null &&
                   this.FindForm().GetType().GetProperty("SecondaryColor") != null;
        }
        private Color GetParentSecondaryColor()
        {
            if (ParentHasSecondaryColor())
                return (Color)this.FindForm().GetType()
                                   .GetProperty("SecondaryColor").GetValue(this.FindForm());
            else
                return Color.AliceBlue;
        }
        private bool ShouldSerializeSecondaryColor()
        {
            return this.SecondaryColor != GetParentSecondaryColor();
        }
        private void ResetSecondaryColor()
        {
            this.SecondaryColor = GetParentSecondaryColor();
        }
        #endregion
    }


}
