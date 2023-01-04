using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中医信息管理系统.entity
{
    class JingMai
    {
        public static JingMai _Current = null;
        //应用单件模式，保存用户登录状态
        public static JingMai Current
        {
            get
            {
                if (_Current == null)
                    _Current = new JingMai();
                return _Current;
            }
        }

        public string JingMaiName { get; set; } //经脉名称
    }
}
