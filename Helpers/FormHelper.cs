using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 中医信息管理系统.Helpers
{
    class FormHelper
    {
        public static void ShowForm(Form form)
        {
            FormLogicians formLogicians = null;
            //同一个程序，一个窗口控制另一窗口的控件(解决"未将对象引用设置到对象的实例")
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "FormLogicians")
                {
                    formLogicians = (FormLogicians)f;
                    break;
                }
            }
            formLogicians.splitContainer1.Panel2.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            formLogicians.splitContainer1.Panel2.Controls.Add(form);//加载子窗体
            form.Show();
        }
    }
}
