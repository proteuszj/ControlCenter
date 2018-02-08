#define CAR_ALLOCATION_BROADCAST
using System;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static Client.DBM;

namespace Client
{
    public partial class Form_CarAllocation : Form
    {
        static readonly string __CarStatusSQL = "select " +
            "LICENSE_PLATE 车牌, " +
            "CARNUMBER 车辆编号, " +
            "QUALIFIED_CAR_TYPE 车辆类型, " +
            "PROCESS_TYPE_DICTNAME 项目状态, " +
            "EXAM_ITEM_DICTNAME 当前项目, " +
            "SEQUENCE_NUMBER 预约序号, " +
            "STUDENT_NAME 车上学员姓名, " +
            "STUDENT_IDNUMBER 车上学员身份证明号码, " +
            "BOOKING_TIMES 预约次数, " +
            "LEFT_TIMES 剩余次数, " +
            "BOOKING_STUDY_TIME 预约时间, " +
            "LEFT_STUDY_TIME 剩余时间, " +
            "USE_STATUS 使用状态 " +
            "from CAR_ALLOCATION_CAR_VIEW";
        static readonly string __WaitingStudentSQL = "select " +
            "SEQUENCE_NUMBER 预约序号, " +
            "NAME 姓名, " +
            "IDNUMBER 身份证明号码, " +
            "DRIVER_LICENSE_TYPE 考试车型, " +
            "BOOKING_CAR 预约车辆, " +
            "BOOKING_TIMES 预约次数, " +
            "LEFT_TIMES 剩余次数, " +
            "BOOKING_STUDY_TIME 预约时间, " +
            "LEFT_STUDY_TIME 剩余时间 " +
            "from CAR_ALLOCATION_STUDENT_VIEW";
        static readonly string __UpdateCarStatusSQL = "update BAS_CAR set USE_STATUS='{0}' where LICENSE_PLATE='{1}'";
        static readonly string __AllocateCarSQL = "update bas_booking set CAR_ID=(select ID from bas_car where LICENSE_PLATE='{0}') where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select ID from bas_student where IDNUMBER='{1}')";
        static readonly string __RevokeCarSQL = "update bas_booking set CAR_ID=null where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and CAR_ID=(select ID from bas_car where LICENSE_PLATE='{0}')";
        static readonly string __RevokeStudentCarSQL = "update bas_booking set CAR_ID=null where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select ID from bas_student where IDNUMBER='{0}')";
        static readonly string __UnusedBooking = "select * from bas_booking where BOOKING_EXAM_DATE=to_char(current_date, 'yyyymmdd') and STUDENT_ID=(select ID from bas_student where IDNUMBER='{0}') and not exists(select * from buz_exam_info where BOOKING_ID=bas_booking.ID)";

        TcpClient __TcpClient;

        public Form_CarAllocation()
        {
            InitializeComponent();
            DataTable car = mDBM.Select("select LICENSE_PLATE, CARNUMBER, QUALIFIED_CAR_TYPE, USE_STATUS from BAS_CAR").Tables[0];
            for (int i = 0; i < car.Rows.Count; i++)
                checkedListBox_carMaintenance.Items.Add($"{car.Rows[i]["QUALIFIED_CAR_TYPE"]}-{car.Rows[i]["CARNUMBER"]}({car.Rows[i]["LICENSE_PLATE"]})", car.Rows[i]["USE_STATUS"].ToString() == "A");
            numericUpDown_update.Value = Convert.ToInt32(mDBM.GetParameter("CAR_ALLOCATION_INTERVAL"));
            textBox_projectAddress.Text = mDBM.GetParameter("CAR_ALLOCATION_PROJECT_ADDRESS");
            textBox_projectPort.Text = mDBM.GetParameter("CAR_ALLOCATION_PROJECT_PORT");
            numericUpDown_projcetStudentCount.Value = Convert.ToInt32(mDBM.GetParameter("CAR_ALLOCATION_PROJECT_COUNT"));
            numericUpDown_waitingTimeout.Value = Convert.ToInt32(mDBM.GetParameter("CAR_ALLOCATION_WAITING_TIMEOUT"));

            if (0 == numericUpDown_update.Value)
                timer_allocate.Interval = 1000;
            else
                timer_allocate.Interval = (int)numericUpDown_update.Value * 1000;

            dataGridView_car.Columns.Add("车牌", "车牌");
            dataGridView_car.Columns.Add("车辆编号", "车辆编号");
            dataGridView_car.Columns.Add("车辆类型", "车辆类型");
            dataGridView_car.Columns.Add("项目状态", "项目状态");
            dataGridView_car.Columns.Add("当前项目", "当前项目");
            dataGridView_car.Columns.Add("预约序号", "预约序号");
            dataGridView_car.Columns.Add("车上学员姓名", "车上学员姓名");
            dataGridView_car.Columns.Add("车上学员身份证明号码", "车上学员身份证明号码");
            dataGridView_car.Columns.Add("预约次数", "预约次数");
            dataGridView_car.Columns.Add("剩余次数", "剩余次数");
            dataGridView_car.Columns.Add("预约时间", "预约时间");
            dataGridView_car.Columns.Add("剩余时间", "剩余时间");
            dataGridView_car.Columns.Add("使用状态", "使用状态");
            dataGridView_car.Columns.Add("分配学员姓名", "分配学员姓名");
            dataGridView_car.Columns.Add("分配学员身份证明号码", "分配学员身份证明号码");
            dataGridView_car.Columns["使用状态"].Visible = false;
            for (int i = 0; i < dataGridView_car.ColumnCount; i++)
                dataGridView_car.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            refreshCar();

            dataGridView_student.Columns.Add("预约序号", "预约序号");
            dataGridView_student.Columns.Add("姓名", "姓名");
            dataGridView_student.Columns.Add("身份证明号码", "身份证明号码");
            dataGridView_student.Columns.Add("考试车型", "考试车型");
            dataGridView_student.Columns.Add("预约车辆", "预约车辆");
            dataGridView_student.Columns.Add("预约次数", "预约次数");
            dataGridView_student.Columns.Add("剩余次数", "剩余次数");
            dataGridView_student.Columns.Add("预约时间", "预约时间");
            dataGridView_student.Columns.Add("剩余时间", "剩余时间");
            dataGridView_student.Columns.Add("状态", "状态");
            dataGridView_student.Columns.Add("更新时间", "更新时间");
            for (int i = 0; i < dataGridView_student.ColumnCount; i++)
                dataGridView_student.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            refreshStudent();

            button_manualAllocate.Enabled = dataGridView_student.RowCount > 0;
        }

        private void Form_CarAllocation_Activated(object sender, EventArgs e)
        {
            refreshCar();
            refreshStudent();
            timer_refresh.Start();
        }

        private void checkedListBox_carMaintenance_MouseEnter(object sender, EventArgs e)
        {
            (sender as CheckedListBox).Height = 200;
        }

        private void checkedListBox_carMaintenance_MouseLeave(object sender, EventArgs e)
        {
            (sender as CheckedListBox).Height = 20;
        }

        private void button_carMaintenance_Click(object sender, EventArgs e)
        {
            bool flag = timer_allocate.Enabled;
            if (flag) timer_allocate.Stop();
            for (int i = 0; i < checkedListBox_carMaintenance.Items.Count; i++)
            {
                string value = checkedListBox_carMaintenance.GetItemChecked(i) ? "A" : "B";
                string carInfo = checkedListBox_carMaintenance.Items[i].ToString();
                string carLicensePlate = carInfo.Substring(carInfo.IndexOf('(') + 1, carInfo.IndexOf(')') - carInfo.IndexOf('(') - 1);
                mDBM.ExecuteNonQuery(string.Format(__UpdateCarStatusSQL, value, carLicensePlate));
                if ("A" != value)
                    mDBM.ExecuteNonQuery(string.Format(__RevokeCarSQL, carLicensePlate));
            }
            mDBM.SetParameter(out string message, "CAR_ALLOCATION_INTERVAL", numericUpDown_update.Value.ToString());
            mDBM.SetParameter(out message, "CAR_ALLOCATION_PROJECT_ADDRESS", textBox_projectAddress.Text);
            mDBM.SetParameter(out message, "CAR_ALLOCATION_PROJECT_PORT", textBox_projectPort.Text);
            mDBM.SetParameter(out message, "CAR_ALLOCATION_PROJECT_COUNT", numericUpDown_projcetStudentCount.Value.ToString());
            mDBM.SetParameter(out message, "CAR_ALLOCATION_WAITING_TIMEOUT", numericUpDown_waitingTimeout.Value.ToString());

            MessageBox.Show("车辆维护信息写入成功", "提示");
            if (0 == numericUpDown_update.Value)
                timer_allocate.Interval = 1000;
            else
                timer_allocate.Interval = (int)numericUpDown_update.Value * 1000;
            refreshCar();
            refreshStudent();
            if (flag) timer_allocate.Start();
        }

        private void dataGridView_car_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                button_manualAllocate.Enabled = dataGridView_student.RowCount > 0 && "A" == dataGridView_car.Rows[e.RowIndex].Cells["使用状态"].Value.ToString() && dataGridView_student.SelectedRows[0].Cells["考试车型"].Value.ToString() == dataGridView_car.Rows[e.RowIndex].Cells["车辆类型"].Value.ToString() && "已叫号" != dataGridView_student.SelectedRows[0].Cells["状态"].Value.ToString();
        }

        private void dataGridView_student_SelectionChanged(object sender, EventArgs e)
        {
            if ((sender as DataGridView).SelectedRows.Count > 0)
            {
                int selectedIndex = (sender as DataGridView).SelectedRows[0].Index;
                button_up.Enabled = timer_allocate.Enabled && selectedIndex > numericUpDown_projcetStudentCount.Value || !timer_allocate.Enabled && selectedIndex > 0;
                button_down.Enabled = (timer_allocate.Enabled && selectedIndex >= numericUpDown_projcetStudentCount.Value || !timer_allocate.Enabled) && selectedIndex < dataGridView_student.RowCount - 1;
                button_manualAllocate.Enabled = "A" == dataGridView_car.SelectedRows[0].Cells["使用状态"].Value.ToString() && dataGridView_student.SelectedRows[0].Cells["考试车型"].Value.ToString() == dataGridView_car.SelectedRows[0].Cells["车辆类型"].Value.ToString() && "已叫号" != dataGridView_student.SelectedRows[0].Cells["状态"].Value.ToString();
                button_cancelManualAllocate.Enabled = !string.IsNullOrEmpty(dataGridView_student.SelectedRows[0].Cells["预约车辆"].Value.ToString()) && "已叫号" != dataGridView_student.SelectedRows[0].Cells["状态"].Value.ToString();
                button_reallocate.Enabled = "已叫号" == dataGridView_student.SelectedRows[0].Cells["状态"].Value.ToString();
            }
        }

        private void button_reallocate_Click(object sender, EventArgs e)
        {
            reallocate(dataGridView_student.SelectedRows[0].Index);
        }

        private void button_move_Click(object sender, EventArgs e)
        {
            if (dataGridView_student.SelectedRows.Count > 0)
            {
                int index = dataGridView_student.SelectedRows[0].Index;
                if (sender == button_up)
                {
                    dataGridView_student.Rows[index - 1].HeaderCell.Value = (index + 1).ToString();
                    index--;
                }
                else if (sender == button_down)
                {
                    dataGridView_student.Rows[index + 1].HeaderCell.Value = (index + 1).ToString();
                    index++;
                }
                else
                    return;
                moveRow(dataGridView_student, dataGridView_student.SelectedRows[0].Index, index);
                dataGridView_student.Rows[index].Selected = true;
                dataGridView_student.Rows[index].HeaderCell.Value = (index + 1).ToString();
            }
            for (int i = 0; i < dataGridView_student.RowCount; i++)
                dataGridView_student.Rows[i].DefaultCellStyle.BackColor = i < numericUpDown_projcetStudentCount.Value ? Color.Lime : SystemColors.Window;
        }

        private void button_AutoAllocate_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            if ("自动分车" == button.Text)
            {
                if (null == __TcpClient)
                    try
                    {
#if CAR_ALLOCATION_BROADCAST
                        __TcpClient = new TcpClient(textBox_projectAddress.Text, int.Parse(textBox_projectPort.Text));
#endif
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                button.Text = "停止分车";
                timer_allocate_Tick(timer_allocate, new EventArgs());
                timer_allocate.Start();
                dataGridView_student_SelectionChanged(dataGridView_student, new EventArgs());
            }
            else
            {
                button.Text = "自动分车";
                __TcpClient.Close();
                __TcpClient = null;
                timer_allocate.Stop();
                dataGridView_student_SelectionChanged(dataGridView_student, new EventArgs());
            }
        }

        private void button_manualAllocate_Click(object sender, EventArgs e)
        {
            allocateCar(dataGridView_car.SelectedRows[0].Cells["车牌"].Value.ToString(), dataGridView_student.SelectedRows[0].Cells["身份证明号码"].Value.ToString());
            refreshStudent();
        }

        private void button_cancelManualAllocate_Click(object sender, EventArgs e)
        {
            if (dataGridView_student.SelectedRows.Count > 0)
            {
                string idNumber = dataGridView_student.SelectedRows[0].Cells["身份证明号码"].Value.ToString();
                mDBM.ExecuteNonQuery(string.Format(__RevokeStudentCarSQL, idNumber));
                dataGridView_student.SelectedRows[0].Cells["预约车辆"].Value = string.Empty;
                (sender as Button).Enabled = false;
            }
        }

        private void timer_allocate_Tick(object sender, EventArgs e)
        {
            mDBM.DBMutex.WaitOne();
            int index, calledIndex;
            if (dataGridView_student.RowCount > 0)
            {
                index = 0;
                for (int i = 0; i < dataGridView_student.RowCount; i++)
                {
                    string announceTime = dataGridView_student.Rows[index].Cells["更新时间"].Value.ToString();
                    if (!string.IsNullOrEmpty(announceTime) && DateTime.Now > Convert.ToDateTime(announceTime).AddMinutes((double)numericUpDown_waitingTimeout.Value))
                        reallocate(index);
                    else
                        index++;
                }

                for (int i = 0; i < dataGridView_car.RowCount; i++)
                    if ((string.IsNullOrEmpty(dataGridView_car.Rows[i].Cells["项目状态"].Value.ToString()) || "考试科目结束" == dataGridView_car.Rows[i].Cells["项目状态"].Value.ToString()) &&
                        "A" == dataGridView_car.Rows[i].Cells["使用状态"].Value.ToString() &&
                        string.IsNullOrEmpty(dataGridView_car.Rows[i].Cells["分配学员姓名"].Value.ToString()) &&
                        (string.IsNullOrEmpty(dataGridView_car.Rows[i].Cells["剩余次数"].Value.ToString()) || "0" == dataGridView_car.Rows[i].Cells["剩余次数"].Value.ToString()) &&
                        (string.IsNullOrEmpty(dataGridView_car.Rows[i].Cells["剩余时间"].Value.ToString()) || "0" == dataGridView_car.Rows[i].Cells["剩余时间"].Value.ToString()))
                    {
                        string carLicensePlate = dataGridView_car.Rows[i].Cells["车牌"].Value.ToString();
                        string carNumber = dataGridView_car.Rows[i].Cells["车辆编号"].Value.ToString();
                        string qualifiedCarType = dataGridView_car.Rows[i].Cells["车辆类型"].Value.ToString();
                        index = 0;
                        calledIndex = 0;
                        string bookedCar = dataGridView_student.Rows[index].Cells["预约车辆"].Value.ToString();
                        string licenseType = dataGridView_student.Rows[index].Cells["考试车型"].Value.ToString();
                        while (index < dataGridView_student.RowCount &&
                            (!string.IsNullOrEmpty(bookedCar) && bookedCar != carNumber || qualifiedCarType != licenseType || "已叫号" == dataGridView_student.Rows[index].Cells["状态"].Value.ToString()))
                        {
                            if ("已叫号" == dataGridView_student.Rows[index].Cells["状态"].Value.ToString()) calledIndex++;
                            index++;
                            if (index < dataGridView_student.RowCount)
                            {
                                bookedCar = dataGridView_student.Rows[index].Cells["预约车辆"].Value.ToString();
                                licenseType = dataGridView_student.Rows[index].Cells["考试车型"].Value.ToString();
                            }
                        }
                        if (index < dataGridView_student.RowCount)
                        {
                            if (string.IsNullOrEmpty(bookedCar)) allocateCar(carLicensePlate, dataGridView_student.Rows[index].Cells["身份证明号码"].Value.ToString());

                            string name = dataGridView_student.Rows[index].Cells["姓名"].Value.ToString();
                            string idNumber = dataGridView_student.Rows[index].Cells["身份证明号码"].Value.ToString();
                            dataGridView_car.Rows[i].Cells["分配学员姓名"].Value = name;
                            dataGridView_car.Rows[i].Cells["分配学员身份证明号码"].Value = idNumber;
                            dataGridView_student.Rows[index].Cells["状态"].Value = "已叫号";
                            dataGridView_student.Rows[index].Cells["更新时间"].Value = DateTime.Now.ToString("HH:mm:ss");
                            if (index > calledIndex)
                            {
                                moveRow(dataGridView_student, index, calledIndex);
                            }
                            richTextBox_announce.AppendText($"学员：{name}（{idNumber}）请上车：{carNumber}" + Console.Out.NewLine);
                            announce($"{name},{idNumber},{carNumber}");
                        }
                    }

                calledIndex = 0;
                bool isC1 = true;
                for (int i = 0; i < dataGridView_student.RowCount; i++)
                {
                    if ("已叫号" == dataGridView_student.Rows[i].Cells["状态"].Value.ToString()) calledIndex++;
                    else if (i <= calledIndex)
                    {
                        while (calledIndex < dataGridView_student.RowCount && isC1 == ("C1" == dataGridView_student.Rows[calledIndex].Cells["考试车型"].Value.ToString()))
                        {
                            calledIndex++;
                            isC1 = !isC1;
                        }
                        if (calledIndex >= dataGridView_student.RowCount) break;
                    }
                    else
                    {
                        if (isC1 == ("C1" == dataGridView_student.Rows[i].Cells["考试车型"].Value.ToString()))
                        {
                            moveRow(dataGridView_student, i, calledIndex);
                            while (calledIndex < dataGridView_student.RowCount && isC1 == ("C1" == dataGridView_student.Rows[calledIndex].Cells["考试车型"].Value.ToString()))
                            {
                                calledIndex++;
                                isC1 = !isC1;
                            }
                            if (calledIndex >= dataGridView_student.RowCount) break;
                        }
                    }
                }
            }

            refreshCar();
            refreshStudent();

            if (null != __TcpClient)
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = false,
                    OmitXmlDeclaration = true
                };
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb, settings);
                int count = 0;
                for (int i = 0; i < dataGridView_car.RowCount; i++)
                    if (!string.IsNullOrEmpty(dataGridView_car.Rows[i].Cells["车上学员姓名"].Value.ToString())) count++;
                writer.WriteStartElement("StudentInfoList");
                int countStudent = dataGridView_student.RowCount;
                if (numericUpDown_projcetStudentCount.Value < countStudent)
                    countStudent = (int)numericUpDown_projcetStudentCount.Value;

                writer.WriteAttributeString("count", (count + countStudent).ToString());
                for (int i = 0; i < dataGridView_car.RowCount; i++)
                    if (!string.IsNullOrEmpty(dataGridView_car.Rows[i].Cells["车上学员姓名"].Value.ToString()))
                    {
                        writer.WriteStartElement("StudentInfo");
                        writer.WriteAttributeString("no", "0");
                        writer.WriteAttributeString("sequenceNumber", dataGridView_car.Rows[i].Cells["预约序号"].Value.ToString());
                        writer.WriteAttributeString("name", dataGridView_car.Rows[i].Cells["车上学员姓名"].Value.ToString());
                        writer.WriteAttributeString("idnumber", dataGridView_car.Rows[i].Cells["车上学员身份证明号码"].Value.ToString());
                        writer.WriteAttributeString("driverLicenseType", dataGridView_car.Rows[i].Cells["车辆类型"].Value.ToString());
                        writer.WriteAttributeString("bookingCar", dataGridView_car.Rows[i].Cells["车辆编号"].Value.ToString());
                        writer.WriteAttributeString("bookingTimes", dataGridView_car.Rows[i].Cells["预约次数"].Value.ToString());
                        writer.WriteAttributeString("bookingLeftTimes", dataGridView_car.Rows[i].Cells["剩余次数"].Value.ToString());
                        writer.WriteAttributeString("bookingStudyTime", dataGridView_car.Rows[i].Cells["预约时间"].Value.ToString());
                        writer.WriteAttributeString("bookingLeftStudyTime", dataGridView_car.Rows[i].Cells["剩余时间"].Value.ToString());
                        writer.WriteAttributeString("status", "已上车");
                        writer.WriteEndElement();
                    }
                for (int i = 0; i < countStudent; i++)
                {
                    writer.WriteStartElement("StudentInfo");
                    writer.WriteAttributeString("no", (i + 1).ToString());
                    writer.WriteAttributeString("sequenceNumber", dataGridView_student.Rows[i].Cells["预约序号"].Value.ToString());
                    writer.WriteAttributeString("name", dataGridView_student.Rows[i].Cells["姓名"].Value.ToString());
                    writer.WriteAttributeString("idnumber", dataGridView_student.Rows[i].Cells["身份证明号码"].Value.ToString());
                    writer.WriteAttributeString("driverLicenseType", dataGridView_student.Rows[i].Cells["考试车型"].Value.ToString());
                    writer.WriteAttributeString("bookingCar", dataGridView_student.Rows[i].Cells["预约车辆"].Value.ToString());
                    writer.WriteAttributeString("bookingTimes", dataGridView_student.Rows[i].Cells["预约次数"].Value.ToString());
                    writer.WriteAttributeString("bookingLeftTimes", dataGridView_student.Rows[i].Cells["剩余次数"].Value.ToString());
                    writer.WriteAttributeString("bookingStudyTime", dataGridView_student.Rows[i].Cells["预约时间"].Value.ToString());
                    writer.WriteAttributeString("bookingLeftStudyTime", dataGridView_student.Rows[i].Cells["剩余时间"].Value.ToString());
                    writer.WriteAttributeString("status", dataGridView_student.Rows[i].Cells["状态"].Value.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.Close();
                NetworkStream ns = __TcpClient.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(sb.ToString());
                ns.WriteByte((byte)(data.Length >> 24));
                ns.WriteByte((byte)(data.Length >> 16));
                ns.WriteByte((byte)(data.Length >> 8));
                ns.WriteByte((byte)(data.Length));
                for (int i = 0; i < data.Length; i++)
                    ns.WriteByte(data[i]);
                ns.Flush();

                //FileStream fs = new FileStream(Application.StartupPath + @"\log.xml", FileMode.Append);
                //fs.Write(data, 0, data.Length);
                //fs.Close();

            }
            mDBM.DBMutex.ReleaseMutex();
        }

        private void timer_refresh_Tick(object sender, EventArgs e)
        {
            mDBM.DBMutex.WaitOne();
            refreshCar();
            refreshStudent();
            mDBM.DBMutex.ReleaseMutex();
        }

        void refreshCar()
        {
            int selectedIndex = 0 == dataGridView_car.SelectedRows.Count ? 0 : dataGridView_car.SelectedRows[0].Index;

            DataTable dataTable = mDBM.Select(__CarStatusSQL).Tables[0];

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int j = i;
                for (; j < dataGridView_car.RowCount; j++)
                    if (dataTable.Rows[i]["车牌"].ToString() == dataGridView_car.Rows[j].Cells["车牌"].Value.ToString()) break;
                if (j < dataGridView_car.RowCount)
                {
                    string allocatedStudentName = dataGridView_car.Rows[j].Cells["分配学员姓名"].Value.ToString();
                    string allocatedStudentIDNumber = dataGridView_car.Rows[j].Cells["分配学员身份证明号码"].Value.ToString();
                    if (!string.IsNullOrEmpty(allocatedStudentIDNumber) && 0 == mDBM.Select(string.Format(__UnusedBooking, allocatedStudentIDNumber)).Tables[0].Rows.Count)
                    //if (!string.IsNullOrEmpty(dataGridView_car.Rows[j].Cells["车上学员姓名"].Value.ToString()) && string.IsNullOrEmpty(dataTable.Rows[i]["车上学员姓名"].ToString()))
                    {
                        allocatedStudentName = string.Empty;
                        allocatedStudentIDNumber = string.Empty;
                    }

                    if (j != i)
                    {
                        dataGridView_car.Rows.RemoveAt(j);
                        dataGridView_car.Rows.Insert(i, 1);
                    }
                    dataGridView_car.Rows[i].Cells["分配学员姓名"].Value = allocatedStudentName;
                    dataGridView_car.Rows[i].Cells["分配学员身份证明号码"].Value = allocatedStudentIDNumber;
                }
                else
                {
                    dataGridView_car.Rows.Insert(i, 1);
                    dataGridView_car.Rows[i].Cells["分配学员姓名"].Value = string.Empty;
                    dataGridView_car.Rows[i].Cells["分配学员身份证明号码"].Value = string.Empty;
                }
                dataGridView_car.Rows[i].Cells["车牌"].Value = dataTable.Rows[i]["车牌"].ToString();
                dataGridView_car.Rows[i].Cells["车辆编号"].Value = dataTable.Rows[i]["车辆编号"].ToString();
                dataGridView_car.Rows[i].Cells["车辆类型"].Value = dataTable.Rows[i]["车辆类型"].ToString();
                dataGridView_car.Rows[i].Cells["项目状态"].Value = dataTable.Rows[i]["项目状态"].ToString();
                dataGridView_car.Rows[i].Cells["当前项目"].Value = dataTable.Rows[i]["当前项目"].ToString();
                dataGridView_car.Rows[i].Cells["预约序号"].Value = dataTable.Rows[i]["预约序号"].ToString();
                dataGridView_car.Rows[i].Cells["车上学员姓名"].Value = dataTable.Rows[i]["车上学员姓名"].ToString();
                dataGridView_car.Rows[i].Cells["车上学员身份证明号码"].Value = dataTable.Rows[i]["车上学员身份证明号码"].ToString();
                dataGridView_car.Rows[i].Cells["预约次数"].Value = dataTable.Rows[i]["预约次数"].ToString();
                dataGridView_car.Rows[i].Cells["剩余次数"].Value = dataTable.Rows[i]["剩余次数"].ToString();
                dataGridView_car.Rows[i].Cells["预约时间"].Value = dataTable.Rows[i]["预约时间"].ToString();
                dataGridView_car.Rows[i].Cells["剩余时间"].Value = dataTable.Rows[i]["剩余时间"].ToString();
                dataGridView_car.Rows[i].Cells["使用状态"].Value = dataTable.Rows[i]["使用状态"].ToString();
            }

            if (dataGridView_car.RowCount > 0)
                dataGridView_car.Rows[selectedIndex].Selected = true;
            for (int i = 0; i < dataGridView_car.RowCount; i++)
                if ("A" == dataGridView_car.Rows[i].Cells["使用状态"].Value.ToString())
                {
                    dataGridView_car.Rows[i].DefaultCellStyle.BackColor = SystemColors.Window;
                    dataGridView_car.Rows[i].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                }
                else
                {
                    dataGridView_car.Rows[i].Cells["分配学员姓名"].Value = string.Empty;
                    dataGridView_car.Rows[i].Cells["分配学员身份证明号码"].Value = string.Empty;
                    dataGridView_car.Rows[i].DefaultCellStyle.BackColor = SystemColors.Control;
                    dataGridView_car.Rows[i].DefaultCellStyle.ForeColor = SystemColors.ControlDark;
                }
        }

        void refreshStudent()
        {
            int selectedIndex = 0 == dataGridView_student.SelectedRows.Count ? 0 : dataGridView_student.SelectedRows[0].Index;

            DataTable dataTable = mDBM.Select(__WaitingStudentSQL).Tables[0];

            for (int i = 0; i < dataGridView_student.RowCount; i++)
            {
                bool found = false;
                for (int j = 0; j < dataTable.Rows.Count; j++)
                    if (dataGridView_student.Rows[i].Cells["身份证明号码"].Value.ToString() == dataTable.Rows[j]["身份证明号码"].ToString())
                    {
                        found = true;
                        break;
                    }
                if (!found)
                {
                    dataGridView_student.Rows.RemoveAt(i);
                    i--;
                }
            }

            for (int j = 0; j < dataTable.Rows.Count; j++)
            {
                bool found = false;
                int index = 0;
                for (; index < dataGridView_student.RowCount; index++)
                    if (dataGridView_student.Rows[index].Cells["身份证明号码"].Value.ToString() == dataTable.Rows[j]["身份证明号码"].ToString())
                    {
                        found = true;
                        break;
                    }
                if (!found)
                {
                    index = dataGridView_student.Rows.Add();
                    dataGridView_student.Rows[index].Cells["预约序号"].Value = dataTable.Rows[j]["预约序号"];
                    dataGridView_student.Rows[index].Cells["姓名"].Value = dataTable.Rows[j]["姓名"];
                    dataGridView_student.Rows[index].Cells["身份证明号码"].Value = dataTable.Rows[j]["身份证明号码"];
                    dataGridView_student.Rows[index].Cells["考试车型"].Value = dataTable.Rows[j]["考试车型"];
                    dataGridView_student.Rows[index].Cells["预约车辆"].Value = dataTable.Rows[j]["预约车辆"];
                    dataGridView_student.Rows[index].Cells["预约次数"].Value = dataTable.Rows[j]["预约次数"];
                    dataGridView_student.Rows[index].Cells["剩余次数"].Value = dataTable.Rows[j]["剩余次数"];
                    dataGridView_student.Rows[index].Cells["预约时间"].Value = dataTable.Rows[j]["预约时间"];
                    dataGridView_student.Rows[index].Cells["剩余时间"].Value = dataTable.Rows[j]["剩余时间"];
                    dataGridView_student.Rows[index].Cells["状态"].Value = "未叫号";
                    dataGridView_student.Rows[index].Cells["更新时间"].Value = string.Empty;
                }
                else
                    dataGridView_student.Rows[index].Cells["预约车辆"].Value = dataTable.Rows[j]["预约车辆"];
            }

            if (dataGridView_student.RowCount > 0)
            {
                if (selectedIndex >= dataGridView_student.RowCount)
                    selectedIndex = dataGridView_student.RowCount - 1;
                dataGridView_student.Rows[selectedIndex].Selected = true;
            }

            int count = (int)numericUpDown_projcetStudentCount.Value;
            if (dataGridView_student.RowCount < count)
                count = dataGridView_student.RowCount;
            for (int i = 0; i < dataGridView_student.RowCount; i++)
            {
                dataGridView_student.Rows[i].DefaultCellStyle.BackColor = i < count ? Color.Lime : SystemColors.Window;
                dataGridView_student.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

            if (dataGridView_student.SelectedRows.Count > 0)
                dataGridView_student_SelectionChanged(dataGridView_student, new EventArgs());
        }

        void allocateCar(string licensePlate, string idNumber)
        {
            mDBM.ExecuteNonQuery(string.Format(__AllocateCarSQL, licensePlate, idNumber));
        }

        void announce(string announceText)
        {
            //richTextBox_announce.AppendText(announceText + Console.Out.NewLine);

            if (null != __TcpClient)
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = false,
                    OmitXmlDeclaration = true
                };
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb, settings);

                writer.WriteStartElement("Broadcast");
                writer.WriteAttributeString("content", announceText);
                writer.Close();
                NetworkStream ns = __TcpClient.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(sb.ToString());
                ns.WriteByte((byte)(data.Length >> 24));
                ns.WriteByte((byte)(data.Length >> 16));
                ns.WriteByte((byte)(data.Length >> 8));
                ns.WriteByte((byte)(data.Length));
                for (int i = 0; i < data.Length; i++)
                    ns.WriteByte(data[i]);
                ns.Flush();
            }
        }

        void reallocate(int studentIndex)
        {
            if (studentIndex < 0 || studentIndex >= dataGridView_student.RowCount) return;
            DataGridViewRow row = dataGridView_student.Rows[studentIndex];
            for (int i = 0; i < dataGridView_car.RowCount; i++)
                if (dataGridView_car.Rows[i].Cells["分配学员身份证明号码"].Value.ToString() == row.Cells["身份证明号码"].Value.ToString())
                {
                    dataGridView_car.Rows[i].Cells["分配学员姓名"].Value = string.Empty;
                    dataGridView_car.Rows[i].Cells["分配学员身份证明号码"].Value = string.Empty;
                    break;
                }
            string name = row.Cells["姓名"].Value.ToString();
            string idNumber = row.Cells["身份证明号码"].Value.ToString();
            mDBM.ExecuteNonQuery(string.Format(__RevokeStudentCarSQL, idNumber));
            row.Cells["预约车辆"].Value = string.Empty;
            row.Cells["状态"].Value = "过号重排";
            row.Cells["更新时间"].Value = string.Empty;
            moveRow(dataGridView_student, studentIndex, dataGridView_student.RowCount - 1);
            richTextBox_announce.AppendText($"学员：{name}（{idNumber}）等待超时，过号重排" + Console.Out.NewLine);
            announce($"{name},{idNumber}");
        }

        void moveRow(DataGridView dgv, int sourceIndex, int targetIndex)
        {
            if (sourceIndex == targetIndex || sourceIndex >= dgv.Rows.Count || targetIndex >= dgv.Rows.Count) return;

            DataGridViewRow row = dgv.Rows[sourceIndex];
            DataGridViewRow newRow = new DataGridViewRow();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell
                {
                    Value = row.Cells[i].Value
                };
                newRow.Cells.Add(cell);
            }
            if (targetIndex > sourceIndex) targetIndex++;
            dgv.Rows.Insert(targetIndex, newRow);
            dgv.Rows.Remove(row);
        }
    }
}