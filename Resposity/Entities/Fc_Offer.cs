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
    /// 投标表
    /// </summary>
    [Table("Fc_Offer")]
    public class Fc_Offer
    {
        /// <summary>
        /// 投标ID
        /// </summary>
        [Key()]
        public string OfferID { get; set; }
        /// <summary>
        /// 货架需求ID  
        /// </summary>
        public string InstallID { get; set; }
        /// <summary>
        /// 投标者ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 投标价格
        /// </summary>
        public string OfferMoney { get; set; }
        /// <summary>
        /// 投标时间    
        /// </summary>
        public DateTime? OfferTime { get; set; }
        /// <summary>
        /// 投标状态
        /// </summary>
        public OfferState OfferState { get; set; }
        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? OfferDateStart { get; set; }
        /// <summary>
        /// 截至时间
        /// </summary>
        public DateTime? OfferDateEnd { get; set; }
        /// <summary>
        /// 是否验收
        /// </summary>
        public OfferGetState OfferGet { get; set; }
        public string OfferRemark1 { get; set; }
        public string OfferRemark2 { get; set; }
        public string OfferRemark3 { get; set; }
    }
}