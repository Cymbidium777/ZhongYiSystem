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
    public partial class FormMaiXue : Form
    {
        DataTable dt = new DataTable();
        public FormMaiXue()
        {
            InitializeComponent();
        }

        private void LviZJ()    //列表中显示章节标题
        {
            string sql = "SELECT * FROM `脉学信息`";
            dt = SqlHelper.GetDataTable(sql);
            int length = dt.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dt.Rows[i]["编号"].ToString();
                item.SubItems.Add(dt.Rows[i]["名称"].ToString());
                lviList.Items.Add(item);
            }
        }

        private void Display(string title)
        {
            string sql = "SELECT * FROM `脉学信息` WHERE `编号`=" + title.ToString() + "";
            DataTable dt = SqlHelper.GetDataTable(sql);
            rtbMS.Text = dt.Rows[0]["描述"].ToString();
            rtbTZS.Text = dt.Rows[0]["体状诗"].ToString();
            rtbXLS.Text= dt.Rows[0]["相类诗"].ToString();
            rtbZBS.Text = dt.Rows[0]["主病诗"].ToString();
            rtbFBS.Text = dt.Rows[0]["分部诗"].ToString();
            rtbZJ.Text = dt.Rows[0]["注解"].ToString();
            rtbBZ.Text = dt.Rows[0]["备注"].ToString();
            rtbAll.Text = dt.Rows[0]["描述"].ToString()
                + "\n\n" + dt.Rows[0]["体状诗"].ToString()
                + "\n\n" + dt.Rows[0]["相类诗"].ToString()
                + "\n\n" + dt.Rows[0]["主病诗"].ToString()
                + "\n\n" + dt.Rows[0]["分部诗"].ToString()
                + "\n\n" + dt.Rows[0]["注解"].ToString()
                + "\n\n" + dt.Rows[0]["备注"].ToString();
        }

        private void FormMaiXue_Load(object sender, EventArgs e)
        {
            LviZJ();
        }

        private void lviList_Click(object sender, EventArgs e)  //列表单击事件
        {
            Display(dt.Rows[lviList.Items.IndexOf(lviList.FocusedItem)]["编号"].ToString());
        }
    }
}
