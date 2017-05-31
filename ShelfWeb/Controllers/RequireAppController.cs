using Newtonsoft.Json;
using Ninject;
using Service.Interface;
using ShelfWeb.Filter;
using ShelfWeb.Models;
using System;
using System.Web.Mvc;

namespace ShelfWeb.Controllers
{
    public class RequireAppController : Controller
    {
        /// <summary>
        /// 负责人：姜玮佶
        /// </summary>

        [Inject]
        public IOrderApp Ord { get; set; }
        [Inject]
        public ICommonApp Com { get; set; }

        #region 抢单用
        public class RobOrderDetailIn
        {
            public string UserID { get; set; }
            public string RobOrderID { get; set; }
        }
        public class RobOrderDetailOut
        {
            //货架类型
            public string Type { get; set; }
            //设计吨位
            public string Tonnage { get; set; }
            //安装地点
            public string InstallPlace { get; set; }
            //开工时间
            public string StartTime { get; set; }
            //安装周期
            public string InstallCycle { get; set; }
            //货架结构
            public string Structure { get; set; }
            //备注
            public string Remarks { get; set; }
            //报价
            public string OrderOffer { get; set; }
            //报价单位
            public string Weight { get; set; }
            //联系人
            public string Contacts { get; set; }
            //手机
            public string Phone { get; set; }
            //立柱高度
            public string Column { get; set; }
            //横梁层高
            public string Beam { get; set; }
            //阁楼层数
            public string Attic { get; set; }
            //货叉伸位
            public string Fork { get; set; }

        }
        #endregion

        #region 我的订单

        public class MyOrderIn
        {
            public string UserID { get; set; }

            public int RequestNum { get; set; }
        }

        public class MyOrderItem
        {
            public string MyOrderID { get; set; }
            public string StartTime { get; set; }
            public string FinishTime { get; set; }
            public string Title { get; set; }
            public int StateCode { get; set; }
            public string Tonnage { get; set; }
            public string InstallPlace { get; set; }
        }
        #endregion

        #region 我的订单
        public class MyOrderInfoIn
        {
            public string UserID { get; set; }
            public string OrderID { get; set; }
        }
        public class MyOrderInfoOut
        {
            //货架类型
            public string Type { get; set; }
            //设计吨位
            public string Tonnage { get; set; }
            //安装地点
            public string InstallPlace { get; set; }
            //开工时间
            public string StartTime { get; set; }
            //安装周期
            public string InstallCycle { get; set; }
            //货架结构
            public string Structure { get; set; }
            //备注
            public string Remarks { get; set; }
            //报价
            public string OrderOffer { get; set; }
            //报价单位
            public string Weight { get; set; }
            //联系人
            public string Contacts { get; set; }
            //手机
            public string Phone { get; set; }
            //立柱高度
            public string Column { get; set; }
            //横梁层高
            public string Beam { get; set; }
            //阁楼层数
            public string Attic { get; set; }
            //货叉伸位
            public string Fork { get; set; }
        }
        #endregion

        #region 抢单
        public class OrderOfferIn
        {
            public string UserID { get; set; }
            public string RobOrderID { get; set; }
            //报价
            public string OrderOffer { get; set; }
            //报价单位
            public string Weight { get; set; }
        }

        public class OrderOfferOut
        {
            //状态码
            public int Code { get; set; }
        }
        #endregion

        #region 评价
        public class EvaluateIn
        {
            public string UserID { get; set; }
            public string OrderID { get; set; }
        }
        public class EvaluateOut
        {
            //评价内容
            public string EvaluateContent { get; set; }
            //客户满意度
            public int Satisfaction { get; set; }
            //质量验收
            public int Quality { get; set; }
            //交期达成率
            public int DeliveryRate { get; set; }
            //无安全事故
            public int Safety { get; set; }
            //现场管理
            public int Manage { get; set; }
            //现场管理
            public int StateCode { get; set; }
        }
        #endregion

        #region 安装资质
        public class AttestationIn
        {
            public string UserID { get; set; }
        }
        public class AttestationOut
        {
            //营业执照
            public string Business { get; set; }
            //安装资质
            public string Install { get; set; }
            //登高证
            public string Climbing { get; set; }
            //焊工证
            public string Welder { get; set; }
            //叉车证
            public string Forklift { get; set; }
            //电工证
            public string Electrician { get; set; }
            //安全员证
            public string SafetyPerson { get; set; }
            //保险
            public string Insurance { get; set; }
            //现场管理
            public int StateCode { get; set; }
        }
        #endregion



        [HttpPost]
        public ActionResult RobOrderList()
        {
            var list = Ord.RobOrderList(UserInfo.UserID);
            return Content(JsonConvert.SerializeObject(list));
        }

        //[HttpPost]
        //public ActionResult RobOrderInfo([ModelBinder(typeof(JsonModelBinder))]RobOrderDetailIn request)
        //{
        //    RobOrderDetailOut Result = new RobOrderDetailOut();
        //    var list = Ord.RobOrderInfo(request.RobOrderID);
        //    Result.Type = list.InsShelftype;
        //    Result.Tonnage = list.InsTonnage+list.InsTonUnit;
        //    Result.Phone = list.InsPhone;
        //    Result.InstallPlace = list.Insplace;
        //    Result.StartTime = Convert.ToDateTime(list.InsStartDate).ToString("yyyy.MM.dd");
        //    Result.InstallCycle = list.InsCycle+list.InsCycleUnit;
        //    Result.Column = list.InsHeight+list.InsHghUnit;
        //    Result.Beam = list.InsBeamHgh+list.InsStyHghUnit;
        //    Result.Attic = list.InsAtticLayer;
        //    Result.Fork = list.InsForkExtension+list.InsStretchCom;
        //    Result.OrderOffer = list.InsMoney;
        //    Result.Contacts = list.InsName;
        //    Result.Remarks = list.InsRemark;
        //    Result.Weight = list.InsMoneyCom;
        //    return Content(JsonConvert.SerializeObject(Result));
        //}

        //[HttpPost]
        //public ActionResult RobOrderSubmit([ModelBinder(typeof(JsonModelBinder))]OrderOfferIn request)
        //{
        //    OrderOfferOut Result = new OrderOfferOut();
        //    try
        //    {
        //        var list = Ord.RobOrderSubmit(UserInfo.UserID, request.RobOrderID, request.OrderOffer, request.Weight);
        //        Result.Code = Convert.ToInt32(list.msg);
        //    }
        //    catch(Exception ex)
        //    {
        //        Result.Code = Convert.ToInt32(ex.Message);
        //    }
        //    return Content(JsonConvert.SerializeObject(Result));
        //}

        //[HttpPost]
        //public ActionResult Order()
        //{
        //    var list = Ord.Order(UserInfo.UserID);
        //    return Content(JsonConvert.SerializeObject(list));
        //}

        //[HttpPost]
        //public ActionResult OrderInfo([ModelBinder(typeof(JsonModelBinder))]MyOrderInfoIn request)
        //{
        //    MyOrderInfoOut Result = new MyOrderInfoOut();
        //    var list = Ord.OrderInfo(request.OrderID);
        //    Result.Type = list.InsShelftype;
        //    Result.Tonnage = list.InsTonnage + list.InsTonUnit;
        //    Result.Phone = list.InsPhone;
        //    Result.InstallPlace = list.Insplace;
        //    Result.StartTime = Convert.ToDateTime(list.InsStartDate).ToString("yyyy.MM.dd");
        //    Result.InstallCycle = list.InsCycle + list.InsCycleUnit;
        //    Result.Column = list.InsHeight + list.InsHghUnit;
        //    Result.Beam = list.InsBeamHgh + list.InsStyHghUnit;
        //    Result.Attic = list.InsAtticLayer;
        //    Result.Fork = list.InsForkExtension + list.InsStretchCom;
        //    Result.OrderOffer = list.InsMoney;
        //    Result.Contacts = list.InsName;
        //    Result.Remarks = list.InsRemark;
        //    Result.Weight = list.InsMoneyCom;
        //    return Content(JsonConvert.SerializeObject(Result));
        //}

        //[HttpPost]
        //public ActionResult Evaluate([ModelBinder(typeof(JsonModelBinder))]EvaluateIn request)
        //{
        //    EvaluateOut Result = new EvaluateOut();
        //    try
        //    {
        //        var list = Ord.Evaluate(request.OrderID);
        //        Result.Satisfaction = Convert.ToInt32(list.EvalSatisfied);
        //        Result.DeliveryRate = Convert.ToInt32(list.EvalReachRate);
        //        Result.Quality = Convert.ToInt32(list.EvalQuality);
        //        Result.Safety = Convert.ToInt32(list.EvalAccident);
        //        Result.Manage = Convert.ToInt32(list.EvalManagement);
        //        Result.EvaluateContent = list.EvalContent;
        //        Result.StateCode = list.msg;
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.StateCode = Convert.ToInt32(ex.Message);
        //    }
            
        //    return Content(JsonConvert.SerializeObject(Result));
        //}

        [HttpPost]
        public ActionResult Commpany()
        {
            AttestationOut Result = new AttestationOut();
            try
            {
                var list = Com.Company(UserInfo.UserID);
                Result.Climbing = list.CompanyClimbCard;
                Result.Install = list.CompanyQualification;
                Result.Welder = list.CompanyWelderCard;
                Result.Forklift = list.CompanyForkliftCard;
                Result.Electrician = list.CompanyElectricianCard;
                Result.SafetyPerson = list.CompanySafeCard;
                Result.Insurance = list.CompanyInsuranceCard;
                Result.Business = list.CompanyLicense;
                Result.StateCode = list.msg;
            }
            catch (Exception ex)
            {
                Result.StateCode = Convert.ToInt32(ex.Message);
            }
            return Content(JsonConvert.SerializeObject(Result));
        }
    }
}