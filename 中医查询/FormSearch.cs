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

namespace 中医信息管理系统
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0;
            cboSearch.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string SearchName = cboSearch.Text;
                string str = txtSearch.Text;
                //FormResult fm = new FormResult(str, SearchName);
                //fm.Show();
                Form frm = Application.OpenForms["FormResult"];  //查找是否打开过窗体  
                if ((frm == null) || (frm.IsDisposed))       //如果没有打开过
                {
                    FormResult fm = new FormResult(str, SearchName);//创建窗体
                    fm.Show();
                }
                else
                {
                    frm.Close();
                    FormResult fm = new FormResult(str, SearchName);//创建窗体
                    fm.Show();
                }
            }
            else
            {
                MessageBox.Show("请输入查询内容");
            }
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSearch.SelectedIndex == 0)
            {
                labTips.Visible = true;
            }
            else
            {
                labTips.Visible = false;
            }
        }
    }
}
