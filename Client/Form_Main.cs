
using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
 using static Client.DBM;

namespace Client
{
    public partial class Form_Main : Form
    {
        private IniFile iniFile = null;
        public const string INIFILE_NAME = ".\\Management.ini";
        internal static string terminalIP;
        internal static string terminalMAC;
        internal static string LoginName;
        internal static string RoleName;
        Form_CarAllocation __Form_CarAllocation;

        public Form subForm = null;

        public Form_Password form_password;// 密码修改
        public Form_DBConfig form_DBConfig;// 数据库连接设置
        public Form_Help form_help;// 操作说明

        // 菜单项显示文本和菜单项名称对应
        public struct MenuItemStruct
        {
            public string[] itemText;
            public string[] itemName;
        };
        public MenuItemStruct menuItems;
        public string getItemText(string itemName)
        {
            return menuItems.itemText[Array.IndexOf(menuItems.itemName, itemName)];
        }

        public Form_Main()
        {
            InitializeComponent();

            timer_op.Stop();
            timer_start.Stop();

            // IP
            terminalIP = "";
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    terminalIP = _IPAddress.ToString();
                    break;
                }
            }
            if (string.IsNullOrEmpty(terminalIP)) terminalIP = "127.0.0.1";

            // MAC
            terminalMAC = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo["IPEnabled"].ToString() == "True")
                {
                    terminalMAC = mo["MacAddress"].ToString();
                    break;
                }
            }
            if (string.IsNullOrEmpty(terminalMAC)) terminalMAC = "00-00-00-00-00-00";

            string productName = ((AssemblyProductAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0]).Product;
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
#if DEBUG
            version += "[DEBUG]";
#endif
            this.Text = String.Format($"{productName} v{version}" );
            toolStripLabel_role.Text = "未登录";
        }

        private void Form_Main_Shown(object sender, EventArgs e)
        {
            // 计算两级菜单的总数
            int count = menuStrip_main.Items.Count;
            foreach (ToolStripMenuItem con in this.menuStrip_main.Items)
            {
                count += con.DropDownItems.Count;
            }
            menuItems.itemText = new string[count];
            menuItems.itemName = new string[count];
            // 获取所有菜单项的名字和显示文本
            int x = 0;
            foreach (ToolStripMenuItem con in this.menuStrip_main.Items)
            {
                menuItems.itemText[x] = con.Text;
                menuItems.itemName[x++] = con.Name;
                foreach (ToolStripItem con2 in con.DropDownItems)
                {
                    menuItems.itemText[x] = con2.Text;
                    menuItems.itemName[x++] = con2.Name;
                }
            }

            // 登录窗口
            ToolStripMenuItem_Click(登录ToolStripMenuItem, new EventArgs());
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(mDBM.loginName))
                    mDBM.Logout();
                mDBM.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Dispose();
                Application.Exit();
            }
        }

        /// <summary>
        /// 登录框
        /// </summary>
        /// <param name="name">返回登录名</param>
        /// <param name="role">返回角色名</param>
        /// <returns>-1：取消，0：失败，1：成功</returns>
        public int LoginBox(out string name, out string role)
        {
            name = role = "";

            Form LoginForm = new Form();
            LoginForm.MinimizeBox = false;
            LoginForm.MaximizeBox = false;
            LoginForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            LoginForm.StartPosition = FormStartPosition.CenterScreen;
            LoginForm.Width = 420;
            LoginForm.Height = 230;
            LoginForm.Text = "登录";

            Label lbl_name = new Label();
            lbl_name.Text = "登录名：";
            lbl_name.Left = 92;
            lbl_name.Top = 44;
            lbl_name.Parent = LoginForm;
            lbl_name.AutoSize = true;

            TextBox textBox_name = new TextBox();
            textBox_name.Left = 151;
            textBox_name.Top = 41;
            textBox_name.Width = 160;
            textBox_name.Parent = LoginForm;
            textBox_name.Text = "";

            Label lbl_password = new Label();
            lbl_password.Text = "密码：";
            lbl_password.Left = 92;
            lbl_password.Top = 86;
            lbl_password.Parent = LoginForm;
            lbl_password.AutoSize = true;

            TextBox textBox_password = new TextBox();
            textBox_password.Left = 151;
            textBox_password.Top = 83;
            textBox_password.Width = 160;
            textBox_password.Parent = LoginForm;
            textBox_password.Text = "";
            textBox_password.PasswordChar = '*';

            Button btn_DBConfig = new Button();
            btn_DBConfig.Left = 80;
            btn_DBConfig.Top = 145;
            btn_DBConfig.Parent = LoginForm;
            btn_DBConfig.Text = "数据库连接设置";
            btn_DBConfig.DialogResult = DialogResult.Yes;

            Button btn_login = new Button();
            btn_login.Left = 165;
            btn_login.Top = 145;
            btn_login.Parent = LoginForm;
            btn_login.Text = "登录";
            LoginForm.AcceptButton = btn_login;//回车响应
            btn_login.DialogResult = DialogResult.OK;

            Button btn_cancel = new Button();
            btn_cancel.Left = 251;
            btn_cancel.Top = 145;
            btn_cancel.Parent = LoginForm;
            btn_cancel.Text = "取消";
            btn_cancel.DialogResult = DialogResult.Cancel;
            LoginForm.CancelButton = btn_cancel;

            try
            {
                switch (LoginForm.ShowDialog())
                {
                    case DialogResult.OK:
                        // 读取连接配置文件
                        if (!File.Exists(INIFILE_NAME))
                        {
                            MessageBox.Show("缺少数据库连接配置文件", "错误");
                            return 0;
                        }

                        iniFile = new IniFile(INIFILE_NAME);
                        string DBAddress = iniFile.ReadValue("DBConfig", "DB Address");
                        string DBName = iniFile.ReadValue("DBConfig", "DB Name");
                        string userName = iniFile.ReadValue("DBConfig", "User Name");

                        try
                        {
                            string password = Algo.DESDecrypt(iniFile.ReadValue("DBConfig", "Password"));
                            mDBM.Open($"User Id={userName};Password={password};Data Source={DBAddress}/{DBName};Min Pool Size=0; Connection Timeout=5");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());

                            // 数据库连接设置
                            if (form_DBConfig == null || form_DBConfig.IsDisposed)
                                form_DBConfig = new Form_DBConfig();
                            form_DBConfig.ShowDialog();

                            return 0;
                        }

                        string message;
                        int index = mDBM.Login(textBox_name.Text, textBox_password.Text, out message);
                        if (index == 1)
                        {
                            MessageBox.Show(message, "提示");

                            if (form_password == null || form_password.IsDisposed)
                                form_password = new Form_Password();

                            if (form_password.ShowDialog() != DialogResult.OK)
                                return -1;
                        }
                        else if (index != 0)
                        {
                            if (-5 == index)//用户已登录
                            {
                                if (DialogResult.Yes == MessageBox.Show(message + ", 是否强制注销", "登录失败", MessageBoxButtons.YesNo))
                                {
                                    mDBM.loginName = textBox_name.Text;
                                    mDBM.Logout();
                                }
                            }
                            else
                                MessageBox.Show(message, "登录失败");
                            return 0;
                        }
                        else
                            MessageBox.Show(message, "提示");

                        name = mDBM.loginName;
                        role = mDBM.roleName;
                        if (Form_Config.LoginTimeout > 0)
                        {
                            timer_op.Interval = Form_Config.LoginTimeout * 60 * 1000;
                            timer_op.Start();
                            timer_start.Start();
                        }
                        else
                        {
                            timer_op.Stop();
                            timer_start.Stop();
                        }
                        return 1;

                    case DialogResult.Yes:
                        if (form_DBConfig == null || form_DBConfig.IsDisposed)
                            form_DBConfig = new Form_DBConfig();
                        form_DBConfig.ShowDialog();
                        return 0;

                    default:
                        return -1;
                }
            }
            finally
            {
                LoginForm.Close();
                LoginForm.Dispose();
            }
        }

        /// <summary>
        /// 注销或未登录后界面处理
        /// </summary>
        public void LogoutPermissionProcess()
        {
            // 断开数据库连接
            if (mDBM != null)
            {
                if (!String.IsNullOrEmpty(mDBM.loginName))
                    mDBM.Logout();
                mDBM.Close();
            }

            // 关闭当前窗口
            if (subForm != null && !subForm.IsDisposed)
            {
                subForm.Close();
                subForm.Dispose();
            }

            // 界面处理
            toolStripLabel_role.Text = "未登录";

            string[] permissionList = {
                "系统操作ToolStripMenuItem", "登录ToolStripMenuItem", "退出ToolStripMenuItem",
                "帮助ToolStripMenuItem", "操作说明ToolStripMenuItem", "关于ToolStripMenuItem"
            };

            foreach (ToolStripMenuItem con in this.menuStrip_main.Items)
            {
                if (con.Name.Equals("帮助ToolStripMenuItem"))
                    con.Enabled = true;
                else if (permissionList.Contains(con.Name))
                    con.Enabled = true;
                else
                    con.Enabled = false;

                foreach (ToolStripItem con2 in con.DropDownItems)
                {
                    if (con2.Name.Equals("操作说明ToolStripMenuItem"))
                        con2.Enabled = true;
                    else if (con2.Name.Equals("登录ToolStripMenuItem"))
                        con2.Enabled = true;
                    else if (con2.Name.Equals("关于ToolStripMenuItem"))
                        con2.Enabled = true;
                    else if (permissionList.Contains(con2.Name))
                        con2.Enabled = true;
                    else
                        con2.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 登录后权限关联界面处理
        /// </summary>
        public void LoginPermissionProcess(string roleName)
        {
            string[] permissionList = mDBM.getRolePermissions(roleName);

            foreach (ToolStripMenuItem con in this.menuStrip_main.Items)
            {
                if (con.Name.Equals("帮助ToolStripMenuItem"))
                    con.Enabled = true;
                else if (permissionList.Contains(getItemText(con.Name)))
                    con.Enabled = true;
                else
                    con.Enabled = false;

                foreach (ToolStripItem con2 in con.DropDownItems)
                {
                    if (con2.Name.Equals("操作说明ToolStripMenuItem"))
                        con2.Enabled = true;
                    else if (con2.Name.Equals("关于ToolStripMenuItem"))
                        con2.Enabled = true;
                    else if (con2.Name.Equals("登录ToolStripMenuItem"))
                        con2.Enabled = false;
                    else if (con2.Name.Equals("注销ToolStripMenuItem"))
                        con2.Enabled = true;
                    else if (con2.Name.Equals("退出ToolStripMenuItem"))
                        con2.Enabled = true;
                    else if (permissionList.Contains(getItemText(con2.Name)))
                        con2.Enabled = true;
                    else
                        con2.Enabled = false;
                }
            }
        }
        private Form getSubForm(Type tt)
        {
            //if (!tt.IsSubclassOf(typeof(Form))) return null;
            //if (tt.IsInstanceOfType(subForm)) return null;

            if (subForm != null && !subForm.IsDisposed && !(subForm is Form_CarAllocation))
            {
                subForm.Close();
                subForm.Dispose();
            }

            if (tt == typeof(Form_CarAllocation) && null != __Form_CarAllocation)
                subForm = __Form_CarAllocation;
            else
            {
                ConstructorInfo ci = tt.GetConstructor(new Type[] { });
                subForm = (Form)ci.Invoke(null);
                subForm.MdiParent = this;
                subForm.WindowState = FormWindowState.Maximized;
                if (subForm is Form_CarAllocation)
                    __Form_CarAllocation = (Form_CarAllocation)subForm;
            }
            return subForm;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                switch ((sender as ToolStripMenuItem).Name)
                {
                    case "登录ToolStripMenuItem":
                        int result = LoginBox(out LoginName, out RoleName);
                        if (result == 1)
                        {
                            toolStripLabel_role.Text = $"【用户】: {LoginName}, 【角色】: {RoleName}，【MAC】：{terminalMAC}，【IP】：{terminalIP}";
                            LoginPermissionProcess(RoleName);
                        }
                        else if (result == 0)
                        {
                            LogoutPermissionProcess();
                            ToolStripMenuItem_Click(登录ToolStripMenuItem, new EventArgs());
                        }
                        else
                            LogoutPermissionProcess();
                        break;
                    case "密码修改ToolStripMenuItem":
                        if (form_password == null || form_password.IsDisposed)
                            form_password = new Form_Password();
                        if (DialogResult.Abort == form_password.ShowDialog())   //ChangePassword executed but failed
                            LogoutPermissionProcess();
                        break;
                    case "注销ToolStripMenuItem":
                        LogoutPermissionProcess();
                        ToolStripMenuItem_Click(登录ToolStripMenuItem, new EventArgs());
                        break;
                    case "退出ToolStripMenuItem":
                        if (mDBM != null)
                        {
                            if (!String.IsNullOrEmpty(mDBM.loginName))
                                mDBM.Logout();
                            mDBM.Close();
                        }

                        Dispose();
                        Application.Exit();
                        break;
                    case "预约计次培训ToolStripMenuItem":
                        getSubForm(typeof(Form_TrainBooking));
                        ((Form_TrainBooking)subForm).TrainingMode = Form_TrainBooking.TrainingModeEnum.ByTimes;
                        subForm.Text = "预约计次培训";
                        subForm.Show();
                        break;
                    case "预约计时培训ToolStripMenuItem":
                        getSubForm(typeof(Form_TrainBooking));
                        ((Form_TrainBooking)subForm).TrainingMode = Form_TrainBooking.TrainingModeEnum.ByTime;
                        subForm.Text = "预约计时培训";
                        subForm.Show();
                        break;
                    case "支付流水ToolStripMenuItem":
                        getSubForm(typeof(Form_PaymentDetail)).Show();
                        break;
                    case "分车叫号ToolStripMenuItem":
                        getSubForm(typeof(Form_CarAllocation)).Show();
                        break;
                    case "过程查询ToolStripMenuItem":
                        getSubForm(typeof(Form_Process)).Show();
                        break;
                    case "预约及签到ToolStripMenuItem":
                        getSubForm(typeof(Form_Booking)).Show();
                        break;
                    case "分组及分车ToolStripMenuItem":
                        getSubForm(typeof(Form_Grouping)).Show();
                        break;
                    case "考试状态ToolStripMenuItem":
                        getSubForm(typeof(Form_ExamStatus)).Show();
                        break;
                    case "成绩打印ToolStripMenuItem":
                        getSubForm(typeof(Form_StudentExam)).Show();
                        break;
                    case "综合统计ToolStripMenuItem":
                        getSubForm(typeof(Form_SummaryStatistices)).Show();
                        break;
                    case "综合查询ToolStripMenuItem":
                        getSubForm(typeof(Form_SummaryQuery)).Show();
                        break;
                    case "场地信息ToolStripMenuItem":
                        getSubForm(typeof(Form_PlaceInfo)).Show();
                        break;
                    case "设备信息ToolStripMenuItem":
                        getSubForm(typeof(Form_DeviceInfo)).Show();
                        break;
                    case "车辆信息ToolStripMenuItem":
                        getSubForm(typeof(Form_CarInfo)).Show();
                        break;
                    case "考试员信息ToolStripMenuItem":
                        getSubForm(typeof(Form_ExaminerInfo)).Show();
                        break;
                    case "驾校信息ToolStripMenuItem":
                        getSubForm(typeof(Form_SchoolInfo)).Show();
                        break;
                    case "支付定价ToolStripMenuItem":
                        getSubForm(typeof(Form_PricingStrategy)).Show();
                        break;
                    case "数据库连接设置ToolStripMenuItem":
                        if (form_DBConfig == null || form_DBConfig.IsDisposed)
                            form_DBConfig = new Form_DBConfig();
                        form_DBConfig.ShowDialog();
                        break;
                    case "参数设置ToolStripMenuItem":
                        new Form_Config().ShowDialog();
                        break;
                    case "用户管理ToolStripMenuItem":
                        getSubForm(typeof(Form_User)).Show();
                        break;
                    case "权限管理ToolStripMenuItem":
                        getSubForm(typeof(Form_Permission)).Show();
                        break;
                    case "日志查询ToolStripMenuItem":
                        getSubForm(typeof(Form_LogQuery)).Show();
                        break;
                    case "审计查询ToolStripMenuItem":
                        getSubForm(typeof(Form_Audit)).Show();
                        break;
                    case "操作说明ToolStripMenuItem":
                        if (form_help == null || form_help.IsDisposed)
                            form_help = new Form_Help();
                        form_help.ShowDialog();
                        break;
                    case "关于ToolStripMenuItem":
                        AboutBox aboutBox = new AboutBox();
                        aboutBox.ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                LogoutPermissionProcess();
            }
        }

        private void timer_start_Tick(object sender, EventArgs e)
        {
            (sender as Timer).Start();
            if (!timer_op.Enabled)
                timer_op.Start();
        }

        private void timer_op_Tick(object sender, EventArgs e)
        {
            timer_op.Stop();
            timer_start.Stop();
            MessageBox.Show("操作超时，请重新登录");
            LogoutPermissionProcess();
            ToolStripMenuItem_Click(登录ToolStripMenuItem, new EventArgs());
        }

        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            timer_op.Stop();
        }

        private void Form_Main_MouseMove(object sender, MouseEventArgs e)
        {
            timer_op.Stop();
        }
    }
}
