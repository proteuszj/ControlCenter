
using Client.IDReader;
using System;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_TrainBooking : Form
    {
        private Form_TrainBooking_confirm form_TrainBooking_confirm;
#if false
        private IniFile iniFile = null;
#endif
        private const string studentViewSQL = @"select 
                NAME as 姓名, 
                GENDER_DICT_NAME as 性别, 
                IDTYPE_DICT_NAME as 身份证明类型, 
                IDNUMBER as 身份证明号码, 
                DRIVER_LICENSE_TYPE as 驾驶证类型, 
                SCHOOL_NAME as 驾校名称,
                BOOKED as 预约状态,
                BOOK_TIMES as 预约次数,
                LEFT_TIMES as 剩余次数
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
#if false
            iniFile = new IniFile(Form_Main.INIFILE_NAME);
            string[] nameList = iniFile.ReadValue("SchoolName", "School Name List").Split(',');
            comboBox_schoolName.Items.AddRange(nameList);
#endif

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

        private void btn_book_Click(object sender, EventArgs e)
        {
            string message;

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
            float amount = mDBM.GetPriceByTimes(Convert.ToInt32(textBox_times.Text, 10), startTime, comboBox_schoolName.Text, textBox_idNumber.Text, out message);

            // 预约确认
            form_TrainBooking_confirm = new Form_TrainBooking_confirm();
            form_TrainBooking_confirm.studentName = textBox_name.Text;
            form_TrainBooking_confirm.subjectName = comboBox_subjectName.Text;
            form_TrainBooking_confirm.times = textBox_times.Text;
            form_TrainBooking_confirm.amount = amount.ToString("F2");
            if (form_TrainBooking_confirm.ShowDialog() == DialogResult.OK)
            {
                string bookingDatetime = dateTimePicker_bookingDate.Value.ToString("yyyyMMdd") + comboBox_bookingTime.Text.Remove(5, 1).Remove(2, 1).Substring(0, 6);
                string carLicensePlate = radioButton_specifiedCar.Checked ? comboBox_car.Text : string.Empty;
                mDBM.BookFromManagement(textBox_idNumber.Text, comboBox_subjectName.Text, Convert.ToInt32(textBox_times.Text, 10),
                    amount.ToString("F2"), comboBox_paymentWay.Text, bookingDatetime, carLicensePlate, form_TrainBooking_confirm.cashierName, form_TrainBooking_confirm.cashierIDNumber, out message);

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

            dataGridView_student.DataSource = mDBM.Select(studentViewSQL).Tables[0];
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
            studentSQL = studentViewSQL + (studentSQL == "" ? "" : " where " + studentSQL);
            dataGridView_student.DataSource = mDBM.Select(studentSQL).Tables[0];

            string[] names = mDBM.SelectArray(studentSQL);

            // 学员注册
            if (names.Length == 0)
            {
                if (DialogResult.Yes == MessageBox.Show("学员不存在，是否注册", "提示", MessageBoxButtons.YesNo))
                {
                    Form_Student_appendModify form_Student_appendModify = new Form_Student_appendModify();
                    form_Student_appendModify.isAppend = true;
                    form_Student_appendModify.Text = "学员添加";

                    form_Student_appendModify.name = textBox_name.Text;
                    form_Student_appendModify.gender = comboBox_gender.Text;
                    form_Student_appendModify.idType = comboBox_idType.Text;
                    form_Student_appendModify.idNo = textBox_idNumber.Text;
                    form_Student_appendModify.driverType = comboBox_driverLicenseType.Text;
                    form_Student_appendModify.schoolName = comboBox_schoolName.Text;
                    form_Student_appendModify.photoBytes[0] = null;
                    form_Student_appendModify.photoBytes[1] = null;

                    if (form_Student_appendModify.ShowDialog() == DialogResult.OK)
                        dataGridView_student.DataSource = mDBM.Select(studentViewSQL).Tables[0];
                }
                else
                    return;
            }
        }

        private void dataGridView_student_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Form_Student_appendModify form_Student_appendModify = new Form_Student_appendModify();
                form_Student_appendModify.isAppend = false;
                form_Student_appendModify.Text = "学员修改";

                form_Student_appendModify.name = dataGridView_student.Rows[e.RowIndex].Cells["姓名"].Value.ToString();
                form_Student_appendModify.gender = dataGridView_student.Rows[e.RowIndex].Cells["性别"].Value.ToString();
                form_Student_appendModify.idType = dataGridView_student.Rows[e.RowIndex].Cells["身份证明类型"].Value.ToString();
                form_Student_appendModify.idNo = dataGridView_student.Rows[e.RowIndex].Cells["身份证明号码"].Value.ToString();
                form_Student_appendModify.driverType = dataGridView_student.Rows[e.RowIndex].Cells["驾驶证类型"].Value.ToString();
                form_Student_appendModify.schoolName = dataGridView_student.Rows[e.RowIndex].Cells["驾校名称"].Value.ToString();
                form_Student_appendModify.photoBytes[0] = null;
                form_Student_appendModify.photoBytes[1] = null;

                if (form_Student_appendModify.ShowDialog() == DialogResult.OK)
                    dataGridView_student.DataSource = mDBM.Select(studentViewSQL).Tables[0];
            }
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

        private void radioButton_specifiedCar_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_car.Enabled = ((sender as RadioButton).Checked);
        }

        private void button_bookingStatus_Click(object sender, EventArgs e)
        {
            Form_BookingStatus bookingStatus = new Form_BookingStatus();
            bookingStatus.DateString = dateTimePicker_bookingDate.Text;
            bookingStatus.TimeString = comboBox_bookingTime.Text;
            if (DialogResult.OK == bookingStatus.ShowDialog())
            {
                dateTimePicker_bookingDate.Text = bookingStatus.DateString;
                comboBox_bookingTime.Text = bookingStatus.TimeString;
            }
        }

        private void dateTimePicker_bookingDate_ValueChanged(object sender, EventArgs e)
        {
            comboBox_bookingTime.Items.Clear();
            string sql = "select DISPLAY_NAME from CFG_PARAM where PARAM_NAME like '__0000' and PARAM_VALUE='TRUE'";
            if ((sender as DateTimePicker).Value.Date == DateTime.Now.Date)
                sql += $" and substr(PARAM_NAME,1,2)>{DateTime.Now.Hour}";
            comboBox_bookingTime.Items.AddRange(mDBM.SelectArray(sql));
            if (comboBox_bookingTime.Items.Count > 0)
                comboBox_bookingTime.SelectedIndex = 0;
        }
    }
}
