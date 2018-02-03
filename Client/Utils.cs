
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Client
{
    internal static class Utils
    {
        internal static bool SaveToExcel(DataGridView dgv, string[] additionalMessage, string filePath, out string message)
        {
            int lineNum = 1;
            if (dgv.RowCount < 1)
            {
                message = "数据内容为空";
                return false;
            }
            Excel.Application excelApp = new Excel.Application();
            if (null == excelApp)
            {
                message = "Excel互操作不支持";
                return false;
            }
            Excel.Worksheet worksheet = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet).Worksheets[1];

            if (null != additionalMessage && additionalMessage.Length > 0)
            {
                worksheet.Cells[lineNum, 1] = "检索条件";
                for (int i = 0; i < additionalMessage.Length; i++)
                    worksheet.Cells[lineNum, i + 2] = additionalMessage[i];
                lineNum++;
                lineNum++;
            }
            int index = 2;
            for (int j = 0; j < dgv.ColumnCount; j++)
                if (dgv.Columns[j].Visible)
                    worksheet.Cells[lineNum, index++] = dgv.Columns[j].HeaderText;
            lineNum++;

            for (int i = 0; i < dgv.RowCount; i++)
            {
                worksheet.Cells[lineNum, 1] = dgv.Rows[i].HeaderCell.Value;
                index = 2;
                for (int j = 0; j < dgv.ColumnCount; j++)
                    if (dgv.Columns[j].Visible)
                        worksheet.Cells[lineNum, index++] = "'" + dgv.Rows[i].Cells[j].Value;
                lineNum++;
                Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();
            bool flag = true;
            try
            {
                try
                {
                    worksheet.SaveAs(filePath);
                    message = "导出文件成功";
                }
                catch (Exception ex)
                {
                    message = $"写入文件失败：{ex.Message}";
                    flag = false;
                }
            }
            finally
            {
                excelApp.Quit();
                GC.Collect();
            }
            return flag;
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool SetLocalTime(ref SYSTEMTIME lpSystemTime);

        //  DWORD WINAPI FormatMessage(
        //  _In_     DWORD   dwFlags,
        //  _In_opt_ LPCVOID lpSource,
        //  _In_     DWORD   dwMessageId,
        //  _In_     DWORD   dwLanguageId,
        //  _Out_    LPTSTR  lpBuffer,
        //  _In_     DWORD   nSize,
        //  _In_opt_ va_list *Arguments
        //);
        [DllImport("Kernel32.dll")]
        static extern UInt32 FormatMessage(UInt32 dwFlags, string lpSource, UInt32 dwMessageId, UInt32 dwLanguageId, StringBuilder lpBuffer, UInt32 nSize, IntPtr Arguments);

        //DWORD WINAPI GetLastError(void);
        [DllImport("Kernel32.dll")]
        internal static extern UInt32 GetLastError();

        /// <summary>
        /// Format error message from system message-table according to error code
        /// </summary>
        /// <param name="errorCode">error code from GetLastError()</param>
        /// <returns>error message</returns>
        internal static string GetSystemErrorMessage(UInt32 errorCode)
        {
            uint size = 100;
            StringBuilder sb = new StringBuilder((int)size);
            size = FormatMessage(FORMAT_MESSAGE_IGNORE_INSERTS | FORMAT_MESSAGE_FROM_SYSTEM, null, errorCode, 0x0409, sb, size, IntPtr.Zero);
            if (0 == size) return "";
            return sb.ToString();
        }//end of method

        /// <summary>
        /// Convert a byte array to hex string like "A0A1A2"
        /// </summary>
        /// <param name="array">array of bytes</param>
        /// <returns>hex string in upper case</returns>
        internal static string convertByteArrayToHexString(byte[] array)
        {
            if (null == array || 0 == array.Length) return "";
            StringBuilder sb = new StringBuilder(array.Length * 2);
            for (int i = 0; i < array.Length; i++)
                sb.Append(array[i].ToString("X2"));
            return sb.ToString();
        }//end of method

        /// <summary>
        /// 检查身份证明号码
        /// </summary>
        /// <param name="idNumber">身份证明号码</param>
        /// <param name="message">错误信息</param>
        /// <returns>true/false</returns>
        internal static bool CheckIDNumber(string idNumber, out string message)
        {
            message = "";

            if (idNumber.Length != 18)
            {
                message = "长度错误";
                return false;
            }

            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(idNumber))
            {
                message = "不能包含除数字以外的字符";
                return false;
            }

            return true;
        }

        /// <summary>
        /// 日期检查
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="message">错误信息</param>
        /// <returns>true/false</returns>
        internal static bool CheckDate(string date, out string message)
        {
            message = "";

            if (date.Length != 8)
            {
                message = "长度错误";
                return false;
            }

            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(date))
            {
                message = "不能包含除数字以外的字符";
                return false;
            }

            return true;
        }

        /// <summary>
        /// 时间检查
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="message">错误信息</param>
        /// <returns>true/false</returns>
        public static bool CheckTime(string time, out string message)
        {
            message = "";

            if (time.Length != 6)
            {
                message = "长度错误";
                return false;
            }

            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(time))
            {
                message = "不能包含除数字以外的字符";
                return false;
            }

            return true;
        }

        const UInt32 FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
        const UInt16 FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;

        [StructLayout(LayoutKind.Sequential)]
        internal struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;    // ignored for the SetLocalTime function
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }
    }
}
