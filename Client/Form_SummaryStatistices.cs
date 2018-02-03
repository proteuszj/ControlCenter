
using Client.IDReader;
using System;
using System.Data;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_SummaryStatistices : Form
    {
        private const string statisticSql = @"select {0}
                count (distinct BOOKING_SEQUENCENUMBER) 总人数,
                count (distinct (select BOOKING_SEQUENCENUMBER from BUZ_EXAM_INFO_VIEW b where a.ID=b.ID and EXAM_STATUS_DICT_NAME='合格')) 合格人数,
                --count (distinct (select BOOKING_SEQUENCENUMBER from BUZ_EXAM_INFO_VIEW b where a.ID=b.ID and EXAM_STATUS_DICT_NAME='不合格')) 不合格人数,
                count (distinct BOOKING_SEQUENCENUMBER)-count (distinct (select BOOKING_SEQUENCENUMBER from BUZ_EXAM_INFO_VIEW b where a.ID=b.ID and EXAM_STATUS_DICT_NAME='合格')) 不合格人数,
                count(*) 考试总人次,
                count ((select BOOKING_SEQUENCENUMBER from BUZ_EXAM_INFO_VIEW b where a.ID=b.ID and EXAM_STATUS_DICT_NAME='合格')) 合格人次,
                count ((select BOOKING_SEQUENCENUMBER from BUZ_EXAM_INFO_VIEW b where a.ID=b.ID and EXAM_STATUS_DICT_NAME='不合格')) 不合格人次,
                case when count(*)=0 then '-' else to_char(count(distinct (select BOOKING_SEQUENCENUMBER from BUZ_EXAM_INFO_VIEW b where a.ID=b.ID and EXAM_STATUS_DICT_NAME='合格'))*100/count (distinct BOOKING_SEQUENCENUMBER),'990.99')||'%' end 合格率
            from BUZ_EXAM_INFO_VIEW a
            where (EXAM_STATUS_DICT_NAME='合格' or EXAM_STATUS_DICT_NAME='不合格')
                and EXAM_START_TIME between {1} and {2} {3}";

        private const string statisticByDevice = @"select {0}
                count(distinct BOOKING_SEQUENCENUMBER) 总人数,
                count(distinct (select BOOKING_SEQUENCENUMBER from BUZ_EXAM_PROCESS_VIEW b where a.ID=b.ID and EXAM_STATUS_DICT_NAME='合格')) 合格人数,
                --count(distinct (select BOOKING_SEQUENCENUMBER from BUZ_EXAM_PROCESS_VIEW b where a.ID=b.ID and EXAM_STATUS_DICT_NAME='不合格')) 不合格人数,
                count(distinct BOOKING_SEQUENCENUMBER)-count(distinct (select BOOKING_SEQUENCENUMBER from BUZ_EXAM_PROCESS_VIEW b where a.ID=b.ID and EXAM_STATUS_DICT_NAME='合格')) 不合格人数,
                count(distinct EXAM_ID) 考试总人次,
                count(distinct (select EXAM_ID from BUZ_EXAM_PROCESS_VIEW b where a.ID=b.ID and EXAM_STATUS_DICT_NAME='合格')) 合格人次数,
                count(distinct (select EXAM_ID from BUZ_EXAM_PROCESS_VIEW b where a.ID=b.ID and EXAM_STATUS_DICT_NAME='不合格')) 不合格人次数,
                case when count(distinct EXAM_ID)=0 then '-' else to_char(count(distinct (select BOOKING_SEQUENCENUMBER from BUZ_EXAM_PROCESS_VIEW b where a.ID=b.ID and EXAM_STATUS_DICT_NAME='合格'))*100/count(distinct BOOKING_SEQUENCENUMBER),'990.99')||'%' end 合格率
            from BUZ_EXAM_PROCESS_VIEW a
            where (EXAM_STATUS_DICT_NAME='合格' or EXAM_STATUS_DICT_NAME='不合格') and DEVICE_NUMBER is not null
                and PROCESS_TIME between {1} and {2} {3}";

        public Form_SummaryStatistices()
        {
            InitializeComponent();
        }

        private void Form_SummaryStatistices_Load(object sender, EventArgs e)
        {
            comboBox_value.Items.Clear();
            comboBox_value.Items.Add("<全部>");
            comboBox_value.SelectedIndex = 0;
            comboBox_type.SelectedIndex = 0;
            comboBox_condition.SelectedIndex = 0;
        }

        private void button_readCard_Click(object sender, EventArgs e)
        {
            try
            {
                IDCardInfo info = IDCardReader.getInstance().CardInfo;
                textBox_name.Text = info.name;
                textBox_idNumber.Text = info.idNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_condition.SelectedIndex = 0;
            comboBox_value.SelectedIndex = 0;
        }

        private void comboBox_condition_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_value.SelectedIndex = 0;
        }

        private void comboBox_value_DropDown(object sender, EventArgs e)
        {
            string sql = "";

            comboBox_value.Items.Clear();
            comboBox_value.Items.Add("<全部>");

            switch (comboBox_condition.Text)
            {
                case "考车编号":
                    sql = "select SEQUENCENUMBER from BAS_CAR";
                    break;

                case "考试员":
                    sql = "select NAME from BAS_EXAMINER";
                    break;

                case "培训机构":
                    sql = "select NAME from BAS_DRIVING_SCHOOL";
                    break;

                case "考试原因":
                    sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1007 order by VIEW_INDEX";
                    break;

                case "考试车型":
                    sql = "select DICT_CODE from CFG_DICT where DICT_TYPE=2003 order by VIEW_INDEX";
                    break;

                case "设备编号":
                    sql = "select DEVICENUMBER from BAS_DEVICE";
                    break;
            }

            if (!String.IsNullOrEmpty(sql))
                comboBox_value.Items.AddRange(mDBM.SelectArray(sql));
        }

        private void btn_statistices_Click(object sender, EventArgs e)
        {
            string sql, condition, cond1, cond2;
            string startTime = dateTimePicker_startTime.Checked ? dateTimePicker_startTime.Value.Date.ToString("yyyyMMdd") + "000000" : "19000101000000";
            string endTime = dateTimePicker_endTime.Checked ? dateTimePicker_endTime.Value.Date.ToString("yyyyMMdd") + "235959" : DateTime.Now.ToString("yyyyMMdd") + "235959";

            dataGridView_Statistics.DataSource = null;
            dataGridView_Statistics.Rows.Clear();
            dataGridView_Statistics.Columns.Clear();

            switch (comboBox_type.Text)
            {
                case "合格率":
                    if ("<全部>" == comboBox_value.Text) condition = "";
                    else condition = comboBox_value.Text;
                    cond1 = "";
                    cond2 = "";
                    if (!string.IsNullOrEmpty(textBox_name.Text))
                        cond2 = cond2 + $" and STUDENT_NAME='{textBox_name.Text}' ";
                    if (!string.IsNullOrEmpty(textBox_idNumber.Text))
                        cond2 = cond2 + $" and STUDENT_IDNUMBER='{textBox_idNumber.Text}' ";
                    sql = statisticSql;
                    switch (comboBox_condition.Text)
                    {
                        case "考车编号":
                            if (string.IsNullOrEmpty(condition))
                            {
                                cond1 = "CARSEQUENCENUMBER 考车编号,";
                                cond2 += "group by CARSEQUENCENUMBER";
                            }
                            else
                                cond2 += $"and CARSEQUENCENUMBER='{condition}'";
                            break;
                        case "设备编号":
                            if (string.IsNullOrEmpty(condition))
                            {
                                cond1 = "DEVICE_NUMBER 设备编号,";
                                cond2 += "group by DEVICE_NUMBER";
                            }
                            else
                                cond2 += $"and DEVICE_NUMBER='{condition}'";
                            sql = statisticByDevice;
                            break;
                        case "考试员":
                            if (string.IsNullOrEmpty(condition))
                            {
                                cond1 = "EXAMINER1_NAME 考试员,";
                                cond2 += "group by EXAMINER1_NAME";
                            }
                            else
                                cond2 += $"and EXAMINER1_NAME='{condition}'";
                            break;
                        case "考试原因":
                            if (string.IsNullOrEmpty(condition))
                            {
                                cond1 = "EXAM_REASON 考试原因,";
                                cond2 += "group by EXAM_REASON";
                            }
                            else
                                cond2 += $"and EXAM_REASON='{condition}'";
                            break;
                        case "培训机构":
                            if (string.IsNullOrEmpty(condition))
                            {
                                cond1 = "SCHOOL_NAME 培训机构,";
                                cond2 += "group by SCHOOL_NAME";
                            }
                            else
                                cond2 += $"and SCHOOL_NAME='{condition}'";
                            break;
                        case "考试车型":
                            if (string.IsNullOrEmpty(condition))
                            {
                                cond1 = "DRIVER_LICENSE_TYPE 考试车型,";
                                cond2 += "group by DRIVER_LICENSE_TYPE";
                            }
                            else
                                cond2 += $"and DRIVER_LICENSE_TYPE='{condition}'";
                            break;
                    }
                    sql = string.Format(sql, cond1, startTime, endTime, cond2);
                    DataTable dt = mDBM.Select(sql).Tables[0];
                    for (int i = 0; i < dt.Columns.Count; i++)
                        dataGridView_Statistics.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].Caption);
                    for (int i = 0; i < dt.Rows.Count; i++)
                        dataGridView_Statistics.Rows.Add(dt.Rows[i].ItemArray);

                    // 总计
                    if (0 == comboBox_value.SelectedIndex && 0 != comboBox_condition.SelectedIndex && comboBox_condition.Text != "设备编号")
                    {
                        int index = dataGridView_Statistics.Rows.Add();
                        dataGridView_Statistics.Rows[index].Cells[0].Value = "总计";
                        for (int i = 1; i < dataGridView_Statistics.ColumnCount - 1; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < dataGridView_Statistics.RowCount - 1; j++)
                                sum += Convert.ToInt16(dataGridView_Statistics[i, j].Value);
                            dataGridView_Statistics[i, index].Value = sum;
                        }
                    }
                    break;

                case "扣分原因":
                    condition = "";
                    if (!string.IsNullOrEmpty(textBox_name.Text))
                        condition = condition + $" and STUDENT_NAME='{textBox_name.Text}' ";
                    if (!string.IsNullOrEmpty(textBox_idNumber.Text))
                        condition = condition + $" and STUDENT_IDNUMBER='{textBox_idNumber.Text}' ";
                    sql = "select (select ITEM_NAME from CFG_ITEMS where ITEM_CODE=A.PARENT_CODE) 考试项目, " +
                        "ITEM_CODE as 考试项目代码, ITEM_NAME as 扣分原因, -DEDUCT_SCORE as 扣分分数, " +
                        "(select count(*) from BUZ_EXAM_PROCESS_VIEW where DEDUCT_ITEM_NAME=ITEM_NAME " +
                        "and PROCESS_TYPE_DICT_NAME='扣分' and PROCESS_TIME between '{0}' and '{1}'{2}) 扣分次数 from CFG_ITEMS A where GRADE=3";

                    if (comboBox_condition.Text != "<全部>" && comboBox_value.Text != "<全部>")
                    {
                        switch (comboBox_condition.Text)
                        {
                            case "考车编号":
                                condition += $" and CARSEQUENCENUMBER='{comboBox_value.Text}'";
                                break;
                            case "考试员":
                                condition += $" and (EXAMINER1_NAME='{comboBox_value.Text}' or EXAMINER2_NAME='{comboBox_value.Text}')";
                                break;
                            case "培训机构":
                                condition += $" and SCHOOL_NAME='{comboBox_value.Text}'";
                                break;
                            case "考试原因":
                                condition += $" and EXAM_REASON='{comboBox_value.Text}'";
                                break;
                            case "考试车型":
                                condition += $" and CAR_TYPE='{comboBox_value.Text}'";
                                break;
                            case "设备编号":
                                condition += $" and DEVICE_NUMBER='{comboBox_value.Text}'";
                                break;
                        }
                    }

                    dataGridView_Statistics.DataSource = mDBM.Select(string.Format(sql, startTime, endTime, condition)).Tables[0];
                    break;

                case "考试项目":
                    condition = "";
                    if (!string.IsNullOrEmpty(textBox_name.Text))
                        condition = condition + $" and STUDENT_NAME='{textBox_name.Text}' ";
                    if (!string.IsNullOrEmpty(textBox_idNumber.Text))
                        condition = condition + $" and STUDENT_IDNUMBER='{textBox_idNumber.Text}' ";
                    sql = "select ITEM_NAME as 考试项目, " +
                        "(select count(*) from BUZ_EXAM_PROCESS_VIEW where EXAM_ITEM_NAME = ITEM_NAME and PROCESS_TYPE_DICT_NAME = '考试项目结束' and PROCESS_TIME between '{0}' and '{1}'{2}) 考试次数," +
                        "(select count(*) from BUZ_EXAM_PROCESS_VIEW where EXAM_ITEM_NAME = ITEM_NAME and PROCESS_TYPE_DICT_NAME = '扣分' and PROCESS_TIME between '{0}' and '{1}'{2}) 扣分次数 " +
                        "from CFG_ITEMS where PARENT_CODE = 20000";

                    if (comboBox_condition.Text != "<全部>" && comboBox_value.Text != "<全部>")
                    {
                        switch (comboBox_condition.Text)
                        {
                            case "考车编号":
                                condition += $" and CARSEQUENCENUMBER='{comboBox_value.Text}'";
                                break;
                            case "考试员":
                                condition += $" and (EXAMINER1_NAME='{comboBox_value.Text}' or EXAMINER2_NAME='{comboBox_value.Text}')";
                                break;
                            case "培训机构":
                                condition += $" and SCHOOL_NAME='{comboBox_value.Text}'";
                                break;
                            case "考试原因":
                                condition += $" and EXAM_REASON='{comboBox_value.Text}'";
                                break;
                            case "考试车型":
                                condition += $" and CAR_TYPE='{comboBox_value.Text}'";
                                break;
                            case "设备编号":
                                condition += $" and DEVICE_NUMBER='{comboBox_value.Text}'";
                                break;
                        }
                    }

                    dataGridView_Statistics.DataSource = mDBM.Select(string.Format(sql, startTime, endTime, condition)).Tables[0];
                    break;
            }
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            string message;
            string[] searchCondition = new string[] { dateTimePicker_startTime.Text, dateTimePicker_endTime.Text, comboBox_type.Text, comboBox_condition.Text, comboBox_value.Text };
            if (DialogResult.OK == saveFileDialog_excel.ShowDialog())
            {
                bool flag = Utils.SaveToExcel(dataGridView_Statistics, searchCondition, saveFileDialog_excel.FileName, out message);
                MessageBox.Show($"{message}：{saveFileDialog_excel.FileName}", flag ? "提示" : "错误", MessageBoxButtons.OK, flag ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
        }
    }
}
