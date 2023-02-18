﻿using GMS.系统管理;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using 中医信息管理系统.中医古籍;
using 中医信息管理系统.帮助;
using 中医信息管理系统.诊断报告;

namespace 中医信息管理系统
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrint());
        }
    }
}