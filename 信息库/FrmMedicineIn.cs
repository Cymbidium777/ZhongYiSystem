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

        public void LoadIn()    //加载中药信息
        {
            dgvMedicineIn.DataSource = null;
            string sql = "SELECT * FROM `中药信息`";
            DataTable dt = SqlHelper.GetDataTable(sql);
            dgvMedicineIn.DataSource = dt;
            dgvMedicineIn.Columns[0].Visible = false;
        }

        private void FrmMedicineIn_Load(object sender, EventArgs e)
        {
            LoadIn();
            btnAdd.Visible = false;
        }

        public void AddMedicine()
        {
            string sql = $"insert into `中药信息`(名称, 别名, 产地, 性味归经, 归类, 炮制, 用量用法, 歌诀, 相关方剂, 功效与应用, 注意事项, 备注) values(@名称,@别名, @产地, @性味归经, @归类, @炮制, @用量用法, @歌诀, @相关方剂, @功效与应用, @注意事项, @备注)";
            MySqlParameter[] paras =
            {
                new MySqlParameter("名称",txtMC.Text),
                new MySqlParameter("别名",txtBM.Text),
                new MySqlParameter("产地",txtXWGJ.Text),
                new MySqlParameter("性味归经",txtCD.Text),
                new MySqlParameter("归类",txtGL.Text),
                new MySqlParameter("炮制",txtPZ.Text),
                new MySqlParameter("用量用法",txtYF.Text),
                new MySqlParameter("歌诀",txtGJ.Text),
                new MySqlParameter("相关方剂",txtXGFJ.Text),
                new MySqlParameter("功效与应用",txtGX.Text),
                new MySqlParameter("注意事项",txtZY.Text),
                new MySqlParameter("备注",txtBZ.Text),
            };
            if (string.IsNullOrEmpty(txtMC.Text))
            {
                MessageBox.Show("名称不能为空!", "添加名称提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtBM.Text))
            {
                MessageBox.Show("别名不能为空!", "添加别名提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtXWGJ.Text))
            {
                MessageBox.Show("产地不能为空!", "添加产地提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int count = SqlHelper.ExecuteNonQuery(sql, paras);
            if (count > 0)
            {
                MessageBox.Show($"信息录入成功！", "录入信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadIn();
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

        public void Search()    //查询中药信息s
        {
            string sql = $"select * from `中药信息` where 名称 like '%{txtName.Text}%'";
            DataTable dt = SqlHelper.GetDataTable(sql);
            dgvMedicineIn.DataSource = dt;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            Search();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                txtName.Visible = true;
                btnSearch.Visible = true;
                btnBack.Visible = true;
                btnAdd.Visible = false;
                txtName.Clear();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                btnAdd.Visible = true;
                txtName.Visible = false;
                btnSearch.Visible = false;
                btnBack.Visible = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            LoadIn();
        }
    }
}