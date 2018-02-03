using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_DeviceInfo_appendModify : Form
    {
        public bool isAppend;// true:添加, false:修改

        public string deviceNo = "", deviceDescription = "", deviceManufacture = "", deviceSerial = "";

        public string examItemName = "", placeCode = "", acceptanceDate = "", expireDate = "";

        public Form_DeviceInfo_appendModify()
        {
            InitializeComponent();
        }

        private void Form_DeviceInfo_appendModify_Load(object sender, EventArgs e)
        {
            comboBox_examItemName.Items.Clear();
            string sql = "select ITEM_NAME from CFG_ITEMS where PARENT_CODE='20000'";
            comboBox_examItemName.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_placeCode.Items.Clear();
            sql = "select CODE from BAS_PLACE";
            comboBox_placeCode.Items.AddRange(mDBM.SelectArray(sql));

            if (!isAppend)
            {
                textBox_deviceNo.Text = deviceNo;
                textBox_deviceDescription.Text = deviceDescription;
                textBox_deviceManufacture.Text = deviceManufacture;
                textBox_deviceSerial.Text = deviceSerial;
                comboBox_examItemName.SelectedIndex = comboBox_examItemName.Items.IndexOf(examItemName);
                comboBox_placeCode.SelectedIndex = comboBox_placeCode.Items.IndexOf(placeCode);
                dateTimePicker_acceptanceDate.Text = DateTime.ParseExact(acceptanceDate, "yyyyMMdd", new CultureInfo("zh-CN", true)).ToString();
                dateTimePicker_expireDate.Text = DateTime.ParseExact(expireDate, "yyyyMMdd", new CultureInfo("zh-CN", true)).ToString();
            }
        }

        private void btn_device_save_Click(object sender, EventArgs e)
        {
            string message;

            if (String.IsNullOrEmpty(textBox_deviceNo.Text) ||
                String.IsNullOrEmpty(textBox_deviceDescription.Text) ||
                String.IsNullOrEmpty(textBox_deviceManufacture.Text) ||
                String.IsNullOrEmpty(textBox_deviceSerial.Text) ||
                String.IsNullOrEmpty(comboBox_examItemName.Text) ||
                String.IsNullOrEmpty(comboBox_placeCode.Text) ||
                String.IsNullOrEmpty(dateTimePicker_acceptanceDate.Text) ||
                String.IsNullOrEmpty(dateTimePicker_expireDate.Text))
            {
                MessageBox.Show("数据不能为空", "提示");
                return;
            }

            // 添加检查重名
            if (isAppend)
            {
                string sql = "select * from BAS_DEVICE_VIEW where DEVICENUMBER='" + textBox_deviceNo.Text + "'";
                string[] names = mDBM.SelectArray(sql);

                if (names.Length > 0)
                {
                    MessageBox.Show("设备已存在", "错误");
                    return;
                }
            }

            acceptanceDate = dateTimePicker_acceptanceDate.Value.Date.ToString("yyyyMMdd");
            expireDate = dateTimePicker_expireDate.Value.Date.ToString("yyyyMMdd");
            mDBM.AddUpdateDevice(textBox_deviceNo.Text, textBox_deviceDescription.Text, textBox_deviceManufacture.Text,
                textBox_deviceSerial.Text, comboBox_examItemName.Text, comboBox_placeCode.Text, acceptanceDate, expireDate, out message);

            if (isAppend)
                MessageBox.Show("添加成功", "提示");
            else
                MessageBox.Show("修改成功", "提示");

            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }

        private void btn_device_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
