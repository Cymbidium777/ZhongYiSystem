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

        private void FormTest_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>(txt.Split('，'));
            int s = list.Count;
            string sp = list[0];
            if (SearchName == "症状") //贺
            {
                string sql1 = "select `特效方名称` AS 方药名称,`主治` AS 方药对症,`方药` AS 方药组成 from  (select `特效方名称`,`主治`,`方药` from `秘方特效方` where `主治` like '%" + sp + "%' ";
                string sql2 = "" + sql1;
                if (s > 1)
                {
                    for (int i = 1; i < s; i++)
                    {
                        string t = list[i];
                        sql2 += " and `主治` like '%" + t + "%'";
                    }
                }
                string sql3 = sql2 + "union select `药方名称`,`主治`,`组成` from `偏方药方` where `主治` like '%" + sp + "%'";
                string sql4 = "" + sql3;
                if (s > 1)
                {
                    for (int i = 1; i < s; i++)
                    {
                        string t = list[i];
                        sql4 += " and `主治` like '%" + t + "%'";
                    }
                }
                string sql = sql4 + ") t";
                //MessageBox.Show(sql);
                DataTable dt = SqlHelper.GetDataTable(sql);
                string str = DtHelper.DtToStr(dt);
                if (!"".Equals(str))
                {
                    richTextBox1.Text = str;
                }
                else
                {
                    richTextBox1.Text = "无查询结果";
                }
                //将搜索内容在 richTextBox中标红
                string result = "";//拼接成功结果
                string lastResult = "";//上一个拼接成功结果，与下一个结果对比
                int count = 0; //统计第几个不同的字符串被匹配
                foreach (var item in list)
                {
                    //MessageBox.Show(item);
                    char[] content = str.ToArray();// richTextBox1内容转字符数组
                    for (int i = 0; i < content.Length - item.Length + 1; i++)
                    {
                        for (int j = 0; j < item.Length; j++)
                        {
                            result += content[i + j].ToString();//拼接字符串的结果
                        }
                        if (result.Equals(item))
                        {
                            if (!result.Equals(lastResult))
                            {
                                count++;
                            }
                            lastResult = result;
                            richTextBox1.SelectionStart = i;
                            richTextBox1.SelectionLength = item.Length;
                            switch (count)
                            {
                                case 1:
                                    richTextBox1.SelectionColor = Color.Red;
                                    break;
                                case 2:
                                    richTextBox1.SelectionColor = Color.Blue;
                                    break;
                                case 3:
                                    richTextBox1.SelectionColor = Color.Brown;
                                    break;
                                case 4:
                                    richTextBox1.SelectionColor = Color.Orange;
                                    break;
                                default:
                                    MessageBox.Show("匹配条件不能超过4个！");
                                    break;
                            }
                        }
                        else
                        {
                            result = "";
                        }
                    }
                }
            }
            else if (SearchName == "中药")  //余
            {
                string sql1 = "SELECT `名称` AS 中药名称,`歌诀` AS 中药歌诀 from `中药信息` WHERE `名称` LIKE '%" + txt + "%'";
                DataTable dt1 = SqlHelper.GetDataTable(sql1);
                string str1 = DtHelper.DtToStr(dt1);

                string sql2 = "SELECT `药方名称`,`组成` AS 药方组成 FROM `偏方药方` WHERE `组成` LIKE '%" + txt + "%' UNION SELECT `特效方名称`,`方药`FROM `秘方特效方` WHERE `方药索引`LIKE '%" + txt + "%' UNION SELECT 名称,`方剂组成` FROM `汤方歌诀汤方信息`WHERE `方剂组成` LIKE '%" + txt + "%'";
                DataTable dt2 = SqlHelper.GetDataTable(sql2);
                string str2 = DtHelper.DtToStr(dt2);
                richTextBox1.Text = str1 + str2;
            }
            else if (SearchName == "汤方")  //陈
            {
                string sql = "select `名称` AS 汤方名称,`方剂组成` AS 汤方组成,`功效主治` from(select `名称`,`方剂组成`,`功效主治` from `汤方歌诀汤方信息` where `方剂组成` like '%" + txt + "%' OR `名称` LIKE '%" + txt + "%' OR `功效主治` LIKE '%" + txt + "%' union select `汤方标题`,`汤方内容`,`汤方对症` from `伤寒杂病论汤方` where `汤方内容` like '%" + txt + "%' OR `汤方标题` LIKE '%" + txt + "%' OR `汤方对症` LIKE '%" + txt + "%') t";
                DataTable dt = SqlHelper.GetDataTable(sql);
                string str = DtHelper.DtToStr(dt);
                richTextBox1.Text = str;
            }
            else if (SearchName == "偏方")  //肖
            {
                string sql = "select 药方名称,组成 AS 药方组成,主治 AS 药方主治,用法 AS 药方用法 from `偏方药方` where 药方名称 like '%" + txt + "%' or 组成 like '%" + txt + "%' or 主治 like '%" + txt + "%'";
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
