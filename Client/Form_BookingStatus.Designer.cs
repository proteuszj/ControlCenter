namespace Client
{
    partial class Form_BookingStatus
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
            this.dataGridView_status = new System.Windows.Forms.DataGridView();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_status)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_status
            // 
            this.dataGridView_status.AllowUserToAddRows = false;
            this.dataGridView_status.AllowUserToDeleteRows = false;
            this.dataGridView_status.AllowUserToResizeRows = false;
            this.dataGridView_status.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView_status.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_status.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_status.MultiSelect = false;
            this.dataGridView_status.Name = "dataGridView_status";
            this.dataGridView_status.ReadOnly = true;
            this.dataGridView_status.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView_status.RowTemplate.Height = 23;
            this.dataGridView_status.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_status.Size = new System.Drawing.Size(363, 300);
            this.dataGridView_status.TabIndex = 0;
            this.dataGridView_status.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_status_CellClick);
            // 
            // button_ok
            // 
            this.button_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_ok.Enabled = false;
            this.button_ok.Location = new System.Drawing.Point(219, 318);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "确定";
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(300, 318);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // Form_BookingStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(387, 353);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.dataGridView_status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_BookingStatus";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_BookingStatus";
            this.Load += new System.EventHandler(this.Form_BookingStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_status)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        internal System.Windows.Forms.DataGridView dataGridView_status;
    }
}