using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShelfWeb.Models
{
    public class VMPersonal
    {
        public string msg { get; set; }
        public string UserImage { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserRealName { get; set; }
        public string UserEmail { get; set; }
        public string CompanyName { get; set; }
        public string UserPosition { get; set; }
        public CompanyState CompanyState { get; set; }
        public string UserPassword { get; set; }
        public string OldPassword { get; set; }
        public string SurePassword { get; set; }
    }
}