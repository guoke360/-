using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    /// <summary>
    /// 负责人：王清乐
    /// </summary>
    public class PersonalDM
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 原密码
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// 用户状态:启用/未启用
        /// </summary>
        public UserState UserState { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string UserRealName { get; set; }

        /// <summary>
        /// 用户权限
        /// </summary>
        public string UserLevel   { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public UserRole UserRole { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string UserPhone { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string UserMail { get; set; }

        public bool IsProved { get; set; }

        public int msg { get; set; }
    }
}
