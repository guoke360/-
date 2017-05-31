using Resposity.Entities;
using Resposity.Enum;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    /// <summary>
    /// 负责人：王清乐
    /// </summary>
    public interface IPersonal
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="UserPassword">密码</param>
        /// <returns></returns>
        PersonalDM LoginUser(String UserName, String UserPassword);

        /// <summary>
        /// 个人管理
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="OldPassword">原密码</param>
        /// <param name="UserPassword">新密码</param>
        /// <returns></returns>
        void Personal(String UserID, String OldPassword, String UserPassword,String SurePassword);
    }

}
