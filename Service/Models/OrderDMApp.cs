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
    public class OrderDMApp
    {
        /// <summary>
        /// 货架需求ID
        /// </summary>
        public string InstallID { get; set; }
        /// <summary>
        /// 开工日期
        /// </summary>
        public DateTime? InsStartDate { get; set; }
        /// <summary>
        /// 安装周期
        /// </summary>
        public string InsCycle { get; set; }
        /// <summary>
        /// 周期单位
        /// </summary>
        public string InsCycleUnit { get; set; }
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
        /// 订单状态
        /// </summary>
        public int OrderState { get; set; }
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
        /// 联系人
        /// </summary>
        public string InsName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string InsPhone { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string InsRemark { get; set; }
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime? OfferDateEnd { get; set; }
        /// <summary>
        /// 工程完成性
        /// </summary>
        public InsProjectState InsProjectState { get; set; }

        /// <summary>
        /// 需求发布日期
        /// </summary>
        public DateTime InstallSendDate { get; set; }

        /// <summary>
        /// 投标状态枚举
        /// </summary>
        public OfferState OfferState { get; set; }

        /// <summary>
        /// 验收状态
        /// </summary>
        public OfferGetState OfferGet { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        public String InsMoneyCom { get; set; }

        public String msg { get; set; }
    }
    
}
