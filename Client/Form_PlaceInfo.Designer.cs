namespace Client
{
    partial class Form_PlaceInfo
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
            this.dateTimePicker_gxsj = new System.Windows.Forms.DateTimePicker();
            this.comboBox_kskm = new System.Windows.Forms.ComboBox();
            this.label_gxsj = new System.Windows.Forms.Label();
            this.label_kskm = new System.Windows.Forms.Label();
            this.textBox_fzjg = new System.Windows.Forms.TextBox();
            this.label_fzjg = new System.Windows.Forms.Label();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_append = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_code = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_sequenceNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_place = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_place)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker_gxsj
            // 
            this.dateTimePicker_gxsj.Checked = false;
            this.dateTimePicker_gxsj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_gxsj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_gxsj.Location = new System.Drawing.Point(329, 13);
            this.dateTimePicker_gxsj.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker_gxsj.Name = "dateTimePicker_gxsj";
            this.dateTimePicker_gxsj.ShowCheckBox = true;
            this.dateTimePicker_gxsj.Size = new System.Drawing.Size(168, 21);
            this.dateTimePicker_gxsj.TabIndex = 28;
            // 
            // comboBox_kskm
            // 
            this.comboBox_kskm.FormattingEnabled = true;
            this.comboBox_kskm.Location = new System.Drawing.Point(178, 14);
            this.comboBox_kskm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_kskm.Name = "comboBox_kskm";
            this.comboBox_kskm.Size = new System.Drawing.Size(75, 20);
            this.comboBox_kskm.TabIndex = 27;
            // 
            // label_gxsj
            // 
            this.label_gxsj.AutoSize = true;
            this.label_gxsj.Location = new System.Drawing.Point(272, 17);
            this.label_gxsj.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_gxsj.Name = "label_gxsj";
            this.label_gxsj.Size = new System.Drawing.Size(53, 12);
            this.label_gxsj.TabIndex = 25;
            this.label_gxsj.Text = "更新时间";
            // 
            // label_kskm
            // 
            this.label_kskm.AutoSize = true;
            this.label_kskm.Location = new System.Drawing.Point(121, 17);
            this.label_kskm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_kskm.Name = "label_kskm";
            this.label_kskm.Size = new System.Drawing.Size(53, 12);
            this.label_kskm.TabIndex = 23;
            this.label_kskm.Text = "考试科目";
            // 
            // textBox_fzjg
            // 
            this.textBox_fzjg.Location = new System.Drawing.Point(65, 13);
            this.textBox_fzjg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_fzjg.Name = "textBox_fzjg";
            this.textBox_fzjg.Size = new System.Drawing.Size(45, 21);
            this.textBox_fzjg.TabIndex = 20;
            this.textBox_fzjg.Text = "苏B";
            // 
            // label_fzjg
            // 
            this.label_fzjg.AutoSize = true;
            this.label_fzjg.Location = new System.Drawing.Point(8, 17);
            this.label_fzjg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_fzjg.Name = "label_fzjg";
            this.label_fzjg.Size = new System.Drawing.Size(53, 12);
            this.label_fzjg.TabIndex = 19;
            this.label_fzjg.Text = "发证机关";
            // 
            // btn_download
            // 
            this.btn_download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_download.Location = new System.Drawing.Point(683, 10);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(75, 23);
            this.btn_download.TabIndex = 17;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // btn_append
            // 
            this.btn_append.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_append.Location = new System.Drawing.Point(763, 38);
            this.btn_append.Name = "btn_append";
            this.btn_append.Size = new System.Drawing.Size(75, 23);
            this.btn_append.TabIndex = 14;
            this.btn_append.Text = "添加";
            this.btn_append.UseVisualStyleBackColor = true;
            this.btn_append.Click += new System.EventHandler(this.btn_append_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_name);
            this.panel1.Controls.Add(this.textBox_code);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.dateTimePicker_gxsj);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox_kskm);
            this.panel1.Controls.Add(this.label_fzjg);
            this.panel1.Controls.Add(this.textBox_sequenceNumber);
            this.panel1.Controls.Add(this.btn_append);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label_gxsj);
            this.panel1.Controls.Add(this.btn_download);
            this.panel1.Controls.Add(this.label_kskm);
            this.panel1.Controls.Add(this.textBox_fzjg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 68);
            this.panel1.TabIndex = 12;
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(497, 40);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(121, 21);
            this.textBox_name.TabIndex = 10;
            // 
            // textBox_code
            // 
            this.textBox_code.Location = new System.Drawing.Point(288, 40);
            this.textBox_code.Name = "textBox_code";
            this.textBox_code.Size = new System.Drawing.Size(121, 21);
            this.textBox_code.TabIndex = 11;
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.Location = new System.Drawing.Point(763, 10);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 8;
            this.btn_search.Text = "检索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "考场名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "考场代码：";
            // 
            // textBox_sequenceNumber
            // 
            this.textBox_sequenceNumber.Location = new System.Drawing.Point(81, 40);
            this.textBox_sequenceNumber.Name = "textBox_sequenceNumber";
            this.textBox_sequenceNumber.Size = new System.Drawing.Size(121, 21);
            this.textBox_sequenceNumber.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "场地序号：";
            // 
            // dataGridView_place
            // 
            this.dataGridView_place.AllowUserToAddRows = false;
            this.dataGridView_place.AllowUserToDeleteRows = false;
            this.dataGridView_place.AllowUserToResizeRows = false;
            this.dataGridView_place.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_place.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_place.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_place.EnableHeadersVisualStyles = false;
            this.dataGridView_place.Location = new System.Drawing.Point(0, 68);
            this.dataGridView_place.Name = "dataGridView_place";
            this.dataGridView_place.ReadOnly = true;
            this.dataGridView_place.RowHeadersVisible = false;
            this.dataGridView_place.RowTemplate.Height = 23;
            this.dataGridView_place.Size = new System.Drawing.Size(851, 428);
            this.dataGridView_place.TabIndex = 13;
            this.dataGridView_place.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_place_CellDoubleClick);
            // 
            // Form_PlaceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 496);
            this.Controls.Add(this.dataGridView_place);
            this.Controls.Add(this.panel1);
            this.Name = "Form_PlaceInfo";
            this.Text = "场地信息";
            this.Load += new System.EventHandler(this.Form_PlaceInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_place)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_append;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_sequenceNumber;
        private System.Windows.Forms.TextBox textBox_code;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_place;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Label label_gxsj;
        private System.Windows.Forms.Label label_kskm;
        private System.Windows.Forms.TextBox textBox_fzjg;
        private System.Windows.Forms.Label label_fzjg;
        private System.Windows.Forms.ComboBox comboBox_kskm;
        private System.Windows.Forms.DateTimePicker dateTimePicker_gxsj;
    }
}