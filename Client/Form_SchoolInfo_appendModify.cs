using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_SchoolInfo_appendModify : Form
    {
        public bool isAppend;// true:添加, false:修改

        public string name = "", shortName = "", code = "", address = "", contactAddress = "";
        public string contact = "", corporation = "", grade = "";

        public Form_SchoolInfo_appendModify()
        {
            InitializeComponent();
        }

        private void Form_SchoolInfo_appendModify_Load(object sender, EventArgs e)
        {
            comboBox_grade.Items.Clear();
            string sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1020 order by VIEW_INDEX";
            comboBox_grade.Items.AddRange(mDBM.SelectArray(sql));

            if (!isAppend)
            {
                textBox_name.Text = name;
                textBox_shortName.Text = shortName;
                textBox_code.Text = code;
                textBox_address.Text = address;
                textBox_contactAddress.Text = contactAddress;
                textBox_contact.Text = contact;
                textBox_corporation.Text = corporation;
                comboBox_grade.SelectedIndex = comboBox_grade.Items.IndexOf(grade);
            }
        }

        private void btn_school_save_Click(object sender, EventArgs e)
        {
            string message;

            if (String.IsNullOrEmpty(textBox_name.Text) ||
                String.IsNullOrEmpty(textBox_shortName.Text) ||
                String.IsNullOrEmpty(textBox_code.Text) ||
                String.IsNullOrEmpty(textBox_address.Text) ||
                String.IsNullOrEmpty(textBox_contactAddress.Text) ||
                String.IsNullOrEmpty(textBox_contact.Text) ||
                String.IsNullOrEmpty(textBox_corporation.Text) ||
                String.IsNullOrEmpty(comboBox_grade.Text))
            {
                MessageBox.Show("数据不能为空", "提示");
                return;
            }

            // 添加检查重名
            if (isAppend)
            {
                string sql = "select * from BAS_DRIVING_SCHOOL where CODE='" + textBox_code.Text + "'";
                string[] names = mDBM.SelectArray(sql);

                if (names.Length > 0)
                {
                    MessageBox.Show("驾校已存在", "错误");
                    return;
                }
            }
            
            mDBM.AddUpdateSchool(textBox_code.Text, textBox_name.Text, textBox_shortName.Text,
                textBox_address.Text, textBox_contactAddress.Text, textBox_contact.Text, textBox_corporation.Text, comboBox_grade.Text, out message);

            if (isAppend)
                MessageBox.Show("添加成功", "提示");
            else
                MessageBox.Show("修改成功", "提示");

            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }

        private void btn_school_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
