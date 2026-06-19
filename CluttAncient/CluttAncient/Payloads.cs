using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;

namespace CluttAncient
{
    internal class Payloads
    {
        // credit to CYBER SOLDIER for these dllimport          's
        // https://www.mediafire.com/file/6gstq1g9bqye7te/dllimports.txt/file

        [DllImport("gdi32.dll")]
        static extern IntPtr CreatePen(PenStyle fnPenStyle, int nWidth, uint crColor);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("gdi32.dll")]
        static extern bool MoveToEx(IntPtr hdc, int X, int Y, IntPtr lpPoint);
        [DllImport("gdi32.dll", SetLastError = true)]
        static extern bool MaskBlt(IntPtr hdcDest, int xDest, int yDest, int width, int height, IntPtr hdcSrc, int xSrc, int ySrc, IntPtr hbmMask, int xMask, int yMask, uint rop);
        [DllImport("gdi32.dll")]
        static extern bool LineTo(IntPtr hdc, int nXEnd, int nYEnd);
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll", EntryPoint = "BitBlt", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);
        [DllImport("gdi32.dll")]
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
        IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        TernaryRasterOperations dwRop);
        [DllImport("gdi32.dll")]
        static extern bool PlgBlt(IntPtr hdcDest, POINT[] lpPoint, IntPtr hdcSrc,
        int nXSrc, int nYSrc, int nWidth, int nHeight, IntPtr hbmMask, int xMask,
        int yMask);
        [DllImport("gdi32.dll")]
        static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, TernaryRasterOperations dwRop);
        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
        static extern IntPtr Ellipse(IntPtr hdc, int nLeftRect, int nTopRect,
        int nRightRect, int nBottomRect);
        [DllImport("gdi32.dll", EntryPoint = "GdiAlphaBlend")]
        public static extern bool AlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest,
        int nWidthDest, int nHeightDest,
        IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        BLENDFUNCTION blendFunction);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateSolidBrush(uint crColor);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateBitmap(int nWidth, int nHeight, uint cPlanes, uint cBitsPerPel, IntPtr lpvBits);
        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        public static extern bool DeleteDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern bool FloodFill(IntPtr hdc, int nXStart, int nYStart, uint crFill);
        [DllImport("gdi32.dll", EntryPoint = "GdiGradientFill", ExactSpelling = true)]
        public static extern bool GradientFill(
        IntPtr hdc,           // handle to DC
        TRIVERTEX[] pVertex,    // array of vertices
        uint dwNumVertex,     // number of vertices
        GRADIENT_RECT[] pMesh, // array of gradient triangles, that each one keeps three indices in pVertex array, to determine its bounds
        uint dwNumMesh,       // number of gradient triangles to draw
        GRADIENT_FILL dwMode);           // Use only GRADIENT_FILL.TRIANGLE. Both values GRADIENT_FILL.RECT_H and GRADIENT_FILL.RECT_V are wrong in this overload!

        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);
        [DllImport("gdi32.dll")]
        static extern bool FillRgn(IntPtr hdc, IntPtr hrgn, IntPtr hbr);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect,
        int nBottomRect);
        [DllImport("gdi32.dll")]
        static extern bool Pie(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect,
        int nBottomRect, int nXRadial1, int nYRadial1, int nXRadial2, int nYRadial2);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern bool Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        [DllImport("gdi32.dll")]
        static extern uint SetPixel(IntPtr hdc, int X, int Y, int crColor);
        [DllImport("gdi32.dll")]
        static extern IntPtr GetPixel(IntPtr hdc, int nXPos, int nYPos);
        [DllImport("gdi32.dll")]
        static extern bool AngleArc(IntPtr hdc, int X, int Y, uint dwRadius,
        float eStartAngle, float eSweepAngle);
        [DllImport("gdi32.dll")]
        static extern bool RoundRect(IntPtr hdc, int nLeftRect, int nTopRect,
        int nRightRect, int nBottomRect, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern bool DeleteMetaFile(IntPtr hmf);
        [DllImport("gdi32.dll")]
        static extern bool CancelDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern bool Polygon(IntPtr hdc, POINT[] lpPoints, int nCount);
        [DllImport("gdi32.dll")]

        static extern int SetBitmapBits(IntPtr hbmp, int cBytes, RGBQUAD[] lpBits);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool Beep(uint dwFreq, uint dwDuration);

        [DllImport("user32.dll")]
        private static extern bool BlockInput(bool block);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType,
        int cxDesired, int cyDesired, uint fuLoad);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int DestroyIcon(IntPtr hIcon);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadLibraryEx(IntPtr lpFileName, IntPtr hFile, LoadLibraryFlags dwFlags);

        [DllImport("user32.dll")]
        static extern IntPtr LoadBitmap(IntPtr hInstance, string lpBitmapName);

        [DllImport("user32.dll")]
        static extern IntPtr BeginPaint(IntPtr hwnd, out PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        static extern bool EndPaint(IntPtr hWnd, out PAINTSTRUCT lpPaint);

        [DllImport("gdi32.dll")]
        static extern int SetStretchBltMode(IntPtr hdc, StretchBltMode iStretchMode);

        [DllImport("gdi32.dll")]
        static extern int StretchDIBits(IntPtr hdc, int XDest, int YDest,
        int nDestWidth, int nDestHeight, int XSrc, int YSrc, int nSrcWidth,
        int nSrcHeight, RGBQUAD rgbq, [In] ref BITMAPINFO lpBitsInfo, DIB_Color_Mode dib_mode,
        TernaryRasterOperations dwRop);

        [DllImport("gdi32.dll")]
        public static extern bool SetDeviceGammaRamp(IntPtr hDC, ref RAMP lpRamp);

        [DllImport("Gdi32", EntryPoint = "GetBitmapBits")]
        private extern static long GetBitmapBits([In] IntPtr hbmp, [In] int cbBuffer, RGBQUAD[] lpvBits);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateHatchBrush(int iHatch, uint Color);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreatePatternBrush(IntPtr hbmp);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateDIBitmap(IntPtr hdc, [In] ref BITMAPINFOHEADER
        lpbmih, uint fdwInit, byte[] lpbInit, [In] ref BITMAPINFO lpbmi,
        uint fuUsage);

        [DllImport("gdi32.dll")]
        static extern int SetDIBitsToDevice(IntPtr hdc, int XDest, int YDest, uint
        dwWidth, uint dwHeight, int XSrc, int YSrc, uint uStartScan, uint cScanLines,
        byte[] lpvBits, [In] ref BITMAPINFO lpbmi, uint fuColorUse);

        [DllImport("gdi32.dll")]
        static extern IntPtr SetDIBits(IntPtr hdc, IntPtr hbm, uint start, int line, int lpBits, [In] ref BITMAPINFO lpbmi, DIB_Color_Mode ColorUse);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct RAMP
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public UInt16[] Red;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public UInt16[] Green;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public UInt16[] Blue;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct BITMAPINFO
        {
            /// <summary>
            /// A BITMAPINFOHEADER structure that contains information about the dimensions of color format.
            /// </summary>
            public BITMAPINFOHEADER bmiHeader;

            /// <summary>
            /// An array of RGBQUAD. The elements of the array that make up the color table.
            /// </summary>
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
            public RGBQUAD[] bmiColors;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFOHEADER
        {
            public uint biSize;
            public int biWidth;
            public int biHeight;
            public ushort biPlanes;
            public ushort biBitCount;
            public uint biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public uint biClrUsed;
            public uint biClrImportant;
            public uint biCompression;

            public void Init()
            {
                biSize = (uint)Marshal.SizeOf(this);
            }
        }

        enum BitmapCompressionMode : uint
        {
            BI_RGB = 0,
            BI_RLE8 = 1,
            BI_RLE4 = 2,
            BI_BITFIELDS = 3,
            BI_JPEG = 4,
            BI_PNG = 5
        }

        enum DIB_Color_Mode : uint
        {
            DIB_RGB_COLORS = 0,
            DIB_PAL_COLORS = 1
        }

        private enum StretchBltMode : int
        {
            STRETCH_ANDSCANS = 1,
            STRETCH_ORSCANS = 2,
            STRETCH_DELETESCANS = 3,
            STRETCH_HALFTONE = 4,
        }

        /// <summary>
        /// The default flag; it does nothing. All it means is "not LR_MONOCHROME".
        /// </summary>
        public const int LR_DEFAULTCOLOR = 0x0000;

        /// <summary>
        /// Loads the image in black and white.
        /// </summary>
        public const int LR_MONOCHROME = 0x0001;

        /// <summary>
        /// Returns the original hImage if it satisfies the criteria for the copy—that is, correct dimensions and color depth—in
        /// which case the LR_COPYDELETEORG flag is ignored. If this flag is not specified, a new object is always created.
        /// </summary>
        public const int LR_COPYRETURNORG = 0x0004;

        /// <summary>
        /// Deletes the original image after creating the copy.
        /// </summary>
        public const int LR_COPYDELETEORG = 0x0008;

        /// <summary>
        /// Specifies the image to load. If the hinst parameter is non-NULL and the fuLoad parameter omits LR_LOADFROMFILE,
        /// lpszName specifies the image resource in the hinst module. If the image resource is to be loaded by name,
        /// the lpszName parameter is a pointer to a null-terminated string that contains the name of the image resource.
        /// If the image resource is to be loaded by ordinal, use the MAKEINTRESOURCE macro to convert the image ordinal
        /// into a form that can be passed to the LoadImage function.
        ///  
        /// If the hinst parameter is NULL and the fuLoad parameter omits the LR_LOADFROMFILE value,
        /// the lpszName specifies the OEM image to load. The OEM image identifiers are defined in Winuser.h and have the following prefixes.
        ///
        /// OBM_ OEM bitmaps
        /// OIC_ OEM icons
        /// OCR_ OEM cursors
        ///
        /// To pass these constants to the LoadImage function, use the MAKEINTRESOURCE macro. For example, to load the OCR_NORMAL cursor,
        /// pass MAKEINTRESOURCE(OCR_NORMAL) as the lpszName parameter and NULL as the hinst parameter.
        ///
        /// If the fuLoad parameter includes the LR_LOADFROMFILE value, lpszName is the name of the file that contains the image.
        /// </summary>
        public const int LR_LOADFROMFILE = 0x0010;

        /// <summary>
        /// Retrieves the color value of the first pixel in the image and replaces the corresponding entry in the color table
        /// with the default window color (COLOR_WINDOW). All pixels in the image that use that entry become the default window color.
        /// This value applies only to images that have corresponding color tables.
        /// Do not use this option if you are loading a bitmap with a color depth greater than 8bpp.
        ///
        /// If fuLoad includes both the LR_LOADTRANSPARENT and LR_LOADMAP3DCOLORS values, LRLOADTRANSPARENT takes precedence.
        /// However, the color table entry is replaced with COLOR_3DFACE rather than COLOR_WINDOW.
        /// </summary>
        public const int LR_LOADTRANSPARENT = 0x0020;

        /// <summary>
        /// Uses the width or height specified by the system metric values for cursors or icons,
        /// if the cxDesired or cyDesired values are set to zero. If this flag is not specified and cxDesired and cyDesired are set to zero,
        /// the function uses the actual resource size. If the resource contains multiple images, the function uses the size of the first image.
        /// </summary>
        public const int LR_DEFAULTSIZE = 0x0040;

        /// <summary>
        /// Uses true VGA colors.
        /// </summary>
        public const int LR_VGACOLOR = 0x0080;

        /// <summary>
        /// Searches the color table for the image and replaces the following shades of gray with the corresponding 3-D color: Color Replaced with
        /// Dk Gray, RGB(128,128,128) COLOR_3DSHADOW
        /// Gray, RGB(192,192,192) COLOR_3DFACE
        /// Lt Gray, RGB(223,223,223) COLOR_3DLIGHT
        /// Do not use this option if you are loading a bitmap with a color depth greater than 8bpp.
        /// </summary>
        public const int LR_LOADMAP3DCOLORS = 0x1000;

        /// <summary>
        /// When the uType parameter specifies IMAGE_BITMAP, causes the function to return a DIB section bitmap rather than a compatible bitmap.
        /// This flag is useful for loading a bitmap without mapping it to the colors of the display device.
        /// </summary>
        public const int LR_CREATEDIBSECTION = 0x2000;

        /// <summary>
        /// Tries to reload an icon or cursor resource from the original resource file rather than simply copying the current image.
        /// This is useful for creating a different-sized copy when the resource file contains multiple sizes of the resource.
        /// Without this flag, CopyImage stretches the original image to the new size. If this flag is set, CopyImage uses the size
        /// in the resource file closest to the desired size. This will succeed only if hImage was loaded by LoadIcon or LoadCursor,
        /// or by LoadImage with the LR_SHARED flag.
        /// </summary>
        public const int LR_COPYFROMRESOURCE = 0x4000;

        /// <summary>
        /// Shares the image handle if the image is loaded multiple times. If LR_SHARED is not set, a second call to LoadImage for the
        /// same resource will load the image again and return a different handle.
        /// When you use this flag, the system will destroy the resource when it is no longer needed.
        ///
        /// Do not use LR_SHARED for images that have non-standard sizes, that may change after loading, or that are loaded from a file.
        ///
        /// When loading a system icon or cursor, you must use LR_SHARED or the function will fail to load the resource.
        ///
        /// Windows 95/98/Me: The function finds the first image with the requested resource name in the cache, regardless of the size requested.
        /// </summary>
        public const int LR_SHARED = 0x8000;

        [StructLayout(LayoutKind.Sequential)]
        struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public bool fErase;
            public RECT rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

            public int X
            {
                get { return Left; }
                set { Right -= (Left - value); Left = value; }
            }

            public int Y
            {
                get { return Top; }
                set { Bottom -= (Top - value); Top = value; }
            }

            public int Height
            {
                get { return Bottom - Top; }
                set { Bottom = value + Top; }
            }

            public int Width
            {
                get { return Right - Left; }
                set { Right = value + Left; }
            }

            public System.Drawing.Point Location
            {
                get { return new System.Drawing.Point(Left, Top); }
                set { X = value.X; Y = value.Y; }
            }

            public System.Drawing.Size Size
            {
                get { return new System.Drawing.Size(Width, Height); }
                set { Width = value.Width; Height = value.Height; }
            }

            public static implicit operator System.Drawing.Rectangle(RECT r)
            {
                return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
            }

            public static implicit operator RECT(System.Drawing.Rectangle r)
            {
                return new RECT(r);
            }

            public static bool operator ==(RECT r1, RECT r2)
            {
                return r1.Equals(r2);
            }

            public static bool operator !=(RECT r1, RECT r2)
            {
                return !r1.Equals(r2);
            }

            public bool Equals(RECT r)
            {
                return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
            }

            public override bool Equals(object obj)
            {
                if (obj is RECT)
                    return Equals((RECT)obj);
                else if (obj is System.Drawing.Rectangle)
                    return Equals(new RECT((System.Drawing.Rectangle)obj));
                return false;
            }

            public override int GetHashCode()
            {
                return ((System.Drawing.Rectangle)this).GetHashCode();
            }

            public override string ToString()
            {
                return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
            }
        }

        private enum LoadLibraryFlags : uint
        {
            DONT_RESOLVE_DLL_REFERENCES = 0x00000001,
            LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,
            LOAD_LIBRARY_AS_DATAFILE = 0x00000002,
            LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,
            LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,
            LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008
        }

        private enum PenStyle : int
        {
            PS_SOLID = 0, //The pen is solid.
            PS_DASH = 1, //The pen is dashed.
            PS_DOT = 2, //The pen is dotted.
            PS_DASHDOT = 3, //The pen has alternating dashes and dots.
            PS_DASHDOTDOT = 4, //The pen has alternating dashes and double dots.
            PS_NULL = 5, //The pen is invisible.
            PS_INSIDEFRAME = 6,// Normally when the edge is drawn, it’s centred on the outer edge meaning that half the width of the pen is drawn
                               // outside the shape’s edge, half is inside the shape’s edge. When PS_INSIDEFRAME is specified the edge is drawn
                               //completely inside the outer edge of the shape.
            PS_USERSTYLE = 7,
            PS_ALTERNATE = 8,
            PS_STYLE_MASK = 0x0000000F,

            PS_ENDCAP_ROUND = 0x00000000,
            PS_ENDCAP_SQUARE = 0x00000100,
            PS_ENDCAP_FLAT = 0x00000200,
            PS_ENDCAP_MASK = 0x00000F00,

            PS_JOIN_ROUND = 0x00000000,
            PS_JOIN_BEVEL = 0x00001000,
            PS_JOIN_MITER = 0x00002000,
            PS_JOIN_MASK = 0x0000F000,

            PS_COSMETIC = 0x00000000,
            PS_GEOMETRIC = 0x00010000,
            PS_TYPE_MASK = 0x000F0000
        };
        public enum TernaryRasterOperations : uint
        {
            /// <summary>dest = source</summary>
            SRCCOPY = 0x00CC0020,
            /// <summary>dest = source OR dest</summary>
            SRCPAINT = 0x00EE0086,
            /// <summary>dest = source AND dest</summary>
            SRCAND = 0x008800C6,
            /// <summary>dest = source XOR dest</summary>
            SRCINVERT = 0x00660046,
            /// <summary>dest = source AND (NOT dest)</summary>
            SRCERASE = 0x00440328,
            /// <summary>dest = (NOT source)</summary>
            NOTSRCCOPY = 0x00330008,
            /// <summary>dest = (NOT src) AND (NOT dest)</summary>
            NOTSRCERASE = 0x001100A6,
            /// <summary>dest = (source AND pattern)</summary>
            MERGECOPY = 0x00C000CA,
            /// <summary>dest = (NOT source) OR dest</summary>
            MERGEPAINT = 0x00BB0226,
            /// <summary>dest = pattern</summary>
            PATCOPY = 0x00F00021,
            /// <summary>dest = DPSnoo</summary>
            PATPAINT = 0x00FB0A09,
            /// <summary>dest = pattern XOR dest</summary>
            PATINVERT = 0x005A0049,
            /// <summary>dest = (NOT dest)</summary>
            DSTINVERT = 0x00550009,
            /// <summary>dest = BLACK</summary>
            BLACKNESS = 0x00000042,
            /// <summary>dest = WHITE</summary>
            WHITENESS = 0x00FF0062,
            /// <summary>
            /// Capture window as seen on screen.  This includes layered windows
            /// such as WPF windows with AllowsTransparency="true"
            /// </summary>
            CAPTUREBLT = 0x40000000,
            CUSTOM = 0x00100C85
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct BLENDFUNCTION
        {
            byte BlendOp;
            byte BlendFlags;
            byte SourceConstantAlpha;
            byte AlphaFormat;

            public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
            {
                BlendOp = op;
                BlendFlags = flags;
                SourceConstantAlpha = alpha;
                AlphaFormat = format;
            }
        }

        //
        // currently defined blend operation
        //
        const int AC_SRC_OVER = 0x00;

        //
        // currently defined alpha format
        //
        const int AC_SRC_ALPHA = 0x01;

        [StructLayout(LayoutKind.Sequential)]
        public struct GRADIENT_RECT
        {
            public uint UpperLeft;
            public uint LowerRight;

            public GRADIENT_RECT(uint upLeft, uint lowRight)
            {
                this.UpperLeft = upLeft;
                this.LowerRight = lowRight;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TRIVERTEX
        {
            public int x;
            public int y;
            public ushort Red;
            public ushort Green;
            public ushort Blue;
            public ushort Alpha;

            public TRIVERTEX(int x, int y, ushort red, ushort green, ushort blue, ushort alpha)
            {
                this.x = x;
                this.y = y;
                this.Red = red;
                this.Green = green;
                this.Blue = blue;
                this.Alpha = alpha;
            }
        }
        public enum GRADIENT_FILL : uint
        {
            RECT_H = 0,
            RECT_V = 1,
            TRIANGLE = 2,
            OP_FLAG = 0xff
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct GRADIENT_TRIANGLE
        {
            public uint Vertex1;
            public uint Vertex2;
            public uint Vertex3;

            public GRADIENT_TRIANGLE(uint vertex1, uint vertex2, uint vertex3)
            {
                this.Vertex1 = vertex1;
                this.Vertex2 = vertex2;
                this.Vertex3 = vertex3;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RGBQUAD
        {
            public byte rgbBlue;
            public byte rgbGreen;
            public byte rgbRed;
            public byte rgbReserved;
        }



        public static void lunareclipse()
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            Random r = new Random();

            while (true)
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                IntPtr hbrush = CreateSolidBrush(255);

                try
                {
                    SelectObject(hdc, hbrush);

                    for (int i = 0; i < r.Next(10); ++i)
                    {
                        BitBlt(hdc, r.Next(-11, -10), r.Next(-11, 10), w, h, hdc, -12, -12, TernaryRasterOperations.SRCINVERT);
                        BitBlt(hdc, r.Next(-11, -10), r.Next(-11, 10), w, h, hdc, -12, -12, TernaryRasterOperations.SRCCOPY);
                        BitBlt(hdc, r.Next(-11, -10), r.Next(-11, 10), w, h, hdc, -12, -12, TernaryRasterOperations.SRCPAINT);
                        BitBlt(hdc, r.Next(-11, -10), r.Next(-11, 10), w, h, hdc, -12, -12, TernaryRasterOperations.SRCERASE);
                        Thread.Sleep(1);
                    }

                    for (int i = 0; i < r.Next(10); ++i)
                    {
                        BitBlt(hdc, r.Next(-11, 10), r.Next(-11, 10), w, h, hdc, 12, 12, TernaryRasterOperations.SRCINVERT);
                        BitBlt(hdc, r.Next(-11, 10), r.Next(-11, 10), w, h, hdc, 12, 12, TernaryRasterOperations.SRCCOPY);
                        BitBlt(hdc, r.Next(-11, 10), r.Next(-11, 10), w, h, hdc, 12, 12, TernaryRasterOperations.SRCPAINT);
                        BitBlt(hdc, r.Next(-11, 10), r.Next(-11, 10), w, h, hdc, 12, 12, TernaryRasterOperations.SRCERASE);
                        Thread.Sleep(1);
                    }
                }
                finally
                {
                    DeleteObject(hbrush);
                    ReleaseDC(IntPtr.Zero, hdc);
                }
            }
        }
        public static void texts()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            Random r = new Random();
            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string user = Environment.UserName;

            string[] rndtext =
            {
                "Enjoy your new PC" + user,
                "6767676767676",
                desktopFolder + "AAAA",
                "Unknown Hard Error",
                "MAMA IM STUCKED AT HELL",
                "Clutt Clutt Clutt Clutt Clutt",
                documentFolder + "AAA",
                "FREE ROBUX NO SCAM!! 100% WORK",
                "uhh you are in trouble",
                "Hello! I'm Bonzi! I am come here to DESTROY your computer again",
                "Poop Poop Poop Poop, Get the fuck up you little piece of shit from here!",
                "BAD ERROR!!1111",
                "enjoy your new pc!!",
                "666",
                "Never Gonna Give YOU uP1!!",
                "!!! VIRUS DETECTED",
                "Half Life 3 released soon!",
                "CluttAncient",
                "maybe the free minecraft installer doesnt work..",
                "Cyber Soldier",
                "Ajun Wira",
                ".NET Framework 4.7.2"
            };

            while (true)
            {
                IntPtr hdc = GetDC(IntPtr.Zero);

                try
                {
                    using (Graphics g = Graphics.FromHdc(hdc))
                    using (Font drawFont = new Font("Arial", r.Next(20, 40)))
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256))))
                    {
                        int xp = r.Next(x);
                        int yp = r.Next(y);
                        g.DrawString(rndtext[r.Next(rndtext.Length)], drawFont, brush, xp, yp);
                    }
                }
                finally
                {
                    ReleaseDC(IntPtr.Zero, hdc);
                }

                Thread.Sleep(1);
            }
        }
        //horrible tab          's

        // credit from silverjetes for the text GDI
        // https://github.com/silverjetes/cerium/blob/main/cerium/Program.cs#L496


        public static void bitmaps()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);

            try
            {
                int sw = Screen.PrimaryScreen.Bounds.Width;
                int sh = Screen.PrimaryScreen.Bounds.Height;

                using (Graphics desktopGraphics = Graphics.FromHdc(hdc))
                using (Bitmap overlay = new Bitmap(256, 256))
                using (Graphics g = Graphics.FromImage(overlay))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    Random rnd = new Random();
                    double angle = 0;

                    while (true)
                    {
                        BitBlt(
                            hdc,
                            1, 1,
                            sw - 1, sh - 1,
                            hdc,
                            0, 0,
                            TernaryRasterOperations.SRCINVERT);

                        BitBlt(
                            hdc,
                            1, 1,
                            sw - 1, sh - 1,
                            hdc,
                            0, 0,
                            TernaryRasterOperations.SRCPAINT);

                        g.Clear(Color.Transparent);

                        for (int i = 0; i < 12; i++)
                        {
                            double a = angle + i * (Math.PI * 2.0 / 12.0);

                            float x = 128 + (float)(Math.Cos(a) * 80);
                            float y = 128 + (float)(Math.Sin(a) * 80);

                            Color c = Color.FromArgb(
                                180,
                                rnd.Next(256),
                                rnd.Next(256),
                                rnd.Next(256));

                            using (Pen pen = new Pen(c, 2))
                            using (SolidBrush brush = new SolidBrush(c))
                            {
                                g.DrawLine(pen, 128, 128, x, y);
                                g.FillEllipse(brush, x - 6, y - 6, 12, 12);
                            }
                        }

                        int px = rnd.Next(Math.Max(1, sw - overlay.Width));
                        int py = rnd.Next(Math.Max(1, sh - overlay.Height));

                        desktopGraphics.DrawImageUnscaled(overlay, px, py);

                        angle += 0.08;
                        Thread.Sleep(16);
                    }
                }
            }
            finally
            {
                ReleaseDC(IntPtr.Zero, hdc);
            }
        }
        public static void bitmap2()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);

            try
            {
                int sw = Screen.PrimaryScreen.Bounds.Width;
                int sh = Screen.PrimaryScreen.Bounds.Height;

                using (Graphics desktopGraphics = Graphics.FromHdc(hdc))
                using (Bitmap overlay = new Bitmap(256, 256))
                using (Graphics g = Graphics.FromImage(overlay))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    Random rnd = new Random();
                    double angle = 0;

                    while (true)
                    {
                        g.Clear(Color.Transparent);

                        for (int i = 0; i < 12; i++)
                        {
                            double a = angle + i * (Math.PI * 2.0 / 12.0);

                            float x = 128 + (float)(Math.Cos(a) * 80);
                            float y = 128 + (float)(Math.Sin(a) * 80);

                            Color c = Color.FromArgb(
                                180,
                                rnd.Next(256),
                                rnd.Next(256),
                                rnd.Next(256));

                            using (Pen pen = new Pen(c, 2))
                            using (SolidBrush brush = new SolidBrush(c))
                            {
                                g.DrawBezier(pen, 128, 128, x, y, x + 1, y + 1, x + y, y + x);
                                g.FillEllipse(brush, x - 6, y - 6, 12, 12);
                            }
                        }

                        int px = rnd.Next(Math.Max(1, sw - overlay.Width));
                        int py = rnd.Next(Math.Max(1, sh - overlay.Height));

                        desktopGraphics.DrawImageUnscaled(overlay, px, py);

                        angle += 0.08;
                        Thread.Sleep(16);
                    }
                }
            }
            finally
            {
                ReleaseDC(IntPtr.Zero, hdc);
            }
        }

        // skidded
        public static void melting()
        {
            Random r = new Random();
            while (true)
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                try
                {
                    int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height, rx = r.Next(x);
                    BitBlt(hdc, rx, 2, r.Next(400), y, hdc, rx, 0, TernaryRasterOperations.SRCCOPY);
                }
                finally
                {
                    ReleaseDC(IntPtr.Zero, hdc);
                }
                Thread.Sleep(1);
            }
        }

        public static void texts2()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            Random r = new Random();
            string[] rndtext =
{
    // List awal kamu
    "C++",
    "C#",
    "C",
    "Python",
    "Assembly",
    "Rust",
    "Ruby",
    "Golang",
    "Haxe",
    "Java",
    "JavaScript",
    "CSS",
    "LUA",
    "XAML",
    "XML",
    "YAML",
    "PHP",
    "JSON",
    "Visual Basic",
    "TOML",

    // Tambahan baru biar makin lengkap
    "TypeScript",   // Superset JavaScript yang super populer
    "Kotlin",       // Andalannya Android dev saat ini
    "Swift",        // Wajib hukumnya buat iOS dev
    "Dart",         // Pasangannya Flutter
    "HTML",         // Pasangan sejatinya CSS
    "SQL",          // Rajanya urusan database
    "R",            // Favorit anak data science & statistik
    "MATLAB",       // Teman setianya mahasiswa teknik
    "Scala",        // Sering dipakai buat Big Data
    "Haskell",      // Bahasa fungsional murni
    "Perl",         // Legend scripting language
    "Objective-C",  // Pendahulunya Swift
    "Elixir",       // Mantap buat sistem yang butuh concurrency tinggi
    "Clojure",      // Dialek modern dari Lisp
    "F#",           // Bahasa fungsional dari keluarga .NET
    "Bash",         // Buat yang hobi mainan terminal Linux
    "PowerShell",   // Scripting andalan di Windows
    "Julia",        // Cepat banget buat komputasi numerik
    "Zig",          // Bahasa modern yang sering dibilang kandidat pengganti C
    "Nim"           // Sintaks mirip Python tapi performa secepat C
};
            while (true)
            {
                IntPtr hdc = GetDC(IntPtr.Zero);

                try
                {
                    using (Graphics g = Graphics.FromHdc(hdc))
                    using (Font drawFont = new Font("Arial", r.Next(20, 40)))
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256))))
                    {
                        int xp = r.Next(x);
                        int yp = r.Next(y);
                        g.DrawString(rndtext[r.Next(rndtext.Length)], drawFont, brush, xp, yp);
                    }
                }
                finally
                {
                    ReleaseDC(IntPtr.Zero, hdc);
                }

                Thread.Sleep(1);
            }
        }

        public static void colorvortex()
        {
            Random rnd = new Random();

            IntPtr hdc = GetDC(IntPtr.Zero);

            try
            {
                int sw = Screen.PrimaryScreen.Bounds.Width;
                int sh = Screen.PrimaryScreen.Bounds.Height;

                using (Graphics g = Graphics.FromHdc(hdc))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    double t = 0;

                    while (true)
                    {
                        // Geser isi layar sedikit untuk efek trail
                        BitBlt(
                            hdc,
                            1,
                            1,
                            sw - 2,
                            sh - 2,
                            hdc,
                            0,
                            0,
                            TernaryRasterOperations.SRCCOPY);

                        float cx = sw / 2f;
                        float cy = sh / 2f;

                        for (int i = 0; i < 36; i++)
                        {
                            double a = t + i * (Math.PI / 18.0);

                            float x = cx + (float)(Math.Cos(a) * 200);
                            float y = cy + (float)(Math.Sin(a) * 200);

                            Color c = Color.FromArgb(
                                180,
                                (int)(128 + 127 * Math.Sin(a)),
                                (int)(128 + 127 * Math.Sin(a + 2)),
                                (int)(128 + 127 * Math.Sin(a + 4)));

                            using (Pen p = new Pen(c, 3))
                            using (SolidBrush b = new SolidBrush(c))
                            {
                                g.DrawLine(p, cx, cy, x, y);
                                g.FillEllipse(b, x - 8, y - 8, 16, 16);
                            }
                        }

                        t += 0.05;
                        Thread.Sleep(16);
                    }
                }
            }
            finally
            {
                ReleaseDC(IntPtr.Zero, hdc);
            }
        }

        public static void texts3()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            Random r = new Random();
            string[] rndtext =
{
            "iostream",
            "string",
            "vector",
            "cctype",
            "algorithm",
            $"{r.Next(255) + long.MaxValue}"};
            while (true)
            {
                IntPtr hdc = GetDC(IntPtr.Zero);

                try
                {
                    using (Graphics g = Graphics.FromHdc(hdc))
                    using (Font drawFont = new Font("Arial", r.Next(20, 40)))
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256))))
                    {
                        int xp = r.Next(x);
                        int yp = r.Next(y);
                        g.DrawString(rndtext[r.Next(rndtext.Length)], drawFont, brush, xp, yp);
                    }
                }
                finally
                {
                    ReleaseDC(IntPtr.Zero, hdc);
                }
                InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
            }
        }

        public static void morphshape()
        {
            Random rnd = new Random();

            IntPtr hdc = GetDC(IntPtr.Zero);

            try
            {
                int sw = Screen.PrimaryScreen.Bounds.Width;
                int sh = Screen.PrimaryScreen.Bounds.Height;

                using (Graphics g = Graphics.FromHdc(hdc))
                {
                    g.SmoothingMode =
                        System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    float x = sw / 2f;
                    float y = sh / 2f;

                    float vx = 7f;
                    float vy = 5f;

                    float radius = 80f;

                    float currentSides = 5f;
                    float targetSides = 5f;

                    bool star = true;

                    double hue = 0;

                    while (true)
                    {
                        x += vx;
                        y += vy;

                        bool hit = false;

                        if (x - radius < 0 || x + radius > sw)
                        {
                            vx = -vx;
                            hit = true;
                        }

                        if (y - radius < 0 || y + radius > sh)
                        {
                            vy = -vy;
                            hit = true;
                        }

                        if (hit)
                        {
                            InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                            star = rnd.Next(2) == 0;
                            targetSides = rnd.Next(3, 9);
                        }

                        // transisi halus
                        currentSides +=
                            (targetSides - currentSides) * 0.08f;

                        hue += 0.03;

                        Color c = Color.FromArgb(
                            180,
                            (int)(128 + 127 * Math.Sin(hue)),
                            (int)(128 + 127 * Math.Sin(hue + 2)),
                            (int)(128 + 127 * Math.Sin(hue + 4)));

                        using (Pen pen = new Pen(c, 4))
                        {
                            PointF[] pts;

                            int sides = Math.Max(
                                3,
                                (int)Math.Round(currentSides));

                            if (star)
                            {
                                pts = new PointF[sides * 2];

                                for (int i = 0; i < pts.Length; i++)
                                {
                                    double a =
                                        i * Math.PI / sides -
                                        Math.PI / 2;

                                    float r =
                                        (i % 2 == 0)
                                        ? radius
                                        : radius * 0.45f;

                                    pts[i] = new PointF(
                                        x + (float)Math.Cos(a) * r,
                                        y + (float)Math.Sin(a) * r);
                                }
                            }
                            else
                            {
                                pts = new PointF[sides];

                                for (int i = 0; i < sides; i++)
                                {
                                    double a =
                                        i * 2.0 * Math.PI / sides -
                                        Math.PI / 2;

                                    pts[i] = new PointF(
                                        x + (float)Math.Cos(a) * radius,
                                        y + (float)Math.Sin(a) * radius);
                                }
                            }

                            g.DrawPolygon(pen, pts);
                        }
                        Thread.Sleep(16);
                    }
                }
            }
            finally
            {
                ReleaseDC(IntPtr.Zero, hdc);
            }
        }

        public static void orbitingballs()
        {
            Random rnd = new Random();

            IntPtr hdc = GetDC(IntPtr.Zero);

            try
            {
                int sw = Screen.PrimaryScreen.Bounds.Width;
                int sh = Screen.PrimaryScreen.Bounds.Height;

                using (Graphics g = Graphics.FromHdc(hdc))
                {
                    g.SmoothingMode =
                        System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    double rot = 0;

                    while (true)
                    {
                        // Efek trail
                        BitBlt(
                            hdc,
                            1,
                            1,
                            sw - 2,
                            sh - 2,
                            hdc,
                            0,
                            0,
                            TernaryRasterOperations.SRCCOPY);

                        float cx = sw / 2f;
                        float cy = sh / 2f;

                        for (int i = 0; i < 24; i++)
                        {
                            double a = rot + (Math.PI * 2.0 / 24.0) * i;

                            float r = 80 + (float)(40 * Math.Sin(rot * 2 + i));

                            float x = cx + (float)Math.Cos(a) * 200;
                            float y = cy + (float)Math.Sin(a) * 200;

                            Color c = Color.FromArgb(
                                180,
                                (int)(128 + 127 * Math.Sin(a)),
                                (int)(128 + 127 * Math.Sin(a + 2)),
                                (int)(128 + 127 * Math.Sin(a + 4)));

                            using (SolidBrush b = new SolidBrush(c))
                            {
                                g.FillEllipse(
                                    b,
                                    x - r / 2,
                                    y - r / 2,
                                    r,
                                    r);
                            }
                        }

                        rot += 0.03;

                        Thread.Sleep(16);
                    }
                }
            }
            finally
            {
                ReleaseDC(IntPtr.Zero, hdc);
            }
        }
    }
}
