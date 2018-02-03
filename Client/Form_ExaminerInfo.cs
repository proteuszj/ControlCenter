
using Client.TMRI;
using System;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_ExaminerInfo : Form
    {
        private const string examinerViewSQL = @"select 
            SEQUENCENUMBER as 序号, 
            NAME as 姓名, 
            GENDER_DICT_NAME as 性别, 
            ID_TYPE_DICT_NAME as 身份证明类型, 
            IDNUMBER as 身份证明号码, 
            BIRTH_DATE as 出生日期, 
            ISSUING_AUTHORITY as 所属发证机关, 
            BRANCH_ADMINISTRATION as 管理部门, 
            ARCHIVESNUMBER as 驾驶证档案编号, 
            QUALIFIED_CAR_TYPE as 考试准驾车型范围, 
            ISSUING_DATE as 发证日期, 
            EXPIRE_DATE as 有效截止日期, 
            STATUS_DICT_NAME as 考试员状态, 
            WORK_OFFICE as 工作单位, 
            OPERATOR_NAME as 经办人, 
            ISSUING_OFFICE as 考试员证发证单位, 
            CREATE_TIME as 创建时间, 
            UPDATE_TIME as 更新时间
            from BAS_EXAMINER_VIEW";

        public Form_ExaminerInfo()
        {
            InitializeComponent();
        }

        private void Form_ExaminerInfo_Load(object sender, EventArgs e)
        {
            dataGridView_examiner.DataSource = mDBM.Select(examinerViewSQL).Tables[0];
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string sql = "";

            if (!String.IsNullOrEmpty(textBox_name.Text))
            {
                sql += "NAME='" + textBox_name.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_idNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "IDNUMBER='" + textBox_idNumber.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_archivesNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "ARCHIVESNUMBER='" + textBox_archivesNumber.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_issuingOffice.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "ISSUING_OFFICE='" + textBox_issuingOffice.Text + "'";
            }

            sql = examinerViewSQL + (sql == "" ? "" : " where " + sql);
            dataGridView_examiner.DataSource = mDBM.Select(sql).Tables[0];
        }

        private void btn_examiner_append_Click(object sender, EventArgs e)
        {
            Form_ExaminerInfo_appendModify form_ExaminerInfo_appendModify = new Form_ExaminerInfo_appendModify();
            form_ExaminerInfo_appendModify.isAppend = true;
            form_ExaminerInfo_appendModify.Text = "考试员信息添加";

            if (form_ExaminerInfo_appendModify.ShowDialog() == DialogResult.OK)
                dataGridView_examiner.DataSource = mDBM.Select(examinerViewSQL).Tables[0];
        }

        private void dataGridView_examiner_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Form_ExaminerInfo_appendModify form_ExaminerInfo_appendModify = new Form_ExaminerInfo_appendModify();
                form_ExaminerInfo_appendModify.isAppend = false;
                form_ExaminerInfo_appendModify.Text = "考试员信息修改";

                form_ExaminerInfo_appendModify.idNo = dataGridView_examiner.Rows[e.RowIndex].Cells["身份证明号码"].Value.ToString();
                form_ExaminerInfo_appendModify.idTypeName = dataGridView_examiner.Rows[e.RowIndex].Cells["身份证明类型"].Value.ToString();
                form_ExaminerInfo_appendModify.examinerName = dataGridView_examiner.Rows[e.RowIndex].Cells["姓名"].Value.ToString();
                form_ExaminerInfo_appendModify.examinerGender = dataGridView_examiner.Rows[e.RowIndex].Cells["性别"].Value.ToString();
                form_ExaminerInfo_appendModify.birth = dataGridView_examiner.Rows[e.RowIndex].Cells["出生日期"].Value.ToString();
                form_ExaminerInfo_appendModify.issuingAuthority = dataGridView_examiner.Rows[e.RowIndex].Cells["所属发证机关"].Value.ToString();
                form_ExaminerInfo_appendModify.issuingDate = dataGridView_examiner.Rows[e.RowIndex].Cells["发证日期"].Value.ToString();
                form_ExaminerInfo_appendModify.expireDate = dataGridView_examiner.Rows[e.RowIndex].Cells["有效截止日期"].Value.ToString();
                form_ExaminerInfo_appendModify.office = dataGridView_examiner.Rows[e.RowIndex].Cells["工作单位"].Value.ToString();
                form_ExaminerInfo_appendModify.operatorName = dataGridView_examiner.Rows[e.RowIndex].Cells["经办人"].Value.ToString();
                form_ExaminerInfo_appendModify.issuingOffice = dataGridView_examiner.Rows[e.RowIndex].Cells["考试员证发证单位"].Value.ToString();

                if (form_ExaminerInfo_appendModify.ShowDialog() == DialogResult.OK)
                    dataGridView_examiner.DataSource = mDBM.Select(examinerViewSQL).Tables[0];
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            string message;
            TMRIQuery.QueryExaminator(out message, textBox_fzjg.Text, textBox_glbm.Text, textBox_gxsj.Text);
            MessageBox.Show(message);
            dataGridView_examiner.DataSource = mDBM.Select(examinerViewSQL).Tables[0];
        }

        private void dateTimePicker_gxsj_ValueChanged(object sender, EventArgs e)
        {
            if ((sender as DateTimePicker).Checked)
                textBox_gxsj.Text = dateTimePicker_gxsj.Text;
            else textBox_gxsj.Clear();
        }
    }
}
