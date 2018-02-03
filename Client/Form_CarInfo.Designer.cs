namespace Client
{
    partial class Form_CarInfo
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
            this.btn_car_append = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.comboBox_subject = new System.Windows.Forms.ComboBox();
            this.textBox_sequenceNumber = new System.Windows.Forms.TextBox();
            this.textBox_licensePlate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_carNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePicker_gxsj = new System.Windows.Forms.DateTimePicker();
            this.textBox_gxsj = new System.Windows.Forms.TextBox();
            this.label_gxsj = new System.Windows.Forms.Label();
            this.textBox_kcxh = new System.Windows.Forms.TextBox();
            this.label_kcxh = new System.Windows.Forms.Label();
            this.textBox_glbm = new System.Windows.Forms.TextBox();
            this.label_glbm = new System.Windows.Forms.Label();
            this.textBox_fzjg = new System.Windows.Forms.TextBox();
            this.label_fzjg = new System.Windows.Forms.Label();
            this.btn_download = new System.Windows.Forms.Button();
            this.dataGridView_car = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_car)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_car_append
            // 
            this.btn_car_append.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_car_append.Location = new System.Drawing.Point(705, 39);
            this.btn_car_append.Name = "btn_car_append";
            this.btn_car_append.Size = new System.Drawing.Size(75, 23);
            this.btn_car_append.TabIndex = 9;
            this.btn_car_append.Text = "添加";
            this.btn_car_append.UseVisualStyleBackColor = true;
            this.btn_car_append.Click += new System.EventHandler(this.btn_car_append_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 71);
            this.panel1.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_search, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_subject, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_sequenceNumber, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_licensePlate, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_carNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(768, 53);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "车辆序号：";
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.Location = new System.Drawing.Point(690, 23);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 8;
            this.btn_search.Text = "检索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // comboBox_subject
            // 
            this.comboBox_subject.FormattingEnabled = true;
            this.comboBox_subject.Location = new System.Drawing.Point(462, 23);
            this.comboBox_subject.Name = "comboBox_subject";
            this.comboBox_subject.Size = new System.Drawing.Size(121, 20);
            this.comboBox_subject.TabIndex = 12;
            // 
            // textBox_sequenceNumber
            // 
            this.textBox_sequenceNumber.Location = new System.Drawing.Point(3, 23);
            this.textBox_sequenceNumber.Name = "textBox_sequenceNumber";
            this.textBox_sequenceNumber.Size = new System.Drawing.Size(121, 21);
            this.textBox_sequenceNumber.TabIndex = 9;
            // 
            // textBox_licensePlate
            // 
            this.textBox_licensePlate.Location = new System.Drawing.Point(309, 23);
            this.textBox_licensePlate.Name = "textBox_licensePlate";
            this.textBox_licensePlate.Size = new System.Drawing.Size(121, 21);
            this.textBox_licensePlate.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(462, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "考试科目：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "车辆编号：";
            // 
            // textBox_carNumber
            // 
            this.textBox_carNumber.Location = new System.Drawing.Point(156, 23);
            this.textBox_carNumber.Name = "textBox_carNumber";
            this.textBox_carNumber.Size = new System.Drawing.Size(121, 21);
            this.textBox_carNumber.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "车辆号牌号码：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePicker_gxsj);
            this.panel2.Controls.Add(this.textBox_gxsj);
            this.panel2.Controls.Add(this.label_gxsj);
            this.panel2.Controls.Add(this.textBox_kcxh);
            this.panel2.Controls.Add(this.label_kcxh);
            this.panel2.Controls.Add(this.textBox_glbm);
            this.panel2.Controls.Add(this.label_glbm);
            this.panel2.Controls.Add(this.textBox_fzjg);
            this.panel2.Controls.Add(this.label_fzjg);
            this.panel2.Controls.Add(this.btn_download);
            this.panel2.Controls.Add(this.btn_car_append);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 468);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 75);
            this.panel2.TabIndex = 11;
            // 
            // dateTimePicker_gxsj
            // 
            this.dateTimePicker_gxsj.Checked = false;
            this.dateTimePicker_gxsj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_gxsj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_gxsj.Location = new System.Drawing.Point(605, 13);
            this.dateTimePicker_gxsj.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker_gxsj.Name = "dateTimePicker_gxsj";
            this.dateTimePicker_gxsj.ShowCheckBox = true;
            this.dateTimePicker_gxsj.Size = new System.Drawing.Size(152, 21);
            this.dateTimePicker_gxsj.TabIndex = 36;
            this.dateTimePicker_gxsj.ValueChanged += new System.EventHandler(this.dateTimePicker_gxsj_ValueChanged);
            // 
            // textBox_gxsj
            // 
            this.textBox_gxsj.Location = new System.Drawing.Point(477, 13);
            this.textBox_gxsj.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_gxsj.Name = "textBox_gxsj";
            this.textBox_gxsj.Size = new System.Drawing.Size(125, 21);
            this.textBox_gxsj.TabIndex = 35;
            // 
            // label_gxsj
            // 
            this.label_gxsj.AutoSize = true;
            this.label_gxsj.Location = new System.Drawing.Point(419, 17);
            this.label_gxsj.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_gxsj.Name = "label_gxsj";
            this.label_gxsj.Size = new System.Drawing.Size(53, 12);
            this.label_gxsj.TabIndex = 34;
            this.label_gxsj.Text = "更新时间";
            // 
            // textBox_kcxh
            // 
            this.textBox_kcxh.Location = new System.Drawing.Point(315, 13);
            this.textBox_kcxh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_kcxh.Name = "textBox_kcxh";
            this.textBox_kcxh.Size = new System.Drawing.Size(97, 21);
            this.textBox_kcxh.TabIndex = 16;
            this.textBox_kcxh.Text = "32000647";
            // 
            // label_kcxh
            // 
            this.label_kcxh.AutoSize = true;
            this.label_kcxh.Location = new System.Drawing.Point(257, 15);
            this.label_kcxh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_kcxh.Name = "label_kcxh";
            this.label_kcxh.Size = new System.Drawing.Size(53, 12);
            this.label_kcxh.TabIndex = 15;
            this.label_kcxh.Text = "考场序号";
            // 
            // textBox_glbm
            // 
            this.textBox_glbm.Location = new System.Drawing.Point(166, 13);
            this.textBox_glbm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_glbm.Name = "textBox_glbm";
            this.textBox_glbm.Size = new System.Drawing.Size(89, 21);
            this.textBox_glbm.TabIndex = 14;
            this.textBox_glbm.Text = "320200000400";
            // 
            // label_glbm
            // 
            this.label_glbm.AutoSize = true;
            this.label_glbm.Location = new System.Drawing.Point(109, 15);
            this.label_glbm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_glbm.Name = "label_glbm";
            this.label_glbm.Size = new System.Drawing.Size(53, 12);
            this.label_glbm.TabIndex = 13;
            this.label_glbm.Text = "管理部门";
            // 
            // textBox_fzjg
            // 
            this.textBox_fzjg.Location = new System.Drawing.Point(65, 13);
            this.textBox_fzjg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_fzjg.Name = "textBox_fzjg";
            this.textBox_fzjg.Size = new System.Drawing.Size(41, 21);
            this.textBox_fzjg.TabIndex = 12;
            this.textBox_fzjg.Text = "苏B";
            // 
            // label_fzjg
            // 
            this.label_fzjg.AutoSize = true;
            this.label_fzjg.Location = new System.Drawing.Point(8, 15);
            this.label_fzjg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_fzjg.Name = "label_fzjg";
            this.label_fzjg.Size = new System.Drawing.Size(53, 12);
            this.label_fzjg.TabIndex = 11;
            this.label_fzjg.Text = "发证机关";
            // 
            // btn_download
            // 
            this.btn_download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_download.Location = new System.Drawing.Point(624, 39);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(75, 23);
            this.btn_download.TabIndex = 10;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
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
            this.dataGridView_car.Location = new System.Drawing.Point(0, 71);
            this.dataGridView_car.Name = "dataGridView_car";
            this.dataGridView_car.ReadOnly = true;
            this.dataGridView_car.RowHeadersVisible = false;
            this.dataGridView_car.RowTemplate.Height = 23;
            this.dataGridView_car.Size = new System.Drawing.Size(792, 397);
            this.dataGridView_car.TabIndex = 12;
            this.dataGridView_car.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_car_CellDoubleClick);
            // 
            // Form_CarInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 543);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView_car);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_CarInfo";
            this.Text = "车辆信息";
            this.Load += new System.EventHandler(this.Form_CarInfo_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_car)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_car_append;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_licensePlate;
        private System.Windows.Forms.TextBox textBox_carNumber;
        private System.Windows.Forms.TextBox textBox_sequenceNumber;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_car;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.ComboBox comboBox_subject;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_kcxh;
        private System.Windows.Forms.Label label_kcxh;
        private System.Windows.Forms.TextBox textBox_glbm;
        private System.Windows.Forms.Label label_glbm;
        private System.Windows.Forms.TextBox textBox_fzjg;
        private System.Windows.Forms.Label label_fzjg;
        private System.Windows.Forms.DateTimePicker dateTimePicker_gxsj;
        private System.Windows.Forms.TextBox textBox_gxsj;
        private System.Windows.Forms.Label label_gxsj;
    }
}