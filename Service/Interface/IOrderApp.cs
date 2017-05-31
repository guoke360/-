using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Service.Method.OrderServiceApp;

namespace Service.Interface
{
    /// <summary>
    /// 负责人：姜玮佶
    /// </summary>
    public interface IOrderApp
    {
        /// <summary>
        /// App抢单列表
        /// </summary>
        /// <param name="Page">总共几页</param>
        /// <param name="Count">一页显示数量</param>
        /// <returns></returns>
        IList<RobOrderItem> RobOrderList(String UserID, int? Count=10, int? Page = 0);

        /// <summary>
        /// App抢单详细
        /// </summary>
        /// <param name="InstallID">需求ID</param>
        /// <returns></returns>
        OrderDMApp RobOrderInfo(String InstallID);

        /// <summary>
        /// App抢单提交
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="InstallID">需求ID</param>
        /// <param name="OfferMoney">价格</param>
        OrderDMApp RobOrderSubmit(String UserID, String InstallID, String OfferMoney, String OfferWeight);

        /// <summary>
        /// App订单列表
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        IList<MyOrderItem> Order(String UserID, int? Count = 10, int? Page = 0);

        /// <summary>
        /// App订单详细
        /// </summary>
        /// <param name="InstallID">需求ID</param>
        /// <returns></returns>
        OrderDMApp OrderInfo(String InstallID);

        /// <summary>
        /// App评价内容
        /// </summary>
        /// <param name="InstallID">需求ID</param>
        /// <returns></returns>
        EvaluateDMApp Evaluate(String InstallID);
    }
}
