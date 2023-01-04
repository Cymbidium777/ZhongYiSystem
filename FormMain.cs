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
            FormMaiXue mx = new FormMaiXue();
            mx.Show();
        }

        private void 中药信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMedicineIn frmMedicineIn = new FrmMedicineIn();
            frmMedicineIn.Show();
        }

        private void 民间偏方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPeculiarPrescription pp = FormPeculiarPrescription.CreateInstance();
            pp.Show();
            pp.Activate();//切换页面,置顶
        }

        private void 历代名家ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogicians ls = FormLogicians.CreateInstance();
            ls.Show();
            ls.Activate();//切换页面,置顶
        }

        private void 伤寒杂病论ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShangHanLun sh = new FormShangHanLun();
            sh.Show();
        }

        private void 成药信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChengYao cy = new FrmChengYao();
            cy.MdiParent = this;
            cy.WindowState = FormWindowState.Maximized;
            cy.Show();
        }

        private void 汤头方剂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFangji fj = new FrmFangji();
            fj.MdiParent = this;
            fj.WindowState = FormWindowState.Maximized;
            fj.Show();
        }

        private void 经络信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormJingLuo jl = new FormJingLuo();
            jl.Show();
        }

        private void 中医诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormZhenDuan zd = new FormZhenDuan();
            zd.Show();
        }
    }
}
