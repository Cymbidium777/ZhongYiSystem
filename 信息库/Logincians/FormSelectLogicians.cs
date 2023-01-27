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
    public partial class FormSelectLogicians : Form
    {
        public FormSelectLogicians()
        {
            InitializeComponent();
        }

        DataTable dtLogicians;

        /// <summary>
        /// 获取历代名家信息,并添加至listView
        /// </summary>
        public void GetLogicians(string sql, params MySqlParameter[] paras)
        {
            //初始化listView
            if (livSelectLogicians.Items.Count > 0)
            {
                livSelectLogicians.Items.Clear();
            }
            dtLogicians = SqlHelper.GetDataTable(sql,paras);
            int length = dtLogicians.Rows.Count;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dtLogicians.Rows[i]["姓名"].ToString();
                    item.SubItems.Add(dtLogicians.Rows[i]["朝代"].ToString());
                    livSelectLogicians.Items.Add(item);
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
        /// 获取RadioButton选中状态
        /// </summary>
        /// <param name="radioButton"></param>
        /// <returns></returns>
        public bool GetRadioButtonChecked(RadioButton radioButton)
        {
            bool check = radioButton.Checked;
            return check;
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
        /// 按所选条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            //判断空值
            if (string.IsNullOrEmpty(txtContent.Text))
            {
                MessageBox.Show("查询内容不能为空", "查询历代名家提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetRadioButtonChecked(rdbName))
            {
                string sql = "select * from  `历代名家信息` where 姓名 like @姓名 or 姓名拼音 like @姓名拼音";
                MySqlParameter[] paras =
                {
                    new MySqlParameter("@姓名拼音",GetPYString(txtContent.Text)+"%"),
                    new MySqlParameter("@姓名","%"+txtContent.Text+"%"),
                };
                GetLogicians(sql, paras);
            }
            if (GetRadioButtonChecked(rdbDynasty))
            {
                string sql = "select * from  `历代名家信息` where 朝代 like @朝代";
                MySqlParameter[] paras =
                {
                    new MySqlParameter("@朝代","%"+txtContent.Text+"%"),
                };
                GetLogicians(sql, paras);
            }
            if (GetRadioButtonChecked(rdbWork))
            {
                string sql = "select * from  `历代名家信息` where 著作 like @著作";
                MySqlParameter[] paras =
                {
                    new MySqlParameter("@著作","%"+txtContent.Text+"%"),
                };
                GetLogicians(sql, paras);
            }
            if (GetRadioButtonChecked(rdbAchievement))
            {
                string sql = "select * from  `历代名家信息` where 成就 like @成就";
                MySqlParameter[] paras =
                {
                    new MySqlParameter("@成就","%"+txtContent.Text+"%"),
                };
                GetLogicians(sql, paras);
            }
        }

        /// <summary>
        /// 双击跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void livSelectLogicians_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormLogicians formLogicians = null;
            //同一个程序，一个窗口控制另一窗口的控件(解决"未将对象引用设置到对象的实例")
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "FormLogicians")
                {
                    formLogicians = (FormLogicians)form;
                    break;
                }
            }
            string LogiciansName = dtLogicians.Rows[livSelectLogicians.Items.IndexOf(livSelectLogicians.FocusedItem)]["姓名"].ToString();
            SelectLogicians.selectLogicians.LogiciansName = LogiciansName;
            FormAddLogicians addLogicians = new FormAddLogicians();
            FormHelper.ShowForm(addLogicians);
            this.Close();
            //切换至所显示界面的焦点
            formLogicians.treeView1.Focus();
            formLogicians.treeView1.SelectedNode = formLogicians.treeView1.Nodes[0];
        }

        /// <summary>
        /// 加载界面执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSelectLogicians_Load(object sender, EventArgs e)
        {
            rdbName.Checked = true;//默认按"姓名"查询
        }
    }
}
