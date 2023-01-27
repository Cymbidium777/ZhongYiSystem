using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中医信息管理系统.entity
{
    class Login
    {
        public static Login _Current = null;
        //应用单件模式，保存用户登录状态
        public static Login Current
        {
            get
            {
                if (_Current == null)
                    _Current = new Login();
                return _Current;
            }
        }

        public string LoginID { get; set; } //登录编号
        public string LoginRole { get; set; } //登录身份
        public string CreateID { get; set; } //注册编号
        public string CreatePW { get; set; } //注册密码
        public string CreateRole { get; set; } //注册身份

    }
}
