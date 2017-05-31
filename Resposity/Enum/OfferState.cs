using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resposity.Enum
{
    /// <summary>
    /// 投标状态枚举
    /// </summary>
    public enum OfferState
    {
        /// <summary>
        /// 空
        /// </summary>
        None = 0,
        /// <summary>
        /// 投标成功
        /// </summary>
        Yes = 1,
        /// <summary>
        /// 投标失败
        /// </summary>
        No = 2,
        /// <summary>
        /// 全部
        /// </summary>
        All = 3
    }
}
