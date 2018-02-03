
using Client.TMRI;
using System;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_DeviceInfo : Form
    {
        private const string deviceViewSQL = @"select 
            SEQUENCENUMBER as 序号, 
            DEVICENUMBER as 设备编号, 
            DESCRIPTION as 设备描述, 
            MANUFACTURER as 制造厂商, 
            SERIALNUMBER as 设备型号, 
            EXAM_ITEM as 考试项目, 
            EXAM_ITEM_NAME as 考试项目名称, 
            JUDGING_TYPE as 评判方式, 
            PLACE_NAME as 考场名称, 
            PLACE_SEQUENCENUMBER as 考场序号,
            PLACE_CODE as 考场代码, 
            QUALIFIED_CAR_TYPE as 适用准驾车型范围, 
            ACCEPTANCE_DATE as 验收日期, 
            SINGLE_EXAM_TIMES as 备案单次考试时间, 
            HOURLY_EXAM_TIMES as 备案每小时考试人次, 
            EXPIRE_DATE as 有效截止日期, 
            STATUS as 使用状态, 
            CREATE_TIME as 创建时间, 
            UPDATE_TIME as 更新时间 
            from BAS_DEVICE_VIEW";

        public Form_DeviceInfo()
        {
            InitializeComponent();
        }

        private void Form_DeviceInfo_Load(object sender, EventArgs e)
        {
            dataGridView_device.DataSource = mDBM.Select(deviceViewSQL).Tables[0];
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string sql = "";

            if (!String.IsNullOrEmpty(textBox_sequenceNumber.Text))
            {
                sql += "SEQUENCENUMBER='" + textBox_sequenceNumber.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_deviceNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "DEVICENUMBER='" + textBox_deviceNumber.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_serialNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "SERIALNUMBER='" + textBox_serialNumber.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_status.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "STATUS='" + textBox_status.Text + "'";
            }

            sql = deviceViewSQL + (sql == "" ? "" : " where " + sql);
            dataGridView_device.DataSource = mDBM.Select(sql).Tables[0];
        }

        private void btn_device_append_Click(object sender, EventArgs e)
        {
            Form_DeviceInfo_appendModify form_DeviceInfo_appendModify = new Form_DeviceInfo_appendModify();
            form_DeviceInfo_appendModify.isAppend = true;
            form_DeviceInfo_appendModify.Text = "设备信息添加";

            if (form_DeviceInfo_appendModify.ShowDialog() == DialogResult.OK)
                dataGridView_device.DataSource = mDBM.Select(deviceViewSQL).Tables[0];
        }

        private void dataGridView_device_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Form_DeviceInfo_appendModify form_DeviceInfo_appendModify = new Form_DeviceInfo_appendModify();
                form_DeviceInfo_appendModify.isAppend = false;
                form_DeviceInfo_appendModify.Text = "设备信息修改";

                form_DeviceInfo_appendModify.deviceNo = dataGridView_device.Rows[e.RowIndex].Cells["设备编号"].Value.ToString();
                form_DeviceInfo_appendModify.deviceDescription = dataGridView_device.Rows[e.RowIndex].Cells["设备描述"].Value.ToString();
                form_DeviceInfo_appendModify.deviceManufacture = dataGridView_device.Rows[e.RowIndex].Cells["制造厂商"].Value.ToString();
                form_DeviceInfo_appendModify.deviceSerial = dataGridView_device.Rows[e.RowIndex].Cells["设备型号"].Value.ToString();
                form_DeviceInfo_appendModify.examItemName = dataGridView_device.Rows[e.RowIndex].Cells["考试项目名称"].Value.ToString();
                form_DeviceInfo_appendModify.placeCode = dataGridView_device.Rows[e.RowIndex].Cells["考场代码"].Value.ToString();
                form_DeviceInfo_appendModify.acceptanceDate = dataGridView_device.Rows[e.RowIndex].Cells["验收日期"].Value.ToString();
                form_DeviceInfo_appendModify.expireDate = dataGridView_device.Rows[e.RowIndex].Cells["有效截止日期"].Value.ToString();

                if (form_DeviceInfo_appendModify.ShowDialog() == DialogResult.OK)
                    dataGridView_device.DataSource = mDBM.Select(deviceViewSQL).Tables[0];
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            string message;
            TMRIQuery.QueryDevice(out message, textBox_fzjg.Text, textBox_kcxh.Text, textBox_gxsj.Text);
            MessageBox.Show(message);
            dataGridView_device.DataSource = mDBM.Select(deviceViewSQL).Tables[0];
        }

        private void dateTimePicker_gxsj_ValueChanged(object sender, EventArgs e)
        {
            if ((sender as DateTimePicker).Checked)
                textBox_gxsj.Text = dateTimePicker_gxsj.Text;
            else textBox_gxsj.Clear();
        }
    }
}
