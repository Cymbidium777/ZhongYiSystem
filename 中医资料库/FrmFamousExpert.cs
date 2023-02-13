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

namespace 中医信息管理系统.信息库
{
    public partial class FrmFamousExpert : Form
    {
        public FrmFamousExpert()
        {
            InitializeComponent();
        }

        DataTable dtFamousExpert;

        private static FrmFamousExpert frmFamousExpert = null;//初始化窗体
        /// <summary>
        ///  //单例 只能出现一个窗体
        /// </summary>
        /// <returns></returns>
        public static FrmFamousExpert CreateInstance()
        {
            if (frmFamousExpert == null || frmFamousExpert.IsDisposed) //窗体为空或被释放
                frmFamousExpert = new FrmFamousExpert();
            return frmFamousExpert;
        }

        /// <summary>
        /// 获取历代名家信息,填充datagridView
        /// </summary>
        public void GetFamousExpertToDataGridView()
        {
            string sql = "select * from `历代名家信息`";
            dtFamousExpert = SqlHelper.GetDataTable(sql);
            dgvFamousExpert.DataSource = dtFamousExpert;
        }

        /// <summary>
        /// 获取历代名家信息,并添加至listView
        /// </summary>
        public void GetFamousExpertToListView(string sql, params MySqlParameter[] paras)
        {
            //初始化listView
            if (livFamousExpert.Items.Count > 0)
            {
                livFamousExpert.Items.Clear();
            }
            dtFamousExpert = SqlHelper.GetDataTable(sql, paras);
            int length = dtFamousExpert.Rows.Count;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dtFamousExpert.Rows[i]["姓名"].ToString();
                    item.SubItems.Add(dtFamousExpert.Rows[i]["朝代"].ToString());
                    item.SubItems.Add(dtFamousExpert.Rows[i]["备注"].ToString());
                    livFamousExpert.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("未查询到相关信息！", "查询历代名家提示",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        /// 根据历代名家姓名查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sql = "select 姓名,朝代,备注 from  `历代名家信息` where 姓名 like @姓名";
            MySqlParameter[] paras =
            {
                    new MySqlParameter("@姓名","%"+txtContent.Text+"%"),
                };
            GetFamousExpertToListView(sql, paras);
        }

        /// <summary>
        /// 进入界面时加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFamousExpert_Load(object sender, EventArgs e)
        {
            string sql = "select 姓名,朝代,备注 from `历代名家信息` ";
            GetFamousExpertToListView(sql);
            GetFamousExpertToDataGridView();
        }

        /// <summary>
        /// 点击listView获取相对应的历代名家信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void livFamousExpert_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < livFamousExpert.Items.Count; i++)
            {

                bool selected = livFamousExpert.Items[i].Selected;
                if (selected)
                {
                    string sql = "select * from `历代名家信息` where 姓名=@姓名 ";
                    MySqlParameter[] paras =
                    {
                        new MySqlParameter("@姓名",livFamousExpert.Items[i].Text),
                    };
                    DataTable dt = SqlHelper.GetDataTable(sql, paras);
                    int length = dt.Rows.Count;
                    if (length > 0)
                    {
                        rtbWork.Text = dt.Rows[0]["著作"].ToString();
                        rtbAchievement.Text = dt.Rows[0]["成就"].ToString();
                        rtbEvaluate.Text = dt.Rows[0]["人物评价"].ToString();
                        rtbLife.Text = dt.Rows[0]["生平"].ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 添加历代名家信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //判断空值
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("请完善数据", "添加偏方提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //判断姓名是否存在
            string sqlSelect = "select count(1) from `历代名家信息`  where 姓名=@姓名";
            MySqlParameter[] parasSelect =
            {
                new MySqlParameter("@姓名",txtName.Text),
            };
            object o = SqlHelper.ExecuteScalar(sqlSelect, parasSelect);
            if (o == null || o == DBNull.Value || int.Parse(o.ToString()) == 0)// DBNull.Value 适用于向数据库的表中插入空值
            {
                //添加偏方
                string sqlUpdate = "insert into `历代名家信息`(姓名,朝代,著作,成就,生平,人物评价,备注) " +
                    "VALUES(@姓名,@朝代,@著作,@成就,@生平,@人物评价,@备注)";
                MySqlParameter[] parasUpdate =
            {
                    new MySqlParameter("@姓名",txtName.Text),
                    new MySqlParameter("@朝代",txtDynasty.Text),
                    new MySqlParameter("@著作",txtWork.Text),
                    new MySqlParameter("@成就",txtAchievement.Text),
                    new MySqlParameter("@生平",txtLife.Text),
                    new MySqlParameter("@人物评价",txtEvaluate.Text),
                    new MySqlParameter("@备注",txtRemark.Text),
                };
                //处理结果
                int count = SqlHelper.ExecuteNonQuery(sqlUpdate, parasUpdate);
                if (count > 0)
                {
                    MessageBox.Show("添加成功！", "添加历代名家提示",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetFamousExpertToDataGridView();
                    return;        
                }
                else
                {
                    MessageBox.Show("添加失败", "添加历代名家提示",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("该名家已存在！", "添加历代名家提示",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// 更新历代名家信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //判断空值
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("请完善数据", "更新历代名家提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //判断姓名是否存在
            string sqlSelect = "select count(1) from `历代名家信息`  where 姓名=@姓名";
            MySqlParameter[] parasSelect =
            {
                new MySqlParameter("@姓名",txtName.Text),
            };
            object o = SqlHelper.ExecuteScalar(sqlSelect, parasSelect);
            if (o == null || o == DBNull.Value || int.Parse(o.ToString()) == 0)// DBNull.Value 适用于向数据库的表中插入空值
            {
                MessageBox.Show("更新失败,该名家不存在！", "更新历代名家提示",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                //更新偏方
                string sqlUpdate = "update `历代名家信息` set 朝代=@朝代,著作=@著作,成就=@成就,生平=@生平,人物评价=@人物评价,备注=@备注 where 姓名=@姓名";
                MySqlParameter[] parasUpdate =
                {
                    new MySqlParameter("@姓名",txtName.Text),
                    new MySqlParameter("@朝代",txtName.Text),
                    new MySqlParameter("@著作",txtWork.Text),
                    new MySqlParameter("@成就",txtAchievement.Text),
                    new MySqlParameter("@生平",txtLife.Text),
                    new MySqlParameter("@人物评价",txtEvaluate.Text),
                    new MySqlParameter("@备注",txtRemark.Text),
                };
                //处理结果
                int count = SqlHelper.ExecuteNonQuery(sqlUpdate, parasUpdate);
                if (count > 0)
                {
                    MessageBox.Show("更新成功！", "更新历代名家提示",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetFamousExpertToDataGridView();//重置历代名家信息
                    return;
                }
                else {
                    MessageBox.Show("更新失败！", "更新历代名家提示",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        /// <summary>
        /// 将Dgv中某行的数据加载到textBox中
        /// </summary>
        /// <param name="e"></param>
        private void dgvFamousExpert_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvFamousExpert.CurrentRow.Cells["姓名"].Value.ToString();
            txtDynasty.Text = dgvFamousExpert.CurrentRow.Cells["朝代"].Value.ToString();
            txtWork.Text = dgvFamousExpert.CurrentRow.Cells["著作"].Value.ToString();
            txtAchievement.Text = dgvFamousExpert.CurrentRow.Cells["成就"].Value.ToString();
            txtEvaluate.Text = dgvFamousExpert.CurrentRow.Cells["人物评价"].Value.ToString();
            txtLife.Text = dgvFamousExpert.CurrentRow.Cells["生平"].Value.ToString();
            txtRemark.Text = dgvFamousExpert.CurrentRow.Cells["备注"].Value.ToString();
        }

        /// <summary>
        /// 右键操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFamousExpert_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex > -1)
                    tsmDel.Visible = true;
            }
        }

        /// <summary>
        /// 右键删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show($"您确定要删除{dgvFamousExpert.CurrentRow.Cells["姓名"].Value.ToString()}的信息吗？", "删除历代名家信息提示",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete  from `历代名家信息` where 姓名=@姓名";
                MySqlParameter para = new MySqlParameter("@姓名", dgvFamousExpert.CurrentRow.Cells["姓名"].Value.ToString());
                int count = SqlHelper.ExecuteNonQuery(sql, para);
                if (count > 0)
                {
                    MessageBox.Show($"{dgvFamousExpert.CurrentRow.Cells["姓名"].Value.ToString()}名家信息删除成功");
                }
                else
                {
                    MessageBox.Show($"{dgvFamousExpert.CurrentRow.Cells["姓名"].Value.ToString()}名家信息删除失败");
                }
            }
            GetFamousExpertToDataGridView();
        }
    }
}
