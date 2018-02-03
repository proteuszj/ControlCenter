
using Client.TMRI;
using System;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_PlaceInfo : Form
    {
        private const string placeViewSQL = @"select 
            ISSUING_AUTHORITY as 发证机关, 
            SUBJECT_DICT_NAME as 考试科目, 
            SEQUENCENUMBER as 序号, 
            CODE as 考场代码, 
            NAME as 考场名称, 
            BRANCH_ADMINISTRATION as 管理部门, 
            UPDATE_TIME as 更新时间,
            QUALIFIED_CAR_TYPE as 适用准驾车型范围, 
            BUSINESS_TYPE as 适用业务类型范围, 
            ACCEPTANCE_DATE as 总队验收日期, 
            ACCEPTER as 验收人, 
            RESERVATION_MODE as 预约模式, 
            GROUPING_MODE as 分组模式, 
            CAPACITY as 考试人数限制, 
            PILE_EXAM_CAPACITY as 科目二桩考人数限制, 
            PLACE_EXAM_CAPACITY as 科目二场考人数限制, 
            PILE_EXAM_JUDGING as 桩考评判方式, 
            PLACE_EXAM_JUDGING as 场考评判方式, 
            PILE_EXAM_NETWORK_TIME as 桩考开始联网时间, 
            PLACE_EXAM_NETWORK_TIME as 场考开始联网时间, 
            STATUS as 场地使用状态, 
            PILE_EXAM_DEVICE_COUNT as 桩考设备数, 
            PLACE_EXAM_DEVICE_COUNT as 场考设备数, 
            EXAM_CAR_TOTAL_COUNT as 考场考试车辆数, 
            PLACE_AREA as 考场面积, 
            ROADWAY_LENGTH as 考场车道总长度, 
            EXAM_CAR_COUNT as 考场同时考试车辆数,
            CREATE_TIME as 创建时间
            from BAS_PLACE_VIEW";

        public Form_PlaceInfo()
        {
            InitializeComponent();
        }

        private void Form_PlaceInfo_Load(object sender, EventArgs e)
        {
            dataGridView_place.DataSource = mDBM.Select(placeViewSQL).Tables[0];

            comboBox_kskm.Items.Clear();
            string sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1006 order by VIEW_INDEX";
            comboBox_kskm.Items.AddRange(mDBM.SelectArray(sql));
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string sql = "";

            if (!String.IsNullOrEmpty(textBox_fzjg.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "ISSUING_AUTHORITY='" + textBox_fzjg.Text + "'";
            }
            if (!String.IsNullOrEmpty(comboBox_kskm.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "SUBJECT_DICT_NAME='" + comboBox_kskm.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_sequenceNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "SEQUENCENUMBER='" + textBox_sequenceNumber.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_code.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "CODE='" + textBox_code.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_name.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "NAME='" + textBox_name.Text + "'";
            }

            sql = placeViewSQL + (sql == "" ? "" : " where " + sql);
            dataGridView_place.DataSource = mDBM.Select(sql).Tables[0];
        }

        private void btn_append_Click(object sender, EventArgs e)
        {
            Form_PlaceInfo_appendModify form_PlaceInfo_appendModify = new Form_PlaceInfo_appendModify();
            form_PlaceInfo_appendModify.isAppend = true;
            form_PlaceInfo_appendModify.Text = "场地信息添加";

            if (form_PlaceInfo_appendModify.ShowDialog() == DialogResult.OK)
                dataGridView_place.DataSource = mDBM.Select(placeViewSQL).Tables[0];
        }

        private void dataGridView_place_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Form_PlaceInfo_appendModify form_PlaceInfo_appendModify = new Form_PlaceInfo_appendModify();
                form_PlaceInfo_appendModify.isAppend = false;
                form_PlaceInfo_appendModify.Text = "场地信息修改";

                form_PlaceInfo_appendModify.code = dataGridView_place.Rows[e.RowIndex].Cells["考场代码"].Value.ToString();
                form_PlaceInfo_appendModify.name = dataGridView_place.Rows[e.RowIndex].Cells["考场名称"].Value.ToString();
                form_PlaceInfo_appendModify.subject = dataGridView_place.Rows[e.RowIndex].Cells["考试科目"].Value.ToString();
                form_PlaceInfo_appendModify.issuingAuthority = dataGridView_place.Rows[e.RowIndex].Cells["发证机关"].Value.ToString();
                form_PlaceInfo_appendModify.branchAdministration = dataGridView_place.Rows[e.RowIndex].Cells["管理部门"].Value.ToString();
                form_PlaceInfo_appendModify.acceptanceDate = dataGridView_place.Rows[e.RowIndex].Cells["总队验收日期"].Value.ToString();
                form_PlaceInfo_appendModify.accepter = dataGridView_place.Rows[e.RowIndex].Cells["验收人"].Value.ToString();

                if (form_PlaceInfo_appendModify.ShowDialog() == DialogResult.OK)
                    dataGridView_place.DataSource = mDBM.Select(placeViewSQL).Tables[0];
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            string message;
            TMRIQuery.QueryPlace(out message, textBox_fzjg.Text, comboBox_kskm.Text, dateTimePicker_gxsj.Checked ? dateTimePicker_gxsj.Value.ToString("yyyy-MM-dd HH:mm:ss") : null);
            MessageBox.Show(message);
            dataGridView_place.DataSource = mDBM.Select(placeViewSQL).Tables[0];
        }
    }
}
