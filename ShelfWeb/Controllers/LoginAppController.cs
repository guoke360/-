using Common;
using Newtonsoft.Json;
using Ninject;
using Resposity.Enum;
using Service.Interface;
using ShelfWeb.Filter;
using ShelfWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelfWeb.Controllers
{
    public class LoginAppController : Controller
    {
        /// <summary>
        /// 负责人：姜玮佶
        /// </summary>

        [Inject]
        public ICommonApp Com { get; set; }
        
        #region 登录用

        public class LoginIn
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class LoginOut
        {
            public string UserID { get; set; }
            public string UserName { get; set; }
            public bool IsProved { get; set; }
            public int Code { get; set; }
        }

        #endregion

        #region 注册用
        public class RegisterIn
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string UnitName { get; set; }
        }
        public class RegisterOut
        {
            public string UserName { get; set; }
            public int Code { get; set; }
        }
        #endregion

        #region 个人中心

        public class PersonInfoIn
        {
            public string UserID { get; set; }
        }

        public class PersonInfoOut
        {
            public string UserPic { get; set; }
            public string PhoneNum { get; set; }
            public string UserUnit { get; set; }
        }

        #endregion

        #region 个人中心

        public class PersonInfoDetailIn
        {
            public string UserID { get; set; }
        }

        public class PersonInfoDetailOut
        {
            public string UserPic { get; set; }
            public string PhoneNum { get; set; }
            public string UserName { get; set; }
            public string UserMail { get; set; }
            public string Unit { get; set; }
            public string Job { get; set; }
            public int Code{get; set;}
        }
        #endregion

        #region 我的信用
        public class MyCreditIn
        {
            public string UserID { get; set; }
            public int RequestNum { get; set; }
        }
        #endregion

        #region 个人修改
        public class ModifyMyInfoIn
        {
            public string UserID { get; set; }
            public string UserPhone { get; set; }
            public string UserName { get; set; }
            public string UserMail { get; set; }
            public string UserUnit { get; set; }
            public string UserJob { get; set; }
        }
        public class ModifyMyInfoOut
        {
            public int Code { get; set; }
        }
        #endregion

     
        [HttpPost]
        public ActionResult UserCenter()
        {
            PersonInfoOut Result = new PersonInfoOut();
            var list = Com.UserCenter(UserInfo.UserID);
            Result.UserPic = list.UserImage;
            Result.PhoneNum = list.UserPhone;
            Result.UserUnit = list.CompanyName;
            return Content(JsonConvert.SerializeObject(Result));
        }

        [HttpPost]
        public ActionResult UserCenters()
        {
            PersonInfoDetailOut Result = new PersonInfoDetailOut();
            var list = Com.UserCenter(UserInfo.UserID);
            if (list == null)
            {
                Result.Code = 1;
            }
            else
            {
                Result.UserPic = list.UserImage;
                Result.PhoneNum = list.UserPhone;
                Result.UserName = list.UserName;
                Result.UserMail = list.UserEmail;
                Result.Unit = list.CompanyName;
                Result.Job = list.UserPosition;
                Result.Code = 0;
            }
            return Content(JsonConvert.SerializeObject(Result));
        }

        //[HttpPost]
        //public ActionResult UserEdit([ModelBinder(typeof(JsonModelBinder))]ModifyMyInfoIn request)
        //{
        //    ModifyMyInfoOut Result = new ModifyMyInfoOut();
        //    try
        //    {
        //        var list = Com.UserEdit(UserInfo.UserID, request.UserPhone, request.UserName, request.UserMail, request.UserUnit, request.UserJob);
        //        Result.Code = list.msg;
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.Code = Convert.ToInt32(ex.Message);
        //    }
        //    return Content(JsonConvert.SerializeObject(Result));
        //}

        [HttpPost]
        public ActionResult MyCredit()
        {
            var list = Com.MyCredit(UserInfo.UserID);
            return Content(JsonConvert.SerializeObject(list));
        }
    }
}