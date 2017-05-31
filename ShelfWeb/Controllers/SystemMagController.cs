using Common;
using Newtonsoft.Json;
using Ninject;
using Resposity.Enum;
using Service.Interface;
using ShelfWeb.Filter;
using ShelfWeb.Models;
using ShelfWeb.ViewMapper;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ShelfWeb.Controllers
{
    /// <summary>
    /// 负责人：栾康成
    /// </summary>
    public class SystemMagController : Controller
    {
        [Inject]
        public ISystem user { get; set; }

        [Inject]
        public Paging Paging { get; set; }


        public class Level
        {
            public string Userlevel { get; set; }
        }   


        //用户列表
        [CustAuthorizeAttribute(UserRole.Admin)]
        public ActionResult SystemList(int NowPage = 0)
        {
            VMUser Result = new VMUser();
            Result.list = JsonConvert.SerializeObject(SystemMapper.Userlist(user.UserList()));
            Result.count = user.UsersList();
            Result.AllPage = Paging.SumPage(Result.count, 10);
            Result.NowPage = NowPage;
            Result.NewPage = (Result.AllPage == 0) ? 0 : Result.NowPage + 1;
            Result.UserName = "";
            return View(Result);
        }

        [HttpPost]//用户查询
        [CustAuthorizeAttribute(UserRole.Admin)]
        public ActionResult SystemList(VMUserSeacher search)
        {
            VMUser result = new VMUser();
            result.Userlist = SystemMapper.Userlist(user.UserList(search.UsersState, search.UsersName,search.NowPage));
            result.count = user.UsersList(search.UsersState, search.UsersName);
            result.AllPage = Paging.SumPage(result.count, 10);
            result.NowPage = search.NowPage;
            result.NewPage = (result.AllPage == 0) ? 0 : result.NowPage + 1;
            result.UserName = "";
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        //用户添加
        [HttpPost]
        [CustAuthorizeAttribute(UserRole.Admin)]
        public ActionResult UserAdd(VMAddUserInfo addUser)
        {
            VMUser vmUser = new VMUser();
            try
            {
                user.UserAdd(addUser.UserCategory, addUser.UserState, addUser.UserName, addUser.UserPassword, addUser.UserLevel);
                vmUser.msg = "添加成功！";
            }
            catch (Exception ex)
            {
                vmUser.msg = ex.Message;
            }
            vmUser.Userlist = SystemMapper.Userlist(user.UserList());
            vmUser.count = user.UsersList();
            vmUser.AllPage = Paging.SumPage(vmUser.count, 10);
            vmUser.NowPage = addUser.NowPage;
            vmUser.NewPage = (vmUser.AllPage == 0) ? 0 : vmUser.NowPage + 1;
            vmUser.UserName = "";
            return Json(vmUser, JsonRequestBehavior.AllowGet);
        }

        //用户详细
        [HttpPost]
        [CustAuthorizeAttribute(UserRole.Admin)]
        public ActionResult DetailUser(String UserID)
        {
            VMUser Result = new VMUser();
            var list = user.UserDetail(UserID);
            var level = list.UserLevel;
            Result.UserName = list.UserName;
            Result.UserCategorys = list.UserCategory.ToString();
            Result.UserStates = list.UserState.ToString();
            if (list.UserCategory == UserRole.InstallAdmin)
            {
                string str = list.UserLevel;
                Result.UserLevel = list.UserLevel.Split(',').ToArray();
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        //用户编辑
        [HttpPost]
        [CustAuthorizeAttribute(UserRole.Admin)]
        public ActionResult UserEdit(VMAddUserInfo updataUser)
        {
            VMUser vmUser = new VMUser();
            try
            {
                user.UserEdit(updataUser.UserCategory, updataUser.UserState, updataUser.UserID, updataUser.UserName, updataUser.UserLevel);
                vmUser.msg = "修改成功！";
            }
            catch (Exception ex)
            {
                vmUser.msg = ex.Message;
            }
            vmUser.Userlist = SystemMapper.Userlist(user.UserList());
            vmUser.count = user.UsersList();
            vmUser.AllPage = Paging.SumPage(vmUser.count, 10);
            vmUser.NowPage = updataUser.NowPage;
            vmUser.NewPage = (vmUser.AllPage == 0) ? 0 : vmUser.NowPage + 1;
            vmUser.UserName = "";
            return Json(vmUser, JsonRequestBehavior.AllowGet);
        }
    }
}