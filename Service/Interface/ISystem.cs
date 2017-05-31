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
    /// 负责人:栾康成
    /// </summary>
    public interface ISystem
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="UserCategory">用户权限类别</param>
        /// <param name="UserState">用户权限级别</param>
        /// <param name="UserName">用户名</param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns>返回总数</returns>
        IList<SystemDM> UserList(UserState UserState = UserState.All,String UserName = "" ,int? page = 0,  int? count = 10);


        /// <summary>
        /// 用户列表分页
        /// </summary>
        /// <param name="UserCategory">用户权限类别</param>
        /// <param name="UserState">用户权限级别</param>
        /// <param name="UserName">用户名</param>
        /// <param name="page"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        int UsersList(UserState UserState = UserState.All, String UserName = "");

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="UserCategory">用户权限类别</param>
        /// <param name="UserState">用户权限级别</param>
        /// <param name="UserName">用户名</param>
        /// <param name="UserPassword">用户密码</param>
        /// <param name="UserLevel">用户级别</param>
        void UserAdd(UserRole UserCategory, UserState UserState, String UserName="", String UserPassword = "", String UserLevel = "");

        /// <summary>
        /// 用户编辑
        /// </summary>
        /// <param name="UserCategory">用户权限类别</param>
        /// <param name="UserState">用户权限级别</param>
        /// <param name="UserName">用户名</param>
        /// <param name="UserPassword">用户密码</param>
        /// <param name="UserLevel">用户级别</param>
        void UserEdit(UserRole UserCategory, UserState UserState,  String UserID, String UserName = "", String UserPassword = "", String UserLevel = "");

        /// <summary>
        /// 用户详细
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        SystemDM UserDetail(String UserID);
    }
}
