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
    /// 视图模型转换器负责人：王清乐
    /// </summary>
    public class LoginMapper
    {
        public static IList<VMPersonlInfo> Userlist(IList<PersonalDM> userlist)
        {
            IList<VMPersonlInfo> item = new List<VMPersonlInfo>();
            foreach (var aa in userlist)
            {
                item.Add(UserInfo(aa));
            }
            return item;
        }

        public static VMPersonlInfo UserInfo(PersonalDM UserInfos)
        {
            VMPersonlInfo item1 = new VMPersonlInfo();
            item1.UserID = UserInfos.UserID;
            item1.UserName = UserInfos.UserName;
            item1.UserRealName = UserInfos.UserRealName;
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