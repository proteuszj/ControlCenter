
using System;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_Process : Form
    {
        private const string studentViewSQL = @"select 
                NAME as 姓名, 
                GENDER_DICT_NAME as 性别, 
                IDTYPE_DICT_NAME as 身份证明类型, 
                IDNUMBER as 身份证明号码, 
                DRIVER_LICENSE_TYPE as 驾驶证类型, 
                STATUS_DICT_NAME as 状态, 
                CREATE_TIME as 创建时间, 
                UPDATE_TIME as 更新时间 
                from BAS_STUDENT_VIEW";

        string processViewSQL = @"select 
                PROCESS_TIME as 时间,
                PROCESS_FLAG_DICT_NAME as 考试过程标识类型,
                PROCESS_TYPE_DICT_NAME as 考试过程类型,
                EXAM_ITEM as 考试项目,
                EXAM_ITEM_NAME as 考试项目名称,
                DEDUCT_ITEM as 扣分项目,
                DEDUCT_SCORE as 扣分分值,
                DEDUCT_ITEM_NAME as 扣分项目名称
                from BUZ_EXAM_PROCESS_VIEW";

        public Form_Process()
        {
            InitializeComponent();
        }

        private void Form_Student_Load(object sender, EventArgs e)
        {
            dataGridView_students.DataSource = mDBM.Select(studentViewSQL).Tables[0];

            string sql;

            comboBox_driverType.Items.Clear();
            sql = "select DICT_CODE from CFG_DICT where DICT_TYPE=2003 order by VIEW_INDEX";
            comboBox_driverType.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_status.Items.Clear();
            sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1036 order by VIEW_INDEX";
            comboBox_status.Items.AddRange(mDBM.SelectArray(sql));
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
            if (!String.IsNullOrEmpty(comboBox_status.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "STATUS_DICT_NAME='" + comboBox_status.Text + "'";
            }
            if (!String.IsNullOrEmpty(comboBox_driverType.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "DRIVER_LICENSE_TYPE='" + comboBox_driverType.Text + "'";
            }

            sql = studentViewSQL + (sql == "" ? "" : " where " + sql);
            dataGridView_students.DataSource = mDBM.Select(sql).Tables[0];
        }

        private void dataGridView_students_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string examInfoViewSQL = @"select 
            //    ID as ID,
            //    SUBJECT_DICT_NAME as 考试科目,
            //    STUDENT_NAME as 姓名, 
            //    STUDENT_GENDER as 性别, 
            //    STUDENT_IDNUMBER as 身份证明号码, 
            //    EXAM_NUMBER as 学员准考证号码,
            //    DRIVER_LICENSE_TYPE as 驾驶证类型, 
            //    STUDENT_STATUS as 学员状态, 
            //    PLACE_NAME as 考场名称,
            //    CARNUMBER as 车辆编号,
            //    LICENSE_PLATE as 车辆号牌号码,
            //    EXAM_START_TIME as 考试开始时间, 
            //    EXAM_END_TIME as 考试结束时间,
            //    CURRENT_EXAM_TIMES as 当前考试次数,
            //    CURRENT_EXAM_SCORE as 当前考试分数,
            //    EXAM_STATUS_DICT_NAME as 考试状态,
            //    DEDUCT_COUNT as 扣分次数,
            //    DEDUCT_SCORE as 扣分分数 
            //    from BUZ_EXAM_INFO_VIEW";
            string examInfoViewSQL = @"select 
                ID as ID,
                PLACE_NAME as 考场名称,
                CARNUMBER as 车辆编号,
                LICENSE_PLATE as 车辆号牌号码,
                EXAM_START_TIME as 考试开始时间, 
                EXAM_END_TIME as 考试结束时间,
                CURRENT_EXAM_SCORE as 当前考试分数,
                EXAM_STATUS_DICT_NAME as 考试状态,
                DEDUCT_COUNT as 扣分次数,
                DEDUCT_SCORE as 扣分分数 
                from BUZ_EXAM_INFO_VIEW";

            if (e.RowIndex >= 0)
            {
                dataGridView_student.DataSource = mDBM.Select(examInfoViewSQL +
                    " where STUDENT_IDNUMBER='" + dataGridView_students.Rows[e.RowIndex].Cells["身份证明号码"].Value.ToString() + "'").Tables[0];
            }
        }

        private void dataGridView_student_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dataGridView_student.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                dataGridView_processQuery.DataSource = mDBM.Select($"{processViewSQL} where EXAM_ID='{id}'").Tables[0];
            }
        }
    }
}
