using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中医信息管理系统.Helpers
{
    class DtHelper
    {
        public static string DtToStr(DataTable dt)  //将输入的DataTable表输出为String字符串
        {
            string str = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    str += "【"+dt.Columns[j].ColumnName + "】:   " + dt.Rows[i][j].ToString() + "\n";
                }
                str += "\n";
            }
            return str;
        }
    }
}
