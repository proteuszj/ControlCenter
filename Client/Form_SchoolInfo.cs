
using Client.TMRI;
using System;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_SchoolInfo : Form
    {
        private const string schoolViewSQL = @"select 
            SEQUENCENUMBER as 序号, 
            NAME as 驾校名称, 
            SHORT_NAME as 驾校简称, 
            CODE as 驾校代码, 
            ADDRESS as 驾校地址, 
            CONTACT_ADDRESS as 联系地址, 
            CONTACT as 联系人, 
            CORPORATION as 法人代表, 
            REGISTERED_CAPITAL as 注册资金, 
            GRADE as 驾校级别, 
            QUALIFIED_CAR_TYPE as 培训准驾车型, 
            ISSUING_AUTHORITY as 所属发证机关, 
            STATUS as 驾校状态, 
            AUDITOR as 审核人, 
            CREATE_TIME as 创建时间, 
            UPDATE_TIME as 更新时间 
            from BAS_DRIVING_SCHOOL_VIEW";

        public Form_SchoolInfo()
        {
            InitializeComponent();
        }

        private void Form_SchoolInfo_Load(object sender, EventArgs e)
        {
            dataGridView_school.DataSource = mDBM.Select(schoolViewSQL).Tables[0];
        }

        private void btn_school_append_Click(object sender, EventArgs e)
        {
            Form_SchoolInfo_appendModify form_SchoolInfo_appendModify = new Form_SchoolInfo_appendModify();
            form_SchoolInfo_appendModify.isAppend = true;
            form_SchoolInfo_appendModify.Text = "驾校信息添加";

            if (form_SchoolInfo_appendModify.ShowDialog() == DialogResult.OK)
                dataGridView_school.DataSource = mDBM.Select(schoolViewSQL).Tables[0];
        }

        private void dataGridView_school_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Form_SchoolInfo_appendModify form_SchoolInfo_appendModify = new Form_SchoolInfo_appendModify();
                form_SchoolInfo_appendModify.isAppend = false;
                form_SchoolInfo_appendModify.Text = "驾校信息修改";

                form_SchoolInfo_appendModify.name = dataGridView_school.Rows[e.RowIndex].Cells["驾校名称"].Value.ToString();
                form_SchoolInfo_appendModify.shortName = dataGridView_school.Rows[e.RowIndex].Cells["驾校简称"].Value.ToString();
                form_SchoolInfo_appendModify.code = dataGridView_school.Rows[e.RowIndex].Cells["驾校代码"].Value.ToString();
                form_SchoolInfo_appendModify.address = dataGridView_school.Rows[e.RowIndex].Cells["驾校地址"].Value.ToString();
                form_SchoolInfo_appendModify.contactAddress = dataGridView_school.Rows[e.RowIndex].Cells["联系地址"].Value.ToString();
                form_SchoolInfo_appendModify.contact = dataGridView_school.Rows[e.RowIndex].Cells["联系人"].Value.ToString();
                form_SchoolInfo_appendModify.corporation = dataGridView_school.Rows[e.RowIndex].Cells["法人代表"].Value.ToString();
                form_SchoolInfo_appendModify.grade = dataGridView_school.Rows[e.RowIndex].Cells["驾校级别"].Value.ToString();

                if (form_SchoolInfo_appendModify.ShowDialog() == DialogResult.OK)
                    dataGridView_school.DataSource = mDBM.Select(schoolViewSQL).Tables[0];
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            string message;
            TMRIQuery.QuerySchool(out message, textBox_fzjg.Text, textBox_gxsj.Text);
            MessageBox.Show(message);
            dataGridView_school.DataSource = mDBM.Select(schoolViewSQL).Tables[0];
        }

        private void dateTimePicker_gxsj_ValueChanged(object sender, EventArgs e)
        {
            if ((sender as DateTimePicker).Checked)
                textBox_gxsj.Text = dateTimePicker_gxsj.Text;
            else textBox_gxsj.Clear();
        }
    }
}
