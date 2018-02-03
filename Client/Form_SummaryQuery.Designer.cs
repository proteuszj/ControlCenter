namespace Client
{
    partial class Form_SummaryQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.comboBox_deviceNumber = new System.Windows.Forms.ComboBox();
            this.label_deviceNumber = new System.Windows.Forms.Label();
            this.textBox_examNumber = new System.Windows.Forms.TextBox();
            this.label_examNumber = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_idNumber = new System.Windows.Forms.TextBox();
            this.label_idNumber = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.btn_query = new System.Windows.Forms.Button();
            this.comboBox_driverLicenseType = new System.Windows.Forms.ComboBox();
            this.label_driverLicenseType = new System.Windows.Forms.Label();
            this.comboBox_subject = new System.Windows.Forms.ComboBox();
            this.comboBox_examReason = new System.Windows.Forms.ComboBox();
            this.label_subject = new System.Windows.Forms.Label();
            this.label_examReason = new System.Windows.Forms.Label();
            this.label_carSequenceNumber = new System.Windows.Forms.Label();
            this.label_school = new System.Windows.Forms.Label();
            this.comboBox_examiner = new System.Windows.Forms.ComboBox();
            this.comboBox_carSequenceNumber = new System.Windows.Forms.ComboBox();
            this.label_examiner = new System.Windows.Forms.Label();
            this.comboBox_school = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_date = new System.Windows.Forms.TabPage();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Export = new System.Windows.Forms.Button();
            this.dataGridView_ExamInfo = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel_ProcessPhoto = new System.Windows.Forms.Panel();
            this.pictureBox_ProcessPhoto = new System.Windows.Forms.PictureBox();
            this.dataGridView_ExamProcess = new System.Windows.Forms.DataGridView();
            this.saveFileDialog_excel = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_date.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ExamInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel_ProcessPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProcessPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ExamProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl2);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 105);
            this.panel1.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(181, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(794, 105);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.comboBox_deviceNumber);
            this.tabPage4.Controls.Add(this.label_deviceNumber);
            this.tabPage4.Controls.Add(this.textBox_examNumber);
            this.tabPage4.Controls.Add(this.label_examNumber);
            this.tabPage4.Controls.Add(this.textBox_name);
            this.tabPage4.Controls.Add(this.textBox_idNumber);
            this.tabPage4.Controls.Add(this.label_idNumber);
            this.tabPage4.Controls.Add(this.label_name);
            this.tabPage4.Controls.Add(this.btn_query);
            this.tabPage4.Controls.Add(this.comboBox_driverLicenseType);
            this.tabPage4.Controls.Add(this.label_driverLicenseType);
            this.tabPage4.Controls.Add(this.comboBox_subject);
            this.tabPage4.Controls.Add(this.comboBox_examReason);
            this.tabPage4.Controls.Add(this.label_subject);
            this.tabPage4.Controls.Add(this.label_examReason);
            this.tabPage4.Controls.Add(this.label_carSequenceNumber);
            this.tabPage4.Controls.Add(this.label_school);
            this.tabPage4.Controls.Add(this.comboBox_examiner);
            this.tabPage4.Controls.Add(this.comboBox_carSequenceNumber);
            this.tabPage4.Controls.Add(this.label_examiner);
            this.tabPage4.Controls.Add(this.comboBox_school);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage4.Size = new System.Drawing.Size(786, 79);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "条件";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // comboBox_deviceNumber
            // 
            this.comboBox_deviceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_deviceNumber.FormattingEnabled = true;
            this.comboBox_deviceNumber.Location = new System.Drawing.Point(589, 53);
            this.comboBox_deviceNumber.Name = "comboBox_deviceNumber";
            this.comboBox_deviceNumber.Size = new System.Drawing.Size(75, 20);
            this.comboBox_deviceNumber.TabIndex = 19;
            // 
            // label_deviceNumber
            // 
            this.label_deviceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_deviceNumber.AutoSize = true;
            this.label_deviceNumber.Location = new System.Drawing.Point(518, 57);
            this.label_deviceNumber.Name = "label_deviceNumber";
            this.label_deviceNumber.Size = new System.Drawing.Size(65, 12);
            this.label_deviceNumber.TabIndex = 18;
            this.label_deviceNumber.Text = "场地设备：";
            // 
            // textBox_examNumber
            // 
            this.textBox_examNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_examNumber.Location = new System.Drawing.Point(214, 29);
            this.textBox_examNumber.Name = "textBox_examNumber";
            this.textBox_examNumber.Size = new System.Drawing.Size(104, 21);
            this.textBox_examNumber.TabIndex = 11;
            // 
            // label_examNumber
            // 
            this.label_examNumber.AutoSize = true;
            this.label_examNumber.Location = new System.Drawing.Point(149, 33);
            this.label_examNumber.Name = "label_examNumber";
            this.label_examNumber.Size = new System.Drawing.Size(65, 12);
            this.label_examNumber.TabIndex = 10;
            this.label_examNumber.Text = "准考证号：";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(52, 5);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(55, 21);
            this.textBox_name.TabIndex = 1;
            // 
            // textBox_idNumber
            // 
            this.textBox_idNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_idNumber.Location = new System.Drawing.Point(189, 5);
            this.textBox_idNumber.Name = "textBox_idNumber";
            this.textBox_idNumber.Size = new System.Drawing.Size(129, 21);
            this.textBox_idNumber.TabIndex = 3;
            // 
            // label_idNumber
            // 
            this.label_idNumber.AutoSize = true;
            this.label_idNumber.Location = new System.Drawing.Point(119, 9);
            this.label_idNumber.Name = "label_idNumber";
            this.label_idNumber.Size = new System.Drawing.Size(65, 12);
            this.label_idNumber.TabIndex = 2;
            this.label_idNumber.Text = "身份证号：";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(5, 9);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(41, 12);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "姓名：";
            // 
            // btn_query
            // 
            this.btn_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_query.Location = new System.Drawing.Point(700, 47);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 21;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // comboBox_driverLicenseType
            // 
            this.comboBox_driverLicenseType.DropDownWidth = 140;
            this.comboBox_driverLicenseType.FormattingEnabled = true;
            this.comboBox_driverLicenseType.Location = new System.Drawing.Point(76, 29);
            this.comboBox_driverLicenseType.Name = "comboBox_driverLicenseType";
            this.comboBox_driverLicenseType.Size = new System.Drawing.Size(44, 20);
            this.comboBox_driverLicenseType.TabIndex = 9;
            // 
            // label_driverLicenseType
            // 
            this.label_driverLicenseType.AutoSize = true;
            this.label_driverLicenseType.Location = new System.Drawing.Point(5, 33);
            this.label_driverLicenseType.Name = "label_driverLicenseType";
            this.label_driverLicenseType.Size = new System.Drawing.Size(65, 12);
            this.label_driverLicenseType.TabIndex = 8;
            this.label_driverLicenseType.Text = "考试车型：";
            // 
            // comboBox_subject
            // 
            this.comboBox_subject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_subject.FormattingEnabled = true;
            this.comboBox_subject.Location = new System.Drawing.Point(589, 5);
            this.comboBox_subject.Name = "comboBox_subject";
            this.comboBox_subject.Size = new System.Drawing.Size(75, 20);
            this.comboBox_subject.TabIndex = 7;
            // 
            // comboBox_examReason
            // 
            this.comboBox_examReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_examReason.FormattingEnabled = true;
            this.comboBox_examReason.Location = new System.Drawing.Point(420, 29);
            this.comboBox_examReason.Name = "comboBox_examReason";
            this.comboBox_examReason.Size = new System.Drawing.Size(83, 20);
            this.comboBox_examReason.TabIndex = 13;
            // 
            // label_subject
            // 
            this.label_subject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_subject.AutoSize = true;
            this.label_subject.Location = new System.Drawing.Point(518, 9);
            this.label_subject.Name = "label_subject";
            this.label_subject.Size = new System.Drawing.Size(65, 12);
            this.label_subject.TabIndex = 6;
            this.label_subject.Text = "考试项目：";
            // 
            // label_examReason
            // 
            this.label_examReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_examReason.AutoSize = true;
            this.label_examReason.Location = new System.Drawing.Point(349, 33);
            this.label_examReason.Name = "label_examReason";
            this.label_examReason.Size = new System.Drawing.Size(65, 12);
            this.label_examReason.TabIndex = 12;
            this.label_examReason.Text = "考试原因：";
            // 
            // label_carSequenceNumber
            // 
            this.label_carSequenceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_carSequenceNumber.AutoSize = true;
            this.label_carSequenceNumber.Location = new System.Drawing.Point(349, 9);
            this.label_carSequenceNumber.Name = "label_carSequenceNumber";
            this.label_carSequenceNumber.Size = new System.Drawing.Size(65, 12);
            this.label_carSequenceNumber.TabIndex = 4;
            this.label_carSequenceNumber.Text = "考车编号：";
            // 
            // label_school
            // 
            this.label_school.AutoSize = true;
            this.label_school.Location = new System.Drawing.Point(5, 57);
            this.label_school.Name = "label_school";
            this.label_school.Size = new System.Drawing.Size(65, 12);
            this.label_school.TabIndex = 16;
            this.label_school.Text = "培训单位：";
            // 
            // comboBox_examiner
            // 
            this.comboBox_examiner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_examiner.FormattingEnabled = true;
            this.comboBox_examiner.Location = new System.Drawing.Point(589, 29);
            this.comboBox_examiner.Name = "comboBox_examiner";
            this.comboBox_examiner.Size = new System.Drawing.Size(75, 20);
            this.comboBox_examiner.TabIndex = 15;
            // 
            // comboBox_carSequenceNumber
            // 
            this.comboBox_carSequenceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_carSequenceNumber.FormattingEnabled = true;
            this.comboBox_carSequenceNumber.Location = new System.Drawing.Point(420, 5);
            this.comboBox_carSequenceNumber.Name = "comboBox_carSequenceNumber";
            this.comboBox_carSequenceNumber.Size = new System.Drawing.Size(82, 20);
            this.comboBox_carSequenceNumber.TabIndex = 5;
            // 
            // label_examiner
            // 
            this.label_examiner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_examiner.AutoSize = true;
            this.label_examiner.Location = new System.Drawing.Point(518, 33);
            this.label_examiner.Name = "label_examiner";
            this.label_examiner.Size = new System.Drawing.Size(53, 12);
            this.label_examiner.TabIndex = 14;
            this.label_examiner.Text = "考试员：";
            // 
            // comboBox_school
            // 
            this.comboBox_school.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_school.FormattingEnabled = true;
            this.comboBox_school.Location = new System.Drawing.Point(76, 53);
            this.comboBox_school.Name = "comboBox_school";
            this.comboBox_school.Size = new System.Drawing.Size(427, 20);
            this.comboBox_school.TabIndex = 17;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_date);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(181, 105);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_date
            // 
            this.tabPage_date.Controls.Add(this.dateTimePicker_end);
            this.tabPage_date.Controls.Add(this.dateTimePicker_start);
            this.tabPage_date.Controls.Add(this.label2);
            this.tabPage_date.Controls.Add(this.label1);
            this.tabPage_date.Location = new System.Drawing.Point(4, 22);
            this.tabPage_date.Name = "tabPage_date";
            this.tabPage_date.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage_date.Size = new System.Drawing.Size(173, 79);
            this.tabPage_date.TabIndex = 0;
            this.tabPage_date.Text = "日期范围";
            this.tabPage_date.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(55, 51);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(106, 21);
            this.dateTimePicker_end.TabIndex = 3;
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(55, 5);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(106, 21);
            this.dateTimePicker_start.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始：";
            // 
            // button_Export
            // 
            this.button_Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Export.Location = new System.Drawing.Point(188, 149);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(75, 23);
            this.button_Export.TabIndex = 20;
            this.button_Export.Text = "导出";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // dataGridView_ExamInfo
            // 
            this.dataGridView_ExamInfo.AllowUserToAddRows = false;
            this.dataGridView_ExamInfo.AllowUserToDeleteRows = false;
            this.dataGridView_ExamInfo.AllowUserToResizeRows = false;
            this.dataGridView_ExamInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ExamInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_ExamInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ExamInfo.EnableHeadersVisualStyles = false;
            this.dataGridView_ExamInfo.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_ExamInfo.Name = "dataGridView_ExamInfo";
            this.dataGridView_ExamInfo.ReadOnly = true;
            this.dataGridView_ExamInfo.RowHeadersVisible = false;
            this.dataGridView_ExamInfo.RowTemplate.Height = 23;
            this.dataGridView_ExamInfo.Size = new System.Drawing.Size(975, 284);
            this.dataGridView_ExamInfo.TabIndex = 0;
            this.dataGridView_ExamInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ExamInfo_CellClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 105);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView_ExamInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel_ProcessPhoto);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_ExamProcess);
            this.splitContainer1.Size = new System.Drawing.Size(975, 462);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel_ProcessPhoto
            // 
            this.panel_ProcessPhoto.Controls.Add(this.button_Export);
            this.panel_ProcessPhoto.Controls.Add(this.pictureBox_ProcessPhoto);
            this.panel_ProcessPhoto.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_ProcessPhoto.Location = new System.Drawing.Point(704, 0);
            this.panel_ProcessPhoto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_ProcessPhoto.Name = "panel_ProcessPhoto";
            this.panel_ProcessPhoto.Size = new System.Drawing.Size(271, 175);
            this.panel_ProcessPhoto.TabIndex = 1;
            // 
            // pictureBox_ProcessPhoto
            // 
            this.pictureBox_ProcessPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_ProcessPhoto.Location = new System.Drawing.Point(2, 2);
            this.pictureBox_ProcessPhoto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox_ProcessPhoto.Name = "pictureBox_ProcessPhoto";
            this.pictureBox_ProcessPhoto.Size = new System.Drawing.Size(269, 139);
            this.pictureBox_ProcessPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_ProcessPhoto.TabIndex = 9;
            this.pictureBox_ProcessPhoto.TabStop = false;
            // 
            // dataGridView_ExamProcess
            // 
            this.dataGridView_ExamProcess.AllowUserToAddRows = false;
            this.dataGridView_ExamProcess.AllowUserToDeleteRows = false;
            this.dataGridView_ExamProcess.AllowUserToResizeRows = false;
            this.dataGridView_ExamProcess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ExamProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_ExamProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ExamProcess.EnableHeadersVisualStyles = false;
            this.dataGridView_ExamProcess.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_ExamProcess.Name = "dataGridView_ExamProcess";
            this.dataGridView_ExamProcess.ReadOnly = true;
            this.dataGridView_ExamProcess.RowHeadersVisible = false;
            this.dataGridView_ExamProcess.RowTemplate.Height = 23;
            this.dataGridView_ExamProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ExamProcess.Size = new System.Drawing.Size(975, 175);
            this.dataGridView_ExamProcess.TabIndex = 0;
            this.dataGridView_ExamProcess.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ExamProcess_CellClick);
            // 
            // saveFileDialog_excel
            // 
            this.saveFileDialog_excel.DefaultExt = "xlsx";
            this.saveFileDialog_excel.Filter = "Excel File|*.xlsx|All files|*.*";
            // 
            // Form_SummaryQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 567);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "Form_SummaryQuery";
            this.Text = "综合查询";
            this.Load += new System.EventHandler(this.Form_SummaryQuery_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_date.ResumeLayout(false);
            this.tabPage_date.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ExamInfo)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel_ProcessPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProcessPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ExamProcess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_ExamInfo;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_driverLicenseType;
        private System.Windows.Forms.Label label_driverLicenseType;
        private System.Windows.Forms.ComboBox comboBox_subject;
        private System.Windows.Forms.ComboBox comboBox_examReason;
        private System.Windows.Forms.Label label_subject;
        private System.Windows.Forms.Label label_examReason;
        private System.Windows.Forms.Label label_carSequenceNumber;
        private System.Windows.Forms.Label label_school;
        private System.Windows.Forms.ComboBox comboBox_examiner;
        private System.Windows.Forms.ComboBox comboBox_carSequenceNumber;
        private System.Windows.Forms.Label label_examiner;
        private System.Windows.Forms.ComboBox comboBox_school;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Label label_idNumber;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox textBox_examNumber;
        private System.Windows.Forms.Label label_examNumber;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_idNumber;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView_ExamProcess;
        private System.Windows.Forms.Panel panel_ProcessPhoto;
        private System.Windows.Forms.PictureBox pictureBox_ProcessPhoto;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox comboBox_deviceNumber;
        private System.Windows.Forms.Label label_deviceNumber;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_date;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_excel;
    }
}