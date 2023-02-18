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

namespace 中医信息管理系统.诊断报告
{
    public partial class FormPrint : Form
    {
        public FormPrint()
        {
            InitializeComponent();
        }

        private void FillDataGridView()
        {
            string sql = "SELECT c.`求诊者姓名` 用户姓名,a.`诊断编号` 报告编号,`求诊日期` 求诊日期,b.`医生姓名` 诊治医生 FROM `诊断信息` a JOIN `医生信息` b ON(a.`医生编号`=b.`医生编号`) JOIN `求诊者信息` c ON(a.`求诊者编号`=c.`求诊者编号`) WHERE a.`求诊者编号`="+Login.Current.LoginID+"";
            //加载数据
            DataTable dt = SqlHelper.GetDataTable(sql);
            //绑定数据
            dgvPrintReport.DataSource = dt;
            dgvPrintReport.Columns["用户姓名"].DisplayIndex = 0;
            dgvPrintReport.Columns["报告编号"].DisplayIndex = 1;
            dgvPrintReport.Columns["求诊日期"].DisplayIndex = 2;
            dgvPrintReport.Columns["诊治医生"].DisplayIndex = 3;
            foreach (DataGridViewColumn item in this.dgvPrintReport.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void FormPrint_Load(object sender, EventArgs e)
        {
            Login.Current.LoginID = "220102";
            Text = "打印报告";
            FillDataGridView();
        }
    }
}
