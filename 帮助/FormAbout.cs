using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 中医信息管理系统.帮助
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            labVersion.Text = "当前版本：" + version.ToString();
            labRight.Text = "Copyright © 2022-2023 郭永刚课题组 版权所有";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
