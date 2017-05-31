using Common;
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
    /// 负责人:栾康成
    /// </summary>
    public class SystemService : BaseResposity, ISystem
    {
        public IList<SystemDM> UserList(UserState UserState = UserState.All, String UserName = "", int? page = 0, int? count = 10)
        {
            IQueryable<SystemDM> list = from usersinfo in db.UserInfo
                                        where usersinfo.UserCategory == UserRole.Admin || usersinfo.UserCategory == UserRole.InstallAdmin
                                        select new SystemDM
                                        {
                                            UserID = usersinfo.UserID,
                                            UserName = usersinfo.UserName,
                                            UserCategory = usersinfo.UserCategory,
                                            UserLevel = usersinfo.UserLevel,
                                            UserState = usersinfo.UserState
                                        };
            if (UserState != UserState.All && UserState != UserState.None)
            {
                list = list.Where(x => x.UserState == UserState);
            }
            if (!String.IsNullOrEmpty(UserName))
            {
                list = list.Where(x => x.UserName.Contains(UserName));
            }
            return list.OrderByDescending(x => x.UserID).Skip(page.Value * count.Value).Take(count.Value).ToList();
        }

        public int UsersList(UserState UserState = UserState.All, String UserName = "")
        {
            IQueryable<SystemDM> list = from usersinfo in db.UserInfo
                                        where usersinfo.UserCategory == UserRole.Admin || usersinfo.UserCategory == UserRole.InstallAdmin
                                        select new SystemDM
                                        {
                                            UserID = usersinfo.UserID,
                                            UserName = usersinfo.UserName,
                                            UserCategory = usersinfo.UserCategory,
                                            UserLevel = usersinfo.UserLevel,
                                            UserState = usersinfo.UserState
                                        };
            if (UserState != UserState.All && UserState != UserState.None)
            {
                list = list.Where(x => x.UserState == UserState);
            }
            if (!String.IsNullOrEmpty(UserName))
            {
                list = list.Where(x => x.UserName.Contains(UserName));
            }
            return list.Count();
        }

        ///用户添加
        public void UserAdd(UserRole UserCategory, UserState UserState, String UserName = "", String UserPassword = "", String UserLevel = "")
        {
            BD_UserInfo info = new BD_UserInfo();
            Helper pass = new Helper();
            if (String.IsNullOrEmpty(UserName))
            {
                throw new ArgumentException("请输入用户名称！");
            }
            if (String.IsNullOrEmpty(UserPassword))
            {
                throw new ArgumentException("请输入用户密码！");
            }
            if (UserPassword.Length < 6)
            {
                throw new ArgumentException("用户密码至少6位！");
            }
            if (UserState == UserState.None)
            {
                throw new ArgumentException("请选择用户状态！");
            }
            if (UserCategory == UserRole.None)
            {
                throw new ArgumentException("请选择用户权限类别！");
            }
            if (db.UserInfo.Where(x => x.UserName.Equals(UserName)).Count() > 0)
            {
                throw new ArgumentException("用户名称重复！");
            }
            if (UserCategory == UserRole.Admin)
            {
                info.UserID = DateTime.Now.Ticks.ToString();
                info.UserCategory = UserCategory;
                info.UserLevel = "安装公司管理,安装需求管理,安装需求发布,安装需求管理,安装进度管理,系统管理";
                info.UserState = UserState;
                info.UserName = UserName; ;
                info.UserPassword = pass.md5(UserPassword);
                info.UserDate = DateTime.Now;
            }
            else
            {
                if (String.IsNullOrEmpty(UserLevel))
                {
                    throw new ArgumentException("请选择用户权限级别！");
                }
                else
                {
                    info.UserID = DateTime.Now.Ticks.ToString();
                    info.UserCategory = UserCategory;
                    info.UserState = UserState;
                    info.UserLevel = UserLevel;
                    info.UserName = UserName; ;
                    info.UserPassword = pass.md5(UserPassword);
                    info.UserDate = DateTime.Now;
                }
            }
            db.UserInfo.Add(info);
            db.SaveChanges();
        }

        //用户详细
        public SystemDM UserDetail(String UserID)
        {
            SystemDM user = new SystemDM();
            var list = db.UserInfo.Find(UserID);
            user.UserID = list.UserID;
            user.UserLevel = list.UserLevel;
            user.UserCategory = list.UserCategory;
            user.UserState = list.UserState;
            user.UserName = list.UserName;
            //user.UserPassword = list.UserPassword;
            return user;
        }

        //用户编辑
        public void UserEdit(UserRole UserCategory, UserState UserState, String UserID, String UserName = "", String UserPassword = "", String UserLevel = "")
        {
            BD_UserInfo info = new BD_UserInfo();
            Helper pass = new Helper();
            info = db.UserInfo.Where(x => x.UserID.Equals(UserID)).FirstOrDefault();
            info.UserState = UserState;
            info.UserCategory = UserCategory;
            if (!String.IsNullOrEmpty(UserName))
            {
                info.UserName = UserName;
            }
            if (!String.IsNullOrEmpty(UserPassword))
            {
                info.UserPassword = pass.md5(UserPassword);
            }
            if (UserPassword.Length < 6)
            {
                throw new ArgumentException("用户密码至少6位！");
            }
            if (UserCategory == UserRole.InstallAdmin)
            {
                if (!String.IsNullOrEmpty(UserLevel))
                {
                    info.UserLevel = UserLevel;
                }
                else
                {
                    throw new ArgumentException("请选择用户权限级别！");
                }
            }
            else
            {
                info.UserLevel = "";
            }
            db.UserInfo.Attach(info);
            db.Entry<BD_UserInfo>(info).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }


    }
    /// <summary>
    /// 操作失败
    /// </summary>
    public class OperationFalse31185 : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "操作失败！";
            }
        }
    }
}
