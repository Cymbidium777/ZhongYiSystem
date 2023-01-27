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
    public partial class FormCreate : Form
    {
        FormLogin login = null;
        string id;
        string date;
        string sex;
        string role;
        public FormCreate(FormLogin f)
        {
            login = f;
            InitializeComponent();
        }

        public void AddNewCustomer() //录入新用户信息
        {
            if (txtName.Text != "" && txtNumber.Text != "" && txtNumber.Text.Length == 18 && txtPhone.Text != "" & txtPhone.Text.Length == 11 && txtPW.Text != "")
            {
                string sql;
                int count;
                if (rdbCustom.Checked == true)
                {
                    sql = $"insert into `求诊者信息`(求诊者编号,登录密码, 求诊者姓名, 求诊者代码, 注册日期, 年龄, 性别, 生活地, 职业, 联系电话, 病史, 家族病史, 备注) values(@求诊者编号,@登录密码,@求诊者姓名, @求诊者代码, @注册日期, @年龄, @性别, @生活地, @职业, @联系电话, @病史, @家族病史, @备注)";
                    MySqlParameter[] paras =
                    {
                        new MySqlParameter("求诊者编号", id),
                        new MySqlParameter("登录密码", txtPW.Text),
                        new MySqlParameter("求诊者姓名", txtName.Text),
                        new MySqlParameter("求诊者代码", txtNumber.Text),
                        new MySqlParameter("注册日期", date),
                        new MySqlParameter("年龄", txtAge.Text),
                        new MySqlParameter("性别", sex),
                        new MySqlParameter("生活地", txtAddress.Text),
                        new MySqlParameter("职业", txtWorkOrIntime.Text),
                        new MySqlParameter("联系电话", txtPhone.Text),
                        new MySqlParameter("病史", txtSingleOrDegree.Text),
                        new MySqlParameter("家族病史", txtFamilyOrJobtitle.Text),
                        new MySqlParameter("备注", txtExtra.Text),
                    };
                    count = SqlHelper.ExecuteNonQuery(sql, paras);
                }
                else
                {
                    sql = $"insert into `医生信息`(医生编号,登录密码, 医生姓名, 医生代码, 注册日期, 年龄, 性别, 居住地, 入职时间, 特长科目, 学历, 职称, 备注) values(@医生编号,@登录密码,@医生姓名, @医生代码, @注册日期, @年龄, @性别, @居住地, @入职时间, @特长科目, @学历, @职称, @备注)";
                    MySqlParameter[] paras =
                    {
                        new MySqlParameter("医生编号", id),
                        new MySqlParameter("登录密码", txtPW.Text),
                        new MySqlParameter("医生姓名", txtName.Text),
                        new MySqlParameter("医生代码", txtNumber.Text),
                        new MySqlParameter("注册日期", date),
                        new MySqlParameter("年龄", txtAge.Text),
                        new MySqlParameter("性别", sex),
                        new MySqlParameter("居住地", txtAddress.Text),
                        new MySqlParameter("入职时间", txtWorkOrIntime.Text),
                        new MySqlParameter("特长科目", txtPhone.Text),
                        new MySqlParameter("学历", txtSingleOrDegree.Text),
                        new MySqlParameter("职称", txtFamilyOrJobtitle.Text),
                        new MySqlParameter("备注", txtExtra.Text),
                    };
                    count = SqlHelper.ExecuteNonQuery(sql, paras);
                }
                if (count > 0)
                {
                    MessageBox.Show("注册" + role + "成功！\n您的用户编号为：" + id + "\n您的密码为：" + txtPW.Text + "\n请妥善保管您的用户编号和密码！");
                    Login.Current.CreateID = id;
                    Login.Current.CreatePW = txtPW.Text;
                    Login.Current.CreateRole = role;
                    login.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("注册失败，请联系管理员");
                }
            }
            else
            {
                MessageBox.Show("输入内容有误，请检查");
            }
        }

        public void JudgeSex()  //判断性别
        {
            if (rdbMale.Checked == true)
            {
                sex = rdbMale.Text;
            }
            else
            {
                sex = rdbFemale.Text;
            }
        }

        public void JudgeRole() //判断角色
        {
            if (rdbCustom.Checked == true)
            {
                labFamilyOrJobtitle.Text = "家族病史";
                labPhoneOrSpecial.Text = "联系方式";
                labSingleOrDegree.Text = "个人病史";
                labWorkOrIntime.Text = "职业";
                role = "求诊者";
                txtPhone.Visible = true;
                txtPhone.Text = "";
                txtSpecial.Visible = false;
            }
            else
            {
                labFamilyOrJobtitle.Text = "职称";
                labPhoneOrSpecial.Text = "特长科目";
                labSingleOrDegree.Text = "学历";
                labWorkOrIntime.Text = "注册日期";
                role = "医生";
                txtPhone.Visible = false;
                txtPhone.Text = "11100001111";
                txtSpecial.Visible = true;
            }
            NewID();
            rdbMale.Checked = true;
            picPhoneNo.Visible = false;
            picPhoneYes.Visible = false;
        }

        private void NewID() //获取最新的编号及当前日期
        {
            string sql = "SELECT `" + role + "编号` FROM `" + role + "信息` ORDER BY `" + role + "编号`DESC"; //降序排序
            DataTable dt = SqlHelper.GetDataTable(sql);
            id = (int.Parse(dt.Rows[0][0].ToString()) + 1).ToString(); //类型转换
            date = DateTime.Now.ToString("D");
        }

        private void FormCreate_Load(object sender, EventArgs e)
        {
            rdbCustom.Checked = true;
        }

        private void btnCreate_Click(object sender, EventArgs e)    //注册按钮
        {
            AddNewCustomer();
        }

        private void btnCancel_Click(object sender, EventArgs e)    //取消按钮
        {
            login.Show();
            Close();
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)  //身份证号录入监测
        {
            if (txtNumber.Text.Length != 18)
            {
                picNumberNo.Visible = true;
                picNumberYes.Visible = false;
            }
            else
            {
                picNumberNo.Visible = false;
                picNumberYes.Visible = true;
            }
        }

        private void txtNumber_Leave(object sender, EventArgs e)    //身份证号文本框失去焦点
        {
            picNumberNo.Visible = false;
            picNumberYes.Visible = false;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)   //联系方式录入监测
        {
            if (txtPhone.Text.Length != 11)
            {
                picPhoneNo.Visible = true;
                picPhoneYes.Visible = false;
            }
            else
            {
                picPhoneNo.Visible = false;
                picPhoneYes.Visible = true;
            }

        }

        private void txtPhone_Leave(object sender, EventArgs e) //联系方式文本框失去焦点
        {
            picPhoneNo.Visible = false;
            picPhoneYes.Visible = false;
        }

        private void rdbDoctor_CheckedChanged(object sender, EventArgs e)   //医生选择属性值更改
        {
            JudgeRole();
        }

        private void rdbCustom_CheckedChanged(object sender, EventArgs e)   //求诊者选择属性值更改
        {
            JudgeRole();
        }
    }
}
