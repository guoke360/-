using Common;
using Newtonsoft.Json;
using Ninject;
using Resposity.Enum;
using Service.Interface;
using Service.Models;
using ShelfWeb.Filter;
using ShelfWeb.Models;
using ShelfWeb.ViewMapper;
using System;
using System.Web.Mvc;

namespace ShelfWeb.Controllers
{
    /// <summary>
    /// 负责人：王清乐、姜玮佶
    /// </summary>
    public class CompanyMagController : Controller
    {

        #region 视图列表（王清乐）

        [Inject]
        public ICompany company { get; set; }

        [Inject]
        public Paging Paging { get; set; }

        //安装公司列表
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        public ActionResult CompanyList(int NowPage = 0)
        {
            VMCompanyList Result = new VMCompanyList();
            Result.list = JsonConvert.SerializeObject(CompanyMapper.Companylist(company.GetCompanyList(), Url));
            Result.Count = company.GetCompanyListCount();
            Result.AllPage = Paging.SumPage(Result.Count, 10);
            Result.NowPage = NowPage;
            Result.NewPage = (Result.AllPage == 0) ? 0 : Result.NowPage + 1;
            Result.CompanyName = "";
            return View(Result);
        }

        #endregion

        #region 编码（姜玮佶）

        [Inject]
        public ICompany Com { get; set; }

        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        public ActionResult CompanyInfo(String id)
        {
            CompanyDM Result = new CompanyDM();
            var list = CompanyMapper.CompanyInfo(Com.ComPanys(id), Url, Com.CompanyCredit(id));
            Result.UserID = list.UserID;
            Result.CompanyName = list.CompanyName;
            Result.UserRealName = list.UserRealName;
            Result.UserPhone = list.UserPhone;
            Result.CompanyStates = list.CompanyState;
            Result.CompanyLicense = list.CompanyLicense;
            Result.CompanyQualification = list.CompanyQualification;
            Result.CompanyClimbCard = list.CompanyClimbCard;
            Result.CompanyWelderCard = list.CompanyWelderCard;
            Result.CompanyForkliftCard = list.CompanyForkliftCard;
            Result.CompanyElectricianCard = list.CompanyElectricianCard;
            Result.CompanySafeCard = list.CompanySafeCard;
            Result.CompanyInsuranceCard = list.CompanyInsuranceCard;
            Result.EvalAccident = list.EvalAccident;
            Result.EvalManagement = list.EvalManagement;
            Result.EvalQuality = list.EvalQuality;
            Result.EvalReachRate = list.EvalReachRate;
            Result.EvalSatisfied = list.EvalSatisfied;
            return View(Result);
        }

        [HttpPost]
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        public ActionResult Delete(Qualifications Qua, String UserID)
        {
            CompanyDM Result = new CompanyDM();
            Qua.UserID = UserID;
            try
            {
                Com.QuaDelete(Qua);
            }
            catch (Exception ex)
            {
                Result.msg = ex.Message;
            }
            var list = CompanyMapper.CompanyInfo(Com.ComPanys(UserID),Url, Com.CompanyCredit(UserID));
            Result.CompanyName = list.CompanyName;
            Result.UserRealName = list.UserRealName;
            Result.UserPhone = list.UserPhone;
            Result.CompanyStates = list.CompanyState;
            Result.CompanyLicense = list.CompanyLicense;
            Result.CompanyQualification = list.CompanyQualification;
            Result.CompanyClimbCard = list.CompanyClimbCard;
            Result.CompanyWelderCard = list.CompanyWelderCard;
            Result.CompanyForkliftCard = list.CompanyForkliftCard;
            Result.CompanyElectricianCard = list.CompanyElectricianCard;
            Result.CompanySafeCard = list.CompanySafeCard;
            Result.CompanyInsuranceCard = list.CompanyInsuranceCard;
            Result.EvalAccident = list.EvalAccident;
            Result.EvalManagement = list.EvalManagement;
            Result.EvalQuality = list.EvalQuality;
            Result.EvalReachRate = list.EvalReachRate;
            Result.EvalSatisfied = list.EvalSatisfied;
            Result.msg = "删除成功";
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        public ActionResult Pass(String State, String UserID)
        {
            CompanyDM Result = new CompanyDM();
            try
            {
                if (State == "Pass")
                {
                    Com.QuaPass(UserID, CompanyState.Pass);
                    var list = CompanyMapper.CompanyInfo(Com.ComPanys(UserID), Url, Com.CompanyCredit(UserID));
                    Result.UserID = UserID;
                    Result.CompanyName = list.CompanyName;
                    Result.UserRealName = list.UserRealName;
                    Result.UserPhone = list.UserPhone;
                    Result.CompanyStates = list.CompanyState;
                    Result.CompanyLicense = list.CompanyLicense;
                    Result.CompanyQualification = list.CompanyQualification;
                    Result.CompanyClimbCard = list.CompanyClimbCard;
                    Result.CompanyWelderCard = list.CompanyWelderCard;
                    Result.CompanyForkliftCard = list.CompanyForkliftCard;
                    Result.CompanyElectricianCard = list.CompanyElectricianCard;
                    Result.CompanySafeCard = list.CompanySafeCard;
                    Result.CompanyInsuranceCard = list.CompanyInsuranceCard;
                    Result.EvalAccident = list.EvalAccident;
                    Result.EvalManagement = list.EvalManagement;
                    Result.EvalQuality = list.EvalQuality;
                    Result.EvalReachRate = list.EvalReachRate;
                    Result.EvalSatisfied = list.EvalSatisfied;
                    Result.msg = "认证成功";
                }
                if (State == "NoPass")
                {
                    Com.QuaPass(UserID, CompanyState.NoPass);
                    var list = CompanyMapper.CompanyInfo(Com.ComPanys(UserID), Url, Com.CompanyCredit(UserID));
                    Result.CompanyName = list.CompanyName;
                    Result.UserRealName = list.UserRealName;
                    Result.UserPhone = list.UserPhone;
                    Result.CompanyStates = list.CompanyState;
                    Result.CompanyLicense = list.CompanyLicense;
                    Result.CompanyQualification = list.CompanyQualification;
                    Result.CompanyClimbCard = list.CompanyClimbCard;
                    Result.CompanyWelderCard = list.CompanyWelderCard;
                    Result.CompanyForkliftCard = list.CompanyForkliftCard;
                    Result.CompanyElectricianCard = list.CompanyElectricianCard;
                    Result.CompanySafeCard = list.CompanySafeCard;
                    Result.CompanyInsuranceCard = list.CompanyInsuranceCard;
                    Result.EvalAccident = list.EvalAccident;
                    Result.EvalManagement = list.EvalManagement;
                    Result.EvalQuality = list.EvalQuality;
                    Result.EvalReachRate = list.EvalReachRate;
                    Result.EvalSatisfied = list.EvalSatisfied;
                    Result.msg = "认证失败";
                }
            }
            catch (Exception ex)
            {
                Result.msg = ex.Message;
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 编码（王清乐）

        //安装公司查询
        [HttpPost]
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        public ActionResult CompanyLists(VMCompanySeacher search)
        {
            VMCompanyList result = new VMCompanyList();
            UserRole role = UserRole.All;
            result.CompanyList = CompanyMapper.Companylist(company.GetCompanyList(role, search.StatuString, search.CompanyName, search.NowPage), Url);
            result.Count = company.GetCompanyListCount(role, search.StatuString, search.CompanyName);
            result.AllPage = Paging.SumPage(result.Count, 10);
            result.NowPage = search.NowPage;
            result.NewPage = (result.AllPage == 0) ? 0 : result.NowPage + 1;
            result.CompanyName = "";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}