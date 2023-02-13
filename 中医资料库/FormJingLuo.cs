using GMS;
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

namespace 中医信息管理系统.中医古籍
{
    public partial class FormJingLuo : Form
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        public FormJingLuo()
        {
            InitializeComponent();
        }

        private void LviJM()    //列表中显示章节标题
        {
            string sql = "SELECT * FROM `经脉信息`";
            dt = SqlHelper.GetDataTable(sql);
            int length = dt.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dt.Rows[i]["经脉编号"].ToString();
                item.SubItems.Add(dt.Rows[i]["经脉名称"].ToString());
                item.SubItems.Add(dt.Rows[i]["经脉简介"].ToString());
                lviJM.Items.Add(item);
            }
        }

        private void LviTF(string str)    //列表中显示汤方标题
        {
            string sql = "SELECT * FROM `穴位信息` WHERE `经脉编号`=" + str + "";
            dt2 = SqlHelper.GetDataTable(sql);
            int length = dt2.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dt2.Rows[i]["穴位编号"].ToString();
                item.SubItems.Add(dt2.Rows[i]["穴位名称"].ToString());
                item.SubItems.Add(dt2.Rows[i]["穴位简介"].ToString());
                lviXW.Items.Add(item);
            }
        }

        private void FormJingLuo_Load(object sender, EventArgs e)
        {
            LviJM();
        }

        private void lviJM_Click(object sender, EventArgs e)    //经脉列表单击事件
        {
            lviXW.Items.Clear();
            JingMai.Current.JingMaiName = dt.Rows[lviJM.Items.IndexOf(lviJM.FocusedItem)]["经脉名称"].ToString();
            string num = dt.Rows[lviJM.Items.IndexOf(lviJM.FocusedItem)]["经脉编号"].ToString();
            LviTF(num);
        }

        private void lviJM_DoubleClick(object sender, EventArgs e)  //经脉列表双击事件
        {
            string num= dt.Rows[lviJM.Items.IndexOf(lviJM.FocusedItem)]["经脉编号"].ToString();
            JingMai.Current.JingMaiName = dt.Rows[lviJM.Items.IndexOf(lviJM.FocusedItem)]["经脉名称"].ToString();
            FormMP4Player play = new FormMP4Player(num);
            play.Show();
        }

        private void lviXW_Click(object sender, EventArgs e)    //穴位列表单击事件
        {
            rtbNR.Text = "";
            labTitle2.Text = JingMai.Current.JingMaiName + "——" + dt2.Rows[lviXW.Items.IndexOf(lviXW.FocusedItem)]["穴位名称"].ToString();
            rtbNR.Text = JingMai.Current.JingMaiName + "\n"
                + dt.Rows[lviJM.Items.IndexOf(lviJM.FocusedItem)]["经脉简介"].ToString() + "\n\n"
                + dt2.Rows[lviXW.Items.IndexOf(lviXW.FocusedItem)]["穴位名称"].ToString() + "\n"
                + dt2.Rows[lviXW.Items.IndexOf(lviXW.FocusedItem)]["穴位简介"].ToString();
        }
    }
}