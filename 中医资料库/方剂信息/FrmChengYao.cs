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
    public partial class FrmChengYao : Form
    {
        public FrmChengYao()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 循环添加三层节点
        /// </summary>
        private void DisplayTr()//在根节点下面添加各部分的子节点
        {
            string sql = "SELECT distinct(归类) FROM `成药信息`";
            DataTable dt = SqlHelper.GetDataTable(sql);
            MySqlParameter para1, para2;
            DataTable dt1, dt2;
            string sql1, sql2;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                trvChengyao.Nodes.Add(dt.Rows[i][0].ToString());//添加根节点
                //根据每个根节点（即每个归类）查询相对应的名称
                sql1 = "select distinct(功能分类) from `成药信息` where 归类=@归类";
                para1 = new MySqlParameter("归类", dt.Rows[i][0].ToString());
                dt1 = SqlHelper.GetDataTable(sql1, para1);
                if (dt1.Rows.Count > 0)
                {
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        trvChengyao.Nodes[i].Nodes.Add(dt1.Rows[j][0].ToString());//添加根节点下的子节点
                        sql2 = "select 名称 from `成药信息` where 功能分类=@功能分类 ";
                        para2 = new MySqlParameter("功能分类", dt1.Rows[j][0].ToString());
                        dt2 = SqlHelper.GetDataTable(sql2, para2);
                        if (dt2.Rows.Count > 0)
                        {
                            for (int k = 0; k < dt2.Rows.Count; k++)
                            {
                                trvChengyao.Nodes[i].Nodes[j].Nodes.Add(dt2.Rows[k][0].ToString());
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 点击子节点显示详细信息
        /// </summary>
        /// <param name="str"></param>
        private void DisPlayTb(string str)
        {
            string sql = " SELECT * FROM `成药信息` where  \"" + str + "\"=名称 ";
            DataTable dt = SqlHelper.GetDataTable(sql);
            int length = dt.Rows.Count;
            if (length > 0)
            {
                rtbMC.Text = dt.Rows[0]["名称"].ToString();
                rtbCF.Text = dt.Rows[0]["处方"].ToString();
                rtbZB.Text = dt.Rows[0]["制备方法"].ToString();
                rtbYFFX.Text = dt.Rows[0]["药方分析"].ToString();
                rtbJX.Text = dt.Rows[0]["剂型规格"].ToString();
                rtbGX.Text = dt.Rows[0]["功效主治"].ToString();
                rtbYF.Text = dt.Rows[0]["用法用量"].ToString();
                rtbJJ.Text = dt.Rows[0]["使用禁忌"].ToString();
                rtbYY.Text = dt.Rows[0]["临床应用"].ToString();
                rtbZC.Text = dt.Rows[0]["贮藏"].ToString();
                rtbFG.Text = dt.Rows[0]["方歌"].ToString();
            }
        }
        private void FrmChengYao_Load(object sender, EventArgs e)
        {
            trvSearch.Visible = false;
            DisplayTr();
            BindDgv();
        }
        /// <summary>
        /// 模糊查询功能方法
        /// </summary>
        private void Search()
        {
            if (txtSearch.Text != "")
            {
                trvSearch.Visible = true;
                string MC = txtSearch.Text;
                string sql = $"select  distinct(功能分类) from `成药信息` where 归类 like '%{txtSearch.Text}%' or 功能分类 like '%{txtSearch.Text}%'";
                MySqlParameter[] paras =
                {
                new MySqlParameter("@归类",MC)
                };
                DataTable dt = SqlHelper.GetDataTable(sql, paras);
                int length = dt.Rows.Count;
                if (length > 0)
                {
                    if (trvSearch.Nodes.Count > 0)
                        trvSearch.Nodes.Clear();
                    for (int i = 0; i < length; i++)
                    {
                        string fl = dt.Rows[i]["功能分类"].ToString();
                        trvSearch.Nodes.Add(fl);
                    }
                }
                else
                {
                    MessageBox.Show("缺少该成药数据", "查询名称提示",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    trvSearch.Visible = false;
                    trvChengyao.Visible = true;
                    return;
                }
            }
            else
            {
                MessageBox.Show("请输入搜索内容");
                trvSearch.Visible = false;
                trvChengyao.Visible = true;
            }
        }

        private void trvChengyao_AfterSelect(object sender, TreeViewEventArgs e)
        {
                string txt = trvChengyao.SelectedNode.Text;
                DisPlayTb(txt);
                this.Text = "成药信息" + "——" + txt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        /// <summary>
        /// 点击根节点显示详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvSearch_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string str = trvSearch.SelectedNode.Text;
            string  sql = $"select  名称 from `成药信息` where 功能分类=\""+str+"\"";
            DataTable dt = SqlHelper.GetDataTable(sql);
            int i = trvSearch.SelectedNode.Index;
            if (dt.Rows.Count > 0)
            {
                trvSearch.SelectedNode.Nodes.Clear();
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    trvSearch.Nodes[i].Nodes.Add(dt.Rows[k][0].ToString());
                }
            }
            string txt = trvSearch.SelectedNode.Text;
            DisPlayTb(txt);
            this.Text = "成药信息" + "——" + txt;
        }

        /// <summary>
        /// esc按键快速关闭搜索框，打开成药信息主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEsc_Click(object sender, EventArgs e)
        {
            trvSearch.Nodes.Clear();
            trvSearch.Visible = false;
            txtSearch.Text = null;
        }
        /// <summary>
        /// DataGridView绑定数据
        /// </summary>
        private void BindDgv()
        {
            //dgvFangji.Rows.Clear();
            string sql = " SELECT * FROM `成药信息`";
            DataTable dt = SqlHelper.GetDataTable(sql);
            dgvChengYao.DataSource = dt;
        }
        /// <summary>
        /// 将Dgv中某行的数据加载到textbook中
        /// </summary>
        /// <param name="e"></param>
        private void LoadDataToDgv(DataGridViewCellEventArgs e)
        {
            try
            {
                txtMC.Text = dgvChengYao.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCF.Text = dgvChengYao.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtZB.Text = dgvChengYao.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtYFFX.Text = dgvChengYao.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtJX.Text = dgvChengYao.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtGX.Text = dgvChengYao.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtYF.Text = dgvChengYao.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtJJ.Text = dgvChengYao.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtYY.Text = dgvChengYao.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtZC.Text = dgvChengYao.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtFG.Text = dgvChengYao.Rows[e.RowIndex].Cells[12].Value.ToString();
                txtGL.Text = dgvChengYao.Rows[e.RowIndex].Cells[13].Value.ToString();
                txtFL.Text = dgvChengYao.Rows[e.RowIndex].Cells[14].Value.ToString();
            }
            catch
            {
                MessageBox.Show("数据获取有误，请选择正确的行！");
            }
        }

        private void dgvChengYao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToDgv(e);
        }
        /// <summary>
        /// 添加方剂信息方法
        /// </summary>
        private void AddChengYao()
        {
            string MC = txtMC.Text.Trim();
            string CF = txtCF.Text.Trim();
            string ZB = txtZB.Text.Trim();
            string YFFX = txtYFFX.Text.Trim();
            string JX = txtJX.Text.Trim();
            string GX = txtGX.Text.Trim();
            string YF = txtYF.Text.Trim();
            string JJ = txtJJ.Text.Trim();
            string YY = txtYY.Text.Trim();
            string ZC = txtZC.Text.Trim();
            string FG = txtFG.Text.Trim();
            string GL = txtGL.Text.Trim();
            string FL = txtFL.Text.Trim();
            //判空处理
            if (string.IsNullOrEmpty(MC))
            {
                MessageBox.Show("名称不能为空!", "添加名称提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(GL))
            {
                MessageBox.Show("归类不能为空!", "添加归类提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(FL))
            {
                MessageBox.Show("功能分类不能为空!", "添加功能分类提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //判断方剂名称是否存在
            string sqlSelect = "select count(1) from `成药信息`  where 名称=@名称";
            MySqlParameter[] parasSelect =
            {
                new MySqlParameter("@名称",MC),
            };
            object o = SqlHelper.ExecuteScalar(sqlSelect, parasSelect);
            if (o != null && o != DBNull.Value && int.Parse(o.ToString()) > 0)
            {
                MessageBox.Show("该成药信息已经存在!", "添加成药信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //添加方剂信息
            string sql = $"insert into `成药信息`(名称, 处方, 制备方法,药方分析, 剂型规格, 功效主治, 用法用量,使用禁忌 , 临床应用, 贮藏, 方歌, 归类, 功能分类) " +
                $"values(@名称,@处方, @制备方法, @药方分析, @剂型规格, @功效主治, @用法用量, @使用禁忌, @临床应用,@贮藏, @方歌, @归类,@功能分类)";
            MySqlParameter[] paras ={
                new MySqlParameter("名称",MC),
                new MySqlParameter("处方",CF),
                new MySqlParameter("制备方法",ZB),
                new MySqlParameter("药方分析",YFFX),
                new MySqlParameter("剂型规格",JX),
                new MySqlParameter("功效主治",GX),
                new MySqlParameter("用法用量",YF),
                new MySqlParameter("使用禁忌",JJ),
                new MySqlParameter("临床应用",YY),
                new MySqlParameter("贮藏",ZC),
                new MySqlParameter("方歌",FG),
                new MySqlParameter("归类",GL),
                new MySqlParameter("功能分类",FL),
            };
            int count = SqlHelper.ExecuteNonQuery(sql, paras);
            if (count > 0)
            {
                MessageBox.Show($"该成药：{MC}信息录入成功！", "录入信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("成药信息录入失败，请检查！", "录入信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddChengYao();
            BindDgv();
        }
        private void UpdateChengYao()
        {
            //判空处理
            if (string.IsNullOrEmpty(txtMC.Text))
            {
                MessageBox.Show("成药名称不能为空!", "修改名称提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtGL.Text))
            {
                MessageBox.Show("归类不能为空!", "修改归类提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtFL.Text))
            {
                MessageBox.Show("功能分类不能为空!", "修改功能分类提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql = $"update `成药信息` set 名称='{txtMC.Text}',方歌='{txtFG.Text}',处方='{txtCF.Text}',制备方法='{txtZB.Text}'," +
                            $" 用法用量='{txtYF.Text}',功效主治='{txtGX.Text}',药方分析='{txtYFFX.Text}',剂型规格='{txtJX.Text}',归类='{txtGL.Text}' ,使用禁忌='{txtJJ.Text}'," +
                            $" 贮藏='{txtZC.Text}',临床应用='{txtYY.Text}',功能分类='{txtFL.Text}' where 名称='{txtMC.Text}'";
            if (SqlHelper.ExecuteNonQuery(sql) > 0)
            {
                MessageBox.Show($"该成药:{txtMC.Text}信息修改成功");
            }
            else
            {
                MessageBox.Show("该成药信息修改失败");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateChengYao();
            BindDgv();
        }

        private void dgvChengYao_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex > -1)
                    tsmDel.Visible = true;
            }
        }

        private void tsmDel_Click(object sender, EventArgs e)
        {
            string MC = txtMC.Text.Trim();
            if (MessageBox.Show("您确定要删除该成药信息吗？", "删除成药提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete  from `成药信息` where 名称=@名称";
                MySqlParameter para = new MySqlParameter("@名称", MC);
                int count = SqlHelper.ExecuteNonQuery(sql, para);
                if (count > 0)
                {
                    MessageBox.Show($"该成药{txtMC.Text}信息删除成功");
                }
                else
                {
                    MessageBox.Show($"该成药{txtMC.Text}信息删除失败");
                }
            }
            BindDgv();
        }


        /// <summary>
        /// 多行删除方法
        /// </summary>
        private void MutiDel()
        {
            //选择
            //获取要删除的数据stuId
            //判断选择的编号个数，=0 没有选择 提示用户选择要删除 的数据>0 继续
            //删除操作  事务  sql事务 代码里启动事务、
            List<int> listIds = new List<int>();
            for (int i = 0; i < dgvChengYao.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = dgvChengYao.Rows[i].Cells["colCheck"] as DataGridViewCheckBoxCell;
                bool chk = Convert.ToBoolean(cell.Value);
                if (chk)
                {
                    DataRow dr = (dgvChengYao.Rows[i].DataBoundItem as DataRowView).Row;
                    int id = (int)dr["编号".ToString()];
                    listIds.Add(id);
                }
            }

            //真删除
            if (listIds.Count == 0)
            {
                MessageBox.Show("请选择要删除的成药信息！", "删除成药提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("您确定要删除该批成药信息吗？", "删除成药提示",
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
                                cmd.CommandText = "delete from `成药信息` where 编号=@编号";
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
                            MessageBox.Show("删除成药信息出现异常！", "删除成药提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (count == listIds.Count)
                    {
                        MessageBox.Show("这批成药信息删除成功！", "删除成药提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //手动刷新
                        DataTable dt = (DataTable)dgvChengYao.DataSource;
                        //dgvStudents.DataSource = null;
                        string idStr = string.Join(",", listIds);
                        DataRow[] rows = dt.Select("编号 in(" + idStr + ")");
                        foreach (DataRow dr in rows)
                        {
                            dt.Rows.Remove(dr);
                        }
                        dgvChengYao.DataSource = dt;
                    }
                }
            }
        }

        /// <summary>
        /// 执行多行删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMutiDel_Click(object sender, EventArgs e)
        {
            MutiDel();
            BindDgv();
        }
    }
}
