using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中医信息管理系统.Helpers
{
    class SelectLogicians
    {
        public string LogiciansName { get; set; }

        public static SelectLogicians _selectLogicians = null;
        //应用单件模式，保存用户登录状态
        public static SelectLogicians selectLogicians
        {
            get
            {
                if (_selectLogicians == null)
                    _selectLogicians = new SelectLogicians();
                return _selectLogicians;
            }
        }
    }
}
