
using Client.IDReader;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_TrainBooking_confirm : Form
    {
        public string studentName;
        public string subjectName;
        public string times, amount;
        public string cashierName, cashierIDNumber;

        private void Form_TrainBooking_confirm_Load(object sender, EventArgs e)
        {
            label_studentName.Text = studentName;
            label_subject.Text = subjectName;
            label_times.Text = times;
            label_amount.Text = amount;
            btn_ok.Enabled = false;
        }

        private void button_readCard_Click(object sender, EventArgs e)
        {
            try
            {
                IDCardInfo info = IDCardReader.getInstance().CardInfo;
                textBox_name.Text = info.name;
                textBox_idNumber.Text = info.idNumber;
                btn_ok.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            cashierName = textBox_name.Text;
            cashierIDNumber = textBox_idNumber.Text;
        }

        public Form_TrainBooking_confirm()
        {
            InitializeComponent();
        }
    }
}
