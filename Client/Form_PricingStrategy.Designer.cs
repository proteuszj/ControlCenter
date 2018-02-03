namespace Client
{
    partial class Form_PricingStrategy
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
            this.dataGridView_pricingStrategy = new System.Windows.Forms.DataGridView();
            this.panel_pricingStrategy = new System.Windows.Forms.Panel();
            this.button_showAll = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_filter = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.label_expireDate = new System.Windows.Forms.Label();
            this.label_effectiveDate = new System.Windows.Forms.Label();
            this.dateTimePicker_expireDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_effectiveDate = new System.Windows.Forms.DateTimePicker();
            this.textBox_referenceAmount2 = new System.Windows.Forms.TextBox();
            this.label_referenceAmount2 = new System.Windows.Forms.Label();
            this.comboBox_referenceMethod2 = new System.Windows.Forms.ComboBox();
            this.label_referenceMethod2 = new System.Windows.Forms.Label();
            this.comboBox_referenceRelation = new System.Windows.Forms.ComboBox();
            this.label_referenceRelation = new System.Windows.Forms.Label();
            this.textBox_referenceAmount1 = new System.Windows.Forms.TextBox();
            this.label_referenceAmount1 = new System.Windows.Forms.Label();
            this.comboBox_referenceMethod1 = new System.Windows.Forms.ComboBox();
            this.label_referenceMethod1 = new System.Windows.Forms.Label();
            this.comboBox_schoolName = new System.Windows.Forms.ComboBox();
            this.textBox_studentIDNumber = new System.Windows.Forms.TextBox();
            this.label_studentIDNumber = new System.Windows.Forms.Label();
            this.label_schoolName = new System.Windows.Forms.Label();
            this.dateTimePicker_endTime = new System.Windows.Forms.DateTimePicker();
            this.label_endTime = new System.Windows.Forms.Label();
            this.dateTimePicker_startTime = new System.Windows.Forms.DateTimePicker();
            this.label_startTime = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.label_startDate = new System.Windows.Forms.Label();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.textBox_amount = new System.Windows.Forms.TextBox();
            this.label_amount = new System.Windows.Forms.Label();
            this.comboBox_action = new System.Windows.Forms.ComboBox();
            this.label_action = new System.Windows.Forms.Label();
            this.numericUpDown_priority = new System.Windows.Forms.NumericUpDown();
            this.label_priority = new System.Windows.Forms.Label();
            this.panel_test = new System.Windows.Forms.Panel();
            this.textBox_studentIDNumberForTest = new System.Windows.Forms.TextBox();
            this.label_studentIDNumberForTest = new System.Windows.Forms.Label();
            this.comboBox_schoolNameForTest = new System.Windows.Forms.ComboBox();
            this.label_schoolNameForTest = new System.Windows.Forms.Label();
            this.label_bookingTime = new System.Windows.Forms.Label();
            this.dateTimePicker_bookingTime = new System.Windows.Forms.DateTimePicker();
            this.dataGridView_testResult = new System.Windows.Forms.DataGridView();
            this.Column_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_test = new System.Windows.Forms.Button();
            this.textBox_end = new System.Windows.Forms.TextBox();
            this.label_end = new System.Windows.Forms.Label();
            this.textBox_start = new System.Windows.Forms.TextBox();
            this.label_start = new System.Windows.Forms.Label();
            this.label_bookingDateLimit = new System.Windows.Forms.Label();
            this.numericUpDown_bookingDateLimt = new System.Windows.Forms.NumericUpDown();
            this.panel_parameter = new System.Windows.Forms.Panel();
            this.label_bookingTimeSetting = new System.Windows.Forms.Label();
            this.button_setValue = new System.Windows.Forms.Button();
            this.checkedListBox_bookingTimeSetting = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_pricingStrategy)).BeginInit();
            this.panel_pricingStrategy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_priority)).BeginInit();
            this.panel_test.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_testResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_bookingDateLimt)).BeginInit();
            this.panel_parameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_pricingStrategy
            // 
            this.dataGridView_pricingStrategy.AllowUserToAddRows = false;
            this.dataGridView_pricingStrategy.AllowUserToDeleteRows = false;
            this.dataGridView_pricingStrategy.AllowUserToResizeRows = false;
            this.dataGridView_pricingStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_pricingStrategy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_pricingStrategy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_pricingStrategy.EnableHeadersVisualStyles = false;
            this.dataGridView_pricingStrategy.Location = new System.Drawing.Point(1, 137);
            this.dataGridView_pricingStrategy.Name = "dataGridView_pricingStrategy";
            this.dataGridView_pricingStrategy.ReadOnly = true;
            this.dataGridView_pricingStrategy.RowHeadersVisible = false;
            this.dataGridView_pricingStrategy.RowTemplate.Height = 23;
            this.dataGridView_pricingStrategy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_pricingStrategy.Size = new System.Drawing.Size(803, 354);
            this.dataGridView_pricingStrategy.TabIndex = 2;
            this.dataGridView_pricingStrategy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_pricingStrategy_CellClick);
            // 
            // panel_pricingStrategy
            // 
            this.panel_pricingStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_pricingStrategy.Controls.Add(this.button_showAll);
            this.panel_pricingStrategy.Controls.Add(this.button_remove);
            this.panel_pricingStrategy.Controls.Add(this.button_filter);
            this.panel_pricingStrategy.Controls.Add(this.button_add);
            this.panel_pricingStrategy.Controls.Add(this.label_expireDate);
            this.panel_pricingStrategy.Controls.Add(this.label_effectiveDate);
            this.panel_pricingStrategy.Controls.Add(this.dateTimePicker_expireDate);
            this.panel_pricingStrategy.Controls.Add(this.dateTimePicker_effectiveDate);
            this.panel_pricingStrategy.Controls.Add(this.textBox_referenceAmount2);
            this.panel_pricingStrategy.Controls.Add(this.label_referenceAmount2);
            this.panel_pricingStrategy.Controls.Add(this.comboBox_referenceMethod2);
            this.panel_pricingStrategy.Controls.Add(this.label_referenceMethod2);
            this.panel_pricingStrategy.Controls.Add(this.comboBox_referenceRelation);
            this.panel_pricingStrategy.Controls.Add(this.label_referenceRelation);
            this.panel_pricingStrategy.Controls.Add(this.textBox_referenceAmount1);
            this.panel_pricingStrategy.Controls.Add(this.label_referenceAmount1);
            this.panel_pricingStrategy.Controls.Add(this.comboBox_referenceMethod1);
            this.panel_pricingStrategy.Controls.Add(this.label_referenceMethod1);
            this.panel_pricingStrategy.Controls.Add(this.comboBox_schoolName);
            this.panel_pricingStrategy.Controls.Add(this.textBox_studentIDNumber);
            this.panel_pricingStrategy.Controls.Add(this.label_studentIDNumber);
            this.panel_pricingStrategy.Controls.Add(this.label_schoolName);
            this.panel_pricingStrategy.Controls.Add(this.dateTimePicker_endTime);
            this.panel_pricingStrategy.Controls.Add(this.label_endTime);
            this.panel_pricingStrategy.Controls.Add(this.dateTimePicker_startTime);
            this.panel_pricingStrategy.Controls.Add(this.label_startTime);
            this.panel_pricingStrategy.Controls.Add(this.label_endDate);
            this.panel_pricingStrategy.Controls.Add(this.label_startDate);
            this.panel_pricingStrategy.Controls.Add(this.dateTimePicker_endDate);
            this.panel_pricingStrategy.Controls.Add(this.dateTimePicker_startDate);
            this.panel_pricingStrategy.Controls.Add(this.textBox_amount);
            this.panel_pricingStrategy.Controls.Add(this.label_amount);
            this.panel_pricingStrategy.Controls.Add(this.comboBox_action);
            this.panel_pricingStrategy.Controls.Add(this.label_action);
            this.panel_pricingStrategy.Controls.Add(this.numericUpDown_priority);
            this.panel_pricingStrategy.Controls.Add(this.label_priority);
            this.panel_pricingStrategy.Location = new System.Drawing.Point(1, 35);
            this.panel_pricingStrategy.Name = "panel_pricingStrategy";
            this.panel_pricingStrategy.Size = new System.Drawing.Size(977, 96);
            this.panel_pricingStrategy.TabIndex = 1;
            // 
            // button_showAll
            // 
            this.button_showAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_showAll.Location = new System.Drawing.Point(661, 60);
            this.button_showAll.Name = "button_showAll";
            this.button_showAll.Size = new System.Drawing.Size(69, 23);
            this.button_showAll.TabIndex = 32;
            this.button_showAll.Text = "显示全部";
            this.button_showAll.UseVisualStyleBackColor = true;
            this.button_showAll.Click += new System.EventHandler(this.button_showAll_Click);
            // 
            // button_remove
            // 
            this.button_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_remove.Location = new System.Drawing.Point(890, 60);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(75, 23);
            this.button_remove.TabIndex = 35;
            this.button_remove.Text = "删除";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_filter
            // 
            this.button_filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_filter.Location = new System.Drawing.Point(734, 60);
            this.button_filter.Name = "button_filter";
            this.button_filter.Size = new System.Drawing.Size(69, 23);
            this.button_filter.TabIndex = 33;
            this.button_filter.Text = "检索";
            this.button_filter.UseVisualStyleBackColor = true;
            this.button_filter.Click += new System.EventHandler(this.button_filter_Click);
            // 
            // button_add
            // 
            this.button_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add.Location = new System.Drawing.Point(809, 60);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 34;
            this.button_add.Text = "增加";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // label_expireDate
            // 
            this.label_expireDate.AutoSize = true;
            this.label_expireDate.Location = new System.Drawing.Point(439, 48);
            this.label_expireDate.Name = "label_expireDate";
            this.label_expireDate.Size = new System.Drawing.Size(65, 12);
            this.label_expireDate.TabIndex = 30;
            this.label_expireDate.Text = "失效日期：";
            // 
            // label_effectiveDate
            // 
            this.label_effectiveDate.AutoSize = true;
            this.label_effectiveDate.Location = new System.Drawing.Point(336, 48);
            this.label_effectiveDate.Name = "label_effectiveDate";
            this.label_effectiveDate.Size = new System.Drawing.Size(65, 12);
            this.label_effectiveDate.TabIndex = 28;
            this.label_effectiveDate.Text = "生效日期：";
            // 
            // dateTimePicker_expireDate
            // 
            this.dateTimePicker_expireDate.Checked = false;
            this.dateTimePicker_expireDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_expireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_expireDate.Location = new System.Drawing.Point(441, 62);
            this.dateTimePicker_expireDate.Name = "dateTimePicker_expireDate";
            this.dateTimePicker_expireDate.ShowCheckBox = true;
            this.dateTimePicker_expireDate.Size = new System.Drawing.Size(97, 21);
            this.dateTimePicker_expireDate.TabIndex = 31;
            // 
            // dateTimePicker_effectiveDate
            // 
            this.dateTimePicker_effectiveDate.Checked = false;
            this.dateTimePicker_effectiveDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_effectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_effectiveDate.Location = new System.Drawing.Point(338, 62);
            this.dateTimePicker_effectiveDate.Name = "dateTimePicker_effectiveDate";
            this.dateTimePicker_effectiveDate.ShowCheckBox = true;
            this.dateTimePicker_effectiveDate.Size = new System.Drawing.Size(97, 21);
            this.dateTimePicker_effectiveDate.TabIndex = 29;
            // 
            // textBox_referenceAmount2
            // 
            this.textBox_referenceAmount2.Enabled = false;
            this.textBox_referenceAmount2.Location = new System.Drawing.Point(272, 62);
            this.textBox_referenceAmount2.Name = "textBox_referenceAmount2";
            this.textBox_referenceAmount2.Size = new System.Drawing.Size(52, 21);
            this.textBox_referenceAmount2.TabIndex = 27;
            this.textBox_referenceAmount2.TextChanged += new System.EventHandler(this.comboBox_reference_TextChanged);
            // 
            // label_referenceAmount2
            // 
            this.label_referenceAmount2.AutoSize = true;
            this.label_referenceAmount2.Location = new System.Drawing.Point(270, 48);
            this.label_referenceAmount2.Name = "label_referenceAmount2";
            this.label_referenceAmount2.Size = new System.Drawing.Size(47, 12);
            this.label_referenceAmount2.TabIndex = 26;
            this.label_referenceAmount2.Text = "金额2：";
            // 
            // comboBox_referenceMethod2
            // 
            this.comboBox_referenceMethod2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_referenceMethod2.Enabled = false;
            this.comboBox_referenceMethod2.FormattingEnabled = true;
            this.comboBox_referenceMethod2.Location = new System.Drawing.Point(199, 63);
            this.comboBox_referenceMethod2.Name = "comboBox_referenceMethod2";
            this.comboBox_referenceMethod2.Size = new System.Drawing.Size(67, 20);
            this.comboBox_referenceMethod2.TabIndex = 25;
            this.comboBox_referenceMethod2.TextChanged += new System.EventHandler(this.comboBox_reference_TextChanged);
            // 
            // label_referenceMethod2
            // 
            this.label_referenceMethod2.AutoSize = true;
            this.label_referenceMethod2.Location = new System.Drawing.Point(199, 48);
            this.label_referenceMethod2.Name = "label_referenceMethod2";
            this.label_referenceMethod2.Size = new System.Drawing.Size(71, 12);
            this.label_referenceMethod2.TabIndex = 24;
            this.label_referenceMethod2.Text = "参考方法2：";
            // 
            // comboBox_referenceRelation
            // 
            this.comboBox_referenceRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_referenceRelation.Enabled = false;
            this.comboBox_referenceRelation.FormattingEnabled = true;
            this.comboBox_referenceRelation.Items.AddRange(new object[] {
            "并且",
            "或者"});
            this.comboBox_referenceRelation.Location = new System.Drawing.Point(142, 63);
            this.comboBox_referenceRelation.Name = "comboBox_referenceRelation";
            this.comboBox_referenceRelation.Size = new System.Drawing.Size(51, 20);
            this.comboBox_referenceRelation.TabIndex = 23;
            this.comboBox_referenceRelation.TextChanged += new System.EventHandler(this.comboBox_reference_TextChanged);
            // 
            // label_referenceRelation
            // 
            this.label_referenceRelation.AutoSize = true;
            this.label_referenceRelation.Location = new System.Drawing.Point(142, 48);
            this.label_referenceRelation.Name = "label_referenceRelation";
            this.label_referenceRelation.Size = new System.Drawing.Size(41, 12);
            this.label_referenceRelation.TabIndex = 22;
            this.label_referenceRelation.Text = "关系：";
            // 
            // textBox_referenceAmount1
            // 
            this.textBox_referenceAmount1.Location = new System.Drawing.Point(84, 62);
            this.textBox_referenceAmount1.Name = "textBox_referenceAmount1";
            this.textBox_referenceAmount1.Size = new System.Drawing.Size(52, 21);
            this.textBox_referenceAmount1.TabIndex = 21;
            this.textBox_referenceAmount1.TextChanged += new System.EventHandler(this.comboBox_reference_TextChanged);
            // 
            // label_referenceAmount1
            // 
            this.label_referenceAmount1.AutoSize = true;
            this.label_referenceAmount1.Location = new System.Drawing.Point(87, 48);
            this.label_referenceAmount1.Name = "label_referenceAmount1";
            this.label_referenceAmount1.Size = new System.Drawing.Size(47, 12);
            this.label_referenceAmount1.TabIndex = 20;
            this.label_referenceAmount1.Text = "金额1：";
            // 
            // comboBox_referenceMethod1
            // 
            this.comboBox_referenceMethod1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_referenceMethod1.FormattingEnabled = true;
            this.comboBox_referenceMethod1.Location = new System.Drawing.Point(11, 63);
            this.comboBox_referenceMethod1.Name = "comboBox_referenceMethod1";
            this.comboBox_referenceMethod1.Size = new System.Drawing.Size(67, 20);
            this.comboBox_referenceMethod1.TabIndex = 19;
            this.comboBox_referenceMethod1.TextChanged += new System.EventHandler(this.comboBox_reference_TextChanged);
            // 
            // label_referenceMethod1
            // 
            this.label_referenceMethod1.AutoSize = true;
            this.label_referenceMethod1.Location = new System.Drawing.Point(10, 48);
            this.label_referenceMethod1.Name = "label_referenceMethod1";
            this.label_referenceMethod1.Size = new System.Drawing.Size(71, 12);
            this.label_referenceMethod1.TabIndex = 18;
            this.label_referenceMethod1.Text = "参考方法1：";
            // 
            // comboBox_schoolName
            // 
            this.comboBox_schoolName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_schoolName.FormattingEnabled = true;
            this.comboBox_schoolName.Location = new System.Drawing.Point(603, 25);
            this.comboBox_schoolName.Name = "comboBox_schoolName";
            this.comboBox_schoolName.Size = new System.Drawing.Size(247, 20);
            this.comboBox_schoolName.TabIndex = 15;
            // 
            // textBox_studentIDNumber
            // 
            this.textBox_studentIDNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_studentIDNumber.Location = new System.Drawing.Point(856, 23);
            this.textBox_studentIDNumber.MaxLength = 18;
            this.textBox_studentIDNumber.Name = "textBox_studentIDNumber";
            this.textBox_studentIDNumber.Size = new System.Drawing.Size(109, 21);
            this.textBox_studentIDNumber.TabIndex = 17;
            // 
            // label_studentIDNumber
            // 
            this.label_studentIDNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_studentIDNumber.AutoSize = true;
            this.label_studentIDNumber.Location = new System.Drawing.Point(854, 8);
            this.label_studentIDNumber.Name = "label_studentIDNumber";
            this.label_studentIDNumber.Size = new System.Drawing.Size(89, 12);
            this.label_studentIDNumber.TabIndex = 16;
            this.label_studentIDNumber.Text = "学员身份证号：";
            // 
            // label_schoolName
            // 
            this.label_schoolName.AutoSize = true;
            this.label_schoolName.Location = new System.Drawing.Point(601, 9);
            this.label_schoolName.Name = "label_schoolName";
            this.label_schoolName.Size = new System.Drawing.Size(65, 12);
            this.label_schoolName.TabIndex = 14;
            this.label_schoolName.Text = "驾校名称：";
            // 
            // dateTimePicker_endTime
            // 
            this.dateTimePicker_endTime.Checked = false;
            this.dateTimePicker_endTime.CustomFormat = "HH:mm:ss";
            this.dateTimePicker_endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_endTime.Location = new System.Drawing.Point(510, 24);
            this.dateTimePicker_endTime.Name = "dateTimePicker_endTime";
            this.dateTimePicker_endTime.ShowCheckBox = true;
            this.dateTimePicker_endTime.ShowUpDown = true;
            this.dateTimePicker_endTime.Size = new System.Drawing.Size(87, 21);
            this.dateTimePicker_endTime.TabIndex = 13;
            // 
            // label_endTime
            // 
            this.label_endTime.AutoSize = true;
            this.label_endTime.Location = new System.Drawing.Point(508, 9);
            this.label_endTime.Name = "label_endTime";
            this.label_endTime.Size = new System.Drawing.Size(65, 12);
            this.label_endTime.TabIndex = 12;
            this.label_endTime.Text = "结束时间：";
            // 
            // dateTimePicker_startTime
            // 
            this.dateTimePicker_startTime.Checked = false;
            this.dateTimePicker_startTime.CustomFormat = "HH:mm:ss";
            this.dateTimePicker_startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_startTime.Location = new System.Drawing.Point(417, 24);
            this.dateTimePicker_startTime.Name = "dateTimePicker_startTime";
            this.dateTimePicker_startTime.ShowCheckBox = true;
            this.dateTimePicker_startTime.ShowUpDown = true;
            this.dateTimePicker_startTime.Size = new System.Drawing.Size(87, 21);
            this.dateTimePicker_startTime.TabIndex = 11;
            // 
            // label_startTime
            // 
            this.label_startTime.AutoSize = true;
            this.label_startTime.Location = new System.Drawing.Point(415, 9);
            this.label_startTime.Name = "label_startTime";
            this.label_startTime.Size = new System.Drawing.Size(65, 12);
            this.label_startTime.TabIndex = 10;
            this.label_startTime.Text = "开始时间：";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Location = new System.Drawing.Point(312, 9);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(65, 12);
            this.label_endDate.TabIndex = 8;
            this.label_endDate.Text = "结束日期：";
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Location = new System.Drawing.Point(209, 9);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(65, 12);
            this.label_startDate.TabIndex = 6;
            this.label_startDate.Text = "开始日期：";
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Checked = false;
            this.dateTimePicker_endDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(314, 24);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.ShowCheckBox = true;
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(97, 21);
            this.dateTimePicker_endDate.TabIndex = 9;
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Checked = false;
            this.dateTimePicker_startDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(211, 24);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.ShowCheckBox = true;
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(97, 21);
            this.dateTimePicker_startDate.TabIndex = 7;
            // 
            // textBox_amount
            // 
            this.textBox_amount.Location = new System.Drawing.Point(143, 24);
            this.textBox_amount.Name = "textBox_amount";
            this.textBox_amount.Size = new System.Drawing.Size(61, 21);
            this.textBox_amount.TabIndex = 5;
            // 
            // label_amount
            // 
            this.label_amount.AutoSize = true;
            this.label_amount.Location = new System.Drawing.Point(142, 9);
            this.label_amount.Name = "label_amount";
            this.label_amount.Size = new System.Drawing.Size(41, 12);
            this.label_amount.TabIndex = 4;
            this.label_amount.Text = "金额：";
            // 
            // comboBox_action
            // 
            this.comboBox_action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_action.FormattingEnabled = true;
            this.comboBox_action.Location = new System.Drawing.Point(70, 25);
            this.comboBox_action.Name = "comboBox_action";
            this.comboBox_action.Size = new System.Drawing.Size(67, 20);
            this.comboBox_action.TabIndex = 3;
            // 
            // label_action
            // 
            this.label_action.AutoSize = true;
            this.label_action.Location = new System.Drawing.Point(71, 9);
            this.label_action.Name = "label_action";
            this.label_action.Size = new System.Drawing.Size(41, 12);
            this.label_action.TabIndex = 2;
            this.label_action.Text = "行为：";
            // 
            // numericUpDown_priority
            // 
            this.numericUpDown_priority.Location = new System.Drawing.Point(11, 24);
            this.numericUpDown_priority.Name = "numericUpDown_priority";
            this.numericUpDown_priority.Size = new System.Drawing.Size(53, 21);
            this.numericUpDown_priority.TabIndex = 1;
            // 
            // label_priority
            // 
            this.label_priority.AutoSize = true;
            this.label_priority.Location = new System.Drawing.Point(12, 9);
            this.label_priority.Name = "label_priority";
            this.label_priority.Size = new System.Drawing.Size(53, 12);
            this.label_priority.TabIndex = 0;
            this.label_priority.Text = "优先级：";
            // 
            // panel_test
            // 
            this.panel_test.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_test.Controls.Add(this.textBox_studentIDNumberForTest);
            this.panel_test.Controls.Add(this.label_studentIDNumberForTest);
            this.panel_test.Controls.Add(this.comboBox_schoolNameForTest);
            this.panel_test.Controls.Add(this.label_schoolNameForTest);
            this.panel_test.Controls.Add(this.label_bookingTime);
            this.panel_test.Controls.Add(this.dateTimePicker_bookingTime);
            this.panel_test.Controls.Add(this.dataGridView_testResult);
            this.panel_test.Controls.Add(this.button_test);
            this.panel_test.Controls.Add(this.textBox_end);
            this.panel_test.Controls.Add(this.label_end);
            this.panel_test.Controls.Add(this.textBox_start);
            this.panel_test.Controls.Add(this.label_start);
            this.panel_test.Location = new System.Drawing.Point(810, 137);
            this.panel_test.Name = "panel_test";
            this.panel_test.Size = new System.Drawing.Size(169, 354);
            this.panel_test.TabIndex = 3;
            // 
            // textBox_studentIDNumberForTest
            // 
            this.textBox_studentIDNumberForTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_studentIDNumberForTest.Location = new System.Drawing.Point(3, 169);
            this.textBox_studentIDNumberForTest.MaxLength = 18;
            this.textBox_studentIDNumberForTest.Name = "textBox_studentIDNumberForTest";
            this.textBox_studentIDNumberForTest.Size = new System.Drawing.Size(165, 21);
            this.textBox_studentIDNumberForTest.TabIndex = 9;
            // 
            // label_studentIDNumberForTest
            // 
            this.label_studentIDNumberForTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_studentIDNumberForTest.AutoSize = true;
            this.label_studentIDNumberForTest.Location = new System.Drawing.Point(14, 155);
            this.label_studentIDNumberForTest.Name = "label_studentIDNumberForTest";
            this.label_studentIDNumberForTest.Size = new System.Drawing.Size(89, 12);
            this.label_studentIDNumberForTest.TabIndex = 8;
            this.label_studentIDNumberForTest.Text = "学员身份证号：";
            // 
            // comboBox_schoolNameForTest
            // 
            this.comboBox_schoolNameForTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_schoolNameForTest.FormattingEnabled = true;
            this.comboBox_schoolNameForTest.Location = new System.Drawing.Point(3, 127);
            this.comboBox_schoolNameForTest.Name = "comboBox_schoolNameForTest";
            this.comboBox_schoolNameForTest.Size = new System.Drawing.Size(165, 20);
            this.comboBox_schoolNameForTest.TabIndex = 7;
            // 
            // label_schoolNameForTest
            // 
            this.label_schoolNameForTest.AutoSize = true;
            this.label_schoolNameForTest.Location = new System.Drawing.Point(4, 113);
            this.label_schoolNameForTest.Name = "label_schoolNameForTest";
            this.label_schoolNameForTest.Size = new System.Drawing.Size(65, 12);
            this.label_schoolNameForTest.TabIndex = 6;
            this.label_schoolNameForTest.Text = "驾校名称：";
            // 
            // label_bookingTime
            // 
            this.label_bookingTime.AutoSize = true;
            this.label_bookingTime.Location = new System.Drawing.Point(4, 61);
            this.label_bookingTime.Name = "label_bookingTime";
            this.label_bookingTime.Size = new System.Drawing.Size(65, 12);
            this.label_bookingTime.TabIndex = 4;
            this.label_bookingTime.Text = "预约时间：";
            // 
            // dateTimePicker_bookingTime
            // 
            this.dateTimePicker_bookingTime.Checked = false;
            this.dateTimePicker_bookingTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_bookingTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_bookingTime.Location = new System.Drawing.Point(3, 84);
            this.dateTimePicker_bookingTime.Name = "dateTimePicker_bookingTime";
            this.dateTimePicker_bookingTime.ShowCheckBox = true;
            this.dateTimePicker_bookingTime.Size = new System.Drawing.Size(165, 21);
            this.dateTimePicker_bookingTime.TabIndex = 5;
            // 
            // dataGridView_testResult
            // 
            this.dataGridView_testResult.AllowUserToAddRows = false;
            this.dataGridView_testResult.AllowUserToDeleteRows = false;
            this.dataGridView_testResult.AllowUserToResizeRows = false;
            this.dataGridView_testResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_testResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_testResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_testResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Time,
            this.Column_Amount});
            this.dataGridView_testResult.EnableHeadersVisualStyles = false;
            this.dataGridView_testResult.Location = new System.Drawing.Point(0, 221);
            this.dataGridView_testResult.Name = "dataGridView_testResult";
            this.dataGridView_testResult.ReadOnly = true;
            this.dataGridView_testResult.RowHeadersVisible = false;
            this.dataGridView_testResult.RowTemplate.Height = 23;
            this.dataGridView_testResult.Size = new System.Drawing.Size(169, 133);
            this.dataGridView_testResult.TabIndex = 11;
            // 
            // Column_Time
            // 
            this.Column_Time.HeaderText = "次数";
            this.Column_Time.Name = "Column_Time";
            this.Column_Time.ReadOnly = true;
            this.Column_Time.Width = 56;
            // 
            // Column_Amount
            // 
            this.Column_Amount.HeaderText = "金额";
            this.Column_Amount.Name = "Column_Amount";
            this.Column_Amount.ReadOnly = true;
            this.Column_Amount.Width = 56;
            // 
            // button_test
            // 
            this.button_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_test.Location = new System.Drawing.Point(85, 193);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 23);
            this.button_test.TabIndex = 10;
            this.button_test.Text = "验证";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // textBox_end
            // 
            this.textBox_end.Location = new System.Drawing.Point(75, 30);
            this.textBox_end.Name = "textBox_end";
            this.textBox_end.Size = new System.Drawing.Size(53, 21);
            this.textBox_end.TabIndex = 3;
            this.textBox_end.Text = "10";
            // 
            // label_end
            // 
            this.label_end.AutoSize = true;
            this.label_end.Location = new System.Drawing.Point(4, 33);
            this.label_end.Name = "label_end";
            this.label_end.Size = new System.Drawing.Size(65, 12);
            this.label_end.TabIndex = 2;
            this.label_end.Text = "结束次数：";
            // 
            // textBox_start
            // 
            this.textBox_start.Location = new System.Drawing.Point(75, 3);
            this.textBox_start.Name = "textBox_start";
            this.textBox_start.Size = new System.Drawing.Size(53, 21);
            this.textBox_start.TabIndex = 1;
            this.textBox_start.Text = "1";
            // 
            // label_start
            // 
            this.label_start.AutoSize = true;
            this.label_start.Location = new System.Drawing.Point(3, 6);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(65, 12);
            this.label_start.TabIndex = 0;
            this.label_start.Text = "起始次数：";
            // 
            // label_bookingDateLimit
            // 
            this.label_bookingDateLimit.AutoSize = true;
            this.label_bookingDateLimit.Location = new System.Drawing.Point(11, 9);
            this.label_bookingDateLimit.Name = "label_bookingDateLimit";
            this.label_bookingDateLimit.Size = new System.Drawing.Size(89, 12);
            this.label_bookingDateLimit.TabIndex = 0;
            this.label_bookingDateLimit.Text = "预约时间限制：";
            // 
            // numericUpDown_bookingDateLimt
            // 
            this.numericUpDown_bookingDateLimt.Location = new System.Drawing.Point(106, 3);
            this.numericUpDown_bookingDateLimt.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_bookingDateLimt.Name = "numericUpDown_bookingDateLimt";
            this.numericUpDown_bookingDateLimt.Size = new System.Drawing.Size(53, 21);
            this.numericUpDown_bookingDateLimt.TabIndex = 1;
            // 
            // panel_parameter
            // 
            this.panel_parameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_parameter.Controls.Add(this.label_bookingTimeSetting);
            this.panel_parameter.Controls.Add(this.button_setValue);
            this.panel_parameter.Controls.Add(this.numericUpDown_bookingDateLimt);
            this.panel_parameter.Controls.Add(this.label_bookingDateLimit);
            this.panel_parameter.Location = new System.Drawing.Point(1, 0);
            this.panel_parameter.Name = "panel_parameter";
            this.panel_parameter.Size = new System.Drawing.Size(977, 29);
            this.panel_parameter.TabIndex = 0;
            // 
            // label_bookingTimeSetting
            // 
            this.label_bookingTimeSetting.AutoSize = true;
            this.label_bookingTimeSetting.Location = new System.Drawing.Point(165, 9);
            this.label_bookingTimeSetting.Name = "label_bookingTimeSetting";
            this.label_bookingTimeSetting.Size = new System.Drawing.Size(89, 12);
            this.label_bookingTimeSetting.TabIndex = 2;
            this.label_bookingTimeSetting.Text = "预约时间设置：";
            // 
            // button_setValue
            // 
            this.button_setValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_setValue.Location = new System.Drawing.Point(890, 4);
            this.button_setValue.Name = "button_setValue";
            this.button_setValue.Size = new System.Drawing.Size(75, 23);
            this.button_setValue.TabIndex = 3;
            this.button_setValue.Text = "写入";
            this.button_setValue.UseVisualStyleBackColor = true;
            this.button_setValue.Click += new System.EventHandler(this.button_setValue_Click);
            // 
            // checkedListBox_bookingTimeSetting
            // 
            this.checkedListBox_bookingTimeSetting.CheckOnClick = true;
            this.checkedListBox_bookingTimeSetting.Items.AddRange(new object[] {
            "00:00:00",
            "01:00:00",
            "02:00:00",
            "03:00:00",
            "04:00:00",
            "05:00:00",
            "06:00:00",
            "07:00:00",
            "08:00:00",
            "09:00:00",
            "10:00:00",
            "11:00:00",
            "12:00:00",
            "13:00:00",
            "14:00:00",
            "15:00:00",
            "16:00:00",
            "17:00:00",
            "18:00:00",
            "19:00:00",
            "20:00:00",
            "21:00:00",
            "22:00:00",
            "23:00:00"});
            this.checkedListBox_bookingTimeSetting.Location = new System.Drawing.Point(258, 4);
            this.checkedListBox_bookingTimeSetting.Name = "checkedListBox_bookingTimeSetting";
            this.checkedListBox_bookingTimeSetting.Size = new System.Drawing.Size(120, 20);
            this.checkedListBox_bookingTimeSetting.TabIndex = 4;
            this.checkedListBox_bookingTimeSetting.ThreeDCheckBoxes = true;
            this.checkedListBox_bookingTimeSetting.MouseEnter += new System.EventHandler(this.checkedListBox_bookingTimeSetting_Enter);
            this.checkedListBox_bookingTimeSetting.MouseLeave += new System.EventHandler(this.checkedListBox_bookingTimeSetting_Leave);
            // 
            // Form_PricingStrategy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 490);
            this.ControlBox = false;
            this.Controls.Add(this.checkedListBox_bookingTimeSetting);
            this.Controls.Add(this.panel_parameter);
            this.Controls.Add(this.panel_test);
            this.Controls.Add(this.panel_pricingStrategy);
            this.Controls.Add(this.dataGridView_pricingStrategy);
            this.Name = "Form_PricingStrategy";
            this.Text = "支付定价";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_pricingStrategy)).EndInit();
            this.panel_pricingStrategy.ResumeLayout(false);
            this.panel_pricingStrategy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_priority)).EndInit();
            this.panel_test.ResumeLayout(false);
            this.panel_test.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_testResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_bookingDateLimt)).EndInit();
            this.panel_parameter.ResumeLayout(false);
            this.panel_parameter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_pricingStrategy;
        private System.Windows.Forms.Panel panel_pricingStrategy;
        private System.Windows.Forms.ComboBox comboBox_action;
        private System.Windows.Forms.Label label_action;
        private System.Windows.Forms.NumericUpDown numericUpDown_priority;
        private System.Windows.Forms.Label label_priority;
        private System.Windows.Forms.ComboBox comboBox_referenceMethod1;
        private System.Windows.Forms.Label label_referenceMethod1;
        private System.Windows.Forms.ComboBox comboBox_schoolName;
        private System.Windows.Forms.TextBox textBox_studentIDNumber;
        private System.Windows.Forms.Label label_studentIDNumber;
        private System.Windows.Forms.Label label_schoolName;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endTime;
        private System.Windows.Forms.Label label_endTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startTime;
        private System.Windows.Forms.Label label_startTime;
        private System.Windows.Forms.Label label_endDate;
        private System.Windows.Forms.Label label_startDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.TextBox textBox_amount;
        private System.Windows.Forms.Label label_amount;
        private System.Windows.Forms.ComboBox comboBox_referenceRelation;
        private System.Windows.Forms.Label label_referenceRelation;
        private System.Windows.Forms.TextBox textBox_referenceAmount1;
        private System.Windows.Forms.Label label_referenceAmount1;
        private System.Windows.Forms.TextBox textBox_referenceAmount2;
        private System.Windows.Forms.Label label_referenceAmount2;
        private System.Windows.Forms.ComboBox comboBox_referenceMethod2;
        private System.Windows.Forms.Label label_referenceMethod2;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Label label_expireDate;
        private System.Windows.Forms.Label label_effectiveDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_expireDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_effectiveDate;
        private System.Windows.Forms.Button button_filter;
        private System.Windows.Forms.Panel panel_test;
        private System.Windows.Forms.DataGridView dataGridView_testResult;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.TextBox textBox_end;
        private System.Windows.Forms.Label label_end;
        private System.Windows.Forms.TextBox textBox_start;
        private System.Windows.Forms.Label label_start;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Amount;
        private System.Windows.Forms.Label label_bookingTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_bookingTime;
        private System.Windows.Forms.TextBox textBox_studentIDNumberForTest;
        private System.Windows.Forms.Label label_studentIDNumberForTest;
        private System.Windows.Forms.ComboBox comboBox_schoolNameForTest;
        private System.Windows.Forms.Label label_schoolNameForTest;
        private System.Windows.Forms.Button button_showAll;
        private System.Windows.Forms.NumericUpDown numericUpDown_bookingDateLimt;
        private System.Windows.Forms.Label label_bookingDateLimit;
        private System.Windows.Forms.Panel panel_parameter;
        private System.Windows.Forms.Button button_setValue;
        private System.Windows.Forms.Label label_bookingTimeSetting;
        private System.Windows.Forms.CheckedListBox checkedListBox_bookingTimeSetting;
    }
}