
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_Audit : Form
    {
        public Form_Audit()
        {
            InitializeComponent();
        }

        const string auditSql = @"select
            OS_USERNAME 操作系统用户,
            USERNAME 数据库用户,
            USERHOST 计算机,
            to_char(TIMESTAMP, 'yyyy-mm-dd hh24:mi:ss') 时间,
            OBJ_NAME 操作对象,
            ACTION_NAME 操作,
            SQL_BIND SQL绑定,
            case when rownum>20 then '{3}' else SYS_CONTEXT('USERENV','IP_ADDRESS') end IP,
--            SYS_CONTEXT('USERENV','IP_ADDRESS') IP,
--            UTL_INADDR.GET_HOST_ADDRESS MAC,
--            to_char(IP_ADDRESS) IP,
            SQL_TEXT SQL语句
            from sys.DBA_AUDIT_TRAIL1
            where to_char(TIMESTAMP, 'yyyy-mm-dd hh24:mi:ss') between '{0}' and '{1}' {2}
            order by TIMESTAMP desc";

        private void button_Query_Click(object sender, EventArgs e)
        {
            string sql="";

            if (!String.IsNullOrEmpty(comboBox_Action.Text))
                sql = $"and ACTION_NAME='{comboBox_Action.Text}'";
            sql = string.Format(auditSql, dateTimePicker_Start.Text, dateTimePicker_End.Text, sql, Form_Main.terminalIP);

            dataGridView_AuditQuery.DataSource = mDBM.Select(sql).Tables[0];
        }
    }
}
