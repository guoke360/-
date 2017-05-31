using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShelfWeb.Filter
{
    public class UserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public static String UserID
        {
            get
            {
                Object uidobj = HttpContext.Current.Session["UserID"];

                try { PicUserID = uidobj.ToString(); }
                catch
                {
                };
                if (uidobj != null)
                {
                    return uidobj.ToString();
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["UserID"] = value;
            }
        }

        /// <summary>
        /// 用户状态
        /// </summary>
        public static UserState UserState
        {
            get
            {
                Object rolobj = HttpContext.Current.Session["UserState"];
                if (rolobj != null)
                {
                    return (UserState)rolobj;
                }
                return UserState.None;
            }
            set
            {
                HttpContext.Current.Session["UserState"] = value;
            }
        }

        public static String PicUserID { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public static String UserRealName
        {
            get
            {
                Object rneobj = HttpContext.Current.Session["UserRealName"];

                if (rneobj != null)
                {
                    return rneobj.ToString();
                }
                return "";
            }
            set
            {
                HttpContext.Current.Session["UserRealName"] = value;
            }
        }

        /// <summary>
        /// 用户权限
        /// </summary>
        public static String UserLevel
        {
            get
            {
                Object rneobj = HttpContext.Current.Session["UserLevel"];

                if (rneobj != null)
                {
                    return rneobj.ToString();
                }
                return "";
            }
            set
            {
                HttpContext.Current.Session["UserLevel"] = value;
            }
        }

        /// <summary>
        /// 用户角色
        /// </summary>
        public static UserRole UserRole
        {
            get
            {
                Object rneobj = HttpContext.Current.Session["UserRole"];

                if (rneobj != null)
                {
                    return (UserRole)rneobj;
                }
                return UserRole.None;
            }
            set
            {
                HttpContext.Current.Session["UserRole"] = value;
            }
        } 

        /// <summary>
        /// 用户退出登陆
        /// </summary>
        public static void Exit()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}