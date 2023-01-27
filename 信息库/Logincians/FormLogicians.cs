using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 中医信息管理系统.Logincians;
using 中医信息管理系统.Helpers;

namespace 中医信息管理系统
{
    public partial class FormLogicians : Form
    {
        public FormLogicians()
        {
            InitializeComponent();
        }

        private static FormLogicians formLogicians = null;//初始化窗体
        /// <summary>
        ///  //单例 只能出现一个窗体
        /// </summary>
        /// <returns></returns>
        public static FormLogicians CreateInstance()
        {
            if (formLogicians == null || formLogicians.IsDisposed) //窗体为空或被释放
                formLogicians = new FormLogicians();
            return formLogicians;
        }

        /// <summary>
        /// 点击treeView节点切换界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.CollapseAll();//初始为折叠状态
            e.Node.Expand();
            if (e.Node.Name == "nodeAdd") //显示"添加各代名家"界面
            {
                FormAddLogicians addLogicians = new FormAddLogicians();
                FormHelper.ShowForm(addLogicians);
            }
            if (e.Node.Name == "nodeSelect") //显示"查询各代名家"界面
            {
                FormSelectLogicians selectLogicians = new FormSelectLogicians();
                FormHelper.ShowForm(selectLogicians);
            }
        }

        /// <summary>
        /// 界面加载显示FormSelectLogicians界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLogicians_Load(object sender, EventArgs e)
        {
            FormSelectLogicians selectLogicians = new FormSelectLogicians();
            FormHelper.ShowForm(selectLogicians);
            //切换至所显示界面的焦点
            treeView1.Focus();
            treeView1.SelectedNode = treeView1.Nodes[1];
        }
    }
}
