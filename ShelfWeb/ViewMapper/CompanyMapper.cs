using Resposity.Enum;
using Service.Models;
using ShelfWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelfWeb.ViewMapper
{
    /// <summary>
    /// 视图模型转换器负责人：姜玮佶、王清乐
    /// </summary>
    public class CompanyMapper
    {
        public static IList<VMCompanyListss> Companylist(IList<CompanyDM> Companylist, UrlHelper Url)
        {
            IList<VMCompanyListss> item = new List<VMCompanyListss>();
            int i = 1;
            int No;
            foreach (var aa in Companylist)
            {
                No = i++;
                item.Add(CompanyInfo(aa, Url, null, No));
            }
            return item;
        }

        public static VMCompanyListss CompanyInfo(CompanyDM CompanyInfos, UrlHelper Url, IList<CompanyDM> CompanyCredit = null, int No = 1)
        {
            VMCompanyListss item1 = new VMCompanyListss();
            item1.NO = No;//序号自增
            item1.UserID = CompanyInfos.UserID;//用户ID
            item1.CompanyName = CompanyInfos.CompanyName;//公司名称
            item1.UserRealName = CompanyInfos.UserRealName;//联系人
            item1.UserPhone = CompanyInfos.UserPhone;//联系方式
            item1.CompanyLicense = CompanyInfos.CompanyLicense;//营业执照
            item1.CompanyQualification = CompanyInfos.CompanyQualification;//安装资质
            item1.CompanyClimbCard = CompanyInfos.CompanyClimbCard;//登高证
            item1.CompanyWelderCard = CompanyInfos.CompanyWelderCard;//焊工证
            item1.CompanyForkliftCard = CompanyInfos.CompanyForkliftCard;//叉车证
            item1.CompanyElectricianCard = CompanyInfos.CompanyElectricianCard;//电工证
            item1.CompanySafeCard = CompanyInfos.CompanySafeCard;//安全员证
            item1.CompanyInsuranceCard = CompanyInfos.CompanyInsuranceCard;//保险证明
            item1.Look = Url.Action("CompanyInfo", "CompanyMag", new { id = item1.UserID });//查看公司详情
            //资质认证详细评价
            if (CompanyCredit != null)
            {
                foreach (var e in CompanyCredit)
                {
                    item1.EvalAccident += e.EvalAccident != 0 ? e.EvalAccident : 0;
                    item1.EvalManagement += e.EvalManagement;
                    item1.EvalQuality += e.EvalQuality;
                    item1.EvalReachRate += e.EvalReachRate;
                    item1.EvalSatisfied += e.EvalSatisfied;
                }
                item1.EvalAccident = item1.EvalAccident != 0 ? item1.EvalAccident / CompanyCredit.Count() : 0;
                item1.EvalManagement = item1.EvalManagement != 0 ? item1.EvalManagement / CompanyCredit.Count() : 0;
                item1.EvalQuality = item1.EvalQuality != 0 ? item1.EvalQuality / CompanyCredit.Count() : 0;
                item1.EvalReachRate = item1.EvalReachRate != 0 ? item1.EvalReachRate / CompanyCredit.Count():0;
                item1.EvalSatisfied = item1.EvalSatisfied != 0 ? item1.EvalSatisfied / CompanyCredit.Count():0;
            }
            switch (CompanyInfos.UserCategory)//用户权限
            {
                case UserRole.Admin:
                    item1.CompanyState = "系统管理员";
                    break;
                case UserRole.InstallAdmin:
                    item1.CompanyState = "安装需求管理员";
                    break;
                case UserRole.InsCompanyUser:
                    item1.CompanyState = "安装公司";
                    break;
            }
            switch (CompanyInfos.CompanyState)//公司状态
            {
                case CompanyState.NoAudited:
                    item1.CompanyState = "未认证";
                    break;
                case CompanyState.NoPass:
                    item1.CompanyState = "认证未通过";
                    break;
                case CompanyState.Pass:
                    item1.CompanyState = "认证已通过";
                    break;
            }
            return item1;
        }
    }
}