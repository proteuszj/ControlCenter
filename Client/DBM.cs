
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Client
{
    /// <summary>
    /// 数据库管理类
    /// </summary>
    public class DBM
    {
        public OracleConnection conn;

        public string loginName, roleName;

        public static DBM mDBM = new DBM();// 数据库操作管理类

        public DBM()
        {
            conn = null;
        }

        public void Open(string connString)
        {
            conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            loginName = null;
            roleName = null;
        }

        public void Close()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();

                loginName = null;
                roleName = null;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql">SQL查询语句</param>
        /// <returns>查询结果数据集</returns>
        public DataSet Select(string sql)
        {
            OracleDataAdapter oda = new OracleDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            oda.Fill(ds);

            return ds;
        }

        /// <summary>
        /// 查询一个字段并返回字符串数组的结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string[] SelectArray(string sql)
        {
            OracleDataAdapter oda = new OracleDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            oda.Fill(ds);

            string[] array = new string[ds.Tables[0].Rows.Count];
            for (int x = 0; x < array.Length; x++)
                array[x] = ds.Tables[0].Rows[x][0].ToString();

            return array;
        }

        public int ExecuteNonQuery(string sql)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">登录名</param>
        /// <param name="password">密码</param>
        /// <param name="message">返回信息</param>
        /// <returns>0:登录成功, 1:登录成功请修改密码, -1:用户不存在, -2:用户已锁定, -3:终端已锁定, -4:密码连续错误, -5:用户已登录, -6:用户不在登录有效期内, -7:用户不在授权登录时间内, -8:终端不在授权列表</returns>
        public int Login(string name, string password, out string message)
        {
            // hash password
            byte[] pwd = Encoding.Default.GetBytes(password);
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] output = sha1.ComputeHash(pwd);
            sha1.Dispose();

            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Login";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                // 返回值必须是第一个参数
                new OracleParameter("ReturnValue", OracleDbType.Int32, 0, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Default, Convert.DBNull),
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("loginName", OracleDbType.Varchar2),
                new OracleParameter("passwordSHA1", OracleDbType.Varchar2),
                new OracleParameter("hostIP", OracleDbType.Varchar2),
                new OracleParameter("hostMAC", OracleDbType.Varchar2)
            };

            param[1].Direction = ParameterDirection.Output;
            for (int i = 2; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[2].Value = name;
            param[3].Value = Utils.convertByteArrayToHexString(output);
            param[4].Value = Form_Main.terminalIP;
            param[5].Value = Form_Main.terminalMAC;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            int res = Convert.ToInt32(param[0].Value.ToString());
            if ((res == 0) || (res == 1))
            {
                loginName = name;
                roleName = param[1].Value.ToString();
                message = roleName.Substring(roleName.IndexOf('，') + 1);
                roleName = roleName.Substring(0, roleName.IndexOf('，'));
            }
            else
            {
                loginName = null;
                roleName = null;
                message = param[1].Value.ToString();
            }
            return res;
        }

        /// <summary>
        /// 用户注销
        /// </summary>
        public void Logout()
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Logout";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = { new OracleParameter("loginName", OracleDbType.Varchar2),
                new OracleParameter("ip", OracleDbType.Varchar2),
                new OracleParameter("mac", OracleDbType.Varchar2) };

            foreach (OracleParameter p in param)
                p.Direction = ParameterDirection.Input;

            param[0].Value = loginName;
            param[1].Value = Form_Main.terminalIP;
            param[2].Value = Form_Main.terminalMAC;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            loginName = null;
            roleName = null;
        }

        /// <summary>
        /// 修改当前用户的密码
        /// </summary>
        /// <param name="oldPassword">旧密码值</param>
        /// <param name="newPassword">新密码值</param>
        /// <param name="hostIP">IP地址</param>
        /// <param name="hostMAC">MAC地址</param>
        /// <param name="message">返回信息</param>
        /// <returns>0:密码修改成功, -1:用户不存在, -2:用户未登录, -3:密码连续错误</returns>
        public int ChangePassword(string oldPassword, string newPassword, out string message)
        {
            string oldPasswordSHA1, newPasswordSHA1;

            // hash password
            byte[] pwd = Encoding.Default.GetBytes(oldPassword);
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] output = sha1.ComputeHash(pwd);
            oldPasswordSHA1 = Utils.convertByteArrayToHexString(output);

            pwd = Encoding.Default.GetBytes(newPassword);
            sha1 = new SHA1CryptoServiceProvider();
            output = sha1.ComputeHash(pwd);
            newPasswordSHA1 = Utils.convertByteArrayToHexString(output);

            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "ChangePassword";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                // 返回值必须是第一个参数
                new OracleParameter("ReturnValue", OracleDbType.Int32, 0, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Default, Convert.DBNull),
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("loginName", OracleDbType.Varchar2),
                new OracleParameter("oldPasswordSHA1", OracleDbType.Varchar2),
                new OracleParameter("newPasswordSHA1", OracleDbType.Varchar2),
                new OracleParameter("hostIP", OracleDbType.Varchar2),
                new OracleParameter("hostMAC", OracleDbType.Varchar2),
            };

            param[1].Direction = ParameterDirection.Output;
            for (int i = 2; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[2].Value = this.loginName;
            param[3].Value = oldPasswordSHA1;
            param[4].Value = newPasswordSHA1;
            param[5].Value = Form_Main.terminalIP;
            param[6].Value = Form_Main.terminalMAC;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[1].Value.ToString();
            return Convert.ToInt32(param[0].Value.ToString());
        }

        /// <summary>
        /// 解锁用户
        /// </summary>
        /// <param name="loginName">用户登录名</param>
        /// <param name="message">返回信息</param>
        /// <returns>0:解锁成功, -1:操作员不存在, -2:用户不存在, -3:操作员权限不足</returns>
        public int UnblockUser(string loginName, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UnblockUser";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                // 返回值必须是第一个参数
                new OracleParameter("ReturnValue", OracleDbType.Int32, 0, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Default, Convert.DBNull),
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("operatorLoginName", OracleDbType.Varchar2),
                new OracleParameter("loginName", OracleDbType.Varchar2),
                new OracleParameter("hostIP", OracleDbType.Varchar2),
                new OracleParameter("hostMAC", OracleDbType.Varchar2),
            };

            param[1].Direction = ParameterDirection.Output;
            for (int i = 2; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[2].Value = this.loginName;
            param[3].Value = loginName;
            param[4].Value = Form_Main.terminalIP;
            param[5].Value = Form_Main.terminalMAC;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[1].Value.ToString();
            return Convert.ToInt32(param[0].Value.ToString());
        }

        /// <summary>
        /// 增加或修改用户
        /// </summary>
        /// <param name="loginName">用户登录名</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="gender">用户性别</param>
        /// <param name="idNo">用户身份证号码</param>
        /// <param name="userFlag">用户标识</param>
        /// <param name="userNo">用户编号</param>
        /// <param name="fp1">用户指纹1</param>
        /// <param name="maxFailureCount">用户登录鉴别失败次数上限</param>
        /// <param name="passwordModifyDate">密码修改日期</param>
        /// <param name="enableDate">用户启用日期</param>
        /// <param name="disableDate">用户停用日期</param>
        /// <param name="roleName">角色名称</param>
        /// <param name="qualifiedStartTime">允许登录开始时间</param>
        /// <param name="qualifiedEndTime">允许登录结束时间</param>
        /// <param name="qualifiedAddressList">允许登录的IP/MAC地址列表</param>
        /// <param name="message">返回信息</param>
        /// <returns>0:成功, 其它:失败</returns>
        public int AddUpateUser(string loginName, string userName, string gender, string idNo, string userFlag, string userNo,
            byte[] fp1, string maxFailureCount, string passwordModifyDate, string enableDate, string disableDate, string roleName,
            string qualifiedStartTime, string qualifiedEndTime, string qualifiedAddressList, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "addUpdateUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new OracleParameter("ReturnValue", OracleDbType.Int32, 0, null, ParameterDirection.ReturnValue));
            cmd.Parameters.Add(new OracleParameter("message", OracleDbType.Varchar2, 1000, null, ParameterDirection.Output));
            cmd.Parameters.Add(new OracleParameter("operatorLoginName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("loginName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("userName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("gender", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("idNo", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("userFlag", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("userNo", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("fp1", OracleDbType.Blob, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("maxFailureCount", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("passwordModifyDate", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("enableDate", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("disableDate", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("roleName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("qualifiedStartTime", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("qualifiedEndTime", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("qualifiedAddressList", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters["operatorLoginName"].Value = this.loginName;
            cmd.Parameters["loginName"].Value = loginName;
            cmd.Parameters["userName"].Value = userName;
            cmd.Parameters["gender"].Value = gender;
            cmd.Parameters["idNo"].Value = idNo;
            cmd.Parameters["userFlag"].Value = userFlag;
            cmd.Parameters["userNo"].Value = userNo;
            cmd.Parameters["fp1"].Value = fp1;
            cmd.Parameters["maxFailureCount"].Value = maxFailureCount;
            cmd.Parameters["passwordModifyDate"].Value = passwordModifyDate;
            cmd.Parameters["enableDate"].Value = enableDate;
            cmd.Parameters["disableDate"].Value = disableDate;
            cmd.Parameters["roleName"].Value = roleName;
            cmd.Parameters["qualifiedStartTime"].Value = qualifiedStartTime;
            cmd.Parameters["qualifiedEndTime"].Value = qualifiedEndTime;
            cmd.Parameters["qualifiedAddressList"].Value = qualifiedAddressList;

            cmd.ExecuteNonQuery();

            message = cmd.Parameters["message"].Value.ToString();
            return Convert.ToInt32(cmd.Parameters["ReturnValue"].Value.ToString());
        }

        internal int GenerateSUB2(out string message, string examID)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "GenerateSUB2";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new OracleParameter("ReturnValue", OracleDbType.Int32, 0, null, ParameterDirection.ReturnValue));
            cmd.Parameters.Add(new OracleParameter("message", OracleDbType.Varchar2, 1000, null, ParameterDirection.Output));
            cmd.Parameters.Add(new OracleParameter("operatorLoginName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("examID", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("hostIP", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("hostMAC", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters["operatorLoginName"].Value = loginName;
            cmd.Parameters["examID"].Value = examID;
            cmd.Parameters["hostIP"].Value = Form_Main.terminalIP;
            cmd.Parameters["hostMAC"].Value = Form_Main.terminalMAC;

            cmd.ExecuteNonQuery();

            message = cmd.Parameters["message"].Value.ToString();
            return Convert.ToInt32(cmd.Parameters["ReturnValue"].Value.ToString());
        }

        internal void HandleMisjudge(out string message, string description)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "HandleMisjudge";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new OracleParameter("message", OracleDbType.Varchar2, 1000, null, ParameterDirection.Output));
            cmd.Parameters.Add(new OracleParameter("operatorLoginName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("description", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("hostIP", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("hostMAC", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters["operatorLoginName"].Value = loginName;
            cmd.Parameters["description"].Value = description;
            cmd.Parameters["hostIP"].Value = Form_Main.terminalIP;
            cmd.Parameters["hostMAC"].Value = Form_Main.terminalMAC;

            cmd.ExecuteNonQuery();

            message = cmd.Parameters["message"].Value.ToString();
        }

        internal int RemoveUser(out string message, string loginName)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "RemoveUser";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new OracleParameter("ReturnValue", OracleDbType.Int32, 0, null, ParameterDirection.ReturnValue));
            cmd.Parameters.Add(new OracleParameter("message", OracleDbType.Varchar2, 1000, null, ParameterDirection.Output));
            cmd.Parameters.Add(new OracleParameter("operatorLoginName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("loginName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("hostIP", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("hostMAC", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters["operatorLoginName"].Value = this.loginName;
            cmd.Parameters["loginName"].Value = loginName;
            cmd.Parameters["hostIP"].Value = Form_Main.terminalIP ;
            cmd.Parameters["hostMAC"].Value = Form_Main.terminalMAC;

            cmd.ExecuteNonQuery();

            message = cmd.Parameters["message"].Value.ToString();
            return Convert.ToInt32(cmd.Parameters["ReturnValue"].Value.ToString());
        }

        internal string GetParameter(string parameterName)
        {
            return Select($"select PARAM_VALUE from CFG_PARAM where PARAM_NAME='{parameterName}'").Tables[0].Rows[0][0].ToString();
        }

        internal int SetParameter(out string message, string parameterName, string parameterValue)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SetParameter";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new OracleParameter("ReturnValue", OracleDbType.Int32, 0, null, ParameterDirection.ReturnValue));
            cmd.Parameters.Add(new OracleParameter("message", OracleDbType.Varchar2, 1000, null, ParameterDirection.Output));
            cmd.Parameters.Add(new OracleParameter("operatorLoginName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("parameterName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("parameterValue", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("hostIP", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("hostMAC", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters["operatorLoginName"].Value = this.loginName;
            cmd.Parameters["parameterName"].Value = parameterName;
            cmd.Parameters["parameterValue"].Value = parameterValue;
            cmd.Parameters["hostIP"].Value = Form_Main.terminalIP;
            cmd.Parameters["hostMAC"].Value = Form_Main.terminalMAC;

            cmd.ExecuteNonQuery();

            message = cmd.Parameters["message"].Value.ToString();
            return Convert.ToInt32(cmd.Parameters["ReturnValue"].Value.ToString());
        }

        /// <summary>
        /// 增加角色
        /// </summary>
        /// <param name="roleName">角色名</param>
        /// <param name="message">返回消息</param>
        /// <returns>0:成功, -1:角色已存在：</returns>
        public int AddRole(string roleName, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "AddRole";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                // 返回值必须是第一个参数
                new OracleParameter("ReturnValue", OracleDbType.Int32, 0, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Default, Convert.DBNull),
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("operatorLoginName", OracleDbType.Varchar2),
                new OracleParameter("roleName", OracleDbType.Varchar2),
                new OracleParameter("hostIP", OracleDbType.Varchar2),
                new OracleParameter("hostMAC", OracleDbType.Varchar2),
            };

            param[1].Direction = ParameterDirection.Output;
            for (int i = 2; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[2].Value = this.loginName;
            param[3].Value = roleName;
            param[4].Value = Form_Main.terminalIP;
            param[5].Value = Form_Main.terminalMAC;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[1].Value.ToString();
            return Convert.ToInt32(param[0].Value.ToString());
        }

        /// <summary>
        /// 返回角色具有的全部权限
        /// </summary>
        /// <param name="roleName">角色名</param>
        /// <returns>权限列表</returns>
        public string[] getRolePermissions(string roleName)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "getRolePermissions";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("roleName", OracleDbType.Varchar2),
                new OracleParameter("permissionNames", OracleDbType.Varchar2, 1000)
            };

            param[0].Direction = ParameterDirection.Input;
            param[1].Direction = ParameterDirection.Output;

            param[0].Value = roleName;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            string[] names = param[1].Value.ToString().Split(',');
            for (int x = 0; x < names.Length; x++)
            {
                if (names[x].StartsWith("*"))
                    names[x] = names[x].Remove(0, 1);
            }
            return names;
        }

        /// <summary>
        /// 增加权限
        /// </summary>
        /// <param name="roleName">角色名</param>
        /// <param name="permissionName">权限名</param>
        /// <param name="message">信息</param>
        /// <returns>0：成功，-1：角色不存在，-2：权限不存在，-3：授权不存在</returns>
        public int GrantRolePermission(string roleName, string permissionName, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "GrantRolePermission";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                // 返回值必须是第一个参数
                new OracleParameter("ReturnValue", OracleDbType.Int32, 200, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Default, Convert.DBNull),
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("operatorLoginName", OracleDbType.Varchar2),
                new OracleParameter("roleName", OracleDbType.Varchar2),
                new OracleParameter("permissionName", OracleDbType.Varchar2)
            };

            param[1].Direction = ParameterDirection.Output;
            for (int i = 2; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[2].Value = this.loginName;
            param[3].Value = roleName;
            param[4].Value = permissionName;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[1].Value.ToString();
            return Convert.ToInt32(param[0].Value.ToString());
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="roleName">角色名</param>
        /// <param name="permissionName">权限名</param>
        /// <param name="message">0：成功，-1：角色不存在，-2：权限不存在</param>
        /// <returns></returns>
        public int RevokeRolePermission(string roleName, string permissionName, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "RevokeRolePermission";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                // 返回值必须是第一个参数
                new OracleParameter("ReturnValue", OracleDbType.Int32, 200, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Default, Convert.DBNull),
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("operatorLoginName", OracleDbType.Varchar2),
                new OracleParameter("roleName", OracleDbType.Varchar2),
                new OracleParameter("permissionName", OracleDbType.Varchar2)
            };

            param[1].Direction = ParameterDirection.Output;
            for (int i = 2; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[2].Value = this.loginName;
            param[3].Value = roleName;
            param[4].Value = permissionName;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[1].Value.ToString();
            return Convert.ToInt32(param[0].Value.ToString());
        }

        /// <summary>
        /// 增加学员
        /// </summary>
        /// <param name="idType">身份证明类型</param>
        /// <param name="idNo">身份证明号码</param>
        /// <param name="studentName">学员姓名</param>
        /// <param name="gender">性别</param>
        /// <param name="password">密码</param>
        /// <param name="driverLicenseType">驾驶证类型/考试车型</param>
        /// <param name="message">错误信息或姓名</param>
        /// <returns>0:成功, -1:证件号码重复</returns>
        public int AddStudent(string idType, string idNo, string studentName, string gender, string password, string driverLicenseType, out string message)
        {
            // hash password
            byte[] pwd = Encoding.Default.GetBytes(password);
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] output = sha1.ComputeHash(pwd);
            sha1.Dispose();

            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "AddStudent";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                // 返回值必须是第一个参数
                new OracleParameter("ReturnValue", OracleDbType.Int32, 0, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Default, Convert.DBNull),
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("operatorLoginName", OracleDbType.Varchar2),
                new OracleParameter("idType", OracleDbType.Varchar2),
                new OracleParameter("idNo", OracleDbType.Varchar2),
                new OracleParameter("studentName", OracleDbType.Varchar2),
                new OracleParameter("gender", OracleDbType.Varchar2),
                new OracleParameter("password", OracleDbType.Varchar2),
                new OracleParameter("driverLicenseType", OracleDbType.Varchar2)
            };

            param[1].Direction = ParameterDirection.Output;
            for (int i = 2; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[2].Value = this.loginName;
            param[3].Value = idType;
            param[4].Value = idNo;
            param[5].Value = studentName;
            param[6].Value = gender;
            param[7].Value = Utils.convertByteArrayToHexString(output);
            param[8].Value = driverLicenseType;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[1].Value.ToString();
            return Convert.ToInt32(param[0].Value.ToString());
        }

        /// <summary>
        /// 学员预约训练
        /// </summary>
        /// <param name="studentIdNumber">学员身份证号码</param>
        /// <param name="subjectName">训练科目</param>
        /// <param name="times">预约次数</param>
        /// <param name="amount">金额</param>
        /// <param name="paymentWay">支付方式</param>
        /// <param name="bookingDatetime">预约时间</param>
        /// <param name="carLicensePlate">指定车辆号牌</param>
        /// <param name="cashierName">收银员姓名</param>
        /// <param name="cashierIDNumber">收银员身份证号码</param>
        /// <param name="message">返回信息</param>
        /// <returns>
        ///     0：成功
        ///     -1：操作员不存在
        ///     -2：学员不存在
        ///     -3：金额不正确
        ///     -4：车辆不存在
        /// </returns>
        public int BookFromManagement(string studentIdNumber, string subjectName, int times, string amount, string paymentWay, string bookingDatetime,string carLicensePlate, string cashierName, string cashierIDNumber, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "BookFromManagement";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new OracleParameter("ReturnValue", OracleDbType.Int32, 0, null, ParameterDirection.ReturnValue));
            cmd.Parameters.Add(new OracleParameter("message", OracleDbType.Varchar2, 1000, null, ParameterDirection.Output));
            cmd.Parameters.Add(new OracleParameter("operatorLoginName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("studentIDNumber", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("subjectName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("times", OracleDbType.Int32, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("amount", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("paymentWay", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("bookingDatetime", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("carLicensePlate", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("cashierName", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("cashierIDNumber", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("hostIP", OracleDbType.Varchar2, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("hostMAC", OracleDbType.Varchar2, ParameterDirection.Input));

            cmd.Parameters["operatorLoginName"].Value = loginName;
            cmd.Parameters["studentIDNumber"].Value = studentIdNumber;
            cmd.Parameters["subjectName"].Value = subjectName;
            cmd.Parameters["times"].Value = times;
            cmd.Parameters["amount"].Value = amount;
            cmd.Parameters["paymentWay"].Value = paymentWay;
            cmd.Parameters["bookingDatetime"].Value = bookingDatetime;
            cmd.Parameters["carLicensePlate"].Value = carLicensePlate;
            cmd.Parameters["cashierName"].Value = cashierName;
            cmd.Parameters["cashierIDNumber"].Value = cashierIDNumber;
            cmd.Parameters["hostIP"].Value = Form_Main.terminalIP;
            cmd.Parameters["hostMAC"].Value = Form_Main.terminalMAC;

            cmd.ExecuteNonQuery();

            message = cmd.Parameters["message"].Value.ToString();
            return Convert.ToInt32(cmd.Parameters["ReturnValue"].Value.ToString());
        }

        /// <summary>
        /// 增加修改学员信息
        /// </summary>
        /// <param name="idNo">身份证明号码</param>
        /// <param name="idTypeName">身份证明类型</param>
        /// <param name="studentName">姓名</param>
        /// <param name="studentGender">性别</param>
        /// <param name="driverLicenseType">驾驶证类型</param>
        /// <param name="schoolName">驾校名称</param>
        /// <param name="password">密码</param>
        /// <param name="photoA">照片-老</param>
        /// <param name="photoB">照片-新</param>
        /// <param name="fingerPrintA">指纹1</param>
        /// <param name="fingerPrintB">指纹2</param>
        /// <param name="fingerPrintC">指纹3</param>
        /// <param name="fingerPrintD">指纹4</param>
        /// <param name="message">信息</param>
        public void AddUpdateStudent(string idNo, string idTypeName, string studentName, string studentGender, string driverLicenseType, string schoolName, string password, byte[] photoA, byte[] photoB, byte[] fingerPrintA, byte[] fingerPrintB, byte[] fingerPrintC, byte[] fingerPrintD, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "AddUpdateStudent";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("operatorLoginName", OracleDbType.Varchar2),
                new OracleParameter("idNo", OracleDbType.Varchar2),
                new OracleParameter("idTypeName", OracleDbType.Varchar2),
                new OracleParameter("studentName", OracleDbType.Varchar2),
                new OracleParameter("studentGender", OracleDbType.Varchar2),
                new OracleParameter("driverLicenseType", OracleDbType.Varchar2),
                new OracleParameter("schoolName", OracleDbType.Varchar2),
                new OracleParameter("password", OracleDbType.Varchar2),
                new OracleParameter("photoA", OracleDbType.Blob),
                new OracleParameter("photoB", OracleDbType.Blob),
                new OracleParameter("fingerPrintA", OracleDbType.Clob),
                new OracleParameter("fingerPrintB", OracleDbType.Clob),
                new OracleParameter("fingerPrintC", OracleDbType.Clob),
                new OracleParameter("fingerPrintD", OracleDbType.Clob),
            };

            param[0].Direction = ParameterDirection.Output;
            for (int i = 1; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[1].Value = this.loginName;
            param[2].Value = idNo;
            param[3].Value = idTypeName;
            param[4].Value = studentName;
            param[5].Value = studentGender;
            param[6].Value = driverLicenseType;
            param[7].Value = schoolName;
            param[8].Value = password;
            param[9].Value = photoA;
            param[10].Value = photoB;
            param[11].Value = fingerPrintA;
            param[12].Value = fingerPrintB;
            param[13].Value = fingerPrintC;
            param[14].Value = fingerPrintD;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[0].Value.ToString();
        }

        /// <summary>
        /// 增加修改车辆信息
        /// </summary>
        /// <param name="licenseNo">车辆号牌号码</param>
        /// <param name="subjectName">考试科目</param>
        /// <param name="carNo">车辆编号</param>
        /// <param name="qualifiedLicenseTypes">适用准驾车型范围</param>
        /// <param name="carBrand">车辆品牌</param>
        /// <param name="ip">车载IP</param>
        /// <param name="expireDate">强制报废期止</param>
        /// <param name="carMap">车辆轮廓地图</param>
        /// <param name="message">信息</param>
        public void AddUpdateCar(string licenseNo, string subjectName, string carNo, string qualifiedLicenseTypes, string carBrand, string ip, string expireDate, byte[] carMap, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "AddUpdateCar";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("operatorLoginName", OracleDbType.Varchar2),
                new OracleParameter("licenseNo", OracleDbType.Varchar2),
                new OracleParameter("subjectName", OracleDbType.Varchar2),
                new OracleParameter("carNo", OracleDbType.Varchar2),
                new OracleParameter("qualifiedLicenseTypes", OracleDbType.Varchar2),
                new OracleParameter("carBrand", OracleDbType.Varchar2),
                new OracleParameter("ip", OracleDbType.Varchar2),
                new OracleParameter("expireDate", OracleDbType.Varchar2),
                new OracleParameter("carMap", OracleDbType.Blob),
            };

            param[0].Direction = ParameterDirection.Output;
            for (int i = 1; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[1].Value = this.loginName;
            param[2].Value = licenseNo;
            param[3].Value = subjectName;
            param[4].Value = carNo;
            param[5].Value = qualifiedLicenseTypes;
            param[6].Value = carBrand;
            param[7].Value = ip;
            param[8].Value = expireDate;
            param[9].Value = carMap;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[0].Value.ToString();
        }

        /// <summary>
        /// 增加修改设备信息
        /// </summary>
        /// <param name="deviceNo">设备编号</param>
        /// <param name="deviceDescription">设备描述</param>
        /// <param name="deviceManufacture">制造厂商</param>
        /// <param name="deviceSerial">设备型号</param>
        /// <param name="examItemName">考试项目</param>
        /// <param name="placeCode">考场代码</param>
        /// <param name="acceptanceDate">验收日期</param>
        /// <param name="expireDate">有效截止日期</param>
        /// <param name="message">信息</param>
        public void AddUpdateDevice(string deviceNo, string deviceDescription, string deviceManufacture, string deviceSerial, string examItemName, string placeCode, string acceptanceDate, string expireDate, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "AddUpdateDevice";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("operatorLoginName", OracleDbType.Varchar2),
                new OracleParameter("deviceNo", OracleDbType.Varchar2),
                new OracleParameter("deviceDescription", OracleDbType.Varchar2),
                new OracleParameter("deviceManufacture", OracleDbType.Varchar2),
                new OracleParameter("deviceSerial", OracleDbType.Varchar2),
                new OracleParameter("examItemName", OracleDbType.Varchar2),
                new OracleParameter("placeCode", OracleDbType.Varchar2),
                new OracleParameter("acceptanceDate", OracleDbType.Varchar2),
                new OracleParameter("expireDate", OracleDbType.Varchar2),
            };

            param[0].Direction = ParameterDirection.Output;
            for (int i = 1; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[1].Value = this.loginName;
            param[2].Value = deviceNo;
            param[3].Value = deviceDescription;
            param[4].Value = deviceManufacture;
            param[5].Value = deviceSerial;
            param[6].Value = examItemName;
            param[7].Value = placeCode;
            param[8].Value = acceptanceDate;
            param[9].Value = expireDate;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[0].Value.ToString();
        }

        /// <summary>
        /// 增加修改考试员信息
        /// </summary>
        /// <param name="idNo">身份证明号码</param>
        /// <param name="idTypeName">身份证明类型</param>
        /// <param name="examinerName">姓名</param>
        /// <param name="examinerGender">性别</param>
        /// <param name="birth">出生日期</param>
        /// <param name="issuingAuthority">所属发证机关</param>
        /// <param name="issuingDate">发证日期</param>
        /// <param name="expireDate">有效截止日期</param>
        /// <param name="office">工作单位</param>
        /// <param name="operatorName">经办人</param>
        /// <param name="issuingOffice">发证单位</param>
        /// <param name="message">信息</param>
        public void AddUpdateExaminer(string idNo, string idTypeName, string examinerName, string examinerGender, string birth, string issuingAuthority, string issuingDate, string expireDate, string office, string operatorName, string issuingOffice, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "AddUpdateExaminer";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("operatorLoginName", OracleDbType.Varchar2),
                new OracleParameter("idNo", OracleDbType.Varchar2),
                new OracleParameter("idTypeName", OracleDbType.Varchar2),
                new OracleParameter("examinerName", OracleDbType.Varchar2),
                new OracleParameter("examinerGender", OracleDbType.Varchar2),
                new OracleParameter("birth", OracleDbType.Varchar2),
                new OracleParameter("issuingAuthority", OracleDbType.Varchar2),
                new OracleParameter("issuingDate", OracleDbType.Varchar2),
                new OracleParameter("expireDate", OracleDbType.Varchar2),
                new OracleParameter("office", OracleDbType.Varchar2),
                new OracleParameter("operatorName", OracleDbType.Varchar2),
                new OracleParameter("issuingOffice", OracleDbType.Varchar2),
            };

            param[0].Direction = ParameterDirection.Output;
            for (int i = 1; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[1].Value = this.loginName;
            param[2].Value = idNo;
            param[3].Value = idTypeName;
            param[4].Value = examinerName;
            param[5].Value = examinerGender;
            param[6].Value = birth;
            param[7].Value = issuingAuthority;
            param[8].Value = issuingDate;
            param[9].Value = expireDate;
            param[10].Value = office;
            param[11].Value = operatorName;
            param[12].Value = issuingOffice;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[0].Value.ToString();
        }

        /// <summary>
        /// 增加修改场地信息
        /// </summary>
        /// <param name="placeCode">考场代码</param>
        /// <param name="placeName">考场名称</param>
        /// <param name="subjectName">考试科目</param>
        /// <param name="issuingAuthority">发证机关</param>
        /// <param name="branch">管理部门</param>
        /// <param name="acceptanceDate">总队验收日期</param>
        /// <param name="accepterName">验收人</param>
        /// <param name="message">信息</param>
        public void AddUpdatePlace(string placeCode, string placeName, string subjectName, string issuingAuthority, string branch, string acceptanceDate, string accepterName, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "AddUpdatePlace";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("operatorLoginName", OracleDbType.Varchar2),
                new OracleParameter("placeCode", OracleDbType.Varchar2),
                new OracleParameter("placeName", OracleDbType.Varchar2),
                new OracleParameter("subjectName", OracleDbType.Varchar2),
                new OracleParameter("issuingAuthority", OracleDbType.Varchar2),
                new OracleParameter("branch", OracleDbType.Varchar2),
                new OracleParameter("acceptanceDate", OracleDbType.Varchar2),
                new OracleParameter("accepterName", OracleDbType.Varchar2),
            };

            param[0].Direction = ParameterDirection.Output;
            for (int i = 1; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[1].Value = this.loginName;
            param[2].Value = placeCode;
            param[3].Value = placeName;
            param[4].Value = subjectName;
            param[5].Value = issuingAuthority;
            param[6].Value = branch;
            param[7].Value = acceptanceDate;
            param[8].Value = accepterName;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[0].Value.ToString();
        }

        /// <summary>
        /// 增加修改驾校信息
        /// </summary>
        /// <param name="schoolCode">代码</param>
        /// <param name="schoolName">名称</param>
        /// <param name="shortName">简称</param>
        /// <param name="schoolAddress">地址</param>
        /// <param name="contactAddress">联系地址</param>
        /// <param name="contactName">联系人</param>
        /// <param name="corporation">法人代表</param>
        /// <param name="schoolGrade">驾校级别</param>
        /// <param name="message">信息</param>
        public void AddUpdateSchool(string schoolCode, string schoolName, string shortName, string schoolAddress, string contactAddress, string contactName, string corporation, string schoolGrade, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "AddUpdateSchool";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("operatorLoginName", OracleDbType.Varchar2),
                new OracleParameter("schoolCode", OracleDbType.Varchar2),
                new OracleParameter("schoolName", OracleDbType.Varchar2),
                new OracleParameter("shortName", OracleDbType.Varchar2),
                new OracleParameter("schoolAddress", OracleDbType.Varchar2),
                new OracleParameter("contactAddress", OracleDbType.Varchar2),
                new OracleParameter("contactName", OracleDbType.Varchar2),
                new OracleParameter("corporation", OracleDbType.Varchar2),
                new OracleParameter("schoolGrade", OracleDbType.Varchar2),
            };

            param[0].Direction = ParameterDirection.Output;
            for (int i = 1; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[1].Value = this.loginName;
            param[2].Value = schoolCode;
            param[3].Value = schoolName;
            param[4].Value = shortName;
            param[5].Value = schoolAddress;
            param[6].Value = contactAddress;
            param[7].Value = contactName;
            param[8].Value = corporation;
            param[9].Value = schoolGrade;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[0].Value.ToString();
        }

        /// <summary>
        /// 增加或修改备案场地信息
        /// </summary>
        /// <param name="xh">序号</param>
        /// <param name="fzjg">发证机关</param>
        /// <param name="glbm">管理部门</param>
        /// <param name="kskm">考试科目</param>
        /// <param name="kcmc">考场名称</param>
        /// <param name="kcdddh">考场代码</param>
        /// <param name="kkcx">适用准驾车型范围</param>
        /// <param name="ywlx">适用业务类型范围</param>
        /// <param name="zdysrq">总队验收日期</param>
        /// <param name="ysr">验收人</param>
        /// <param name="kmeyyms">科目二预约模式</param>
        /// <param name="fzms">分组模式</param>
        /// <param name="kmeksrsxz">考试人数限制</param>
        /// <param name="kmezkrsxz">科目二桩考人数限制</param>
        /// <param name="kmeckrsxz">科目二场考人数限制</param>
        /// <param name="zksfdz">桩考评判方式</param>
        /// <param name="cksfdz">场考评判方式</param>
        /// <param name="zklwrq">桩考开始联网时间</param>
        /// <param name="cklwrq">场考开始联网时间</param>
        /// <param name="kczt">使用状态</param>
        /// <param name="zksbs">桩考设备数</param>
        /// <param name="cksbs">场考设备数</param>
        /// <param name="cjsj">创建日期</param>
        /// <param name="gxsj">更新日期</param>
        public void Query17C01Place(string xh, string fzjg, string glbm, string kskm, string kcmc, string kcdddh,
            string kkcx, string ywlx, string zdysrq, string ysr, string kmeyyms, string fzms, string kmeksrsxz,
            string kmezkrsxz, string kmeckrsxz, string zksfdz, string cksfdz, string zklwrq, string cklwrq, string kczt,
            string zksbs, string cksbs, string cjsj, string gxsj)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Query17C01Place";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("xh", OracleDbType.Varchar2),
                new OracleParameter("fzjg", OracleDbType.Varchar2),
                new OracleParameter("glbm", OracleDbType.Varchar2),
                new OracleParameter("kskm", OracleDbType.Varchar2),
                new OracleParameter("kcmc", OracleDbType.Varchar2),
                new OracleParameter("kcdddh", OracleDbType.Varchar2),
                new OracleParameter("kkcx", OracleDbType.Varchar2),
                new OracleParameter("ywlx", OracleDbType.Varchar2),
                new OracleParameter("zdysrq", OracleDbType.Varchar2),
                new OracleParameter("ysr", OracleDbType.Varchar2),
                new OracleParameter("kmeyyms", OracleDbType.Varchar2),
                new OracleParameter("fzms", OracleDbType.Varchar2),
                new OracleParameter("kmeksrsxz", OracleDbType.Varchar2),
                new OracleParameter("kmezkrsxz", OracleDbType.Varchar2),
                new OracleParameter("kmeckrsxz", OracleDbType.Varchar2),
                new OracleParameter("zksfdz", OracleDbType.Varchar2),
                new OracleParameter("cksfdz", OracleDbType.Varchar2),
                new OracleParameter("zklwrq", OracleDbType.Varchar2),
                new OracleParameter("cklwrq", OracleDbType.Varchar2),
                new OracleParameter("kczt", OracleDbType.Varchar2),
                new OracleParameter("zksbs", OracleDbType.Varchar2),
                new OracleParameter("cksbs", OracleDbType.Varchar2),
                new OracleParameter("cjsj", OracleDbType.Varchar2),
                new OracleParameter("gxsj", OracleDbType.Varchar2),
            };

            for (int i = 0; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[0].Value = xh;
            param[1].Value = fzjg;
            param[2].Value = glbm;
            param[3].Value = kskm;
            param[4].Value = kcmc;
            param[5].Value = kcdddh;
            param[6].Value = kkcx;
            param[7].Value = ywlx;
            param[8].Value = zdysrq;
            param[9].Value = ysr;
            param[10].Value = kmeyyms;
            param[11].Value = fzms;
            param[12].Value = kmeksrsxz;
            param[13].Value = kmezkrsxz;
            param[14].Value = kmeckrsxz;
            param[15].Value = zksfdz;
            param[16].Value = cksfdz;
            param[17].Value = zklwrq;
            param[18].Value = cklwrq;
            param[19].Value = kczt;
            param[20].Value = zksbs;
            param[21].Value = cksbs;
            param[22].Value = cjsj;
            param[23].Value = gxsj;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 增加或修改备案设备信息
        /// </summary>
        /// <param name="xh">序号</param>
        /// <param name="sbbh">设备编号</param>
        /// <param name="sbms">设备描述</param>
        /// <param name="zzcs">制造厂商</param>
        /// <param name="sbxh">设备型号</param>
        /// <param name="ksxm">考试项目</param>
        /// <param name="ksxmsm">考试项目说明</param>
        /// <param name="ppfs">评判方式</param>
        /// <param name="kcxh">考场序号</param>
        /// <param name="syzjcx">适用准驾车型范围</param>
        /// <param name="ysrq">验收日期</param>
        /// <param name="badckssj">备案单次考试时间</param>
        /// <param name="bamxsksrs">备案每小时考试人次</param>
        /// <param name="jyyxqz">检验有效期止</param>
        /// <param name="syzt">使用状态</param>
        /// <param name="cjsj">创建时间</param>
        /// <param name="gxsj">更新日期</param>
        public void Query17C02Device(string xh, string sbbh, string sbms, string zzcs, string sbxh, string ksxm,
            string ksxmsm, string ppfs, string kcxh, string syzjcx, string ysrq, string badckssj, string bamxsksrs,
            string jyyxqz, string syzt, string cjsj, string gxsj)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Query17C02Device";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("xh", OracleDbType.Varchar2),
                new OracleParameter("sbbh", OracleDbType.Varchar2),
                new OracleParameter("sbms", OracleDbType.Varchar2),
                new OracleParameter("zzcs", OracleDbType.Varchar2),
                new OracleParameter("sbxh", OracleDbType.Varchar2),
                new OracleParameter("ksxm", OracleDbType.Varchar2),
                new OracleParameter("ksxmsm", OracleDbType.Varchar2),
                new OracleParameter("ppfs", OracleDbType.Varchar2),
                new OracleParameter("kcxh", OracleDbType.Varchar2),
                new OracleParameter("syzjcx", OracleDbType.Varchar2),
                new OracleParameter("ysrq", OracleDbType.Varchar2),
                new OracleParameter("badckssj", OracleDbType.Varchar2),
                new OracleParameter("bamxsksrs", OracleDbType.Varchar2),
                new OracleParameter("jyyxqz", OracleDbType.Varchar2),
                new OracleParameter("syzt", OracleDbType.Varchar2),
                new OracleParameter("cjsj", OracleDbType.Varchar2),
                new OracleParameter("gxsj", OracleDbType.Varchar2),
            };

            for (int i = 0; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[0].Value = xh;
            param[1].Value = sbbh;
            param[2].Value = sbms;
            param[3].Value = zzcs;
            param[4].Value = sbxh;
            param[5].Value = ksxm;
            param[6].Value = ksxmsm;
            param[7].Value = ppfs;
            param[8].Value = kcxh;
            param[9].Value = syzjcx;
            param[10].Value = ysrq;
            param[11].Value = badckssj;
            param[12].Value = bamxsksrs;
            param[13].Value = jyyxqz;
            param[14].Value = syzt;
            param[15].Value = cjsj;
            param[16].Value = gxsj;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 增加或修改备案车辆信息
        /// </summary>
        /// <param name="xh">序号</param>
        /// <param name="jbr">经办人</param>
        /// <param name="shr">审核人</param>
        /// <param name="hpzl">号牌种类</param>
        /// <param name="zt">状态</param>
        /// <param name="ksczt">考试车状态</param>
        /// <param name="cllx">车辆类型</param>
        /// <param name="shsj">审核时间</param>
        /// <param name="clpp">车辆品牌</param>
        /// <param name="ccdjrq">初次登记日期</param>
        /// <param name="qzbfqz">强制报废期止</param>
        /// <param name="fzjg">发证机关</param>
        /// <param name="hphm">号牌号码</param>
        /// <param name="syzjcx">适用准驾车型范围</param>
        /// <param name="ipdz">IP地址</param>
        /// <param name="cjsj">创建时间</param>
        /// <param name="gxsj">更新日期</param>
        public void Query17C03Car(string xh, string jbr, string shr, string hpzl, string zt, string ksczt, string cllx,
            string shsj, string clpp, string ccdjrq, string qzbfqz, string fzjg, string hphm, string syzjcx, string ipdz,
            string cjsj, string gxsj)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Query17C03Car";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("xh", OracleDbType.Varchar2),
                new OracleParameter("jbr", OracleDbType.Varchar2),
                new OracleParameter("shr", OracleDbType.Varchar2),
                new OracleParameter("hpzl", OracleDbType.Varchar2),
                new OracleParameter("zt", OracleDbType.Varchar2),
                new OracleParameter("ksczt", OracleDbType.Varchar2),
                new OracleParameter("cllx", OracleDbType.Varchar2),
                new OracleParameter("shsj", OracleDbType.Varchar2),
                new OracleParameter("clpp", OracleDbType.Varchar2),
                new OracleParameter("ccdjrq", OracleDbType.Varchar2),
                new OracleParameter("qzbfqz", OracleDbType.Varchar2),
                new OracleParameter("fzjg", OracleDbType.Varchar2),
                new OracleParameter("hphm", OracleDbType.Varchar2),
                new OracleParameter("syzjcx", OracleDbType.Varchar2),
                new OracleParameter("ipdz", OracleDbType.Varchar2),
                new OracleParameter("cjsj", OracleDbType.Varchar2),
                new OracleParameter("gxsj", OracleDbType.Varchar2),
            };

            for (int i = 0; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[0].Value = xh;
            param[1].Value = jbr;
            param[2].Value = shr;
            param[3].Value = hpzl;
            param[4].Value = zt;
            param[5].Value = ksczt;
            param[6].Value = cllx;
            param[7].Value = shsj;
            param[8].Value = clpp;
            param[9].Value = ccdjrq;
            param[10].Value = qzbfqz;
            param[11].Value = fzjg;
            param[12].Value = hphm;
            param[13].Value = syzjcx;
            param[14].Value = ipdz;
            param[15].Value = cjsj;
            param[16].Value = gxsj;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 增加或修改备案考试员信息
        /// </summary>
        /// <param name="xh">序号</param>
        /// <param name="sszd">所属发证机关</param>
        /// <param name="glbm">管理部门</param>
        /// <param name="sfzmmc">身份证明名称</param>
        /// <param name="sfzmhm">身份证明号码</param>
        /// <param name="dabh">驾驶证档案编号</param>
        /// <param name="xm">姓名</param>
        /// <param name="xb">性别</param>
        /// <param name="csrq">出生日期</param>
        /// <param name="zkcx">考试准驾车型范围</param>
        /// <param name="fzrq">考试员证发证日期</param>
        /// <param name="kszyxqz">考试员证有效期止</param>
        /// <param name="kszzt">考试员证状态</param>
        /// <param name="gzdw">工作单位</param>
        /// <param name="jbr">经办人</param>
        /// <param name="fzjg">考试员证发证单位</param>
        /// <param name="cjsj">创建时间</param>
        /// <param name="gxsj">更新时间</param>
        public void Query17C04Examinator(string xh, string sszd, string glbm, string sfzmmc, string sfzmhm,
            string dabh, string xm, string xb, string csrq, string zkcx, string fzrq, string kszyxqz,
            string kszzt, string gzdw, string jbr, string fzjg, string cjsj, string gxsj)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Query17C04Examinator";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("xh", OracleDbType.Varchar2),
                new OracleParameter("sszd", OracleDbType.Varchar2),
                new OracleParameter("glbm", OracleDbType.Varchar2),
                new OracleParameter("sfzmmc", OracleDbType.Varchar2),
                new OracleParameter("sfzmhm", OracleDbType.Varchar2),
                new OracleParameter("dabh", OracleDbType.Varchar2),
                new OracleParameter("xm", OracleDbType.Varchar2),
                new OracleParameter("xb", OracleDbType.Varchar2),
                new OracleParameter("csrq", OracleDbType.Varchar2),
                new OracleParameter("zkcx", OracleDbType.Varchar2),
                new OracleParameter("fzrq", OracleDbType.Varchar2),
                new OracleParameter("kszyxqz", OracleDbType.Varchar2),
                new OracleParameter("kszzt", OracleDbType.Varchar2),
                new OracleParameter("gzdw", OracleDbType.Varchar2),
                new OracleParameter("jbr", OracleDbType.Varchar2),
                new OracleParameter("fzjg", OracleDbType.Varchar2),
                new OracleParameter("cjsj", OracleDbType.Varchar2),
                new OracleParameter("gxsj", OracleDbType.Varchar2),
            };

            for (int i = 0; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[0].Value = xh;
            param[1].Value = sszd;
            param[2].Value = glbm;
            param[3].Value = sfzmmc;
            param[4].Value = sfzmhm;
            param[5].Value = dabh;
            param[6].Value = xm;
            param[7].Value = xb;
            param[8].Value = csrq;
            param[9].Value = zkcx;
            param[10].Value = fzrq;
            param[11].Value = kszyxqz;
            param[12].Value = kszzt;
            param[13].Value = gzdw;
            param[14].Value = jbr;
            param[15].Value = fzjg;
            param[16].Value = cjsj;
            param[17].Value = gxsj;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 增加或修改备案驾校信息
        /// </summary>
        /// <param name="xh">序号</param>
        /// <param name="jxmc">驾校名称</param>
        /// <param name="jxjc">驾校简称</param>
        /// <param name="jxdm">驾校代码</param>
        /// <param name="jxdz">驾校地址</param>
        /// <param name="lxdh">联系电话</param>
        /// <param name="lxr">联系人</param>
        /// <param name="frdb">法人代表</param>
        /// <param name="zczj">注册资金</param>
        /// <param name="jxjb">驾校级别</param>
        /// <param name="kpxcx">培训准驾车型</param>
        /// <param name="fzjg">所属发证机关</param>
        /// <param name="jxzt">驾校状态</param>
        /// <param name="shr">审核人</param>
        /// <param name="cjsj">创建时间</param>
        /// <param name="gxsj">更新时间</param>
        public void Query17C05School(string xh, string jxmc, string jxjc, string jxdm, string jxdz, string lxdh,
            string lxr, string frdb, string zczj, string jxjb, string kpxcx, string fzjg, string jxzt, string shr,
            string cjsj, string gxsj)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Query17C05School";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("xh", OracleDbType.Varchar2),
                new OracleParameter("jxmc", OracleDbType.Varchar2),
                new OracleParameter("jxjc", OracleDbType.Varchar2),
                new OracleParameter("jxdm", OracleDbType.Varchar2),
                new OracleParameter("jxdz", OracleDbType.Varchar2),
                new OracleParameter("lxdh", OracleDbType.Varchar2),
                new OracleParameter("lxr", OracleDbType.Varchar2),
                new OracleParameter("frdb", OracleDbType.Varchar2),
                new OracleParameter("zczj", OracleDbType.Varchar2),
                new OracleParameter("jxjb", OracleDbType.Varchar2),
                new OracleParameter("kpxcx", OracleDbType.Varchar2),
                new OracleParameter("fzjg", OracleDbType.Varchar2),
                new OracleParameter("jxzt", OracleDbType.Varchar2),
                new OracleParameter("shr", OracleDbType.Varchar2),
                new OracleParameter("cjsj", OracleDbType.Varchar2),
                new OracleParameter("gxsj", OracleDbType.Varchar2),
            };

            for (int i = 0; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[0].Value = xh;
            param[1].Value = jxmc;
            param[2].Value = jxjc;
            param[3].Value = jxdm;
            param[4].Value = jxdz;
            param[5].Value = lxdh;
            param[6].Value = lxr;
            param[7].Value = frdb;
            param[8].Value = zczj;
            param[9].Value = jxjb;
            param[10].Value = kpxcx;
            param[11].Value = fzjg;
            param[12].Value = jxzt;
            param[13].Value = shr;
            param[14].Value = cjsj;
            param[15].Value = gxsj;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 增加或修改考试计划分组信息
        /// </summary>
        /// <param name="xh">序号</param>
        /// <param name="kskm">考试科目</param>
        /// <param name="ksrq">考试日期</param>
        /// <param name="ksdd">考试地点</param>
        /// <param name="kcxh">考场序号</param>
        /// <param name="kscx">考试车型</param>
        /// <param name="kscc">考试场次</param>
        /// <param name="kchp">考车号牌</param>
        /// <param name="ksy">考试员</param>
        /// <param name="ksxm">考试项目</param>
        /// <param name="glbm">管理部门</param>
        /// <param name="ksxl">考试线路</param>
        public void Query17C06Group(string xh, string kskm, string ksrq, string ksdd, string kcxh, string kscx,
            string kscc, string kchp, string ksy, string ksxm, string glbm, string ksxl)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Query17C06Group";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("xh", OracleDbType.Varchar2),
                new OracleParameter("kskm", OracleDbType.Varchar2),
                new OracleParameter("ksrq", OracleDbType.Varchar2),
                new OracleParameter("ksdd", OracleDbType.Varchar2),
                new OracleParameter("kcxh", OracleDbType.Varchar2),
                new OracleParameter("kscx", OracleDbType.Varchar2),
                new OracleParameter("kscc", OracleDbType.Varchar2),
                new OracleParameter("kchp", OracleDbType.Varchar2),
                new OracleParameter("ksy", OracleDbType.Varchar2),
                new OracleParameter("ksxm", OracleDbType.Varchar2),
                new OracleParameter("glbm", OracleDbType.Varchar2),
                new OracleParameter("ksxl", OracleDbType.Varchar2),
            };

            for (int i = 0; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[0].Value = xh;
            param[1].Value = kskm;
            param[2].Value = ksrq;
            param[3].Value = ksdd;
            param[4].Value = kcxh;
            param[5].Value = kscx;
            param[6].Value = kscc;
            param[7].Value = kchp;
            param[8].Value = ksy;
            param[9].Value = ksxm;
            param[10].Value = glbm;
            param[11].Value = ksxl;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 增加或修改考试分组明细信息
        /// </summary>
        /// <param name="xh">分组序号</param>
        /// <param name="sfzmhm">身份证明号码</param>
        /// <param name="xm">姓名</param>
        /// <param name="dlr">代理人</param>
        /// <param name="kchp">考车号牌</param>
        /// <param name="Jxxh">驾校序号</param>
        public void Query17C07GroupDetail(string xh, string sfzmhm, string xm, string dlr, string kchp, string Jxxh)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Query17C07GroupDetail";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("xh", OracleDbType.Varchar2),
                new OracleParameter("sfzmhm", OracleDbType.Varchar2),
                new OracleParameter("xm", OracleDbType.Varchar2),
                new OracleParameter("dlr", OracleDbType.Varchar2),
                new OracleParameter("kchp", OracleDbType.Varchar2),
                new OracleParameter("Jxxh", OracleDbType.Varchar2),
            };

            for (int i = 0; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[0].Value = xh;
            param[1].Value = sfzmhm;
            param[2].Value = xm;
            param[3].Value = dlr;
            param[4].Value = kchp;
            param[5].Value = Jxxh;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 增加或修改考试预约信息
        /// </summary>
        /// <param name="lsh">流水号</param>
        /// <param name="kskm">考试科目</param>
        /// <param name="zkzmbh">准考证明编号</param>
        /// <param name="sfzmmc">身份证明名称</param>
        /// <param name="sfzmhm">身份证明号码</param>
        /// <param name="xm">姓名</param>
        /// <param name="ksyy">考试原因</param>
        /// <param name="xxsj">学习时间</param>
        /// <param name="yyrq">预约日期</param>
        /// <param name="ykrq">约考日期</param>
        /// <param name="kscx">考试车型</param>
        /// <param name="ksdd">考试地点</param>
        /// <param name="kscc">考试场次</param>
        /// <param name="kchp">考试车辆号牌</param>
        /// <param name="jbr">经办人</param>
        /// <param name="glbm">管理部门</param>
        /// <param name="dlr">代理人</param>
        /// <param name="ksrq">考试日期</param>
        /// <param name="kscs">考试次数</param>
        /// <param name="ksy1">考试员1</param>
        /// <param name="ksy2">考试员2</param>
        /// <param name="zt">状态</param>
        /// <param name="pxshrq">培训审核日期</param>
        /// <param name="sfyk">是否夜考</param>
        /// <param name="zkykrq">桩考约考日期</param>
        /// <param name="zksfhg">桩考是否合格</param>
        /// <param name="clzl">车辆种类</param>
        /// <param name="jly">教练员</param>
        /// <param name="zkkf">桩考扣分</param>
        /// <param name="ckyy">场考是否已约</param>
        /// <param name="ywblbm">业务办理部门</param>
        /// <param name="yycs">预约次数</param>
        /// <param name="bcyykscs">本次预约考试次数</param>
        public void Query17C08Book(string lsh, string kskm, string zkzmbh, string sfzmmc, string sfzmhm, string xm,
            string ksyy, string xxsj, string yyrq, string ykrq, string kscx, string ksdd, string kscc, string kchp,
            string jbr, string glbm, string dlr, string ksrq, string kscs, string ksy1, string ksy2, string zt,
            string pxshrq, string sfyk, string zkykrq, string zksfhg, string clzl, string jly, string zkkf,
            string ckyy, string ywblbm, string yycs, string bcyykscs)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Query17C08Book";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                new OracleParameter("lsh", OracleDbType.Varchar2),
                new OracleParameter("kskm", OracleDbType.Varchar2),
                new OracleParameter("zkzmbh", OracleDbType.Varchar2),
                new OracleParameter("sfzmmc", OracleDbType.Varchar2),
                new OracleParameter("sfzmhm", OracleDbType.Varchar2),
                new OracleParameter("xm", OracleDbType.Varchar2),
                new OracleParameter("ksyy", OracleDbType.Varchar2),
                new OracleParameter("xxsj", OracleDbType.Varchar2),
                new OracleParameter("yyrq", OracleDbType.Varchar2),
                new OracleParameter("ykrq", OracleDbType.Varchar2),
                new OracleParameter("kscx", OracleDbType.Varchar2),
                new OracleParameter("ksdd", OracleDbType.Varchar2),
                new OracleParameter("kscc", OracleDbType.Varchar2),
                new OracleParameter("kchp", OracleDbType.Varchar2),
                new OracleParameter("jbr", OracleDbType.Varchar2),
                new OracleParameter("glbm", OracleDbType.Varchar2),
                new OracleParameter("dlr", OracleDbType.Varchar2),
                new OracleParameter("ksrq", OracleDbType.Varchar2),
                new OracleParameter("kscs", OracleDbType.Varchar2),
                new OracleParameter("ksy1", OracleDbType.Varchar2),
                new OracleParameter("ksy2", OracleDbType.Varchar2),
                new OracleParameter("zt", OracleDbType.Varchar2),
                new OracleParameter("pxshrq", OracleDbType.Varchar2),
                new OracleParameter("sfyk", OracleDbType.Varchar2),
                new OracleParameter("zkykrq", OracleDbType.Varchar2),
                new OracleParameter("zksfhg", OracleDbType.Varchar2),
                new OracleParameter("clzl", OracleDbType.Varchar2),
                new OracleParameter("jly", OracleDbType.Varchar2),
                new OracleParameter("zkkf", OracleDbType.Varchar2),
                new OracleParameter("ckyy", OracleDbType.Varchar2),
                new OracleParameter("ywblbm", OracleDbType.Varchar2),
                new OracleParameter("yycs", OracleDbType.Varchar2),
                new OracleParameter("bcyykscs", OracleDbType.Varchar2),
            };

            for (int i = 0; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[0].Value = lsh;
            param[1].Value = kskm;
            param[2].Value = zkzmbh;
            param[3].Value = sfzmmc;
            param[4].Value = sfzmhm;
            param[5].Value = xm;
            param[6].Value = ksyy;
            param[7].Value = xxsj;
            param[8].Value = yyrq;
            param[9].Value = ykrq;
            param[10].Value = kscx;
            param[11].Value = ksdd;
            param[12].Value = kscc;
            param[13].Value = kchp;
            param[14].Value = jbr;
            param[15].Value = glbm;
            param[16].Value = dlr;
            param[17].Value = ksrq;
            param[18].Value = kscs;
            param[19].Value = ksy1;
            param[20].Value = ksy2;
            param[21].Value = zt;
            param[22].Value = pxshrq;
            param[23].Value = sfyk;
            param[24].Value = zkykrq;
            param[25].Value = zksfhg;
            param[26].Value = clzl;
            param[27].Value = jly;
            param[28].Value = zkkf;
            param[29].Value = ckyy;
            param[30].Value = ywblbm;
            param[31].Value = yycs;
            param[32].Value = bcyykscs;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 根据预约次数计算金额
        /// </summary>
        /// <param name="times">预约次数</param>
        /// <param name="startTime">预约开始时间</param>
        /// <param name="schoolName">驾校名称</param>
        /// <param name="studentIDNumber">学员身份证号码</param>
        /// <param name="message">返回信息</param>
        /// <returns>金额</returns>
        public float GetPriceByTimes(int times, string startTime, string schoolName, string studentIDNumber, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "GetPriceByTimes";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                // 返回值必须是第一个参数
                new OracleParameter("ReturnValue", OracleDbType.Int32, 0, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Default, Convert.DBNull),
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("times", OracleDbType.Varchar2),
                new OracleParameter("startTime", OracleDbType.Varchar2),
                new OracleParameter("schoolName", OracleDbType.Varchar2),
                new OracleParameter("studentIDNumber", OracleDbType.Varchar2)
            };

            param[1].Direction = ParameterDirection.Output;
            for (int i = 2; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[2].Value = times;
            param[3].Value = startTime;
            param[4].Value = schoolName;
            param[5].Value = studentIDNumber;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[1].Value.ToString();
            return Convert.ToSingle(param[0].Value.ToString());
        }
        
        /// <summary>
        /// 增加或修改定价策略
        /// </summary>
        /// <param name="pricingPriority">定价优先级</param>
        /// <param name="pricingAction">定价行为</param>
        /// <param name="pricingAmount">定价金额</param>
        /// <param name="effectiveDate">生效日期</param>
        /// <param name="expiredDate">失效日期</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="schoolName">驾校名称</param>
        /// <param name="studentIDNumber">学员身份证明号码</param>
        /// <param name="method1">参考方法1</param>
        /// <param name="amount1">金额1</param>
        /// <param name="relation">关系</param>
        /// <param name="method2">参考方法2</param>
        /// <param name="amount2">金额2</param>
        /// <param name="message">返回信息</param>
        /// <returns>0：成功</returns>
        public int AddUpdatePricingStrategy(string pricingPriority, string pricingAction, string pricingAmount, string effectiveDate,
            string expiredDate, string startDate, string endDate, string startTime, string endTime, string schoolName, string studentIDNumber,
            string method1, string amount1, string relation, string method2, string amount2, out string message)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "AddUpdatePricingStrategy";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter[] param = {
                // 返回值必须是第一个参数
                new OracleParameter("ReturnValue", OracleDbType.Int32, 200, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Default, Convert.DBNull),
                new OracleParameter("message", OracleDbType.Varchar2, 1000),
                new OracleParameter("operatorLoginName", OracleDbType.Varchar2),
                new OracleParameter("hostIP", OracleDbType.Varchar2),
                new OracleParameter("hostMAC", OracleDbType.Varchar2),
                new OracleParameter("pricingPriority", OracleDbType.Varchar2),
                new OracleParameter("pricingActionName", OracleDbType.Varchar2),
                new OracleParameter("pricingAmount", OracleDbType.Varchar2),
                new OracleParameter("effectiveDate", OracleDbType.Varchar2),
                new OracleParameter("expiredDate", OracleDbType.Varchar2),
                new OracleParameter("startDate", OracleDbType.Varchar2),
                new OracleParameter("endDate", OracleDbType.Varchar2),
                new OracleParameter("startTime", OracleDbType.Varchar2),
                new OracleParameter("endTime", OracleDbType.Varchar2),
                new OracleParameter("schoolName", OracleDbType.Varchar2),
                new OracleParameter("studentIDNumber", OracleDbType.Varchar2),
                new OracleParameter("methodName1", OracleDbType.Varchar2),
                new OracleParameter("amount1", OracleDbType.Varchar2),
                new OracleParameter("relation", OracleDbType.Varchar2),
                new OracleParameter("methodName2", OracleDbType.Varchar2),
                new OracleParameter("amount2", OracleDbType.Varchar2),
            };

            param[1].Direction = ParameterDirection.Output;
            for (int i = 2; i < param.Length; i++)
                param[i].Direction = ParameterDirection.Input;

            param[2].Value = this.loginName;
            param[3].Value = Form_Main.terminalIP;
            param[4].Value = Form_Main.terminalMAC;
            param[5].Value = pricingPriority;
            param[6].Value = pricingAction;
            param[7].Value = pricingAmount;
            param[8].Value = effectiveDate;
            param[9].Value = expiredDate;
            param[10].Value = startDate;
            param[11].Value = endDate;
            param[12].Value = startTime;
            param[13].Value = endTime;
            param[14].Value = schoolName;
            param[15].Value = studentIDNumber;
            param[16].Value = method1;
            param[17].Value = amount1;
            param[18].Value = relation;
            param[19].Value = method2;
            param[20].Value = amount2;

            cmd.Parameters.AddRange(param);

            cmd.ExecuteNonQuery();

            message = param[1].Value.ToString();
            return Convert.ToInt32(param[0].Value.ToString());
        }
    }
}
