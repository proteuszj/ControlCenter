namespace Client
{
    partial class Form_CarAllocation
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_setting = new System.Windows.Forms.Panel();
            this.textBox_projectPort = new System.Windows.Forms.TextBox();
            this.label_projectPort = new System.Windows.Forms.Label();
            this.textBox_projectAddress = new System.Windows.Forms.TextBox();
            this.label_projectAddress = new System.Windows.Forms.Label();
            this.numericUpDown_waitingTimeout = new System.Windows.Forms.NumericUpDown();
            this.label_waitingTimeout = new System.Windows.Forms.Label();
            this.numericUpDown_projcetStudentCount = new System.Windows.Forms.NumericUpDown();
            this.label_projectStudentCount = new System.Windows.Forms.Label();
            this.numericUpDown_update = new System.Windows.Forms.NumericUpDown();
            this.button_carMaintenance = new System.Windows.Forms.Button();
            this.label_interval = new System.Windows.Forms.Label();
            this.label_carMaintenance = new System.Windows.Forms.Label();
            this.checkedListBox_carMaintenance = new System.Windows.Forms.CheckedListBox();
            this.dataGridView_car = new System.Windows.Forms.DataGridView();
            this.dataGridView_student = new System.Windows.Forms.DataGridView();
            this.button_manualAllocate = new System.Windows.Forms.Button();
            this.richTextBox_announce = new System.Windows.Forms.RichTextBox();
            this.button_AutoAllocate = new System.Windows.Forms.Button();
            this.button_down = new System.Windows.Forms.Button();
            this.button_up = new System.Windows.Forms.Button();
            this.timer_allocate = new System.Windows.Forms.Timer(this.components);
            this.groupBox_car = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button_reallocate = new System.Windows.Forms.Button();
            this.groupBox_student = new System.Windows.Forms.GroupBox();
            this.button_cancelManualAllocate = new System.Windows.Forms.Button();
            this.panel_setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_waitingTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_projcetStudentCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_update)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_car)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_student)).BeginInit();
            this.groupBox_car.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox_student.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_setting
            // 
            this.panel_setting.Controls.Add(this.textBox_projectPort);
            this.panel_setting.Controls.Add(this.label_projectPort);
            this.panel_setting.Controls.Add(this.textBox_projectAddress);
            this.panel_setting.Controls.Add(this.label_projectAddress);
            this.panel_setting.Controls.Add(this.numericUpDown_waitingTimeout);
            this.panel_setting.Controls.Add(this.label_waitingTimeout);
            this.panel_setting.Controls.Add(this.numericUpDown_projcetStudentCount);
            this.panel_setting.Controls.Add(this.label_projectStudentCount);
            this.panel_setting.Controls.Add(this.numericUpDown_update);
            this.panel_setting.Controls.Add(this.button_carMaintenance);
            this.panel_setting.Controls.Add(this.label_interval);
            this.panel_setting.Controls.Add(this.label_carMaintenance);
            this.panel_setting.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_setting.Location = new System.Drawing.Point(0, 0);
            this.panel_setting.Name = "panel_setting";
            this.panel_setting.Size = new System.Drawing.Size(1084, 40);
            this.panel_setting.TabIndex = 0;
            // 
            // textBox_projectPort
            // 
            this.textBox_projectPort.Location = new System.Drawing.Point(644, 9);
            this.textBox_projectPort.Name = "textBox_projectPort";
            this.textBox_projectPort.Size = new System.Drawing.Size(35, 21);
            this.textBox_projectPort.TabIndex = 6;
            this.textBox_projectPort.Text = "5678";
            // 
            // label_projectPort
            // 
            this.label_projectPort.AutoSize = true;
            this.label_projectPort.Location = new System.Drawing.Point(573, 12);
            this.label_projectPort.Name = "label_projectPort";
            this.label_projectPort.Size = new System.Drawing.Size(65, 12);
            this.label_projectPort.TabIndex = 5;
            this.label_projectPort.Text = "投显端口：";
            // 
            // textBox_projectAddress
            // 
            this.textBox_projectAddress.Location = new System.Drawing.Point(473, 9);
            this.textBox_projectAddress.Name = "textBox_projectAddress";
            this.textBox_projectAddress.Size = new System.Drawing.Size(94, 21);
            this.textBox_projectAddress.TabIndex = 4;
            this.textBox_projectAddress.Text = "192.168.1.100";
            // 
            // label_projectAddress
            // 
            this.label_projectAddress.AutoSize = true;
            this.label_projectAddress.Location = new System.Drawing.Point(402, 12);
            this.label_projectAddress.Name = "label_projectAddress";
            this.label_projectAddress.Size = new System.Drawing.Size(65, 12);
            this.label_projectAddress.TabIndex = 3;
            this.label_projectAddress.Text = "投显地址：";
            // 
            // numericUpDown_waitingTimeout
            // 
            this.numericUpDown_waitingTimeout.Location = new System.Drawing.Point(945, 9);
            this.numericUpDown_waitingTimeout.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDown_waitingTimeout.Name = "numericUpDown_waitingTimeout";
            this.numericUpDown_waitingTimeout.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown_waitingTimeout.TabIndex = 10;
            this.numericUpDown_waitingTimeout.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label_waitingTimeout
            // 
            this.label_waitingTimeout.AutoSize = true;
            this.label_waitingTimeout.Location = new System.Drawing.Point(826, 12);
            this.label_waitingTimeout.Name = "label_waitingTimeout";
            this.label_waitingTimeout.Size = new System.Drawing.Size(113, 12);
            this.label_waitingTimeout.TabIndex = 9;
            this.label_waitingTimeout.Text = "等候超时（分钟）：";
            // 
            // numericUpDown_projcetStudentCount
            // 
            this.numericUpDown_projcetStudentCount.Location = new System.Drawing.Point(780, 9);
            this.numericUpDown_projcetStudentCount.Name = "numericUpDown_projcetStudentCount";
            this.numericUpDown_projcetStudentCount.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown_projcetStudentCount.TabIndex = 8;
            this.numericUpDown_projcetStudentCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label_projectStudentCount
            // 
            this.label_projectStudentCount.AutoSize = true;
            this.label_projectStudentCount.Location = new System.Drawing.Point(685, 12);
            this.label_projectStudentCount.Name = "label_projectStudentCount";
            this.label_projectStudentCount.Size = new System.Drawing.Size(89, 12);
            this.label_projectStudentCount.TabIndex = 7;
            this.label_projectStudentCount.Text = "投显学员数量：";
            // 
            // numericUpDown_update
            // 
            this.numericUpDown_update.Location = new System.Drawing.Point(356, 9);
            this.numericUpDown_update.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_update.Name = "numericUpDown_update";
            this.numericUpDown_update.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown_update.TabIndex = 2;
            this.numericUpDown_update.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // button_carMaintenance
            // 
            this.button_carMaintenance.Location = new System.Drawing.Point(997, 7);
            this.button_carMaintenance.Name = "button_carMaintenance";
            this.button_carMaintenance.Size = new System.Drawing.Size(75, 23);
            this.button_carMaintenance.TabIndex = 11;
            this.button_carMaintenance.Text = "写入";
            this.button_carMaintenance.UseVisualStyleBackColor = true;
            this.button_carMaintenance.Click += new System.EventHandler(this.button_carMaintenance_Click);
            // 
            // label_interval
            // 
            this.label_interval.AutoSize = true;
            this.label_interval.Location = new System.Drawing.Point(249, 12);
            this.label_interval.Name = "label_interval";
            this.label_interval.Size = new System.Drawing.Size(101, 12);
            this.label_interval.TabIndex = 1;
            this.label_interval.Text = "刷新时间（秒）：";
            // 
            // label_carMaintenance
            // 
            this.label_carMaintenance.AutoSize = true;
            this.label_carMaintenance.Location = new System.Drawing.Point(11, 12);
            this.label_carMaintenance.Name = "label_carMaintenance";
            this.label_carMaintenance.Size = new System.Drawing.Size(65, 12);
            this.label_carMaintenance.TabIndex = 0;
            this.label_carMaintenance.Text = "车辆维护：";
            // 
            // checkedListBox_carMaintenance
            // 
            this.checkedListBox_carMaintenance.CheckOnClick = true;
            this.checkedListBox_carMaintenance.FormattingEnabled = true;
            this.checkedListBox_carMaintenance.Location = new System.Drawing.Point(79, 9);
            this.checkedListBox_carMaintenance.Name = "checkedListBox_carMaintenance";
            this.checkedListBox_carMaintenance.Size = new System.Drawing.Size(164, 20);
            this.checkedListBox_carMaintenance.TabIndex = 1;
            this.checkedListBox_carMaintenance.MouseEnter += new System.EventHandler(this.checkedListBox_carMaintenance_MouseEnter);
            this.checkedListBox_carMaintenance.MouseLeave += new System.EventHandler(this.checkedListBox_carMaintenance_MouseLeave);
            // 
            // dataGridView_car
            // 
            this.dataGridView_car.AllowUserToAddRows = false;
            this.dataGridView_car.AllowUserToDeleteRows = false;
            this.dataGridView_car.AllowUserToResizeRows = false;
            this.dataGridView_car.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_car.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_car.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_car.EnableHeadersVisualStyles = false;
            this.dataGridView_car.Location = new System.Drawing.Point(3, 17);
            this.dataGridView_car.MultiSelect = false;
            this.dataGridView_car.Name = "dataGridView_car";
            this.dataGridView_car.ReadOnly = true;
            this.dataGridView_car.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.dataGridView_car.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_car.RowTemplate.Height = 23;
            this.dataGridView_car.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_car.Size = new System.Drawing.Size(588, 252);
            this.dataGridView_car.TabIndex = 0;
            this.dataGridView_car.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_car_CellClick);
            // 
            // dataGridView_student
            // 
            this.dataGridView_student.AllowUserToAddRows = false;
            this.dataGridView_student.AllowUserToDeleteRows = false;
            this.dataGridView_student.AllowUserToResizeRows = false;
            this.dataGridView_student.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_student.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_student.EnableHeadersVisualStyles = false;
            this.dataGridView_student.Location = new System.Drawing.Point(3, 17);
            this.dataGridView_student.MultiSelect = false;
            this.dataGridView_student.Name = "dataGridView_student";
            this.dataGridView_student.ReadOnly = true;
            this.dataGridView_student.RowTemplate.Height = 23;
            this.dataGridView_student.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_student.Size = new System.Drawing.Size(419, 498);
            this.dataGridView_student.TabIndex = 0;
            this.dataGridView_student.SelectionChanged += new System.EventHandler(this.dataGridView_student_SelectionChanged);
            // 
            // button_manualAllocate
            // 
            this.button_manualAllocate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_manualAllocate.Enabled = false;
            this.button_manualAllocate.Location = new System.Drawing.Point(434, 395);
            this.button_manualAllocate.Name = "button_manualAllocate";
            this.button_manualAllocate.Size = new System.Drawing.Size(40, 40);
            this.button_manualAllocate.TabIndex = 5;
            this.button_manualAllocate.Text = "指定分车";
            this.button_manualAllocate.UseVisualStyleBackColor = true;
            this.button_manualAllocate.Click += new System.EventHandler(this.button_manualAllocate_Click);
            // 
            // richTextBox_announce
            // 
            this.richTextBox_announce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_announce.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_announce.Name = "richTextBox_announce";
            this.richTextBox_announce.ReadOnly = true;
            this.richTextBox_announce.Size = new System.Drawing.Size(594, 245);
            this.richTextBox_announce.TabIndex = 0;
            this.richTextBox_announce.Text = "";
            // 
            // button_AutoAllocate
            // 
            this.button_AutoAllocate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AutoAllocate.Location = new System.Drawing.Point(434, 349);
            this.button_AutoAllocate.Name = "button_AutoAllocate";
            this.button_AutoAllocate.Size = new System.Drawing.Size(40, 40);
            this.button_AutoAllocate.TabIndex = 4;
            this.button_AutoAllocate.Text = "自动分车";
            this.button_AutoAllocate.UseVisualStyleBackColor = true;
            this.button_AutoAllocate.Click += new System.EventHandler(this.button_AutoAllocate_Click);
            // 
            // button_down
            // 
            this.button_down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_down.Enabled = false;
            this.button_down.Location = new System.Drawing.Point(434, 183);
            this.button_down.Name = "button_down";
            this.button_down.Size = new System.Drawing.Size(40, 38);
            this.button_down.TabIndex = 3;
            this.button_down.Text = "向下";
            this.button_down.UseVisualStyleBackColor = true;
            this.button_down.Click += new System.EventHandler(this.button_move_Click);
            // 
            // button_up
            // 
            this.button_up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_up.Enabled = false;
            this.button_up.Location = new System.Drawing.Point(434, 139);
            this.button_up.Name = "button_up";
            this.button_up.Size = new System.Drawing.Size(40, 38);
            this.button_up.TabIndex = 2;
            this.button_up.Text = "向上";
            this.button_up.UseVisualStyleBackColor = true;
            this.button_up.Click += new System.EventHandler(this.button_move_Click);
            // 
            // timer_allocate
            // 
            this.timer_allocate.Interval = 1000;
            this.timer_allocate.Tick += new System.EventHandler(this.timer_allocate_Tick);
            // 
            // groupBox_car
            // 
            this.groupBox_car.Controls.Add(this.dataGridView_car);
            this.groupBox_car.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_car.Location = new System.Drawing.Point(0, 0);
            this.groupBox_car.Name = "groupBox_car";
            this.groupBox_car.Size = new System.Drawing.Size(594, 272);
            this.groupBox_car.TabIndex = 0;
            this.groupBox_car.TabStop = false;
            this.groupBox_car.Text = "车辆状态";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button_cancelManualAllocate);
            this.splitContainer1.Panel2.Controls.Add(this.button_reallocate);
            this.splitContainer1.Panel2.Controls.Add(this.button_down);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox_student);
            this.splitContainer1.Panel2.Controls.Add(this.button_manualAllocate);
            this.splitContainer1.Panel2.Controls.Add(this.button_AutoAllocate);
            this.splitContainer1.Panel2.Controls.Add(this.button_up);
            this.splitContainer1.Size = new System.Drawing.Size(1084, 521);
            this.splitContainer1.SplitterDistance = 594;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox_car);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBox_announce);
            this.splitContainer2.Size = new System.Drawing.Size(594, 521);
            this.splitContainer2.SplitterDistance = 272;
            this.splitContainer2.TabIndex = 0;
            // 
            // button_reallocate
            // 
            this.button_reallocate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_reallocate.Location = new System.Drawing.Point(434, 93);
            this.button_reallocate.Name = "button_reallocate";
            this.button_reallocate.Size = new System.Drawing.Size(40, 40);
            this.button_reallocate.TabIndex = 1;
            this.button_reallocate.Text = "过号重排";
            this.button_reallocate.UseVisualStyleBackColor = true;
            this.button_reallocate.Click += new System.EventHandler(this.button_reallocate_Click);
            // 
            // groupBox_student
            // 
            this.groupBox_student.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_student.Controls.Add(this.dataGridView_student);
            this.groupBox_student.Location = new System.Drawing.Point(3, 3);
            this.groupBox_student.Name = "groupBox_student";
            this.groupBox_student.Size = new System.Drawing.Size(425, 518);
            this.groupBox_student.TabIndex = 0;
            this.groupBox_student.TabStop = false;
            this.groupBox_student.Text = "学员列表";
            // 
            // button_cancelManualAllocate
            // 
            this.button_cancelManualAllocate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancelManualAllocate.Enabled = false;
            this.button_cancelManualAllocate.Location = new System.Drawing.Point(434, 441);
            this.button_cancelManualAllocate.Name = "button_cancelManualAllocate";
            this.button_cancelManualAllocate.Size = new System.Drawing.Size(40, 68);
            this.button_cancelManualAllocate.TabIndex = 6;
            this.button_cancelManualAllocate.Text = "取消指定分车";
            this.button_cancelManualAllocate.UseVisualStyleBackColor = true;
            this.button_cancelManualAllocate.Click += new System.EventHandler(this.button_cancelManualAllocate_Click);
            // 
            // Form_CarAllocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.ControlBox = false;
            this.Controls.Add(this.checkedListBox_carMaintenance);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel_setting);
            this.Name = "Form_CarAllocation";
            this.Text = "分车叫号";
            this.Load += new System.EventHandler(this.Form_CarAllocation_Load);
            this.panel_setting.ResumeLayout(false);
            this.panel_setting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_waitingTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_projcetStudentCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_update)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_car)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_student)).EndInit();
            this.groupBox_car.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox_student.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_setting;
        private System.Windows.Forms.Label label_carMaintenance;
        private System.Windows.Forms.CheckedListBox checkedListBox_carMaintenance;
        private System.Windows.Forms.Button button_carMaintenance;
        private System.Windows.Forms.DataGridView dataGridView_car;
        private System.Windows.Forms.DataGridView dataGridView_student;
        private System.Windows.Forms.NumericUpDown numericUpDown_update;
        private System.Windows.Forms.Label label_interval;
        private System.Windows.Forms.NumericUpDown numericUpDown_projcetStudentCount;
        private System.Windows.Forms.Label label_projectStudentCount;
        private System.Windows.Forms.Button button_manualAllocate;
        private System.Windows.Forms.RichTextBox richTextBox_announce;
        private System.Windows.Forms.Button button_AutoAllocate;
        private System.Windows.Forms.Button button_down;
        private System.Windows.Forms.Button button_up;
        private System.Windows.Forms.Timer timer_allocate;
        private System.Windows.Forms.NumericUpDown numericUpDown_waitingTimeout;
        private System.Windows.Forms.Label label_waitingTimeout;
        private System.Windows.Forms.TextBox textBox_projectAddress;
        private System.Windows.Forms.Label label_projectAddress;
        private System.Windows.Forms.Label label_projectPort;
        private System.Windows.Forms.TextBox textBox_projectPort;
        private System.Windows.Forms.GroupBox groupBox_car;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox_student;
        private System.Windows.Forms.Button button_reallocate;
        private System.Windows.Forms.Button button_cancelManualAllocate;
    }
}