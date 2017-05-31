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
    /// 评价表
    /// </summary>
    [Table("Fc_Evaluate")]
    public class Fc_Evaluate
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        [Key()]
        public string EvaluateID { get; set; }
        /// <summary>
        /// 投标ID
        /// </summary>
        public string OfferID { get; set; }
        /// <summary>
        /// 客户满意度   
        /// </summary>
        public double EvalSatisfied { get; set; }
        /// <summary>
        /// 质量合格率
        /// </summary>
        public double EvalQuality { get; set; }
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
        public string EvalContent { get; set; }
        /// <summary>
        /// 评价时间
        /// </summary>
        public DateTime? EvalTime { get; set; }
        public string EvalRemark1 { get; set; }
        public string EvalRemark2 { get; set; }
        public string EvalRemark3 { get; set; }
    }
}
