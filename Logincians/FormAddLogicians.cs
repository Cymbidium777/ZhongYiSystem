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
using 中医信息管理系统.Helpers;

namespace 中医信息管理系统.Logincians
{
    public partial class FormAddLogicians : Form
    {
        public FormAddLogicians()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取历代名家信息（FormSelectLogicians双击跳转）
        /// </summary>
        public void GetLogicians()
        {
            string sql = "select * from `历代名家信息` where 姓名=@姓名";
            MySqlParameter[] paras =
            {
                new MySqlParameter("@姓名",SelectLogicians.selectLogicians.LogiciansName),
            };
            DataTable dt = SqlHelper.GetDataTable(sql,paras);
            int length = dt.Rows.Count;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    rtbDynasty.Text = dt.Rows[0]["朝代"].ToString();
                    rtbWork.Text = dt.Rows[0]["著作"].ToString();
                    rtbAchievement.Text = dt.Rows[0]["成就"].ToString();
                    rtbEvaluate.Text = dt.Rows[0]["人物评价"].ToString();
                    rtbLife.Text = dt.Rows[0]["生平"].ToString();
                    rtbName.Text = dt.Rows[0]["姓名"].ToString();
                }
            }
        }

        /// <summary>
        /// 获取历代名家姓名,并添加至listView
        /// </summary>
        public void GetLogiciansName()
        {
            //初始化listView
            if (livAddLogicians.Items.Count > 0)
            {
                livAddLogicians.Items.Clear();
            }
            string sql = "select 姓名 from `历代名家信息` ";
            DataTable dt = SqlHelper.GetDataTable(sql);
            int length = dt.Rows.Count;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dt.Rows[i]["姓名"].ToString();
                    livAddLogicians.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 进入界面加载历代名家信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAddLogicians_Load(object sender, EventArgs e)
        {
            GetLogiciansName();
            GetLogicians();
        }

        /// <summary>
        /// 点击listView的项获取历代名家信息详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void livLogicians_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < livAddLogicians.Items.Count; i++)
            {

                bool selected = livAddLogicians.Items[i].Selected;
                if (selected)
                {
                    string sql = "select * from `历代名家信息` where 姓名=@姓名 ";
                    MySqlParameter[] paras =
                    {
                        new MySqlParameter("@姓名",livAddLogicians.Items[i].Text),
                    };

                    DataTable dt = SqlHelper.GetDataTable(sql, paras);
                    int length = dt.Rows.Count;
                    if (length > 0)
                    {
                        rtbDynasty.Text = dt.Rows[0]["朝代"].ToString();
                        rtbWork.Text = dt.Rows[0]["著作"].ToString();
                        rtbAchievement.Text = dt.Rows[0]["成就"].ToString();
                        rtbEvaluate.Text = dt.Rows[0]["人物评价"].ToString();
                        rtbLife.Text = dt.Rows[0]["生平"].ToString();
                        rtbName.Text = dt.Rows[0]["姓名"].ToString();
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
            if (string.IsNullOrEmpty(rtbDynasty.Text) || string.IsNullOrEmpty(rtbAchievement.Text) || string.IsNullOrEmpty(rtbEvaluate.Text) ||
                 string.IsNullOrEmpty(rtbLife.Text) || string.IsNullOrEmpty(rtbWork.Text) || string.IsNullOrEmpty(rtbName.Text))
            {
                MessageBox.Show("请完善数据", "添加偏方提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //判断姓名是否存在
            string sqlSelect = "select count(1) from `历代名家信息`  where 姓名=@姓名";
            MySqlParameter[] parasSelect =
            {
                new MySqlParameter("@姓名",rtbName.Text),
            };
            object o = SqlHelper.ExecuteScalar(sqlSelect, parasSelect);
            if (o == null || o == DBNull.Value || int.Parse(o.ToString()) == 0)// DBNull.Value 适用于向数据库的表中插入空值
            {
                //添加偏方
                string sqlUpdate = "insert into `历代名家信息`(姓名,朝代,著作,成就,生平,人物评价) " +
                    "VALUES(@姓名,@朝代,@著作,@成就,@生平,@人物评价)";
                MySqlParameter[] parasUpdate =
            {
                    new MySqlParameter("@姓名",rtbName.Text),
                    new MySqlParameter("@朝代",rtbDynasty.Text),
                    new MySqlParameter("@著作",rtbWork.Text),
                    new MySqlParameter("@成就",rtbAchievement.Text),
                    new MySqlParameter("@生平",rtbLife.Text),
                    new MySqlParameter("@人物评价",rtbEvaluate.Text),
                };
                //处理结果
                int count = SqlHelper.ExecuteNonQuery(sqlUpdate, parasUpdate);
                if (count > 0)
                {
                    MessageBox.Show("添加成功！", "添加历代名家提示",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetLogiciansName();
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
            if (string.IsNullOrEmpty(rtbDynasty.Text) || string.IsNullOrEmpty(rtbAchievement.Text) || string.IsNullOrEmpty(rtbEvaluate.Text) ||
                string.IsNullOrEmpty(rtbLife.Text) || string.IsNullOrEmpty(rtbWork.Text)|| string.IsNullOrEmpty(rtbName.Text))
            {
                MessageBox.Show("请完善数据", "更新偏方提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //添加偏方
            string sqlUpdate = "update `历代名家信息` set 朝代=@朝代,著作=@著作,成就=@成就,生平=@生平,人物评价=@人物评价 where 姓名=@姓名";
            MySqlParameter[] parasUpdate =
            {
                new MySqlParameter("@姓名",rtbName.Text),
                new MySqlParameter("@朝代",rtbDynasty.Text),
                new MySqlParameter("@著作",rtbWork.Text),
                new MySqlParameter("@成就",rtbAchievement.Text),
                new MySqlParameter("@生平",rtbLife.Text),
                new MySqlParameter("@人物评价",rtbEvaluate.Text),
            };
            //处理结果
            int count = SqlHelper.ExecuteNonQuery(sqlUpdate, parasUpdate);
            if (count > 0)
            {
                MessageBox.Show("更新成功！", "更新历代名家提示",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetLogicians();//重置历代名家信息
                return;

            }
            else
            {
                MessageBox.Show("更新失败,已存在该名家信息", "更新历代名家提示",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// 删除历代名家信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            //判断空值
            if (string.IsNullOrEmpty(rtbDynasty.Text) || string.IsNullOrEmpty(rtbAchievement.Text) || string.IsNullOrEmpty(rtbEvaluate.Text) ||
                 string.IsNullOrEmpty(rtbLife.Text) || string.IsNullOrEmpty(rtbWork.Text) || string.IsNullOrEmpty(rtbName.Text))
            {
                MessageBox.Show("请完善数据", "删除偏方提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //添加偏方
            string sqlDel = "delete from `历代名家信息` set 姓名=@姓名" ;
            MySqlParameter[] parasDel =
            {
                    new MySqlParameter("@姓名",rtbName.Text),
            };
            //处理结果
            int count = SqlHelper.ExecuteNonQuery(sqlDel, parasDel);
            if (count > 0)
            {
                MessageBox.Show("删除成功！", "删除历代名家提示",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetLogiciansName();
                return;

            }
            else
            {
                MessageBox.Show("删除失败", "删除历代名家提示",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
