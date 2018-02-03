
using System;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_User : Form
    {
        private const string userViewSQL = @"select 
            LOGIN_NAME as 登录名, 
            LOCKED_STATUS as 锁定状态, 
            USER_NAME as 姓名, 
            GENDER_DICT_NAME as 性别, 
            IDNUMBER as 身份证明号码, 
            USER_FLAG_DICT_NAME as 用户标识, 
            USERNUMBER as 用户编号,
            STATUS_DICT_NAME as 状态, 
            MAX_FAILURE_COUNT as 最大连续失败次数,
            ROLE_NAME as 角色, 
            PASSWORD_MODIFY_DATE as 密码修改日期, 
            ENABLE_DATE as 用户启用日期, 
            DISABLE_DATE as 用户停用日期, 
            QUALIFIED_START_TIME as 允许登录开始时间, 
            QUALIFIED_END_TIME as 允许登录结束时间,
            QUALIFIED_ADDRESS_LIST as 允许登录地址列表
            from SYS_USER_VIEW";

        public Form_User()
        {
            InitializeComponent();
        }

        private void Form_User_Load(object sender, EventArgs e)
        {
            dataGridView_user.DataSource = mDBM.Select(userViewSQL).Tables[0];

            comboBox_lockStatus.Items.Clear();
            comboBox_lockStatus.Items.Add("已锁定");
            comboBox_lockStatus.Items.Add("未锁定");
        }

        private void btn_append_Click(object sender, EventArgs e)
        {
            Form_User_appendModify form_user_appendModify = new Form_User_appendModify();
            form_user_appendModify.isAppend = true;
            form_user_appendModify.Text = "用户添加";
            form_user_appendModify.textBox_IP.Text = Form_Main.terminalIP;
            form_user_appendModify.textBox_MAC.Text = Form_Main.terminalMAC;

            if (form_user_appendModify.ShowDialog() == DialogResult.OK)
                dataGridView_user.DataSource = mDBM.Select(userViewSQL).Tables[0];
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string sql = "";

            if (!String.IsNullOrEmpty(textBox_loginName.Text))
            {
                sql += "LOGIN_NAME='" + textBox_loginName.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_name.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "USER_NAME='" + textBox_name.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_userNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "USERNUMBER='" + textBox_userNumber.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_idNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "IDNUMBER='" + textBox_idNumber.Text + "'";
            }
            if (!String.IsNullOrEmpty(comboBox_lockStatus.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "LOCKED_STATUS='" + comboBox_lockStatus.Text + "'";
            }

            sql = userViewSQL + (sql == "" ? "" : " where " + sql);
            dataGridView_user.DataSource = mDBM.Select(sql).Tables[0];
        }

        private void dataGridView_user_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Form_User_appendModify form_user_appendModify = new Form_User_appendModify();
                form_user_appendModify.isAppend = false;
                form_user_appendModify.Text = "用户修改";

                form_user_appendModify.loginName = dataGridView_user.Rows[e.RowIndex].Cells["登录名"].Value.ToString();
                form_user_appendModify.userName = dataGridView_user.Rows[e.RowIndex].Cells["姓名"].Value.ToString();
                form_user_appendModify.gender = dataGridView_user.Rows[e.RowIndex].Cells["性别"].Value.ToString();
                form_user_appendModify.idNo = dataGridView_user.Rows[e.RowIndex].Cells["身份证明号码"].Value.ToString();
                form_user_appendModify.userNo = dataGridView_user.Rows[e.RowIndex].Cells["用户编号"].Value.ToString();
                form_user_appendModify.userFlag = dataGridView_user.Rows[e.RowIndex].Cells["用户标识"].Value.ToString();
                form_user_appendModify.maxFailureCount = dataGridView_user.Rows[e.RowIndex].Cells["最大连续失败次数"].Value.ToString();
                form_user_appendModify.passwordModifyDate = dataGridView_user.Rows[e.RowIndex].Cells["密码修改日期"].Value.ToString();
                form_user_appendModify.enableDate = dataGridView_user.Rows[e.RowIndex].Cells["用户启用日期"].Value.ToString();
                form_user_appendModify.disableDate = dataGridView_user.Rows[e.RowIndex].Cells["用户停用日期"].Value.ToString();
                form_user_appendModify.role = dataGridView_user.Rows[e.RowIndex].Cells["角色"].Value.ToString();
                form_user_appendModify.qualifiedStartTime = dataGridView_user.Rows[e.RowIndex].Cells["允许登录开始时间"].Value.ToString();
                form_user_appendModify.qualifiedEndTime = dataGridView_user.Rows[e.RowIndex].Cells["允许登录结束时间"].Value.ToString();
                form_user_appendModify.qualifiedAddressList = dataGridView_user.Rows[e.RowIndex].Cells["允许登录地址列表"].Value.ToString();
                form_user_appendModify.button_unblock.Enabled = "已锁定" == dataGridView_user.Rows[e.RowIndex].Cells["锁定状态"].Value.ToString();
                form_user_appendModify.textBox_IP.Text = Form_Main.terminalIP;
                form_user_appendModify.textBox_MAC.Text = Form_Main.terminalMAC;
                if (form_user_appendModify.ShowDialog() == DialogResult.OK)
                    dataGridView_user.DataSource = mDBM.Select(userViewSQL).Tables[0];
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (1 != dataGridView_user.SelectedCells.Count) return;
            string user = dataGridView_user.SelectedCells[0].OwningRow.Cells["登录名"].Value.ToString();
            if (DialogResult.OK == MessageBox.Show($"用户{user}即将被删除，是否继续？", "警告", MessageBoxButtons.OKCancel))
            {
                string message;
                mDBM.RemoveUser(out message, user);
                MessageBox.Show(message);
                dataGridView_user.DataSource = mDBM.Select(userViewSQL).Tables[0];
            }
        }
    }
}
