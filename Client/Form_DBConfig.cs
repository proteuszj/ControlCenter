using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_DBConfig : Form
    {
        private IniFile iniFile = null;

        public Form_DBConfig()
        {
            InitializeComponent();

            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            AcceptButton = btn_save;//回车响应
            btn_save.DialogResult = DialogResult.OK;
            btn_cancel.DialogResult = DialogResult.Cancel;
        }

        private void Form_DBConfig_Load(object sender, EventArgs e)
        {
            if (File.Exists(Form_Main.INIFILE_NAME))
            {
                iniFile = new IniFile(Form_Main.INIFILE_NAME);
                textBox_DBAddress.Text = iniFile.ReadValue("DBConfig", "DB Address");
                textBox_DBName.Text = iniFile.ReadValue("DBConfig", "DB Name");
                textBox_userName.Text = iniFile.ReadValue("DBConfig", "User Name");
                try
                {
                    textBox_password.Text = Algo.DESDecrypt(iniFile.ReadValue("DBConfig", "Password"));
                }
                catch
                {
                    textBox_password.Text = "";
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            iniFile.WriteValue("DBConfig", "DB Name", textBox_DBName.Text);
            iniFile.WriteValue("DBConfig", "DB Address", textBox_DBAddress.Text);
            iniFile.WriteValue("DBConfig", "User Name", textBox_userName.Text);
            iniFile.WriteValue("DBConfig", "Password", Algo.DESEncrypt(textBox_password.Text));
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            DBM DBMTest = new DBM();

            try
            {
                DBMTest.Open($"User Id={textBox_userName.Text};Password={textBox_password.Text};Data Source={textBox_DBAddress.Text}/{textBox_DBName.Text};Pooling=false;Connection Timeout=5");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误");
                return;
            }

            MessageBox.Show("数据库连接成功", "提示");
        }
    }
}
