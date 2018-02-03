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
    public partial class Form_ExaminerInfo_appendModify : Form
    {
        public bool isAppend;// true:添加, false:修改

        public string idNo = "", idTypeName = "", examinerName = "", examinerGender = "";
        public string birth = "", issuingAuthority = "", issuingDate = "", expireDate = "";
        public string office = "", operatorName = "", issuingOffice = "";

        public Form_ExaminerInfo_appendModify()
        {
            InitializeComponent();
        }

        private void Form_ExaminerInfo_appendModify_Load(object sender, EventArgs e)
        {
            comboBox_examiner_gender.Items.Clear();
            string sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=2001 order by VIEW_INDEX";
            comboBox_examiner_gender.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_examiner_idType.Items.Clear();
            sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=2002 order by VIEW_INDEX";
            comboBox_examiner_idType.Items.AddRange(mDBM.SelectArray(sql));

            if (!isAppend)
            {
                textBox_examiner_name.Text = examinerName;
                comboBox_examiner_gender.SelectedIndex = comboBox_examiner_gender.Items.IndexOf(examinerGender);
                comboBox_examiner_idType.SelectedIndex = comboBox_examiner_idType.Items.IndexOf(idTypeName);
                textBox_examiner_idNumber.Text = idNo;
                dateTimePicker_examiner_birthDate.Text = DateTime.ParseExact(birth, "yyyyMMdd", new CultureInfo("zh-CN", true)).ToString();
                textBox_examiner_issuingAuthority.Text = issuingAuthority;
                dateTimePicker_examiner_issuingDate.Text = DateTime.ParseExact(issuingDate, "yyyyMMdd", new CultureInfo("zh-CN", true)).ToString();
                dateTimePicker_examiner_expireDate.Text = DateTime.ParseExact(expireDate, "yyyyMMdd", new CultureInfo("zh-CN", true)).ToString();
                textBox_examiner_workOffice.Text = office;
                textBox_examiner_opreator.Text = operatorName;
                textBox_examiner_issuingOffice.Text = issuingOffice;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string message;

            if (String.IsNullOrEmpty(textBox_examiner_name.Text) ||
                String.IsNullOrEmpty(comboBox_examiner_gender.Text) ||
                String.IsNullOrEmpty(comboBox_examiner_idType.Text) ||
                String.IsNullOrEmpty(textBox_examiner_idNumber.Text) ||
                String.IsNullOrEmpty(dateTimePicker_examiner_birthDate.Text) ||
                String.IsNullOrEmpty(textBox_examiner_issuingAuthority.Text) ||
                String.IsNullOrEmpty(dateTimePicker_examiner_issuingDate.Text) ||
                String.IsNullOrEmpty(dateTimePicker_examiner_expireDate.Text) ||
                String.IsNullOrEmpty(textBox_examiner_workOffice.Text) ||
                String.IsNullOrEmpty(textBox_examiner_opreator.Text) ||
                String.IsNullOrEmpty(textBox_examiner_issuingOffice.Text))
            {
                MessageBox.Show("数据不能为空", "提示");
                return;
            }

            // 添加检查重名
            if (isAppend)
            {
                string sql = "select * from BAS_EXAMINER where IDNUMBER='" + textBox_examiner_idNumber.Text + "'";
                string[] names = mDBM.SelectArray(sql);

                if (names.Length > 0)
                {
                    MessageBox.Show("考试员已存在", "错误");
                    return;
                }
            }

            birth = dateTimePicker_examiner_birthDate.Value.Date.ToString("yyyyMMdd");
            issuingDate = dateTimePicker_examiner_issuingDate.Value.Date.ToString("yyyyMMdd");
            expireDate = dateTimePicker_examiner_expireDate.Value.Date.ToString("yyyyMMdd");
            mDBM.AddUpdateExaminer(textBox_examiner_idNumber.Text, comboBox_examiner_idType.Text, textBox_examiner_name.Text,
                comboBox_examiner_gender.Text, birth, textBox_examiner_issuingAuthority.Text, issuingDate, expireDate,
                textBox_examiner_workOffice.Text, textBox_examiner_opreator.Text, textBox_examiner_issuingOffice.Text, out message);

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
