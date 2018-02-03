namespace Client
{
    partial class Form_DBConfig
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
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_DBName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_DBAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "密码：";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(169, 137);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(160, 21);
            this.textBox_password.TabIndex = 20;
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(88, 189);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(75, 23);
            this.btn_test.TabIndex = 19;
            this.btn_test.Text = "测试连接";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(254, 189);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 18;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(173, 189);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 17;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // textBox_userName
            // 
            this.textBox_userName.Location = new System.Drawing.Point(169, 101);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(160, 21);
            this.textBox_userName.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "用户名：";
            // 
            // textBox_DBName
            // 
            this.textBox_DBName.Location = new System.Drawing.Point(169, 65);
            this.textBox_DBName.Name = "textBox_DBName";
            this.textBox_DBName.Size = new System.Drawing.Size(160, 21);
            this.textBox_DBName.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "数据库名称：";
            // 
            // textBox_DBAddress
            // 
            this.textBox_DBAddress.Location = new System.Drawing.Point(169, 29);
            this.textBox_DBAddress.Name = "textBox_DBAddress";
            this.textBox_DBAddress.Size = new System.Drawing.Size(160, 21);
            this.textBox_DBAddress.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "数据库地址：";
            // 
            // Form_DBConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(415, 224);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.textBox_userName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_DBName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_DBAddress);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_DBConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "";
            this.Text = "数据库连接设置";
            this.Load += new System.EventHandler(this.Form_DBConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_DBName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_DBAddress;
        private System.Windows.Forms.Label label1;
    }
}