
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Client.IDReader
{
    internal class IDCardInfo
    {
        public readonly string name;
        public readonly string sex;
        public readonly string birthDate;
        public readonly string idNumber;

        public IDCardInfo(string name, string sex, string birthDate, string idNumber)
        {
            this.name = name;
            this.sex = sex;
            this.birthDate = birthDate;
            this.idNumber = idNumber;
        }
    }
    class IDCardReader
    {
        internal IDCardInfo CardInfo
        {
            get
            {
                PERSONINFOW info = new PERSONINFOW();
                FPINFOW fp = new FPINFOW();
                int result = IdcrReadAllW(__ReaderDevice, info, "", fp, 1, 1);
                if (0 != result)
                {
                    StringBuilder sb = new StringBuilder(100);
                    IdcrGetErrorDescW(sb, 100, result);
                    throw new Exception(sb.ToString());
                }
                return new IDCardInfo(info.name, info.sex, info.birthDate, info.idNumber);
            }
        }

        internal static IDCardReader getInstance()
        {
            if (null == __Instance)
                __Instance = new IDCardReader();
            return __Instance;
        }

        private static IDCardReader __Instance = null;

        private static IntPtr __ReaderDevice = IntPtr.Zero;

        private IDCardReader()
        {
            int result = IdcrInitialize(1);
            if (0 != result)
            {
                StringBuilder sb = new StringBuilder(100);
                IdcrGetErrorDescW(sb, 100, result);
//                throw new Exception(sb.ToString());
            }
            int port = 0;
            result = IdcrOpen(ref port, 115200, 0, 0, ref __ReaderDevice);
            if (0 != result)
            {
                StringBuilder sb = new StringBuilder(100);
                IdcrGetErrorDescW(sb, 100, result);
                throw new Exception(sb.ToString());
            }
        }

        ~IDCardReader()
        {
            if (IntPtr.Zero != __ReaderDevice)
                IdcrClose(__ReaderDevice);
            IdcrFinalize();
        }

        [DllImport(@"IDReader\cardapi4.dll", EntryPoint = "IdcrInitialize", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int IdcrInitialize(uint dwFlags);

        [DllImport(@"IDReader\cardapi4.dll", EntryPoint = "IdcrOpen",
            CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int IdcrOpen(ref int piPort, uint dwBaudRate, uint dwCmdIntv, int iBpPort, ref IntPtr ppRD);

        [DllImport(@"IDReader\cardapi4.dll", EntryPoint = "IdcrReadAllW",
            CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int IdcrReadAllW(IntPtr pRD, [In, Out]PERSONINFOW pInfo, string pszPhotoPath,
            [In, Out]FPINFOW pFPInfo, int bRepeatRead, int bReadAppend);

        [DllImport(@"IDReader\cardapi4.dll", EntryPoint = "IdcrClose",
            CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void IdcrClose(IntPtr pRD);

        [DllImport(@"IDReader\cardapi4.dll", EntryPoint = "IdcrFinalize",
            CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void IdcrFinalize();

        [DllImport(@"IDReader\cardapi4.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern void IdcrGetErrorDescW(StringBuilder pszBuffer, uint nBufLen, int nErrorCode);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
        private class PERSONINFOW
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string name;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
            public string sexCode;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
            public string sex;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string ethnicCode;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string ethnic;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string birthDate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
            public string address;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string idNumber;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string issueAuthority;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string validTermBegin;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string validTermEnd;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
            public string appendInfo;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
        private class FPINFOW
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
            public byte[] fpData1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
            public byte[] fpData2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
            public string fName1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
            public string fName2;
        }
    }
}
