using Client.IDReader;
using Client.TMRI;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_Student_appendModify : Form
    {
        public bool isAppend;

        public string name, gender, idType, idNo, driverType, schoolName;

        public byte[][] photoBytes = new byte[2][];

        private void button_downloadPhoto_Click(object sender, EventArgs e)
        {
            string message;
            Bitmap photo;
            if (!TMRIQuery.QueryPhoto(out message, idNo, out photo))
            {
                MessageBox.Show(message);
                return;
            }
            pictureBox_new.Image = photo;
            MemoryStream ms = new MemoryStream();
            photo.Save(ms, ImageFormat.Bmp);
            photoBytes[1] = ms.ToArray();
            MessageBox.Show($"学员：{idNo}照片下载成功");
        }

        private void button_readCard_Click(object sender, EventArgs e)
        {
            try
            {
                IDCardInfo info = IDCardReader.getInstance().CardInfo;
                textBox_name.Text = info.name;
                comboBox_idType.Text = "居民身份证";
                textBox_idNumber.Text = info.idNumber;
                switch (info.sex)
                {
                    case "男": comboBox_gender.Text = "男性"; break;
                    case "女": comboBox_gender.Text = "女性"; break;
                    default: comboBox_gender.Text = "未说明性别"; break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private byte[][] fingerPrintBytes = new byte[4][];

        public Form_Student_appendModify()
        {
            InitializeComponent();
        }

        private void Form_Student_append_Load(object sender, EventArgs e)
        {
            string sql;

            comboBox_gender.Items.Clear();
            sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=2001 order by VIEW_INDEX";
            comboBox_gender.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_idType.Items.Clear();
            sql = "select DICT_NAME from CFG_DICT where DICT_TYPE=2002 order by VIEW_INDEX";
            comboBox_idType.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_driverLicenseType.Items.Clear();
            sql = "select DICT_CODE from CFG_DICT where DICT_TYPE=2003 order by VIEW_INDEX";
            comboBox_driverLicenseType.Items.AddRange(mDBM.SelectArray(sql));

            comboBox_schoolName.Items.Clear();
            //sql = "select NAME from BAS_DRIVING_SCHOOL";
            sql = "select distinct school_name from bas_student";
            comboBox_schoolName.Items.AddRange(mDBM.SelectArray(sql));
            
            textBox_name.Text = name;
            textBox_idNumber.Text = idNo;
            comboBox_schoolName.Text = schoolName;

            comboBox_gender.SelectedIndex = comboBox_gender.Items.IndexOf(gender);
            comboBox_idType.SelectedIndex = comboBox_idType.Items.IndexOf(idType);
            comboBox_driverLicenseType.SelectedIndex = comboBox_driverLicenseType.Items.IndexOf(driverType);

            if (null != photoBytes[0])
                pictureBox_old.Image = new Bitmap(new MemoryStream(photoBytes[0]));
            if (null != photoBytes[1])
                pictureBox_new.Image = new Bitmap(new MemoryStream(photoBytes[1]));
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string message;

            if (String.IsNullOrEmpty(comboBox_idType.Text) ||
                String.IsNullOrEmpty(textBox_idNumber.Text) ||
                String.IsNullOrEmpty(textBox_name.Text) ||
                String.IsNullOrEmpty(comboBox_gender.Text) ||
                String.IsNullOrEmpty(comboBox_schoolName.Text) ||
 //               String.IsNullOrEmpty(textBox_password.Text) ||
                String.IsNullOrEmpty(comboBox_driverLicenseType.Text))
            {
                MessageBox.Show("数据不能为空", "提示");
                return;
            }

            // 添加检查重名
            if (isAppend)
            {
                string sql = "select * from BAS_STUDENT where IDNUMBER='" + textBox_idNumber.Text + "'";
                string[] names = mDBM.SelectArray(sql);

                if (names.Length > 0)
                {
                    MessageBox.Show("学员已存在", "错误");
                    return;
                }
            }

            mDBM.AddUpdateStudent(textBox_idNumber.Text, comboBox_idType.Text, textBox_name.Text,
                comboBox_gender.Text, comboBox_driverLicenseType.Text, comboBox_schoolName.Text, textBox_password.Text,
                photoBytes[0], photoBytes[1], fingerPrintBytes[0], fingerPrintBytes[1], fingerPrintBytes[2], fingerPrintBytes[3], out message);

            if (isAppend)
                MessageBox.Show("添加成功", "提示");
            else
                MessageBox.Show("修改成功", "提示");

            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
