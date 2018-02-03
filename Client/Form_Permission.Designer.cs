namespace Client
{
    partial class Form_Permission
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_roleName = new System.Windows.Forms.TextBox();
            this.btn_append = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.splitContainer_permission = new System.Windows.Forms.SplitContainer();
            this.listBox_roles = new System.Windows.Forms.ListBox();
            this.treeView_permission = new System.Windows.Forms.TreeView();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_permission)).BeginInit();
            this.splitContainer_permission.Panel1.SuspendLayout();
            this.splitContainer_permission.Panel2.SuspendLayout();
            this.splitContainer_permission.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.textBox_roleName);
            this.panel5.Controls.Add(this.btn_append);
            this.panel5.Controls.Add(this.btn_cancel);
            this.panel5.Controls.Add(this.btn_save);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 361);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(725, 38);
            this.panel5.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "角色名称：";
            // 
            // textBox_roleName
            // 
            this.textBox_roleName.Location = new System.Drawing.Point(83, 11);
            this.textBox_roleName.Name = "textBox_roleName";
            this.textBox_roleName.Size = new System.Drawing.Size(123, 21);
            this.textBox_roleName.TabIndex = 31;
            // 
            // btn_append
            // 
            this.btn_append.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_append.Location = new System.Drawing.Point(212, 9);
            this.btn_append.Name = "btn_append";
            this.btn_append.Size = new System.Drawing.Size(75, 23);
            this.btn_append.TabIndex = 11;
            this.btn_append.Text = "添加角色";
            this.btn_append.UseVisualStyleBackColor = true;
            this.btn_append.Click += new System.EventHandler(this.btn_append_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Enabled = false;
            this.btn_cancel.Location = new System.Drawing.Point(642, 9);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(561, 9);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // splitContainer_permission
            // 
            this.splitContainer_permission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_permission.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_permission.Name = "splitContainer_permission";
            // 
            // splitContainer_permission.Panel1
            // 
            this.splitContainer_permission.Panel1.Controls.Add(this.listBox_roles);
            // 
            // splitContainer_permission.Panel2
            // 
            this.splitContainer_permission.Panel2.Controls.Add(this.treeView_permission);
            this.splitContainer_permission.Size = new System.Drawing.Size(725, 361);
            this.splitContainer_permission.SplitterDistance = 306;
            this.splitContainer_permission.TabIndex = 4;
            // 
            // listBox_roles
            // 
            this.listBox_roles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_roles.FormattingEnabled = true;
            this.listBox_roles.ItemHeight = 12;
            this.listBox_roles.Location = new System.Drawing.Point(0, 0);
            this.listBox_roles.Name = "listBox_roles";
            this.listBox_roles.Size = new System.Drawing.Size(306, 361);
            this.listBox_roles.TabIndex = 2;
            this.listBox_roles.SelectedIndexChanged += new System.EventHandler(this.listBox_roles_SelectedIndexChanged);
            // 
            // treeView_permission
            // 
            this.treeView_permission.CheckBoxes = true;
            this.treeView_permission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_permission.Location = new System.Drawing.Point(0, 0);
            this.treeView_permission.Name = "treeView_permission";
            this.treeView_permission.Size = new System.Drawing.Size(415, 361);
            this.treeView_permission.TabIndex = 0;
            this.treeView_permission.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_permission_AfterCheck);
            // 
            // Form_Permission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 399);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer_permission);
            this.Controls.Add(this.panel5);
            this.Name = "Form_Permission";
            this.Text = "权限管理";
            this.Load += new System.EventHandler(this.Form_Permission_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.splitContainer_permission.Panel1.ResumeLayout(false);
            this.splitContainer_permission.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_permission)).EndInit();
            this.splitContainer_permission.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.SplitContainer splitContainer_permission;
        private System.Windows.Forms.ListBox listBox_roles;
        private System.Windows.Forms.Button btn_append;
        private System.Windows.Forms.TextBox textBox_roleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView_permission;
    }
}