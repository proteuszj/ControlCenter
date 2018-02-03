namespace Client
{
    partial class Form_Student_appendModify
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.comboBox_gender = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox_idType = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_idNumber = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBox_driverLicenseType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox_old = new System.Windows.Forms.PictureBox();
            this.pictureBox_new = new System.Windows.Forms.PictureBox();
            this.button_downloadPhoto = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_schoolName = new System.Windows.Forms.ComboBox();
            this.button_readCard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_old)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_new)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Location = new System.Drawing.Point(199, 307);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 26;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(118, 307);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 25;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(55, 3);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(79, 21);
            this.textBox_name.TabIndex = 1;
            // 
            // comboBox_gender
            // 
            this.comboBox_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_gender.FormattingEnabled = true;
            this.comboBox_gender.Location = new System.Drawing.Point(187, 4);
            this.comboBox_gender.Name = "comboBox_gender";
            this.comboBox_gender.Size = new System.Drawing.Size(62, 20);
            this.comboBox_gender.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "姓名：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(140, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "性别：";
            // 
            // comboBox_idType
            // 
            this.comboBox_idType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_idType.FormattingEnabled = true;
            this.comboBox_idType.Location = new System.Drawing.Point(103, 57);
            this.comboBox_idType.Name = "comboBox_idType";
            this.comboBox_idType.Size = new System.Drawing.Size(146, 20);
            this.comboBox_idType.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 12);
            this.label16.TabIndex = 4;
            this.label16.Text = "身份证明类型：";
            // 
            // textBox_idNumber
            // 
            this.textBox_idNumber.Location = new System.Drawing.Point(103, 83);
            this.textBox_idNumber.MaxLength = 18;
            this.textBox_idNumber.Name = "textBox_idNumber";
            this.textBox_idNumber.Size = new System.Drawing.Size(146, 21);
            this.textBox_idNumber.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 87);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 12);
            this.label17.TabIndex = 5;
            this.label17.Text = "身份证明号码：";
            // 
            // comboBox_driverLicenseType
            // 
            this.comboBox_driverLicenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_driverLicenseType.FormattingEnabled = true;
            this.comboBox_driverLicenseType.Location = new System.Drawing.Point(103, 110);
            this.comboBox_driverLicenseType.Name = "comboBox_driverLicenseType";
            this.comboBox_driverLicenseType.Size = new System.Drawing.Size(146, 20);
            this.comboBox_driverLicenseType.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "驾驶证类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "驾校名称：";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(103, 30);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(146, 21);
            this.textBox_password.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 33);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 6;
            this.label18.Text = "密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "照片（老）：";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "照片（新）：";
            this.label4.Visible = false;
            // 
            // pictureBox_old
            // 
            this.pictureBox_old.Location = new System.Drawing.Point(10, 183);
            this.pictureBox_old.Name = "pictureBox_old";
            this.pictureBox_old.Size = new System.Drawing.Size(77, 92);
            this.pictureBox_old.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_old.TabIndex = 31;
            this.pictureBox_old.TabStop = false;
            this.pictureBox_old.Visible = false;
            // 
            // pictureBox_new
            // 
            this.pictureBox_new.Location = new System.Drawing.Point(172, 183);
            this.pictureBox_new.Name = "pictureBox_new";
            this.pictureBox_new.Size = new System.Drawing.Size(77, 92);
            this.pictureBox_new.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_new.TabIndex = 32;
            this.pictureBox_new.TabStop = false;
            this.pictureBox_new.Visible = false;
            // 
            // button_downloadPhoto
            // 
            this.button_downloadPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_downloadPhoto.Location = new System.Drawing.Point(12, 307);
            this.button_downloadPhoto.Name = "button_downloadPhoto";
            this.button_downloadPhoto.Size = new System.Drawing.Size(75, 23);
            this.button_downloadPhoto.TabIndex = 28;
            this.button_downloadPhoto.Text = "下载照片";
            this.button_downloadPhoto.UseVisualStyleBackColor = true;
            this.button_downloadPhoto.Visible = false;
            this.button_downloadPhoto.Click += new System.EventHandler(this.button_downloadPhoto_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.comboBox_schoolName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox_password);
            this.panel1.Controls.Add(this.pictureBox_new);
            this.panel1.Controls.Add(this.pictureBox_old);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox_driverLicenseType);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.textBox_idNumber);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.comboBox_idType);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.comboBox_gender);
            this.panel1.Controls.Add(this.textBox_name);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 289);
            this.panel1.TabIndex = 29;
            // 
            // comboBox_schoolName
            // 
            this.comboBox_schoolName.FormattingEnabled = true;
            this.comboBox_schoolName.Location = new System.Drawing.Point(103, 136);
            this.comboBox_schoolName.Name = "comboBox_schoolName";
            this.comboBox_schoolName.Size = new System.Drawing.Size(147, 20);
            this.comboBox_schoolName.TabIndex = 33;
            // 
            // button_readCard
            // 
            this.button_readCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_readCard.Location = new System.Drawing.Point(12, 307);
            this.button_readCard.Name = "button_readCard";
            this.button_readCard.Size = new System.Drawing.Size(75, 23);
            this.button_readCard.TabIndex = 30;
            this.button_readCard.Text = "读卡";
            this.button_readCard.UseVisualStyleBackColor = true;
            this.button_readCard.Click += new System.EventHandler(this.button_readCard_Click);
            // 
            // Form_Student_appendModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(286, 342);
            this.Controls.Add(this.button_readCard);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_downloadPhoto);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Student_appendModify";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学员添加/修改";
            this.Load += new System.EventHandler(this.Form_Student_append_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_old)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_new)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.ComboBox comboBox_gender;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox_driverLicenseType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox_idNumber;
        private System.Windows.Forms.ComboBox comboBox_idType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.PictureBox pictureBox_old;
        private System.Windows.Forms.PictureBox pictureBox_new;
        private System.Windows.Forms.Button button_downloadPhoto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox_schoolName;
        private System.Windows.Forms.Button button_readCard;
    }
}