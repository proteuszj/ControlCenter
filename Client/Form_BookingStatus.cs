
using System;
using System.Drawing;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_BookingStatus : Form
    {
        public string DateString;
        public string TimeString;

        public Form_BookingStatus()
        {
            InitializeComponent();
            for (int i = 0; i < Convert.ToByte(ConfigParameters.getValue("BOOKING_DATE_LIMIT")); i++)
            {
                dataGridView_status.Columns.Add($"column{i}", (DateTime.Now + TimeSpan.FromDays(i)).ToString("yyyy-MM-dd"));
                dataGridView_status.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
#if simpleBookingTime
            string sql = "select distinct(case when substr(DISPLAY_NAME,1,2)<12 then '上午' else '下午' end) from CFG_PARAM where PARAM_NAME like '__0000' and PARAM_VALUE='TRUE'";
#else
            string sql = "select DISPLAY_NAME from CFG_PARAM where PARAM_NAME like '__0000' and PARAM_VALUE='TRUE'";
#endif
            string[] names = mDBM.SelectArray(sql);
            if (names.Length > 0)
            {
                dataGridView_status.Rows.Add(names.Length);
                for (int i = 0; i < names.Length; i++)
                    dataGridView_status.Rows[i].HeaderCell.Value = names[i];
                for (int i = 0; i < Convert.ToByte(ConfigParameters.getValue("BOOKING_DATE_LIMIT")); i++)
                {
                    string dateString = (DateTime.Now + TimeSpan.FromDays(i)).ToString("yyyyMMdd");
#if simpleBookingTime
                    sql = $"select sum(booking_times) from (select distinct(case when substr(DISPLAY_NAME,1,2)<12 then '上午' else '下午' end) bookingTimePiece from cfg_param where param_name like '__0000' and param_value='TRUE') a left join bas_booking on case when substr(bas_booking.booking_datetime,9,2)<12 then '上午' else '下午' end =a.bookingTimePiece and substr(bas_booking.booking_datetime,1,8)={dateString} group by a.bookingTimePiece order by a.bookingTimePiece";
#else
                sql = $"select sum(booking_times) from (select param_name from cfg_param where param_name like '__0000' and param_value='TRUE') a left join bas_booking on substr(bas_booking.booking_datetime,9,6)=a.param_name and substr(bas_booking.booking_datetime,1,8)={dateString} group by a.param_name order by a.param_name";
#endif
                    string[] values = mDBM.SelectArray(sql);
                    for (int j = 0; j < names.Length; j++)
#if simpleBookingTime
                        if (i == 0 && ("上午" == dataGridView_status.Rows[j].HeaderCell.Value.ToString()) && (Convert.ToByte(DateTime.Now.ToString("hh")) >= 12))
#else
                    if (i == 0 && Convert.ToDateTime(dataGridView_status.Rows[j].HeaderCell.Value) < DateTime.Now.ToLocalTime())
#endif
                            dataGridView_status.Rows[j].Cells[i].Style.BackColor = dataGridView_status.Rows[j].Cells[i].Style.SelectionBackColor = Color.LightGray;
                        else dataGridView_status.Rows[j].Cells[i].Value = values[j];
                }
            }
        }

        private void Form_BookingStatus_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DateString) || string.IsNullOrEmpty(TimeString)) return;
            int rowIndex = -1, columnIndex = -1;
            for (int i = 0; i < dataGridView_status.ColumnCount; i++)
                if (DateString == dataGridView_status.Columns[i].HeaderText)
                {
                    columnIndex = i;
                    break;
                }
            for (int i = 0; i < dataGridView_status.RowCount; i++)
                if (TimeString == dataGridView_status.Rows[i].HeaderCell.Value.ToString())
                {
                    rowIndex = i;
                    break;
                }
            dataGridView_status.Rows[rowIndex].Cells[columnIndex].Selected = true;
        }

        private void dataGridView_status_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
#if simpleBookingTime
            if (0 == e.ColumnIndex && ("上午" == dataGridView_status.Rows[e.RowIndex].HeaderCell.Value.ToString()) && (Convert.ToByte(DateTime.Now.ToString("hh")) >= 12))
#else
            if (0 == e.ColumnIndex && Convert.ToDateTime(dataGridView_status.Rows[e.RowIndex].HeaderCell.Value) < DateTime.Now.ToLocalTime())
#endif
            {
                button_ok.Enabled = false;
                return;
            }
            DateString = dataGridView_status.Columns[e.ColumnIndex].HeaderCell.Value.ToString();
            TimeString = dataGridView_status.Rows[e.RowIndex].HeaderCell.Value.ToString();
            button_ok.Enabled = true;
        }
    }
}
