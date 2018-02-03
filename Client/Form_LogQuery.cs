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
    public partial class Form_LogQuery : Form
    {
        private const string logViewSQL = @"select 
            VERIFY as 校验, 
            USER_LOGIN_NAME as 登录名, 
            TIME as 操作时间, 
            SOURCE as 操作模块, 
            ACTION as 操作行为, 
            CONTENT as 操作内容, 
            RESULT as 操作结果, 
            IP as IP地址, 
            MAC as MAC地址, 
            HASH as 哈希 
            from SYS_LOG_VIEW";

        public Form_LogQuery()
        {
            InitializeComponent();
        }

        private void Form_LogQuery_Load(object sender, EventArgs e)
        {
            comboBox_operationAction.Items.Clear();
            comboBox_operationAction.Items.AddRange(mDBM.SelectArray("select DICT_NAME from CFG_DICT where DICT_TYPE=1028 order by VIEW_INDEX"));

            for (int i = 0; i < dataGridView_logQuery.Columns.Count; i++)
                dataGridView_logQuery.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string sql = "";

            if (!String.IsNullOrEmpty(textBox_loginName.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "USER_LOGIN_NAME='" + textBox_loginName.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_operationModule.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "SOURCE='" + textBox_operationModule.Text + "'";
            }
            if (!String.IsNullOrEmpty(comboBox_operationAction.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "ACTION='" + comboBox_operationAction.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_ip.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "IP='" + textBox_ip.Text + "'";
            }
            if (!String.IsNullOrEmpty(dateTimePicker_start.Value.Date.ToString("yyyyMMdd")))
            {
                sql += sql == "" ? "" : " and ";
                sql += "TIME>='" + dateTimePicker_start.Value.Date.ToString("yyyyMMdd") + "000000'";
            }
            if (!String.IsNullOrEmpty(dateTimePicker_end.Value.Date.ToString("yyyyMMdd")))
            {
                sql += sql == "" ? "" : " and ";
                sql += "TIME<='" + dateTimePicker_end.Value.Date.ToString("yyyyMMdd") + "235959'";
            }

            sql = logViewSQL + (sql == "" ? "" : " where " + sql);
            dataGridView_logQuery.DataSource = mDBM.Select(sql).Tables[0];

            bool warning = false;
            int warningCount = 0;
            for (int i = 0; i < dataGridView_logQuery.RowCount; i++)
                if (dataGridView_logQuery.Rows[i].Cells["校验"].Value.ToString() == "FALSE")
                {
                    warning = true;
                    warningCount++;
                    dataGridView_logQuery.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            if (warning)
            {
                MessageBox.Show($"{warningCount}组数据被篡改", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Form_LogQuery_Shown(object sender, EventArgs e)
        {
            btn_search_Click(this, new EventArgs());
        }
    }
}
