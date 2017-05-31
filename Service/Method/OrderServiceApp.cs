using Resposity.Entities;
using Resposity.Enum;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Method
{
    public class OrderServiceApp : BaseResposity, IOrderApp
    {
        public class RobOrderItem
        {
            public string RobOrderID { get; set; }
            public DateTime StartTime { get; set; }
            public string InstallCycle { get; set; }
            public string Title { get; set; }
            public int StateCode { get; set; }
            public string Tonnage { get; set; }
            public string InstallPlace { get; set; }
        }

        public class MyOrderItem
        {
            public string MyOrderID { get; set; }
            public DateTime? StartTime { get; set; }
            public string InstallCycle { get; set; }
            public string Title { get; set; }
            public int StateCode { get; set; }
            public string Tonnage { get; set; }
            public string InstallPlace { get; set; }
        }

        public IList<RobOrderItem> RobOrderList(String UserID ,int? Count = 10, int? Page = 0)
        {

            IQueryable<RobOrderItem> list = from a in db.Install
                                            where a.InsProjectState==InsProjectState.Audited
                                            select new RobOrderItem
                                            {
                                                StartTime = a.InstallSendDate,
                                                InstallCycle = a.InsCycle,
                                                RobOrderID = a.InstallID,
                                                Title = a.InsShelftype,
                                                Tonnage = a.InsTonnage,
                                                InstallPlace = a.Insplace,

                                                StateCode = (from i in db.Offer
                                                             where i.InstallID == a.InstallID && i.UserID==UserID
                                                             select i).Count()//如果该数值为0订单状态为未抢，如果该数值不是0订单状态为已抢

                                            };
            return list.OrderBy(x => x.StartTime).Skip(Page.Value * Count.Value).Take(Count.Value).ToList();
        }

        public OrderDMApp RobOrderInfo(String InstallID)
        {
            OrderDMApp Ord = new OrderDMApp();
            if (String.IsNullOrEmpty(InstallID))
            {
                Ord.msg = "1";//ID为空
            }
            else
            {
                var list = db.Install.Find(InstallID);
                Ord.InstallID = InstallID;
                Ord.InsShelftype = list.InsShelftype;
                Ord.InsTonnage = list.InsTonnage;
                Ord.Insplace = list.Insplace;
                Ord.InsStartDate = list.InsStartDate;
                Ord.InsCycle = list.InsCycle;
                Ord.InsHeight = list.InsHeight;
                Ord.InsBeamHgh = list.InsBeamHgh;
                Ord.InsAtticLayer = list.InsAtticLayer;
                Ord.InsForkExtension = list.InsForkExtension;
                Ord.InsMoney = list.InsMoney;
                Ord.InsName = list.InsName;
                Ord.InsPhone = list.InsPhone;
                Ord.InsRemark = list.InsRemark;
                Ord.InsTonUnit = list.InsTonUnit;
                Ord.InsCycleUnit = list.InsCycleUnit;
                Ord.InsHghUnit = list.InsHghUnit;
                Ord.InsStyHghUnit = list.InsStyHghUnit;
                Ord.InsStretchCom = list.InsStretchCom;
                Ord.InsMoneyCom = list.InsMoneyCom;
            }
            return Ord;
        }

        public OrderDMApp RobOrderSubmit(String UserID, String InstallID, String OfferMoney, String OfferWeight)
        {
            int count = (from i in db.Offer
                         where i.InstallID == InstallID && i.UserID == UserID
                         select i).Count();
            OrderDMApp Ord = new OrderDMApp();
            if (String.IsNullOrEmpty(UserID))
            {
                Ord.msg = "1";//请先登录
            }
            if (String.IsNullOrEmpty(InstallID))
            {
                Ord.msg = "2";//请选择需求
            }
            if (String.IsNullOrEmpty(OfferMoney))
            {
                Ord.msg = "3";//请填写金额
            }
            if (count == 0)
            {
                Fc_Offer off = new Fc_Offer();
                off.OfferID = DateTime.Now.Ticks.ToString();
                off.InstallID = InstallID;
                off.UserID = UserID;
                off.OfferMoney = OfferMoney+OfferWeight;
                off.OfferTime = DateTime.Now;
                off.OfferState = OfferState.No;
                off.OfferGet = OfferGetState.No;
                db.Offer.Add(off);
                db.SaveChanges();
                Ord.msg = "4";//投标成功
            }
            else
            {
                Ord.msg = "5";//已被抢
            }
            return Ord;
        }

        public IList<MyOrderItem> Order(String UserID, int? Count = 10, int? Page = 0)
        {
            IQueryable<MyOrderItem> ord = from a in db.Install
                                         join b in db.Offer on a.InstallID equals b.InstallID
                                          where b.UserID == UserID
                                         select new MyOrderItem
                                         {
                                             MyOrderID=b.OfferID,
                                             StartTime = a.InsStartDate,
                                             InstallCycle = a.InsCycle,
                                             Title = a.InsShelftype,
                                             Tonnage = a.InsTonnage,
                                             InstallPlace = a.Insplace,
                                             StateCode = (int)a.InsProjectState
                                         };
            return ord.OrderBy(x=>x.StartTime).Skip(Page.Value * Count.Value).Take(Count.Value).ToList();
        }

        public OrderDMApp OrderInfo(String InstallID)
        {
            OrderDMApp Ord = new OrderDMApp();
            var list1 = db.Offer.Find(InstallID);
            string id = list1.InstallID;
            var list = (from a in db.Install
                        join b in db.Offer on a.InstallID equals b.InstallID
                        where a.InstallID == id
                        select a).FirstOrDefault();
            Ord.InstallID = InstallID;
            Ord.InsShelftype = list.InsShelftype;
            Ord.InsTonnage = list.InsTonnage;
            Ord.Insplace = list.Insplace;
            Ord.InsStartDate = list.InsStartDate;
            Ord.InsCycle = list.InsCycle;
            Ord.InsHeight = list.InsHeight;
            Ord.InsBeamHgh = list.InsBeamHgh;
            Ord.InsAtticLayer = list.InsAtticLayer;
            Ord.InsForkExtension = list.InsForkExtension;
            Ord.InsMoney = list.InsMoney;
            Ord.InsName = list.InsName;
            Ord.InsPhone = list.InsPhone;
            Ord.InsRemark = list.InsRemark;
            Ord.InsMoneyCom = list.InsMoneyCom;
            Ord.InsTonUnit = list.InsTonUnit;
            Ord.InsCycleUnit = list.InsCycleUnit;
            Ord.InsHghUnit = list.InsHghUnit;
            Ord.InsStyHghUnit = list.InsStyHghUnit;
            Ord.InsStretchCom = list.InsStretchCom;
            Ord.InsMoneyCom = list.InsMoneyCom;
            return Ord;
        }

        public EvaluateDMApp Evaluate(String InstallID)
        {
            EvaluateDMApp Eva = new EvaluateDMApp();
            if (String.IsNullOrEmpty(InstallID))
            {
                Eva.msg = 0;//暂无评价
            }
            else
            {
                var list = db.Evaluate.Find(InstallID);
                Eva.EvalSatisfied = list.EvalSatisfied;
                Eva.EvalQuality = list.EvalQuality;
                Eva.EvalReachRate = list.EvalReachRate;
                Eva.EvalAccident = list.EvalAccident;
                Eva.EvalManagement = list.EvalManagement;
                Eva.EvalContent = list.EvalContent;
                Eva.msg = 1;//成功
            }
            return Eva;
        }
    }
}
