
using Client.TMRI;
using System;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_Booking : Form
    {
        private const string bookingViewSQL = @"select 
                SUBJECT_DICT_NAME as 考试科目, 
                EXAM_DATE as 考试日期,
                PLACE_SEQUENCENUMBER as 考场序号,
                STUDENT_IDTYPE as 身份证明类型, 
                STUDENT_IDNUMBER as 身份证明号码, 
                SEQUENCENUMBER as 流水号, 
                EXAMNUMBER as 准考证号码, 
                STUDENT_NAME as 姓名, 
                GENDER_DICT_NAME as 性别, 
                SIGN_STATUS as 签到状态,
                EXAM_SESSION_DICT_NAME as 考试场次,
                CAR_LICENSE_NUMBER as 车辆号牌号码,
                EXAM_STATUS as 考试状态,
                STUDENT_DRIVER_LICENSE_TYPE as 学员驾驶证类型, 
                STUDENT_STATUS as 学员状态, 
                EXAM_REASON_DICT_NAME as 考试原因, 
                BOOKING_DATETIME as 预约日期时间, 
                BOOKING_EXAM_DATE as 约考日期, 
                BOOKING_DRIVER_LICENSE_TYPE as 预约驾驶证类型, 
                OPERATOR_NAME as 经办人,
                BRANCH_ADMINISTRATION as 管理部门,
                ID 序号
                from BAS_BOOKING_VIEW";
        private string bookingQuerySql = bookingViewSQL;

        public Form_Booking()
        {
            InitializeComponent();
        }

        private void Form_Booking_Load(object sender, EventArgs e)
        {
            //dataGridView_booking.DataSource =mDBM.Select(bookingViewSQL).Tables[0];
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            string message;
            TMRIQuery.QueryBook(out message, comboBox_kskm.Text, dateTimePicker_ksrq.Value, textBox_kcxh.Text, textBox_sfzmhm.Text);
            MessageBox.Show(message);
            dataGridView_booking.DataSource = mDBM.Select(bookingViewSQL).Tables[0];
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string message;

            bookingQuerySql = string.Empty;

            if (!String.IsNullOrEmpty(comboBox_kskm.Text))
            {
                bookingQuerySql += bookingQuerySql == "" ? "" : " and ";
                bookingQuerySql += $"SUBJECT_DICT_NAME='{comboBox_kskm.Text}'";
            }
            if (dateTimePicker_ksrq.Checked)
            {
                bookingQuerySql += bookingQuerySql == "" ? "" : " and ";
                bookingQuerySql += "EXAM_DATE='" + dateTimePicker_ksrq.Value.ToString("yyyyMMdd") + "'";
            }
            if (!String.IsNullOrEmpty(textBox_kcxh.Text))
            {
                bookingQuerySql += bookingQuerySql == "" ? "" : " and ";
                bookingQuerySql += "PLACE_SEQUENCENUMBER='" + textBox_kcxh.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_sfzmhm.Text))
            {
                if (!Utils.CheckIDNumber(textBox_sfzmhm.Text, out message))
                {
                    MessageBox.Show(message, "提示");
                    return;
                }
                bookingQuerySql += bookingQuerySql == "" ? "" : " and ";
                bookingQuerySql += "STUDENT_IDNUMBER='" + textBox_sfzmhm.Text + "'";
            }
            bookingQuerySql = bookingViewSQL + (bookingQuerySql == "" ? "" : " where " + bookingQuerySql);
            dataGridView_booking.DataSource = mDBM.Select(bookingQuerySql).Tables[0];
        }

        private void dataGridView_booking_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button_CheckIn_Click(button_CheckIn, new EventArgs());
        }

        private void button_CheckIn_Click(object sender, EventArgs e)
        {
            int index = dataGridView_booking.SelectedCells[0].RowIndex;
            TMRIWriteResponse response;
            string sfzmhm = dataGridView_booking.Rows[index].Cells["身份证明号码"].Value.ToString();
            string kskm = dataGridView_booking.Rows[index].Cells["考试科目"].Value.ToString();
            string kcxh = dataGridView_booking.Rows[index].Cells["考场序号"].Value.ToString();
            string kscc = dataGridView_booking.Rows[index].Cells["考试场次"].Value.ToString();
            if (TMRIWrite.WriteCheckIn(out response, sfzmhm, kskm, kcxh, kscc, null))
            {
                MessageBox.Show(response.message);
                string sql = $"update BAS_BOOKING set SIGN_STATUS=1 where ID={dataGridView_booking.Rows[index].Cells["序号"].Value.ToString()}";
                mDBM.Select(sql);
                dataGridView_booking.DataSource = mDBM.Select(bookingQuerySql).Tables[0];
            }
            else if (null != response)
                MessageBox.Show($"Error: {response.code}\nMessage: {response.message}", "错误");
        }
    }
}
