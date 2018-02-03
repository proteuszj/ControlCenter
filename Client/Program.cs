using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        internal static Form_Main mainForm;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new Form_Main();
            Application.Run(mainForm);
        }
    }
}
