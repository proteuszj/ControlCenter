namespace Client
{
    partial class Form_Process
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.comboBox_driverType = new System.Windows.Forms.ComboBox();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_idNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView_students = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView_student = new System.Windows.Forms.DataGridView();
            this.dataGridView_processQuery = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_students)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_student)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_processQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 76);
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
            this.tableLayoutPanel1.Controls.Add(this.comboBox_driverType, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_status, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_name, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_idNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(802, 58);
            this.tableLayoutPanel1.TabIndex = 15;
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
            this.btn_search.Location = new System.Drawing.Point(724, 23);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 8;
            this.btn_search.Text = "检索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // comboBox_driverType
            // 
            this.comboBox_driverType.FormattingEnabled = true;
            this.comboBox_driverType.Location = new System.Drawing.Point(483, 23);
            this.comboBox_driverType.Name = "comboBox_driverType";
            this.comboBox_driverType.Size = new System.Drawing.Size(121, 20);
            this.comboBox_driverType.TabIndex = 13;
            // 
            // comboBox_status
            // 
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Location = new System.Drawing.Point(323, 23);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(121, 20);
            this.comboBox_status.TabIndex = 14;
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(3, 23);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(121, 21);
            this.textBox_name.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "驾驶证类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "身份证明号码：";
            // 
            // textBox_idNumber
            // 
            this.textBox_idNumber.Location = new System.Drawing.Point(163, 23);
            this.textBox_idNumber.MaxLength = 18;
            this.textBox_idNumber.Name = "textBox_idNumber";
            this.textBox_idNumber.Size = new System.Drawing.Size(121, 21);
            this.textBox_idNumber.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "状态：";
            // 
            // dataGridView_students
            // 
            this.dataGridView_students.AllowUserToAddRows = false;
            this.dataGridView_students.AllowUserToDeleteRows = false;
            this.dataGridView_students.AllowUserToResizeRows = false;
            this.dataGridView_students.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_students.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_students.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_students.EnableHeadersVisualStyles = false;
            this.dataGridView_students.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_students.Name = "dataGridView_students";
            this.dataGridView_students.ReadOnly = true;
            this.dataGridView_students.RowHeadersVisible = false;
            this.dataGridView_students.RowTemplate.Height = 23;
            this.dataGridView_students.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_students.Size = new System.Drawing.Size(826, 138);
            this.dataGridView_students.TabIndex = 7;
            this.dataGridView_students.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_students_CellClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 76);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView_students);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(826, 356);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 8;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView_student);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView_processQuery);
            this.splitContainer2.Size = new System.Drawing.Size(826, 214);
            this.splitContainer2.SplitterDistance = 419;
            this.splitContainer2.TabIndex = 9;
            // 
            // dataGridView_student
            // 
            this.dataGridView_student.AllowUserToAddRows = false;
            this.dataGridView_student.AllowUserToDeleteRows = false;
            this.dataGridView_student.AllowUserToResizeRows = false;
            this.dataGridView_student.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_student.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_student.EnableHeadersVisualStyles = false;
            this.dataGridView_student.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_student.Name = "dataGridView_student";
            this.dataGridView_student.ReadOnly = true;
            this.dataGridView_student.RowHeadersVisible = false;
            this.dataGridView_student.RowTemplate.Height = 23;
            this.dataGridView_student.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_student.Size = new System.Drawing.Size(419, 214);
            this.dataGridView_student.TabIndex = 8;
            this.dataGridView_student.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_student_CellClick);
            // 
            // dataGridView_processQuery
            // 
            this.dataGridView_processQuery.AllowUserToAddRows = false;
            this.dataGridView_processQuery.AllowUserToDeleteRows = false;
            this.dataGridView_processQuery.AllowUserToResizeRows = false;
            this.dataGridView_processQuery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_processQuery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_processQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_processQuery.EnableHeadersVisualStyles = false;
            this.dataGridView_processQuery.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_processQuery.Name = "dataGridView_processQuery";
            this.dataGridView_processQuery.ReadOnly = true;
            this.dataGridView_processQuery.RowHeadersVisible = false;
            this.dataGridView_processQuery.RowTemplate.Height = 23;
            this.dataGridView_processQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_processQuery.Size = new System.Drawing.Size(403, 214);
            this.dataGridView_processQuery.TabIndex = 10;
            // 
            // Form_Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 432);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Process";
            this.Text = "分析统计";
            this.Load += new System.EventHandler(this.Form_Student_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_students)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_student)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_processQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_idNumber;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.ComboBox comboBox_driverType;
        private System.Windows.Forms.DataGridView dataGridView_students;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView_student;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView_processQuery;
    }
}