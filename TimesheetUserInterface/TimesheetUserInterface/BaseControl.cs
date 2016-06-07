using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimesheetUserInterface
{
    public class BaseControl : Control
    {
        public BaseControl()
        {
            mainColor = Color.Empty;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PaintBorder(e.Graphics);
        }

        void PaintBorder(Graphics g)
        {
            using (Pen P = new Pen(this.MainColor, 1))
            {
                g.DrawRectangle(P, new Rectangle((int)(P.Width / 2), (int)(P.Width / 2), this.Width - (int)(P.Width), this.Height - (int)(P.Width)));
            }
        }


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
