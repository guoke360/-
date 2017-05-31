using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    /// <summary>
    /// 负责人：刘雨杰、栾康成
    /// </summary>
  public  interface ISchedule
    {
        /// <summary>
        /// 安装进度列表
        /// </summary>
        /// <param name="CompanyName">公司名称(用于查询)</param>
        /// <param name="InsShelftype">货架类型(用于查询)</param>
        /// <param name="page">页数(用于分页)</param>
        /// <param name="count">总数(用于分页)</param>
        /// <returns></returns>
        IList<ScheduleDM>ScheduleListss(String CompanyName,String InsShelftype, int? page = 0, int? count = 10);
        /// <summary>
        /// 安装进度列表分页
        /// </summary>
        /// <param name="CompanyName">公司名称(用于查询)</param>
        /// <param name="InsShelftype">货架类型(用于查询)</param>
        /// <returns></returns>
        int ScheduleLists(String CompanyName, String InsShelftype);
        /// <summary>
        /// 进度详细查询(12.13第一稿)
        /// </summary>
        /// <param name="OfferID">工程详细id(用来确定数据)</param>
        /// <returns></returns>
        IList<ScheduleDM> ScheduleDetial(String OfferID);

        void Evaluate(double EvalSatisfied , double EvalQuality , double EvalReachRate , double EvalAccident , double EvalManagement , String OfferID, String EvalContent = "");
        

    }
}
