using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resposity.Enum
{
    /// <summary>
    /// 安装公司认证状态枚举
    /// </summary>
    public enum CompanyState
    {
        /// <summary>
        /// 空
        /// </summary>
        None = 0,

        /// <summary>
        /// 未认证
        /// </summary>
        NoAudited = 1,

        /// <summary>
        /// 认证已通过
        /// </summary>
        Pass = 2,

        /// <summary>
        /// 认证未通过
        /// </summary>
        NoPass = 4,

        /// <summary>
        /// 全部
        /// </summary>
        All = 7
    }
}
