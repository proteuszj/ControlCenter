
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_SummaryQuery : Form
    {
        private const string examInfoViewSQL = @"select 
                ID,
                VERIFY 校验,
                SUBJECT_DICT_NAME as 考试科目,
                EXAM_REASON as 考试原因，
                STUDENT_NAME as 姓名, 
                STUDENT_GENDER as 性别, 
                STUDENT_IDNUMBER as 身份证明号码, 
                EXAM_NUMBER as 学员准考证号码,
                DRIVER_LICENSE_TYPE as 驾驶证类型, 
                PLACE_NAME as 考场名称,
                CARNUMBER as 车辆编号,
                CARSEQUENCENUMBER as 车辆序号,
                CAR_TYPE as 车辆类型，
                LICENSE_PLATE as 车辆号牌号码,
                EXAMINER1_NAME as 考试员1,
                EXAMINER2_NAME as 考试员2,
                SCHOOL_NAME as 驾校名称,
                EXAM_START_TIME as 考试开始时间, 
                EXAM_END_TIME as 考试结束时间,
                CURRENT_EXAM_SCORE as 当前考试分数,
                EXAM_STATUS_DICT_NAME as 考试状态,
                DEDUCT_COUNT as 扣分次数,
                DEDUCT_SCORE as 扣分分数 
                from BUZ_EXAM_INFO_VIEW";

        private const string examProcessViewSQL = @"select 
                PROCESS_TIME as 时间,
                PROCESS_FLAG_DICT_NAME as 考试过程标识类型,
                PROCESS_TYPE_DICT_NAME as 考试过程类型,
                EXAM_ITEM as 考试项目,
                EXAM_ITEM_NAME as 考试项目名称,
                DEDUCT_ITEM as 扣分项目,
                DEDUCT_SCORE as 扣分分值,
                DEDUCT_ITEM_NAME as 扣分项目名称,
                PROCESS_PHOTO 过程照片
                from BUZ_EXAM_PROCESS_VIEW";

        public Form_SummaryQuery()
        {
            InitializeComponent();
            string sql;

            sql = "select NAME from BAS_DRIVING_SCHOOL";
            comboBox_school.Items.Clear();
            comboBox_school.Items.AddRange(mDBM.SelectArray(sql));
            //iniFile = new IniFile(Form_Main.INIFILE_NAME);
            //string[] nameList = iniFile.ReadValue("SchoolName", "School Name List").Split(',');
            //comboBox_school.Items.AddRange(nameList);

            sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1007 order by VIEW_INDEX";
            comboBox_examReason.Items.Clear();
            comboBox_examReason.Items.AddRange(mDBM.SelectArray(sql));

            sql = "select DICT_CODE from CFG_DICT where DICT_TYPE=2003 order by VIEW_INDEX";
            comboBox_driverLicenseType.Items.Clear();
            comboBox_driverLicenseType.Items.AddRange(mDBM.SelectArray(sql));

            sql = "select SEQUENCENUMBER from BAS_CAR";
            comboBox_carSequenceNumber.Items.Clear();
            comboBox_carSequenceNumber.Items.AddRange(mDBM.SelectArray(sql));

            sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1006 order by VIEW_INDEX";
            comboBox_subject.Items.Clear();
            comboBox_subject.Items.AddRange(mDBM.SelectArray(sql));

            sql = "select NAME from BAS_EXAMINER";
            comboBox_examiner.Items.Clear();
            comboBox_examiner.Items.AddRange(mDBM.SelectArray(sql));

            sql = "select DEVICENUMBER from BAS_DEVICE";
            comboBox_deviceNumber.Items.Clear();
            comboBox_deviceNumber.Items.AddRange(mDBM.SelectArray(sql));
        }

        private void Form_SummaryQuery_Load(object sender, EventArgs e)
        {

            //            btn_query_Click(this, new EventArgs());
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            string sql = "";

            if (!String.IsNullOrEmpty(dateTimePicker_start.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "EXAM_START_TIME>='" + dateTimePicker_start.Value.Date.ToString("yyyyMMdd") + "000000'";
            }
            if (!String.IsNullOrEmpty(dateTimePicker_end.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "EXAM_END_TIME<='" + dateTimePicker_end.Value.Date.ToString("yyyyMMdd") + "235959'";
            }

            if (!String.IsNullOrEmpty(comboBox_school.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "SCHOOL_NAME='" + comboBox_school.Text + "'";
            }
            if (!String.IsNullOrEmpty(comboBox_examReason.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "EXAM_REASON='" + comboBox_examReason.Text + "'";
            }
            if (!String.IsNullOrEmpty(comboBox_driverLicenseType.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "DRIVER_LICENSE_TYPE='" + comboBox_driverLicenseType.Text + "'";
            }
            if (!String.IsNullOrEmpty(comboBox_carSequenceNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "CARSEQUENCENUMBER='" + comboBox_carSequenceNumber.Text + "'";
            }
            if (!String.IsNullOrEmpty(comboBox_subject.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "SUBJECT_DICT_NAME='" + comboBox_subject.Text + "'";
            }
            if (!String.IsNullOrEmpty(comboBox_examiner.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "(EXAMINER1_NAME='" + comboBox_examiner.Text + "' or EXAMINER2_NAME='" + comboBox_examiner.Text + "')";
            }
            if (!String.IsNullOrEmpty(textBox_name.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "STUDENT_NAME='" + textBox_name.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_idNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "STUDENT_IDNUMBER='" + textBox_idNumber.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_examNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "EXAM_NUMBER='" + textBox_examNumber.Text + "'";
            }
            if (!string.IsNullOrEmpty(comboBox_deviceNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += $"exists(select * from buz_exam_process where exam_id=buz_exam_info_view.id and device_id=(select id from bas_device where devicenumber='{comboBox_deviceNumber.Text}'))";
            }

            sql = examInfoViewSQL + (sql == "" ? "" : " where " + sql);
            dataGridView_ExamInfo.DataSource = mDBM.Select(sql).Tables[0];

            bool warning = false;
            int warningCount = 0;
            for (int i = 0; i < dataGridView_ExamInfo.RowCount; i++)
                if (dataGridView_ExamInfo.Rows[i].Cells["校验"].Value.ToString() == "FALSE")
                {
                    warning = true;
                    warningCount++;
                    dataGridView_ExamInfo.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            if (warning)
            {
                MessageBox.Show($"{warningCount}组数据被篡改", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView_ExamInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView_ExamProcess.DataSource = mDBM.Select(examProcessViewSQL +
                    " where EXAM_ID='" + dataGridView_ExamInfo.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "'").Tables[0];
            }

            dataGridView_ExamProcess.Columns["过程照片"].Visible = false;
        }

        private void dataGridView_ExamProcess_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dataGridView_ExamProcess.Rows[e.RowIndex].Cells["过程照片"].Value is DBNull))
            {
                byte[] data = (byte[])dataGridView_ExamProcess.Rows[e.RowIndex].Cells["过程照片"].Value;
                if (data.Length > 0)
                    pictureBox_ProcessPhoto.Image = new Bitmap(new MemoryStream(data));
                else pictureBox_ProcessPhoto.Image = null;
            }
            else pictureBox_ProcessPhoto.Image = null;
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            string message;
            if (DialogResult.OK == saveFileDialog_excel.ShowDialog())
            {
                bool flag = Utils.SaveToExcel(dataGridView_ExamProcess, null, saveFileDialog_excel.FileName, out message);
                MessageBox.Show($"{message}：{saveFileDialog_excel.FileName}", flag ? "提示" : "错误", MessageBoxButtons.OK, flag ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
        }
    }
}
