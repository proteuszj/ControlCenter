namespace Client
{
    partial class Form_Password
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
            this.textBox_newPassword2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_newPassword1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_oldPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label_hint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_newPassword2
            // 
            this.textBox_newPassword2.Location = new System.Drawing.Point(154, 86);
            this.textBox_newPassword2.Name = "textBox_newPassword2";
            this.textBox_newPassword2.PasswordChar = '*';
            this.textBox_newPassword2.Size = new System.Drawing.Size(160, 21);
            this.textBox_newPassword2.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "确认密码：";
            // 
            // textBox_newPassword1
            // 
            this.textBox_newPassword1.Location = new System.Drawing.Point(154, 59);
            this.textBox_newPassword1.Name = "textBox_newPassword1";
            this.textBox_newPassword1.PasswordChar = '*';
            this.textBox_newPassword1.Size = new System.Drawing.Size(160, 21);
            this.textBox_newPassword1.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "新密码：";
            // 
            // textBox_oldPassword
            // 
            this.textBox_oldPassword.Location = new System.Drawing.Point(154, 32);
            this.textBox_oldPassword.Name = "textBox_oldPassword";
            this.textBox_oldPassword.PasswordChar = '*';
            this.textBox_oldPassword.Size = new System.Drawing.Size(160, 21);
            this.textBox_oldPassword.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "旧密码：";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(85, 141);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 18;
            this.btn_ok.Text = "确认";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(239, 141);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 19;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label_hint
            // 
            this.label_hint.ForeColor = System.Drawing.Color.Red;
            this.label_hint.Location = new System.Drawing.Point(12, 110);
            this.label_hint.Name = "label_hint";
            this.label_hint.Size = new System.Drawing.Size(380, 19);
            this.label_hint.TabIndex = 20;
            this.label_hint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_Password
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(404, 176);
            this.ControlBox = false;
            this.Controls.Add(this.label_hint);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.textBox_newPassword2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_newPassword1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_oldPassword);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Password";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "密码修改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_newPassword2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_newPassword1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_oldPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label_hint;
    }
}