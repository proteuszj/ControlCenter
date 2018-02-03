namespace DBTools
{
    partial class Form_Main
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
            this.panel_connection = new System.Windows.Forms.Panel();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.label_user = new System.Windows.Forms.Label();
            this.textBox_SID = new System.Windows.Forms.TextBox();
            this.label_SID = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.label_address = new System.Windows.Forms.Label();
            this.panel_backup = new System.Windows.Forms.Panel();
            this.button_backup = new System.Windows.Forms.Button();
            this.label_FileName = new System.Windows.Forms.Label();
            this.checkBox_addTime = new System.Windows.Forms.CheckBox();
            this.checkBox_addDate = new System.Windows.Forms.CheckBox();
            this.textBox_baseName = new System.Windows.Forms.TextBox();
            this.label_baseName = new System.Windows.Forms.Label();
            this.button_targetFolder = new System.Windows.Forms.Button();
            this.panel_restore = new System.Windows.Forms.Panel();
            this.button_restore = new System.Windows.Forms.Button();
            this.textBox_restoreFile = new System.Windows.Forms.TextBox();
            this.button_restoreFile = new System.Windows.Forms.Button();
            this.openFileDialog_restore = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog_backup = new System.Windows.Forms.FolderBrowserDialog();
            this.panel_backupRestore = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_run = new System.Windows.Forms.Button();
            this.textBox_scriptFile = new System.Windows.Forms.TextBox();
            this.button_scriptFile = new System.Windows.Forms.Button();
            this.openFileDialog_script = new System.Windows.Forms.OpenFileDialog();
            this.panel_connection.SuspendLayout();
            this.panel_backup.SuspendLayout();
            this.panel_restore.SuspendLayout();
            this.panel_backupRestore.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_connection
            // 
            this.panel_connection.Controls.Add(this.button_connect);
            this.panel_connection.Controls.Add(this.textBox_password);
            this.panel_connection.Controls.Add(this.label_password);
            this.panel_connection.Controls.Add(this.textBox_user);
            this.panel_connection.Controls.Add(this.label_user);
            this.panel_connection.Controls.Add(this.textBox_SID);
            this.panel_connection.Controls.Add(this.label_SID);
            this.panel_connection.Controls.Add(this.textBox_port);
            this.panel_connection.Controls.Add(this.label_port);
            this.panel_connection.Controls.Add(this.textBox_address);
            this.panel_connection.Controls.Add(this.label_address);
            this.panel_connection.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_connection.Location = new System.Drawing.Point(0, 0);
            this.panel_connection.Name = "panel_connection";
            this.panel_connection.Size = new System.Drawing.Size(150, 149);
            this.panel_connection.TabIndex = 0;
            this.panel_connection.Visible = false;
            // 
            // button_connect
            // 
            this.button_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_connect.Location = new System.Drawing.Point(73, 122);
            this.button_connect.Margin = new System.Windows.Forms.Padding(2);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 25);
            this.button_connect.TabIndex = 10;
            this.button_connect.Text = "连接数据库";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_password
            // 
            this.textBox_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_password.Location = new System.Drawing.Point(61, 99);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(87, 21);
            this.textBox_password.TabIndex = 9;
            this.textBox_password.Text = "Tn$zc_160610";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(3, 101);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(41, 12);
            this.label_password.TabIndex = 8;
            this.label_password.Text = "密码：";
            // 
            // textBox_user
            // 
            this.textBox_user.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_user.Location = new System.Drawing.Point(61, 75);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.PasswordChar = '*';
            this.textBox_user.Size = new System.Drawing.Size(87, 21);
            this.textBox_user.TabIndex = 7;
            this.textBox_user.Text = "tnzc_dz";
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(3, 77);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(53, 12);
            this.label_user.TabIndex = 6;
            this.label_user.Text = "用户名：";
            // 
            // textBox_SID
            // 
            this.textBox_SID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SID.Location = new System.Drawing.Point(61, 51);
            this.textBox_SID.Name = "textBox_SID";
            this.textBox_SID.PasswordChar = '*';
            this.textBox_SID.Size = new System.Drawing.Size(87, 21);
            this.textBox_SID.TabIndex = 5;
            this.textBox_SID.Text = "orcl";
            // 
            // label_SID
            // 
            this.label_SID.AutoSize = true;
            this.label_SID.Location = new System.Drawing.Point(3, 53);
            this.label_SID.Name = "label_SID";
            this.label_SID.Size = new System.Drawing.Size(53, 12);
            this.label_SID.TabIndex = 4;
            this.label_SID.Text = "服务名：";
            // 
            // textBox_port
            // 
            this.textBox_port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_port.Location = new System.Drawing.Point(61, 27);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(87, 21);
            this.textBox_port.TabIndex = 3;
            this.textBox_port.Text = "1521";
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(3, 29);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(41, 12);
            this.label_port.TabIndex = 2;
            this.label_port.Text = "端口：";
            // 
            // textBox_address
            // 
            this.textBox_address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_address.Location = new System.Drawing.Point(61, 3);
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(87, 21);
            this.textBox_address.TabIndex = 1;
            this.textBox_address.Text = "localhost";
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(3, 5);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(41, 12);
            this.label_address.TabIndex = 0;
            this.label_address.Text = "地址：";
            // 
            // panel_backup
            // 
            this.panel_backup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_backup.Controls.Add(this.button_backup);
            this.panel_backup.Controls.Add(this.label_FileName);
            this.panel_backup.Controls.Add(this.checkBox_addTime);
            this.panel_backup.Controls.Add(this.checkBox_addDate);
            this.panel_backup.Controls.Add(this.textBox_baseName);
            this.panel_backup.Controls.Add(this.label_baseName);
            this.panel_backup.Controls.Add(this.button_targetFolder);
            this.panel_backup.Location = new System.Drawing.Point(3, 3);
            this.panel_backup.Name = "panel_backup";
            this.panel_backup.Size = new System.Drawing.Size(550, 62);
            this.panel_backup.TabIndex = 1;
            // 
            // button_backup
            // 
            this.button_backup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_backup.Location = new System.Drawing.Point(471, 3);
            this.button_backup.Name = "button_backup";
            this.button_backup.Size = new System.Drawing.Size(68, 23);
            this.button_backup.TabIndex = 5;
            this.button_backup.Text = "开始备份";
            this.button_backup.UseVisualStyleBackColor = true;
            this.button_backup.Click += new System.EventHandler(this.button_backup_Click);
            // 
            // label_FileName
            // 
            this.label_FileName.AutoSize = true;
            this.label_FileName.Location = new System.Drawing.Point(3, 41);
            this.label_FileName.Name = "label_FileName";
            this.label_FileName.Size = new System.Drawing.Size(53, 12);
            this.label_FileName.TabIndex = 6;
            this.label_FileName.Text = "FileName";
            // 
            // checkBox_addTime
            // 
            this.checkBox_addTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_addTime.AutoSize = true;
            this.checkBox_addTime.Location = new System.Drawing.Point(394, 7);
            this.checkBox_addTime.Name = "checkBox_addTime";
            this.checkBox_addTime.Size = new System.Drawing.Size(72, 16);
            this.checkBox_addTime.TabIndex = 4;
            this.checkBox_addTime.Text = "添加时间";
            this.checkBox_addTime.UseVisualStyleBackColor = true;
            this.checkBox_addTime.CheckedChanged += new System.EventHandler(this.textBox_baseName_TextChanged);
            // 
            // checkBox_addDate
            // 
            this.checkBox_addDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_addDate.AutoSize = true;
            this.checkBox_addDate.Location = new System.Drawing.Point(316, 7);
            this.checkBox_addDate.Name = "checkBox_addDate";
            this.checkBox_addDate.Size = new System.Drawing.Size(72, 16);
            this.checkBox_addDate.TabIndex = 3;
            this.checkBox_addDate.Text = "添加日期";
            this.checkBox_addDate.UseVisualStyleBackColor = true;
            this.checkBox_addDate.CheckedChanged += new System.EventHandler(this.textBox_baseName_TextChanged);
            // 
            // textBox_baseName
            // 
            this.textBox_baseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_baseName.Location = new System.Drawing.Point(215, 5);
            this.textBox_baseName.Name = "textBox_baseName";
            this.textBox_baseName.Size = new System.Drawing.Size(97, 21);
            this.textBox_baseName.TabIndex = 2;
            this.textBox_baseName.Text = "tnzc_dz";
            this.textBox_baseName.TextChanged += new System.EventHandler(this.textBox_baseName_TextChanged);
            // 
            // label_baseName
            // 
            this.label_baseName.AutoSize = true;
            this.label_baseName.Location = new System.Drawing.Point(156, 8);
            this.label_baseName.Name = "label_baseName";
            this.label_baseName.Size = new System.Drawing.Size(53, 12);
            this.label_baseName.TabIndex = 1;
            this.label_baseName.Text = "文件名：";
            // 
            // button_targetFolder
            // 
            this.button_targetFolder.Location = new System.Drawing.Point(2, 3);
            this.button_targetFolder.Name = "button_targetFolder";
            this.button_targetFolder.Size = new System.Drawing.Size(149, 23);
            this.button_targetFolder.TabIndex = 0;
            this.button_targetFolder.Text = "选择备份文件目录位置";
            this.button_targetFolder.UseVisualStyleBackColor = true;
            this.button_targetFolder.Click += new System.EventHandler(this.button_targetFolder_Click);
            // 
            // panel_restore
            // 
            this.panel_restore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_restore.Controls.Add(this.button_restore);
            this.panel_restore.Controls.Add(this.textBox_restoreFile);
            this.panel_restore.Controls.Add(this.button_restoreFile);
            this.panel_restore.Location = new System.Drawing.Point(3, 71);
            this.panel_restore.Name = "panel_restore";
            this.panel_restore.Size = new System.Drawing.Size(550, 32);
            this.panel_restore.TabIndex = 2;
            this.panel_restore.Visible = false;
            // 
            // button_restore
            // 
            this.button_restore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_restore.Enabled = false;
            this.button_restore.Location = new System.Drawing.Point(471, 3);
            this.button_restore.Name = "button_restore";
            this.button_restore.Size = new System.Drawing.Size(68, 23);
            this.button_restore.TabIndex = 2;
            this.button_restore.Text = "开始恢复";
            this.button_restore.UseVisualStyleBackColor = true;
            this.button_restore.Click += new System.EventHandler(this.button_restore_Click);
            // 
            // textBox_restoreFile
            // 
            this.textBox_restoreFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_restoreFile.Location = new System.Drawing.Point(110, 5);
            this.textBox_restoreFile.Name = "textBox_restoreFile";
            this.textBox_restoreFile.Size = new System.Drawing.Size(357, 21);
            this.textBox_restoreFile.TabIndex = 1;
            this.textBox_restoreFile.TextChanged += new System.EventHandler(this.textBox_File_TextChanged);
            // 
            // button_restoreFile
            // 
            this.button_restoreFile.Location = new System.Drawing.Point(3, 3);
            this.button_restoreFile.Name = "button_restoreFile";
            this.button_restoreFile.Size = new System.Drawing.Size(103, 23);
            this.button_restoreFile.TabIndex = 0;
            this.button_restoreFile.Text = "选择恢复文件";
            this.button_restoreFile.UseVisualStyleBackColor = true;
            this.button_restoreFile.Click += new System.EventHandler(this.button_openFile_Click);
            // 
            // openFileDialog_restore
            // 
            this.openFileDialog_restore.DefaultExt = "dmp";
            this.openFileDialog_restore.Filter = "dump file|*.dmp|所有文件|*.*";
            // 
            // folderBrowserDialog_backup
            // 
            this.folderBrowserDialog_backup.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // panel_backupRestore
            // 
            this.panel_backupRestore.Controls.Add(this.panel1);
            this.panel_backupRestore.Controls.Add(this.panel_backup);
            this.panel_backupRestore.Controls.Add(this.panel_restore);
            this.panel_backupRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_backupRestore.Location = new System.Drawing.Point(150, 0);
            this.panel_backupRestore.Margin = new System.Windows.Forms.Padding(2);
            this.panel_backupRestore.Name = "panel_backupRestore";
            this.panel_backupRestore.Size = new System.Drawing.Size(555, 149);
            this.panel_backupRestore.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button_run);
            this.panel1.Controls.Add(this.textBox_scriptFile);
            this.panel1.Controls.Add(this.button_scriptFile);
            this.panel1.Location = new System.Drawing.Point(3, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 32);
            this.panel1.TabIndex = 3;
            // 
            // button_run
            // 
            this.button_run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_run.Location = new System.Drawing.Point(471, 3);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(68, 23);
            this.button_run.TabIndex = 2;
            this.button_run.Text = "开始执行";
            this.button_run.UseVisualStyleBackColor = true;
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // textBox_scriptFile
            // 
            this.textBox_scriptFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_scriptFile.Enabled = false;
            this.textBox_scriptFile.Location = new System.Drawing.Point(110, 5);
            this.textBox_scriptFile.Name = "textBox_scriptFile";
            this.textBox_scriptFile.Size = new System.Drawing.Size(357, 21);
            this.textBox_scriptFile.TabIndex = 1;
            this.textBox_scriptFile.TextChanged += new System.EventHandler(this.textBox_File_TextChanged);
            // 
            // button_scriptFile
            // 
            this.button_scriptFile.Enabled = false;
            this.button_scriptFile.Location = new System.Drawing.Point(3, 3);
            this.button_scriptFile.Name = "button_scriptFile";
            this.button_scriptFile.Size = new System.Drawing.Size(103, 23);
            this.button_scriptFile.TabIndex = 0;
            this.button_scriptFile.Text = "选择脚本文件";
            this.button_scriptFile.UseVisualStyleBackColor = true;
            this.button_scriptFile.Click += new System.EventHandler(this.button_openFile_Click);
            // 
            // openFileDialog_script
            // 
            this.openFileDialog_script.DefaultExt = "sql";
            this.openFileDialog_script.Filter = "SQL file|*.sql|所有文件|*.*";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 149);
            this.Controls.Add(this.panel_backupRestore);
            this.Controls.Add(this.panel_connection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Main_KeyDown);
            this.panel_connection.ResumeLayout(false);
            this.panel_connection.PerformLayout();
            this.panel_backup.ResumeLayout(false);
            this.panel_backup.PerformLayout();
            this.panel_restore.ResumeLayout(false);
            this.panel_restore.PerformLayout();
            this.panel_backupRestore.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_connection;
        private System.Windows.Forms.Panel panel_backup;
        private System.Windows.Forms.Panel panel_restore;
        private System.Windows.Forms.OpenFileDialog openFileDialog_restore;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_backup;
        private System.Windows.Forms.Label label_FileName;
        private System.Windows.Forms.CheckBox checkBox_addTime;
        private System.Windows.Forms.CheckBox checkBox_addDate;
        private System.Windows.Forms.TextBox textBox_baseName;
        private System.Windows.Forms.Label label_baseName;
        private System.Windows.Forms.Button button_targetFolder;
        private System.Windows.Forms.Button button_backup;
        private System.Windows.Forms.Button button_restore;
        private System.Windows.Forms.TextBox textBox_restoreFile;
        private System.Windows.Forms.Button button_restoreFile;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.TextBox textBox_SID;
        private System.Windows.Forms.Label label_SID;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Panel panel_backupRestore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_run;
        private System.Windows.Forms.TextBox textBox_scriptFile;
        private System.Windows.Forms.Button button_scriptFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog_script;
    }
}

