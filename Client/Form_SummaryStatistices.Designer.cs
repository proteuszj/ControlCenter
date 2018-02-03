namespace Client
{
    partial class Form_SummaryStatistices
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
            this.btn_statistices = new System.Windows.Forms.Button();
            this.label_endTime = new System.Windows.Forms.Label();
            this.dateTimePicker_startTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endTime = new System.Windows.Forms.DateTimePicker();
            this.comboBox_condition = new System.Windows.Forms.ComboBox();
            this.comboBox_value = new System.Windows.Forms.ComboBox();
            this.label_condition = new System.Windows.Forms.Label();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.label_type = new System.Windows.Forms.Label();
            this.label_value = new System.Windows.Forms.Label();
            this.button_Export = new System.Windows.Forms.Button();
            this.dataGridView_Statistics = new System.Windows.Forms.DataGridView();
            this.saveFileDialog_excel = new System.Windows.Forms.SaveFileDialog();
            this.panel_filter = new System.Windows.Forms.Panel();
            this.button_readCard = new System.Windows.Forms.Button();
            this.textBox_idNumber = new System.Windows.Forms.TextBox();
            this.label_cashierIDNumber = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label_cashierName = new System.Windows.Forms.Label();
            this.label_startTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Statistics)).BeginInit();
            this.panel_filter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_statistices
            // 
            this.btn_statistices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_statistices.Location = new System.Drawing.Point(722, 39);
            this.btn_statistices.Name = "btn_statistices";
            this.btn_statistices.Size = new System.Drawing.Size(75, 23);
            this.btn_statistices.TabIndex = 10;
            this.btn_statistices.Text = "统计";
            this.btn_statistices.UseVisualStyleBackColor = true;
            this.btn_statistices.Click += new System.EventHandler(this.btn_statistices_Click);
            // 
            // label_endTime
            // 
            this.label_endTime.AutoSize = true;
            this.label_endTime.Location = new System.Drawing.Point(230, 15);
            this.label_endTime.Name = "label_endTime";
            this.label_endTime.Size = new System.Drawing.Size(89, 12);
            this.label_endTime.TabIndex = 2;
            this.label_endTime.Text = "考试结束时间：";
            // 
            // dateTimePicker_startTime
            // 
            this.dateTimePicker_startTime.Checked = false;
            this.dateTimePicker_startTime.Location = new System.Drawing.Point(98, 9);
            this.dateTimePicker_startTime.Name = "dateTimePicker_startTime";
            this.dateTimePicker_startTime.ShowCheckBox = true;
            this.dateTimePicker_startTime.Size = new System.Drawing.Size(126, 21);
            this.dateTimePicker_startTime.TabIndex = 1;
            // 
            // dateTimePicker_endTime
            // 
            this.dateTimePicker_endTime.Location = new System.Drawing.Point(325, 9);
            this.dateTimePicker_endTime.Name = "dateTimePicker_endTime";
            this.dateTimePicker_endTime.ShowCheckBox = true;
            this.dateTimePicker_endTime.Size = new System.Drawing.Size(126, 21);
            this.dateTimePicker_endTime.TabIndex = 3;
            // 
            // comboBox_condition
            // 
            this.comboBox_condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_condition.FormattingEnabled = true;
            this.comboBox_condition.Items.AddRange(new object[] {
            "<全部>",
            "考车编号",
            "考试员",
            "培训机构",
            "考试原因",
            "考试车型",
            "设备编号"});
            this.comboBox_condition.Location = new System.Drawing.Point(203, 36);
            this.comboBox_condition.Name = "comboBox_condition";
            this.comboBox_condition.Size = new System.Drawing.Size(102, 20);
            this.comboBox_condition.TabIndex = 7;
            this.comboBox_condition.SelectedIndexChanged += new System.EventHandler(this.comboBox_condition_SelectedIndexChanged);
            // 
            // comboBox_value
            // 
            this.comboBox_value.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_value.FormattingEnabled = true;
            this.comboBox_value.Location = new System.Drawing.Point(346, 36);
            this.comboBox_value.Name = "comboBox_value";
            this.comboBox_value.Size = new System.Drawing.Size(121, 20);
            this.comboBox_value.TabIndex = 9;
            this.comboBox_value.DropDown += new System.EventHandler(this.comboBox_value_DropDown);
            // 
            // label_condition
            // 
            this.label_condition.AutoSize = true;
            this.label_condition.Location = new System.Drawing.Point(156, 39);
            this.label_condition.Name = "label_condition";
            this.label_condition.Size = new System.Drawing.Size(41, 12);
            this.label_condition.TabIndex = 6;
            this.label_condition.Text = "条件：";
            // 
            // comboBox_type
            // 
            this.comboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "合格率",
            "扣分原因",
            "考试项目"});
            this.comboBox_type.Location = new System.Drawing.Point(50, 36);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(100, 20);
            this.comboBox_type.TabIndex = 5;
            this.comboBox_type.SelectedIndexChanged += new System.EventHandler(this.comboBox_type_SelectedIndexChanged);
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(3, 39);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(41, 12);
            this.label_type.TabIndex = 4;
            this.label_type.Text = "类型：";
            // 
            // label_value
            // 
            this.label_value.AutoSize = true;
            this.label_value.Location = new System.Drawing.Point(311, 39);
            this.label_value.Name = "label_value";
            this.label_value.Size = new System.Drawing.Size(29, 12);
            this.label_value.TabIndex = 8;
            this.label_value.Text = "值：";
            // 
            // button_Export
            // 
            this.button_Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Export.Location = new System.Drawing.Point(803, 39);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(75, 23);
            this.button_Export.TabIndex = 11;
            this.button_Export.Text = "导出";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // dataGridView_Statistics
            // 
            this.dataGridView_Statistics.AllowUserToAddRows = false;
            this.dataGridView_Statistics.AllowUserToDeleteRows = false;
            this.dataGridView_Statistics.AllowUserToResizeRows = false;
            this.dataGridView_Statistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Statistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Statistics.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Statistics.EnableHeadersVisualStyles = false;
            this.dataGridView_Statistics.Location = new System.Drawing.Point(0, 78);
            this.dataGridView_Statistics.Name = "dataGridView_Statistics";
            this.dataGridView_Statistics.ReadOnly = true;
            this.dataGridView_Statistics.RowHeadersVisible = false;
            this.dataGridView_Statistics.RowTemplate.Height = 23;
            this.dataGridView_Statistics.Size = new System.Drawing.Size(881, 349);
            this.dataGridView_Statistics.TabIndex = 1;
            // 
            // saveFileDialog_excel
            // 
            this.saveFileDialog_excel.DefaultExt = "xlsx";
            this.saveFileDialog_excel.Filter = "Excel File|*.xlsx|All files|*.*";
            // 
            // panel_filter
            // 
            this.panel_filter.Controls.Add(this.button_readCard);
            this.panel_filter.Controls.Add(this.textBox_idNumber);
            this.panel_filter.Controls.Add(this.label_cashierIDNumber);
            this.panel_filter.Controls.Add(this.textBox_name);
            this.panel_filter.Controls.Add(this.label_cashierName);
            this.panel_filter.Controls.Add(this.btn_statistices);
            this.panel_filter.Controls.Add(this.comboBox_value);
            this.panel_filter.Controls.Add(this.button_Export);
            this.panel_filter.Controls.Add(this.comboBox_condition);
            this.panel_filter.Controls.Add(this.label_value);
            this.panel_filter.Controls.Add(this.label_startTime);
            this.panel_filter.Controls.Add(this.dateTimePicker_endTime);
            this.panel_filter.Controls.Add(this.label_condition);
            this.panel_filter.Controls.Add(this.label_endTime);
            this.panel_filter.Controls.Add(this.comboBox_type);
            this.panel_filter.Controls.Add(this.dateTimePicker_startTime);
            this.panel_filter.Controls.Add(this.label_type);
            this.panel_filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_filter.Location = new System.Drawing.Point(0, 0);
            this.panel_filter.Name = "panel_filter";
            this.panel_filter.Size = new System.Drawing.Size(881, 72);
            this.panel_filter.TabIndex = 0;
            // 
            // button_readCard
            // 
            this.button_readCard.Location = new System.Drawing.Point(789, 10);
            this.button_readCard.Name = "button_readCard";
            this.button_readCard.Size = new System.Drawing.Size(49, 23);
            this.button_readCard.TabIndex = 16;
            this.button_readCard.Text = "读卡";
            this.button_readCard.UseVisualStyleBackColor = true;
            this.button_readCard.Click += new System.EventHandler(this.button_readCard_Click);
            // 
            // textBox_idNumber
            // 
            this.textBox_idNumber.Location = new System.Drawing.Point(660, 12);
            this.textBox_idNumber.Name = "textBox_idNumber";
            this.textBox_idNumber.Size = new System.Drawing.Size(123, 21);
            this.textBox_idNumber.TabIndex = 15;
            // 
            // label_cashierIDNumber
            // 
            this.label_cashierIDNumber.AutoSize = true;
            this.label_cashierIDNumber.Location = new System.Drawing.Point(577, 15);
            this.label_cashierIDNumber.Name = "label_cashierIDNumber";
            this.label_cashierIDNumber.Size = new System.Drawing.Size(77, 12);
            this.label_cashierIDNumber.TabIndex = 14;
            this.label_cashierIDNumber.Text = "身份证号码：";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(504, 12);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(67, 21);
            this.textBox_name.TabIndex = 13;
            // 
            // label_cashierName
            // 
            this.label_cashierName.AutoSize = true;
            this.label_cashierName.Location = new System.Drawing.Point(457, 15);
            this.label_cashierName.Name = "label_cashierName";
            this.label_cashierName.Size = new System.Drawing.Size(41, 12);
            this.label_cashierName.TabIndex = 12;
            this.label_cashierName.Text = "姓名：";
            // 
            // label_startTime
            // 
            this.label_startTime.AutoSize = true;
            this.label_startTime.Location = new System.Drawing.Point(3, 15);
            this.label_startTime.Name = "label_startTime";
            this.label_startTime.Size = new System.Drawing.Size(89, 12);
            this.label_startTime.TabIndex = 0;
            this.label_startTime.Text = "考试开始时间：";
            // 
            // Form_SummaryStatistices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 427);
            this.ControlBox = false;
            this.Controls.Add(this.panel_filter);
            this.Controls.Add(this.dataGridView_Statistics);
            this.Name = "Form_SummaryStatistices";
            this.Text = "综合统计";
            this.Load += new System.EventHandler(this.Form_SummaryStatistices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Statistics)).EndInit();
            this.panel_filter.ResumeLayout(false);
            this.panel_filter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_statistices;
        private System.Windows.Forms.Label label_endTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endTime;
        private System.Windows.Forms.Label label_condition;
        private System.Windows.Forms.ComboBox comboBox_condition;
        private System.Windows.Forms.ComboBox comboBox_value;
        private System.Windows.Forms.DataGridView dataGridView_Statistics;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.Label label_type;
        private System.Windows.Forms.Label label_value;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_excel;
        private System.Windows.Forms.Panel panel_filter;
        private System.Windows.Forms.Label label_startTime;
        private System.Windows.Forms.Button button_readCard;
        private System.Windows.Forms.TextBox textBox_idNumber;
        private System.Windows.Forms.Label label_cashierIDNumber;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label_cashierName;
    }
}