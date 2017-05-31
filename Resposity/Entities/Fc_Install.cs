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
    /// 货架需求表
    /// </summary>
    [Table("Fc_Install")]
    public class Fc_Install
    {
        /// <summary>
        /// 货架需求ID
        /// </summary>
        [Key()]
        public string InstallID { get; set; }
        /// <summary>
        /// 发布者ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 货架类型
        /// </summary>
        public string InsShelftype { get; set; }
        /// <summary>
        /// 设计吨位
        /// </summary>
        public string InsTonnage { get; set; }
        /// <summary>
        /// 吨位单位
        /// </summary>
        public string InsTonUnit { get; set; }
        /// <summary>
        /// 安装地点
        /// </summary>
        public string Insplace { get; set; }
        /// <summary>
        /// 开工日期
        /// </summary>
        public DateTime ?InsStartDate { get; set; }
        /// <summary>
        /// 安装周期
        /// </summary>
        public string InsCycle { get; set; }
        /// <summary>
        /// 周期单位
        /// </summary>
        public string InsCycleUnit { get; set; }
        /// <summary>
        /// 立柱高度
        /// </summary>
        public string InsHeight { get; set; }
        /// <summary>
        /// 高度单位
        /// </summary>
        public string InsHghUnit { get; set; }
        /// <summary>
        /// 横梁层高
        /// </summary>
        public string InsBeamHgh { get; set; }
        /// <summary>
        /// 层高单位
        /// </summary>
        public string InsStyHghUnit { get; set; }
        /// <summary>
        /// 阁楼层数
        /// </summary>
        public string InsAtticLayer { get; set; }
        /// <summary>
        /// 货叉伸拉
        /// </summary>
        public string InsForkExtension { get; set; }
        /// <summary>
        /// 伸拉单位
        /// </summary>
        public string InsStretchCom { get; set; }
        /// <summary>
        /// 安装价格
        /// </summary>
        public string InsMoney { get; set; }
        /// <summary>
        /// 价格单位
        /// </summary>
        public string InsMoneyCom { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string InsName { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string InsPhone { get; set; }
        /// <summary>
        /// 工程完成性
        /// </summary>
        public InsProjectState InsProjectState { get; set; }

        /// <summary>
        /// 需求发布日期
        /// </summary>
        public DateTime InstallSendDate { get; set; }

        public string InsRemark { get; set; }
        public string InsRemark1 { get; set; }
        public string InsRemark2 { get; set; }
        public string InsRemark3 { get; set; }
    }
}
