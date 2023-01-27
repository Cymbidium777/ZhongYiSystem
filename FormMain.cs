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
using 中医信息管理系统.中医古籍;

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
            if (Login.Current.LoginRole == "求诊者")
            {
                基本信息ToolStripMenuItem.Enabled = false;
                信息查询ToolStripMenuItem.Enabled = false;
                基础理论ToolStripMenuItem.Enabled = false;
            }
        }

        private void 濒湖脉学ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormMaiXue mx = new FormMaiXue();
                OpenForm(mx);
                //Add_TabPage(mx.Text, mx);
            }
        }

        private void 中药信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmMedicineIn frmMedicineIn = new FrmMedicineIn();
                OpenForm(frmMedicineIn);
                //Add_TabPage(frmMedicineIn.Text, frmMedicineIn);
            }
        }

        private void 民间偏方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormPeculiarPrescription pp = FormPeculiarPrescription.CreateInstance();
                OpenForm(pp);
                //Add_TabPage(pp.Text, pp);
            }
        }

        private void 历代名家ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormLogicians ls = FormLogicians.CreateInstance();
                OpenForm(ls);
                //Add_TabPage(ls.Text, ls);
            }
        }

        private void 伤寒杂病论ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormShangHanLun sh = new FormShangHanLun();
                OpenForm(sh);
                //Add_TabPage(sh.Text, sh);
            }
        }

        private void 成药信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmChengYao cy = new FrmChengYao();
                OpenForm(cy);
                //Add_TabPage(cy.Text, cy);
            }
        }

        private void 汤头方剂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmFangji fj = new FrmFangji();
                OpenForm(fj);
                //Add_TabPage(fj.Text, fj);
            }
        }

        private void 经络信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormJingLuo jl = new FormJingLuo();
                OpenForm(jl);
                //Add_TabPage(jl.Text, jl);
            }
        }

        private void 中医诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormZhenDuan zd = new FormZhenDuan();
                OpenForm(zd);
                //Add_TabPage(zd.Text, zd);
            }
        }

        private void 求诊信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmPatient qz = new FrmPatient();
                OpenForm(qz);
                //Add_TabPage(qz.Text, qz);
            }
        }

        private void 基本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormDoctor ys = new FormDoctor();
                OpenForm(ys);
                //Add_TabPage(ys.Text, ys);
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
    }
}
