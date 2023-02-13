using GMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 中医信息管理系统.entity;

namespace 中医信息管理系统
{
    public partial class FormLogin : Form
    {
        FormMain login = null;

        public FormLogin(FormMain M)
        {
            login = M;
            InitializeComponent();
        }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            rdbDoctor.Checked = true;
            if (Login.Current.CreateID != null && Login.Current.CreatePW != null && Login.Current.CreateRole != null)
            {
                txtID.Text = Login.Current.CreateID;
                txtKey.Text = Login.Current.CreatePW;
                if (Login.Current.CreateRole == "求诊者")
                {
                    rdbCustom.Checked = true;
                }
                else if(Login.Current.CreateRole == "医生")
                {
                    rdbDoctor.Checked = true;
                }
            }
            else if(Login.Current.LoginID != null && Login.Current.LoginRole != null)
            {
                txtID.Text = Login.Current.LoginID;
                if (Login.Current.LoginRole == "求诊者")
                {
                    rdbCustom.Checked = true;
                }
                else if (Login.Current.LoginRole == "医生")
                {
                    rdbDoctor.Checked = true;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e) //登录按钮
        {
            if (SqlHelper.ConnectTest())
            {
                if (txtID.Text == "000000")
                {
                    string sql = "SELECT id FROM `管理员信息` WHERE id=@id AND pw=@pw";
                    MySqlParameter[] paras =
                    {
                        new MySqlParameter("@id",txtID.Text),
                        new MySqlParameter("@pw",txtKey.Text)
                    };
                    DataTable dt = SqlHelper.GetDataTable(sql, paras);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("用户名或密码错误，请重新登录");
                    }
                    else
                    {
                        Login.Current.LoginID = txtID.Text;
                        Login.Current.LoginRole = "管理员";
                        FormMain fm = new FormMain();
                        fm.Show();
                        Hide();
                    }
                }
                else if (rdbCustom.Checked == true)
                {
                    string sql = "SELECT id FROM `求诊者信息` WHERE `求诊者编号`=@求诊者编号 AND `登录密码`=@登录密码";
                    MySqlParameter[] paras =
                    {
                        new MySqlParameter("@求诊者编号",txtID.Text),
                        new MySqlParameter("@登录密码",txtKey.Text)
                    };
                    DataTable dt = SqlHelper.GetDataTable(sql, paras);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("用户名或密码错误，请重新登录");
                    }
                    else
                    {
                        Login.Current.LoginID = txtID.Text;
                        Login.Current.LoginRole = "求诊者";
                        FormMain fm = new FormMain();
                        fm.Show();
                        Hide();
                    }
                }
                else
                {
                    string sql = "SELECT id FROM `医生信息` WHERE `医生编号`=@医生编号 AND `登录密码`=@登录密码";
                    MySqlParameter[] paras =
                    {
                        new MySqlParameter("@医生编号",txtID.Text),
                        new MySqlParameter("@登录密码",txtKey.Text)
                    };
                    DataTable dt = SqlHelper.GetDataTable(sql, paras);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("用户名或密码错误，请重新登录");
                    }
                    else
                    {
                        Login.Current.LoginID = txtID.Text;
                        Login.Current.LoginRole = "医生";
                        FormMain fm = new FormMain();
                        fm.Show();
                        Hide();
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)    //注册按钮
        {
            if (SqlHelper.ConnectTest())
            {
                FormLogin f = new FormLogin();
                FormCreate create = new FormCreate(f);
                create.Show();
                Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)  //退出按钮
        {
            Application.Exit();
        }
    }
}
