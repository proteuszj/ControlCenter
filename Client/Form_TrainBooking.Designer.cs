namespace Client
{
    partial class Form_TrainBooking
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
            this.btn_book = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.comboBox_gender = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_idNumber = new System.Windows.Forms.TextBox();
            this.comboBox_driverLicenseType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_schoolName = new System.Windows.Forms.ComboBox();
            this.button_search = new System.Windows.Forms.Button();
            this.comboBox_paymentWay = new System.Windows.Forms.ComboBox();
            this.label_paymentWay = new System.Windows.Forms.Label();
            this.textBox_times = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_subjectName = new System.Windows.Forms.ComboBox();
            this.label_subject = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_bookingStatus = new System.Windows.Forms.Button();
            this.comboBox_car = new System.Windows.Forms.ComboBox();
            this.radioButton_specifiedCar = new System.Windows.Forms.RadioButton();
            this.radioButton_randomCar = new System.Windows.Forms.RadioButton();
            this.comboBox_bookingTime = new System.Windows.Forms.ComboBox();
            this.label_bookingTime = new System.Windows.Forms.Label();
            this.dateTimePicker_bookingDate = new System.Windows.Forms.DateTimePicker();
            this.label_bookingDate = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_read = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox_idType = new System.Windows.Forms.ComboBox();
            this.dataGridView_student = new System.Windows.Forms.DataGridView();
            this.groupBox_booking = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_student)).BeginInit();
            this.groupBox_booking.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_book
            // 
            this.btn_book.Location = new System.Drawing.Point(326, 60);
            this.btn_book.Name = "btn_book";
            this.btn_book.Size = new System.Drawing.Size(75, 23);
            this.btn_book.TabIndex = 14;
            this.btn_book.Text = "预约";
            this.btn_book.UseVisualStyleBackColor = true;
            this.btn_book.Click += new System.EventHandler(this.btn_book_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(53, 6);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(69, 21);
            this.textBox_name.TabIndex = 1;
            // 
            // comboBox_gender
            // 
            this.comboBox_gender.FormattingEnabled = true;
            this.comboBox_gender.Location = new System.Drawing.Point(53, 32);
            this.comboBox_gender.Name = "comboBox_gender";
            this.comboBox_gender.Size = new System.Drawing.Size(69, 20);
            this.comboBox_gender.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "姓名：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 6;
            this.label15.Text = "性别：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(294, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 12);
            this.label17.TabIndex = 4;
            this.label17.Text = "身份证明号码：";
            // 
            // textBox_idNumber
            // 
            this.textBox_idNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_idNumber.Location = new System.Drawing.Point(389, 6);
            this.textBox_idNumber.MaxLength = 18;
            this.textBox_idNumber.Name = "textBox_idNumber";
            this.textBox_idNumber.Size = new System.Drawing.Size(118, 21);
            this.textBox_idNumber.TabIndex = 5;
            // 
            // comboBox_driverLicenseType
            // 
            this.comboBox_driverLicenseType.FormattingEnabled = true;
            this.comboBox_driverLicenseType.Location = new System.Drawing.Point(221, 32);
            this.comboBox_driverLicenseType.Name = "comboBox_driverLicenseType";
            this.comboBox_driverLicenseType.Size = new System.Drawing.Size(69, 20);
            this.comboBox_driverLicenseType.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "驾驶证类型：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "驾校名称：";
            // 
            // comboBox_schoolName
            // 
            this.comboBox_schoolName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_schoolName.FormattingEnabled = true;
            this.comboBox_schoolName.Location = new System.Drawing.Point(365, 33);
            this.comboBox_schoolName.Name = "comboBox_schoolName";
            this.comboBox_schoolName.Size = new System.Drawing.Size(142, 20);
            this.comboBox_schoolName.TabIndex = 11;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(88, 63);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 13;
            this.button_search.Text = "检索";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // comboBox_paymentWay
            // 
            this.comboBox_paymentWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_paymentWay.FormattingEnabled = true;
            this.comboBox_paymentWay.Location = new System.Drawing.Point(216, 7);
            this.comboBox_paymentWay.Name = "comboBox_paymentWay";
            this.comboBox_paymentWay.Size = new System.Drawing.Size(71, 20);
            this.comboBox_paymentWay.TabIndex = 3;
            // 
            // label_paymentWay
            // 
            this.label_paymentWay.AutoSize = true;
            this.label_paymentWay.Location = new System.Drawing.Point(145, 9);
            this.label_paymentWay.Name = "label_paymentWay";
            this.label_paymentWay.Size = new System.Drawing.Size(65, 12);
            this.label_paymentWay.TabIndex = 2;
            this.label_paymentWay.Text = "支付方式：";
            // 
            // textBox_times
            // 
            this.textBox_times.Location = new System.Drawing.Point(338, 6);
            this.textBox_times.Name = "textBox_times";
            this.textBox_times.Size = new System.Drawing.Size(63, 21);
            this.textBox_times.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "次数：";
            // 
            // comboBox_subjectName
            // 
            this.comboBox_subjectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_subjectName.FormattingEnabled = true;
            this.comboBox_subjectName.Location = new System.Drawing.Point(77, 6);
            this.comboBox_subjectName.Name = "comboBox_subjectName";
            this.comboBox_subjectName.Size = new System.Drawing.Size(65, 20);
            this.comboBox_subjectName.TabIndex = 1;
            // 
            // label_subject
            // 
            this.label_subject.AutoSize = true;
            this.label_subject.Location = new System.Drawing.Point(6, 9);
            this.label_subject.Name = "label_subject";
            this.label_subject.Size = new System.Drawing.Size(65, 12);
            this.label_subject.TabIndex = 0;
            this.label_subject.Text = "考试科目：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl2);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(945, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Enabled = false;
            this.tabControl2.Location = new System.Drawing.Point(526, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(416, 118);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.button_bookingStatus);
            this.tabPage2.Controls.Add(this.comboBox_car);
            this.tabPage2.Controls.Add(this.radioButton_specifiedCar);
            this.tabPage2.Controls.Add(this.radioButton_randomCar);
            this.tabPage2.Controls.Add(this.comboBox_bookingTime);
            this.tabPage2.Controls.Add(this.label_bookingTime);
            this.tabPage2.Controls.Add(this.dateTimePicker_bookingDate);
            this.tabPage2.Controls.Add(this.label_bookingDate);
            this.tabPage2.Controls.Add(this.btn_book);
            this.tabPage2.Controls.Add(this.comboBox_paymentWay);
            this.tabPage2.Controls.Add(this.textBox_times);
            this.tabPage2.Controls.Add(this.label_paymentWay);
            this.tabPage2.Controls.Add(this.label_subject);
            this.tabPage2.Controls.Add(this.comboBox_subjectName);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(408, 92);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "预约";
            // 
            // button_bookingStatus
            // 
            this.button_bookingStatus.Location = new System.Drawing.Point(326, 31);
            this.button_bookingStatus.Name = "button_bookingStatus";
            this.button_bookingStatus.Size = new System.Drawing.Size(75, 23);
            this.button_bookingStatus.TabIndex = 10;
            this.button_bookingStatus.Text = "预约状态";
            this.button_bookingStatus.UseVisualStyleBackColor = true;
            this.button_bookingStatus.Click += new System.EventHandler(this.button_bookingStatus_Click);
            // 
            // comboBox_car
            // 
            this.comboBox_car.Enabled = false;
            this.comboBox_car.FormattingEnabled = true;
            this.comboBox_car.Location = new System.Drawing.Point(162, 62);
            this.comboBox_car.Name = "comboBox_car";
            this.comboBox_car.Size = new System.Drawing.Size(80, 20);
            this.comboBox_car.TabIndex = 13;
            // 
            // radioButton_specifiedCar
            // 
            this.radioButton_specifiedCar.AutoSize = true;
            this.radioButton_specifiedCar.Location = new System.Drawing.Point(85, 63);
            this.radioButton_specifiedCar.Name = "radioButton_specifiedCar";
            this.radioButton_specifiedCar.Size = new System.Drawing.Size(71, 16);
            this.radioButton_specifiedCar.TabIndex = 12;
            this.radioButton_specifiedCar.Text = "指定车辆";
            this.radioButton_specifiedCar.UseVisualStyleBackColor = true;
            this.radioButton_specifiedCar.CheckedChanged += new System.EventHandler(this.radioButton_specifiedCar_CheckedChanged);
            // 
            // radioButton_randomCar
            // 
            this.radioButton_randomCar.AutoSize = true;
            this.radioButton_randomCar.Checked = true;
            this.radioButton_randomCar.Location = new System.Drawing.Point(8, 63);
            this.radioButton_randomCar.Name = "radioButton_randomCar";
            this.radioButton_randomCar.Size = new System.Drawing.Size(71, 16);
            this.radioButton_randomCar.TabIndex = 11;
            this.radioButton_randomCar.TabStop = true;
            this.radioButton_randomCar.Text = "随机分车";
            this.radioButton_randomCar.UseVisualStyleBackColor = true;
            // 
            // comboBox_bookingTime
            // 
            this.comboBox_bookingTime.FormattingEnabled = true;
            this.comboBox_bookingTime.Location = new System.Drawing.Point(242, 32);
            this.comboBox_bookingTime.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_bookingTime.Name = "comboBox_bookingTime";
            this.comboBox_bookingTime.Size = new System.Drawing.Size(79, 20);
            this.comboBox_bookingTime.TabIndex = 9;
            // 
            // label_bookingTime
            // 
            this.label_bookingTime.AutoSize = true;
            this.label_bookingTime.Location = new System.Drawing.Point(161, 36);
            this.label_bookingTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_bookingTime.Name = "label_bookingTime";
            this.label_bookingTime.Size = new System.Drawing.Size(77, 12);
            this.label_bookingTime.TabIndex = 8;
            this.label_bookingTime.Text = "预约时间段：";
            // 
            // dateTimePicker_bookingDate
            // 
            this.dateTimePicker_bookingDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_bookingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_bookingDate.Location = new System.Drawing.Point(77, 32);
            this.dateTimePicker_bookingDate.Name = "dateTimePicker_bookingDate";
            this.dateTimePicker_bookingDate.Size = new System.Drawing.Size(79, 21);
            this.dateTimePicker_bookingDate.TabIndex = 7;
            this.dateTimePicker_bookingDate.ValueChanged += new System.EventHandler(this.dateTimePicker_bookingDate_ValueChanged);
            // 
            // label_bookingDate
            // 
            this.label_bookingDate.AutoSize = true;
            this.label_bookingDate.Location = new System.Drawing.Point(6, 36);
            this.label_bookingDate.Name = "label_bookingDate";
            this.label_bookingDate.Size = new System.Drawing.Size(65, 12);
            this.label_bookingDate.TabIndex = 6;
            this.label_bookingDate.Text = "预约日期：";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(521, 118);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.button_read);
            this.tabPage1.Controls.Add(this.button_search);
            this.tabPage1.Controls.Add(this.comboBox_driverLicenseType);
            this.tabPage1.Controls.Add(this.textBox_idNumber);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.comboBox_schoolName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.comboBox_idType);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.comboBox_gender);
            this.tabPage1.Controls.Add(this.textBox_name);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(513, 92);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "学员检索";
            // 
            // button_read
            // 
            this.button_read.Location = new System.Drawing.Point(8, 63);
            this.button_read.Name = "button_read";
            this.button_read.Size = new System.Drawing.Size(75, 23);
            this.button_read.TabIndex = 12;
            this.button_read.Text = "读卡";
            this.button_read.UseVisualStyleBackColor = true;
            this.button_read.Click += new System.EventHandler(this.button_read_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(127, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 12);
            this.label16.TabIndex = 2;
            this.label16.Text = "身份证明类型：";
            // 
            // comboBox_idType
            // 
            this.comboBox_idType.FormattingEnabled = true;
            this.comboBox_idType.Location = new System.Drawing.Point(221, 6);
            this.comboBox_idType.Name = "comboBox_idType";
            this.comboBox_idType.Size = new System.Drawing.Size(69, 20);
            this.comboBox_idType.TabIndex = 3;
            // 
            // dataGridView_student
            // 
            this.dataGridView_student.AllowUserToAddRows = false;
            this.dataGridView_student.AllowUserToDeleteRows = false;
            this.dataGridView_student.AllowUserToResizeRows = false;
            this.dataGridView_student.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_student.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_student.EnableHeadersVisualStyles = false;
            this.dataGridView_student.Location = new System.Drawing.Point(3, 17);
            this.dataGridView_student.Name = "dataGridView_student";
            this.dataGridView_student.ReadOnly = true;
            this.dataGridView_student.RowHeadersVisible = false;
            this.dataGridView_student.RowTemplate.Height = 23;
            this.dataGridView_student.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_student.Size = new System.Drawing.Size(939, 395);
            this.dataGridView_student.TabIndex = 0;
            this.dataGridView_student.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_student_CellClick);
            this.dataGridView_student.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_student_CellDoubleClick);
            // 
            // groupBox_booking
            // 
            this.groupBox_booking.Controls.Add(this.dataGridView_student);
            this.groupBox_booking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_booking.Location = new System.Drawing.Point(0, 138);
            this.groupBox_booking.Name = "groupBox_booking";
            this.groupBox_booking.Size = new System.Drawing.Size(945, 415);
            this.groupBox_booking.TabIndex = 1;
            this.groupBox_booking.TabStop = false;
            this.groupBox_booking.Text = "学员信息";
            // 
            // Form_TrainBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 553);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_booking);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_TrainBooking";
            this.Text = "预约培训";
            this.groupBox1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_student)).EndInit();
            this.groupBox_booking.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_book;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.ComboBox comboBox_gender;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox_idNumber;
        private System.Windows.Forms.ComboBox comboBox_driverLicenseType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_subject;
        private System.Windows.Forms.TextBox textBox_times;
        private System.Windows.Forms.ComboBox comboBox_subjectName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_paymentWay;
        private System.Windows.Forms.Label label_paymentWay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_student;
        private System.Windows.Forms.ComboBox comboBox_schoolName;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox_booking;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox_idType;
        private System.Windows.Forms.DateTimePicker dateTimePicker_bookingDate;
        private System.Windows.Forms.Label label_bookingDate;
        private System.Windows.Forms.Button button_read;
        private System.Windows.Forms.Label label_bookingTime;
        private System.Windows.Forms.ComboBox comboBox_bookingTime;
        private System.Windows.Forms.ComboBox comboBox_car;
        private System.Windows.Forms.RadioButton radioButton_specifiedCar;
        private System.Windows.Forms.RadioButton radioButton_randomCar;
        private System.Windows.Forms.Button button_bookingStatus;
    }
}