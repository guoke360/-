using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShelfWeb.Models
{
    public class VMRequire
    {
        public int No { get; set; }
        /// <summary>
        /// 货架需求ID
        /// </summary>
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
        /// 投标ID
        /// </summary>
        public string OfferID { get; set; }
        /// <summary>
        /// 投标价格
        /// </summary>
        public string OfferMoney { get; set; }
        /// <summary>
        /// 投标状态
        /// </summary>
        public OfferState OfferState { get; set; }
        public string OfferStates { get; set; }
        public string msg { get; set; }
        public string offerlist { get; set; }
        public string CompanyName { get; set; }
        public int AllPage { get; set; }
        public int NowPage { get; set; }
        public int count { get; set; }
        public int NewPage { get; set; }
        public string InsRemark { get; set; }
        public IList<VMRequire> OfferList { get; set; }
        public string url { get; set; }

    }

    public class VMRequireList
    {
        public String Result { get; set; }
        public int AllPage { get; set; }
        public int NowPage { get; set; }
        public int count { get; set; }
        public int NewPage { get; set; }
        public String list { get; set; }
        public IList<VMRequirelist> Installlist { get; set; }
        public String msg { get; set; }
        public String url { get; set; }

        public String InstallID { get; set; }
        public String InsShelftypeName { get; set; }
        public String InsProjectState { get; set; }
    }

    public class VMEvaluate
    {
        public double EvalSatisfied { get; set; }
        public double EvalQuality { get; set; }
        public double EvalReachRate { get; set; }
        public double EvalAccident { get; set; }
        public double EvalManagement { get; set; }
        public String EvalContent { get; set; }
    }

    public class VMRequireAdd
    {
        public String InsShelftype { get; set; }
        public String InsTonnage { get; set; }
        public String InsTonUnit { get; set; }
        public String Insplace { get; set; }
        public DateTime? InsStartDate { get; set; }
        public String InsCycle { get; set; }
        public String InsCycleUnit { get; set; }
        public String InsHeight { get; set; }
        public String InsHghUnit { get; set; }
        public String InsBeamHgh { get; set; }
        public String InsStyHghUnit { get; set; }
        public String InsAtticLayer { get; set; }
        public String InsForkExtension { get; set; }
        public String InsStretchCom { get; set; }
        public String InsMoney { get; set; }
        public String InsMoneyCom { get; set; }
        public String InsName { get; set; }
        public String InsPhone { get; set; }
        public String Remark { get; set; }
    }

    public class VMRequirelist
    {
        public int No { get; set; }
        public String Look { get; set; }
        public String Pass { get; set; }
        public String InstallID { get; set; }
        public String InsShelftype { get; set; }
        public String InsTonnage { get; set; }
        public String InsTonUnit { get; set; }
        public String Insplace { get; set; }
        public String InsStartDate { get; set; }
        public String InsCycle { get; set; }
        public String InsCycleUnit { get; set; }
        public String InsHeight { get; set; }
        public String InsHghUnit { get; set; }
        public String InsBeamHgh { get; set; }
        public String InsStyHghUnit { get; set; }
        public String InsAtticLayer { get; set; }
        public String InsForkExtension { get; set; }
        public String InsStretchCom { get; set; }
        public String InsMoney { get; set; }
        public String InsMoneyCom { get; set; }
        public String InsState { get; set; }
        public String InsProjectState { get; set; }
        public bool State { get; set; }
        public bool Statef { get; set; }
    }
}