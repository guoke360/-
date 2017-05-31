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
    /// <summary>
    /// 负责人：姜玮佶、王清乐
    /// </summary>
    public class CompanyService : BaseResposity, ICompany
    {
        //安装公司列表
        public IList<CompanyDM> GetCompanyList(UserRole UserString = UserRole.All, CompanyState StatuString = CompanyState.All, String CompanyName = "", int? Page = 0, int? Count = 10)
        {
            IQueryable<CompanyDM> company = from m in db.UserInfo
                                            select new CompanyDM
                                            {
                                                UserID = m.UserID,
                                                CompanyName = m.CompanyName,
                                                CompanyState = m.CompanyState,
                                                UserCategory = m.UserCategory,
                                                UserRealName = m.UserRealName,
                                                UserPhone = m.UserPhone
                                            };
            if (!String.IsNullOrEmpty(CompanyName))
            {
                company = company.Where(s => s.CompanyName.Contains(CompanyName));
            }
            if (UserString == UserRole.All && UserString != UserRole.None)
            {
                company = company.Where(x => (x.UserCategory == UserRole.InsCompanyUser));
            }
            if (StatuString != CompanyState.None && StatuString != CompanyState.All)
            {
                company = company.Where(x => (x.CompanyState == StatuString));
            }
            return company.OrderBy(m => m.UserID).Skip(Page.Value * Count.Value).Take(Count.Value).ToList();
        }


        //安装公司列表分页
        public int GetCompanyListCount(UserRole UserString = UserRole.All, CompanyState StatuString = CompanyState.All, String CompanyName = "")
        {
            IQueryable<CompanyDM> list = from m in db.UserInfo
                                         select new CompanyDM
                                         {
                                             UserID = m.UserID,
                                             CompanyName = m.CompanyName,
                                             CompanyState = m.CompanyState,
                                             UserCategory = m.UserCategory,
                                             UserRealName = m.UserRealName,
                                             UserPhone = m.UserPhone
                                         };
            if (!String.IsNullOrEmpty(CompanyName))
            {
                list = list.Where(s => s.CompanyName.Contains(CompanyName));
            }
            if (UserString == UserRole.All && UserString != UserRole.None)
            {
                list = list.Where(x => (x.UserCategory == UserRole.InsCompanyUser));
            }
            if (StatuString != CompanyState.None && StatuString != CompanyState.All)
            {
                list = list.Where(x => (x.CompanyState == StatuString));
            }
            return list.Count();
        }

        public CompanyDM ComPanys(String UserID)
        {
            CompanyDM Com = new CompanyDM();
            var list = db.UserInfo.Find(UserID);
            Com.UserID = UserID;
            Com.CompanyName = list.CompanyName;
            Com.UserPhone = list.UserPhone;
            Com.UserRealName = list.UserRealName;
            Com.CompanyState = list.CompanyState;
            Com.CompanyLicense = list.CompanyLicense;
            Com.CompanyQualification = list.CompanyQualification;
            Com.CompanyClimbCard = list.CompanyClimbCard;
            Com.CompanyWelderCard = list.CompanyWelderCard;
            Com.CompanyForkliftCard = list.CompanyForkliftCard;
            Com.CompanyElectricianCard = list.CompanyElectricianCard;
            Com.CompanySafeCard = list.CompanySafeCard;
            Com.CompanyInsuranceCard = list.CompanyInsuranceCard;
            return Com;
        }

        public IList<CompanyDM> CompanyCredit(String UserID)
        {
            var list = (from b in db.Offer
                        join c in db.Evaluate on b.OfferID equals c.OfferID
                        where b.UserID == UserID && b.OfferState == OfferState.Yes
                        select new CompanyDM
                        {
                            UserID = b.UserID,
                            EvalSatisfied = c.EvalSatisfied,
                            EvalQuality = c.EvalQuality,
                            EvalReachRate = c.EvalReachRate,
                            EvalAccident = c.EvalAccident,
                            EvalManagement = c.EvalManagement
                        }
                        ).ToList();
            return list;
        }

        public void QuaDelete(Qualifications Qua)
        {
            BD_UserInfo user = db.UserInfo.Find(Qua.UserID);
            if (user != null)
            {
                if (!String.IsNullOrEmpty(Qua.CompanyQualification))
                {
                    user.CompanyQualification = null;
                }
                if (!String.IsNullOrEmpty(Qua.CompanyClimbCard))
                {
                    user.CompanyClimbCard = null;
                }
                if (!String.IsNullOrEmpty(Qua.CompanyWelderCard))
                {
                    user.CompanyWelderCard = null;
                }
                if (!String.IsNullOrEmpty(Qua.CompanyForkliftCard))
                {
                    user.CompanyForkliftCard = null;
                }
                if (!String.IsNullOrEmpty(Qua.CompanyElectricianCard))
                {
                    user.CompanyElectricianCard = null;
                }
                if (!String.IsNullOrEmpty(Qua.CompanySafeCard))
                {
                    user.CompanySafeCard = null;
                }
                if (!String.IsNullOrEmpty(Qua.CompanyInsuranceCard))
                {
                    user.CompanyInsuranceCard = null;
                }
                if (!String.IsNullOrEmpty(Qua.CompanyLicense))
                {
                    user.CompanyLicense = null;
                }
                db.UserInfo.Attach(user);
                db.Entry<BD_UserInfo>(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException("查找不到该安装公司！");
            }
        }

        public void QuaPass(String UserID, CompanyState State)
        {
            BD_UserInfo user = db.UserInfo.Find(UserID);
            if (user != null)
            {
                switch (State)
                {
                    case CompanyState.Pass:
                        user.CompanyState = CompanyState.Pass;
                        break;
                    case CompanyState.NoPass:
                        user.CompanyState = CompanyState.NoPass;
                        break;
                    default: break;
                }
                db.UserInfo.Attach(user);
                db.Entry<BD_UserInfo>(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException("查找不到该安装公司！");
            }
        }
    }
}
