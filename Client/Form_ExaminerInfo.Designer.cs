namespace Client
{
    partial class Form_ExaminerInfo
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
            this.panel11 = new System.Windows.Forms.Panel();
            this.dateTimePicker_gxsj = new System.Windows.Forms.DateTimePicker();
            this.textBox_gxsj = new System.Windows.Forms.TextBox();
            this.label_gxsj = new System.Windows.Forms.Label();
            this.textBox_glbm = new System.Windows.Forms.TextBox();
            this.label_glbm = new System.Windows.Forms.Label();
            this.textBox_fzjg = new System.Windows.Forms.TextBox();
            this.label_fzjg = new System.Windows.Forms.Label();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_examiner_append = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_idNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_archivesNumber = new System.Windows.Forms.TextBox();
            this.textBox_issuingOffice = new System.Windows.Forms.TextBox();
            this.dataGridView_examiner = new System.Windows.Forms.DataGridView();
            this.panel11.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_examiner)).BeginInit();
            this.SuspendLayout();
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.Control;
            this.panel11.Controls.Add(this.dateTimePicker_gxsj);
            this.panel11.Controls.Add(this.textBox_gxsj);
            this.panel11.Controls.Add(this.label_gxsj);
            this.panel11.Controls.Add(this.textBox_glbm);
            this.panel11.Controls.Add(this.label_glbm);
            this.panel11.Controls.Add(this.textBox_fzjg);
            this.panel11.Controls.Add(this.label_fzjg);
            this.panel11.Controls.Add(this.btn_download);
            this.panel11.Controls.Add(this.btn_examiner_append);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 455);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(818, 50);
            this.panel11.TabIndex = 2;
            // 
            // dateTimePicker_gxsj
            // 
            this.dateTimePicker_gxsj.Checked = false;
            this.dateTimePicker_gxsj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_gxsj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_gxsj.Location = new System.Drawing.Point(494, 17);
            this.dateTimePicker_gxsj.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker_gxsj.Name = "dateTimePicker_gxsj";
            this.dateTimePicker_gxsj.ShowCheckBox = true;
            this.dateTimePicker_gxsj.Size = new System.Drawing.Size(152, 21);
            this.dateTimePicker_gxsj.TabIndex = 39;
            this.dateTimePicker_gxsj.ValueChanged += new System.EventHandler(this.dateTimePicker_gxsj_ValueChanged);
            // 
            // textBox_gxsj
            // 
            this.textBox_gxsj.Location = new System.Drawing.Point(366, 17);
            this.textBox_gxsj.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_gxsj.Name = "textBox_gxsj";
            this.textBox_gxsj.Size = new System.Drawing.Size(125, 21);
            this.textBox_gxsj.TabIndex = 38;
            // 
            // label_gxsj
            // 
            this.label_gxsj.AutoSize = true;
            this.label_gxsj.Location = new System.Drawing.Point(309, 23);
            this.label_gxsj.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_gxsj.Name = "label_gxsj";
            this.label_gxsj.Size = new System.Drawing.Size(53, 12);
            this.label_gxsj.TabIndex = 37;
            this.label_gxsj.Text = "更新时间";
            // 
            // textBox_glbm
            // 
            this.textBox_glbm.Location = new System.Drawing.Point(202, 20);
            this.textBox_glbm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_glbm.Name = "textBox_glbm";
            this.textBox_glbm.Size = new System.Drawing.Size(89, 21);
            this.textBox_glbm.TabIndex = 20;
            this.textBox_glbm.Text = "320200000400";
            // 
            // label_glbm
            // 
            this.label_glbm.AutoSize = true;
            this.label_glbm.Location = new System.Drawing.Point(145, 23);
            this.label_glbm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_glbm.Name = "label_glbm";
            this.label_glbm.Size = new System.Drawing.Size(53, 12);
            this.label_glbm.TabIndex = 19;
            this.label_glbm.Text = "管理部门";
            // 
            // textBox_fzjg
            // 
            this.textBox_fzjg.Location = new System.Drawing.Point(67, 20);
            this.textBox_fzjg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_fzjg.Name = "textBox_fzjg";
            this.textBox_fzjg.Size = new System.Drawing.Size(66, 21);
            this.textBox_fzjg.TabIndex = 18;
            this.textBox_fzjg.Text = "苏B";
            // 
            // label_fzjg
            // 
            this.label_fzjg.AutoSize = true;
            this.label_fzjg.Location = new System.Drawing.Point(10, 23);
            this.label_fzjg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_fzjg.Name = "label_fzjg";
            this.label_fzjg.Size = new System.Drawing.Size(53, 12);
            this.label_fzjg.TabIndex = 17;
            this.label_fzjg.Text = "发证机关";
            // 
            // btn_download
            // 
            this.btn_download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_download.Location = new System.Drawing.Point(650, 15);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(75, 23);
            this.btn_download.TabIndex = 16;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // btn_examiner_append
            // 
            this.btn_examiner_append.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_examiner_append.Location = new System.Drawing.Point(731, 15);
            this.btn_examiner_append.Name = "btn_examiner_append";
            this.btn_examiner_append.Size = new System.Drawing.Size(75, 23);
            this.btn_examiner_append.TabIndex = 14;
            this.btn_examiner_append.Text = "添加";
            this.btn_examiner_append.UseVisualStyleBackColor = true;
            this.btn_examiner_append.Click += new System.EventHandler(this.btn_examiner_append_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 68);
            this.panel1.TabIndex = 6;
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
            this.tableLayoutPanel1.Controls.Add(this.textBox_name, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_idNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_archivesNumber, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_issuingOffice, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 50);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.Location = new System.Drawing.Point(716, 23);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 8;
            this.btn_search.Text = "检索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(3, 23);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(121, 21);
            this.textBox_name.TabIndex = 9;
            // 
            // textBox_idNumber
            // 
            this.textBox_idNumber.Location = new System.Drawing.Point(161, 23);
            this.textBox_idNumber.MaxLength = 18;
            this.textBox_idNumber.Name = "textBox_idNumber";
            this.textBox_idNumber.Size = new System.Drawing.Size(117, 21);
            this.textBox_idNumber.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "身份证明号码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(477, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "考试员证发证单位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "驾驶证档案编号：";
            // 
            // textBox_archivesNumber
            // 
            this.textBox_archivesNumber.Location = new System.Drawing.Point(319, 23);
            this.textBox_archivesNumber.Name = "textBox_archivesNumber";
            this.textBox_archivesNumber.Size = new System.Drawing.Size(121, 21);
            this.textBox_archivesNumber.TabIndex = 10;
            // 
            // textBox_issuingOffice
            // 
            this.textBox_issuingOffice.Location = new System.Drawing.Point(477, 23);
            this.textBox_issuingOffice.Name = "textBox_issuingOffice";
            this.textBox_issuingOffice.Size = new System.Drawing.Size(121, 21);
            this.textBox_issuingOffice.TabIndex = 11;
            // 
            // dataGridView_examiner
            // 
            this.dataGridView_examiner.AllowUserToAddRows = false;
            this.dataGridView_examiner.AllowUserToDeleteRows = false;
            this.dataGridView_examiner.AllowUserToResizeRows = false;
            this.dataGridView_examiner.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_examiner.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_examiner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_examiner.EnableHeadersVisualStyles = false;
            this.dataGridView_examiner.Location = new System.Drawing.Point(0, 68);
            this.dataGridView_examiner.Name = "dataGridView_examiner";
            this.dataGridView_examiner.ReadOnly = true;
            this.dataGridView_examiner.RowHeadersVisible = false;
            this.dataGridView_examiner.RowTemplate.Height = 23;
            this.dataGridView_examiner.Size = new System.Drawing.Size(818, 387);
            this.dataGridView_examiner.TabIndex = 7;
            this.dataGridView_examiner.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_examiner_CellDoubleClick);
            // 
            // Form_ExaminerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 505);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView_examiner);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel11);
            this.Name = "Form_ExaminerInfo";
            this.Text = "考试员信息";
            this.Load += new System.EventHandler(this.Form_ExaminerInfo_Load);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_examiner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btn_examiner_append;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_idNumber;
        private System.Windows.Forms.TextBox textBox_issuingOffice;
        private System.Windows.Forms.TextBox textBox_archivesNumber;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_examiner;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_glbm;
        private System.Windows.Forms.Label label_glbm;
        private System.Windows.Forms.TextBox textBox_fzjg;
        private System.Windows.Forms.Label label_fzjg;
        private System.Windows.Forms.DateTimePicker dateTimePicker_gxsj;
        private System.Windows.Forms.TextBox textBox_gxsj;
        private System.Windows.Forms.Label label_gxsj;
    }
}