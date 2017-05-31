using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resposity.Enum
{
    /// <summary>
    /// 工程完成性
    /// </summary>
    public enum InsProjectState
    {
        /// <summary>
        /// 空
        /// </summary>
        None = 0,
        /// <summary>
        /// 未审核
        /// </summary>
        NoAudited = 1,
        /// <summary>
        /// 审核通过
        /// </summary>
        Audited = 2,
        /// <summary>
        /// 审核失败
        /// </summary>
        AuditedFail = 4,
        /// <summary>
        /// 待安装
        /// </summary>
        NoInstalled = 8,
        /// <summary>
        /// 在安装
        /// </summary>
        Installed = 16,
        /// <summary>
        /// 已完成（验收为否）
        /// </summary>
        Completed = 32,
        /// <summary>
        /// 已完结（已评价，验收为是）
        /// </summary>
        Finished = 64,
        /// <summary>
        /// 全部
        /// </summary>
        All = 127
    }
}
