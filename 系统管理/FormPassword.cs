using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using 中医信息管理系统.entity;

namespace GMS.系统管理
{
    public partial class FormPassword : Form
    {
        string id = Login.Current.LoginID;
        int count;

        public FormPassword()
        {
            InitializeComponent();
        }

        private bool JudgeRole()    //判断当前用户身份
        {
            if (Login.Current.LoginRole == "医生")
            {
                return true;
            }
            else if (Login.Current.LoginRole == "求诊者")
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        private void ChangeDoctor() //修改医生密码
        {
            //更新密码操作
            string sqlPassword = "update `医生信息` set `登录密码` = @登录密码 where `医生编号` = @医生编号";
            MySqlParameter[] parasPassword =
            {
                new MySqlParameter("@登录密码",textBox2.Text),
                new MySqlParameter("@医生编号",id),
            };
            //处理结果
            count = SqlHelper.ExecuteNonQuery(sqlPassword, parasPassword);
        }

        private void ChangePatient()    //修改求诊者密码
        {
            //更新密码操作
            string sqlPassword = "update `求诊者信息` set `登录密码` = @登录密码 where `求诊者编号` = @求诊者编号";
            MySqlParameter[] parasPassword =
            {
                new MySqlParameter("@登录密码",textBox2.Text),
                new MySqlParameter("@求诊者编号",id),
            };
            //处理结果
            count = SqlHelper.ExecuteNonQuery(sqlPassword, parasPassword);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("提示：输入不能为空！", "警告");
            else if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("两次输入的密码不一致，请重新输入！", "警告");
            }
            else
            {
                if (JudgeRole())
                {
                    ChangeDoctor();
                }
                else
                {
                    ChangePatient();
                }
                if (count > 0)
                {
                    MessageBox.Show("修改密码成功！", "修改密码成功提示",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("修改密码失败", "修改密码失败提示",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.UseSystemPasswordChar == true)
            {
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
