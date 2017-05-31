using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resposity.Enum
{
    /// <summary>
    /// 角色枚举
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// 空
        /// </summary>
        None = 0,
        /// <summary>
        /// 系统管理员
        /// </summary>
        Admin = 1,
        /// <summary>
        /// 安装需求管理员
        /// </summary>
        InstallAdmin = 2,
        /// <summary>
        /// 安装公司
        /// </summary>
        InsCompanyUser = 4,
        /// <summary>
        /// 全部
        /// </summary>
        All = 7
    }
}
