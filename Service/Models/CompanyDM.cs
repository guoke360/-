using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    /// <summary>
    /// 负责人：姜玮佶、王清乐
    /// </summary>
    public class CompanyDM
    {
        public string UserID { get; set; }
        public string CompanyName { get; set; }
        public string UserPhone { get; set; }
        public string UserRealName { get; set; }
        public CompanyState CompanyState { get; set; }
        public UserRole UserCategory { get; set; }
        public string CompanyStates { get; set; }
        public double EvalSatisfied { get; set; }
        public double EvalQuality { get; set; }
        public double EvalReachRate { get; set; }
        public double EvalAccident { get; set; }
        public double EvalManagement { get; set; }
        public string CompanyLicense { get; set; }
        public string CompanyQualification { get; set; }
        public string CompanyClimbCard { get; set; }
        public string CompanyWelderCard { get; set; }
        public string CompanyForkliftCard { get; set; }
        public string CompanyElectricianCard { get; set; }
        public string CompanySafeCard { get; set; }
        public string CompanyInsuranceCard { get; set; }
        public string msg { get; set; } 
    }
}
