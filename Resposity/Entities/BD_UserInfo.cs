using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resposity.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("BD_UserInfo")]
    public class BD_UserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key()]
        public string UserID { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string UserPhone { get; set; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string UserRealName { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public UserState UserState { get; set; }
        /// <summary>
        /// 用户权限类别
        /// </summary>
        public UserRole UserCategory { get; set; }
        /// <summary>
        /// 用户权限级别
        /// </summary>
        public string UserLevel { get; set; }
        /// <summary>
        /// 用户公司职位
        /// </summary>
        public string UserPosition { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string UserEmail { get; set; }
        /// <summary>
        /// 用户注册时间
        /// </summary>
        public DateTime  UserDate { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string UserImage { get; set; }
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
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 认证状态
        /// </summary>
        public CompanyState CompanyState { get; set; }
        /// <summary>
        /// 营业执照
        /// </summary>
        public string CompanyLicense { get; set; }
        public string UserRemark1 { get; set; }
        public string UserRemark2 { get; set; }
        public string UserRemark3 { get; set; }
    }
}
