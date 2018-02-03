#define DB

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Client.DBM;

namespace Client
{
    public partial class Form_Permission : Form
    {
        public Form_Permission()
        {
            InitializeComponent();
        }

        private void Form_Permission_Load(object sender, EventArgs e)
        {
            // 角色列表
            listBox_roles.Items.Clear();
            string sql = "select NAME from SYS_ROLE";
            listBox_roles.Items.AddRange(mDBM.SelectArray(sql));

            // 权限列表
            sql = "select NAME from SYS_PERMISSION order by CODE";
            string[] name = mDBM.SelectArray(sql);
            sql = "select CODE from SYS_PERMISSION order by CODE";
            string[] code = mDBM.SelectArray(sql);
            
            int index;
            for (int x = 0; x < code.Length; x++)
            {
                int intCode = Convert.ToInt32(code[x], 10);
                if (intCode % 100 == 0)
                {
                    treeView_permission.Nodes.Add(name[x]);
                }
                else
                {
                    index = Array.IndexOf(code, (intCode / 100 * 100).ToString("D4"));
                    for (int y = 0; y < treeView_permission.Nodes.Count; y++)
                    {
                        if (name[index] == treeView_permission.Nodes[y].Text)
                        {
                            treeView_permission.Nodes[y].Nodes.Add(name[x]);
                            break;
                        }
                    }
                }
            }

            btn_save.Enabled = false;
            btn_cancel.Enabled = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> oldPermission = mDBM.getRolePermissions(listBox_roles.SelectedItem.ToString()).ToList();
                List<string> newPermission = new List<string>();
                foreach (TreeNode node1 in treeView_permission.Nodes)
                {
                    if (node1.Checked)
                        newPermission.Add(node1.Text);

                    foreach(TreeNode node2 in node1.Nodes)
                    {
                        if (node2.Checked)
                            newPermission.Add(node2.Text);
                    }
                }

                string message;
                // 增加权限
                var addList = newPermission.Except(oldPermission);
                foreach (var i in addList)
                {
                    if (mDBM.GrantRolePermission(listBox_roles.SelectedItem.ToString(), i.ToString(), out message) != 0)
                    {
                        MessageBox.Show(message, "错误");
                        return;
                    }
                }

                // 删除权限
                var removeList = oldPermission.Except(newPermission);
                foreach (var i in removeList)
                {
                    if (i.ToString() != "null")
                    {
                        if (mDBM.RevokeRolePermission(listBox_roles.SelectedItem.ToString(), i.ToString(), out message) != 0)
                        {
                            MessageBox.Show(message, "错误");
                            return;
                        }
                    }
                }

                MessageBox.Show("修改权限成功", "提示");
            }
            finally
            {
                btn_save.Enabled = false;
                btn_cancel.Enabled = false;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            // 角色的权限列表
            string[] permission = mDBM.getRolePermissions(listBox_roles.SelectedItem.ToString());

            // 匹配的权限使能
            foreach (TreeNode node1 in treeView_permission.Nodes)
            {
                if (permission.Contains(node1.Text))
                    node1.Checked = true;
                else
                    node1.Checked = false;

                foreach (TreeNode node2 in node1.Nodes)
                {
                    if (permission.Contains(node2.Text))
                        node2.Checked = true;
                    else
                        node2.Checked = false;
                }
            }

            btn_save.Enabled = false;
            btn_cancel.Enabled = false;
        }

        // 点击角色列表，权限列表显示该角色的权限
        private void listBox_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_roles.SelectedItem != null)
            {
                // 角色的权限列表
                string[] permission = mDBM.getRolePermissions(listBox_roles.SelectedItem.ToString());

                // 匹配的权限使能
                foreach (TreeNode node1 in treeView_permission.Nodes)
                {
                    if (permission.Contains(node1.Text))
                        node1.Checked = true;
                    else
                        node1.Checked = false;

                    foreach (TreeNode node2 in node1.Nodes)
                    {
                        if (permission.Contains(node2.Text))
                            node2.Checked = true;
                        else
                            node2.Checked = false;
                    }
                }

                btn_save.Enabled = false;
                btn_cancel.Enabled = false;
            }
        }

        private void btn_append_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox_roleName.Text))
            {
                string message;
                if (0 == mDBM.AddRole(textBox_roleName.Text, out message))
                    MessageBox.Show("增加角色成功");
                else
                    MessageBox.Show(message);

                listBox_roles.Items.Clear();
                string sql = "select NAME from SYS_ROLE";
                listBox_roles.Items.AddRange(mDBM.SelectArray(sql));
            }
        }

        private void treeView_permission_AfterCheck(object sender, TreeViewEventArgs e)
        {
            btn_save.Enabled = true;
            btn_cancel.Enabled = true;

            if (e.Node.Parent == null)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
        }
    }
}
