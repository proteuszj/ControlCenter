namespace Client
{
    partial class Form_Config
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
            this.label_ServiceURL = new System.Windows.Forms.Label();
            this.textBox_ServiceURL = new System.Windows.Forms.TextBox();
            this.label_ServiceSerialNumber = new System.Windows.Forms.Label();
            this.textBox_ServiceSerialNumber = new System.Windows.Forms.TextBox();
            this.label_PlaceSerialNumber = new System.Windows.Forms.Label();
            this.textBox_PlaceSerialNumber = new System.Windows.Forms.TextBox();
            this.label_PlaceCode = new System.Windows.Forms.Label();
            this.textBox_PlaceCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_TerminalList = new System.Windows.Forms.DataGridView();
            this.groupBox_CarDeviceSettion = new System.Windows.Forms.GroupBox();
            this.button_Load = new System.Windows.Forms.Button();
            this.textBox_UpgradePackage = new System.Windows.Forms.TextBox();
            this.label_UpgradePackage = new System.Windows.Forms.Label();
            this.checkBox_AutoUpgrade = new System.Windows.Forms.CheckBox();
            this.checkBox_FingerPrint = new System.Windows.Forms.CheckBox();
            this.checkBox_Capture = new System.Windows.Forms.CheckBox();
            this.groupBox_SystemSecuritySetting = new System.Windows.Forms.GroupBox();
            this.textBox_LoginTimeout = new System.Windows.Forms.TextBox();
            this.label_LoginTimeout = new System.Windows.Forms.Label();
            this.textBox_TerminalLockDuration = new System.Windows.Forms.TextBox();
            this.label_TerminalLockDuration = new System.Windows.Forms.Label();
            this.textBox_DefaultTerminalMaxFailureCount = new System.Windows.Forms.TextBox();
            this.label_DefaultTerminalMaxFailureCount = new System.Windows.Forms.Label();
            this.textBox_PasswordValidPeriod = new System.Windows.Forms.TextBox();
            this.label_PasswordValidPeriod = new System.Windows.Forms.Label();
            this.label_DefaultUserMaxFailureCount = new System.Windows.Forms.Label();
            this.textBox_DefaultUserMaxFailureCount = new System.Windows.Forms.TextBox();
            this.groupBox_ExamSystemSetting = new System.Windows.Forms.GroupBox();
            this.button_TimeSync = new System.Windows.Forms.Button();
            this.textBox_SystemSerialNumber = new System.Windows.Forms.TextBox();
            this.label_SystemSerialNumber = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.openFileDialog_UpdatePackage = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TerminalList)).BeginInit();
            this.groupBox_CarDeviceSettion.SuspendLayout();
            this.groupBox_SystemSecuritySetting.SuspendLayout();
            this.groupBox_ExamSystemSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_ServiceURL
            // 
            this.label_ServiceURL.AutoSize = true;
            this.label_ServiceURL.Location = new System.Drawing.Point(6, 24);
            this.label_ServiceURL.Name = "label_ServiceURL";
            this.label_ServiceURL.Size = new System.Drawing.Size(59, 12);
            this.label_ServiceURL.TabIndex = 0;
            this.label_ServiceURL.Text = "服务URL：";
            // 
            // textBox_ServiceURL
            // 
            this.textBox_ServiceURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ServiceURL.Location = new System.Drawing.Point(101, 21);
            this.textBox_ServiceURL.Name = "textBox_ServiceURL";
            this.textBox_ServiceURL.Size = new System.Drawing.Size(641, 21);
            this.textBox_ServiceURL.TabIndex = 1;
            // 
            // label_ServiceSerialNumber
            // 
            this.label_ServiceSerialNumber.AutoSize = true;
            this.label_ServiceSerialNumber.Location = new System.Drawing.Point(6, 58);
            this.label_ServiceSerialNumber.Name = "label_ServiceSerialNumber";
            this.label_ServiceSerialNumber.Size = new System.Drawing.Size(101, 12);
            this.label_ServiceSerialNumber.TabIndex = 2;
            this.label_ServiceSerialNumber.Text = "服务接口序列号：";
            // 
            // textBox_ServiceSerialNumber
            // 
            this.textBox_ServiceSerialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ServiceSerialNumber.Location = new System.Drawing.Point(164, 55);
            this.textBox_ServiceSerialNumber.Name = "textBox_ServiceSerialNumber";
            this.textBox_ServiceSerialNumber.Size = new System.Drawing.Size(578, 21);
            this.textBox_ServiceSerialNumber.TabIndex = 3;
            // 
            // label_PlaceSerialNumber
            // 
            this.label_PlaceSerialNumber.AutoSize = true;
            this.label_PlaceSerialNumber.Location = new System.Drawing.Point(6, 92);
            this.label_PlaceSerialNumber.Name = "label_PlaceSerialNumber";
            this.label_PlaceSerialNumber.Size = new System.Drawing.Size(65, 12);
            this.label_PlaceSerialNumber.TabIndex = 4;
            this.label_PlaceSerialNumber.Text = "考场序号：";
            // 
            // textBox_PlaceSerialNumber
            // 
            this.textBox_PlaceSerialNumber.Location = new System.Drawing.Point(110, 89);
            this.textBox_PlaceSerialNumber.Name = "textBox_PlaceSerialNumber";
            this.textBox_PlaceSerialNumber.Size = new System.Drawing.Size(230, 21);
            this.textBox_PlaceSerialNumber.TabIndex = 5;
            // 
            // label_PlaceCode
            // 
            this.label_PlaceCode.AutoSize = true;
            this.label_PlaceCode.Location = new System.Drawing.Point(363, 92);
            this.label_PlaceCode.Name = "label_PlaceCode";
            this.label_PlaceCode.Size = new System.Drawing.Size(137, 12);
            this.label_PlaceCode.TabIndex = 6;
            this.label_PlaceCode.Text = "考场代码（考试地点）：";
            // 
            // textBox_PlaceCode
            // 
            this.textBox_PlaceCode.Location = new System.Drawing.Point(575, 89);
            this.textBox_PlaceCode.Name = "textBox_PlaceCode";
            this.textBox_PlaceCode.Size = new System.Drawing.Size(167, 21);
            this.textBox_PlaceCode.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox_CarDeviceSettion);
            this.panel1.Controls.Add(this.groupBox_SystemSecuritySetting);
            this.panel1.Controls.Add(this.groupBox_ExamSystemSetting);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 491);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView_TerminalList);
            this.panel2.Location = new System.Drawing.Point(3, 296);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(748, 94);
            this.panel2.TabIndex = 17;
            // 
            // dataGridView_TerminalList
            // 
            this.dataGridView_TerminalList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_TerminalList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TerminalList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_TerminalList.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_TerminalList.Name = "dataGridView_TerminalList";
            this.dataGridView_TerminalList.RowTemplate.Height = 30;
            this.dataGridView_TerminalList.Size = new System.Drawing.Size(748, 94);
            this.dataGridView_TerminalList.TabIndex = 16;
            // 
            // groupBox_CarDeviceSettion
            // 
            this.groupBox_CarDeviceSettion.Controls.Add(this.button_Load);
            this.groupBox_CarDeviceSettion.Controls.Add(this.textBox_UpgradePackage);
            this.groupBox_CarDeviceSettion.Controls.Add(this.label_UpgradePackage);
            this.groupBox_CarDeviceSettion.Controls.Add(this.checkBox_AutoUpgrade);
            this.groupBox_CarDeviceSettion.Controls.Add(this.checkBox_FingerPrint);
            this.groupBox_CarDeviceSettion.Controls.Add(this.checkBox_Capture);
            this.groupBox_CarDeviceSettion.Location = new System.Drawing.Point(3, 396);
            this.groupBox_CarDeviceSettion.Name = "groupBox_CarDeviceSettion";
            this.groupBox_CarDeviceSettion.Size = new System.Drawing.Size(748, 92);
            this.groupBox_CarDeviceSettion.TabIndex = 15;
            this.groupBox_CarDeviceSettion.TabStop = false;
            this.groupBox_CarDeviceSettion.Text = "车载端设置";
            // 
            // button_Load
            // 
            this.button_Load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Load.Location = new System.Drawing.Point(667, 54);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(75, 23);
            this.button_Load.TabIndex = 5;
            this.button_Load.Text = "上传";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // textBox_UpgradePackage
            // 
            this.textBox_UpgradePackage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_UpgradePackage.Location = new System.Drawing.Point(164, 53);
            this.textBox_UpgradePackage.Name = "textBox_UpgradePackage";
            this.textBox_UpgradePackage.Size = new System.Drawing.Size(497, 21);
            this.textBox_UpgradePackage.TabIndex = 4;
            // 
            // label_UpgradePackage
            // 
            this.label_UpgradePackage.AutoSize = true;
            this.label_UpgradePackage.Location = new System.Drawing.Point(6, 56);
            this.label_UpgradePackage.Name = "label_UpgradePackage";
            this.label_UpgradePackage.Size = new System.Drawing.Size(101, 12);
            this.label_UpgradePackage.TabIndex = 3;
            this.label_UpgradePackage.Text = "评判软件升级包：";
            // 
            // checkBox_AutoUpgrade
            // 
            this.checkBox_AutoUpgrade.AutoSize = true;
            this.checkBox_AutoUpgrade.Location = new System.Drawing.Point(266, 27);
            this.checkBox_AutoUpgrade.Name = "checkBox_AutoUpgrade";
            this.checkBox_AutoUpgrade.Size = new System.Drawing.Size(72, 16);
            this.checkBox_AutoUpgrade.TabIndex = 2;
            this.checkBox_AutoUpgrade.Text = "自动升级";
            this.checkBox_AutoUpgrade.UseVisualStyleBackColor = true;
            // 
            // checkBox_FingerPrint
            // 
            this.checkBox_FingerPrint.AutoSize = true;
            this.checkBox_FingerPrint.Location = new System.Drawing.Point(6, 27);
            this.checkBox_FingerPrint.Name = "checkBox_FingerPrint";
            this.checkBox_FingerPrint.Size = new System.Drawing.Size(96, 16);
            this.checkBox_FingerPrint.TabIndex = 1;
            this.checkBox_FingerPrint.Text = "启用指纹识别";
            this.checkBox_FingerPrint.UseVisualStyleBackColor = true;
            // 
            // checkBox_Capture
            // 
            this.checkBox_Capture.AutoSize = true;
            this.checkBox_Capture.Location = new System.Drawing.Point(154, 27);
            this.checkBox_Capture.Name = "checkBox_Capture";
            this.checkBox_Capture.Size = new System.Drawing.Size(72, 16);
            this.checkBox_Capture.TabIndex = 0;
            this.checkBox_Capture.Text = "启用抓拍";
            this.checkBox_Capture.UseVisualStyleBackColor = true;
            // 
            // groupBox_SystemSecuritySetting
            // 
            this.groupBox_SystemSecuritySetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_SystemSecuritySetting.Controls.Add(this.textBox_LoginTimeout);
            this.groupBox_SystemSecuritySetting.Controls.Add(this.label_LoginTimeout);
            this.groupBox_SystemSecuritySetting.Controls.Add(this.textBox_TerminalLockDuration);
            this.groupBox_SystemSecuritySetting.Controls.Add(this.label_TerminalLockDuration);
            this.groupBox_SystemSecuritySetting.Controls.Add(this.textBox_DefaultTerminalMaxFailureCount);
            this.groupBox_SystemSecuritySetting.Controls.Add(this.label_DefaultTerminalMaxFailureCount);
            this.groupBox_SystemSecuritySetting.Controls.Add(this.textBox_PasswordValidPeriod);
            this.groupBox_SystemSecuritySetting.Controls.Add(this.label_PasswordValidPeriod);
            this.groupBox_SystemSecuritySetting.Controls.Add(this.label_DefaultUserMaxFailureCount);
            this.groupBox_SystemSecuritySetting.Controls.Add(this.textBox_DefaultUserMaxFailureCount);
            this.groupBox_SystemSecuritySetting.Location = new System.Drawing.Point(3, 166);
            this.groupBox_SystemSecuritySetting.Name = "groupBox_SystemSecuritySetting";
            this.groupBox_SystemSecuritySetting.Size = new System.Drawing.Size(748, 124);
            this.groupBox_SystemSecuritySetting.TabIndex = 14;
            this.groupBox_SystemSecuritySetting.TabStop = false;
            this.groupBox_SystemSecuritySetting.Text = "系统安全设置";
            // 
            // textBox_LoginTimeout
            // 
            this.textBox_LoginTimeout.Location = new System.Drawing.Point(218, 89);
            this.textBox_LoginTimeout.Name = "textBox_LoginTimeout";
            this.textBox_LoginTimeout.Size = new System.Drawing.Size(100, 21);
            this.textBox_LoginTimeout.TabIndex = 20;
            // 
            // label_LoginTimeout
            // 
            this.label_LoginTimeout.AutoSize = true;
            this.label_LoginTimeout.Location = new System.Drawing.Point(6, 92);
            this.label_LoginTimeout.Name = "label_LoginTimeout";
            this.label_LoginTimeout.Size = new System.Drawing.Size(137, 12);
            this.label_LoginTimeout.TabIndex = 19;
            this.label_LoginTimeout.Text = "登录超时时间（分钟）：";
            // 
            // textBox_TerminalLockDuration
            // 
            this.textBox_TerminalLockDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_TerminalLockDuration.Location = new System.Drawing.Point(628, 55);
            this.textBox_TerminalLockDuration.Name = "textBox_TerminalLockDuration";
            this.textBox_TerminalLockDuration.Size = new System.Drawing.Size(115, 21);
            this.textBox_TerminalLockDuration.TabIndex = 18;
            // 
            // label_TerminalLockDuration
            // 
            this.label_TerminalLockDuration.AutoSize = true;
            this.label_TerminalLockDuration.Location = new System.Drawing.Point(416, 58);
            this.label_TerminalLockDuration.Name = "label_TerminalLockDuration";
            this.label_TerminalLockDuration.Size = new System.Drawing.Size(137, 12);
            this.label_TerminalLockDuration.TabIndex = 17;
            this.label_TerminalLockDuration.Text = "终端锁定时间（分钟）：";
            // 
            // textBox_DefaultTerminalMaxFailureCount
            // 
            this.textBox_DefaultTerminalMaxFailureCount.Location = new System.Drawing.Point(290, 55);
            this.textBox_DefaultTerminalMaxFailureCount.Name = "textBox_DefaultTerminalMaxFailureCount";
            this.textBox_DefaultTerminalMaxFailureCount.Size = new System.Drawing.Size(114, 21);
            this.textBox_DefaultTerminalMaxFailureCount.TabIndex = 16;
            // 
            // label_DefaultTerminalMaxFailureCount
            // 
            this.label_DefaultTerminalMaxFailureCount.AutoSize = true;
            this.label_DefaultTerminalMaxFailureCount.Location = new System.Drawing.Point(6, 58);
            this.label_DefaultTerminalMaxFailureCount.Name = "label_DefaultTerminalMaxFailureCount";
            this.label_DefaultTerminalMaxFailureCount.Size = new System.Drawing.Size(185, 12);
            this.label_DefaultTerminalMaxFailureCount.TabIndex = 15;
            this.label_DefaultTerminalMaxFailureCount.Text = "默认终端最大连续失败登录次数：";
            // 
            // textBox_PasswordValidPeriod
            // 
            this.textBox_PasswordValidPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_PasswordValidPeriod.Location = new System.Drawing.Point(628, 21);
            this.textBox_PasswordValidPeriod.Name = "textBox_PasswordValidPeriod";
            this.textBox_PasswordValidPeriod.Size = new System.Drawing.Size(114, 21);
            this.textBox_PasswordValidPeriod.TabIndex = 14;
            // 
            // label_PasswordValidPeriod
            // 
            this.label_PasswordValidPeriod.AutoSize = true;
            this.label_PasswordValidPeriod.Location = new System.Drawing.Point(416, 24);
            this.label_PasswordValidPeriod.Name = "label_PasswordValidPeriod";
            this.label_PasswordValidPeriod.Size = new System.Drawing.Size(137, 12);
            this.label_PasswordValidPeriod.TabIndex = 13;
            this.label_PasswordValidPeriod.Text = "用户密码有效期（天）：";
            // 
            // label_DefaultUserMaxFailureCount
            // 
            this.label_DefaultUserMaxFailureCount.AutoSize = true;
            this.label_DefaultUserMaxFailureCount.Location = new System.Drawing.Point(6, 24);
            this.label_DefaultUserMaxFailureCount.Name = "label_DefaultUserMaxFailureCount";
            this.label_DefaultUserMaxFailureCount.Size = new System.Drawing.Size(185, 12);
            this.label_DefaultUserMaxFailureCount.TabIndex = 11;
            this.label_DefaultUserMaxFailureCount.Text = "默认用户最大连续失败登录次数：";
            // 
            // textBox_DefaultUserMaxFailureCount
            // 
            this.textBox_DefaultUserMaxFailureCount.Location = new System.Drawing.Point(290, 21);
            this.textBox_DefaultUserMaxFailureCount.Name = "textBox_DefaultUserMaxFailureCount";
            this.textBox_DefaultUserMaxFailureCount.Size = new System.Drawing.Size(114, 21);
            this.textBox_DefaultUserMaxFailureCount.TabIndex = 12;
            // 
            // groupBox_ExamSystemSetting
            // 
            this.groupBox_ExamSystemSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_ExamSystemSetting.Controls.Add(this.label_ServiceURL);
            this.groupBox_ExamSystemSetting.Controls.Add(this.label_PlaceSerialNumber);
            this.groupBox_ExamSystemSetting.Controls.Add(this.textBox_ServiceSerialNumber);
            this.groupBox_ExamSystemSetting.Controls.Add(this.button_TimeSync);
            this.groupBox_ExamSystemSetting.Controls.Add(this.textBox_PlaceSerialNumber);
            this.groupBox_ExamSystemSetting.Controls.Add(this.textBox_SystemSerialNumber);
            this.groupBox_ExamSystemSetting.Controls.Add(this.label_ServiceSerialNumber);
            this.groupBox_ExamSystemSetting.Controls.Add(this.label_SystemSerialNumber);
            this.groupBox_ExamSystemSetting.Controls.Add(this.label_PlaceCode);
            this.groupBox_ExamSystemSetting.Controls.Add(this.textBox_ServiceURL);
            this.groupBox_ExamSystemSetting.Controls.Add(this.textBox_PlaceCode);
            this.groupBox_ExamSystemSetting.Location = new System.Drawing.Point(3, 3);
            this.groupBox_ExamSystemSetting.Name = "groupBox_ExamSystemSetting";
            this.groupBox_ExamSystemSetting.Size = new System.Drawing.Size(748, 157);
            this.groupBox_ExamSystemSetting.TabIndex = 13;
            this.groupBox_ExamSystemSetting.TabStop = false;
            this.groupBox_ExamSystemSetting.Text = "考试系统接口设置";
            // 
            // button_TimeSync
            // 
            this.button_TimeSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_TimeSync.Location = new System.Drawing.Point(643, 122);
            this.button_TimeSync.Name = "button_TimeSync";
            this.button_TimeSync.Size = new System.Drawing.Size(99, 27);
            this.button_TimeSync.TabIndex = 10;
            this.button_TimeSync.Text = "时间同步";
            this.button_TimeSync.UseVisualStyleBackColor = true;
            this.button_TimeSync.Click += new System.EventHandler(this.button_TimeSync_Click);
            // 
            // textBox_SystemSerialNumber
            // 
            this.textBox_SystemSerialNumber.Location = new System.Drawing.Point(146, 123);
            this.textBox_SystemSerialNumber.Name = "textBox_SystemSerialNumber";
            this.textBox_SystemSerialNumber.Size = new System.Drawing.Size(169, 21);
            this.textBox_SystemSerialNumber.TabIndex = 9;
            // 
            // label_SystemSerialNumber
            // 
            this.label_SystemSerialNumber.AutoSize = true;
            this.label_SystemSerialNumber.Location = new System.Drawing.Point(6, 126);
            this.label_SystemSerialNumber.Name = "label_SystemSerialNumber";
            this.label_SystemSerialNumber.Size = new System.Drawing.Size(89, 12);
            this.label_SystemSerialNumber.TabIndex = 8;
            this.label_SystemSerialNumber.Text = "考试系统编号：";
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(610, 509);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "确定";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(691, 509);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Form_Config
            // 
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Config";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.Form_Config_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TerminalList)).EndInit();
            this.groupBox_CarDeviceSettion.ResumeLayout(false);
            this.groupBox_CarDeviceSettion.PerformLayout();
            this.groupBox_SystemSecuritySetting.ResumeLayout(false);
            this.groupBox_SystemSecuritySetting.PerformLayout();
            this.groupBox_ExamSystemSetting.ResumeLayout(false);
            this.groupBox_ExamSystemSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_ServiceURL;
        private System.Windows.Forms.TextBox textBox_ServiceURL;
        private System.Windows.Forms.Label label_ServiceSerialNumber;
        private System.Windows.Forms.TextBox textBox_ServiceSerialNumber;
        private System.Windows.Forms.Label label_PlaceSerialNumber;
        private System.Windows.Forms.TextBox textBox_PlaceSerialNumber;
        private System.Windows.Forms.Label label_PlaceCode;
        private System.Windows.Forms.TextBox textBox_PlaceCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TextBox textBox_SystemSerialNumber;
        private System.Windows.Forms.Label label_SystemSerialNumber;
        private System.Windows.Forms.Button button_TimeSync;
        private System.Windows.Forms.GroupBox groupBox_CarDeviceSettion;
        private System.Windows.Forms.GroupBox groupBox_SystemSecuritySetting;
        private System.Windows.Forms.TextBox textBox_LoginTimeout;
        private System.Windows.Forms.Label label_LoginTimeout;
        private System.Windows.Forms.TextBox textBox_TerminalLockDuration;
        private System.Windows.Forms.Label label_TerminalLockDuration;
        private System.Windows.Forms.TextBox textBox_DefaultTerminalMaxFailureCount;
        private System.Windows.Forms.Label label_DefaultTerminalMaxFailureCount;
        private System.Windows.Forms.TextBox textBox_PasswordValidPeriod;
        private System.Windows.Forms.Label label_PasswordValidPeriod;
        private System.Windows.Forms.Label label_DefaultUserMaxFailureCount;
        private System.Windows.Forms.TextBox textBox_DefaultUserMaxFailureCount;
        private System.Windows.Forms.GroupBox groupBox_ExamSystemSetting;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.TextBox textBox_UpgradePackage;
        private System.Windows.Forms.Label label_UpgradePackage;
        private System.Windows.Forms.CheckBox checkBox_AutoUpgrade;
        private System.Windows.Forms.CheckBox checkBox_FingerPrint;
        private System.Windows.Forms.CheckBox checkBox_Capture;
        private System.Windows.Forms.OpenFileDialog openFileDialog_UpdatePackage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_TerminalList;
    }
}
