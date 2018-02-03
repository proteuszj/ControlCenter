
using libzkfpcsharp;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_User_appendModify : Form
    {
        public bool isAppend;// true:添加, false:修改

        public string loginName = "", userName = "", gender = "", idNo = "", userNo = "", userFlag = "", maxFailureCount = "", role = "";
        public string passwordModifyDate = "", enableDate = "", disableDate = "", qualifiedStartTime = "", qualifiedEndTime = "", qualifiedAddressList = "";

        Regex regexIP = new Regex(@"^\d(\d?){2}(\.\d(\d?){2}){3}$");
        Regex regexMAC1 = new Regex(@"^[a-fA-F0-9]{2}(:[a-fA-F0-9]{2}){5}$");
        Regex regexMAC2 = new Regex(@"^[a-fA-F0-9]{2}(-[a-fA-F0-9]{2}){5}$");

        byte[] RegTmp;

        private void button_fpRegister_Click(object sender, EventArgs e)
        {
            IntPtr mDevHandle = IntPtr.Zero;
            IntPtr mDBHandle = IntPtr.Zero;
            const int REGISTER_FINGER_COUNT = 3;
            byte[][] RegTmps = new byte[3][];
            byte[] FPBuffer;
            byte[] CapTmp = new byte[2048];
            int mfpWidth = 0;
            int mfpHeight = 0;
            int result = zkfp2.Init();
            try
            {
                if (zkfperrdef.ZKFP_ERR_OK == result && zkfp2.GetDeviceCount() > 0)
                {
                    if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(0)))
                    {
                        MessageBox.Show("指纹仪打开设备失败");
                        return;
                    }
                    if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
                    {
                        MessageBox.Show("指纹仪算法库初始化失败");
                        zkfp2.CloseDevice(mDevHandle);
                        mDevHandle = IntPtr.Zero;
                        return;
                    }
                    byte[] paramValue = new byte[4];
                    int size = 4;
                    zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
                    zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

                    size = 4;
                    zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
                    zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

                    FPBuffer = new byte[mfpWidth * mfpHeight];

                    int len;
                    for (int i = 0; i < REGISTER_FINGER_COUNT; i++)
                    {
                        button_fpRegister.Text = (REGISTER_FINGER_COUNT - i).ToString();
                        RegTmps[i] = new byte[2048];
                        len = 2048;
                        while (zkfp.ZKFP_ERR_OK != zkfp2.AcquireFingerprint(mDevHandle, FPBuffer, CapTmp, ref len))
                        {
                            Application.DoEvents();
                            Thread.Sleep(200);
                        }
                        MemoryStream ms = new MemoryStream();
                        BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                        pictureBox_fp.Image = new Bitmap(ms);
                        if (i > 0 && zkfp2.DBMatch(mDBHandle, CapTmp, RegTmps[i - 1]) <= 0)
                        {
                            MessageBox.Show("指纹不匹配，请使用同一手指采集指纹");
                            button_fpRegister.Text = "登记指纹";
                            pictureBox_fp.Image = null;
                            zkfp2.CloseDevice(mDevHandle);
                            mDevHandle = IntPtr.Zero;
                            return;
                        }
                        Array.Copy(CapTmp, RegTmps[i], len);
                    }
                    button_fpRegister.Text = "登记指纹";
                    len = 2048;
                    byte[] buffer = new byte[len];
                    if (zkfp.ZKFP_ERR_OK == zkfp2.DBMerge(mDBHandle, RegTmps[0], RegTmps[1], RegTmps[2], buffer, ref len))
                    {
                        RegTmp = new byte[len];
                        Array.Copy(buffer, RegTmp, len);
                        MessageBox.Show("指纹登记成功");
                    }
                    zkfp2.CloseDevice(mDevHandle);
                    mDevHandle = IntPtr.Zero;
                }
            }
            finally
            {
                zkfp2.Terminate();
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            if (!regexIP.IsMatch(textBox_IP.Text)) message += "IP地址格式不正确";
            if (!regexMAC1.IsMatch(textBox_MAC.Text) && !regexMAC2.IsMatch(textBox_MAC.Text)) message += "MAC地址格式不正确";
            if (string.IsNullOrEmpty(message))
                listBox_qualifiedAddressList.Items.Add(string.Format($"{textBox_IP.Text}({textBox_MAC.Text})"));
            else
                MessageBox.Show(message, "提示");
        }

        private void button_unblock_Click(object sender, EventArgs e)
        {
            string message;
            mDBM.UnblockUser(textBox_loginName.Text, out message);
            MessageBox.Show(message, "提示");
            DialogResult = DialogResult.OK;
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (listBox_qualifiedAddressList.SelectedIndex >= 0)
                listBox_qualifiedAddressList.Items.RemoveAt(listBox_qualifiedAddressList.SelectedIndex);
        }

        private void Form_User_appendModify_Load(object sender, EventArgs e)
        {
            string sql;

            comboBox_gender.Items.Clear();
            sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=2001 order by VIEW_INDEX";
            comboBox_gender.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_roleName.Items.Clear();
            sql = "select NAME from SYS_ROLE";
            comboBox_roleName.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_userFlag.Items.Clear();
            sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1010 order by VIEW_INDEX";
            comboBox_userFlag.Items.AddRange(mDBM.SelectArray(sql));

            if (isAppend)
            {
                textBox_loginName.Enabled = true;
                comboBox_gender.SelectedIndex = 0;
                dateTimePicker_qualifiedEndTime.Value = DateTime.Now + new TimeSpan(1, 0, 0);
            }
            else
            {
                textBox_loginName.Enabled = false;

                textBox_loginName.Text = loginName;
                textBox_userName.Text = userName;
                textBox_idNo.Text = idNo;
                textBox_userNo.Text = userNo;
                textBox_maxFailureCount.Text = maxFailureCount;

                comboBox_gender.SelectedIndex = comboBox_gender.Items.IndexOf(gender);
                comboBox_roleName.SelectedIndex = comboBox_roleName.Items.IndexOf(role);
                comboBox_userFlag.SelectedIndex = comboBox_userFlag.Items.IndexOf(userFlag);
                dateTimePicker_passwordModifyDate.Checked = !string.IsNullOrEmpty(passwordModifyDate);
                if (!string.IsNullOrEmpty(passwordModifyDate))
                    dateTimePicker_passwordModifyDate.Text = DateTime.ParseExact(passwordModifyDate, "yyyyMMdd", new CultureInfo("zh-CN", true)).ToString();
                dateTimePicker_enableDate.Checked = !String.IsNullOrEmpty(enableDate);
                if (!String.IsNullOrEmpty(enableDate))
                    dateTimePicker_enableDate.Text = DateTime.ParseExact(enableDate, "yyyyMMdd", new CultureInfo("zh-CN", true)).ToString();
                dateTimePicker_disableDate.Checked = !String.IsNullOrEmpty(disableDate);
                if (!String.IsNullOrEmpty(disableDate))
                    dateTimePicker_disableDate.Text = DateTime.ParseExact(disableDate, "yyyyMMdd", new CultureInfo("zh-CN", true)).ToString();
                dateTimePicker_qualifiedStartTime.Checked = !String.IsNullOrEmpty(qualifiedStartTime);
                if (!String.IsNullOrEmpty(qualifiedStartTime))
                    dateTimePicker_qualifiedStartTime.Text = DateTime.ParseExact(qualifiedStartTime, "HHmmss", new CultureInfo("zh-CN", true)).ToString();
                dateTimePicker_qualifiedEndTime.Checked = !String.IsNullOrEmpty(qualifiedEndTime);
                if (!String.IsNullOrEmpty(qualifiedEndTime))
                    dateTimePicker_qualifiedEndTime.Text = DateTime.ParseExact(qualifiedEndTime, "HHmmss", new CultureInfo("zh-CN", true)).ToString();
                //richTextBox_qualifiedAddressList.Text = qualifiedAddressList;
                string[] addressList = qualifiedAddressList.Split(';');
                for (int i = 0; i < addressList.Length; i++) listBox_qualifiedAddressList.Items.Add(addressList[i]);
            }
        }

        public Form_User_appendModify()
        {
            InitializeComponent();
        }

        private void btn_user_save_Click(object sender, EventArgs e)
        {
            string message;

            if (String.IsNullOrEmpty(textBox_loginName.Text) ||
                String.IsNullOrEmpty(textBox_userName.Text) ||
                String.IsNullOrEmpty(comboBox_gender.Text) ||
                String.IsNullOrEmpty(textBox_idNo.Text) ||
                String.IsNullOrEmpty(comboBox_userFlag.Text) ||
                String.IsNullOrEmpty(textBox_userNo.Text) ||
                String.IsNullOrEmpty(comboBox_roleName.Text))
            {
                MessageBox.Show("数据不能为空", "提示");
                return;
            }

            // 添加检查重名
            if (isAppend)
            {
                string sql = "select LOGIN_NAME from SYS_USER where LOGIN_NAME='" + textBox_loginName.Text + "'";
                string[] names = mDBM.SelectArray(sql);

                if (names.Length > 0)
                {
                    MessageBox.Show("用户已存在", "错误");
                    return;
                }
            }
            string addressList = string.Empty;

            for (int i = 0; i < listBox_qualifiedAddressList.Items.Count; i++)
                if (!string.IsNullOrEmpty(listBox_qualifiedAddressList.Items[i].ToString()))
                {
                    addressList += listBox_qualifiedAddressList.Items[i];
                    if (i < listBox_qualifiedAddressList.Items.Count - 1)
                        addressList += ";";
                }

            if (mDBM.AddUpateUser(
                textBox_loginName.Text,
                textBox_userName.Text,
                comboBox_gender.Text,
                textBox_idNo.Text,
                comboBox_userFlag.Text,
                textBox_userNo.Text,
                RegTmp,
                textBox_maxFailureCount.Text,
                dateTimePicker_passwordModifyDate.Checked ? dateTimePicker_passwordModifyDate.Value.ToString("yyyyMMdd") : null,
                dateTimePicker_enableDate.Checked ? dateTimePicker_enableDate.Value.ToString("yyyyMMdd") : null,
                dateTimePicker_disableDate.Checked ? dateTimePicker_disableDate.Value.ToString("yyyyMMdd") : null,
                comboBox_roleName.Text,
                dateTimePicker_qualifiedStartTime.Checked ? dateTimePicker_qualifiedStartTime.Value.ToString("HHmmss") : null,
                dateTimePicker_qualifiedEndTime.Checked ? dateTimePicker_qualifiedEndTime.Value.ToString("HHmmss") : null,
                addressList,
                out message) != 0)
            {
                MessageBox.Show(message, "错误");
                return;
            }

            if (isAppend)
                MessageBox.Show("添加成功", "提示");
            else
                MessageBox.Show("修改成功", "提示");

            this.DialogResult = DialogResult.OK;
            this.Close();
            //            this.Dispose();
        }

        private void btn_user_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            //            this.Dispose();
        }
    }
}
