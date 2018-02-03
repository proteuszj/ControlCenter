namespace Client
{
    partial class Form_Booking
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_CheckIn = new System.Windows.Forms.Button();
            this.textBox_sfzmhm = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.label_sfzmhm = new System.Windows.Forms.Label();
            this.label_kskm = new System.Windows.Forms.Label();
            this.dateTimePicker_ksrq = new System.Windows.Forms.DateTimePicker();
            this.btn_download = new System.Windows.Forms.Button();
            this.label_ksrq = new System.Windows.Forms.Label();
            this.label_kcxh = new System.Windows.Forms.Label();
            this.comboBox_kskm = new System.Windows.Forms.ComboBox();
            this.textBox_kcxh = new System.Windows.Forms.TextBox();
            this.dataGridView_booking = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_booking)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_CheckIn);
            this.panel1.Controls.Add(this.textBox_sfzmhm);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.label_sfzmhm);
            this.panel1.Controls.Add(this.label_kskm);
            this.panel1.Controls.Add(this.dateTimePicker_ksrq);
            this.panel1.Controls.Add(this.btn_download);
            this.panel1.Controls.Add(this.label_ksrq);
            this.panel1.Controls.Add(this.label_kcxh);
            this.panel1.Controls.Add(this.comboBox_kskm);
            this.panel1.Controls.Add(this.textBox_kcxh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 41);
            this.panel1.TabIndex = 7;
            // 
            // button_CheckIn
            // 
            this.button_CheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CheckIn.Location = new System.Drawing.Point(786, 7);
            this.button_CheckIn.Name = "button_CheckIn";
            this.button_CheckIn.Size = new System.Drawing.Size(75, 23);
            this.button_CheckIn.TabIndex = 44;
            this.button_CheckIn.Text = "签到";
            this.button_CheckIn.UseVisualStyleBackColor = true;
            this.button_CheckIn.Click += new System.EventHandler(this.button_CheckIn_Click);
            // 
            // textBox_sfzmhm
            // 
            this.textBox_sfzmhm.Location = new System.Drawing.Point(89, 9);
            this.textBox_sfzmhm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_sfzmhm.MaxLength = 18;
            this.textBox_sfzmhm.Name = "textBox_sfzmhm";
            this.textBox_sfzmhm.Size = new System.Drawing.Size(130, 21);
            this.textBox_sfzmhm.TabIndex = 43;
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.Location = new System.Drawing.Point(946, 7);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 8;
            this.btn_search.Text = "检索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label_sfzmhm
            // 
            this.label_sfzmhm.AutoSize = true;
            this.label_sfzmhm.Location = new System.Drawing.Point(8, 13);
            this.label_sfzmhm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_sfzmhm.Name = "label_sfzmhm";
            this.label_sfzmhm.Size = new System.Drawing.Size(77, 12);
            this.label_sfzmhm.TabIndex = 42;
            this.label_sfzmhm.Text = "身份证明号码";
            // 
            // label_kskm
            // 
            this.label_kskm.AutoSize = true;
            this.label_kskm.Location = new System.Drawing.Point(227, 13);
            this.label_kskm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_kskm.Name = "label_kskm";
            this.label_kskm.Size = new System.Drawing.Size(53, 12);
            this.label_kskm.TabIndex = 38;
            this.label_kskm.Text = "考试科目";
            // 
            // dateTimePicker_ksrq
            // 
            this.dateTimePicker_ksrq.Checked = false;
            this.dateTimePicker_ksrq.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker_ksrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_ksrq.Location = new System.Drawing.Point(431, 9);
            this.dateTimePicker_ksrq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker_ksrq.Name = "dateTimePicker_ksrq";
            this.dateTimePicker_ksrq.ShowCheckBox = true;
            this.dateTimePicker_ksrq.Size = new System.Drawing.Size(101, 21);
            this.dateTimePicker_ksrq.TabIndex = 41;
            // 
            // btn_download
            // 
            this.btn_download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_download.Location = new System.Drawing.Point(866, 7);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(75, 23);
            this.btn_download.TabIndex = 16;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // label_ksrq
            // 
            this.label_ksrq.AutoSize = true;
            this.label_ksrq.Location = new System.Drawing.Point(373, 13);
            this.label_ksrq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ksrq.Name = "label_ksrq";
            this.label_ksrq.Size = new System.Drawing.Size(53, 12);
            this.label_ksrq.TabIndex = 40;
            this.label_ksrq.Text = "考试日期";
            // 
            // label_kcxh
            // 
            this.label_kcxh.AutoSize = true;
            this.label_kcxh.Location = new System.Drawing.Point(543, 13);
            this.label_kcxh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_kcxh.Name = "label_kcxh";
            this.label_kcxh.Size = new System.Drawing.Size(53, 12);
            this.label_kcxh.TabIndex = 36;
            this.label_kcxh.Text = "考场序号";
            // 
            // comboBox_kskm
            // 
            this.comboBox_kskm.FormattingEnabled = true;
            this.comboBox_kskm.Items.AddRange(new object[] {
            "科目一",
            "科目二",
            "科目三"});
            this.comboBox_kskm.Location = new System.Drawing.Point(284, 10);
            this.comboBox_kskm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_kskm.Name = "comboBox_kskm";
            this.comboBox_kskm.Size = new System.Drawing.Size(75, 20);
            this.comboBox_kskm.TabIndex = 39;
            // 
            // textBox_kcxh
            // 
            this.textBox_kcxh.Location = new System.Drawing.Point(601, 9);
            this.textBox_kcxh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_kcxh.Name = "textBox_kcxh";
            this.textBox_kcxh.Size = new System.Drawing.Size(59, 21);
            this.textBox_kcxh.TabIndex = 37;
            // 
            // dataGridView_booking
            // 
            this.dataGridView_booking.AllowUserToAddRows = false;
            this.dataGridView_booking.AllowUserToDeleteRows = false;
            this.dataGridView_booking.AllowUserToResizeRows = false;
            this.dataGridView_booking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_booking.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_booking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_booking.EnableHeadersVisualStyles = false;
            this.dataGridView_booking.Location = new System.Drawing.Point(0, 41);
            this.dataGridView_booking.Name = "dataGridView_booking";
            this.dataGridView_booking.ReadOnly = true;
            this.dataGridView_booking.RowHeadersVisible = false;
            this.dataGridView_booking.RowTemplate.Height = 23;
            this.dataGridView_booking.Size = new System.Drawing.Size(1029, 426);
            this.dataGridView_booking.TabIndex = 9;
            this.dataGridView_booking.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_booking_CellDoubleClick);
            // 
            // Form_Booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 467);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView_booking);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Booking";
            this.Text = "预约及签到";
            this.Load += new System.EventHandler(this.Form_Booking_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_booking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.DataGridView dataGridView_booking;
        private System.Windows.Forms.TextBox textBox_kcxh;
        private System.Windows.Forms.Label label_kcxh;
        private System.Windows.Forms.ComboBox comboBox_kskm;
        private System.Windows.Forms.Label label_kskm;
        private System.Windows.Forms.Label label_ksrq;
        private System.Windows.Forms.TextBox textBox_sfzmhm;
        private System.Windows.Forms.Label label_sfzmhm;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ksrq;
        private System.Windows.Forms.Button button_CheckIn;
    }
}