using Resposity.Constaint;
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
    /// 视图模型转换器负责人：刘雨杰
    /// </summary>
    public class ScheduleMapper
    {

        public class aa
        {
            public static int bb = 0;
            public static TimeSpan Start;
            public static TimeSpan end;
        }

        public static IList<ScheduleDM> listforlook(IList<ScheduleDM> ScheduleDetials, UrlHelper url)
        {
            int a = 0;
            IList<ScheduleDM> item = new List<ScheduleDM>();//类似视图转换器，这儿就不多多讲述了
            foreach (var aa in ScheduleDetials)
            {
                a++;
                item.Add(listforlookss(aa, a, url));
            }
            return item;
        }
        public static ScheduleDM listforlookss(ScheduleDM ScheduleDetials, int a, UrlHelper url)
        {
            ScheduleDM item = new ScheduleDM();
            item.OfferID = ScheduleDetials.OfferID;
            item.InsShelftype = ScheduleDetials.InsShelftype;
            item.InsTonnage = ScheduleDetials.InsTonnage;
            item.InsMoney = ScheduleDetials.InsMoney;
            item.Insplace = ScheduleDetials.Insplace;
            item.InsStartDate = ScheduleDetials.InsStartDate;
            item.InsCycle = ScheduleDetials.InsCycle;
            item.InsHeight = ScheduleDetials.InsHeight;
            item.InsBeamHgh = ScheduleDetials.InsBeamHgh;
            item.StepStartTimes = ScheduleDetials.StepStartTimes;
            item.InsAtticLayer = ScheduleDetials.InsAtticLayer;
            item.InsForkExtension = ScheduleDetials.InsBeamHgh;
            item.InsBeamHgh = ScheduleDetials.InsForkExtension;
            item.CompanyName = ScheduleDetials.CompanyName;
            item.OfferMoney = ScheduleDetials.OfferMoney;
            item.look = url.Action("Scheduledetial", "ScheduleMag", new { id = item.OfferID });
            return item;

        }

        public static IList<ScheduleDM> ScheduleInfo(IList<ScheduleDM> ScheduleDetials)
        {
            int a = 0;
            IList<ScheduleDM> item = new List<ScheduleDM>();//类似视图转换器，这儿就不多多讲述了
            foreach (var aa in ScheduleDetials)
            {
                a++;
                item.Add(ScheduleInfos(aa, a));
            }
            return item;
        }

        public static VMSchedule offerdetial(String OfferID)
        {
            DataContent db = new DataContent();//回头给安装公司的详细做搜索实例化类
            VMSchedule Result = new VMSchedule();//实例化一个ScheduleDM           
            var info = db.Offer.Where(x => x.OfferID.Equals(OfferID)).FirstOrDefault();//这儿通过offerid获取投标表的用户id
            var infos = db.UserInfo.Where(x => x.UserID.Equals(info.UserID)).FirstOrDefault();//这儿通过USerid到用户表中去读取安装公司信息
            Result.CompanyName = infos.CompanyName;//获取安装公司信息并且赋值
            Result.UserRealName = infos.UserRealName;//获取安装公司联系人并且赋值
            Result.UserPhone = infos.UserPhone;//获取安装公司联系人电话并且赋值
            return Result;
        }


        public static ScheduleDM ScheduleInfos(ScheduleDM ScheduleDetials, int a)
        {
            ScheduleDM item = new ScheduleDM();
            item.idd = a.ToString();
            item.StepID = ScheduleDetials.StepID;
            item.OfferID = ScheduleDetials.OfferID;
            item.StepName = ScheduleDetials.StepName;
            item.StepStartTime = ScheduleDetials.StepStartTime;
            item.StepEndTime = ScheduleDetials.StepEndTime;
            item.InsProjectState = ScheduleDetials.InsProjectState;
            if (item.StepEndTime == null)
            {
                ScheduleDetials.StepEndTime = DateTime.Now;
            }
            item.Tool = ScheduleDetials.Tool;
            item.people = ScheduleDetials.people;
            item.StepLiable = ScheduleDetials.StepLiable;
            item.StepArtificial = ScheduleDetials.StepArtificial;
            //底下一大段皆为日期加减（注正确的每个工程的开始日期和结束日期必须要执行两次）
            TimeSpan timeNow = new TimeSpan(DateTime.Now.Ticks);
            DateTime ddd = ScheduleDetials.StepStartTime.Value;
            DateTime sss = ScheduleDetials.StepEndTime.Value;
            TimeSpan ts = new TimeSpan(0);
            TimeSpan time = new TimeSpan(ddd.Ticks);
            TimeSpan times = new TimeSpan(sss.Ticks);
            TimeSpan time1 = timeNow - time;
            if (aa.Start == ts) 
            {
                aa.Start = time;
            }
            else if (aa.Start > time)
            {
                aa.Start = time;
            }
            if (aa.end == ts)
            {
                aa.end = times;
            }
            else if (aa.end < times)
            {
                aa.end = times;
            }
            if (aa.bb < time1.Days)
            {
                aa.bb = time1.Days;
            }
            TimeSpan StratTime = time - aa.Start;
            TimeSpan Endtime = times - aa.Start;
            item.StratTime = StratTime.Days;
            item.EndTime = Endtime.Days;
            return item;
        }
    }
}
