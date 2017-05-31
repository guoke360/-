using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShelfWeb.Models
{
    public class VMSystem
    {

    }

    public class VMUserInfo
    {
        public int NO { get; set; }
        public String UserID { get; set; }
        public String UserCategory { get; set; }
        public String UserState { get; set; }
        public String List { get; set; }
        public string msg { get; set; }
        public String UserName { get; set; }
        public String UserLevel { get; set; }
    }

    public class VMUser
    {
        public String msg { get; set; }
        public int AllPage { get; set; }
        public int NowPage { get; set; }
        public int count { get; set; }
        public int NewPage { get; set; }
        public String list { get; set; }
        public UserRole UserCategory { get; set; }
        public UserState UserState { get; set; }
        public String UserCategorys { get; set; }
        public String UserStates { get; set; }
        public String UserName { get; set; }
        public String UserPassword { get; set; }
        public String [] UserLevel { get; set; }
        public String UserID { get; set; }
        public IList<VMUserInfo> Userlist { get; set; }
        public string result { get; set; }
    }

    public class VMAddUserInfo
    {
        public int NowPage { get; set; }
        public String UserName { get; set; }
        public String UserPassword { get; set; }
        public UserState UserState { get; set; }
        public UserRole UserCategory { get; set; }
        public String UserID { get; set; }
        public String UserLevel { get; set; }
    }

    public class VMUserSeacher
    {
        public int NowPage { get; set; }
        public String UsersName { get; set; }
        public UserState UsersState { get; set; }
        public UserRole UserCategory { get; set; }
    }
}