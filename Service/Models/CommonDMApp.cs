using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    /// <summary>
    /// 负责人：姜玮佶
    /// </summary>
    public class CommonDMApp
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserImage { get; set; }

        /// <summary>
        /// 用户公司
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string UserRealName { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// 用户职位
        /// </summary>
        public string UserPosition { get; set; }

        /// <summary>
        /// 用户电话
        /// </summary>
        public string UserPhone { get; set; }

        /// <summary>
        /// 资质认证
        /// </summary>
        public CompanyState CompanyState { get; set; }
    }

    public class EvaluateDMApp
    {
        /// <summary>
        /// 客户满意度
        /// </summary>
        public double EvalSatisfied { get; set; }

        /// <summary>
        /// 质量合格率
        /// </summary>
        public double EvalQuality    { get; set; }

        /// <summary>
        /// 交易达成率
        /// </summary>
        public double EvalReachRate { get; set; }

        /// <summary>
        /// 无安全事故
        /// </summary>
        public double EvalAccident { get; set; }

        /// <summary>
        /// 现场管理规范
        /// </summary>
        public double EvalManagement { get; set; }

        /// <summary>
        /// 评价内容
        /// </summary>
        public string  EvalContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int msg { get; set; }
    }

    public class CompanyDMApp
    {
        /// <summary>
        /// 安装资质
        /// </summary>
        public string CompanyQualification { get; set; }
        /// <summary>
        /// 登高证
        /// </summary>
        public string CompanyClimbCard { get; set; }
        /// <summary>
        /// 焊工证
        /// </summary>
        public string CompanyWelderCard { get; set; }
        /// <summary>
        /// 叉车证
        /// </summary>
        public string CompanyForkliftCard { get; set; }
        /// <summary>
        /// 电工证
        /// </summary>
        public string CompanyElectricianCard { get; set; }
        /// <summary>
        /// 安全员证
        /// </summary>
        public string CompanySafeCard { get; set; }
        /// <summary>
        /// 保险证明
        /// </summary>
        public string CompanyInsuranceCard { get; set; }
        /// <summary>
        /// 营业执照
        /// </summary>
        public string CompanyLicense { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int msg { get; set; }
    }
}
