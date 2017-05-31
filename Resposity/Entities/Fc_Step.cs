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
    /// 投标工序表
    /// </summary>
    [Table("Fc_Step")]
    public class Fc_Step
    {
        /// <summary>
        /// 工序ID
        /// </summary>
        [Key()]
        public string StepID { get; set; }
        /// <summary>
        /// 投标ID
        /// </summary>
        public string OfferID { get; set; }
        /// <summary>
        /// 工序名
        /// </summary>
        public string StepName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StepStartTime { get; set; }
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime? StepEndTime { get; set; }
        /// <summary>
        /// 工具
        /// </summary>
        public string Tool { get; set; }
        /// <summary>
        /// 工序责任人
        /// </summary>
        public string StepLiable { get; set; }
        /// <summary>
        /// 人工
        /// </summary>
        public string StepArtificial { get; set; }
        public StepState StepState { get; set; }
        public int StepDate { get; set; }
        public string ProgressRemark1 { get; set; }
        public string ProgressRemark2 { get; set; }
        public string ProgressRemark3 { get; set; }
    }
}
