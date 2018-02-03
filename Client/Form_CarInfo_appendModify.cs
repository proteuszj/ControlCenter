using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_CarInfo_appendModify : Form
    {
        public bool isAppend;// true:添加, false:修改

        public string licenseNo = "", subjectName = "", carNo = "", qualifiedCarTypes = "";
        public string carBrand = "", ip = "", scrapDate = "";

        public Form_CarInfo_appendModify()
        {
            InitializeComponent();
        }

        private void Form_CarInfo_appendModify_Load(object sender, EventArgs e)
        {
            comboBox_subject.Items.Clear();
            string sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1006 order by VIEW_INDEX";
            comboBox_subject.Items.AddRange(mDBM.SelectArray(sql));

            if (!isAppend)
            {
                textBox_licensePlate.Text = licenseNo;
                comboBox_subject.SelectedIndex = comboBox_subject.Items.IndexOf(subjectName);
                textBox_carNumber.Text = carNo;
                textBox_qulifiedCarType.Text = qualifiedCarTypes;
                textBox_brand.Text = carBrand;
                textBox_carIP.Text = ip;
                dateTimePicker_scrapDate.Text = DateTime.ParseExact(scrapDate, "yyyyMMdd", new CultureInfo("zh-CN", true)).ToString();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string message;
            byte[] carMap = null;

            if (String.IsNullOrEmpty(textBox_licensePlate.Text) ||
                String.IsNullOrEmpty(comboBox_subject.Text) ||
                String.IsNullOrEmpty(textBox_carNumber.Text) ||
                String.IsNullOrEmpty(textBox_qulifiedCarType.Text) ||
                String.IsNullOrEmpty(textBox_brand.Text) ||
                String.IsNullOrEmpty(textBox_carIP.Text) ||
                String.IsNullOrEmpty(dateTimePicker_scrapDate.Text))
            {
                MessageBox.Show("数据不能为空", "提示");
                return;
            }

            // 添加检查重名
            if (isAppend)
            {
                string sql = "select * from BAS_CAR_VIEW where LICENSE_PLATE='" + textBox_licensePlate.Text + "'";
                string[] names = mDBM.SelectArray(sql);

                if (names.Length > 0)
                {
                    MessageBox.Show("车辆已存在", "错误");
                    return;
                }
            }

            if (!String.IsNullOrEmpty(textBox_carMap.Text))
            {
                if (!File.Exists(textBox_carMap.Text))
                    throw new Exception("车辆轮廓地图文件不存在！");
                FileStream fs = new FileStream(textBox_carMap.Text, FileMode.Open);
                carMap = new byte[fs.Length];
                fs.Read(carMap, 0, Convert.ToInt32(fs.Length));
                fs.Close();
            }

            scrapDate = dateTimePicker_scrapDate.Value.Date.ToString("yyyyMMdd");
            mDBM.AddUpdateCar(textBox_licensePlate.Text, comboBox_subject.Text, textBox_carNumber.Text,
                textBox_qulifiedCarType.Text, textBox_brand.Text, textBox_carIP.Text, scrapDate, carMap, out message);

            if (isAppend)
                MessageBox.Show("添加成功", "提示");
            else
                MessageBox.Show("修改成功", "提示");

            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
