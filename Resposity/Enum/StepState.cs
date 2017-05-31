using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resposity.Enum
{
    /// <summary>
    /// 工序状态枚举
    /// </summary>
    public enum StepState
    {
        /// <summary>
        /// 空
        /// </summary>
        None = 0,

        /// <summary>
        /// 未完成
        /// </summary>
        No = 1,

        /// <summary>
        /// 已完成
        /// </summary>
        Yes = 2,

        /// <summary>
        /// 全部
        /// </summary>
        All = 3
    }
}
