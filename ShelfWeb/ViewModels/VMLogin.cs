using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShelfWeb.Models
{
    public class VMLogin
    {
        public string msg { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRealName { get; set; }
        public UserState UserState { get; set; }
        public IList<VMPersonlInfo> Getperson { get; set; }
    }

    public class VMPersonlInfo
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRealName { get; set; }
        public string UserState { get; set; }
    }
}