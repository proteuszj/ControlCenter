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
    public partial class Form_PlaceInfo_appendModify : Form
    {
        public bool isAppend;// true:添加, false:修改

        public string code = "", name = "", subject = "", issuingAuthority = "";
        public string branchAdministration = "", acceptanceDate = "", accepter = "";

        public Form_PlaceInfo_appendModify()
        {
            InitializeComponent();
        }

        private void Form_PlaceInfo_appendModify_Load(object sender, EventArgs e)
        {
            comboBox_subject.Items.Clear();
            string sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1006 order by VIEW_INDEX";
            comboBox_subject.Items.AddRange(mDBM.SelectArray(sql));

            if (!isAppend)
            {
                textBox_code.Text = code;
                textBox_name.Text = name;
                comboBox_subject.SelectedIndex = comboBox_subject.Items.IndexOf(subject);
                textBox_issuingAuthority.Text = issuingAuthority;
                textBox_branchAdministration.Text = branchAdministration;
                dateTimePicker_acceptanceDate.Text = DateTime.ParseExact(acceptanceDate, "yyyyMMdd", new CultureInfo("zh-CN", true)).ToString();
                textBox_accepter.Text = accepter;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string message;

            if (String.IsNullOrEmpty(textBox_code.Text) ||
                String.IsNullOrEmpty(textBox_name.Text) ||
                String.IsNullOrEmpty(comboBox_subject.Text) ||
                String.IsNullOrEmpty(textBox_issuingAuthority.Text) ||
                String.IsNullOrEmpty(textBox_branchAdministration.Text) ||
                String.IsNullOrEmpty(dateTimePicker_acceptanceDate.Text) ||
                String.IsNullOrEmpty(textBox_accepter.Text))
            {
                MessageBox.Show("数据不能为空", "提示");
                return;
            }

            // 添加检查重名
            if (isAppend)
            {
                string sql = "select * from BAS_PLACE where CODE='" + textBox_code.Text + "'";
                string[] names = mDBM.SelectArray(sql);

                if (names.Length > 0)
                {
                    MessageBox.Show("考试员已存在", "错误");
                    return;
                }
            }

            acceptanceDate = dateTimePicker_acceptanceDate.Value.Date.ToString("yyyyMMdd");
            mDBM.AddUpdatePlace(textBox_code.Text, textBox_name.Text, comboBox_subject.Text,
                textBox_issuingAuthority.Text, textBox_branchAdministration.Text, acceptanceDate, textBox_accepter.Text, out message);

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
