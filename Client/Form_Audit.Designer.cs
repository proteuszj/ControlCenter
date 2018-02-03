namespace Client
{
    partial class Form_Audit
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_Filter = new System.Windows.Forms.Panel();
            this.button_Query = new System.Windows.Forms.Button();
            this.comboBox_Action = new System.Windows.Forms.ComboBox();
            this.label_Action = new System.Windows.Forms.Label();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.label_End = new System.Windows.Forms.Label();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.label_Start = new System.Windows.Forms.Label();
            this.dataGridView_AuditQuery = new System.Windows.Forms.DataGridView();
            this.panel_Filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AuditQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Filter
            // 
            this.panel_Filter.Controls.Add(this.button_Query);
            this.panel_Filter.Controls.Add(this.comboBox_Action);
            this.panel_Filter.Controls.Add(this.label_Action);
            this.panel_Filter.Controls.Add(this.dateTimePicker_End);
            this.panel_Filter.Controls.Add(this.label_End);
            this.panel_Filter.Controls.Add(this.dateTimePicker_Start);
            this.panel_Filter.Controls.Add(this.label_Start);
            this.panel_Filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Filter.Location = new System.Drawing.Point(0, 0);
            this.panel_Filter.Name = "panel_Filter";
            this.panel_Filter.Size = new System.Drawing.Size(1157, 84);
            this.panel_Filter.TabIndex = 0;
            // 
            // button_Query
            // 
            this.button_Query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Query.Location = new System.Drawing.Point(1070, 35);
            this.button_Query.Name = "button_Query";
            this.button_Query.Size = new System.Drawing.Size(75, 23);
            this.button_Query.TabIndex = 6;
            this.button_Query.Text = "检索";
            this.button_Query.UseVisualStyleBackColor = true;
            this.button_Query.Click += new System.EventHandler(this.button_Query_Click);
            // 
            // comboBox_Action
            // 
            this.comboBox_Action.FormattingEnabled = true;
            this.comboBox_Action.Items.AddRange(new object[] {
            "SELECT",
            "UPDATE",
            "INSERT",
            "DELETE",
            "DROP",
            "ALTER",
            "EXECUTE PROCEDURE"});
            this.comboBox_Action.Location = new System.Drawing.Point(771, 32);
            this.comboBox_Action.Name = "comboBox_Action";
            this.comboBox_Action.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Action.TabIndex = 5;
            // 
            // label_Action
            // 
            this.label_Action.AutoSize = true;
            this.label_Action.Location = new System.Drawing.Point(703, 37);
            this.label_Action.Name = "label_Action";
            this.label_Action.Size = new System.Drawing.Size(41, 12);
            this.label_Action.TabIndex = 4;
            this.label_Action.Text = "操作：";
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_End.Location = new System.Drawing.Point(465, 30);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker_End.TabIndex = 3;
            // 
            // label_End
            // 
            this.label_End.AutoSize = true;
            this.label_End.Location = new System.Drawing.Point(361, 37);
            this.label_End.Name = "label_End";
            this.label_End.Size = new System.Drawing.Size(65, 12);
            this.label_End.TabIndex = 2;
            this.label_End.Text = "结束时间：";
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Start.Location = new System.Drawing.Point(133, 30);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker_Start.TabIndex = 1;
            // 
            // label_Start
            // 
            this.label_Start.AutoSize = true;
            this.label_Start.Location = new System.Drawing.Point(29, 37);
            this.label_Start.Name = "label_Start";
            this.label_Start.Size = new System.Drawing.Size(65, 12);
            this.label_Start.TabIndex = 0;
            this.label_Start.Text = "开始时间：";
            // 
            // dataGridView_AuditQuery
            // 
            this.dataGridView_AuditQuery.AllowUserToAddRows = false;
            this.dataGridView_AuditQuery.AllowUserToDeleteRows = false;
            this.dataGridView_AuditQuery.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_AuditQuery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_AuditQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_AuditQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_AuditQuery.EnableHeadersVisualStyles = false;
            this.dataGridView_AuditQuery.Location = new System.Drawing.Point(0, 84);
            this.dataGridView_AuditQuery.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_AuditQuery.MultiSelect = false;
            this.dataGridView_AuditQuery.Name = "dataGridView_AuditQuery";
            this.dataGridView_AuditQuery.ReadOnly = true;
            this.dataGridView_AuditQuery.RowHeadersVisible = false;
            this.dataGridView_AuditQuery.RowTemplate.Height = 23;
            this.dataGridView_AuditQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_AuditQuery.Size = new System.Drawing.Size(1157, 622);
            this.dataGridView_AuditQuery.TabIndex = 8;
            // 
            // Form_Audit
            // 
            this.ClientSize = new System.Drawing.Size(1157, 706);
            this.Controls.Add(this.dataGridView_AuditQuery);
            this.Controls.Add(this.panel_Filter);
            this.Name = "Form_Audit";
            this.Text = "审计查询";
            this.panel_Filter.ResumeLayout(false);
            this.panel_Filter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AuditQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Filter;
        private System.Windows.Forms.DataGridView dataGridView_AuditQuery;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.Label label_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private System.Windows.Forms.Label label_Start;
        private System.Windows.Forms.Button button_Query;
        private System.Windows.Forms.ComboBox comboBox_Action;
        private System.Windows.Forms.Label label_Action;
    }
}
