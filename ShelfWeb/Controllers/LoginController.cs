using Common;
using Ninject;
using Resposity.Constaint;
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
    /// <summary>
    /// 负责人：王清乐
    /// </summary>


    public class LoginController : Controller
    {
        #region 编码（王清乐）

        [Inject]
        public IPersonal personal
        {
            get;
            set;
        }

        //登录
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VMLogin vm)
        {
            VMLogin Result = new VMLogin();
            try
            {
                Helper pass = new Helper();
                var list = personal.LoginUser(vm.UserName, pass.md5(vm.UserPassword));
                if (list.UserState == UserState.Able)
                {
                    UserInfo.UserID = list.UserID;
                    UserInfo.UserRealName = list.UserRealName;
                    UserInfo.UserState = list.UserState;
                    UserInfo.UserLevel = list.UserLevel;
                    UserInfo.UserRole = list.UserRole;
                    Result.msg = "登陆成功！";
                }
            }
            catch (Exception ex)
            {
                Result.msg = ex.Message;
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}