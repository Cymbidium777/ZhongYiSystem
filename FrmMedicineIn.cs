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

namespace 中医信息管理系统
{
    public partial class FrmMedicineIn : Form
    {
        public FrmMedicineIn()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString() + "     ";
        }
        public void LoadIn()
        {
            dgvMedicineIn.Rows.Clear();
            string sql = "SELECT * FROM `中药信息`";
            DataTable dt = SqlHelper.GetDataTable(sql);
            dgvMedicineIn.DataSource = dt;
        }//加载中药信息

        private void FrmMedicineIn_Load(object sender, EventArgs e)
        {
            LoadIn();
            toolStripStatusLabel2.Text = "欢迎使用中药信息查询和录入界面";
        }
        public void AddMedicine()
        {
            string MC = txtMC.Text.Trim();
            string BM = txtBM.Text.Trim();
            string CD = txtCD.Text.Trim();
            string XWGJ = txtXWGJ.Text.Trim();
            string GL = txtGL.Text.Trim();
            string PZ = txtPZ.Text.Trim();
            string YF = txtYF.Text.Trim();
            string GJ = txtGJ.Text.Trim();
            string XGFJ = txtXGFJ.Text.Trim();
            string GX = txtGX.Text.Trim();
            string ZY = txtZY.Text.Trim();
            string BZ = txtBZ.Text.Trim();
            string sql = $"insert into `中药信息`(名称, 别名, 产地, 性味归经, 归类, 炮制, 用量用法, 歌诀, 相关方剂, 功效与应用, 注意事项, 备注) values(@名称,@别名, @产地, @性味归经, @归类, @炮制, @用量用法, @歌诀, @相关方剂, @功效与应用, @注意事项, @备注)";
            MySqlParameter[] paras ={
                new MySqlParameter("名称",MC),
                new MySqlParameter("别名",BM),
                new MySqlParameter("产地",CD),
                new MySqlParameter("性味归经",XWGJ),
                new MySqlParameter("归类",GL),
                new MySqlParameter("炮制",PZ),
                new MySqlParameter("用量用法",YF),
                new MySqlParameter("歌诀",GJ),
                new MySqlParameter("相关方剂",XGFJ),
                new MySqlParameter("功效与应用",GX),
                new MySqlParameter("注意事项",ZY),
                new MySqlParameter("备注",BZ),
            };
            if (string.IsNullOrEmpty(MC))
            {
                MessageBox.Show("名称不能为空!", "添加名称提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(BM))
            {
                MessageBox.Show("别名不能为空!", "添加别名提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(CD))
            {
                MessageBox.Show("产地不能为空!", "添加产地提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int count = SqlHelper.ExecuteNonQuery(sql, paras);
            if (count > 0)
            {
                MessageBox.Show($"该中药{MC}信息录入成功！", "录入信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("中药信息录入失败，请检查！", "录入信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Click_1(object sender, EventArgs e)//录入中药信息
        {
            AddMedicine();
        }

        public void Search()
        {
            string MC = txtName.Text;
            string sql = $"select * from `中药信息` where 名称 like '%{txtName.Text}%'";
            DataTable dt = SqlHelper.GetDataTable(sql);
            dgvMedicineIn.DataSource = dt;
        }//查询中药信息
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            Search();
        }
    }
}
