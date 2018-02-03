
using System;
using System.Drawing;
using System.Windows.Forms;
using static Client.DBM;


namespace Client
{
    public partial class Form_StudentExam : Form
    {
        public Form_StudentExam()
        {
            InitializeComponent();
        }

        private void Form_StudentScore_Load(object sender, EventArgs e)
        {
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

        const string examProgressView = @"select 
            VERIFY 校验,
            PROCESS_TIME as 时间,
            PROCESS_FLAG_DICT_NAME as 考试过程标识类型,
            PROCESS_TYPE_DICT_NAME as 考试过程类型,
            EXAM_ITEM as 考试项目,
            EXAM_ITEM_NAME as 考试项目名称,
            DEDUCT_ITEM as 扣分项目,
            DEDUCT_SCORE as 扣分分值,
            DEDUCT_ITEM_NAME as 扣分项目名称,
            PROCESS_PHOTO 过程照片
            from BUZ_EXAM_PROCESS_VIEW";

        const string sub2 = @"select
            VERIFY 校验,
            JDCJSZKSKMDM 科目,
	        JDCJSJNZKZMBH 准考证明编号,
        --	XXJSZMBH 学习驾驶证明编号,
	        JTGLYWDXSFZMDM 学员身份证明类型,
	        JTGLYWDXSFZMHM 身份证明号码,
	        XM 姓名,
	        KSYY 考试原因,
	        JDCJSZZJCXDM 驾驶证类型,
	        JDCJSZKSKCDM 考场代码,
	        KSCCBH 考试场次,
	        JDCHPHM 号牌号码,
	        JBR 经办人,
	        GLBM 管理部门,
	        DLR 代理人,
	        JDCJSRPXXXDM 驾校名称,
	        KSCS 考试次数,
	        CZY 操作员,
	        KSY1 考试员1,
	        KSY2 考试员2,
	        KSCJ 考试成绩,
	        KSQSSJ 考试起始时间,
	        KSJSSJ 考试结束时间,
	        KSCXH 考试车序号,
	        KSZT 考试状态,
        --	XKXM 选考项目,
	        ZHPPKF 综合评判扣分,
	        ZKKF 倒库扣分,
	        PDDDKF 坡起扣分,
	        CFTCKF 侧方扣分,
        --	DBQKF 通过单边桥扣分,
	        QXXSKF 曲线扣分,
	        ZJZWKF 直角扣分,
        --	XKMKF 通过限宽门扣分,
        --	LXZAKF 通过连续障碍扣分,
        --	QFLKF 起伏路行驶扣分,
        --	ZLDTKF 窄路调头扣分,
        --	GSKF 模拟高速公路行驶扣分,
        --	LXJWKF 模拟连续急弯山区路行驶扣分,
        --	SDKF 模拟隧道行驶扣分,
        --	YWKF 模拟雨(雾）天行驶扣分,
        --	SHKF 模拟湿滑路行驶扣分,
        --	JJQKF 模拟紧急情况处置扣分,
        --	ZXXM1 地方自选项目1,
        --	ZXXM2 地方自选项目2,
        --	ZXXM1=3 地方自选项目3,
        --	ZXXM1KF 地方自选项目1扣分,
        --	ZXXM2KF 地方自选项目2扣分,
        --	ZXXM3KF 地方自选项目3扣分,
	        JYW
            from BUZ_SUB2_RECORD_VIEW";

        private void dataGridView_studentExam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string exam_id = dataGridView_studentExam.SelectedRows[0].Cells["EXAM_ID"].Value.ToString();
            string status = dataGridView_studentExam.SelectedRows[0].Cells["状态"].Value.ToString();
            string idnumber = dataGridView_studentExam.SelectedRows[0].Cells["身份证明号码"].Value.ToString();

            string sql = examProgressView + $" where EXAM_ID='{exam_id}'";
            dataGridView_examProcess.DataSource = mDBM.Select(sql).Tables[0];
            dataGridView_examProcess.Columns["过程照片"].Visible = false;

            //check verify of examProcess
            bool warning = false;
            int warningCount = 0;
            for (int i = 0; i < dataGridView_examProcess.RowCount; i++)
                if (dataGridView_examProcess.Rows[i].Cells["校验"].Value.ToString() == "FALSE")
                {
                    warning = true;
                    warningCount++;
                    dataGridView_examProcess.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            if (warning)
                MessageBox.Show($"{warningCount}组数据被篡改", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            sql = sub2 + $" where JTGLYWDXSFZMHM='{idnumber}'";
            dataGridView_SUB2.DataSource = mDBM.Select(sql).Tables[0];

            //check verify of sub2
            warning = false;
            warningCount = 0;
            for (int i = 0; i < dataGridView_SUB2.RowCount; i++)
                if (dataGridView_SUB2.Rows[i].Cells["校验"].Value.ToString() == "FALSE")
                {
                    warning = true;
                    warningCount++;
                    dataGridView_SUB2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            if (warning)
                MessageBox.Show($"{warningCount}组数据被篡改", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            button_Score.Enabled = "合格" == status && 0 == dataGridView_SUB2.RowCount;
            button_misjudge.Enabled = "不合格" == status;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (!String.IsNullOrEmpty(comboBox_Status.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += $"STATUS='{comboBox_Status.Text}'";
            }
            if (!String.IsNullOrEmpty(textBox_Name.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += $"NAME='{textBox_Name.Text}'";
            }
            if (!String.IsNullOrEmpty(textBox_ID.Text))
            {
                sql += sql == "" ? "" : " and ";
                sql += $"IDNUMBER='{textBox_ID.Text}'";
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
        }

        private void button_misjudge_Click(object sender, EventArgs e)
        {
            string message;
            mDBM.HandleMisjudge(out message, "误判申请");
            MessageBox.Show(message, "提示");
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            string exam_id = dataGridView_studentExam.SelectedRows[0].Cells["EXAM_ID"].Value.ToString();
            string idNumber = dataGridView_studentExam.SelectedRows[0].Cells["身份证明号码"].Value.ToString();
            string message;
            mDBM.GenerateSUB2(out message, exam_id);

            string sql = sub2 + $" where JTGLYWDXSFZMHM='{idNumber}'";
            dataGridView_SUB2.DataSource = mDBM.Select(sql).Tables[0];

            new Form_Score(idNumber).ShowDialog();
        }

        private void button_all_Click(object sender, EventArgs e)
        {
            dataGridView_SUB2.DataSource = mDBM.Select(sub2).Tables[0];
            //check verify
        }

        private void dataGridView_SUB2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idNumber = (sender as DataGridView).Rows[e.RowIndex].Cells["身份证明号码"].Value.ToString();
            new Form_Score(idNumber).ShowDialog();
        }
    }
}
