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
            txtSearch.Select();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string SearchName = cboSearch.Text;
            string str = txtSearch.Text;
            FormResult fm = new FormResult(str, SearchName);
            fm.Show();
        }
    }
}
