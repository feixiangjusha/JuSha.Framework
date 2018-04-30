using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace JuSha.Framework.Common.Enums
{
    /// <summary>
    /// 功能权限类型
    /// </summary>
     public enum FuncType
    {
        [Description("非控制")]
        NoRole = 0,

        [Description("页面")]
        Page = 1,

        [Description("对话框")]
        Dialog = 2,

        [Description("Ajax请求")]
        Ajax = 3,

         /// <summary>
         /// 部分页，把部分需要做权限控制的按钮等通过部分页实现选择加载，结合Ajax请求实现
         /// 前后端的权限控制
         /// </summary>
        [Description("部分页")]
        Partial = 4,

        [Description("链接")]
        Link = 5,

    }
}
