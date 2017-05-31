using Resposity.Entities;
using Resposity.Enum;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Service.Method.ScheduleServiceApp;

namespace Service.Interface
{
    /// <summary>
    /// 负责人：孙铭丹
    /// </summary>
    public interface IScheduleApp
    {
        /// <summary>
        /// 投标安装开始
        /// </summary>
        /// <param name="OfferID">投标ID</param>
        /// <returns></returns>
        Fc_Offer OfferAdd(String OfferID);

        /// <summary>
        /// 周期天数
        /// </summary>
        /// <param name="OfferID">中标ID</param>
        /// <param name="StepDate">工序日期</param>
        /// <returns></returns>
        Fc_Step ScheduleProcess(String OfferID, int StepDate);


        /// <summary>
        /// 安装进度列表
        /// </summary>
        /// <param name="CompanyName">用户ID</param>
        /// <param name="OfferID">中标ID</param>
        /// <param name="page">页数</param>
        /// <param name="count">总数</param>
        /// <returns></returns>
        IList<Method.ScheduleServiceApp.ScheduleDMApp> ScheduleList(String UserID, String OfferID, int StepDate, int? page = 0, int? count = 10);

        /// <summary>
        /// 自动添加工序
        /// </summary>
        /// <param name="OfferID">中标ID</param>
        /// <param name="StepID">工序ID</param>
        /// <param name="StepDate">工序日期</param>
        /// <returns></returns>
        Fc_Step ScheduleAddQ(String OfferID,int StepDate,StepState StepState );

        /// <summary>
        /// 添加工序
        /// </summary>
        /// <param name="OfferID">中标ID</param>
        /// <param name="StepName">工序名</param>
        /// <param name="Tool">工具</param>
        /// <param name="StepLiable">负责人</param>
        /// <param name="StepArtificial">人工</param>
        /// <returns></returns>
        Method.ScheduleServiceApp.ScheduleDMApp ScheduleAdd(String OfferID, String StepID, DateTime? StepStartTime, String StepName, String Tool, String StepLiable, String StepArtificial, int StepDate);

        /// <summary>
        /// 删除工序
        /// </summary>
        /// <param name="StepID">工序ID</param>
        /// <returns></returns>
        Method.ScheduleServiceApp.ScheduleDMApp ScheduleDelete(String StepID);

        /// <summary>
        /// 完成工序
        /// </summary>
        /// <param name="StepID">工序ID</param>
        /// <returns></returns>
        Method.ScheduleServiceApp.ScheduleDMApp ScheduleFinish(String StepID);
    }
}
