using Ninject;
using Resposity.Constaint;
using Resposity.Entities;
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
    public class PersonalMagController : Controller
    {
        #region 编码（王清乐）


        [Inject]
        public IPersonal personal
        {
            get;
            set;
        }

        //个人管理
        [CustAuthorizeAttribute(UserRole.InsCompanyUser, UserRole.InstallAdmin, UserRole.Admin)]
        public ActionResult Person()
        {
            return View();
        }

        [CustAuthorizeAttribute(UserRole.InsCompanyUser, UserRole.InstallAdmin, UserRole.Admin)]
        [HttpPost]
        public ActionResult Person(VMPersonal editpwd)
        {
            VMPersonal vmPersonal = new VMPersonal();
            try
            {
                personal.Personal(UserInfo.UserID, editpwd.OldPassword, editpwd.UserPassword, editpwd.SurePassword);
                vmPersonal.msg = "密码修改成功！";
            }
            catch (Exception ex)
            {
                vmPersonal.msg = ex.Message;
            }
            return Json(vmPersonal, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}