namespace Client
{
    partial class Form_PaymentDetail
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
            this.dataGridView_paymentDetail = new System.Windows.Forms.DataGridView();
            this.panel_filter = new System.Windows.Forms.Panel();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_export = new System.Windows.Forms.Button();
            this.groupBox_other = new System.Windows.Forms.GroupBox();
            this.comboBox_car = new System.Windows.Forms.ComboBox();
            this.label_car = new System.Windows.Forms.Label();
            this.comboBox_school = new System.Windows.Forms.ComboBox();
            this.label_school = new System.Windows.Forms.Label();
            this.button_query = new System.Windows.Forms.Button();
            this.groupBox_student = new System.Windows.Forms.GroupBox();
            this.button_readStudent = new System.Windows.Forms.Button();
            this.textBox_studentIDNumber = new System.Windows.Forms.TextBox();
            this.label_studentIDNumber = new System.Windows.Forms.Label();
            this.textBox_studentName = new System.Windows.Forms.TextBox();
            this.label_studentName = new System.Windows.Forms.Label();
            this.groupBox_cashier = new System.Windows.Forms.GroupBox();
            this.button_readCashier = new System.Windows.Forms.Button();
            this.textBox_cashierIDNumber = new System.Windows.Forms.TextBox();
            this.label_cashierIDNumber = new System.Windows.Forms.Label();
            this.textBox_cashierName = new System.Windows.Forms.TextBox();
            this.label_cashierName = new System.Windows.Forms.Label();
            this.groupBox_payTime = new System.Windows.Forms.GroupBox();
            this.label_end = new System.Windows.Forms.Label();
            this.label_start = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.saveFileDialog_excel = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_paymentDetail)).BeginInit();
            this.panel_filter.SuspendLayout();
            this.groupBox_other.SuspendLayout();
            this.groupBox_student.SuspendLayout();
            this.groupBox_cashier.SuspendLayout();
            this.groupBox_payTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_paymentDetail
            // 
            this.dataGridView_paymentDetail.AllowUserToAddRows = false;
            this.dataGridView_paymentDetail.AllowUserToDeleteRows = false;
            this.dataGridView_paymentDetail.AllowUserToResizeRows = false;
            this.dataGridView_paymentDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_paymentDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_paymentDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_paymentDetail.EnableHeadersVisualStyles = false;
            this.dataGridView_paymentDetail.Location = new System.Drawing.Point(0, 99);
            this.dataGridView_paymentDetail.Name = "dataGridView_paymentDetail";
            this.dataGridView_paymentDetail.ReadOnly = true;
            this.dataGridView_paymentDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView_paymentDetail.RowTemplate.Height = 23;
            this.dataGridView_paymentDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_paymentDetail.Size = new System.Drawing.Size(894, 363);
            this.dataGridView_paymentDetail.TabIndex = 1;
            // 
            // panel_filter
            // 
            this.panel_filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_filter.Controls.Add(this.button_clear);
            this.panel_filter.Controls.Add(this.button_export);
            this.panel_filter.Controls.Add(this.groupBox_other);
            this.panel_filter.Controls.Add(this.button_query);
            this.panel_filter.Controls.Add(this.groupBox_student);
            this.panel_filter.Controls.Add(this.groupBox_cashier);
            this.panel_filter.Controls.Add(this.groupBox_payTime);
            this.panel_filter.Location = new System.Drawing.Point(0, 0);
            this.panel_filter.Name = "panel_filter";
            this.panel_filter.Size = new System.Drawing.Size(894, 93);
            this.panel_filter.TabIndex = 0;
            // 
            // button_clear
            // 
            this.button_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_clear.Location = new System.Drawing.Point(807, 7);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 4;
            this.button_clear.Text = "清空条件";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_export
            // 
            this.button_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_export.Location = new System.Drawing.Point(807, 65);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(75, 23);
            this.button_export.TabIndex = 6;
            this.button_export.Text = "导出";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // groupBox_other
            // 
            this.groupBox_other.Controls.Add(this.comboBox_car);
            this.groupBox_other.Controls.Add(this.label_car);
            this.groupBox_other.Controls.Add(this.comboBox_school);
            this.groupBox_other.Controls.Add(this.label_school);
            this.groupBox_other.Location = new System.Drawing.Point(636, 12);
            this.groupBox_other.Name = "groupBox_other";
            this.groupBox_other.Size = new System.Drawing.Size(156, 77);
            this.groupBox_other.TabIndex = 3;
            this.groupBox_other.TabStop = false;
            this.groupBox_other.Text = "驾校/车辆";
            // 
            // comboBox_car
            // 
            this.comboBox_car.FormattingEnabled = true;
            this.comboBox_car.Location = new System.Drawing.Point(53, 47);
            this.comboBox_car.Name = "comboBox_car";
            this.comboBox_car.Size = new System.Drawing.Size(97, 20);
            this.comboBox_car.TabIndex = 3;
            // 
            // label_car
            // 
            this.label_car.AutoSize = true;
            this.label_car.Location = new System.Drawing.Point(6, 53);
            this.label_car.Name = "label_car";
            this.label_car.Size = new System.Drawing.Size(41, 12);
            this.label_car.TabIndex = 2;
            this.label_car.Text = "车牌：";
            // 
            // comboBox_school
            // 
            this.comboBox_school.FormattingEnabled = true;
            this.comboBox_school.Location = new System.Drawing.Point(53, 20);
            this.comboBox_school.Name = "comboBox_school";
            this.comboBox_school.Size = new System.Drawing.Size(97, 20);
            this.comboBox_school.TabIndex = 1;
            // 
            // label_school
            // 
            this.label_school.AutoSize = true;
            this.label_school.Location = new System.Drawing.Point(6, 26);
            this.label_school.Name = "label_school";
            this.label_school.Size = new System.Drawing.Size(41, 12);
            this.label_school.TabIndex = 0;
            this.label_school.Text = "驾校：";
            // 
            // button_query
            // 
            this.button_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_query.Location = new System.Drawing.Point(807, 36);
            this.button_query.Name = "button_query";
            this.button_query.Size = new System.Drawing.Size(75, 23);
            this.button_query.TabIndex = 5;
            this.button_query.Text = "查询";
            this.button_query.UseVisualStyleBackColor = true;
            this.button_query.Click += new System.EventHandler(this.button_query_Click);
            // 
            // groupBox_student
            // 
            this.groupBox_student.Controls.Add(this.button_readStudent);
            this.groupBox_student.Controls.Add(this.textBox_studentIDNumber);
            this.groupBox_student.Controls.Add(this.label_studentIDNumber);
            this.groupBox_student.Controls.Add(this.textBox_studentName);
            this.groupBox_student.Controls.Add(this.label_studentName);
            this.groupBox_student.Location = new System.Drawing.Point(412, 12);
            this.groupBox_student.Name = "groupBox_student";
            this.groupBox_student.Size = new System.Drawing.Size(218, 77);
            this.groupBox_student.TabIndex = 2;
            this.groupBox_student.TabStop = false;
            this.groupBox_student.Text = "学员：";
            // 
            // button_readStudent
            // 
            this.button_readStudent.Location = new System.Drawing.Point(163, 20);
            this.button_readStudent.Name = "button_readStudent";
            this.button_readStudent.Size = new System.Drawing.Size(49, 23);
            this.button_readStudent.TabIndex = 5;
            this.button_readStudent.Text = "读卡";
            this.button_readStudent.UseVisualStyleBackColor = true;
            this.button_readStudent.Click += new System.EventHandler(this.button_readStudent_Click);
            // 
            // textBox_studentIDNumber
            // 
            this.textBox_studentIDNumber.Location = new System.Drawing.Point(89, 50);
            this.textBox_studentIDNumber.Name = "textBox_studentIDNumber";
            this.textBox_studentIDNumber.Size = new System.Drawing.Size(123, 21);
            this.textBox_studentIDNumber.TabIndex = 3;
            // 
            // label_studentIDNumber
            // 
            this.label_studentIDNumber.AutoSize = true;
            this.label_studentIDNumber.Location = new System.Drawing.Point(6, 53);
            this.label_studentIDNumber.Name = "label_studentIDNumber";
            this.label_studentIDNumber.Size = new System.Drawing.Size(77, 12);
            this.label_studentIDNumber.TabIndex = 2;
            this.label_studentIDNumber.Text = "身份证号码：";
            // 
            // textBox_studentName
            // 
            this.textBox_studentName.Location = new System.Drawing.Point(89, 23);
            this.textBox_studentName.Name = "textBox_studentName";
            this.textBox_studentName.Size = new System.Drawing.Size(67, 21);
            this.textBox_studentName.TabIndex = 1;
            // 
            // label_studentName
            // 
            this.label_studentName.AutoSize = true;
            this.label_studentName.Location = new System.Drawing.Point(6, 26);
            this.label_studentName.Name = "label_studentName";
            this.label_studentName.Size = new System.Drawing.Size(41, 12);
            this.label_studentName.TabIndex = 0;
            this.label_studentName.Text = "姓名：";
            // 
            // groupBox_cashier
            // 
            this.groupBox_cashier.Controls.Add(this.button_readCashier);
            this.groupBox_cashier.Controls.Add(this.textBox_cashierIDNumber);
            this.groupBox_cashier.Controls.Add(this.label_cashierIDNumber);
            this.groupBox_cashier.Controls.Add(this.textBox_cashierName);
            this.groupBox_cashier.Controls.Add(this.label_cashierName);
            this.groupBox_cashier.Location = new System.Drawing.Point(188, 12);
            this.groupBox_cashier.Name = "groupBox_cashier";
            this.groupBox_cashier.Size = new System.Drawing.Size(218, 77);
            this.groupBox_cashier.TabIndex = 1;
            this.groupBox_cashier.TabStop = false;
            this.groupBox_cashier.Text = "收银员：";
            // 
            // button_readCashier
            // 
            this.button_readCashier.Location = new System.Drawing.Point(163, 20);
            this.button_readCashier.Name = "button_readCashier";
            this.button_readCashier.Size = new System.Drawing.Size(49, 23);
            this.button_readCashier.TabIndex = 4;
            this.button_readCashier.Text = "读卡";
            this.button_readCashier.UseVisualStyleBackColor = true;
            this.button_readCashier.Click += new System.EventHandler(this.button_readCashier_Click);
            // 
            // textBox_cashierIDNumber
            // 
            this.textBox_cashierIDNumber.Location = new System.Drawing.Point(89, 50);
            this.textBox_cashierIDNumber.Name = "textBox_cashierIDNumber";
            this.textBox_cashierIDNumber.Size = new System.Drawing.Size(123, 21);
            this.textBox_cashierIDNumber.TabIndex = 3;
            // 
            // label_cashierIDNumber
            // 
            this.label_cashierIDNumber.AutoSize = true;
            this.label_cashierIDNumber.Location = new System.Drawing.Point(6, 53);
            this.label_cashierIDNumber.Name = "label_cashierIDNumber";
            this.label_cashierIDNumber.Size = new System.Drawing.Size(77, 12);
            this.label_cashierIDNumber.TabIndex = 2;
            this.label_cashierIDNumber.Text = "身份证号码：";
            // 
            // textBox_cashierName
            // 
            this.textBox_cashierName.Location = new System.Drawing.Point(89, 23);
            this.textBox_cashierName.Name = "textBox_cashierName";
            this.textBox_cashierName.Size = new System.Drawing.Size(67, 21);
            this.textBox_cashierName.TabIndex = 1;
            // 
            // label_cashierName
            // 
            this.label_cashierName.AutoSize = true;
            this.label_cashierName.Location = new System.Drawing.Point(6, 26);
            this.label_cashierName.Name = "label_cashierName";
            this.label_cashierName.Size = new System.Drawing.Size(41, 12);
            this.label_cashierName.TabIndex = 0;
            this.label_cashierName.Text = "姓名：";
            // 
            // groupBox_payTime
            // 
            this.groupBox_payTime.Controls.Add(this.label_end);
            this.groupBox_payTime.Controls.Add(this.label_start);
            this.groupBox_payTime.Controls.Add(this.dateTimePicker_start);
            this.groupBox_payTime.Controls.Add(this.dateTimePicker_end);
            this.groupBox_payTime.Location = new System.Drawing.Point(12, 12);
            this.groupBox_payTime.Name = "groupBox_payTime";
            this.groupBox_payTime.Size = new System.Drawing.Size(170, 77);
            this.groupBox_payTime.TabIndex = 0;
            this.groupBox_payTime.TabStop = false;
            this.groupBox_payTime.Text = "支付时间：";
            // 
            // label_end
            // 
            this.label_end.AutoSize = true;
            this.label_end.Location = new System.Drawing.Point(6, 53);
            this.label_end.Name = "label_end";
            this.label_end.Size = new System.Drawing.Size(41, 12);
            this.label_end.TabIndex = 2;
            this.label_end.Text = "结束：";
            // 
            // label_start
            // 
            this.label_start.AutoSize = true;
            this.label_start.Location = new System.Drawing.Point(6, 26);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(41, 12);
            this.label_start.TabIndex = 0;
            this.label_start.Text = "起始：";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(53, 20);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(111, 21);
            this.dateTimePicker_start.TabIndex = 1;
            this.dateTimePicker_start.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(53, 47);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(111, 21);
            this.dateTimePicker_end.TabIndex = 3;
            this.dateTimePicker_end.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // saveFileDialog_excel
            // 
            this.saveFileDialog_excel.DefaultExt = "xlsx";
            this.saveFileDialog_excel.Filter = "Excel File|*.xlsx|All files|*.*";
            // 
            // Form_PaymentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 461);
            this.ControlBox = false;
            this.Controls.Add(this.panel_filter);
            this.Controls.Add(this.dataGridView_paymentDetail);
            this.Name = "Form_PaymentDetail";
            this.Text = "支付流水";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_paymentDetail)).EndInit();
            this.panel_filter.ResumeLayout(false);
            this.groupBox_other.ResumeLayout(false);
            this.groupBox_other.PerformLayout();
            this.groupBox_student.ResumeLayout(false);
            this.groupBox_student.PerformLayout();
            this.groupBox_cashier.ResumeLayout(false);
            this.groupBox_cashier.PerformLayout();
            this.groupBox_payTime.ResumeLayout(false);
            this.groupBox_payTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_paymentDetail;
        private System.Windows.Forms.Panel panel_filter;
        private System.Windows.Forms.Button button_query;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.GroupBox groupBox_payTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.GroupBox groupBox_student;
        private System.Windows.Forms.TextBox textBox_studentIDNumber;
        private System.Windows.Forms.Label label_studentIDNumber;
        private System.Windows.Forms.TextBox textBox_studentName;
        private System.Windows.Forms.Label label_studentName;
        private System.Windows.Forms.GroupBox groupBox_cashier;
        private System.Windows.Forms.TextBox textBox_cashierIDNumber;
        private System.Windows.Forms.Label label_cashierIDNumber;
        private System.Windows.Forms.TextBox textBox_cashierName;
        private System.Windows.Forms.Label label_cashierName;
        private System.Windows.Forms.Label label_end;
        private System.Windows.Forms.Label label_start;
        private System.Windows.Forms.GroupBox groupBox_other;
        private System.Windows.Forms.ComboBox comboBox_car;
        private System.Windows.Forms.Label label_car;
        private System.Windows.Forms.ComboBox comboBox_school;
        private System.Windows.Forms.Label label_school;
        private System.Windows.Forms.Button button_readStudent;
        private System.Windows.Forms.Button button_readCashier;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_excel;
        private System.Windows.Forms.Button button_clear;
    }
}