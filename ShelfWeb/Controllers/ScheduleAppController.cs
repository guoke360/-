using Newtonsoft.Json;
using Ninject;
using Resposity.Constaint;
using Resposity.Entities;
using Resposity.Enum;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Service.Method.ScheduleServiceApp;

namespace ShelfWeb.Controllers
{
    public class ScheduleAppController : Controller
    {
        /// <summary>
        /// 负责人：孙铭丹
        /// </summary>
        [Inject]
        public IScheduleApp Sch { get; set; }

        #region 自动添加工序
        public class ScheduleAddToolItem
        {
            public string OfferID { get; set; }
            public int StepDate { get; set; }
            public StepState StepState{ get; set; }
    }
        #endregion

       


        #region 进度天数
        public class ScheduleDayItem
        {
            public string Day { get; set; }
            public string OfferDateStart { get; set; }
        }
        #endregion

        #region 进度列表
        public class ScheduleItem
        {
            public string UserID { get; set; }
            public string OfferID { get; set; }
            public int StepDate { get; set; }
        }
        #endregion

        #region 添加工序
        public class AddProcessIn
        {
            /// <summary>
            /// 工序
            /// </summary>
            public string Procedure { get; set; }
            /// <summary>
            /// 工具
            /// </summary>
            public string Tools { get; set; }
            /// <summary>
            /// 责任人
            /// </summary>
            public string LiablePerson { get; set; }
            /// <summary>
            /// 人工
            /// </summary>
            public string Manual { get; set; }
            public string OrderID { get; set; }
            public int DayItem { get; set; }
        }
        public class AddProcessOut
        {  
            public int Code { get; set; }
        }

        #endregion

        #region 删除工序
        public class ScheduleDeleteItem
        {
            public string StepID { get; set; }
            public int Code { get; set; }
        }
        #endregion


        #region 完成工序
        public class ScheduleFinishItem
        {
            public string StepID { get; set; }
            public int Code { get; set; }
        }
        #endregion


        #region 周期天数
        public class ProcessIn
        {
            public string OrderID { get; set; }
        }
        public class ProcessOut
        {
            public int DayNumber { get; set; }
            public int Code { get; set; }
        }
        #endregion


    }
}