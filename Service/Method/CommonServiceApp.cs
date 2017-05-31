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
    public class CommonServiceApp : BaseResposity, ICommonApp
    {
        public PersonalDM LoginUser(String UserName, String UserPassword)
        {
            PersonalDM user = new PersonalDM();
            if (String.IsNullOrEmpty(UserName))
            {
                user.msg = 0;//请输入用户名
            }
            if (String.IsNullOrEmpty(UserPassword))
            {
                user.msg = 1;//请输入密码
            }
            if (db.UserInfo.Where(x => x.UserName.Equals(UserName)).Count() > 0)
            {
                var result = (from a in db.UserInfo
                              where a.UserName == UserName && a.UserPassword == UserPassword
                              select a).FirstOrDefault();
                if (result != null)
                {
                    if (result.UserState == UserState.Able)
                    {
                        user.UserID = result.UserID;
                        user.UserRealName = result.UserRealName;
                        user.UserName = result.UserName;
                        user.UserState = result.UserState;
                        user.UserRole = result.UserCategory;
                        if (CompanyState.Pass == result.CompanyState)
                        {
                            user.IsProved = true;
                        }
                        else {
                            user.IsProved = false;
                        }
                        user.msg = 2;//登录成功
                    }
                    else
                    {
                        user.msg = 3;//该用户尚未启用
                    }
                }
                else
                {
                    user.msg = 4;//用户名密码不正确
                }
            }
            else
            {
                user.msg = 5;//没有该用户
            }
            return user;
        }

        public PersonalDM Register(String CompanyName, String UserName, String UserPassword)
        {
            PersonalDM users = new PersonalDM();
            if (String.IsNullOrEmpty(CompanyName))
            {
                users.msg = 0;//请输入公司名
            }
            if (String.IsNullOrEmpty(UserName))
            {
                users.msg = 1;//请输入用户名
            }
            if (String.IsNullOrEmpty(UserPassword))
            {
                users.msg = 2;//请输入密码
            }
            if ((db.UserInfo.Where(x => x.UserName.Equals(UserName))).Count() == 0)
            {
                BD_UserInfo user = new BD_UserInfo();
                user.UserID = DateTime.Now.Ticks.ToString();
                user.CompanyName = CompanyName;
                user.UserName = UserName;
                user.UserPassword = UserPassword;
                user.UserDate = DateTime.Now;
                user.UserState = UserState.Able;
                user.CompanyState = CompanyState.NoAudited;
                user.CompanyQualification = "/Image/Card.jpg";
                user.CompanyClimbCard = "/Image/Card.jpg";
                user.CompanyWelderCard = "/Image/Card.jpg";
                user.CompanyForkliftCard = "/Image/Card.jpg";
                user.CompanyElectricianCard = "/Image/Card.jpg";
                user.CompanySafeCard = "/Image/Card.jpg";
                user.CompanyInsuranceCard = "/Image/Card.jpg";
                user.CompanyLicense = "/Image/Card.jpg";
                user.UserCategory = UserRole.InsCompanyUser;
                db.UserInfo.Add(user);
                db.SaveChanges();
                users.msg = 3;//注册成功
            }
            else
            {
                users.msg = 4;//用户名已存在
            }
            return users;
        }

        public CommonDMApp UserCenter(String UserID)
        {
            CommonDMApp Com = new CommonDMApp();
            var list = db.UserInfo.Find(UserID);
            Com.UserImage = list.UserImage;
            Com.UserName = list.UserName;
            Com.UserRealName = list.UserRealName;
            Com.UserEmail = list.UserEmail;
            Com.CompanyName = list.CompanyName;
            Com.UserPosition = list.UserPosition;
            Com.CompanyState = list.CompanyState;
            Com.UserPhone = list.UserPhone;
            return Com;
        }

        public PersonalDM UserEdit(String UserID, String UserPhone, String UserName, String UserMail, String UserUnit, String UserJob)
        {
            PersonalDM users = new PersonalDM();
            if (String.IsNullOrEmpty(UserID))
            {
                users.msg = 0;
            }
            else
            {
                var list = db.UserInfo.Find(UserID);
                if (UserPhone=="请填写")
                {
                    list.UserPhone = "";
                }
                else if (UserName == "请填写")
                {
                    list.UserName = "";
                }
                else if (UserMail == "请填写")
                {
                    list.UserEmail = "";
                }
                else if (UserUnit == "请填写")
                {
                    list.CompanyName = "";
                }
                else if (UserJob == "请填写")
                {
                    list.UserPosition = "";
                }
                else
                {
                    list.UserPhone = UserPhone;
                    list.UserRealName = UserName;
                    list.UserEmail = UserMail;
                    list.CompanyName = UserUnit;
                    list.UserPosition = UserJob;
                }
                db.UserInfo.Attach(list);
                db.Entry<BD_UserInfo>(list).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                users.msg = 6;
            }
            return users;
        }

        public class MyCreditItem
        {
            //评价内容
            public string EvaluateContent { get; set; }
            //客户满意度
            public double Satisfaction { get; set; }
            //质量验收
            public double Quality { get; set; }
            //交期达成率
            public double Deliveryrate { get; set; }
            //无安全事故
            public double Safety { get; set; }
            //现场管理
            public double Manage { get; set; }
        }

        public IList<MyCreditItem> MyCredit(String UserID)
        {
            IQueryable<MyCreditItem> list = from a in db.UserInfo
                                             join b in db.Offer on a.UserID equals b.UserID
                                             join c in db.Evaluate on b.OfferID equals c.OfferID
                                             where a.UserID == UserID && a.CompanyState == CompanyState.Pass
                                             select new MyCreditItem
                                             {
                                                 Satisfaction = c.EvalSatisfied,
                                                 Quality = c.EvalQuality,
                                                 Safety = c.EvalAccident,
                                                 Deliveryrate = c.EvalReachRate,
                                                 EvaluateContent = c.EvalContent,
                                                 Manage = c.EvalManagement
                                             };
            return list.ToList();
        }

        public CompanyDMApp Company(String UserID)
        {
            CompanyDMApp Com = new CompanyDMApp();
            if (String.IsNullOrEmpty(UserID))
            {
                Com.msg = 0;//没有登录
            }
            else
            {
                var list = db.UserInfo.Find(UserID);
                Com.CompanyClimbCard = list.CompanyClimbCard;
                Com.CompanyQualification = list.CompanyQualification;
                Com.CompanyWelderCard = list.CompanyWelderCard;
                Com.CompanyForkliftCard = list.CompanyForkliftCard;
                Com.CompanyElectricianCard = list.CompanyElectricianCard;
                Com.CompanySafeCard = list.CompanySafeCard;
                Com.CompanyInsuranceCard = list.CompanyInsuranceCard;
                Com.CompanyLicense = list.CompanyLicense;
                Com.msg = 1;//成功
            }
            return Com;
        }
    }
}
