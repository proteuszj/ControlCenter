
using Client.TMRI;
using System;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_Grouping : Form
    {
        private const string groupingViewSQL = @"select 
                BRANCH_ADMINISTRATION as 管理部门,
                SUBJECT_DICT_NAME as 考试科目, 
                EXAM_DATE as 考试日期,
                PLACE_SEQUENCENUMBER as 考场序号,
                DRIVER_LICENSE_TYPE as 考试车型,
                EXAM_SESSION_DICT_NAME as 考试场次,
                SEQUENCENUMBER as 分组序号, 
                PLACE_NAME as 考场名称,
                CAR_LICENSE_NUMBER as 车辆号牌号码,
                EXAMINER_NAME as 考试员姓名,
                EXAM_ITEM as 考试项目
                from BAS_GROUPING_VIEW";
        private const string groupingDetailViewSQL = @"select 
                GROUPING_SEQUENCENUMBER as 分组序号, 
                STUDENT_IDNUMBER as 学员身份证明号码, 
                STUDENT_NAME as 学员姓名,
                SCHOOL_CODE as 驾校代码,
                CAR_LICENSE_NUMBER as 车辆号牌号码,
                QUEUE_ORDER as 排队顺序号,
                QUEUE_STATUS_DICT_NAME as 排队状态 
                from BAS_GROUPING_DETAIL_VIEW";
        private const string carViewSql = @"select
            LICENSE_PLATE 考车号牌
            from BAS_CAR_VIEW";
        private string groupingQuerySql = groupingViewSQL;
        private string groupingDetailQuerySql = groupingDetailViewSQL;
        public Form_Grouping()
        {
            InitializeComponent();
        }

        private void Form_Grouping_Load(object sender, EventArgs e)
        {
//            dataGridView_Grouping.DataSource = mDBM.Select(groupingViewSQL).Tables[0];
//            dataGridView_GroupingDetail.DataSource = mDBM.Select(groupingDetailViewSQL).Tables[0];
            dataGridView_Car.DataSource = mDBM.Select(carViewSql).Tables[0];
            dataGridView_Car.Columns.Add("身份证明号码", "身份证明号码");
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            string message;
            TMRIQuery.QueryGroup(out message, textBox_glbm.Text, comboBox_kskm.Text, dateTimePicker_ksrq.Value, textBox_kcxh.Text, comboBox_kscx.Text, comboBox_kscc.Text);
            MessageBox.Show(message);
            dataGridView_Grouping.DataSource = mDBM.Select(groupingQuerySql).Tables[0];
        }

        private void dataGridView_grouping_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string fzxh = (sender as DataGridView).Rows[e.RowIndex].Cells["分组序号"].Value.ToString();
                string message;
                TMRIQuery.QueryGroupDetail(out message, fzxh);
                MessageBox.Show("分组明细" + message);
                dataGridView_GroupingDetail.DataSource = mDBM.Select(groupingDetailQuerySql).Tables[0];
            }
        }

        private void dataGridView_grouping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sn = (sender as DataGridView).Rows[e.RowIndex].Cells["分组序号"].Value.ToString();
                groupingDetailQuerySql = groupingDetailViewSQL + $" where GROUPING_SEQUENCENUMBER={sn}";
                dataGridView_GroupingDetail.DataSource = mDBM.Select(groupingDetailQuerySql).Tables[0];
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            groupingQuerySql = "";

            if (!String.IsNullOrEmpty(textBox_glbm.Text))
            {
                groupingQuerySql += groupingQuerySql == "" ? "" : " and ";
                groupingQuerySql += $"BRANCH_ADMINISTRATION='{textBox_glbm.Text}'";
            }
            if (!String.IsNullOrEmpty(comboBox_kskm.Text))
            {
                groupingQuerySql += groupingQuerySql == "" ? "" : " and ";
                groupingQuerySql += $"SUBJECT_DICT_NAME='{comboBox_kskm.Text}'";
            }
            if (dateTimePicker_ksrq.Checked)
            {
                groupingQuerySql += groupingQuerySql == "" ? "" : " and ";
                groupingQuerySql += $"EXAM_DATE='{dateTimePicker_ksrq.Value.ToString("yyyyMMdd")}'";
            }
            if (!String.IsNullOrEmpty(textBox_kcxh.Text))
            {
                groupingQuerySql += groupingQuerySql == "" ? "" : " and ";
                groupingQuerySql += $"PLACE_SEQUENCENUMBER='{textBox_kcxh.Text}'";
            }
            if (!String.IsNullOrEmpty(comboBox_kscx.Text))
            {
                groupingQuerySql += groupingQuerySql == "" ? "" : " and ";
                groupingQuerySql += $"DRIVER_LICENSE_TYPE='{comboBox_kscx.Text}'";
            }
            if (!String.IsNullOrEmpty(comboBox_kscc.Text))
            {
                groupingQuerySql += groupingQuerySql == "" ? "" : " and ";
                groupingQuerySql += $"EXAM_SESSION_DICT_NAME='{comboBox_kscc.Text}'";
            }
            groupingQuerySql = groupingViewSQL + (groupingQuerySql == "" ? "" : " where " + groupingQuerySql);
            dataGridView_Grouping.DataSource = mDBM.Select(groupingQuerySql).Tables[0];
        }

        private void dataGridView_Car_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView_Grouping.RowCount > 0)
            {
                string kchp = (sender as DataGridView).Rows[e.RowIndex].Cells["考车号牌"].Value.ToString();
                int rowIndex = dataGridView_Grouping.SelectedCells[0].RowIndex;
                string kcxh = dataGridView_Grouping.Rows[rowIndex].Cells["考场序号"].Value.ToString();
                string kscc = dataGridView_Grouping.Rows[rowIndex].Cells["考试场次"].Value.ToString();
                string qdxm = null;
                TMRIWriteResponse response;
                if (TMRIWrite.WriteCarAllocation(out response, kchp, kcxh, kscc, qdxm))
                {
                    MessageBox.Show("考试车辆分配成功");
                    (sender as DataGridView).Rows[e.RowIndex].Cells["身份证明号码"].Value = response.message;
                    //                    string sql = $"update BAS_GROUPING_DETAIL set CAR_ID=(select ID from BAS_CAR where LICENSE_PLATE={kchp}) where STUDENT_ID=(select ID from BAS_STUDENT where IDNUMBER={response.message})";
                    string sql = $"update BAS_BOOKING " +
                        $"set EXAMINER1_ID=(select EXAMINER_ID from BAS_GROUPING where PLACE_ID=(select ID from BAS_PLACE where SEQUENCENUMBER='{kcxh}') and ROWNUM=1), " +
                        $"CAR_ID=(select ID from BAS_CAR where LICENSE_PLATE='{kchp}')" +
                        $" where STUDENT_ID=(select ID from BAS_STUDENT where IDNUMBER='{response.message}')";
                    mDBM.Select(sql);
                    dataGridView_GroupingDetail.DataSource = mDBM.Select(groupingDetailQuerySql).Tables[0];
                }
                else if (null != response)
                    MessageBox.Show($"Error: {response.code}\nMessage: {response.message}", "错误");
            }
        }

        private void button_CarAllocation_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView_Grouping.SelectedCells[0].RowIndex;
            string kcxh = dataGridView_Grouping.Rows[rowIndex].Cells["考场序号"].Value.ToString();
            string kscc = dataGridView_Grouping.Rows[rowIndex].Cells["考试场次"].Value.ToString();
            string qdxm = null;
            TMRIWriteResponse response;
            for (int i = 0; i < dataGridView_Car.RowCount; i++)
            {
                string kchp = dataGridView_Car.Rows[i].Cells["考车号牌"].Value.ToString();
                if (TMRIWrite.WriteCarAllocation(out response, kchp, kcxh, kscc, qdxm))
                {
                    dataGridView_Car.Rows[i].Cells["身份证明号码"].Value = response.message;
                    string sql = $"update BAS_GROUPING_DETAIL set CAR_ID=(select ID from BAS_CAR where LICENSE_PLATE={kchp}) where STUDENT_ID=(select ID from BAS_STUDENT where IDNUMBER={response.message})";
                    mDBM.Select(sql);
                }
                else if (null != response)
                    MessageBox.Show($"Error: {response.code}\nMessage: {response.message}", "错误");
            }
            dataGridView_GroupingDetail.DataSource = mDBM.Select(groupingDetailQuerySql).Tables[0];
            MessageBox.Show("全部考试车辆分配成功");
        }
    }
}
