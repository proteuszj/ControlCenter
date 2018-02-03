namespace Client
{
    partial class Form_PlaceInfo_appendModify
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
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label74 = new System.Windows.Forms.Label();
            this.textBox_accepter = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.dateTimePicker_acceptanceDate = new System.Windows.Forms.DateTimePicker();
            this.label71 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.textBox_issuingAuthority = new System.Windows.Forms.TextBox();
            this.textBox_branchAdministration = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.comboBox_subject = new System.Windows.Forms.ComboBox();
            this.label79 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.textBox_code = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(683, 135);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 18;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Location = new System.Drawing.Point(764, 135);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 17;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(168, 60);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(53, 12);
            this.label74.TabIndex = 19;
            this.label74.Text = "验收人：";
            // 
            // textBox_accepter
            // 
            this.textBox_accepter.Location = new System.Drawing.Point(168, 83);
            this.textBox_accepter.Name = "textBox_accepter";
            this.textBox_accepter.Size = new System.Drawing.Size(123, 21);
            this.textBox_accepter.TabIndex = 35;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(3, 60);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(89, 12);
            this.label75.TabIndex = 18;
            this.label75.Text = "总队验收日期：";
            // 
            // dateTimePicker_acceptanceDate
            // 
            this.dateTimePicker_acceptanceDate.Location = new System.Drawing.Point(3, 83);
            this.dateTimePicker_acceptanceDate.Name = "dateTimePicker_acceptanceDate";
            this.dateTimePicker_acceptanceDate.Size = new System.Drawing.Size(123, 21);
            this.dateTimePicker_acceptanceDate.TabIndex = 27;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(498, 0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(65, 12);
            this.label71.TabIndex = 0;
            this.label71.Text = "发证机关：";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(663, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(65, 12);
            this.label70.TabIndex = 2;
            this.label70.Text = "管理部门：";
            // 
            // textBox_issuingAuthority
            // 
            this.textBox_issuingAuthority.Location = new System.Drawing.Point(498, 23);
            this.textBox_issuingAuthority.Name = "textBox_issuingAuthority";
            this.textBox_issuingAuthority.Size = new System.Drawing.Size(123, 21);
            this.textBox_issuingAuthority.TabIndex = 9;
            // 
            // textBox_branchAdministration
            // 
            this.textBox_branchAdministration.Location = new System.Drawing.Point(663, 23);
            this.textBox_branchAdministration.Name = "textBox_branchAdministration";
            this.textBox_branchAdministration.Size = new System.Drawing.Size(123, 21);
            this.textBox_branchAdministration.TabIndex = 9;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(333, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(65, 12);
            this.label80.TabIndex = 14;
            this.label80.Text = "考试科目：";
            // 
            // comboBox_subject
            // 
            this.comboBox_subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_subject.FormattingEnabled = true;
            this.comboBox_subject.Location = new System.Drawing.Point(333, 23);
            this.comboBox_subject.Name = "comboBox_subject";
            this.comboBox_subject.Size = new System.Drawing.Size(123, 20);
            this.comboBox_subject.TabIndex = 3;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(168, 0);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(65, 12);
            this.label79.TabIndex = 5;
            this.label79.Text = "考场名称：";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(168, 23);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(123, 21);
            this.textBox_name.TabIndex = 36;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(3, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(65, 12);
            this.label78.TabIndex = 15;
            this.label78.Text = "考场代码：";
            // 
            // textBox_code
            // 
            this.textBox_code.Location = new System.Drawing.Point(3, 23);
            this.textBox_code.Name = "textBox_code";
            this.textBox_code.Size = new System.Drawing.Size(123, 21);
            this.textBox_code.TabIndex = 37;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.ColumnCount = 5;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.Controls.Add(this.textBox_code, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.label78, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.textBox_name, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.label79, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.comboBox_subject, 2, 1);
            this.tableLayoutPanel8.Controls.Add(this.label80, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.textBox_branchAdministration, 4, 1);
            this.tableLayoutPanel8.Controls.Add(this.textBox_issuingAuthority, 3, 1);
            this.tableLayoutPanel8.Controls.Add(this.label70, 4, 0);
            this.tableLayoutPanel8.Controls.Add(this.label71, 3, 0);
            this.tableLayoutPanel8.Controls.Add(this.dateTimePicker_acceptanceDate, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.label75, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.textBox_accepter, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.label74, 1, 2);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 4;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(827, 117);
            this.tableLayoutPanel8.TabIndex = 16;
            // 
            // Form_PlaceInfo_appendModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 170);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.tableLayoutPanel8);
            this.Name = "Form_PlaceInfo_appendModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_PlaceInfo_appendModify";
            this.Load += new System.EventHandler(this.Form_PlaceInfo_appendModify_Load);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TextBox textBox_accepter;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.DateTimePicker dateTimePicker_acceptanceDate;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox textBox_issuingAuthority;
        private System.Windows.Forms.TextBox textBox_branchAdministration;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.ComboBox comboBox_subject;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.TextBox textBox_code;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
    }
}