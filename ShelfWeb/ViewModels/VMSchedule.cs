using Resposity.Enum;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShelfWeb.Models
{
    public class VMSchedule
    {
        public string InstallID { get; set; }
        public string UserID { get; set; }
        public string InsShelftype { get; set; }
        public string InsTonnage { get; set; }
        public string InsTonUnit { get; set; }
        public string Insplace { get; set; }
        public DateTime? InsStartDate { get; set; }
        public string InsCycle { get; set; }
        public string InsCycleUnit { get; set; }
        public string InsHeight { get; set; }
        public string InsHghUnit { get; set; }
        public string InsBeamHgh { get; set; }
        public string InsStyHghUnit { get; set; }
        public string InsAtticLayer { get; set; }
        public string InsForkExtension { get; set; }
        public string InsStretchCom { get; set; }
        public string InsMoney { get; set; }
        public string InsMoneyCom { get; set; }
        public string InsName { get; set; }
        public string InsPhone { get; set; }
        public InsProjectState InsProjectState { get; set; }
        public string OfferID { get; set; }
        public string OfferMoney { get; set; }
        public DateTime? OfferTime { get; set; }
        public int OfferState { get; set; }
        public string StepStartTimes { get; set; }
        public DateTime? OfferDateStart { get; set; }
        public DateTime? OfferDateEnd { get; set; }
        public bool OfferGet { get; set; }
        //用户表
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPhone { get; set; }
        public string UserRealName { get; set; }
        public UserState UserState { get; set; }
        public UserRole UserCategory { get; set; }
        public string UserLevel { get; set; }
        public string UserPosition { get; set; }
        public string UserEmail { get; set; }
        public DateTime? UserDate { get; set; }
        public string UserProbate { get; set; }
        public string UserImage { get; set; }
        public string CompanyQualification { get; set; }
        public string CompanyClimbCard { get; set; }
        public string CompanyWelderCard { get; set; }
        public string CompanyForkliftCard { get; set; }
        public string CompanyElectricianCard { get; set; }
        public string CompanySafeCard { get; set; }
        public string CompanyInsuranceCard { get; set; }
        public string CompanyName { get; set; }
        public string CompanyState { get; set; }
        public string CompanyLicense { get; set; }
        //投标顺序表
        public string StepID { get; set; }
        public string StepName { get; set; }
        public DateTime? StepStartTime { get; set; }
        public DateTime? StepEndTime { get; set; }
        public string Tool { get; set; }
        public string StepLiable { get; set; }
        public string StepArtificial { get; set; }
        //专用页面返回数据显示列表
        public string list { get; set; }
        public string look { get; set; }
        //总页数 
        public int AllPage { get; set; }

        //当前页
        public int NowPage { get; set; }
        //查询列表
        //public IList<ScheduleDM> ScheduleList { get; set; }
        //开始天数
        public int StratTime { get; set; }
        //结束天数
        public int EndTime { get; set; }
        //当年天数
        public string NowTime { get; set; }
        //自动生成的id
        public string idd { get; set; }
        public string people { get; set; }

        //评价表
        public string EvaluateID { get; set; }

        public double EvalSatisfied { get; set; }

        public double EvalQuality { get; set; }

        public double EvalReachRate { get; set; }

        public double EvalAccident { get; set; }

        public double EvalManagement { get; set; }

        public string EvalContent { get; set; }

        public IList<ScheduleDM> ScheduleList { get; set; }

        public DateTime? EvalTime { get; set; }
    }


    public class VMEvaluates
    {
        public IList<ScheduleDM> ScheduleList { get; set; }
        public string msg { get; set; }
        public string OfferID { get; set; }
        public double EvalSatisfied { get; set; }
        public double EvalQuality { get; set; }
        public double EvalReachRate { get; set; }
        public double EvalAccident { get; set; }
        public double EvalManagement { get; set; }
        public String EvalContent { get; set; }
    }
}