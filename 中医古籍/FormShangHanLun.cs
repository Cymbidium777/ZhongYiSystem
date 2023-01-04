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
    public partial class FormShangHanLun : Form
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        public FormShangHanLun()
        {
            InitializeComponent();
        }

        private void LviZJ()    //列表中显示章节标题
        {
            lviList2.Visible = false;
            string sql = "SELECT * FROM `伤寒杂病论章节表`";
            dt = SqlHelper.GetDataTable(sql);
            int length = dt.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dt.Rows[i]["章节编号"].ToString();
                item.SubItems.Add(dt.Rows[i]["章节标题"].ToString());
                item.SubItems.Add(dt.Rows[i]["章节简介"].ToString());
                lviList.Items.Add(item);
            }
        }

        private void LviTF(string str)    //列表中显示汤方标题
        {
            lviList2.Visible = true;
            string sql = "SELECT * FROM `伤寒杂病论汤方` WHERE `章节编号`=" + str + "";
            dt2 = SqlHelper.GetDataTable(sql);
            int length = dt2.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dt2.Rows[i]["章节编号"].ToString();
                item.SubItems.Add(dt2.Rows[i]["汤方标题"].ToString());
                item.SubItems.Add(dt2.Rows[i]["汤方内容"].ToString());
                item.SubItems.Add(dt2.Rows[i]["汤方对症"].ToString());
                lviList2.Items.Add(item);
            }
        }

        private void LviSC(string str)    //列表中显示匹配结果
        {
            lviList4.Visible = true;
            lviList3.Visible = false;
            labTitle2.Text = str;
            string sql = $"SELECT `章节标题`,`汤方内容`,`汤方对症`,`章节简介` FROM `伤寒杂病论汤方` a JOIN `伤寒杂病论章节表` b ON (a.`章节编号`=b.`章节编号`) WHERE `汤方标题` = \"" + str + "\"";
            dt4 = SqlHelper.GetDataTable(sql);
            int length = dt4.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dt4.Rows[i]["汤方内容"].ToString();
                item.SubItems.Add(dt4.Rows[i]["章节标题"].ToString());
                item.SubItems.Add(dt4.Rows[i]["汤方对症"].ToString());
                item.SubItems.Add(dt4.Rows[i]["章节简介"].ToString());
                lviList4.Items.Add(item);
            }
        }

        private void FormShangHanLun_Load(object sender, EventArgs e)
        {
            LviZJ();
        }

        private void btnReturn_Click(object sender, EventArgs e)    //返回主页
        {
            lviList2.Visible = false;
            lviList3.Visible = false;
            lviList4.Visible = false;
            rtbNR.Text = "";
            rtbDZ.Text = "";
            labTitle2.Text = "";
            txtSearch.Text = "";
            lviList2.Items.Clear();
            lviList3.Items.Clear();
            lviList4.Items.Clear();
            labTitle1.Text = "伤 寒 杂 病 论";
            rtbJJ.Text = "《伤寒杂病论》是中国传统医学著作之一，是一部论述外感病与内科杂病为主要内容的医学典籍，作者是东汉末年张仲景。公元3世纪初，张仲景博览群书，广采众方，凝聚毕生心血，写就《伤寒杂病论》一书。中医所说的伤寒实际上是一切外感病的总称，它包括瘟疫这种传染病。该书成书约在公元200年～210年左右。原书失散后，经王叔和等人收集整理校勘，分编为《伤寒论》和《金匮要略》两部。《伤寒论》共10卷，专门论述伤寒类急性传染病。";
        }

        private void btnSearch_Click(object sender, EventArgs e)    //搜索按钮
        {
            string txt = txtSearch.Text;
            lviList3.Items.Clear();
            lviList4.Items.Clear();
            labTitle2.Text = "";
            rtbNR.Text = "";
            rtbDZ.Text = "";
            labTitle1.Text = "伤 寒 杂 病 论";
            rtbJJ.Text = "《伤寒杂病论》是中国传统医学著作之一，是一部论述外感病与内科杂病为主要内容的医学典籍，作者是东汉末年张仲景。公元3世纪初，张仲景博览群书，广采众方，凝聚毕生心血，写就《伤寒杂病论》一书。中医所说的伤寒实际上是一切外感病的总称，它包括瘟疫这种传染病。该书成书约在公元200年～210年左右。原书失散后，经王叔和等人收集整理校勘，分编为《伤寒论》和《金匮要略》两部。《伤寒论》共10卷，专门论述伤寒类急性传染病。";
            //判断空值
            if (string.IsNullOrEmpty(txt))
            {
                MessageBox.Show("请输入要查询的汤方名称");
                lviList2.Visible = false;
                lviList3.Visible = false;
                lviList4.Visible = false;
                return;
            }
            else
            {
                lviList2.Visible = false;
                lviList3.Visible = true;
                lviList3.Items.Clear();
                string sql = $"SELECT DISTINCT `汤方标题` FROM `伤寒杂病论汤方` a JOIN `伤寒杂病论章节表` b ON (a.`章节编号`=b.`章节编号`) WHERE `汤方标题` LIKE '%{txt}%'";
                MySqlParameter[] paras =
                {
                    new MySqlParameter("@name","%"+txt+"%"),
                };
                dt3 = SqlHelper.GetDataTable(sql, paras);
                int length = dt3.Rows.Count;
                for (int i = 0; i < length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = i.ToString();
                    item.SubItems.Add(dt3.Rows[i]["汤方标题"].ToString());
                    lviList3.Items.Add(item);
                }
            }
        }

        private void lviList_Click(object sender, EventArgs e)      //单击章节标题
        {
            rtbJJ.Text = dt.Rows[lviList.Items.IndexOf(lviList.FocusedItem)]["章节简介"].ToString();
            labTitle1.Text = dt.Rows[lviList.Items.IndexOf(lviList.FocusedItem)]["章节标题"].ToString();
        }

        private void lviList_DoubleClick(object sender, EventArgs e)    //双击章节标题
        {
            string num = dt.Rows[lviList.Items.IndexOf(lviList.FocusedItem)]["章节编号"].ToString();
            LviTF(num);
        }

        private void lviList2_Click(object sender, EventArgs e)     //单击汤方标题
        {
            labTitle2.Text = dt2.Rows[lviList2.Items.IndexOf(lviList2.FocusedItem)]["汤方标题"].ToString();
            rtbNR.Text = dt2.Rows[lviList2.Items.IndexOf(lviList2.FocusedItem)]["汤方内容"].ToString();
            rtbDZ.Text = dt2.Rows[lviList2.Items.IndexOf(lviList2.FocusedItem)]["汤方对症"].ToString();
        }

        private void lviList3_DoubleClick(object sender, EventArgs e)   //双击搜索结果
        {
            string txt = dt3.Rows[lviList3.Items.IndexOf(lviList3.FocusedItem)]["汤方标题"].ToString();
            LviSC(txt);
        }

        private void lviList4_Click(object sender, EventArgs e)     //单击匹配结果
        {
            rtbJJ.Text = dt4.Rows[lviList4.Items.IndexOf(lviList4.FocusedItem)]["章节简介"].ToString();
            labTitle1.Text = dt4.Rows[lviList4.Items.IndexOf(lviList4.FocusedItem)]["章节标题"].ToString();
            rtbNR.Text = dt4.Rows[lviList4.Items.IndexOf(lviList4.FocusedItem)]["汤方内容"].ToString();
            rtbDZ.Text = dt4.Rows[lviList4.Items.IndexOf(lviList4.FocusedItem)]["汤方对症"].ToString();
        }
    }
}
