namespace Client
{
    partial class Form_User
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Remove = new System.Windows.Forms.Button();
            this.btn_append = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_lockStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_idNumber = new System.Windows.Forms.TextBox();
            this.textBox_loginName = new System.Windows.Forms.TextBox();
            this.textBox_userNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.dataGridView_user = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.button_Remove);
            this.panel2.Controls.Add(this.btn_append);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 412);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 51);
            this.panel2.TabIndex = 3;
            // 
            // button_Remove
            // 
            this.button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Remove.Location = new System.Drawing.Point(780, 19);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(75, 23);
            this.button_Remove.TabIndex = 22;
            this.button_Remove.Text = "删除";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // btn_append
            // 
            this.btn_append.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_append.Location = new System.Drawing.Point(700, 19);
            this.btn_append.Name = "btn_append";
            this.btn_append.Size = new System.Drawing.Size(75, 23);
            this.btn_append.TabIndex = 21;
            this.btn_append.Text = "添加";
            this.btn_append.UseVisualStyleBackColor = true;
            this.btn_append.Click += new System.EventHandler(this.btn_append_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "登录名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户姓名：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 78);
            this.panel1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.01191F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.09134F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.74106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.22161F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.48451F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.76727F));
            this.tableLayoutPanel1.Controls.Add(this.comboBox_lockStatus, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_idNumber, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_loginName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_userNumber, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_search, 5, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(839, 60);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // comboBox_lockStatus
            // 
            this.comboBox_lockStatus.FormattingEnabled = true;
            this.comboBox_lockStatus.Location = new System.Drawing.Point(528, 23);
            this.comboBox_lockStatus.Name = "comboBox_lockStatus";
            this.comboBox_lockStatus.Size = new System.Drawing.Size(81, 20);
            this.comboBox_lockStatus.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(528, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "锁定状态：";
            // 
            // textBox_idNumber
            // 
            this.textBox_idNumber.Location = new System.Drawing.Point(368, 23);
            this.textBox_idNumber.MaxLength = 18;
            this.textBox_idNumber.Name = "textBox_idNumber";
            this.textBox_idNumber.Size = new System.Drawing.Size(154, 21);
            this.textBox_idNumber.TabIndex = 12;
            // 
            // textBox_loginName
            // 
            this.textBox_loginName.Location = new System.Drawing.Point(3, 23);
            this.textBox_loginName.Name = "textBox_loginName";
            this.textBox_loginName.Size = new System.Drawing.Size(119, 21);
            this.textBox_loginName.TabIndex = 9;
            // 
            // textBox_userNumber
            // 
            this.textBox_userNumber.Location = new System.Drawing.Point(254, 23);
            this.textBox_userNumber.Name = "textBox_userNumber";
            this.textBox_userNumber.Size = new System.Drawing.Size(108, 21);
            this.textBox_userNumber.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "身份证明号码：";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(128, 23);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(120, 21);
            this.textBox_name.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "用户编号：";
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.Location = new System.Drawing.Point(761, 23);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 8;
            this.btn_search.Text = "检索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dataGridView_user
            // 
            this.dataGridView_user.AllowUserToAddRows = false;
            this.dataGridView_user.AllowUserToDeleteRows = false;
            this.dataGridView_user.AllowUserToResizeRows = false;
            this.dataGridView_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_user.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_user.EnableHeadersVisualStyles = false;
            this.dataGridView_user.Location = new System.Drawing.Point(0, 78);
            this.dataGridView_user.Name = "dataGridView_user";
            this.dataGridView_user.ReadOnly = true;
            this.dataGridView_user.RowHeadersVisible = false;
            this.dataGridView_user.RowTemplate.Height = 23;
            this.dataGridView_user.Size = new System.Drawing.Size(863, 334);
            this.dataGridView_user.TabIndex = 6;
            this.dataGridView_user.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_user_CellDoubleClick);
            // 
            // Form_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 463);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView_user);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form_User";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.Form_User_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_append;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_user;
        private System.Windows.Forms.TextBox textBox_idNumber;
        private System.Windows.Forms.TextBox textBox_userNumber;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_loginName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox_lockStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Remove;
    }
}