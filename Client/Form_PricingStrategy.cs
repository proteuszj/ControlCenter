
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_PricingStrategy : Form
    {
        const string pricingStrategyView = @"select
            ID,
            PRIORITY 优先级,
            ACTION_DICT_NAME 行为,
            AMOUNT 金额,
            EFFECTIVE_DATE 生效日期,
            EXPIRED_DATE 失效日期,
            START_DATE 开始日期,
            END_DATE 结束日期,
            START_TIME 开始时间,
            END_TIME 结束时间,
            SCHOOL_NAME 驾校名称,
            STUDENT_IDNUMBER 学员身份证号,
            REFERENCE_METHOD1_DICT_NAME 参考方法1,
            REFERENCE_AMOUNT1 金额1,
            REFERENCE_RELATION_NAME 关系,
            REFERENCE_METHOD2_DICT_NAME 参考方法2,
            REFERENCE_AMOUNT2 金额2
            from CFG_PRICING_STRATEGY_VIEW";

        public Form_PricingStrategy()
        {
            InitializeComponent();

            numericUpDown_bookingDateLimt.Value = Convert.ToByte(ConfigParameters.getValue("BOOKING_DATE_LIMIT"));
            for (int i = 0; i < checkedListBox_bookingTimeSetting.Items.Count; i++)
                    checkedListBox_bookingTimeSetting.SetItemChecked(i, "TRUE" == ConfigParameters.getValue(checkedListBox_bookingTimeSetting.Items[i].ToString().Remove(5,1).Remove(2,1)));

            comboBox_action.Items.Clear();
            string sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1037 order by VIEW_INDEX";
            comboBox_action.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_schoolName.Items.Clear();
            comboBox_schoolNameForTest.Items.Clear();
            sql = "select NAME from BAS_DRIVING_SCHOOL";
            comboBox_schoolName.Items.AddRange(mDBM.SelectArray(sql));
            comboBox_schoolNameForTest.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_referenceMethod1.Items.Clear();
            comboBox_referenceMethod2.Items.Clear();
            sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1038 order by VIEW_INDEX";
            comboBox_referenceMethod1.Items.AddRange(mDBM.SelectArray(sql));
            comboBox_referenceMethod2.Items.AddRange(mDBM.SelectArray(sql));

            dataGridView_pricingStrategy.DataSource = mDBM.Select(pricingStrategyView).Tables[0];
        }

        private void comboBox_reference_TextChanged(object sender, EventArgs e)
        {
            if (sender == comboBox_referenceMethod1 || sender == textBox_referenceAmount1)
            {
                comboBox_referenceRelation.Enabled = !string.IsNullOrEmpty(comboBox_referenceMethod1.Text) && !string.IsNullOrEmpty(textBox_referenceAmount1.Text);
                if (!comboBox_referenceRelation.Enabled)
                    comboBox_referenceMethod2.Enabled = textBox_referenceAmount2.Enabled = false;
            }
            else if (sender == comboBox_referenceRelation)
                comboBox_referenceMethod2.Enabled = textBox_referenceAmount2.Enabled = !string.IsNullOrEmpty(comboBox_referenceRelation.Text);
        }

        private void button_showAll_Click(object sender, EventArgs e)
        {
            dataGridView_pricingStrategy.DataSource = mDBM.Select(pricingStrategyView).Tables[0];
        }

        private void button_filter_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (!String.IsNullOrEmpty(numericUpDown_priority.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "PRIORITY='" + numericUpDown_priority.Text + "'";
            }
            if (!string.IsNullOrEmpty(comboBox_action.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "ACTION_DICT_NAME='" + comboBox_action.Text + "'";
            }
            if (dateTimePicker_startDate.Checked)
            {
                sql += sql == "" ? "" : " and ";
                sql += "START_DATE>='" + dateTimePicker_startDate.Value.ToString("yyyyMMdd") + "'";
            }
            if (dateTimePicker_endDate.Checked)
            {
                sql += sql == "" ? "" : " and ";
                sql += "END_DATE<='" + dateTimePicker_endDate.Value.ToString("yyyyMMdd") + "'";
            }
            if (dateTimePicker_startTime.Checked)
            {
                sql += sql == "" ? "" : " and ";
                sql += "START_TIME>='" + dateTimePicker_startTime.Value.ToString("yyyyMMdd") + "'";
            }
            if (dateTimePicker_endTime.Checked)
            {
                sql += sql == "" ? "" : " and ";
                sql += "END_TIME<='" + dateTimePicker_endTime.Value.ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(comboBox_schoolName.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "SCHOOL_NAME='" + comboBox_schoolName.Text + "'";
            }
            if (!string.IsNullOrEmpty(textBox_studentIDNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "STUDENT_IDNUMBER='" + textBox_studentIDNumber.Text + "'";
            }
            if (!string.IsNullOrEmpty(comboBox_referenceMethod1.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "REFERENCE_METHOD1_DICT_NAME='" + comboBox_referenceMethod1.Text + "'";
            }
            if (!string.IsNullOrEmpty(textBox_referenceAmount1.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "REFERENCE_AMOUNT1='" + textBox_referenceAmount1.Text + "'";
            }
            if (!string.IsNullOrEmpty(comboBox_referenceRelation.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "REFERENCE_RELATION_NAME='" + comboBox_referenceRelation.Text + "'";
            }
            if (!string.IsNullOrEmpty(comboBox_referenceMethod2.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "REFERENCE_METHOD2_DICT_NAME='" + comboBox_referenceMethod2.Text + "'";
            }
            if (!string.IsNullOrEmpty(textBox_referenceAmount2.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "REFERENCE_AMOUNT2='" + textBox_referenceAmount2.Text + "'";
            }
            if (dateTimePicker_effectiveDate.Checked)
            {
                sql += sql == "" ? "" : " and ";
                sql += "EFFECTIVE_DATE>='" + dateTimePicker_effectiveDate.Value.ToString("yyyyMMdd") + "'";
            }
            if (dateTimePicker_expireDate.Checked)
            {
                sql += sql == "" ? "" : " and ";
                sql += "EXPIRED_DATE<='" + dateTimePicker_expireDate.Value.ToString("yyyyMMdd") + "'";
            }
            sql = pricingStrategyView + (sql == "" ? "" : " where " + sql);
            dataGridView_pricingStrategy.DataSource = mDBM.Select(sql).Tables[0];
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(numericUpDown_priority.Text) || String.IsNullOrEmpty(comboBox_action.Text) || String.IsNullOrEmpty(textBox_amount.Text))
            {
                MessageBox.Show("优先级、行为和金额不能为空", "提示");
                return;
            }

            string effectiveDate, expiredDate, startDate, endDate, startTime, endTime;
            effectiveDate = dateTimePicker_effectiveDate.Checked ? dateTimePicker_effectiveDate.Value.ToString("yyyyMMdd") : "";
            expiredDate = dateTimePicker_expireDate.Checked ? dateTimePicker_expireDate.Value.ToString("yyyyMMdd") : "";
            startDate = dateTimePicker_startDate.Checked ? dateTimePicker_startDate.Value.ToString("yyyyMMdd") : "";
            endDate = dateTimePicker_endDate.Checked ? dateTimePicker_endDate.Value.ToString("yyyyMMdd") : "";
            startTime = dateTimePicker_startTime.Checked ? dateTimePicker_startTime.Value.ToString("HHmmss") : "";
            endTime = dateTimePicker_endTime.Checked ? dateTimePicker_endTime.Value.ToString("HHmmss") : "";
            string refMethod1 = comboBox_referenceMethod1.Text;
            string refAmount1 = textBox_referenceAmount1.Text;
            string refRelation = comboBox_referenceRelation.Enabled ? comboBox_referenceRelation.Text : "";
            string refMethod2 = comboBox_referenceMethod2.Enabled ? comboBox_referenceMethod2.Text : "";
            string refAmount2 = textBox_referenceAmount2.Enabled ? textBox_referenceAmount2.Text : "";

            string message = "";
            try
            {
                mDBM.AddUpdatePricingStrategy(numericUpDown_priority.Text, comboBox_action.Text, textBox_amount.Text, effectiveDate,
                    expiredDate, startDate, endDate, startTime, endTime, comboBox_schoolName.Text, textBox_studentIDNumber.Text,
                    refMethod1, refAmount1, refRelation, refMethod2, refAmount2, out message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                return;
            }

            MessageBox.Show(message);

            dataGridView_pricingStrategy.DataSource = mDBM.Select(pricingStrategyView).Tables[0];
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView_pricingStrategy.SelectedRows[0].Cells["ID"].Value);
            OracleCommand cmd = mDBM.conn.CreateCommand();
            cmd.CommandText = $"delete from CFG_PRICING_STRATEGY where ID={id}";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dataGridView_pricingStrategy.DataSource = mDBM.Select(pricingStrategyView).Tables[0];
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_start.Text) || String.IsNullOrEmpty(textBox_end.Text))
            {
                MessageBox.Show("起始次数和结束次数不能为空", "提示");
            }

            dataGridView_testResult.Rows.Clear();


            string startTime = dateTimePicker_bookingTime.Checked ? dateTimePicker_bookingTime.Value.ToString("yyyyMMddHHmmss") : DateTime.Now.ToString("yyyyMMddHHmmss");
            float amount = 0;
            string message;
            int start = 1, end = 10;
            try
            {
                start = Convert.ToInt32(textBox_start.Text, 10);
                end = Convert.ToInt32(textBox_end.Text, 10);
            }
            catch (FormatException)
            {
            }
            textBox_start.Text = start.ToString();
            textBox_end.Text = end.ToString();

            for (int times = start; times <= end; times++)
            {
                amount = mDBM.GetPriceByTimes(times, startTime, comboBox_schoolNameForTest.Text, textBox_studentIDNumberForTest.Text, out message);

                dataGridView_testResult.Rows.Add();
                dataGridView_testResult.Rows[dataGridView_testResult.Rows.Count - 1].Cells[0].Value = times;
                dataGridView_testResult.Rows[dataGridView_testResult.Rows.Count - 1].Cells[1].Value = amount;
            }
        }

        private void dataGridView_pricingStrategy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                numericUpDown_priority.Text = dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["优先级"].Value.ToString();
                comboBox_action.Text = dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["行为"].Value.ToString();
                textBox_amount.Text = dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["金额"].Value.ToString();
                comboBox_schoolName.Text = dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["驾校名称"].Value.ToString();
                textBox_studentIDNumber.Text = dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["学员身份证号"].Value.ToString();
                comboBox_referenceMethod1.Text = dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["参考方法1"].Value.ToString();
                textBox_referenceAmount1.Text = dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["金额1"].Value.ToString();
                comboBox_referenceRelation.Text = dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["关系"].Value.ToString();
                comboBox_referenceMethod2.Text = dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["参考方法2"].Value.ToString();
                textBox_referenceAmount2.Text = dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["金额2"].Value.ToString();
                if (dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["开始日期"].Value.ToString() == "")
                {
                    dateTimePicker_startDate.Checked = false;
                }
                else
                {
                    dateTimePicker_startDate.Checked = true;
                    dateTimePicker_startDate.Value = DateTime.ParseExact(dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["开始日期"].Value.ToString(), "yyyyMMdd", null);
                }
                if (dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["结束日期"].Value.ToString() == "")
                {
                    dateTimePicker_endDate.Checked = false;
                }
                else
                {
                    dateTimePicker_endDate.Checked = true;
                    dateTimePicker_endDate.Value = DateTime.ParseExact(dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["结束日期"].Value.ToString(), "yyyyMMdd", null);
                }
                if (dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["开始时间"].Value.ToString() == "")
                {
                    dateTimePicker_startTime.Checked = false;
                }
                else
                {
                    dateTimePicker_startTime.Checked = true;
                    dateTimePicker_startTime.Value = DateTime.ParseExact(dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["开始时间"].Value.ToString(), "HHmmss", null);
                }
                if (dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["结束时间"].Value.ToString() == "")
                {
                    dateTimePicker_endTime.Checked = false;
                }
                else
                {
                    dateTimePicker_endTime.Checked = true;
                    dateTimePicker_endTime.Value = DateTime.ParseExact(dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["结束时间"].Value.ToString(), "HHmmss", null);
                }
                if (dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["生效日期"].Value.ToString() == "")
                {
                    dateTimePicker_effectiveDate.Checked = false;
                }
                else
                {
                    dateTimePicker_effectiveDate.Checked = true;
                    dateTimePicker_effectiveDate.Value = DateTime.ParseExact(dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["生效日期"].Value.ToString(), "yyyyMMdd", null);
                }
                if (dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["失效日期"].Value.ToString() == "")
                {
                    dateTimePicker_expireDate.Checked = false;
                }
                else
                {
                    dateTimePicker_expireDate.Checked = true;
                    dateTimePicker_expireDate.Value = DateTime.ParseExact(dataGridView_pricingStrategy.Rows[e.RowIndex].Cells["失效日期"].Value.ToString(), "yyyyMMdd", null);
                }
            }
        }

        private void button_setValue_Click(object sender, EventArgs e)
        {
            ConfigParameters.setValue("BOOKING_DATE_LIMIT", numericUpDown_bookingDateLimt.Value.ToString());
            for (int i = 0; i < checkedListBox_bookingTimeSetting.Items.Count; i++)
                if (checkedListBox_bookingTimeSetting.GetItemChecked(i))
                    ConfigParameters.setValue(checkedListBox_bookingTimeSetting.Items[i].ToString().Remove(5, 1).Remove(2, 1), "TRUE");
                else
                    ConfigParameters.setValue(checkedListBox_bookingTimeSetting.Items[i].ToString().Remove(5, 1).Remove(2, 1), "FALSE");
            MessageBox.Show("参数写入成功", "提示");
        }

        private void checkedListBox_bookingTimeSetting_Enter(object sender, EventArgs e)
        {
            (sender as CheckedListBox).Height = 200;
        }

        private void checkedListBox_bookingTimeSetting_Leave(object sender, EventArgs e)
        {
            (sender as CheckedListBox).Height = 20;
        }
    }
}
