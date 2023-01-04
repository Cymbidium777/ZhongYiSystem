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
using 中医信息管理系统.Helpers;

namespace 中医信息管理系统
{
    public partial class FormPeculiarPrescription : Form
    {
        public FormPeculiarPrescription()
        {
            InitializeComponent();
        }

        private static FormPeculiarPrescription pp = null;//初始化窗体
        /// <summary>
        ///  //单例 只能出现一个窗体
        /// </summary>
        /// <returns></returns>
        public static FormPeculiarPrescription CreateInstance()
        {
            if (pp == null || pp.IsDisposed) //窗体为空或被释放
                pp = new FormPeculiarPrescription();
            return pp;
        }

        /// <summary>
        /// 获取民间偏方全部信息
        /// </summary>
        public void GetFolkPrescription()
        {
            //名称,创始人,方剂组成,炮制,用法用量,功效主治,方义分析,加减方,归类,注意事项,备注
            string sql = "select * from `民间偏方信息`";
            //加载数据
            DataTable dt = SqlHelper.GetDataTable(sql);
            //绑定数据
            dgvFolkPrescription.DataSource = dt;
        }

        /// <summary>
        /// 获取民间偏方归类信息
        /// </summary>
        public void GetClassification()
        {
            string sql = "select distinct(归类) from `民间偏方信息`";
            //加载数据
            DataTable dt = SqlHelper.GetDataTable(sql);
            //添加一行"请选择"项
            DataRow dataRow = dt.NewRow();

            dataRow["归类"] = "请选择";
            dt.Rows.InsertAt(dataRow, 0);//插入到第一个
            //绑定数据
            cboClassification.DataSource = dt;
            cboClassification.DisplayMember = "归类";
            cboClassification.SelectedIndex = 0;
        }

        /// <summary>
        /// 获取拼音
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                if ((int)c >= 33 && (int)c <= 126)
                {//字母和符号原样保留   
                    tempStr += c.ToString();
                }
                else
                {//累加拼音声母   
                    tempStr += GetPYChar(c.ToString());
                }
            }
            return tempStr;
        }

        /// <summary>
        /// 取单个字符的拼音声母
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public string GetPYChar(string c)
        {
            byte[] array = new byte[2];
            array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "j";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";
            return "*";
        }

        /// <summary>
        /// 模糊查询名称获取民间偏方，并将其添加至listView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            //初始化listView
            if (livPeculiarPrescription.Items.Count > 0)
            {
                livPeculiarPrescription.Items.Clear();
            }
            //根据首字母查询到的功效主治添加到listView中
            string name = txtNameSpell.Text;//民间偏方名称
            string name_spell = GetPYString(name);//民间偏方名称拼音
            //判断空值
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入民间偏方名称\n①支持拼音首字母查询\n②支持中文模糊查询", "添加民间偏方提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql = "select * from `民间偏方信息`" +
                " where 名称拼音 like @名称拼音 or 名称 like @名称 ";
            MySqlParameter[] paras =
            {
                new MySqlParameter("@名称拼音",name_spell+"%"),
                new MySqlParameter("@名称","%"+name+"%"),
            };
            DataTable dt = SqlHelper.GetDataTable(sql, paras);
            int length = dt.Rows.Count;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dt.Rows[i]["名称"].ToString();//ListView的第一个Item作为主项需要单独添加
                    item.SubItems.Add(dt.Rows[i]["创始人"].ToString());
                    item.SubItems.Add(dt.Rows[i]["备注"].ToString());
                    livPeculiarPrescription.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("缺少该偏方数据", "查询名称提示",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// 单击listView的项查看相应的民间偏方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void livPeculiarPrescription_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < livPeculiarPrescription.Items.Count; i++)
            {

                bool selected = livPeculiarPrescription.Items[i].Selected;
                if (selected)
                {
                    string sql = "select * from `民间偏方信息` where 名称=@名称 ";
                    MySqlParameter[] paras =
                    {
                        new MySqlParameter("@名称",livPeculiarPrescription.Items[i].Text),
                    };
                    DataTable dt = SqlHelper.GetDataTable(sql, paras);
                    int length = dt.Rows.Count;
                    if (length > 0)
                    {
                        rtbComposition.Text = dt.Rows[0]["方剂组成"].ToString();
                        rtbConcoction.Text = dt.Rows[0]["炮制"].ToString();
                        rtbUsage_Dosage.Text = dt.Rows[0]["用法用量"].ToString();
                        rtbEfficacy.Text = dt.Rows[0]["功效主治"].ToString();
                        rtbAnalysis.Text = dt.Rows[0]["方义分析"].ToString();
                        rtbAdd_Sub.Text = dt.Rows[0]["加减方"].ToString();
                        rtbAttention.Text = dt.Rows[0]["注意事项"].ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 进入界面加载民间偏方信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPeculiarPrescription_Load(object sender, EventArgs e)
        {
            GetFolkPrescription();
            GetClassification();
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dgvFolkPrescription.Rows.Count; i++)
            {
                this.dgvFolkPrescription.Rows[i].Cells[0].Value = true;
            }
        }

        /// <summary>
        /// 取消全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNotAllSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dgvFolkPrescription.Rows.Count; i++)
            {
                this.dgvFolkPrescription.Rows[i].Cells[0].Value = false;
            }
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPushExcel_Click(object sender, EventArgs e)
        {
            //打开文件对话框
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "保存文件";
            saveFileDialog1.Filter = "Excel 文件(*.xls)|*.xls|Excel 文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";
            saveFileDialog1.FileName = "民间偏方信息.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string txtPath = saveFileDialog1.FileName;
                List<int> listIds = new List<int>();//定义一个集合来接收所选择的行的主键
                for (int i = 0; i < dgvFolkPrescription.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell cell = dgvFolkPrescription.Rows[i].Cells["colCheck"] as DataGridViewCheckBoxCell;
                    bool check = Convert.ToBoolean(cell.Value);
                    if (check)
                    {
                        //获取行数据
                        DataRow dr = (dgvFolkPrescription.Rows[i].DataBoundItem as DataRowView).Row;
                        //获取数据的Id
                        int idPushExcel = int.Parse(dr["编号"].ToString());
                        listIds.Add(idPushExcel);
                    }
                }
                DataTable dt = (DataTable)dgvFolkPrescription.DataSource;
                string idStr = string.Join(",", listIds);//将字符数组拼接成字符串
                DataRow[] rows = dt.Select("编号 in (" + idStr + ")"); // 获取所有行数,是把数据传到数据库用Sql语句进行查询判定
                DataTable dtexecl = rows.CopyToDataTable();
                NPOIHelper.DataTableToExcel(dtexecl, txtPath);
            }
        }

        /// <summary>
        /// 导入Excel到datagridView(未直接导入至数据库)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPullExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Multiselect = false;
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                dgvFolkPrescription.DataSource = NPOIHelper.ExcelToDataTable(openfile.FileName, true);
                MessageBox.Show("数据导入完成");
            }
        }

        /// <summary>
        /// 批量删除民间偏方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMulDel_Click(object sender, EventArgs e)
        {
            //选择删除对象
            List<int> listIds = new List<int>();
            for (int i = 0; i < dgvFolkPrescription.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = dgvFolkPrescription.Rows[i].Cells["colCheck"] as DataGridViewCheckBoxCell;
                bool check = Convert.ToBoolean(cell.Value);//定义一个bool变量来判断是否被选择
                if (check)
                {
                    DataRow dr = (dgvFolkPrescription.Rows[i].DataBoundItem as DataRowView).Row; //获取行数据
                    //获取删除数据的StuId
                    int idSelect = int.Parse(dr["编号"].ToString());//获取删除数据的编号
                    listIds.Add(idSelect);
                }
            }
            //判断是否选择删除对象
            if (listIds.Count == 0)
            {
                MessageBox.Show("请选择要删除的民间偏方信息！", "删除民间偏方提示",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("确定删除该民间偏方的信息吗？", "删除民间偏方提示",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int count = 0;
                    //批量删除操作,启动事务
                    using (MySqlConnection conn = new MySqlConnection(SqlHelper.connString))
                    {
                        //事务通过conn开启，且要在连接状态下
                        conn.Open();
                        MySqlTransaction transaction = conn.BeginTransaction();
                        //事务的执行也需要创建Command对象
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.Transaction = transaction;
                        //事务执行内容
                        try
                        {
                            foreach (int idDel in listIds)
                            {
                                cmd.CommandText = "delete from `民间偏方信息` where 编号=@编号";
                                MySqlParameter paraDel = new MySqlParameter("@编号", idDel);
                                cmd.Parameters.Clear();
                                cmd.Parameters.Add(paraDel);
                                count += cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (MySqlException ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("删除民间偏方失败!", "删除民间偏方提示",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (count == listIds.Count)
                    {
                        MessageBox.Show("批量删除民间偏方信息成功！", "删除民间偏方提示",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //刷新数据
                        DataTable dt = (DataTable)dgvFolkPrescription.DataSource;
                        string IdStr = string.Join(",", listIds);//将字符数组拼接成字符串
                        DataRow[] rows = dt.Select("编号 in (" + IdStr + ")"); // 获取所有行的数组
                        foreach (DataRow dr in rows)
                        {
                            dt.Rows.Remove(dr);
                        }
                        dgvFolkPrescription.DataSource = dt;
                    }
                }
            }
        }

        /// <summary>
        /// 批量导入民间偏方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMulAdd_Click(object sender, EventArgs e)
        {
            //选择添加对象
            List<FolkPrescription> folkPrescriptions = new List<FolkPrescription>();
            for (int i = 0; i < dgvFolkPrescription.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = dgvFolkPrescription.Rows[i].Cells["colCheck"] as DataGridViewCheckBoxCell;
                bool check = Convert.ToBoolean(cell.Value);//定义一个bool变量来判断是否被选择
                int number = 0;//被选中的行数
                if (check)
                {
                    number += 1;
                    FolkPrescription[] fp = new FolkPrescription[number];
                    //获取行数据
                    DataRow dr = (dgvFolkPrescription.Rows[i].DataBoundItem as DataRowView).Row;
                    for (int j = 0; j < fp.Length; j++)
                    {
                        fp[j] = new FolkPrescription();//每个对象被单独创建*******************关键
                        fp[j].名称 = dr["名称"].ToString();
                        fp[j].创始人 = dr["创始人"].ToString();
                        fp[j].方剂组成 = dr["方剂组成"].ToString();
                        fp[j].炮制 = dr["炮制"].ToString();
                        fp[j].用法用量 = dr["用法用量"].ToString();
                        fp[j].功效主治 = dr["功效主治"].ToString();
                        fp[j].方义分析 = dr["方义分析"].ToString();
                        fp[j].加减方 = dr["加减方"].ToString();
                        fp[j].归类 = dr["归类"].ToString();
                        fp[j].注意事项 = dr["注意事项"].ToString();
                        fp[j].备注 = dr["备注"].ToString();
                        fp[j].名称拼音 = dr["名称拼音"].ToString();
                        folkPrescriptions.Add(fp[j]);
                    }
                }
            }
            //判断是否选择添加对象
            if (folkPrescriptions.Count == 0)
            {
                MessageBox.Show("请选择要添加民间偏方信息！", "添加民间偏方信息提示",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("确定添加该民间偏方的信息吗？", "添加民间偏方信息提示",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int count = 0;
                    //批量添加操作,启动事务
                    using (MySqlConnection conn = new MySqlConnection(SqlHelper.connString))
                    {
                        //事务通过conn开启，且要在连接状态下
                        conn.Open();
                        MySqlTransaction transaction = conn.BeginTransaction();
                        //事务的执行也需要创建Command对象
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.Transaction = transaction;
                        //事务执行内容
                        try
                        {
                            for (int i = 0; i < folkPrescriptions.Count; i++)
                            {
                                //添加偏方
                                string sqlAdd = "insert into `民间偏方信息`(名称,创始人,方剂组成,炮制,用法用量,功效主治,方义分析,加减方,归类,注意事项,备注) " +
                                    "VALUES(@名称,@创始人,@方剂组成,@炮制,@用法用量,@功效主治,@方义分析,@加减方,@归类,@注意事项,@备注,@名称拼音)";
                                MySqlParameter[] parasAdd =
                                {
                                    new MySqlParameter("@名称",folkPrescriptions[i].名称),
                                    new MySqlParameter("@创始人",folkPrescriptions[i].创始人),
                                    new MySqlParameter("@方剂组成",folkPrescriptions[i].方剂组成),
                                    new MySqlParameter("@炮制",folkPrescriptions[i].炮制),
                                    new MySqlParameter("@用法用量",folkPrescriptions[i].用法用量),
                                    new MySqlParameter("@功效主治",folkPrescriptions[i].功效主治),
                                    new MySqlParameter("@方义分析",folkPrescriptions[i].方义分析),
                                    new MySqlParameter("@加减方",folkPrescriptions[i].加减方),
                                    new MySqlParameter("@归类",folkPrescriptions[i].归类),
                                    new MySqlParameter("@注意事项",folkPrescriptions[i].注意事项),
                                    new MySqlParameter("@备注",folkPrescriptions[i].备注),
                                    new MySqlParameter("@名称拼音",folkPrescriptions[i].名称拼音),
                                };
                                count += SqlHelper.ExecuteNonQuery(sqlAdd, parasAdd);
                            }
                            //事务执行
                            transaction.Commit();
                        }
                        catch (MySqlException ex)
                        {
                            //事务回滚
                            transaction.Rollback();
                            MessageBox.Show("批量添加民间偏方信息失败!", "添加民间偏方信息提示",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (count == folkPrescriptions.Count)
                    {
                        MessageBox.Show("批量添加民间偏方信息成功！", "添加民间偏方信息提示",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// 添加民间偏方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //判断空值
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtFounder.Text) || string.IsNullOrEmpty(txtComposition.Text) ||
                string.IsNullOrEmpty(txtConcoction.Text) || string.IsNullOrEmpty(txtUsage_Dosage.Text) || string.IsNullOrEmpty(txtEfficacy.Text) ||
                string.IsNullOrEmpty(txtAnalysis.Text) || string.IsNullOrEmpty(txtAdd_Sub.Text) || string.IsNullOrEmpty(txtClassification.Text) ||
                string.IsNullOrEmpty(txtAttention.Text) || string.IsNullOrEmpty(txtRemark.Text))
            {
                MessageBox.Show("请完善数据", "添加偏方提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //判断名称是否存在
            string sqlSelect = "select count(1) from `民间偏方信息`  where 名称=@名称";
            MySqlParameter[] parasSelect =
            {
                new MySqlParameter("@名称",txtName.Text),
            };
            object o = SqlHelper.ExecuteScalar(sqlSelect, parasSelect);
            if (o == null || o == DBNull.Value || int.Parse(o.ToString()) == 0)// DBNull.Value 适用于向数据库的表中插入空值
            {
                //添加偏方
                string sqlAdd = "insert into `民间偏方信息`(名称,创始人,方剂组成,炮制,用法用量,功效主治,方义分析,加减方,归类,注意事项,备注,名称拼音) " +
                    "VALUES(@名称,@创始人,@方剂组成,@炮制,@用法用量,@功效主治,@方义分析,@加减方,@归类,@注意事项,@备注,@名称拼音)";
                MySqlParameter[] parasAdd =
            {
                    new MySqlParameter("@名称",txtName.Text),
                    new MySqlParameter("@创始人",txtFounder.Text),
                    new MySqlParameter("@方剂组成",txtComposition.Text),
                    new MySqlParameter("@炮制",txtConcoction.Text),
                    new MySqlParameter("@用法用量",txtUsage_Dosage.Text),
                    new MySqlParameter("@功效主治",txtEfficacy.Text),
                    new MySqlParameter("@方义分析",txtAnalysis.Text),
                    new MySqlParameter("@加减方",txtAdd_Sub.Text),
                    new MySqlParameter("@归类",txtClassification.Text),
                    new MySqlParameter("@注意事项",txtAttention.Text),
                    new MySqlParameter("@备注",txtRemark.Text),
                    new MySqlParameter("@名称拼音",GetPYString(txtName.Text)),
                };
                //处理结果
                int count = SqlHelper.ExecuteNonQuery(sqlAdd, parasAdd);
                if (count > 0)
                {
                    MessageBox.Show("添加成功！", "添加民间偏方提示",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetFolkPrescription();//重置民间偏方信息
                    return;

                }
                else
                {
                    MessageBox.Show("添加失败", "添加民间偏方提示",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("该偏方已存在！", "添加偏方提示",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// 更新民间偏方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            //判断空值
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtFounder.Text) || string.IsNullOrEmpty(txtComposition.Text) ||
            string.IsNullOrEmpty(txtConcoction.Text) || string.IsNullOrEmpty(txtUsage_Dosage.Text) || string.IsNullOrEmpty(txtEfficacy.Text) ||
            string.IsNullOrEmpty(txtAnalysis.Text) || string.IsNullOrEmpty(txtAdd_Sub.Text) || string.IsNullOrEmpty(txtClassification.Text) ||
            string.IsNullOrEmpty(txtAttention.Text) || string.IsNullOrEmpty(txtRemark.Text))
            {
                MessageBox.Show("请完善数据", "更新偏方提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //更新偏方
            string sqlUpdate = "update `民间偏方信息` " +
                "set 创始人=@创始人,方剂组成=@方剂组成,炮制=@炮制," +
                "用法用量=@用法用量,功效主治=@功效主治,方义分析=@方义分析," +
                "加减方=@加减方,归类=@归类,注意事项=@注意事项,备注=@备注,名称拼音=@名称拼音 " +
                "where 名称=@名称";
            MySqlParameter[] parasUpdate =
            {
                 new MySqlParameter("@名称",txtName.Text),
                 new MySqlParameter("@创始人",txtFounder.Text),
                 new MySqlParameter("@方剂组成",txtComposition.Text),
                 new MySqlParameter("@炮制",txtConcoction.Text),
                 new MySqlParameter("@用法用量",txtUsage_Dosage.Text),
                 new MySqlParameter("@功效主治",txtEfficacy.Text),
                 new MySqlParameter("@方义分析",txtAnalysis.Text),
                 new MySqlParameter("@加减方",txtAdd_Sub.Text),
                 new MySqlParameter("@归类",txtClassification.Text),
                 new MySqlParameter("@注意事项",txtAttention.Text),
                 new MySqlParameter("@备注",txtRemark.Text),
                 new MySqlParameter("@名称拼音",GetPYString(txtName.Text)),
                };
            //处理结果
            int count = SqlHelper.ExecuteNonQuery(sqlUpdate, parasUpdate);
            if (count > 0)
            {
                MessageBox.Show("更新成功！", "更新民间偏方提示",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetFolkPrescription();//重置民间偏方信息
                return;

            }
            else
            {
                MessageBox.Show("更新失败,已存在该偏方信息", "更新民间偏方提示",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// 选中DataGridView行，将数据返填到TextBox控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFolkPrescription_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvFolkPrescription.CurrentRow.Cells["名称"].Value.ToString();
            txtFounder.Text = dgvFolkPrescription.CurrentRow.Cells["创始人"].Value.ToString();
            txtComposition.Text = dgvFolkPrescription.CurrentRow.Cells["方剂组成"].Value.ToString();
            txtConcoction.Text = dgvFolkPrescription.CurrentRow.Cells["炮制"].Value.ToString();
            txtUsage_Dosage.Text = dgvFolkPrescription.CurrentRow.Cells["用法用量"].Value.ToString();
            txtEfficacy.Text = dgvFolkPrescription.CurrentRow.Cells["功效主治"].Value.ToString();
            txtAnalysis.Text = dgvFolkPrescription.CurrentRow.Cells["方义分析"].Value.ToString();
            txtAdd_Sub.Text = dgvFolkPrescription.CurrentRow.Cells["加减方"].Value.ToString();
            txtClassification.Text = dgvFolkPrescription.CurrentRow.Cells["归类"].Value.ToString();
            txtAttention.Text = dgvFolkPrescription.CurrentRow.Cells["注意事项"].Value.ToString();
            txtRemark.Text = dgvFolkPrescription.CurrentRow.Cells["备注"].Value.ToString();
        }

        /// <summary>
        /// 民间偏方归类修改触发,显示该类型的民间偏方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboClassification_SelectedIndexChanged(object sender, EventArgs e)
        {

            livPeculiarPrescription.Items.Clear();
            string sql = "select * from `民间偏方信息` where 归类 = @归类 ";
            MySqlParameter para = new MySqlParameter("@归类", cboClassification.Text);
            DataTable dt = SqlHelper.GetDataTable(sql, para);
            int length = dt.Rows.Count;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dt.Rows[i]["名称"].ToString(); ;//ListView的第一个Item作为主项需要单独添加
                    item.SubItems.Add(dt.Rows[i]["创始人"].ToString());
                    item.SubItems.Add(dt.Rows[i]["备注"].ToString());
                    livPeculiarPrescription.Items.Add(item);
                }
            }
        }
    }
}
