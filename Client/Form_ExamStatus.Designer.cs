namespace Client
{
    partial class Form_ExamStatus
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_Student = new System.Windows.Forms.Panel();
            this.dataGridView_studentExam = new System.Windows.Forms.DataGridView();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.label_Status = new System.Windows.Forms.Label();
            this.panel_StudentExam = new System.Windows.Forms.Panel();
            this.panel_ExamProcess = new System.Windows.Forms.Panel();
            this.pictureBox_ProcessPhoto = new System.Windows.Forms.PictureBox();
            this.dataGridView_ExamProcess = new System.Windows.Forms.DataGridView();
            this.panel_StudentInfo = new System.Windows.Forms.Panel();
            this.textBox_CarSequenceNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Place = new System.Windows.Forms.TextBox();
            this.label_Place = new System.Windows.Forms.Label();
            this.textBox_Date = new System.Windows.Forms.TextBox();
            this.label_Date = new System.Windows.Forms.Label();
            this.textBox_Reason = new System.Windows.Forms.TextBox();
            this.label_Reason = new System.Windows.Forms.Label();
            this.textBox_DriverLicenseType = new System.Windows.Forms.TextBox();
            this.label_DriverLicenseType = new System.Windows.Forms.Label();
            this.textBox_StudyNumber = new System.Windows.Forms.TextBox();
            this.label_StudyNumber = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label_ID = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.pictureBox_Photo = new System.Windows.Forms.PictureBox();
            this.panel_Student.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_studentExam)).BeginInit();
            this.panel_StudentExam.SuspendLayout();
            this.panel_ExamProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProcessPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ExamProcess)).BeginInit();
            this.panel_StudentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Photo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Student
            // 
            this.panel_Student.Controls.Add(this.dataGridView_studentExam);
            this.panel_Student.Controls.Add(this.comboBox_Status);
            this.panel_Student.Controls.Add(this.label_Status);
            this.panel_Student.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Student.Location = new System.Drawing.Point(0, 0);
            this.panel_Student.Name = "panel_Student";
            this.panel_Student.Size = new System.Drawing.Size(200, 757);
            this.panel_Student.TabIndex = 0;
            // 
            // dataGridView_studentExam
            // 
            this.dataGridView_studentExam.AllowUserToAddRows = false;
            this.dataGridView_studentExam.AllowUserToDeleteRows = false;
            this.dataGridView_studentExam.AllowUserToResizeRows = false;
            this.dataGridView_studentExam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_studentExam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_studentExam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_studentExam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_studentExam.EnableHeadersVisualStyles = false;
            this.dataGridView_studentExam.Location = new System.Drawing.Point(3, 44);
            this.dataGridView_studentExam.MultiSelect = false;
            this.dataGridView_studentExam.Name = "dataGridView_studentExam";
            this.dataGridView_studentExam.ReadOnly = true;
            this.dataGridView_studentExam.RowHeadersVisible = false;
            this.dataGridView_studentExam.RowTemplate.Height = 30;
            this.dataGridView_studentExam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_studentExam.Size = new System.Drawing.Size(194, 710);
            this.dataGridView_studentExam.TabIndex = 2;
            this.dataGridView_studentExam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_studentExam_CellClick);
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.Items.AddRange(new object[] {
            "合格",
            "不合格",
            "未完成",
            "待考"});
            this.comboBox_Status.Location = new System.Drawing.Point(79, 12);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(107, 20);
            this.comboBox_Status.TabIndex = 1;
            this.comboBox_Status.TextChanged += new System.EventHandler(this.comboBox_Status_TextChanged);
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(11, 15);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(41, 12);
            this.label_Status.TabIndex = 0;
            this.label_Status.Text = "状态：";
            // 
            // panel_StudentExam
            // 
            this.panel_StudentExam.Controls.Add(this.panel_ExamProcess);
            this.panel_StudentExam.Controls.Add(this.panel_StudentInfo);
            this.panel_StudentExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_StudentExam.Location = new System.Drawing.Point(200, 0);
            this.panel_StudentExam.Name = "panel_StudentExam";
            this.panel_StudentExam.Size = new System.Drawing.Size(987, 757);
            this.panel_StudentExam.TabIndex = 1;
            // 
            // panel_ExamProcess
            // 
            this.panel_ExamProcess.Controls.Add(this.pictureBox_ProcessPhoto);
            this.panel_ExamProcess.Controls.Add(this.dataGridView_ExamProcess);
            this.panel_ExamProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ExamProcess.Location = new System.Drawing.Point(0, 285);
            this.panel_ExamProcess.Name = "panel_ExamProcess";
            this.panel_ExamProcess.Size = new System.Drawing.Size(987, 472);
            this.panel_ExamProcess.TabIndex = 1;
            // 
            // pictureBox_ProcessPhoto
            // 
            this.pictureBox_ProcessPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_ProcessPhoto.Location = new System.Drawing.Point(772, 6);
            this.pictureBox_ProcessPhoto.Name = "pictureBox_ProcessPhoto";
            this.pictureBox_ProcessPhoto.Size = new System.Drawing.Size(203, 276);
            this.pictureBox_ProcessPhoto.TabIndex = 2;
            this.pictureBox_ProcessPhoto.TabStop = false;
            // 
            // dataGridView_ExamProcess
            // 
            this.dataGridView_ExamProcess.AllowUserToAddRows = false;
            this.dataGridView_ExamProcess.AllowUserToDeleteRows = false;
            this.dataGridView_ExamProcess.AllowUserToResizeRows = false;
            this.dataGridView_ExamProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ExamProcess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ExamProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_ExamProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ExamProcess.EnableHeadersVisualStyles = false;
            this.dataGridView_ExamProcess.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_ExamProcess.MultiSelect = false;
            this.dataGridView_ExamProcess.Name = "dataGridView_ExamProcess";
            this.dataGridView_ExamProcess.ReadOnly = true;
            this.dataGridView_ExamProcess.RowHeadersVisible = false;
            this.dataGridView_ExamProcess.RowTemplate.Height = 30;
            this.dataGridView_ExamProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ExamProcess.Size = new System.Drawing.Size(766, 472);
            this.dataGridView_ExamProcess.TabIndex = 1;
            this.dataGridView_ExamProcess.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ExamProcess_CellClick);
            // 
            // panel_StudentInfo
            // 
            this.panel_StudentInfo.Controls.Add(this.textBox_CarSequenceNumber);
            this.panel_StudentInfo.Controls.Add(this.label1);
            this.panel_StudentInfo.Controls.Add(this.textBox_Place);
            this.panel_StudentInfo.Controls.Add(this.label_Place);
            this.panel_StudentInfo.Controls.Add(this.textBox_Date);
            this.panel_StudentInfo.Controls.Add(this.label_Date);
            this.panel_StudentInfo.Controls.Add(this.textBox_Reason);
            this.panel_StudentInfo.Controls.Add(this.label_Reason);
            this.panel_StudentInfo.Controls.Add(this.textBox_DriverLicenseType);
            this.panel_StudentInfo.Controls.Add(this.label_DriverLicenseType);
            this.panel_StudentInfo.Controls.Add(this.textBox_StudyNumber);
            this.panel_StudentInfo.Controls.Add(this.label_StudyNumber);
            this.panel_StudentInfo.Controls.Add(this.textBox_ID);
            this.panel_StudentInfo.Controls.Add(this.label_ID);
            this.panel_StudentInfo.Controls.Add(this.textBox_Name);
            this.panel_StudentInfo.Controls.Add(this.label_Name);
            this.panel_StudentInfo.Controls.Add(this.pictureBox_Photo);
            this.panel_StudentInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_StudentInfo.Location = new System.Drawing.Point(0, 0);
            this.panel_StudentInfo.Name = "panel_StudentInfo";
            this.panel_StudentInfo.Size = new System.Drawing.Size(987, 285);
            this.panel_StudentInfo.TabIndex = 0;
            // 
            // textBox_CarSequenceNumber
            // 
            this.textBox_CarSequenceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_CarSequenceNumber.Location = new System.Drawing.Point(523, 150);
            this.textBox_CarSequenceNumber.Name = "textBox_CarSequenceNumber";
            this.textBox_CarSequenceNumber.ReadOnly = true;
            this.textBox_CarSequenceNumber.Size = new System.Drawing.Size(452, 21);
            this.textBox_CarSequenceNumber.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "考车编号：";
            // 
            // textBox_Place
            // 
            this.textBox_Place.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Place.Location = new System.Drawing.Point(291, 249);
            this.textBox_Place.Name = "textBox_Place";
            this.textBox_Place.ReadOnly = true;
            this.textBox_Place.Size = new System.Drawing.Size(684, 21);
            this.textBox_Place.TabIndex = 28;
            // 
            // label_Place
            // 
            this.label_Place.AutoSize = true;
            this.label_Place.Location = new System.Drawing.Point(189, 252);
            this.label_Place.Name = "label_Place";
            this.label_Place.Size = new System.Drawing.Size(65, 12);
            this.label_Place.TabIndex = 27;
            this.label_Place.Text = "考试地点：";
            // 
            // textBox_Date
            // 
            this.textBox_Date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Date.Location = new System.Drawing.Point(306, 199);
            this.textBox_Date.Name = "textBox_Date";
            this.textBox_Date.ReadOnly = true;
            this.textBox_Date.Size = new System.Drawing.Size(669, 21);
            this.textBox_Date.TabIndex = 26;
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Location = new System.Drawing.Point(189, 202);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(65, 12);
            this.label_Date.TabIndex = 25;
            this.label_Date.Text = "考试日期：";
            // 
            // textBox_Reason
            // 
            this.textBox_Reason.Location = new System.Drawing.Point(291, 150);
            this.textBox_Reason.Name = "textBox_Reason";
            this.textBox_Reason.ReadOnly = true;
            this.textBox_Reason.Size = new System.Drawing.Size(109, 21);
            this.textBox_Reason.TabIndex = 24;
            // 
            // label_Reason
            // 
            this.label_Reason.AutoSize = true;
            this.label_Reason.Location = new System.Drawing.Point(189, 153);
            this.label_Reason.Name = "label_Reason";
            this.label_Reason.Size = new System.Drawing.Size(65, 12);
            this.label_Reason.TabIndex = 23;
            this.label_Reason.Text = "考试原因：";
            // 
            // textBox_DriverLicenseType
            // 
            this.textBox_DriverLicenseType.Location = new System.Drawing.Point(291, 96);
            this.textBox_DriverLicenseType.Name = "textBox_DriverLicenseType";
            this.textBox_DriverLicenseType.ReadOnly = true;
            this.textBox_DriverLicenseType.Size = new System.Drawing.Size(110, 21);
            this.textBox_DriverLicenseType.TabIndex = 20;
            // 
            // label_DriverLicenseType
            // 
            this.label_DriverLicenseType.AutoSize = true;
            this.label_DriverLicenseType.Location = new System.Drawing.Point(189, 99);
            this.label_DriverLicenseType.Name = "label_DriverLicenseType";
            this.label_DriverLicenseType.Size = new System.Drawing.Size(65, 12);
            this.label_DriverLicenseType.TabIndex = 19;
            this.label_DriverLicenseType.Text = "考试车型：";
            // 
            // textBox_StudyNumber
            // 
            this.textBox_StudyNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_StudyNumber.Location = new System.Drawing.Point(595, 96);
            this.textBox_StudyNumber.Name = "textBox_StudyNumber";
            this.textBox_StudyNumber.ReadOnly = true;
            this.textBox_StudyNumber.Size = new System.Drawing.Size(380, 21);
            this.textBox_StudyNumber.TabIndex = 18;
            // 
            // label_StudyNumber
            // 
            this.label_StudyNumber.AutoSize = true;
            this.label_StudyNumber.Location = new System.Drawing.Point(419, 99);
            this.label_StudyNumber.Name = "label_StudyNumber";
            this.label_StudyNumber.Size = new System.Drawing.Size(113, 12);
            this.label_StudyNumber.TabIndex = 17;
            this.label_StudyNumber.Text = "学习驾驶证明号码：";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ID.Location = new System.Drawing.Point(595, 41);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.textBox_ID.Size = new System.Drawing.Size(380, 21);
            this.textBox_ID.TabIndex = 22;
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(419, 44);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(89, 12);
            this.label_ID.TabIndex = 21;
            this.label_ID.Text = "身份证明号码：";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(291, 41);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.ReadOnly = true;
            this.textBox_Name.Size = new System.Drawing.Size(109, 21);
            this.textBox_Name.TabIndex = 16;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(189, 44);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(41, 12);
            this.label_Name.TabIndex = 15;
            this.label_Name.Text = "姓名：";
            // 
            // pictureBox_Photo
            // 
            this.pictureBox_Photo.Location = new System.Drawing.Point(6, 15);
            this.pictureBox_Photo.Name = "pictureBox_Photo";
            this.pictureBox_Photo.Size = new System.Drawing.Size(177, 233);
            this.pictureBox_Photo.TabIndex = 0;
            this.pictureBox_Photo.TabStop = false;
            // 
            // Form_ExamStatus
            // 
            this.ClientSize = new System.Drawing.Size(1187, 757);
            this.ControlBox = false;
            this.Controls.Add(this.panel_StudentExam);
            this.Controls.Add(this.panel_Student);
            this.Name = "Form_ExamStatus";
            this.Text = "考试状态";
            this.panel_Student.ResumeLayout(false);
            this.panel_Student.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_studentExam)).EndInit();
            this.panel_StudentExam.ResumeLayout(false);
            this.panel_ExamProcess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProcessPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ExamProcess)).EndInit();
            this.panel_StudentInfo.ResumeLayout(false);
            this.panel_StudentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Photo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Student;
        private System.Windows.Forms.ComboBox comboBox_Status;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.DataGridView dataGridView_studentExam;
        private System.Windows.Forms.Panel panel_StudentExam;
        private System.Windows.Forms.Panel panel_ExamProcess;
        private System.Windows.Forms.Panel panel_StudentInfo;
        private System.Windows.Forms.PictureBox pictureBox_Photo;
        private System.Windows.Forms.TextBox textBox_Place;
        private System.Windows.Forms.Label label_Place;
        private System.Windows.Forms.TextBox textBox_Date;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.TextBox textBox_Reason;
        private System.Windows.Forms.Label label_Reason;
        private System.Windows.Forms.TextBox textBox_DriverLicenseType;
        private System.Windows.Forms.Label label_DriverLicenseType;
        private System.Windows.Forms.TextBox textBox_StudyNumber;
        private System.Windows.Forms.Label label_StudyNumber;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.DataGridView dataGridView_ExamProcess;
        private System.Windows.Forms.PictureBox pictureBox_ProcessPhoto;
        private System.Windows.Forms.TextBox textBox_CarSequenceNumber;
        private System.Windows.Forms.Label label1;
    }
}
