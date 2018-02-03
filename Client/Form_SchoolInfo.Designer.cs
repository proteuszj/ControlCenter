namespace Client
{
    partial class Form_SchoolInfo
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
            this.panel10 = new System.Windows.Forms.Panel();
            this.dateTimePicker_gxsj = new System.Windows.Forms.DateTimePicker();
            this.textBox_gxsj = new System.Windows.Forms.TextBox();
            this.label_gxsj = new System.Windows.Forms.Label();
            this.textBox_fzjg = new System.Windows.Forms.TextBox();
            this.label_fzjg = new System.Windows.Forms.Label();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_school_append = new System.Windows.Forms.Button();
            this.dataGridView_school = new System.Windows.Forms.DataGridView();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_school)).BeginInit();
            this.SuspendLayout();
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.Control;
            this.panel10.Controls.Add(this.dateTimePicker_gxsj);
            this.panel10.Controls.Add(this.textBox_gxsj);
            this.panel10.Controls.Add(this.label_gxsj);
            this.panel10.Controls.Add(this.textBox_fzjg);
            this.panel10.Controls.Add(this.label_fzjg);
            this.panel10.Controls.Add(this.btn_download);
            this.panel10.Controls.Add(this.btn_school_append);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 416);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(821, 51);
            this.panel10.TabIndex = 1;
            // 
            // dateTimePicker_gxsj
            // 
            this.dateTimePicker_gxsj.Checked = false;
            this.dateTimePicker_gxsj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_gxsj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_gxsj.Location = new System.Drawing.Point(365, 18);
            this.dateTimePicker_gxsj.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_gxsj.Name = "dateTimePicker_gxsj";
            this.dateTimePicker_gxsj.ShowCheckBox = true;
            this.dateTimePicker_gxsj.Size = new System.Drawing.Size(152, 21);
            this.dateTimePicker_gxsj.TabIndex = 44;
            this.dateTimePicker_gxsj.ValueChanged += new System.EventHandler(this.dateTimePicker_gxsj_ValueChanged);
            // 
            // textBox_gxsj
            // 
            this.textBox_gxsj.Location = new System.Drawing.Point(237, 17);
            this.textBox_gxsj.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_gxsj.Name = "textBox_gxsj";
            this.textBox_gxsj.Size = new System.Drawing.Size(125, 21);
            this.textBox_gxsj.TabIndex = 43;
            // 
            // label_gxsj
            // 
            this.label_gxsj.AutoSize = true;
            this.label_gxsj.Location = new System.Drawing.Point(179, 21);
            this.label_gxsj.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_gxsj.Name = "label_gxsj";
            this.label_gxsj.Size = new System.Drawing.Size(53, 12);
            this.label_gxsj.TabIndex = 42;
            this.label_gxsj.Text = "更新时间";
            // 
            // textBox_fzjg
            // 
            this.textBox_fzjg.Location = new System.Drawing.Point(65, 17);
            this.textBox_fzjg.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_fzjg.Name = "textBox_fzjg";
            this.textBox_fzjg.Size = new System.Drawing.Size(86, 21);
            this.textBox_fzjg.TabIndex = 41;
            this.textBox_fzjg.Text = "苏B";
            // 
            // label_fzjg
            // 
            this.label_fzjg.AutoSize = true;
            this.label_fzjg.Location = new System.Drawing.Point(8, 21);
            this.label_fzjg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_fzjg.Name = "label_fzjg";
            this.label_fzjg.Size = new System.Drawing.Size(53, 12);
            this.label_fzjg.TabIndex = 40;
            this.label_fzjg.Text = "发证机关";
            // 
            // btn_download
            // 
            this.btn_download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_download.Enabled = false;
            this.btn_download.Location = new System.Drawing.Point(653, 16);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(75, 23);
            this.btn_download.TabIndex = 15;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // btn_school_append
            // 
            this.btn_school_append.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_school_append.Location = new System.Drawing.Point(734, 16);
            this.btn_school_append.Name = "btn_school_append";
            this.btn_school_append.Size = new System.Drawing.Size(75, 23);
            this.btn_school_append.TabIndex = 14;
            this.btn_school_append.Text = "添加";
            this.btn_school_append.UseVisualStyleBackColor = true;
            this.btn_school_append.Click += new System.EventHandler(this.btn_school_append_Click);
            // 
            // dataGridView_school
            // 
            this.dataGridView_school.AllowUserToAddRows = false;
            this.dataGridView_school.AllowUserToDeleteRows = false;
            this.dataGridView_school.AllowUserToResizeRows = false;
            this.dataGridView_school.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_school.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_school.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_school.EnableHeadersVisualStyles = false;
            this.dataGridView_school.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_school.Name = "dataGridView_school";
            this.dataGridView_school.ReadOnly = true;
            this.dataGridView_school.RowHeadersVisible = false;
            this.dataGridView_school.RowTemplate.Height = 23;
            this.dataGridView_school.Size = new System.Drawing.Size(821, 416);
            this.dataGridView_school.TabIndex = 13;
            this.dataGridView_school.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_school_CellDoubleClick);
            // 
            // Form_SchoolInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 467);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView_school);
            this.Controls.Add(this.panel10);
            this.Name = "Form_SchoolInfo";
            this.Text = "驾校信息";
            this.Load += new System.EventHandler(this.Form_SchoolInfo_Load);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_school)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btn_school_append;
        private System.Windows.Forms.DataGridView dataGridView_school;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.DateTimePicker dateTimePicker_gxsj;
        private System.Windows.Forms.TextBox textBox_gxsj;
        private System.Windows.Forms.Label label_gxsj;
        private System.Windows.Forms.TextBox textBox_fzjg;
        private System.Windows.Forms.Label label_fzjg;
    }
}