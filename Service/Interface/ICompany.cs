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
    /// 负责人：姜玮佶、王清乐
    /// </summary>
    public interface ICompany
    {
        /// <summary>
        /// 安装公司列表
        /// </summary>
        /// <param name="StatuString">用户角色</param>
        /// <param name="StatuString">安装公司认证状态</param>
        /// <param name="CompanyName">安装公司名称</param>
        /// <param name="Page"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        IList<CompanyDM> GetCompanyList(UserRole UserString= UserRole.All, CompanyState StatuString = CompanyState.All, String CompanyName = "", int? Page = 0, int? Count = 10);

        /// <summary>
        /// 安装公司列表分页
        /// </summary>
        /// <param name="StatuString">用户角色</param>
        /// <param name="StatuString">安装公司认证状态</param>
        /// <param name="CompanyName">安装公司名称</param>
        /// <returns></returns>
        int GetCompanyListCount(UserRole UserString = UserRole.All, CompanyState StatuString = CompanyState.All, String CompanyName = "");

        /// <summary>
        /// 安装公司详细
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        CompanyDM ComPanys(String UserID);

        /// <summary>
        /// 安装公司信用
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        IList<CompanyDM> CompanyCredit(String UserID);

        /// <summary>
        /// 安装资质上传
        /// </summary>
        /// <param name="Qua">所有证明的类</param>
        /// <returns></returns>
        void QuaDelete(Qualifications Qua);

        /// <summary>
        /// 安装资质通过
        /// </summary>
        /// <param name="UserID">用户ID</param>
        void QuaPass(String UserID, CompanyState State);
    }
}
