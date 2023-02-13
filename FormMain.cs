using GMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 中医信息管理系统.entity;
using 中医信息管理系统.中医古籍;
using 中医信息管理系统.信息库;
using 中医信息管理系统.帮助;

namespace 中医信息管理系统
{
    public partial class FormMain : Form
    {
        public bool TabControlCheckHave(TabControl tab, string tabName) //看tabpage中是否已有窗体
        {
            for (int i = 0; i < tab.TabCount; i++)
            {
                if (tab.TabPages[i].Text == tabName)
                {
                    tab.SelectedIndex = i;
                    return true;
                }
            }
            return false;
        }

        public void OpenForm(Form myForm)   //打开选中窗体
        {
            panelForm.Controls.Clear();
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.TopLevel = false;
            myForm.Show();
            myForm.Parent = panelForm;
            myForm.Dock = DockStyle.Fill;
        }

        //public void Add_TabPage(string str, Form myForm) //将标题添加进tabpage中
        //{
        //    if (!TabControlCheckHave(this.tabControl1, str))
        //    {
        //        tabControl1.TabPages.Clear();
        //        tabControl1.TabPages.Add(str);
        //        tabControl1.SelectTab((int)(tabControl1.TabPages.Count - 1));
        //        myForm.FormBorderStyle = FormBorderStyle.None;
        //        myForm.TopLevel = false;
        //        myForm.Show();
        //        myForm.Parent = tabControl1.SelectedTab;
        //        myForm.Dock = DockStyle.Fill;
        //    }
        //}

        //public void CloseTabPage(int selectedIndex) //关闭标签页
        //{
        //    tabControl1.TabPages.RemoveAt(selectedIndex);
        //}

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (Login.Current.LoginID=="000000")
            {
                用户管理ToolStripMenuItem.Enabled = true;
                权限管理ToolStripMenuItem.Enabled = true;
                诊断报告ToolStripMenuItem.Enabled = false;
            }
            else if (Login.Current.LoginRole == "求诊者")
            {
                用户信息ToolStripMenuItem.Enabled = false;
                中医资料库ToolStripMenuItem.Enabled = false;
                医生诊断ToolStripMenuItem.Enabled = false;
                仪器诊断ToolStripMenuItem.Enabled = false;
            }
        }

        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)  //双击关闭标签页
        {
            //if (e.Button == MouseButtons.Left) // 只有左键双击才响应关闭
            //    CloseTabPage(tabControl1.SelectedIndex);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void 医生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormDoctor form = new FormDoctor();
                OpenForm(form);
                //Add_TabPage(mx.Text, mx);
            }
        }

        private void 求诊者信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmPatient form = new FrmPatient();
                OpenForm(form);
                //Add_TabPage(mx.Text, mx);
            }
        }

        private void 查询报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormZhenDuan form = new FormZhenDuan();
                OpenForm(form);
                //Add_TabPage(mx.Text, mx);
            }
        }

        private void 中药信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmMedicineIn form = new FrmMedicineIn();
                OpenForm(form);
                //Add_TabPage(mx.Text, mx);
            }
        }

        private void 成药信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmChengYao form = new FrmChengYao();
                OpenForm(form);
                //Add_TabPage(mx.Text, mx);
            }
        }

        private void 汤头方剂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmFangji form = new FrmFangji();
                OpenForm(form);
                //Add_TabPage(mx.Text, mx);
            }
        }

        private void 濒湖脉学ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormMaiXue form = new FormMaiXue();
                OpenForm(form);
                //Add_TabPage(mx.Text, mx);
            }
        }

        private void 伤寒杂病论ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormShangHanLun form = new FormShangHanLun();
                OpenForm(form);
                //Add_TabPage(mx.Text, mx);
            }
        }

        private void 历代名家ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmFamousExpert form = new FrmFamousExpert();
                OpenForm(form);
                //Add_TabPage(mx.Text, mx);
            }
        }

        private void 民间偏方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmPeculiarPrescription form = new FrmPeculiarPrescription();
                OpenForm(form);
                //Add_TabPage(mx.Text, mx);
            }
        }

        private void 经络信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormJingLuo form = new FormJingLuo();
                OpenForm(form);
                //Add_TabPage(mx.Text, mx);
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.Show();
            //Add_TabPage(mx.Text, mx);
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("您确定要退出登陆吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                FormMain M = new FormMain();
                FormLogin create = new FormLogin(M);
                create.Show();
                Hide();
            }
        }
    }
}
