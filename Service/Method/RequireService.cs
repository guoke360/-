using Resposity.Entities;
using Resposity.Enum;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Method
{
    /// <summary>
    /// 负责人：王莉雯、孙铭丹
    /// </summary>
    public class RequireService : BaseResposity, IRequire
    {
        public IList<RequireDM> RequireList(String InsShelftype = "", int? page = 0, int? count = 10)
        {
            IQueryable<RequireDM> list = from Require in db.Install
                                         select new RequireDM
                                         {
                                             InstallID = Require.InstallID,
                                             InsShelftype = Require.InsShelftype,
                                             InsTonnage = Require.InsTonnage,
                                             InsTonUnit = Require.InsTonUnit,
                                             Insplace = Require.Insplace,
                                             InsStartDate = Require.InsStartDate,
                                             InsCycle = Require.InsCycle,
                                             InsCycleUnit = Require.InsCycleUnit,
                                             InsHeight = Require.InsHeight,
                                             InsHghUnit = Require.InsHghUnit,
                                             InsBeamHgh = Require.InsBeamHgh,
                                             InsStyHghUnit = Require.InsStyHghUnit,
                                             InsAtticLayer = Require.InsAtticLayer,
                                             InsForkExtension = Require.InsForkExtension,
                                             InsStretchCom = Require.InsStretchCom,
                                             InsMoney = Require.InsMoney,
                                             InsMoneyCom = Require.InsMoneyCom,
                                             InsProjectState= Require.InsProjectState,
                                             OfferState = (from offer in db.Offer
                                                      where offer.InstallID == Require.InstallID && offer.OfferState== OfferState.Yes
                                                      select offer.OfferState).FirstOrDefault()
                                         };
            if (!String.IsNullOrEmpty(InsShelftype))
            {
                list = list.Where(x => x.InsShelftype.Contains(InsShelftype));
            }
            return list.OrderByDescending(x => x.InstallID).Skip(page.Value * count.Value).Take(count.Value).ToList();
        }

        public int RequiresList(String InsShelftype = "")
        {
            IQueryable<RequireDM> list = from Require in db.Install
                                         select new RequireDM
                                         {
                                             InstallID = Require.InstallID,
                                             InsShelftype = Require.InsShelftype,
                                             InsTonnage = Require.InsTonnage,
                                             InsTonUnit = Require.InsTonUnit,
                                             Insplace = Require.Insplace,
                                             InsStartDate = Require.InsStartDate,
                                             InsCycle = Require.InsCycle,
                                             InsCycleUnit = Require.InsCycleUnit,
                                             InsHeight = Require.InsHeight,
                                             InsHghUnit = Require.InsHghUnit,
                                             InsBeamHgh = Require.InsBeamHgh,
                                             InsStyHghUnit = Require.InsStyHghUnit,
                                             InsAtticLayer = Require.InsAtticLayer,
                                             InsForkExtension = Require.InsForkExtension,
                                             InsStretchCom = Require.InsStretchCom,
                                             InsMoney = Require.InsMoney,
                                             InsMoneyCom = Require.InsMoneyCom,
                                             InsProjectState = Require.InsProjectState,
                                             OfferState = (from offer in db.Offer
                                                           where offer.InstallID == Require.InstallID && offer.OfferState == OfferState.Yes
                                                           select offer.OfferState).FirstOrDefault()
                                         };
            if (!String.IsNullOrEmpty(InsShelftype))
            {
                list = list.Where(x => x.InsShelftype.Contains(InsShelftype));
            }
            return list.Count();
        }

        public void RequireAdd(DateTime? InsStartDate, String UserID, String InsShelftype = "", String InsTonnage = "", String InsTonUnit = "", String Insplace = "", String InsCycle = "", String InsCycleUnit = "", String InsHeight = "",
            String InsHghUnit = "", String InsBeamHgh = "", String InsStyHghUnit = "", String InsAtticLayer = "", String InsForkExtension = "", String InsStretchCom = "", String InsMoney = "", String InsMoneyCom = "",
            String InsName = "", String InsPhone = "", String InsRemark = "")
        {
            Fc_Install Require = new Fc_Install();
            Require.InstallID = DateTime.Now.Ticks.ToString();
            if (String.IsNullOrEmpty(InsShelftype))
            {
                throw new ArgumentException("请填写货架类型！");
            }
            if (String.IsNullOrEmpty(InsTonnage))
            {
                throw new ArgumentException("请填写设计吨位！");
            }
            if (String.IsNullOrEmpty(Insplace))
            {
                throw new ArgumentException("请填写安装地点！");
            }
            if (InsStartDate==null)
            {
                throw new ArgumentException("请填写开工日期！");
            }
            if (InsStartDate!=null)
            {
                if(InsStartDate<DateTime.Now)
                throw new ArgumentException("请选择今天之后的日期！");
            }
            if (String.IsNullOrEmpty(InsCycle))
            {
                throw new ArgumentException("请填写安装周期！");
            }
            if (String.IsNullOrEmpty(InsHeight))
            {
                throw new ArgumentException("请填写立柱高度！");
            }
            if (String.IsNullOrEmpty(InsBeamHgh))
            {
                throw new ArgumentException("请填写横梁层高！");
            }
            if (String.IsNullOrEmpty(InsAtticLayer))
            {
                throw new ArgumentException("请填写阁楼层数！");
            }
            if (String.IsNullOrEmpty(InsForkExtension))
            {
                throw new ArgumentException("请填写货叉伸拉！");
            }
            if (String.IsNullOrEmpty(InsMoney))
            {
                throw new ArgumentException("请填写安装价格！");
            }
            if (String.IsNullOrEmpty(InsName))
            {
                throw new ArgumentException("请填写联系人！");
            }
            if (String.IsNullOrEmpty(InsPhone))
            {
                throw new ArgumentException("请填写联系方式！");
            }
            Regex r = new Regex(@"^[1]+[3,5,8]+\d{9}");
            if (!r.IsMatch(InsPhone))
            {
                throw new ArgumentException("请填写正确联系方式！");
            }
            Require.UserID = UserID;
            Require.InsShelftype = InsShelftype;
            Require.InsTonnage = InsTonnage;
            Require.InsTonUnit = InsTonUnit;
            Require.Insplace = Insplace;
            Require.InsStartDate = InsStartDate;
            Require.InsCycle = InsCycle;
            Require.InsCycleUnit = InsCycleUnit;
            Require.InsHeight = InsHeight;
            Require.InsHghUnit = InsHghUnit;
            Require.InsBeamHgh = InsBeamHgh;
            Require.InsStyHghUnit = InsStyHghUnit;
            Require.InsAtticLayer = InsAtticLayer;
            Require.InsForkExtension = InsForkExtension;
            Require.InsStretchCom = InsStretchCom;
            Require.InsMoney = InsMoney;
            Require.InsMoneyCom = InsMoneyCom;
            Require.InsName = InsName;
            Require.InsPhone = InsPhone;
            Require.InsRemark = InsRemark;
            Require.InstallSendDate = DateTime.Now;
            Require.InsProjectState = InsProjectState.NoAudited;
            db.Install.Add(Require);
            db.SaveChanges();
        }

        public RequireDM RequireAuditing(String InstallID)
        {
            RequireDM Require = new RequireDM();
            var list = db.Install.Find(InstallID);
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
            return Require;
        }

        public bool RequireAudited(String InstallID, InsProjectState InsProjectState)
        {
            if (InsProjectState != InsProjectState.None && InsProjectState != InsProjectState.All)
            {
                if (InsProjectState == InsProjectState.Audited)
                {
                    Fc_Install info = db.Install.Where(x => x.InstallID.Equals(InstallID)).FirstOrDefault();
                    info.InsProjectState = InsProjectState;
                    db.Install.Attach(info);
                    db.Entry<Fc_Install>(info).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    Fc_Install info = db.Install.Where(x => x.InstallID.Equals(InstallID)).FirstOrDefault();
                    info.InsProjectState = InsProjectState;
                    db.Install.Attach(info);
                    db.Entry<Fc_Install>(info).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return false;
                }
                
            }
            else
            {
                throw new ArgumentException("审核状态不能为空！");
            }
        }

        public IList<RequireDM> RequireBidding(String InstallID, int? page = 0, int? count = 10)
        {
            IQueryable<RequireDM> list = from Offer in db.Offer
                                         join user in db.UserInfo on Offer.UserID equals user.UserID
                                         where Offer.InstallID == InstallID
                                         select new RequireDM
                                         {
                                             OfferID = Offer.OfferID,
                                             InstallID = InstallID,
                                             CompanyName = user.CompanyName,
                                             InsName = user.UserRealName,
                                             InsPhone = user.UserPhone,
                                             OfferMoney = Offer.OfferMoney,
                                             OfferState = Offer.OfferState
                                         };
            return list.OrderByDescending(x => x.OfferID).Skip(page.Value * count.Value).Take(count.Value).ToList();
        }

        public int RequiresBidding(String InstallID)
        {
            IQueryable<RequireDM> list = from Offer in db.Offer
                                         join user in db.UserInfo on Offer.UserID equals user.UserID
                                         where Offer.InstallID == InstallID
                                         select new RequireDM
                                         {
                                             OfferID = Offer.OfferID,
                                             InstallID = InstallID,
                                             CompanyName = user.CompanyName,
                                             InsName = user.UserRealName,
                                             InsPhone = user.UserPhone,
                                             OfferMoney = Offer.OfferMoney,
                                             OfferState = Offer.OfferState
                                         };
            return list.Count();
        }


        public bool RequireBiddingOffer(String OfferID, OfferState OfferState)
        {
            if (OfferState != OfferState.None && OfferState != OfferState.All)
            {
                Fc_Offer info = db.Offer.Where(x => x.OfferID.Equals(OfferID)).FirstOrDefault();
                Fc_Install install = db.Install.Where(x => x.InstallID.Equals(info.InstallID)).FirstOrDefault();
                install.InsProjectState = InsProjectState.NoInstalled;
                info.OfferState = OfferState;
                db.Offer.Attach(info);
                db.Entry<Fc_Offer>(info).State = System.Data.Entity.EntityState.Modified;
                db.Install.Attach(install);
                db.Entry<Fc_Install>(install).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                throw new ArgumentException("投标状态不能为空！");
            }
        }
    }
}
