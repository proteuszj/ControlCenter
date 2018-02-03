
using Client.IDReader;
using System;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_TrainBooking : Form
    {
        public enum TrainingModeEnum
        {
            ByTime,
            ByTimes
        }

        public TrainingModeEnum TrainingMode = TrainingModeEnum.ByTimes;

        private Form_TrainBooking_confirm __Form_TrainBooking_confirm;
        private const string __StudentViewSQL = @"select 
                NAME as 姓名, 
                GENDER_DICT_NAME as 性别, 
                IDTYPE_DICT_NAME as 身份证明类型, 
                IDNUMBER as 身份证明号码, 
                DRIVER_LICENSE_TYPE as 驾驶证类型, 
                SCHOOL_NAME as 驾校名称,
                BOOKED as 预约状态,
                BOOKING_TIMES as 预约次数,
                LEFT_TIMES as 剩余次数,
                BOOKING_STUDY_TIME as 预约时间,
                LEFT_STUDY_TIME as 剩余时间
                from BAS_STUDENT_VIEW";

        public Form_TrainBooking()
        {
            InitializeComponent();
            comboBox_gender.Items.Clear();
            string sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=2001 order by VIEW_INDEX";
            comboBox_gender.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_idType.Items.Clear();
            sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=2002 order by VIEW_INDEX";
            comboBox_idType.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_driverLicenseType.Items.Clear();
            sql = "select DICT_CODE from CFG_DICT where DICT_TYPE=2003 order by VIEW_INDEX";
            comboBox_driverLicenseType.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_schoolName.Items.Clear();
            //sql = "select NAME from BAS_DRIVING_SCHOOL";
            sql = "select distinct school_name from bas_student";
            comboBox_schoolName.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_subjectName.Items.Clear();
            sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1006 order by VIEW_INDEX";
            comboBox_subjectName.Items.AddRange(mDBM.SelectArray(sql));
            comboBox_subjectName.SelectedIndex = 1;

            comboBox_paymentWay.Items.Clear();
            sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1001 order by VIEW_INDEX";
            comboBox_paymentWay.Items.AddRange(mDBM.SelectArray(sql));
            comboBox_paymentWay.SelectedIndex = 0;

            dateTimePicker_bookingDate.MinDate = DateTime.Now.Date;
            byte bookingDateLimit = 1;
            try
            {
                bookingDateLimit = Convert.ToByte(ConfigParameters.getValue("BOOKING_DATE_LIMIT"));
            }
            catch (Exception)
            { }
            dateTimePicker_bookingDate.MaxDate = dateTimePicker_bookingDate.MinDate + TimeSpan.FromDays(bookingDateLimit) - TimeSpan.FromSeconds(1);
            dateTimePicker_bookingDate.Value = DateTime.Now.Date;

            comboBox_car.Items.Clear();
            sql = "select LICENSE_PLATE from BAS_CAR";
            comboBox_car.Items.AddRange(mDBM.SelectArray(sql));
        }

        private void Form_TrainBooking_Load(object sender, EventArgs e)
        {
            if (TrainingModeEnum.ByTime == TrainingMode)
                label_times.Text = "时间（分钟）：";
            else
                label_times.Text = "次数：";
        }

        private void button_read_Click(object sender, EventArgs e)
        {
            try
            {
                IDCardInfo info = IDCardReader.getInstance().CardInfo;
                textBox_name.Text = info.name;
                comboBox_idType.Text = "居民身份证";
                textBox_idNumber.Text = info.idNumber;
                switch (info.sex)
                {
                    case "男": comboBox_gender.Text = "男性"; break;
                    case "女": comboBox_gender.Text = "女性"; break;
                    default: comboBox_gender.Text = "未说明性别"; break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string studentSQL = "";
            if (!String.IsNullOrEmpty(textBox_name.Text))
            {
                studentSQL += studentSQL == "" ? "" : " and ";
                studentSQL += "NAME='" + textBox_name.Text + "'";
            }
            if (!string.IsNullOrEmpty(comboBox_gender.Text))
            {
                studentSQL += studentSQL == "" ? "" : " and ";
                studentSQL += "GENDER_DICT_NAME='" + comboBox_gender.Text + "'";
            }
            if (!string.IsNullOrEmpty(comboBox_idType.Text))
            {
                studentSQL += studentSQL == "" ? "" : " and ";
                studentSQL += "IDTYPE_DICT_NAME='" + comboBox_idType.Text + "'";
            }
            if (!string.IsNullOrEmpty(textBox_idNumber.Text))
            {
                studentSQL += studentSQL == "" ? "" : " and ";
                studentSQL += "IDNUMBER='" + textBox_idNumber.Text + "'";
            }
            if (!string.IsNullOrEmpty(comboBox_schoolName.Text))
            {
                studentSQL += studentSQL == "" ? "" : " and ";
                studentSQL += "SCHOOL_NAME='" + comboBox_schoolName.Text + "'";
            }
            if (!string.IsNullOrEmpty(comboBox_driverLicenseType.Text))
            {
                studentSQL += studentSQL == "" ? "" : " and ";
                studentSQL += "DRIVER_LICENSE_TYPE='" + comboBox_driverLicenseType.Text + "'";
            }
            studentSQL = __StudentViewSQL + (studentSQL == "" ? "" : " where " + studentSQL);
            dataGridView_student.DataSource = mDBM.Select(studentSQL).Tables[0];
            //if (TrainingModeEnum.ByTime == TrainingMode)
            //{
            //    dataGridView_student.Columns["预约次数"].Visible = false;
            //    dataGridView_student.Columns["剩余次数"].Visible = false;
            //    dataGridView_student.Columns["预约时间"].Visible = true;
            //    dataGridView_student.Columns["剩余时间"].Visible = true;
            //}
            //else
            //{
            //    dataGridView_student.Columns["预约次数"].Visible = true;
            //    dataGridView_student.Columns["剩余次数"].Visible = true;
            //    dataGridView_student.Columns["预约时间"].Visible = false;
            //    dataGridView_student.Columns["剩余时间"].Visible = false;
            //}

            string[] names = mDBM.SelectArray(studentSQL);

            // 学员注册
            if (names.Length == 0)
            {
                if (DialogResult.Yes == MessageBox.Show("学员不存在，是否注册", "提示", MessageBoxButtons.YesNo))
                {
                    Form_Student_appendModify form_Student_appendModify = new Form_Student_appendModify
                    {
                        isAppend = true,
                        Text = "学员添加",

                        name = textBox_name.Text,
                        gender = comboBox_gender.Text,
                        idType = comboBox_idType.Text,
                        idNo = textBox_idNumber.Text,
                        driverType = comboBox_driverLicenseType.Text,
                        schoolName = comboBox_schoolName.Text
                    };
                    form_Student_appendModify.photoBytes[0] = null;
                    form_Student_appendModify.photoBytes[1] = null;

                    if (form_Student_appendModify.ShowDialog() == DialogResult.OK)
                        dataGridView_student.DataSource = mDBM.Select(__StudentViewSQL).Tables[0];
                }
                else
                    return;
            }
        }

        private void dataGridView_student_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox_name.Text = dataGridView_student.Rows[e.RowIndex].Cells["姓名"].Value.ToString();
                comboBox_gender.SelectedIndex = comboBox_gender.Items.IndexOf(dataGridView_student.Rows[e.RowIndex].Cells["性别"].Value.ToString());
                comboBox_idType.SelectedIndex = comboBox_idType.Items.IndexOf(dataGridView_student.Rows[e.RowIndex].Cells["身份证明类型"].Value.ToString());
                textBox_idNumber.Text = dataGridView_student.Rows[e.RowIndex].Cells["身份证明号码"].Value.ToString();
                comboBox_driverLicenseType.SelectedIndex = comboBox_driverLicenseType.Items.IndexOf(dataGridView_student.Rows[e.RowIndex].Cells["驾驶证类型"].Value.ToString());
                comboBox_schoolName.Text = dataGridView_student.Rows[e.RowIndex].Cells["驾校名称"].Value.ToString();

                tabControl2.Enabled = true;
            }
        }

        private void dataGridView_student_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Form_Student_appendModify form_Student_appendModify = new Form_Student_appendModify
                {
                    isAppend = false,
                    Text = "学员修改",

                    name = dataGridView_student.Rows[e.RowIndex].Cells["姓名"].Value.ToString(),
                    gender = dataGridView_student.Rows[e.RowIndex].Cells["性别"].Value.ToString(),
                    idType = dataGridView_student.Rows[e.RowIndex].Cells["身份证明类型"].Value.ToString(),
                    idNo = dataGridView_student.Rows[e.RowIndex].Cells["身份证明号码"].Value.ToString(),
                    driverType = dataGridView_student.Rows[e.RowIndex].Cells["驾驶证类型"].Value.ToString(),
                    schoolName = dataGridView_student.Rows[e.RowIndex].Cells["驾校名称"].Value.ToString()
                };
                form_Student_appendModify.photoBytes[0] = null;
                form_Student_appendModify.photoBytes[1] = null;

                if (form_Student_appendModify.ShowDialog() == DialogResult.OK)
                    dataGridView_student.DataSource = mDBM.Select(__StudentViewSQL).Tables[0];
            }
        }

        private void dateTimePicker_bookingDate_ValueChanged(object sender, EventArgs e)
        {
            comboBox_bookingTime.Items.Clear();
#if simpleBookingTime
            string sql = "select distinct(case when substr(DISPLAY_NAME,1,2)<12 then '上午' else '下午' end) from CFG_PARAM where PARAM_NAME like '__0000' and PARAM_VALUE='TRUE'";
            if ((sender as DateTimePicker).Value.Date == DateTime.Now.Date)
                sql += $" and (substr(DISPLAY_NAME, 1, 2) >= 12 or to_char(current_date, 'hh24') < 12)";
#else
            string sql = "select DISPLAY_NAME from CFG_PARAM where PARAM_NAME like '__0000' and PARAM_VALUE='TRUE'";
            if ((sender as DateTimePicker).Value.Date == DateTime.Now.Date)
                sql += $" and substr(PARAM_NAME,1,2)>{DateTime.Now.Hour}";
#endif
            comboBox_bookingTime.Items.AddRange(mDBM.SelectArray(sql));
            if (comboBox_bookingTime.Items.Count > 0)
                comboBox_bookingTime.SelectedIndex = 0;
        }

        private void button_bookingStatus_Click(object sender, EventArgs e)
        {
            Form_BookingStatus bookingStatus = new Form_BookingStatus
            {
                DateString = dateTimePicker_bookingDate.Text,
                TimeString = comboBox_bookingTime.Text
            };
            if (DialogResult.OK == bookingStatus.ShowDialog())
            {
                dateTimePicker_bookingDate.Text = bookingStatus.DateString;
                comboBox_bookingTime.Text = bookingStatus.TimeString;
            }
        }

        private void radioButton_specifiedCar_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_car.Enabled = ((sender as RadioButton).Checked);
        }

        private void btn_book_Click(object sender, EventArgs e)
        {
            // 学员信息
            if (String.IsNullOrEmpty(comboBox_idType.Text) ||
                String.IsNullOrEmpty(textBox_idNumber.Text) ||
                String.IsNullOrEmpty(textBox_name.Text) ||
                String.IsNullOrEmpty(comboBox_gender.Text) ||
                String.IsNullOrEmpty(comboBox_schoolName.Text) ||
                String.IsNullOrEmpty(comboBox_driverLicenseType.Text))
            {
                MessageBox.Show("学员信息不能为空", "提示");
                return;
            }

            if (textBox_idNumber.Text.Length != 18)
            {
                MessageBox.Show("身份证明号码长度错误", "错误");
                return;
            }

            // 预约检查
            if (String.IsNullOrEmpty(comboBox_subjectName.Text) ||
                String.IsNullOrEmpty(textBox_times.Text) ||
                String.IsNullOrEmpty(comboBox_paymentWay.Text))
            {
                MessageBox.Show("预约信息不能为空", "提示");
                return;
            }

            // 预约金额
            string startTime = dateTimePicker_bookingDate.Value.ToString("yyyyMMddHHmmss");
            string message;
            float amount = TrainingModeEnum.ByTimes == TrainingMode ? mDBM.GetPriceByTimes(Convert.ToInt32(textBox_times.Text, 10), startTime, comboBox_schoolName.Text, textBox_idNumber.Text, out message) : mDBM.GetPriceByTime(Convert.ToInt32(textBox_times.Text, 10), startTime, comboBox_schoolName.Text, textBox_idNumber.Text, out message);

            // 预约确认
            __Form_TrainBooking_confirm = new Form_TrainBooking_confirm
            {
                studentName = textBox_name.Text,
                subjectName = comboBox_subjectName.Text,
                times = textBox_times.Text,
                amount = amount.ToString("F2")
            };
            if (DialogResult.OK == __Form_TrainBooking_confirm.ShowDialog())
            {
#if simpleBookingTime
                string bookingDatetime = dateTimePicker_bookingDate.Value.ToString("yyyyMMdd");
                if ("上午" == comboBox_bookingTime.Text)
                    bookingDatetime += "090000";
                else
                    bookingDatetime += "150000";
#else
                string bookingDatetime = dateTimePicker_bookingDate.Value.ToString("yyyyMMdd") + comboBox_bookingTime.Text.Remove(5, 1).Remove(2, 1).Substring(0, 6);
#endif
                string carLicensePlate = radioButton_specifiedCar.Checked ? comboBox_car.Text : string.Empty;
                if (TrainingModeEnum.ByTimes == TrainingMode)
                    mDBM.BookFromManagement(textBox_idNumber.Text, comboBox_subjectName.Text, Convert.ToInt32(textBox_times.Text, 10),
                        amount.ToString("F2"), comboBox_paymentWay.Text, bookingDatetime, carLicensePlate, __Form_TrainBooking_confirm.cashierName, __Form_TrainBooking_confirm.cashierIDNumber, out message);
                else
                    mDBM.BookFromManagementByTime(textBox_idNumber.Text, comboBox_subjectName.Text, Convert.ToInt32(textBox_times.Text, 10),
                        amount.ToString("F2"), comboBox_paymentWay.Text, bookingDatetime, carLicensePlate, __Form_TrainBooking_confirm.cashierName, __Form_TrainBooking_confirm.cashierIDNumber, out message);

                MessageBox.Show(message, "提示");
            }

            textBox_name.Text = "";
            textBox_idNumber.Text = "";
            comboBox_gender.SelectedIndex = -1;
            comboBox_idType.SelectedIndex = -1;
            comboBox_driverLicenseType.SelectedIndex = -1;
            comboBox_schoolName.SelectedIndex = -1;
            textBox_times.Text = "";
            comboBox_subjectName.SelectedIndex = 1;
            comboBox_paymentWay.SelectedIndex = 0;
            radioButton_randomCar.Checked = true;

            dataGridView_student.DataSource = mDBM.Select(__StudentViewSQL).Tables[0];
        }
    }
}
