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
using 中医信息管理系统.中医古籍;

namespace 中医信息管理系统
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void 濒湖脉学ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormMaiXue mx = new FormMaiXue();
                mx.MdiParent = this;
                mx.WindowState = FormWindowState.Maximized;
                mx.Show();
                mx.Activate();//切换页面,置顶
            }
        }

        private void 中药信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmMedicineIn frmMedicineIn = new FrmMedicineIn();
                frmMedicineIn.MdiParent = this;
                frmMedicineIn.WindowState = FormWindowState.Maximized;
                frmMedicineIn.Show();
                frmMedicineIn.Activate();//切换页面,置顶
            }
        }

        private void 民间偏方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormPeculiarPrescription pp = FormPeculiarPrescription.CreateInstance();
                pp.MdiParent = this;
                pp.WindowState = FormWindowState.Maximized;
                pp.Show();
                pp.Activate();//切换页面,置顶
            }
        }

        private void 历代名家ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormLogicians ls = FormLogicians.CreateInstance();
                ls.Show();
                ls.MdiParent = this;
                ls.WindowState = FormWindowState.Maximized;
                ls.Activate();//切换页面,置顶
            }
        }

        private void 伤寒杂病论ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormShangHanLun sh = new FormShangHanLun();
                sh.MdiParent = this;
                sh.WindowState = FormWindowState.Maximized;
                sh.Show();
                sh.Activate();//切换页面,置顶
            }
        }

        private void 成药信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmChengYao cy = new FrmChengYao();
                cy.MdiParent = this;
                cy.WindowState = FormWindowState.Maximized;
                cy.Show();
                cy.Activate();//切换页面,置顶
            }
        }

        private void 汤头方剂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmFangji fj = new FrmFangji();
                fj.MdiParent = this;
                fj.WindowState = FormWindowState.Maximized;
                fj.Show();
                fj.Activate();//切换页面,置顶
            }
        }

        private void 经络信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormJingLuo jl = new FormJingLuo();
                jl.MdiParent = this;
                jl.WindowState = FormWindowState.Maximized;
                jl.Show();
                jl.Activate();//切换页面,置顶
            }
        }

        private void 中医诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormZhenDuan zd = new FormZhenDuan();
                zd.MdiParent = this;
                zd.WindowState = FormWindowState.Maximized;
                zd.Show();
                zd.Activate();//切换页面,置顶
            }
        }

        private void 求诊信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FrmPatient qz = new FrmPatient();
                qz.MdiParent = this;
                qz.WindowState = FormWindowState.Maximized;
                qz.Show();
                qz.Activate();//切换页面,置顶
            }
        }

        private void 基本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SqlHelper.ConnectTest())
            {
                FormDoctor ys = new FormDoctor();
                ys.MdiParent = this;
                ys.WindowState = FormWindowState.Maximized;
                ys.Show();
                ys.Activate();//切换页面,置顶
            }
        }
    }
}
