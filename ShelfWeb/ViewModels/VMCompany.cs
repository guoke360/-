using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShelfWeb.Models
{
    public class VMCompany
    {

    }

    /// <summary>
    /// 安装公司列表
    /// </summary>
    public class VMCompanyList
    {
        public String msg { get; set; }
        public String list { get; set; }
        public string result { get; set; }
        public int AllPage { get; set; }
        public int NowPage { get; set; }
        public int NewPage { get; set; }
        public int Count { get; set; }
        public string UserID { get; set; }
        public string CompanyName { get; set; }
        public CompanyState CompanyState { get; set; }
        public string UserRealName { get; set; }
        public string UserPhone { get; set; }
        public IList<VMCompanyListss> CompanyList { get; set; }
    }

    public class VMCompanyListss
    {
        public int NO { get; set; }
        public string Look { get; set; }
        public string UserID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyState { get; set; }
        public string UserRealName { get; set; }
        public string UserPhone { get; set; }
        public string List { get; set; }
        public string msg { get; set; }
        public string CompanyLicense { get; set; }
        public string CompanyQualification { get; set; }
        public string CompanyClimbCard { get; set; }
        public string CompanyWelderCard { get; set; }
        public string CompanyForkliftCard { get; set; }
        public string CompanyElectricianCard { get; set; }
        public string CompanySafeCard { get; set; }
        public string CompanyInsuranceCard { get; set; }
        public double EvalSatisfied = 0.0;
        public double EvalQuality = 0.0;
        public double EvalReachRate = 0.0;
        public double EvalAccident = 0.0;
        public double EvalManagement = 0.0;
    }

    /// <summary>
    /// 安装公司列表搜索
    /// </summary>
    public class VMCompanySeacher
    {
        public int NowPage { get; set; }
        public string CompanyName { get; set; }
        public CompanyState StatuString { get; set; }
    }
}