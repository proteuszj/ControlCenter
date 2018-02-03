
using Client.IDReader;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_PaymentDetail : Form
    {
        private const string paymentDetailViewSQL = @"select 
            VERIFY as 校验,
            TRADE_NO as 交易流水号,
            ShowDateTime(PAY_TIME) as 支付时间,
            OPERATOR_NAME as 收银员名称,
            OPERATOR_IDNUMBER as 收银员身份证明号码,
            STUDENT_NAME as 学员名称,
            STUDENT_IDNUMBER as 学员身份证明号码,
            SCHOOL_NAME as 驾校名称,
            SUBJECT_DICT_NAME as 考试科目,
            FEE_TYPE_DICT_NAME as 收费类型,
            TIMES as 预约次数,
            AMOUNT as 金额,
            PAYMENT_WAY as 支付类型,
            DRIVER_LICENSE_TYPE as 驾驶证类型,
            ShowDateTime(BOOKING_DATETIME) 预约时间,
            CAR as 考试车辆
            from BUZ_PAYMENT_DETAIL_VIEW";

        public Form_PaymentDetail()
        {
            InitializeComponent();
            dateTimePicker_start.Value = DateTime.Now.Date;
            dateTimePicker_end.Value = DateTime.Now.Date;
            comboBox_school.Items.Clear();
            string sql = "select NAME from BAS_DRIVING_SCHOOL";
            comboBox_school.Items.AddRange(mDBM.SelectArray(sql));
            comboBox_car.Items.Clear();
            sql = "select LICENSE_PLATE from BAS_CAR";
            comboBox_car.Items.AddRange(mDBM.SelectArray(sql));
        }

        private void button_query_Click(object sender, EventArgs e)
        {
            string sql = $" where PAY_TIME>'{dateTimePicker_start.Value.ToString("yyyyMMdd") + "000000"}' and PAY_TIME<'{dateTimePicker_end.Value.ToString("yyyyMMdd") + "235959"}'";

            if (!String.IsNullOrEmpty(textBox_cashierName.Text))
                sql += $" and OPERATOR_NAME='{textBox_cashierName.Text}'";
            if (!String.IsNullOrEmpty(textBox_cashierIDNumber.Text))
                sql += $" and OPERATOR_IDNUMBER='{textBox_cashierIDNumber.Text}'";
            if (!String.IsNullOrEmpty(textBox_studentName.Text))
                sql += $" and STUDENT_NAME='{textBox_studentName.Text}'";
            if (!String.IsNullOrEmpty(textBox_studentIDNumber.Text))
                sql += $" and STUDENT_IDNUMBER='{textBox_studentIDNumber.Text}'";
            if (!String.IsNullOrEmpty(comboBox_school.Text))
                sql += $" and SCHOOL_NAME='{comboBox_school.Text}'";
            if (!String.IsNullOrEmpty(comboBox_car.Text))
                sql += $"and CAR='{comboBox_car.Text}'";

            sql = paymentDetailViewSQL + sql;
            DataTable dt = mDBM.Select(sql).Tables[0];

            dataGridView_paymentDetail.DataSource = null;
            dataGridView_paymentDetail.Rows.Clear();
            dataGridView_paymentDetail.Columns.Clear();
            for (int i = 0; i < dt.Columns.Count; i++)
                dataGridView_paymentDetail.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].Caption);
            dataGridView_paymentDetail.Columns["校验"].Visible = false;
            int warningCount = 0;
            int bookingTimesSum = 0;
            int bookingAmountSum = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView_paymentDetail.Rows.Add(dt.Rows[i].ItemArray);
                if (dataGridView_paymentDetail.Rows[i].Cells["校验"].Value.ToString() == "FALSE")
                {
                    warningCount++;
                    dataGridView_paymentDetail.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                bookingTimesSum += Convert.ToInt32(dataGridView_paymentDetail.Rows[i].Cells["预约次数"].Value);
                bookingAmountSum += Convert.ToInt32(dataGridView_paymentDetail.Rows[i].Cells["金额"].Value);
            }
            int index = dataGridView_paymentDetail.Rows.Add();
            dataGridView_paymentDetail.Rows[index].HeaderCell.Value = "合计";
            dataGridView_paymentDetail.Rows[index].Cells["预约次数"].Value = bookingTimesSum.ToString();
            dataGridView_paymentDetail.Rows[index].Cells["金额"].Value = bookingAmountSum.ToString();

            if (warningCount > 0)
                MessageBox.Show($"{warningCount}组数据被篡改", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            string message;
            string[] searchCondition = new string[] { dateTimePicker_start.Text, dateTimePicker_end.Text, textBox_cashierName.Text, textBox_cashierIDNumber.Text, textBox_studentName.Text, textBox_studentIDNumber.Text, comboBox_school.Text, comboBox_car.Text };
            if (DialogResult.OK == saveFileDialog_excel.ShowDialog())
            {
                bool flag = Utils.SaveToExcel(dataGridView_paymentDetail, searchCondition, saveFileDialog_excel.FileName, out message);
                MessageBox.Show($"{message}：{saveFileDialog_excel.FileName}", flag ? "提示" : "错误", MessageBoxButtons.OK, flag ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (sender == dateTimePicker_start)
            {
                DateTime start = (sender as DateTimePicker).Value;
                if (dateTimePicker_end.Value < start)
                    dateTimePicker_end.Value = start;
            }
            else if (sender == dateTimePicker_end)
            {
                DateTime end = (sender as DateTimePicker).Value;
                if (dateTimePicker_start.Value > end)
                    dateTimePicker_start.Value = end;
            }
        }

        private void button_readCashier_Click(object sender, EventArgs e)
        {
            try
            {
                IDCardInfo info = IDCardReader.getInstance().CardInfo;
                textBox_cashierName.Text = info.name;
                textBox_cashierIDNumber.Text = info.idNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_readStudent_Click(object sender, EventArgs e)
        {
            try
            {
                IDCardInfo info = IDCardReader.getInstance().CardInfo;
                textBox_studentName.Text = info.name;
                textBox_studentIDNumber.Text = info.idNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            dateTimePicker_start.Value = DateTime.Now;
            dateTimePicker_end.Value = DateTime.Now;
            textBox_cashierName.Clear();
            textBox_cashierIDNumber.Clear();
            textBox_studentName.Clear();
            textBox_studentIDNumber.Clear();
            comboBox_school.SelectedIndex = -1;
            comboBox_car.SelectedIndex = -1;
        }
    }
}
