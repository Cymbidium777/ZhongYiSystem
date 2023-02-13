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
    public partial class FormDoctor : Form
    {
        int totalCount;
        public FormDoctor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据医生姓名模糊查询
        /// </summary>
        private void SelectDoctor()
        {
            int startIndex = uPager1.StartIndex;//开始索引
            int endIndex = startIndex + uPager1.PageSize - 1;//结束索引
            //参数数组
            MySqlParameter[] paras =
            {
                new MySqlParameter("keywords",txtKeywords.Text),
                new MySqlParameter("startIndex",startIndex),
                new MySqlParameter("endIndex",endIndex)
            };
            DataSet ds = SqlHelper.GetDataSet("FindSelectDoctorByPage", paras);
            int totalCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());//总记录数
            DataTable dt = ds.Tables[1];//数据列表
            dgvDoctorInfo.DataSource = dt;
            uPager1.TotalCount = totalCount;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDoctor();
            BindDgv();
        }

        /// <summary>
        /// 添加医生信息
        /// </summary>
        private void AddDoctor()
        {
            //判空处理
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("姓名不能为空!", "添加姓名提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("编号不能为空!", "添加编号提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("代码不能为空!", "添加代码提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //判断医生编号是否存在
            string sqlSelect = "select count(1) from `医生信息`  where 医生编号=@医生编号";
            MySqlParameter[] parasSelect =
            {
                new MySqlParameter("@医生编号",txtId.Text),
            };
            object o = SqlHelper.ExecuteScalar(sqlSelect, parasSelect);
            if (o != null && o != DBNull.Value && int.Parse(o.ToString()) > 0)
            {
                MessageBox.Show("该医生已经存在!", "添加医生提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //添加医生信息
            string sql = "insert into `医生信息`(医生编号,医生姓名,医生代码,注册日期,入职时间,特长科目,年龄,性别,居住地,学历,职称,备注) " +
                "values(@医生编号,@医生姓名,@医生代码,@注册日期,@入职时间,@特长科目,@年龄,@性别,@居住地,@学历,@职称,@备注)";
            MySqlParameter[] paras ={
                new MySqlParameter("@医生编号",txtId.Text),
                new MySqlParameter("@医生姓名",txtName.Text),
                new MySqlParameter("@医生代码",txtCode.Text),
                new MySqlParameter("@注册日期",DateTime.Now.ToString("D")),
                new MySqlParameter("@入职时间",DateTime.Now.ToString("D")),
                new MySqlParameter("@特长科目",txtCourse.Text),
                new MySqlParameter("@年龄",txtAge.Text),
                new MySqlParameter("@性别",rbtMale.Checked ? rbtMale.Text : rbtFemale.Text),
                new MySqlParameter("@居住地",txtPlace.Text),
                new MySqlParameter("@学历",txtEducation.Text),
                new MySqlParameter("@职称",txtProfession.Text),
                new MySqlParameter("@备注",txtRemark.Text)
            };
            int count = SqlHelper.ExecuteNonQuery(sql, paras);
            if (count > 0)
            {
                MessageBox.Show($"{txtName.Text}医生信息录入成功！", "录入信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("医生信息录入失败，请检查！", "录入信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 更新医生信息
        /// </summary>
        private void UpdateDoctor()
        {
            //判空处理
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("医生编号不能为空!", "修改编号提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("医生姓名不能为空!", "修改姓名提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("医生代码不能为空!", "修改医生代码提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql = "UPDATE `医生信息` set  医生姓名 = @医生姓名,医生代码 = @医生代码,年龄 = @年龄," +
                "性别 = @性别,居住地 = @居住地,特长科目 = @特长科目,学历 = @学历,职称 = @职称,备注 = @备注 where 医生编号 = @医生编号";
            MySqlParameter[] paras ={
                new MySqlParameter("@医生编号",txtId.Text),
                new MySqlParameter("@医生姓名",txtName.Text),
                new MySqlParameter("@医生代码",txtCode.Text),
                new MySqlParameter("@特长科目",txtCourse.Text),
                new MySqlParameter("@年龄",txtAge.Text),
                new MySqlParameter("@性别",rbtMale.Checked ? rbtMale.Text: rbtFemale.Text),
                new MySqlParameter("@居住地",txtPlace.Text),
                new MySqlParameter("@学历",txtEducation.Text),
                new MySqlParameter("@职称",txtProfession.Text),
                new MySqlParameter("@备注",txtRemark.Text)
            };
            int count = SqlHelper.ExecuteNonQuery(sql, paras);
            if (count > 0)
            {
                MessageBox.Show($"{txtName.Text}医生信息修改成功");
            }
            else
            {
                MessageBox.Show("该医生信息修改失败");
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateDoctor();
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
                txtId.Text = dgvDoctorInfo.Rows[e.RowIndex].Cells["医生编号"].Value.ToString();
                txtName.Text = dgvDoctorInfo.Rows[e.RowIndex].Cells["医生姓名"].Value.ToString();
                txtCode.Text = dgvDoctorInfo.Rows[e.RowIndex].Cells["医生代码"].Value.ToString();
                txtAge.Text = dgvDoctorInfo.Rows[e.RowIndex].Cells["年龄"].Value.ToString();
                string sex = dgvDoctorInfo.Rows[e.RowIndex].Cells["性别"].Value.ToString();
                if (sex == "男")
                    rbtMale.Checked = true;
                else
                    rbtFemale.Checked = true;
                txtPlace.Text = dgvDoctorInfo.Rows[e.RowIndex].Cells["居住地"].Value.ToString();
                txtCourse.Text = dgvDoctorInfo.Rows[e.RowIndex].Cells["特长科目"].Value.ToString();
                txtEducation.Text = dgvDoctorInfo.Rows[e.RowIndex].Cells["学历"].Value.ToString();
                txtProfession.Text = dgvDoctorInfo.Rows[e.RowIndex].Cells["职称"].Value.ToString();
                txtRemark.Text = dgvDoctorInfo.Rows[e.RowIndex].Cells["备注"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("数据获取有误，请选择正确的行！");
            }
        }

        /// <summary>
        /// 右键删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除该医生信息吗？", "删除医生信息提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete  from `医生信息` where 医生编号=@医生编号";
                MySqlParameter para = new MySqlParameter("@医生编号", txtId.Text);
                int count = SqlHelper.ExecuteNonQuery(sql, para);
                if (count > 0)
                {
                    MessageBox.Show($"{txtName.Text}医生信息删除成功");
                }
                else
                {
                    MessageBox.Show($"{txtName.Text}医生信息删除失败");
                }
            }
            BindDgv();
        }

        /// <summary>
        /// 医生列表
        /// </summary>
        private void BindDgv()
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
            DataSet ds = SqlHelper.GetDataSet("FindDoctorListByPage", paras);
            totalCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());//总记录数
            DataTable dt = ds.Tables[1];//数据列表
            dgvDoctorInfo.DataSource = dt;
            uPager1.TotalCount = totalCount;

        }

        /// <summary>
        /// 加载时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDoctor_Load(object sender, EventArgs e)
        {
            BindDgv();
        }

        /// <summary>
        /// 填充至textBox控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDoctorInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtCode.Text = "";
            rbtMale.Checked = false;
            rbtFemale.Checked = false;
            txtAge.Text = "";
            txtCourse.Text = "";
            txtEducation.Text = "";
            txtProfession.Text = "";
            txtPlace.Text = "";
            txtRemark.Text = "";
            LoadDataToDgv(e);
        }

        /// <summary>
        /// 右键操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDoctorInfo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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

        /// <summary>
        /// 鼠标点击清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKeywords_MouseDown(object sender, MouseEventArgs e)
        {
            txtKeywords.Clear();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            SelectDoctor();
        }

        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uPager1_PageChanged(object sender, EventArgs e)
        {
            BindDgv();
        }
    }
}
