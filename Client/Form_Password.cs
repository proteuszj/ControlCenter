
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_Password : Form
    {
        public Form_Password()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;

            if ("教练员" == Form_Main.RoleName)
            {
                if (textBox_newPassword1.Text.Length < 6)
                {
                    label_hint.Text = "密码长度不能小于6！";
                    return;
                }
                if (textBox_oldPassword.Text.Equals(textBox_newPassword1.Text))
                {
                    label_hint.Text = "新密码与旧密码相同！";
                    return;
                }
                if (!textBox_newPassword1.Text.Equals(textBox_newPassword2.Text))
                {
                    label_hint.Text = "新密码与确认密码不同！";
                    return;
                }

            }
            else
            {
                if (textBox_newPassword1.Text.Length < 8)
                {
                    label_hint.Text = "密码长度不能小于8！";
                    return;
                }

                if (textBox_oldPassword.Text.Equals(textBox_newPassword1.Text))
                {
                    label_hint.Text = "新密码与旧密码相同！";
                    return;
                }

                if (!textBox_newPassword1.Text.Equals(textBox_newPassword2.Text))
                {
                    label_hint.Text = "新密码与确认密码不同！";
                    return;
                }

                if (textBox_newPassword1.Text.Contains(mDBM.loginName))
                {
                    label_hint.Text = "密码不能包含登录名！";
                    return;
                }

                int x = 0;
                Regex regex;
                string[] checkContent = { "[A-Z]+", "[a-z]+", "[0-9]+", "[^A-Za-z0-9]+" };
                foreach (string check in checkContent)
                {
                    regex = new Regex(check);
                    if (regex.IsMatch(textBox_newPassword1.Text))
                        x++;
                }
                if (x < 3)
                {
                    label_hint.Text = "密码至少需要包含大、小写字母、数字和特殊字符中的三种！";
                    return;
                }
            }

            string message;
            int result = mDBM.ChangePassword(textBox_oldPassword.Text, textBox_newPassword1.Text, out message);

            MessageBox.Show(message, "提示");
            if (0 != result) DialogResult = DialogResult.Abort; //ChangePassword executed but failed
            else DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }
    }
}
