using Common;
using Newtonsoft.Json;
using Ninject;
using Resposity.Enum;
using Service.Interface;
using ShelfWeb.Filter;
using ShelfWeb.Models;
using ShelfWeb.ViewMapper;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace ShelfWeb.Controllers
{
    /// <summary>
    /// 负责人：王莉雯、孙铭丹
    /// </summary>
    public class RequireMagController : Controller
    {
        [Inject]
        public IRequire require { get; set; }
        [Inject]
        public Paging Pag { get; set; }
        [Inject]
        public Paging Paging { get; set; }
        [Inject]
        public IRequire Require { get; set; }

        #region 视图列表（王莉雯）

        //需求管理
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        public ActionResult RequireList(int NowPage = 0)
        {
            VMRequireList Result = new VMRequireList();
            Result.list = JsonConvert.SerializeObject(RequireMapper.RequireList(Require.RequireList(), Url));
            Result.count = Require.RequiresList();
            Result.AllPage = Paging.SumPage(Result.count, 10);
            Result.NowPage = NowPage;
            Result.NewPage = (Result.AllPage == 0) ? 0 : Result.NowPage + 1;
            Result.InsShelftypeName = "";
            return View(Result);
        }

        //发布需求
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        public ActionResult RequireRelease()
        {
            return View();
        }

        #endregion

        #region 视图列表（孙铭丹）

        //需求审核
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        public ActionResult RequireAuditing(String id)
        {
            VMRequire Require = new VMRequire();
            var list = require.RequireAuditing(id);
            Require.InstallID = id;
            Require.InsShelftype = list.InsShelftype;
            Require.InsTonnage = list.InsTonnage;
            Require.InsTonUnit = list.InsTonUnit;
            Require.Insplace = list.Insplace;
            Require.InsStartDate = list.InsStartDate;
            Require.InsCycle = list.InsCycle;
            Require.InsCycleUnit = list.InsCycleUnit;
            Require.InsHeight = list.InsHeight;
            Require.InsHghUnit = list.InsHghUnit;
            Require.InsBeamHgh = list.InsBeamHgh;
            Require.InsStyHghUnit = list.InsStyHghUnit;
            Require.InsAtticLayer = list.InsAtticLayer;
            Require.InsForkExtension = list.InsForkExtension;
            Require.InsStretchCom = list.InsStretchCom;
            Require.InsMoney = list.InsMoney;
            Require.InsMoneyCom = list.InsMoneyCom;
            Require.InsName = list.InsName;
            Require.InsPhone = list.InsPhone;
            Require.InsRemark = list.InsRemark;
            return View(Require);
        }

        //需求中标管理
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        public ActionResult RequireBidding(String id)
        {
            VMRequire Require = new VMRequire();
            var list = require.RequireAuditing(id);
            Require.InsShelftype = list.InsShelftype;
            Require.InsTonnage = list.InsTonnage;
            Require.InsTonUnit = list.InsTonUnit;
            Require.Insplace = list.Insplace;
            Require.InsStartDate = list.InsStartDate;
            Require.InsCycle = list.InsCycle;
            Require.InsCycleUnit = list.InsCycleUnit;
            Require.InsHeight = list.InsHeight;
            Require.InsHghUnit = list.InsHghUnit;
            Require.InsBeamHgh = list.InsBeamHgh;
            Require.InsStyHghUnit = list.InsStyHghUnit;
            Require.InsAtticLayer = list.InsAtticLayer;
            Require.InsForkExtension = list.InsForkExtension;
            Require.InsStretchCom = list.InsStretchCom;
            Require.InsMoney = list.InsMoney;
            Require.InsMoneyCom = list.InsMoneyCom;
            Require.InsName = list.InsName;
            Require.InsPhone = list.InsPhone;
            Require.InsRemark = list.InsRemark;
            Require.offerlist = JsonConvert.SerializeObject(RequireMapper.Offerlist(require.RequireBidding(id)));
            Require.count = require.RequiresBidding(id);
            Require.NowPage = 0;
            Require.AllPage = Pag.SumPage(Require.count, 10);
            Require.NewPage = (Require.AllPage == 0) ? 0 : Require.NowPage + 1;
            return View(Require);
        }
        #endregion

        #region 孙铭丹
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        [HttpPost]
        public ActionResult RequireYesOrNo(String InstallID, InsProjectState InsProjectState)
        {
            VMRequire Result = new VMRequire();
            bool a = require.RequireAudited(InstallID, InsProjectState);
            if (a)
            {
                Result.url= Url.Action("RequireList","RequireMag");
                Result.msg = "操作通过";
            }
            else
            {
                Result.url = Url.Action("RequireList", "RequireMag");
                Result.msg = "操作失败";
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        [HttpPost]
        public ActionResult SearchPost(VMRequire search)
        {
            VMRequire Require = new VMRequire();
            Require.OfferList = RequireMapper.Offerlist(require.RequireBidding(search.InstallID, search.NowPage));
            Require.count = require.RequiresBidding(search.InstallID);
            Require.NowPage = search.NowPage;
            Require.AllPage = Pag.SumPage(Require.count, 10);
            Require.NewPage = (Require.AllPage == 0) ? 0 : Require.NowPage + 1;
            return Json(Require, JsonRequestBehavior.AllowGet);
        }

        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        [HttpPost]
        public ActionResult Biding(String OfferID, String InstallID)
        {
            VMRequire Result = new VMRequire();
            require.RequireBiddingOffer(OfferID, OfferState.Yes);
            Result.msg = "选择中标单位成功！";
            Result.OfferList = RequireMapper.Offerlist(require.RequireBidding(InstallID, 0));
            Result.count = require.RequiresBidding(InstallID);
            Result.NowPage = 0;
            Result.AllPage = Pag.SumPage(Result.count, 10);
            Result.NewPage = (Result.AllPage == 0) ? 0 : Result.NowPage + 1;
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 王莉雯
        
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        [HttpPost]//需求管理查询
        public ActionResult RequiresList(VMRequireList search)
        {
            VMRequireList Result = new VMRequireList();
            Result.Installlist = RequireMapper.RequireList(Require.RequireList(search.InsShelftypeName, search.NowPage), Url);
            Result.count = Require.RequiresList(search.InsShelftypeName);
            Result.AllPage = Paging.SumPage(Result.count, 10);
            Result.NowPage = search.NowPage;
            Result.NewPage = (Result.AllPage == 0) ? 0 : Result.NowPage + 1;
            Result.InsShelftypeName = "";
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        [HttpPost]//需求发布
        public ActionResult RequiresRelease(VMRequireAdd Release)
        {
            VMRequireList Result = new VMRequireList();
            try
            {
                Require.RequireAdd(Release.InsStartDate, UserInfo.UserID, Release.InsShelftype, Release.InsTonnage, Release.InsTonUnit, Release.Insplace, Release.InsCycle, Release.InsCycleUnit, Release.InsHeight,
        Release.InsHghUnit, Release.InsBeamHgh, Release.InsStyHghUnit, Release.InsAtticLayer, Release.InsForkExtension, Release.InsStretchCom, Release.InsMoney, Release.InsMoneyCom,
        Release.InsName, Release.InsPhone, Release.Remark);
                Result.url = Url.Action("RequireList", "RequireMag");
                Result.msg = "提交成功";
            }
            catch (Exception ex)
            {
                Result.msg = ex.Message;
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}