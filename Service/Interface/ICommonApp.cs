using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Service.Method.CommonServiceApp;

namespace Service.Interface
{
    /// <summary>
    /// 负责人：姜玮佶
    /// </summary>
    public interface ICommonApp
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="UserPassword">密码</param>
        /// <returns></returns>
        PersonalDM LoginUser(String UserName, String UserPassword);

        /// <summary>
        /// APP注册用户
        /// </summary>
        /// <param name="CompanyName">公司名</param>
        /// <param name="UserName">用户名（手机号）</param>
        /// <param name="UserPassword">密码</param>
        PersonalDM Register(String CompanyName, String UserName, String UserPassword);

        /// <summary>
        /// App用户个人资料
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        CommonDMApp UserCenter(String UserID);

        /// <summary>
        /// App用户我的信用
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        IList<MyCreditItem> MyCredit(String UserID);

        /// <summary>
        /// App个人信息修改
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        PersonalDM UserEdit(String UserID, String UserPhone, String UserName, String UserMail, String UserUnit, String UserJob);

        CompanyDMApp Company(String UserID);
    }
}
