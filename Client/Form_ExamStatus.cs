
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_ExamStatus : Form
    {
        public Form_ExamStatus()
        {
            InitializeComponent();
            comboBox_Status.SelectedIndex = 2;
        }

        const string studentExamView = @"select
            VERIFY 校验,
            NAME 姓名，
            IDNUMBER 身份证明号码,
            CURRENT_EXAM_SCORE 分数,
            STATUS 状态,
            STUDENT_ID,
            EXAM_ID
            from STUDENT_EXAM_VIEW";

        string studentScoreView = @"select
            NAME 姓名,
            IDNUMBER 身份证明号码,
            PHOTO1 照片,
            EXAMNUMBER 考试证明号码,
            DRIVER_LICENSE_TYPE 考试车型,
            EXAM_REASON_DICT_NAME 考试原因,
            PLACE_NAME 考场名称,
            EXAMINER1 考试员,
            CAR_SEQUENCENUMBER 车辆序号,
            CURRENT_EXAM_SCORE 成绩,
            EXAM_DATE 考试日期,
            EXAM_TIME 考试时间,
            STATUS_DICT_NAME 状态,
            EXAM_ID,
            SEQUENCENUMBER,
            BOOKING_TIMES,
            CURRENT_EXAM_TIMES
            from STUDENT_SCORE_VIEW
            where IDNUMBER='{0}'";

        const string examProgressView = @"select 
            VERIFY 校验,
            PROCESS_TIME as 时间,
            PROCESS_FLAG_DICT_NAME as 考试过程标识类型,
            PROCESS_TYPE_DICT_NAME as 考试过程类型,
            EXAM_ITEM as 考试项目,
            EXAM_ITEM_NAME as 考试项目名称,
            DEVICE_NUMBER 设备编号,
            DEDUCT_ITEM as 扣分项目,
            DEDUCT_SCORE as 扣分分值,
            DEDUCT_ITEM_NAME as 扣分项目名称,
            PROCESS_PHOTO 过程照片
            from BUZ_EXAM_PROCESS_VIEW
            where EXAM_ID='{0}'";

        private void comboBox_Status_TextChanged(object sender, EventArgs e)
        {
            string sql = "";
            if (!String.IsNullOrEmpty(comboBox_Status.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += $"STATUS='{comboBox_Status.Text}'";
            }
            sql = studentExamView + (sql == "" ? "" : " where " + sql);
            dataGridView_studentExam.DataSource = mDBM.Select(sql).Tables[0];
            dataGridView_studentExam.Columns["EXAM_ID"].Visible = false;
            dataGridView_studentExam.Columns["STUDENT_ID"].Visible = false;
            dataGridView_studentExam.Columns["校验"].Visible = false;

            bool warning = false;
            int warningCount = 0;
            for (int i = 0; i < dataGridView_studentExam.RowCount; i++)
                if (dataGridView_studentExam.Rows[i].Cells["校验"].Value.ToString() == "FALSE")
                {
                    warning = true;
                    warningCount++;
                    dataGridView_studentExam.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            if (warning)
                MessageBox.Show($"{warningCount}组数据被篡改", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dataGridView_ExamProcess.DataSource = null;
        }

        private void dataGridView_studentExam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string idNumber = dataGridView_studentExam.Rows[e.RowIndex].Cells["身份证明号码"].Value.ToString();
            DataTable student = mDBM.Select(string.Format(studentScoreView, idNumber)).Tables[0];

            if (student.Rows.Count > 0)
            {
                textBox_Name.Text = student.Rows[0]["姓名"].ToString();
                textBox_ID.Text = student.Rows[0]["身份证明号码"].ToString();
                textBox_DriverLicenseType.Text = student.Rows[0]["考试车型"].ToString();
                textBox_StudyNumber.Text = student.Rows[0]["考试证明号码"].ToString();
                textBox_Reason.Text = student.Rows[0]["考试原因"].ToString();
                textBox_Date.Text = student.Rows[0]["考试日期"].ToString();
                textBox_Place.Text = student.Rows[0]["考场名称"].ToString();
                textBox_CarSequenceNumber.Text = student.Rows[0]["车辆序号"].ToString();
                if (!(student.Rows[0]["照片"] is DBNull))
                {
                    byte[] data = (byte[])student.Rows[0]["照片"];
                    pictureBox_Photo.Image = data.Length > 0 ? new Bitmap(new MemoryStream(data)) : null;
                }
            }

            string examID = dataGridView_studentExam.Rows[e.RowIndex].Cells["EXAM_ID"].Value.ToString();
            dataGridView_ExamProcess.DataSource = mDBM.Select(string.Format(examProgressView, examID)).Tables[0];
            dataGridView_ExamProcess.Columns["过程照片"].Visible = false;
        }

        private void dataGridView_ExamProcess_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(dataGridView_ExamProcess.Rows[e.RowIndex].Cells["过程照片"].Value is DBNull))
            {
                byte[] data = (byte[])dataGridView_ExamProcess.Rows[e.RowIndex].Cells["过程照片"].Value;
                pictureBox_ProcessPhoto.Image = data.Length > 0 ? new Bitmap(new MemoryStream(data)) : null;
            }
            else pictureBox_ProcessPhoto.Image = null;
        }
    }
}
