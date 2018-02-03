
using Client.TMRI;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
using static Client.DBM;

//todo: optimize use ConfigParameters;
namespace Client
{
    public partial class Form_Config : Form
    {
        internal static string ServiceSerialNumber
        {
            get
            {
                if (string.IsNullOrEmpty(__ServiceSerialNumber))
                    __ServiceSerialNumber = mDBM.Select("select PARAM_VALUE from CFG_PARAM where PARAM_NAME='SERVICE_SERIAL_NUMBER'").Tables[0].Rows[0][0].ToString();
                return __ServiceSerialNumber;
            }
        }

        internal static int LoginTimeout
        {
            get
            {
                if (string.IsNullOrEmpty(__LoginTimeout))
                {
                    __LoginTimeout = mDBM.Select("select PARAM_VALUE from CFG_PARAM where PARAM_NAME='LOGIN_TIMEOUT'").Tables[0].Rows[0][0].ToString();
                    if (string.IsNullOrEmpty(__LoginTimeout))
                        __LoginTimeout = "0";
                }
                return Convert.ToInt32(__LoginTimeout);
            }
        }

        public Form_Config()
        {
            InitializeComponent();
            __ParamAdapter = new OracleDataAdapter("select PARAM_NAME,PARAM_VALUE from CFG_PARAM", mDBM.conn);
            __TerminalListAdapter = new OracleDataAdapter(@"select MAC, IP, MAX_FAILURE_COUNT 终端错误计数器上限, LOCK_DURATION 终端锁定时间 from SYS_TERMINAL_LIST", mDBM.conn);
            new OracleCommandBuilder(__ParamAdapter);
            new OracleCommandBuilder(__TerminalListAdapter);
        }

        private void Form_Config_Load(object sender, EventArgs e)
        {
            __ParamDataSet.Clear();
            __ParamAdapter.Fill(__ParamDataSet);
            if (__ParamDataSet.Tables.Count > 0)
                for (int i = 0; i < __ParamDataSet.Tables[0].Rows.Count; i++)
                {
                    string name = __ParamDataSet.Tables[0].Rows[i]["PARAM_NAME"].ToString();
                    string value = __ParamDataSet.Tables[0].Rows[i]["PARAM_VALUE"].ToString();
                    switch (name)
                    {
                        case "SERVICE_URL": textBox_ServiceURL.Text = value; break;
                        case "SERVICE_SERIAL_NUMBER": textBox_ServiceSerialNumber.Text = value; break;
                        case "PLACE_SERIAL_NUMBER": textBox_PlaceSerialNumber.Text = value; break;
                        case "PLACE_CODE": textBox_PlaceCode.Text = value; break;
                        case "SYSTEM_SERIAL_NUMBER": textBox_SystemSerialNumber.Text = value; break;
                        case "DEFAULT_USER_MAX_FAILURE_COUNT": textBox_DefaultUserMaxFailureCount.Text = value; break;
                        case "DEFAULT_TERMINAL_MAX_FAILURE_COUNT": textBox_DefaultTerminalMaxFailureCount.Text = value; break;
                        case "PASSWORD_VALID_PERIOD": textBox_PasswordValidPeriod.Text = value; break;
                        case "TERMINAL_LOCK_DURATION": textBox_TerminalLockDuration.Text = value; break;
                        case "LOGIN_TIMEOUT": textBox_LoginTimeout.Text = value; break;
                        case "CAR_ENABLED_FINGER": checkBox_FingerPrint.Checked = "1" == value; break;
                        case "CAR_ENABLED_CAPTUREPIC": checkBox_Capture.Checked = "1" == value; break;
                        case "AUTO_UPGRADE": checkBox_AutoUpgrade.Checked = "1" == value; break;
                        default:
                            break;
                    }
                }//end of for

            __TerminalListDataSet.Clear();
            __TerminalListAdapter.Fill(__TerminalListDataSet);
            dataGridView_TerminalList.DataSource = __TerminalListDataSet.Tables[0];
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string message;
            if (__ParamDataSet.Tables.Count > 0)
            {
                //__ParamDataSet.Tables[0].Columns["PARAM_NAME"].Unique = true;
                for (int i = 0; i < __ParamDataSet.Tables[0].Rows.Count; i++)
                {
                    string name = __ParamDataSet.Tables[0].Rows[i]["PARAM_NAME"].ToString();
                    switch (name)
                    {
                        case "SERVICE_URL": mDBM.SetParameter(out message, name, textBox_ServiceURL.Text); break;
                        case "SERVICE_SERIAL_NUMBER": mDBM.SetParameter(out message, name, textBox_ServiceSerialNumber.Text); break;
                        case "PLACE_SERIAL_NUMBER": mDBM.SetParameter(out message, name, textBox_PlaceSerialNumber.Text); break;
                        case "PLACE_CODE": mDBM.SetParameter(out message, name, textBox_PlaceCode.Text); break;
                        case "SYSTEM_SERIAL_NUMBER": mDBM.SetParameter(out message, name, textBox_SystemSerialNumber.Text); break;
                        case "DEFAULT_USER_MAX_FAILURE_COUNT": mDBM.SetParameter(out message, name, textBox_DefaultUserMaxFailureCount.Text); break;
                        case "DEFAULT_TERMINAL_MAX_FAILURE_COUNT": mDBM.SetParameter(out message, name, textBox_DefaultTerminalMaxFailureCount.Text); break;
                        case "PASSWORD_VALID_PERIOD": mDBM.SetParameter(out message, name, textBox_PasswordValidPeriod.Text); break;
                        case "TERMINAL_LOCK_DURATION": mDBM.SetParameter(out message, name, textBox_TerminalLockDuration.Text); break;
                        case "LOGIN_TIMEOUT": mDBM.SetParameter(out message, name, textBox_LoginTimeout.Text); break;
                        case "CAR_ENABLED_FINGER": mDBM.SetParameter(out message, name, checkBox_FingerPrint.Checked ? "1" : "0"); break;
                        case "CAR_ENABLED_CAPTUREPIC": mDBM.SetParameter(out message, name, checkBox_Capture.Checked ? "1" : "0"); break;
                        case "AUTO_UPGRADE": mDBM.SetParameter(out message, name, checkBox_AutoUpgrade.Checked ? "1" : "0"); break;
                        default: break;
                    }
                }
                // __ParamAdapter.Update(__ParamDataSet);
            }
            if (__TerminalListDataSet.Tables.Count > 0)
                __TerminalListAdapter.Update(__TerminalListDataSet);

            string filePath = openFileDialog_UpdatePackage.FileName;
            if (!string.IsNullOrEmpty(filePath))
            {//open file
             //calculate SHA1
             //get package version
                string version = "2.17.10.1";

                OracleCommand cmd = new OracleCommand("AddLog", mDBM.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("loginName", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("module", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("action", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("content", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("result", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("ip", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("mac", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters["loginName"].Value = Form_Main.LoginName;
                cmd.Parameters["module"].Value = "系统";
                cmd.Parameters["action"].Value = "修改";
                cmd.Parameters["content"].Value = $"评判系统升级，版本号{version}";
                cmd.Parameters["result"].Value = "1";
                cmd.Parameters["ip"].Value = Form_Main.terminalIP;
                cmd.Parameters["mac"].Value = Form_Main.terminalMAC;
                cmd.ExecuteNonQuery();
            }

            __LoginTimeout = textBox_LoginTimeout.Text;
            __ServiceSerialNumber = textBox_ServiceSerialNumber.Text;
        }

        private void button_TimeSync_Click(object sender, EventArgs e)
        {
            string message;
            bool flag = TMRIQuery.QueryTime(out message, textBox_SystemSerialNumber.Text);
            MessageBox.Show(message);
            if (flag)
                MessageBox.Show("时间同步成功");
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog_UpdatePackage.ShowDialog())
                textBox_UpgradePackage.Text = openFileDialog_UpdatePackage.FileName;
        }

        private static OracleDataAdapter __TerminalListAdapter;
        private static DataSet __TerminalListDataSet = new DataSet();
        private static OracleDataAdapter __ParamAdapter;
        private static DataSet __ParamDataSet = new DataSet();
        private static string __ServiceSerialNumber;
        private static string __LoginTimeout;
    }
}
