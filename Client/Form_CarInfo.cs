
using Client.TMRI;
using System;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_CarInfo : Form
    {
        private const string carViewSQL = @"select 
            SEQUENCENUMBER as 序号, 
            SUBJECT_DICT_NAME as 考试科目, 
            LICENSE_PLATE_TYPE_DICT_NAME as 号牌种类, 
            CARNUMBER as 车辆编号, 
            LICENSE_PLATE as 车辆号牌号码, 
            QUALIFIED_CAR_TYPE as 适用准驾车型范围, 
            CAR_TYPE_DICT_NAME as 车辆类型, 
            BRAND as 车辆品牌, 
            REGISTER_DATE as 初次登记日期, 
            SCRAP_DATE as 强制报废期止, 
            ISSUING_AUTHORITY as 发证机关, 
            CAR_STATUS_DICT_NAME as 机动车车辆状态, 
            USE_STATUS_DICT_NAME as 车辆使用状态, 
            AUDITOR as 审核人, 
            CAR_IP as 车载IP, 
            CREATE_TIME as 创建时间, 
            UPDATE_TIME as 更新时间 
            from BAS_CAR_VIEW";

        public Form_CarInfo()
        {
            InitializeComponent();
        }

        private void Form_CarInfo_Load(object sender, EventArgs e)
        {
            dataGridView_car.DataSource = mDBM.Select(carViewSQL).Tables[0];

            comboBox_subject.Items.Clear();
            string sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=1006 order by VIEW_INDEX";
            comboBox_subject.Items.AddRange(mDBM.SelectArray(sql));
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string sql = "";

            if (!String.IsNullOrEmpty(textBox_sequenceNumber.Text))
            {
                sql += "SEQUENCENUMBER='" + textBox_sequenceNumber.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_carNumber.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "CARNUMBER='" + textBox_carNumber.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox_licensePlate.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "LICENSE_PLATE='" + textBox_licensePlate.Text + "'";
            }
            if (!String.IsNullOrEmpty(comboBox_subject.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += "SUBJECT_DICT_NAME='" + comboBox_subject.Text + "'";
            }

            sql = carViewSQL + (sql == "" ? "" : " where " + sql);
            dataGridView_car.DataSource = mDBM.Select(sql).Tables[0];
        }

        private void btn_car_append_Click(object sender, EventArgs e)
        {
            Form_CarInfo_appendModify form_CarInfo_appendModify = new Form_CarInfo_appendModify();
            form_CarInfo_appendModify.isAppend = true;
            form_CarInfo_appendModify.Text = "车辆信息添加";

            if (form_CarInfo_appendModify.ShowDialog() == DialogResult.OK)
                dataGridView_car.DataSource = mDBM.Select(carViewSQL).Tables[0];
        }

        private void dataGridView_car_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Form_CarInfo_appendModify form_CarInfo_appendModify = new Form_CarInfo_appendModify();
                form_CarInfo_appendModify.isAppend = false;
                form_CarInfo_appendModify.Text = "车辆信息修改";

                form_CarInfo_appendModify.licenseNo = dataGridView_car.Rows[e.RowIndex].Cells["车辆号牌号码"].Value.ToString();
                form_CarInfo_appendModify.subjectName = dataGridView_car.Rows[e.RowIndex].Cells["考试科目"].Value.ToString();
                form_CarInfo_appendModify.carNo = dataGridView_car.Rows[e.RowIndex].Cells["车辆编号"].Value.ToString();
                form_CarInfo_appendModify.qualifiedCarTypes = dataGridView_car.Rows[e.RowIndex].Cells["适用准驾车型范围"].Value.ToString();
                form_CarInfo_appendModify.carBrand = dataGridView_car.Rows[e.RowIndex].Cells["车辆品牌"].Value.ToString();
                form_CarInfo_appendModify.ip = dataGridView_car.Rows[e.RowIndex].Cells["车载IP"].Value.ToString();
                form_CarInfo_appendModify.scrapDate = dataGridView_car.Rows[e.RowIndex].Cells["强制报废期止"].Value.ToString();

                if (form_CarInfo_appendModify.ShowDialog() == DialogResult.OK)
                    dataGridView_car.DataSource = mDBM.Select(carViewSQL).Tables[0];
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            string message;
            TMRIQuery.QueryCar(out message, textBox_fzjg.Text, textBox_glbm.Text, textBox_kcxh.Text, textBox_gxsj.Text);
            MessageBox.Show(message);
            dataGridView_car.DataSource = mDBM.Select(carViewSQL).Tables[0];
        }

        private void dateTimePicker_gxsj_ValueChanged(object sender, EventArgs e)
        {
            if ((sender as DateTimePicker).Checked)
                textBox_gxsj.Text = dateTimePicker_gxsj.Text;
            else textBox_gxsj.Clear();
        }
    }
}
