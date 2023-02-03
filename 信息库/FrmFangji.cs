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
    public partial class FrmFangji : Form
    {
        public FrmFangji()
        {
            InitializeComponent();
        }
        private void DisplayTr()//在根节点下面添加各部分的子节点
        {
            string sql = "select DISTINCT(z.章节名称) from `汤方歌诀章节信息` as z INNER JOIN  `汤方歌诀汤方信息` as t where z.`章节编号`=t.`分类编号`";
            DataTable dt = SqlHelper.GetDataTable(sql);
            //MySqlParameter para1;
            //DataTable dt1;
            //string sql1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                trvFangji.Nodes.Add(dt.Rows[i][0].ToString());//添加根节点
            }
        }
        /// <summary>
        /// 根据每个根节点（即每个分类编号）查询相对应的名称
        /// </summary>
        /// <param name="value"></param>
        /// <param name="i"></param>
        public void GetName(string value, int i)
        {
            string sqlName = $"select 名称 from `汤方歌诀汤方信息` where 分类编号=\"" + value + "\"";
            DataTable dtName = SqlHelper.GetDataTable(sqlName);
            if (dtName.Rows.Count > 0)
            {
                for (int j = 0; j < dtName.Rows.Count; j++)
                {
                    trvFangji.Nodes[i].Nodes.Add(dtName.Rows[j][0].ToString());
                }
            }
        }

        private void DisPlayTb(string str)
        {
            string sql = " SELECT * FROM `汤方歌诀汤方信息` where  \"" + str + "\"=名称 ";
            DataTable dt = SqlHelper.GetDataTable(sql);
            int length = dt.Rows.Count;
            if (length > 0)
            {
                rtbMC.Text = dt.Rows[0]["名称"].ToString();
                rtbFG.Text = dt.Rows[0]["方歌"].ToString();
                rtbFJZC.Text = dt.Rows[0]["方剂组成"].ToString();
                rtbPZ.Text = dt.Rows[0]["炮制"].ToString();
                rtbYF.Text = dt.Rows[0]["用法用量"].ToString();
                rtbGX.Text = dt.Rows[0]["功效主治"].ToString();
                rtbFY.Text = dt.Rows[0]["方义分析"].ToString();
                rtbJJF.Text = dt.Rows[0]["加减方"].ToString();
                rtbLY.Text = dt.Rows[0]["来源"].ToString();
                rtbKS.Text = dt.Rows[0]["快速记忆"].ToString();
                rtbZY.Text = dt.Rows[0]["注意事项"].ToString();
                rtbBZ.Text = dt.Rows[0]["备注"].ToString();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------

        private void FrmFangji_Load(object sender, EventArgs e)
        {
            DisplayTr();
            BindDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        private void Search()
        {
            if (txtSearch.Text != "")
            {
                string MC = txtSearch.Text;
                string sql = $"select 名称,功效主治,来源,用法用量 from `汤方歌诀汤方信息` where  名称 like '%{txtSearch.Text}%'  GROUP BY 名称 ORDER BY 名称 ";
                MySqlParameter[] paras =
                {
                    new MySqlParameter("@分类编号",MC)
                };
                DataTable dt = SqlHelper.GetDataTable(sql, paras);
                int length = dt.Rows.Count;
                if (length > 0)
                {
                    if (trvFangji.Nodes.Count > 0)
                        trvFangji.Nodes.Clear();
                    for (int i = 0; i < length; i++)
                    {
                        string mc = dt.Rows[i]["名称"].ToString();
                        trvFangji.Nodes.Add(mc);
                    }
                }
                else
                {
                    MessageBox.Show("缺少该方剂数据", "查询方剂名称提示",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("请输入搜索内容");
            }
        }

        /// <summary>
        /// 绑定datagridview数据
        /// </summary>
        private void BindDgv()
        {
            //dgvFangji.Rows.Clear();
            string sql = " SELECT * FROM `汤方歌诀汤方信息`";
            DataTable dt = SqlHelper.GetDataTable(sql);
            dgvFangji.DataSource = dt;
        }

        /// <summary>
        /// 添加汤方歌诀汤方信息方法
        /// </summary>
        private void AddFangji()
        {
            string MC = txtMC.Text.Trim();
            string FG = txtFG.Text.Trim();
            string FJZC = txtFJZC.Text.Trim();
            string PZ = txtPZ.Text.Trim();
            string YF = txtYF.Text.Trim();
            string GX = txtGX.Text.Trim();
            string FY = txtFY.Text.Trim();
            string JJF = txtJJF.Text.Trim();
            string GL = txtGL.Text.Trim();
            string KSJY = txtKSJY.Text.Trim();
            string ZY = txtZY.Text.Trim();
            string LY = txtLY.Text.Trim();
            string BZ = txtBZ.Text.Trim();
            //判空处理
            if (string.IsNullOrEmpty(MC))
            {
                MessageBox.Show("名称不能为空!", "添加名称提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(GL))
            {
                MessageBox.Show("分类编号不能为空!", "添加分类编号提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(GX))
            {
                MessageBox.Show("功效主治不能为空!", "添加功效主治提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //判断方剂名称是否存在
            string sqlSelect = "select count(1) from `汤方歌诀汤方信息`  where 名称=@名称";
            MySqlParameter[] parasSelect =
            {
                new MySqlParameter("@名称",MC),
            };
            object o = SqlHelper.ExecuteScalar(sqlSelect, parasSelect);
            if (o != null && o != DBNull.Value && int.Parse(o.ToString()) > 0)
            {
                MessageBox.Show("该汤方歌诀汤方信息已经存在!", "添加汤方歌诀汤方信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //添加汤方歌诀汤方信息
            string sql = $"insert into `汤方歌诀汤方信息`(名称, 方歌, 方剂组成, 炮制, 用法用量, 功效主治, 方义分析, 加减方, 分类编号, 来源, 快速记忆, 注意事项,备注) values(@名称,@方歌, @方剂组成, @炮制, @用法用量, @功效主治, @方义分析, @加减方, @分类编号, @来源,@快速记忆, @注意事项, @备注)";
            MySqlParameter[] paras ={
                new MySqlParameter("名称",MC),
                new MySqlParameter("方歌",FG),
                new MySqlParameter("方剂组成",FJZC),
                new MySqlParameter("炮制",PZ),
                new MySqlParameter("用法用量",YF),
                new MySqlParameter("功效主治",GX),
                new MySqlParameter("方义分析",FY),
                new MySqlParameter("加减方",JJF),
                new MySqlParameter("分类编号",GL),
                new MySqlParameter("来源",LY),
                new MySqlParameter("快速记忆",KSJY),
                new MySqlParameter("注意事项",ZY),
                new MySqlParameter("备注",BZ),
            };
            int count = SqlHelper.ExecuteNonQuery(sql, paras);
            if (count > 0)
            {
                MessageBox.Show($"该方剂{MC}信息录入成功！", "录入信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("汤方歌诀汤方信息录入失败，请检查！", "录入信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddFangji();
            BindDgv();
        }

        private void trvFangji_AfterSelect(object sender, TreeViewEventArgs e)
        {
            trvFangji.SelectedNode.Nodes.Clear();
            int i = trvFangji.SelectedNode.Index;
            string name = trvFangji.SelectedNode.Text.ToString();
            string sql = $"SELECT `章节编号` from `汤方歌诀章节信息` where `章节名称`=\"" + name + "\"";
            DataTable dt = SqlHelper.GetDataTable(sql);
            string value;
            if (dt.Rows.Count > 0)
            {
                value = dt.Rows[0]["章节编号"].ToString();
                GetName(value, i);
            }
            string txt = trvFangji.SelectedNode.Text;
            DisPlayTb(txt);
            this.Text = "汤头方剂" + "——" + txt;
        }

        private void dgvFangji_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToDgv(e);
        }

        /// <summary>
        /// 将Dgv中某行的数据加载到textbook中
        /// </summary>
        /// <param name="e"></param>
        private void LoadDataToDgv(DataGridViewCellEventArgs e)
        {
            try
            {
                txtGL.Text = dgvFangji.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtMC.Text = dgvFangji.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtFG.Text = dgvFangji.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtFJZC.Text = dgvFangji.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtPZ.Text = dgvFangji.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtYF.Text = dgvFangji.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtGX.Text = dgvFangji.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtFY.Text = dgvFangji.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtJJF.Text = dgvFangji.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtLY.Text = dgvFangji.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtKSJY.Text = dgvFangji.Rows[e.RowIndex].Cells[12].Value.ToString();
                txtZY.Text = dgvFangji.Rows[e.RowIndex].Cells[13].Value.ToString();
                txtBZ.Text = dgvFangji.Rows[e.RowIndex].Cells[14].Value.ToString();
            }
            catch
            {
                MessageBox.Show("数据获取有误，请选择正确的行！");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateFangji();
            BindDgv();
        }

        private void UpdateFangji()
        {
            //判空处理
            if (string.IsNullOrEmpty(txtMC.Text))
            {
                MessageBox.Show("方剂名称不能为空!", "修改名称提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtGL.Text))
            {
                MessageBox.Show("分类编号不能为空!", "修改分类编号提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql = $"update `汤方歌诀汤方信息` set 名称='{txtMC.Text}',方歌='{txtFG.Text}',方剂组成='{txtFJZC.Text}',炮制='{txtPZ.Text}'," +
                            $" 用法用量='{txtYF.Text}',功效主治='{txtGX.Text}',方义分析='{txtFY.Text}',加减方='{txtJJF.Text}',分类编号='{txtGL.Text}' ,来源='{txtLY.Text}'," +
                            $" 快速记忆='{txtKSJY.Text}',注意事项='{txtZY.Text}',备注='{txtBZ.Text}' where 名称='{txtMC.Text}'";
            if (SqlHelper.ExecuteNonQuery(sql) > 0)
            {
                MessageBox.Show($"该方剂:{txtMC.Text}信息修改成功");
            }
            else
            {
                MessageBox.Show("该汤方歌诀汤方信息修改失败");
            }
        }

        private void dgvFangji_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex > -1)
                    tsmDel.Visible = true;
            }
        }
        /// <summary>
        /// 选中某行鼠标右击删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDel_Click(object sender, EventArgs e)
        {
            string MC = txtMC.Text.Trim();
            if (MessageBox.Show("您确定要删除该汤方歌诀汤方信息吗？", "删除方剂提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete  from `汤方歌诀汤方信息` where 名称=@名称";
                MySqlParameter para = new MySqlParameter("@名称", MC);
                int count = SqlHelper.ExecuteNonQuery(sql, para);
                if (count > 0)
                {
                    MessageBox.Show($"该方剂{txtMC.Text}信息删除成功");
                }
                else
                {
                    MessageBox.Show($"该方剂{txtMC.Text}信息删除失败");
                }
            }
            BindDgv();
        }

        private void btnMutiDel_Click(object sender, EventArgs e)
        {
            MutiDel();
        }

        /// <summary>
        /// 批量删除方法
        /// </summary>
        private void MutiDel()
        {
            //选择
            //获取要删除的数据stuId
            //判断选择的编号个数，=0 没有选择 提示用户选择要删除 的数据>0 继续
            //删除操作  事务  sql事务 代码里启动事务、
            List<int> listIds = new List<int>();
            for (int i = 0; i < dgvFangji.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = dgvFangji.Rows[i].Cells["colCheck"] as DataGridViewCheckBoxCell;
                bool chk = Convert.ToBoolean(cell.Value);
                if (chk)
                {
                    DataRow dr = (dgvFangji.Rows[i].DataBoundItem as DataRowView).Row;
                    int id = (int)dr["编号".ToString()];
                    listIds.Add(id);
                }
            }

            //真删除
            if (listIds.Count == 0)
            {
                MessageBox.Show("请选择要删除的汤方歌诀汤方信息！", "删除方剂提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("您确定要删除该汤方歌诀汤方信息吗？", "删除方剂提示",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int count = 0;
                    //启动事务进行操作
                    using (MySqlConnection conn = new MySqlConnection(SqlHelper.connString))
                    {
                        //事务是通过conn连接对象来开启的，conn.open()
                        conn.Open();
                        MySqlTransaction trans = conn.BeginTransaction();
                        //SqlCommand 事务的执行 cmd
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.Transaction = trans;

                        try
                        {
                            foreach (int idDel in listIds)
                            {
                                cmd.CommandText = "delete from `汤方歌诀汤方信息` where 编号=@编号";
                                MySqlParameter para = new MySqlParameter("@编号", idDel);
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add(para);
                                count += cmd.ExecuteNonQuery();
                            }
                            trans.Commit();
                        }
                        catch (MySqlException)
                        {
                            trans.Rollback();
                            MessageBox.Show("删除汤方歌诀汤方信息出现异常！", "删除方剂提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (count == listIds.Count)
                    {
                        MessageBox.Show("这批汤方歌诀汤方信息删除成功！", "删除方剂提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //手动刷新
                        DataTable dt = (DataTable)dgvFangji.DataSource;
                        //dgvStudents.DataSource = null;
                        string idStr = string.Join(",", listIds);
                        DataRow[] rows = dt.Select("编号 in(" + idStr + ")");
                        foreach (DataRow dr in rows)
                        {
                            dt.Rows.Remove(dr);
                        }
                        dgvFangji.DataSource = dt;
                    }
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Text = null;
            if (trvFangji.Nodes.Count > 0)
                trvFangji.Nodes.Clear();
            DisplayTr();
        }
    }
}
