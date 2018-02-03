namespace Client
{
    partial class Form_TrainBooking_confirm
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
            this.label_studentName = new System.Windows.Forms.Label();
            this.label_subjectLabel = new System.Windows.Forms.Label();
            this.label_subject = new System.Windows.Forms.Label();
            this.label_timesLabel = new System.Windows.Forms.Label();
            this.label_times = new System.Windows.Forms.Label();
            this.label_amountLabel = new System.Windows.Forms.Label();
            this.label_amount = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.textBox_idNumber = new System.Windows.Forms.TextBox();
            this.label_idNumber = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.button_readCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_studentName
            // 
            this.label_studentName.AutoSize = true;
            this.label_studentName.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_studentName.ForeColor = System.Drawing.Color.Red;
            this.label_studentName.Location = new System.Drawing.Point(62, 29);
            this.label_studentName.Name = "label_studentName";
            this.label_studentName.Size = new System.Drawing.Size(0, 19);
            this.label_studentName.TabIndex = 0;
            // 
            // label_subjectLabel
            // 
            this.label_subjectLabel.AutoSize = true;
            this.label_subjectLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_subjectLabel.Location = new System.Drawing.Point(32, 77);
            this.label_subjectLabel.Name = "label_subjectLabel";
            this.label_subjectLabel.Size = new System.Drawing.Size(142, 19);
            this.label_subjectLabel.TabIndex = 1;
            this.label_subjectLabel.Text = "预约考试科目：";
            // 
            // label_subject
            // 
            this.label_subject.AutoSize = true;
            this.label_subject.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_subject.ForeColor = System.Drawing.Color.Red;
            this.label_subject.Location = new System.Drawing.Point(195, 77);
            this.label_subject.Name = "label_subject";
            this.label_subject.Size = new System.Drawing.Size(0, 19);
            this.label_subject.TabIndex = 2;
            // 
            // label_timesLabel
            // 
            this.label_timesLabel.AutoSize = true;
            this.label_timesLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_timesLabel.Location = new System.Drawing.Point(32, 127);
            this.label_timesLabel.Name = "label_timesLabel";
            this.label_timesLabel.Size = new System.Drawing.Size(104, 19);
            this.label_timesLabel.TabIndex = 3;
            this.label_timesLabel.Text = "预约次数：";
            // 
            // label_times
            // 
            this.label_times.AutoSize = true;
            this.label_times.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_times.ForeColor = System.Drawing.Color.Red;
            this.label_times.Location = new System.Drawing.Point(189, 127);
            this.label_times.Name = "label_times";
            this.label_times.Size = new System.Drawing.Size(0, 19);
            this.label_times.TabIndex = 4;
            // 
            // label_amountLabel
            // 
            this.label_amountLabel.AutoSize = true;
            this.label_amountLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_amountLabel.Location = new System.Drawing.Point(32, 183);
            this.label_amountLabel.Name = "label_amountLabel";
            this.label_amountLabel.Size = new System.Drawing.Size(143, 19);
            this.label_amountLabel.TabIndex = 5;
            this.label_amountLabel.Text = "总计金额(元)：";
            // 
            // label_amount
            // 
            this.label_amount.AutoSize = true;
            this.label_amount.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_amount.ForeColor = System.Drawing.Color.Red;
            this.label_amount.Location = new System.Drawing.Point(189, 183);
            this.label_amount.Name = "label_amount";
            this.label_amount.Size = new System.Drawing.Size(0, 19);
            this.label_amount.TabIndex = 6;
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(115, 345);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 7;
            this.btn_ok.Text = "确认";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(198, 345);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // textBox_idNumber
            // 
            this.textBox_idNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_idNumber.Location = new System.Drawing.Point(36, 301);
            this.textBox_idNumber.MaxLength = 18;
            this.textBox_idNumber.Name = "textBox_idNumber";
            this.textBox_idNumber.Size = new System.Drawing.Size(238, 21);
            this.textBox_idNumber.TabIndex = 14;
            // 
            // label_idNumber
            // 
            this.label_idNumber.AutoSize = true;
            this.label_idNumber.Location = new System.Drawing.Point(34, 271);
            this.label_idNumber.Name = "label_idNumber";
            this.label_idNumber.Size = new System.Drawing.Size(125, 12);
            this.label_idNumber.TabIndex = 13;
            this.label_idNumber.Text = "收银员身份证明号码：";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(127, 229);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(69, 21);
            this.textBox_name.TabIndex = 10;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(36, 231);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(77, 12);
            this.label_name.TabIndex = 9;
            this.label_name.Text = "收银员姓名：";
            // 
            // button_readCard
            // 
            this.button_readCard.Location = new System.Drawing.Point(26, 345);
            this.button_readCard.Name = "button_readCard";
            this.button_readCard.Size = new System.Drawing.Size(75, 23);
            this.button_readCard.TabIndex = 15;
            this.button_readCard.Text = "读卡";
            this.button_readCard.UseVisualStyleBackColor = true;
            this.button_readCard.Click += new System.EventHandler(this.button_readCard_Click);
            // 
            // Form_TrainBooking_confirm
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(304, 385);
            this.Controls.Add(this.button_readCard);
            this.Controls.Add(this.textBox_idNumber);
            this.Controls.Add(this.label_idNumber);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label_amount);
            this.Controls.Add(this.label_amountLabel);
            this.Controls.Add(this.label_times);
            this.Controls.Add(this.label_timesLabel);
            this.Controls.Add(this.label_subject);
            this.Controls.Add(this.label_subjectLabel);
            this.Controls.Add(this.label_studentName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_TrainBooking_confirm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "预约信息确认";
            this.Load += new System.EventHandler(this.Form_TrainBooking_confirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_studentName;
        private System.Windows.Forms.Label label_subjectLabel;
        private System.Windows.Forms.Label label_subject;
        private System.Windows.Forms.Label label_timesLabel;
        private System.Windows.Forms.Label label_times;
        private System.Windows.Forms.Label label_amountLabel;
        private System.Windows.Forms.Label label_amount;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox textBox_idNumber;
        private System.Windows.Forms.Label label_idNumber;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Button button_readCard;
    }
}