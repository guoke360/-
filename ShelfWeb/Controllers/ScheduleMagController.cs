using Common;
using Newtonsoft.Json;
using Ninject;
using Resposity.Constaint;
using Resposity.Enum;
using Service;
using Service.Interface;
using Service.Models;
using ShelfWeb.Filter;
using ShelfWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ShelfWeb.ViewMapper.ScheduleMapper;

namespace ShelfWeb.Controllers
{   
    /// <summary>
    /// 负责人：刘雨杰、栾康成
    /// </summary>
    public class ScheduleMagController : Controller
    {
        [Inject]
        public ISchedule ISchedule
        {
            get;
            set;
        }
        [Inject]
        public Paging page
        {
            get;
            set;
        }
        
        #region 视图列表（刘雨杰）
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        public ActionResult ScheduleList()
            {
            VMSchedule Result = new VMSchedule();
            Result.list= JsonConvert.SerializeObject(listforlook(ISchedule.ScheduleListss("","",0,10),Url));
            Result .AllPage = page.SumPage(ISchedule.ScheduleLists("", ""),10);
            Result.NowPage = 1;
            if (Result.AllPage == 0)
            {
                Result.NowPage = 0;
            }
            return View(Result);
        }
        #endregion

        #region 工程详细（刘雨杰-栾康成）
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        public ActionResult Scheduledetial(String id)
        {
            VMSchedule Result = new VMSchedule();//实例化一个ScheduleDM
            Result.list = JsonConvert.SerializeObject(ScheduleInfo(ISchedule.ScheduleDetial(id)));//第一次进行筛选，并且选出最早的初始时间和最迟的结束时间（妈的连个开始日期，结束日期都没有）
            var infos = offerdetial(id);//老栾的用户信息
            Result.CompanyName = infos.CompanyName;//获取安装公司信息并且赋值
            Result.UserRealName = infos.UserRealName;//获取安装公司联系人并且赋值
            Result.UserPhone = infos.UserPhone;//获取安装公司联系人电话并且赋值
            Result.OfferID = id;//获取offerID给前台(评论需要用到)
            TimeSpan asd = aa.end-aa.Start;//这儿就可以获取一共有多少天数了
            Result.NowPage = asd.Days;//这里偷懒直接用Int类型的nowpage代替一共多少天数这个变量了     
            Result.list = JsonConvert.SerializeObject(ScheduleInfo(ISchedule.ScheduleDetial(id)));//列表第二次循环（重要一定要执行，第一次执行的时候开始日期和结束日期不是最终形态的完全体，需要执行第二次才能正确的判断处每一个工程的开始日期和完结日期）
            var state = ISchedule.ScheduleDetial(id).FirstOrDefault();
            Result.InsProjectState = state.InsProjectState;
            aa.end = new TimeSpan(0);//全局变量重新归零
            aa.Start = new TimeSpan(0);//全局变量重新归零
            return View(Result);//返回前台
        }
        #endregion

        #region 编码（栾康成）
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        [HttpPost]
        public ActionResult Evaluate(VMEvaluates Result,String OfferID)
        {
            try
            {
                
                ISchedule.Evaluate(Result.EvalSatisfied, Result.EvalQuality, Result.EvalReachRate, Result.EvalAccident, Result.EvalManagement,OfferID, Result.EvalContent);
                Result.msg = "评价成功！";
            }
            catch (Exception ex)
            {
                Result.msg = ex.Message;
            }
            return Json(Result,JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 编码（刘雨杰）
        [CustAuthorizeAttribute(UserRole.InstallAdmin, UserRole.Admin)]
        [HttpPost]
        public ActionResult ScheduleSearch(String SCName, String SCRName, int NowPage = 0)
        {
            if (NowPage <= 0)
            {
                NowPage = 1;
            }
            VMSchedule Result = new VMSchedule();
            Result.ScheduleList = listforlook(ISchedule.ScheduleListss(SCName, SCRName, NowPage - 1, 10),Url);
            Result.AllPage = page.SumPage(ISchedule.ScheduleLists(SCName, SCRName), 10);
            if (Result.AllPage == 0)
            {
                NowPage = 0;
            }

            Result.NowPage = NowPage;
            return Json(Result, JsonRequestBehavior.AllowGet);

        }


        #endregion
    }
}