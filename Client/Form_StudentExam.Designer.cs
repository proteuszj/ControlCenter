namespace Client
{
    partial class Form_StudentExam
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_studentExam = new System.Windows.Forms.DataGridView();
            this.dataGridView_examProcess = new System.Windows.Forms.DataGridView();
            this.dataGridView_SUB2 = new System.Windows.Forms.DataGridView();
            this.panel_Filter = new System.Windows.Forms.Panel();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label_ID = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.label_Status = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.button_Score = new System.Windows.Forms.Button();
            this.button_misjudge = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button_all = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_studentExam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_examProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SUB2)).BeginInit();
            this.panel_Filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_studentExam
            // 
            this.dataGridView_studentExam.AllowUserToAddRows = false;
            this.dataGridView_studentExam.AllowUserToDeleteRows = false;
            this.dataGridView_studentExam.AllowUserToResizeRows = false;
            this.dataGridView_studentExam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_studentExam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_studentExam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_studentExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_studentExam.EnableHeadersVisualStyles = false;
            this.dataGridView_studentExam.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_studentExam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_studentExam.MultiSelect = false;
            this.dataGridView_studentExam.Name = "dataGridView_studentExam";
            this.dataGridView_studentExam.ReadOnly = true;
            this.dataGridView_studentExam.RowHeadersVisible = false;
            this.dataGridView_studentExam.RowTemplate.Height = 30;
            this.dataGridView_studentExam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_studentExam.Size = new System.Drawing.Size(173, 253);
            this.dataGridView_studentExam.TabIndex = 0;
            this.dataGridView_studentExam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_studentExam_CellClick);
            // 
            // dataGridView_examProcess
            // 
            this.dataGridView_examProcess.AllowUserToAddRows = false;
            this.dataGridView_examProcess.AllowUserToDeleteRows = false;
            this.dataGridView_examProcess.AllowUserToResizeRows = false;
            this.dataGridView_examProcess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_examProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_examProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_examProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_examProcess.EnableHeadersVisualStyles = false;
            this.dataGridView_examProcess.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_examProcess.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_examProcess.MultiSelect = false;
            this.dataGridView_examProcess.Name = "dataGridView_examProcess";
            this.dataGridView_examProcess.ReadOnly = true;
            this.dataGridView_examProcess.RowHeadersVisible = false;
            this.dataGridView_examProcess.RowTemplate.Height = 30;
            this.dataGridView_examProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_examProcess.Size = new System.Drawing.Size(675, 253);
            this.dataGridView_examProcess.TabIndex = 0;
            // 
            // dataGridView_SUB2
            // 
            this.dataGridView_SUB2.AllowUserToAddRows = false;
            this.dataGridView_SUB2.AllowUserToDeleteRows = false;
            this.dataGridView_SUB2.AllowUserToResizeRows = false;
            this.dataGridView_SUB2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_SUB2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_SUB2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_SUB2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SUB2.EnableHeadersVisualStyles = false;
            this.dataGridView_SUB2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_SUB2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_SUB2.MultiSelect = false;
            this.dataGridView_SUB2.Name = "dataGridView_SUB2";
            this.dataGridView_SUB2.ReadOnly = true;
            this.dataGridView_SUB2.RowHeadersVisible = false;
            this.dataGridView_SUB2.RowTemplate.Height = 30;
            this.dataGridView_SUB2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SUB2.Size = new System.Drawing.Size(851, 181);
            this.dataGridView_SUB2.TabIndex = 0;
            this.dataGridView_SUB2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_SUB2_CellDoubleClick);
            // 
            // panel_Filter
            // 
            this.panel_Filter.Controls.Add(this.textBox_ID);
            this.panel_Filter.Controls.Add(this.label_ID);
            this.panel_Filter.Controls.Add(this.textBox_Name);
            this.panel_Filter.Controls.Add(this.label_Name);
            this.panel_Filter.Controls.Add(this.comboBox_Status);
            this.panel_Filter.Controls.Add(this.label_Status);
            this.panel_Filter.Controls.Add(this.button_search);
            this.panel_Filter.Controls.Add(this.button_Score);
            this.panel_Filter.Controls.Add(this.button_misjudge);
            this.panel_Filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Filter.Location = new System.Drawing.Point(0, 0);
            this.panel_Filter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_Filter.Name = "panel_Filter";
            this.panel_Filter.Size = new System.Drawing.Size(851, 41);
            this.panel_Filter.TabIndex = 0;
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(377, 8);
            this.textBox_ID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(153, 21);
            this.textBox_ID.TabIndex = 5;
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(283, 10);
            this.label_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(89, 12);
            this.label_ID.TabIndex = 4;
            this.label_ID.Text = "身份证明号码：";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(190, 8);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(68, 21);
            this.textBox_Name.TabIndex = 3;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(145, 10);
            this.label_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(41, 12);
            this.label_Name.TabIndex = 2;
            this.label_Name.Text = "姓名：";
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.Items.AddRange(new object[] {
            "合格",
            "不合格",
            "未完成",
            "待考"});
            this.comboBox_Status.Location = new System.Drawing.Point(53, 8);
            this.comboBox_Status.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(73, 20);
            this.comboBox_Status.TabIndex = 1;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(8, 10);
            this.label_Status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(41, 12);
            this.label_Status.TabIndex = 0;
            this.label_Status.Text = "状态：";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(542, 8);
            this.button_search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(65, 25);
            this.button_search.TabIndex = 6;
            this.button_search.Text = "检索";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_Score
            // 
            this.button_Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Score.Enabled = false;
            this.button_Score.Location = new System.Drawing.Point(777, 8);
            this.button_Score.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Score.Name = "button_Score";
            this.button_Score.Size = new System.Drawing.Size(65, 25);
            this.button_Score.TabIndex = 8;
            this.button_Score.Text = "成绩单";
            this.button_Score.UseVisualStyleBackColor = true;
            this.button_Score.Click += new System.EventHandler(this.button_print_Click);
            // 
            // button_misjudge
            // 
            this.button_misjudge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_misjudge.Enabled = false;
            this.button_misjudge.Location = new System.Drawing.Point(708, 8);
            this.button_misjudge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_misjudge.Name = "button_misjudge";
            this.button_misjudge.Size = new System.Drawing.Size(65, 25);
            this.button_misjudge.TabIndex = 7;
            this.button_misjudge.Text = "误判处理";
            this.button_misjudge.UseVisualStyleBackColor = true;
            this.button_misjudge.Click += new System.EventHandler(this.button_misjudge_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 41);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button_all);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_SUB2);
            this.splitContainer1.Size = new System.Drawing.Size(851, 474);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView_studentExam);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView_examProcess);
            this.splitContainer2.Size = new System.Drawing.Size(851, 253);
            this.splitContainer2.SplitterDistance = 173;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 2;
            // 
            // button_all
            // 
            this.button_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_all.Location = new System.Drawing.Point(777, 185);
            this.button_all.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_all.Name = "button_all";
            this.button_all.Size = new System.Drawing.Size(65, 25);
            this.button_all.TabIndex = 1;
            this.button_all.Text = "显示全部";
            this.button_all.UseVisualStyleBackColor = true;
            this.button_all.Click += new System.EventHandler(this.button_all_Click);
            // 
            // Form_StudentExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 515);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel_Filter);
            this.Name = "Form_StudentExam";
            this.Text = "成绩打印";
            this.Load += new System.EventHandler(this.Form_StudentScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_studentExam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_examProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SUB2)).EndInit();
            this.panel_Filter.ResumeLayout(false);
            this.panel_Filter.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_studentExam;
        private System.Windows.Forms.DataGridView dataGridView_examProcess;
        private System.Windows.Forms.DataGridView dataGridView_SUB2;
        private System.Windows.Forms.Panel panel_Filter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button_Score;
        private System.Windows.Forms.Button button_misjudge;
        private System.Windows.Forms.Button button_all;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.ComboBox comboBox_Status;
        private System.Windows.Forms.Label label_Status;
    }
}