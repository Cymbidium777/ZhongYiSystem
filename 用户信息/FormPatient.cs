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
    public partial class FrmPatient : Form
    {
        int totalCount;
        public FrmPatient()
        {
            InitializeComponent();
        }

        private void FrmPatient_Load(object sender, EventArgs e)
        {
            BindDgv();
        }
        
        private void BindDgv()  //刷新Datagridview
        {
            //dgvFangji.Rows.Clear();
            int startIndex = uPager1.StartIndex;//开始索引
            int endIndex = startIndex + uPager1.PageSize - 1;//结束索引
            //参数数组
            MySqlParameter[] paras =
            {
                new MySqlParameter("startIndex",startIndex),
                new MySqlParameter("endIndex",endIndex)
            };
            DataSet ds = SqlHelper.GetDataSet("FindPatientListByPage", paras);
            totalCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());//总记录数
            DataTable dt = ds.Tables[1];//数据列表
            dgvPatientInfo.DataSource = dt;
            uPager1.TotalCount = totalCount;
        }

        private void uPager1_PageChanged(object sender, EventArgs e)
        {
            BindDgv();
        }
        
        private void AddPatient()
        {
            string Id = txtId.Text.Trim();
            string Name = txtName.Text.Trim();
            string DM = txtDM.Text.Trim();
            string Age = txtAge.Text.Trim();
            string Sex = rbtMale.Checked ? rbtMale.Text : rbtFemale.Text;//三目运算符，只能选中一个性别
            string Place = txtPlace.Text.Trim();
            string Career  = txtCareer.Text.Trim();
            string Phone = txtPhone.Text.Trim();
            string Disease = txtDisease.Text.Trim();
            string Homedisease = txthomedisease.Text.Trim();
            string Remark = txtRemark.Text.Trim();
            //判空处理
            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("姓名不能为空!", "添加姓名提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(Id))
            {
                MessageBox.Show("编号不能为空!", "添加编号提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(DM))
            {
                MessageBox.Show("代码不能为空!", "添加代码提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //判断求诊者编号是否存在
            string sqlSelect = "select count(1) from `求诊者信息`  where 求诊者编号=@求诊者编号";
            MySqlParameter[] parasSelect =
            {
                new MySqlParameter("@求诊者编号",Id),
            };
            object o = SqlHelper.ExecuteScalar(sqlSelect, parasSelect);
            if (o != null && o != DBNull.Value && int.Parse(o.ToString()) > 0)
            {
                MessageBox.Show("该求诊者已经存在!", "添加求诊者提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //添加求诊者信息
            string sql = "insert into `求诊者信息`(求诊者编号,求诊者姓名,求诊者代码,注册日期,年龄,性别,生活地,职业,联系电话,病史,家族病史,备注) " +
                "values(@求诊者编号,@求诊者姓名,@求诊者代码,@注册日期,@年龄,@性别,@生活地,@职业,@联系电话,@病史,@家族病史,@备注)";
            MySqlParameter[] paras ={
                new MySqlParameter("@求诊者编号",Id),
                new MySqlParameter("@求诊者姓名",Name),
                new MySqlParameter("@求诊者代码",DM),
                new MySqlParameter("@注册日期",DateTime.Now.ToString("D")),
                new MySqlParameter("@年龄",Age),
                new MySqlParameter("@性别",Sex),
                new MySqlParameter("@生活地",Place),
                new MySqlParameter("@职业",Career),
                new MySqlParameter("@联系电话",Phone),
                new MySqlParameter("@病史",Disease),
                new MySqlParameter("@家族病史",Homedisease),
                new MySqlParameter("@备注",Remark)
            };
            int count = SqlHelper.ExecuteNonQuery(sql, paras);
            if (count > 0)
            {
                MessageBox.Show($"该求诊者：{Name}信息录入成功！", "录入信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("求诊者信息录入失败，请检查！", "录入信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPatient();
            BindDgv();
        }
        
        /// <summary>
        /// 将Dgv中某行的数据加载到textbook中
        /// </summary>
        /// <param name="e"></param>
        private void LoadDataToDgv(DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dgvPatientInfo.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtName.Text = dgvPatientInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDM.Text = dgvPatientInfo.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtAge.Text = dgvPatientInfo.Rows[e.RowIndex].Cells[5].Value.ToString();
                string sex = dgvPatientInfo.Rows[e.RowIndex].Cells[6].Value.ToString();
                if (sex == "男")
                    rbtMale.Checked = true;
                else
                    rbtFemale.Checked = true;
                txtPlace.Text = dgvPatientInfo.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtCareer.Text = dgvPatientInfo.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtPhone.Text = dgvPatientInfo.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtDisease.Text = dgvPatientInfo.Rows[e.RowIndex].Cells[10].Value.ToString();
                txthomedisease.Text = dgvPatientInfo.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtRemark.Text = dgvPatientInfo.Rows[e.RowIndex].Cells[12].Value.ToString();
            }
            catch
            {
                MessageBox.Show("数据获取有误，请选择正确的行！");
            }
        }

        private void dgvPatientInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtDM.Text = "";
            rbtMale.Checked = false;
            rbtFemale.Checked = false;
            txtAge.Text = "";
            txtCareer.Text = "";
            txtDisease.Text = "";
            txthomedisease.Text = "";
            txtPhone.Text = "";
            txtRemark.Text = "";
            LoadDataToDgv(e);
        }
        
        private void UpdatePatient()
        {
            string Id = txtId.Text.Trim();
            string Name = txtName.Text.Trim();
            string DM = txtDM.Text.Trim();
            string Age = txtAge.Text.Trim();
            string Sex = rbtMale.Checked ? rbtMale.Text : rbtFemale.Text;//三目运算符，只能选中一个性别
            string Place = txtPlace.Text.Trim();
            string Career = txtCareer.Text.Trim();
            string Phone = txtPhone.Text.Trim();
            string Disease = txtDisease.Text.Trim();
            string Homedisease = txthomedisease.Text.Trim();
            string Remark = txtRemark.Text.Trim();
            //判空处理
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("求诊者编号不能为空!", "修改编号提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("求诊者姓名不能为空!", "修改姓名提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtDM.Text))
            {
                MessageBox.Show("求诊者代码不能为空!", "修改求诊者代码提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql = "UPDATE `求诊者信息` set  求诊者姓名 = @求诊者姓名,求诊者代码 = @求诊者代码,年龄 = @年龄," +
                "性别 = @性别,生活地 = @生活地,职业 = @职业,联系电话 = @联系电话,病史 = @病史,家族病史 = @家族病史,备注 = @备注 where 求诊者编号 = @求诊者编号";
            MySqlParameter[] paras ={
                new MySqlParameter("@求诊者编号",Id),
                new MySqlParameter("@求诊者姓名",Name),
                new MySqlParameter("@求诊者代码",DM),
                new MySqlParameter("@年龄",Age),
                new MySqlParameter("@性别",Sex),
                new MySqlParameter("@生活地",Place),
                new MySqlParameter("@职业",Career),
                new MySqlParameter("@联系电话",Phone),
                new MySqlParameter("@病史",Disease),
                new MySqlParameter("@家族病史",Homedisease),
                new MySqlParameter("@备注",Remark)
            };
            int count = SqlHelper.ExecuteNonQuery(sql, paras);
            if (count > 0)
            {
                MessageBox.Show($"该求诊者:{txtName.Text}信息修改成功");
            }
            else
            {
                MessageBox.Show("该求诊者信息修改失败");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdatePatient();
            BindDgv();
        }

        private void tsmDel_Click(object sender, EventArgs e)
        {
            string Id = dgvPatientInfo.CurrentRow.Cells["求诊者编号"].Value.ToString();
            if (MessageBox.Show("您确定要删除该求诊者信息吗？", "删除求诊者信息提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete  from `求诊者信息` where 求诊者编号=@求诊者编号";
                MySqlParameter para = new MySqlParameter("@求诊者编号", Id);
                int count = SqlHelper.ExecuteNonQuery(sql, para);
                if (count > 0)
                {
                    MessageBox.Show($"该求诊者信息{txtName.Text}信息删除成功");
                }
                else
                {
                    MessageBox.Show($"该求诊者信息{txtName.Text}信息删除失败");
                }
            }
            BindDgv();
        }

        private void dgvPatientInfo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tsmDel.Visible = true;
                if (e.RowIndex >= totalCount)
                {
                    tsmDel.Visible = false;
                }
            }
        }
    }
}
