using Resposity.Enum;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{ 
    /// <summary>
    /// 负责人：王莉雯、孙铭丹
    /// </summary>
    public interface IRequire
    {
        /// <summary>
        /// 安装需求列表
        /// </summary>
        /// <param name="InsShelftype">货架类型</param>
        /// <param name="page">分页</param>
        /// <param name="count">个数</param>
        /// <returns>返回数据列表</returns>
        IList<RequireDM> RequireList(String InsShelftype="",int? page = 0, int? count = 10);

        /// <summary>
        /// 安装需求列表分页
        /// </summary>
        /// <param name="InsShelftype">货架类型</param>
        /// <returns>返回总数</returns>
        int RequiresList(String InsShelftype="");

        /// <summary>
        /// 安装需求发布
        /// </summary>
        /// <param name="InsStartDate">开工日期</param>
        /// <param name="UserID">用户ID</param>
        /// <param name="InsShelftype">货架类型</param>
        /// <param name="InsTonnage">设计吨位</param>
        /// <param name="InsTonUnit">吨位单位</param>
        /// <param name="Insplace">安装地点</param>
        /// <param name="InsCycle">安装周期</param>
        /// <param name="InsCycleUnit">周期单位</param>
        /// <param name="InsHeight">立柱高度</param>
        /// <param name="InsHghUnit">高度单位</param>
        /// <param name="InsBeamHgh">横梁层高</param>
        /// <param name="InsStyHghUnit">层高单位</param>
        /// <param name="InsAtticLayer">阁楼层数</param>
        /// <param name="InsForkExtension">货叉伸拉</param>
        /// <param name="InsStretchCom">伸拉单位</param>
        /// <param name="InsMoney">安装价格</param>
        /// <param name="InsMoneyCom">价格单位</param>
        /// <param name="InsName">联系人</param>
        /// <param name="InsPhone">联系方式</param>
        /// <param name="Remark">备注</param>
        void RequireAdd(DateTime? InsStartDate, String UserID, String InsShelftype="", String InsTonnage = "", String InsTonUnit = "",String Insplace = "",  String InsCycle = "", String InsCycleUnit = "",String InsHeight = "",
            String InsHghUnit = "", String InsBeamHgh = "", String InsStyHghUnit = "", String InsAtticLayer = "", String InsForkExtension = "", String InsStretchCom = "", String InsMoney = "", String InsMoneyCom = "",
            String InsName = "", String InsPhone = "" , String InsRemark = "");
        
        /// <summary>
        /// 安装需求审核读取
        /// </summary>
        /// <param name="InstallID">货架安装ID</param>
        RequireDM RequireAuditing(String InstallID);

        /// <summary>
        /// 安装需求审核操作
        /// </summary>
        /// <param name="InstallID">货架安装ID</param>
        bool RequireAudited(String InstallID, InsProjectState InsProjectState);
        
        /// <summary>
        /// 安装需求中标列表
        /// </summary>
        /// /// <param name="InstallID">货架安装ID</param>
        /// <param name="page">分页</param>
        /// <param name="count">个数</param>
        /// <returns>返回数据列表</returns>
        IList<RequireDM> RequireBidding(String InstallID,int? page = 0, int? count = 10);

        /// <summary>
        /// 安装需求中标分页
        /// </summary>
        /// <param name="InstallID">货架安装ID</param>
        /// <returns>返回分页</returns>
        int RequiresBidding(String InstallID);

        /// <summary>
        /// 安装需求审核中标
        /// </summary>
        /// <param name="OfferID">投标ID</param>
        /// <param name="OfferState">投标状态</param>
        bool RequireBiddingOffer(String OfferID, OfferState OfferState);
    }
}
