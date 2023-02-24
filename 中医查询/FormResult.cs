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
using 中医信息管理系统.Helpers;

namespace 中医信息管理系统
{
    public partial class FormResult : Form
    {
        string txt;
        string SearchName;
        public FormResult(string str, string name)
        {
            txt = str;
            SearchName = name;
            InitializeComponent();
        }

        private string SplitAsList(int i)  //拆分输入字符串建立数组
        {
            List<string> list = new List<string>(txt.Split('，'));
            string sp = list[i];
            return sp;
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>(txt.Split('，'));
            string sp = list[0];
            int s = list.Count;
            if (SearchName == "疾病") //贺
            {
                string sql1 = "select `特效方名称` AS 方药名称,`主治` AS 方药对症,`方药` AS 方药组成 from  (select `特效方名称`,`主治`,`方药` from `秘方特效方` where `主治` like '%" + sp + "%' ";
                string sql2 = "";
                if (s > 1)
                {
                    for (int i = 1; i < s; i++)
                    {
                        string t = SplitAsList(i);
                        sql2 = sql1 + " and `主治` like '%" + t + "%'";
                    }
                }
                string sql3 = sql2 + "union select `药方名称`,`主治`,`组成` from `偏方药方` where `主治` like '%" + sp + "%'";
                string sql4 = "";
                if (s > 1)
                {
                    for (int i = 1; i < s; i++)
                    {
                        string t = SplitAsList(i);
                        sql4 = sql3 + " and `主治` like '%" + t + "%'";
                    }
                }
                string sql = sql4 + ") t";
                DataTable dt = SqlHelper.GetDataTable(sql);
                string str = DtHelper.DtToStr(dt);
                richTextBox1.Text = str;
            }
            else if (SearchName == "中药")  //余
            {

            }
            else if (SearchName == "汤方")  //陈
            {

            }
            else if (SearchName == "偏方")  //肖
            {
                string sql = "select `特效方名称` AS 方药名称,`主治` AS 方药对症,`方药` AS 方药组成 from  (select `特效方名称`,`主治`,`方药` from `秘方特效方` where `主治` like '%" + txt + "%' union select `药方名称`,`主治`,`组成` from `偏方药方` where `主治` like '%" + txt + "%') t";
                DataTable dt = SqlHelper.GetDataTable(sql);
                string str = DtHelper.DtToStr(dt);
                richTextBox1.Text = str;
            }
            else if (SearchName == "医学家")   //薛
            {
                string sql = "select `姓名` AS 姓名,`朝代` AS 朝代,`著作` AS 著作,`成就` AS 成就,`人物评价` AS 人物评价,`生平` AS 生平 from  (select `姓名`,`朝代`,`著作`,`成就`,`人物评价`,`生平` from `历代名家信息` where `姓名` like '%" + txt + "%' union select `姓名`,`朝代`,`著作`,`成就`,`人物评价`,`生平` from `历代名家信息` where `著作` like '%" + txt + "%') t";
                DataTable dt = SqlHelper.GetDataTable(sql);
                string str = DtHelper.DtToStr(dt);
                richTextBox1.Text = str;
            }
        }
    }
}
