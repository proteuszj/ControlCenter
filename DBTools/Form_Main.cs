#define upgradeOnly

using Oracle.ManagedDataAccess.Client;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DBTools
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
#if upgradeOnly
            panel_restore.Visible = false;
            button_scriptFile.Enabled = false;
            textBox_scriptFile.Enabled = false;
            string productName = "数据库升级工具";
#else
            string productName = ((AssemblyProductAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0]).Product;
#endif
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Text = String.Format("{0} v{1}", productName, version);
            folderBrowserDialog_backup.SelectedPath = Application.StartupPath;
            openFileDialog_restore.InitialDirectory = Application.StartupPath;
            openFileDialog_script.InitialDirectory = Application.StartupPath;
            updateFileName();
        }

        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                panel_connection.Visible = !panel_connection.Visible;
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection($"User Id={textBox_user.Text};Password={textBox_password.Text};Data Source={textBox_address.Text}:{textBox_port.Text}/{textBox_SID.Text};Pooling=false;");
            try
            {
                conn.Open();
                MessageBox.Show("连接成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_targetFolder_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog_backup.ShowDialog())
                updateFileName();
        }

        void updateFileName()
        {
            string dateString = checkBox_addDate.Checked ? "_" + DateTime.Now.Date.ToString("yyyyMMdd") : "";
            string timeString = checkBox_addTime.Checked ? "_" + DateTime.Now.ToLocalTime().ToString("hhmmss") : "";
            string pathString = folderBrowserDialog_backup.SelectedPath;
            if ("\\" != pathString.Substring(pathString.Length - 1, 1))
                pathString += "\\";
            label_FileName.Text = $"{pathString}{textBox_baseName.Text}{dateString}{timeString}";
        }

        private void textBox_baseName_TextChanged(object sender, EventArgs e)
        {
            updateFileName();
        }

        private void button_backup_Click(object sender, EventArgs e)
        {
            Process.Start("exp", $"{textBox_user.Text}/{textBox_password.Text}@{textBox_SID.Text} file={label_FileName.Text}.dmp log={label_FileName.Text}.log buffer=65535").WaitForExit();
            MessageBox.Show("备份完成");
        }

        private void button_openFile_Click(object sender, EventArgs e)
        {
            if (button_restore == sender)
            {
                if (DialogResult.OK == openFileDialog_restore.ShowDialog())
                    textBox_restoreFile.Text = openFileDialog_restore.FileName;
            }
            else if (button_scriptFile == sender)
            {
                if (DialogResult.OK == openFileDialog_script.ShowDialog())
                    textBox_scriptFile.Text = openFileDialog_script.FileName;
            }
        }

        private void textBox_File_TextChanged(object sender, EventArgs e)
        {
            if (textBox_restoreFile == sender)
                button_restore.Enabled = !string.IsNullOrEmpty((sender as TextBox).Text);
            else if (textBox_scriptFile == sender)
                button_run.Enabled = !string.IsNullOrEmpty((sender as TextBox).Text);
        }

        private void button_restore_Click(object sender, EventArgs e)
        {
            Process.Start("imp", $"{textBox_user.Text}/{textBox_password.Text}@{textBox_SID.Text} file={textBox_restoreFile.Text} full=y").WaitForExit();
            MessageBox.Show("恢复完成");
        }

        private void button_run_Click(object sender, EventArgs e)
        {
#if upgradeOnly
            FileStream fs = new FileStream(Application.StartupPath + @"\upgrade.sql", FileMode.Create);
            fs.Write(Properties.Resources.upgrade, 0, Properties.Resources.upgrade.Length);
            fs.Close();
            string param = $"{textBox_user.Text}/{textBox_password.Text}@{textBox_SID.Text} @{Application.StartupPath}\\upgrade.sql";
            Process.Start("sqlplus", param).WaitForExit();
            File.Delete(Application.StartupPath + @"\upgrade.sql");
#else
            if (File.Exists(textBox_scriptFile.Text))
                Process.Start("sqlplus", $"{textBox_user.Text}/{textBox_password.Text}@{textBox_SID.Text} @{textBox_scriptFile.Text}").WaitForExit();
#endif
        }
    }
}
