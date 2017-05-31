using Resposity.Enum;
using Service.Models;
using ShelfWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShelfWeb.ViewMapper
{
    /// <summary>
    /// 视图模型转换器负责人：栾康成
    /// </summary>
    public class SystemMapper
    {
        public static IList<VMUserInfo> Userlist(IList<SystemDM> userlist)
        {
            IList<VMUserInfo> item = new List<VMUserInfo>();
            int i = 1;
            int No;
            foreach (var aa in userlist)
            {
                No = i++;
                item.Add(UserInfo(aa,No));
            }
            return item;
        }

        public static VMUserInfo UserInfo(SystemDM UserInfos,int No)
        {
            VMUserInfo item1 = new VMUserInfo();
            item1.NO = No;
            item1.UserID = UserInfos.UserID;
            item1.UserName = UserInfos.UserName;
            item1.UserLevel = UserInfos.UserLevel;
            switch (UserInfos.UserCategory)
            {
                case UserRole.Admin:
                    item1.UserCategory = "系统管理员";
                    break;
                case UserRole.InstallAdmin:
                    item1.UserCategory = "安装需求管理员";
                    break;
            }
            switch (UserInfos.UserState)
            {
                case UserState.Able:
                    item1.UserState = "启用";
                    break;
                case UserState.DisAble:
                    item1.UserState = "未启用";
                    break;
            }
            return item1;
        }
    }
}