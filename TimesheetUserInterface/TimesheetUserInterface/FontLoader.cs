using System;
using System.Drawing;
using System.Drawing.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetUserInterface
{
    public class FontLoader
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        Font font;

        public Font LoadCustomFont(float Size, FontStyle Style)
        {
            //using (Stream S = Assembly.GetExecutingAssembly().GetManifestResourceStream("TimesheetUserInterface.Quicksand-Regular.otf"))
            //{
            //    PrivateFontCollection pfc;
            //    
            //    font = new Font(ff, Size, Style);
            //}

            PrivateFontCollection pfc;

            byte[] fArray = TimesheetUserInterface.Properties.Resources.Quicksand_Regular;
            //int faLength = TimesheetUserInterface.Properties.Resources.Quicksand_Regular.Length;

            FontFamily ff = LoadFontFamily(fArray, out pfc);
            font = new Font(ff, Size, Style);

            return font;
        }


        // load font family from byte array
        public static FontFamily LoadFontFamily(byte[] buffer, out PrivateFontCollection fontCollection)
        {
            // pin array so we can get its address
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                var ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
                fontCollection = new PrivateFontCollection();
                fontCollection.AddMemoryFont(ptr, buffer.Length);
                return fontCollection.Families[0];
            }
            finally
            {
                // don't forget to unpin the array!
                handle.Free();
            }
        }

        // Load font family from stream
        public static FontFamily LoadFontFamily(Stream stream, out PrivateFontCollection fontCollection)
        {
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return LoadFontFamily(buffer, out fontCollection);
        }


    }
}
