using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    /// <summary>
    /// 负责人:栾康成
    /// </summary>
    public class SystemDM
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPhone { get; set; }
        public string UserRealName { get; set; }
        public UserState UserState { get; set; }
        public UserRole UserCategory { get; set; }
        public string UserLevel { get; set; }
        public string UserPosition { get; set; }
        public string UserEmail { get; set; }
        public DateTime UserDate { get; set; }
        public string UserProbate { get; set; }
    }
}
