
using static Client.TMRI.TMRIQuery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Client.DBM;
using System.IO;
using Client.TMRI;

namespace Client
{
    public partial class Form_Score : Form
    {
        public Form_Score(string id)
        {
            idnumber = id;
            InitializeComponent();
        }

        string idnumber;
        string studentScoreView = @"select
            NAME 姓名,
            IDNUMBER 身份证明号码,
            PHOTO1 照片,
            EXAMNUMBER 考试证明号码,
            DRIVER_LICENSE_TYPE 考试车型,
            EXAM_REASON_DICT_NAME 考试原因,
            PLACE_NAME 考场名称,
            EXAMINER1 考试员,
            CURRENT_EXAM_SCORE 成绩,
            EXAM_DATE 考试日期,
            EXAM_TIME 考试时间,
            STATUS_DICT_NAME 状态,
            EXAM_ID,
            SEQUENCENUMBER,
            BOOKING_TIMES,
            CURRENT_EXAM_TIMES
            from STUDENT_SCORE_VIEW
            where (STATUS_DICT_NAME='合格' or STATUS_DICT_NAME='不合格') and IDNUMBER='{0}'";

        private void Form_Score_Load(object sender, EventArgs e)
        {
            DataTable dataTable = mDBM.Select(string.Format(studentScoreView, idnumber)).Tables[0];
            if (dataTable.Rows.Count <= 0) Close();
            textBox_Name.Text = dataTable.Rows[0]["姓名"].ToString();
            textBox_ID.Text = idnumber;
            textBox_DriverLicenseType.Text = dataTable.Rows[0]["考试车型"].ToString();
            textBox_StudyNumber.Text = dataTable.Rows[0]["考试证明号码"].ToString();
            textBox_Reason.Text = dataTable.Rows[0]["考试原因"].ToString();
            string message = dataTable.Rows[0]["考试日期"].ToString();
            DateTime examDate = new DateTime(Convert.ToInt16(message.Substring(0, 4)), Convert.ToByte(message.Substring(4, 2)), Convert.ToByte(message.Substring(6, 2)));
            textBox_Date.Text = examDate.ToString("yyyy-MM-dd");
            textBox_Place.Text = dataTable.Rows[0]["考场名称"].ToString();
            byte[] photoStream = null;
            if (!(dataTable.Rows[0]["照片"] is DBNull))
                photoStream = (byte[])dataTable.Rows[0]["照片"];
            string examID = dataTable.Rows[0]["EXAM_ID"].ToString();
            string sequenceNumber = dataTable.Rows[0]["SEQUENCENUMBER"].ToString();
            string bookingTimes = dataTable.Rows[0]["BOOKING_TIMES"].ToString();
            string currentTimes;
            TMRI.TMRIQueryResponse response;

            Bitmap photo;
            if (null == photoStream || 0 == photoStream.Length)
            {
                if (!QueryPhoto(out message, idnumber, out photo))
                    MessageBox.Show(message);
                else
                    MessageBox.Show($"学员：{idnumber}照片下载成功");
            }
            else
                photo = new Bitmap(new MemoryStream(photoStream));
            pictureBox_Photo.Image = photo;

            int i = 0;
            if (dataTable.Rows.Count > 1)
            {
                i = 1;
                textBox_Time2.Text = dataTable.Rows[0]["考试时间"].ToString();
                textBox_Score2.Text = dataTable.Rows[0]["成绩"].ToString();
                textBox_Examiner2.Text = dataTable.Rows[0]["考试员"].ToString();
                currentTimes = dataTable.Rows[0]["CURRENT_EXAM_TIMES"].ToString();
                //扣分项
                //照片
                if (!QueryPhotoTime(out message, sequenceNumber, "2", idnumber, examDate, bookingTimes, currentTimes, out response))
                    MessageBox.Show(message, "提示");
                else
                {
                    if (response.Items.Count < 3)
                        MessageBox.Show("照片时间数据少于3组", "警告");
                    else
                    {
                        pictureBox_ExamPhoto2a.Image = getExamPhoto(examID, ((TMRIQueryResponseItemOf17C57PhotoTime)response.Items[0]).kssj);
                        pictureBox_ExamPhoto2b.Image = getExamPhoto(examID, ((TMRIQueryResponseItemOf17C57PhotoTime)response.Items[1]).kssj);
                        pictureBox_ExamPhoto2c.Image = getExamPhoto(examID, ((TMRIQueryResponseItemOf17C57PhotoTime)response.Items[2]).kssj);
                    }
                }
            }
            textBox_Time1.Text = dataTable.Rows[i]["考试时间"].ToString();
            textBox_Score1.Text = dataTable.Rows[i]["成绩"].ToString();
            textBox_Examiner1.Text = dataTable.Rows[i]["考试员"].ToString();
            currentTimes = dataTable.Rows[i]["CURRENT_EXAM_TIMES"].ToString();
            //扣分项
            //照片
            if (!QueryPhotoTime(out message, sequenceNumber, "2", idnumber, examDate, bookingTimes, currentTimes, out response))
                MessageBox.Show(message, "提示");
            else
            {
                if (response.Items.Count < 3)
                    MessageBox.Show("照片时间数据少于3组", "警告");
                else
                {
                    pictureBox_ExamPhoto1a.Image = getExamPhoto(examID, ((TMRIQueryResponseItemOf17C57PhotoTime)response.Items[0]).kssj);
                    pictureBox_ExamPhoto1b.Image = getExamPhoto(examID, ((TMRIQueryResponseItemOf17C57PhotoTime)response.Items[1]).kssj);
                    pictureBox_ExamPhoto1c.Image = getExamPhoto(examID, ((TMRIQueryResponseItemOf17C57PhotoTime)response.Items[2]).kssj);
                }
            }
        }

        Bitmap getExamPhoto(string examID, string processTime)
        {
            string sql = $@"select PROCESS_PHOTO from BUZ_EXAM_PROCESS where EXAM_ID='{examID}' and PROCESS_TIME='{processTime}'";
            DataTable table = mDBM.Select(sql).Tables[0];
            if (0 == table.Rows.Count || table.Rows[0]["PROCESS_PHOTO"] is DBNull)
                return null;
            return new Bitmap(new MemoryStream((byte[])table.Rows[0]["PROCESS_PHOTO"]));
        }
    }
}
