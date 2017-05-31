using Resposity.Constaint;
using Resposity.Entities;
using Resposity.Enum;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Method
{
    /// <summary>
    /// 负责人：刘雨杰、栾康成
    /// </summary>
    public class ScheduleService : BaseResposity, ISchedule
    {
        public IList<ScheduleDM> ScheduleListss(String InsShelftype , String CompanyName, int? page = 0, int? count = 10)
        //安装进度列表查询：实现方法-以投标表为基础，对货架需求表和用户表进行多表连接查询
        {
            IQueryable<ScheduleDM> list = from Fc_Offer in db.Offer
                                          join item in db.UserInfo on Fc_Offer.UserID equals item.UserID
                                          join item1 in db.Install on Fc_Offer.InstallID equals item1.InstallID
                                          where Fc_Offer.OfferState == OfferState.Yes
                                          select new ScheduleDM
                                          {
                                              OfferID = Fc_Offer.OfferID,
                                              InsShelftype = item1.InsShelftype,
                                              InsTonnage = item1.InsTonnage,
                                              InsMoney = item1.InsMoney,
                                              Insplace = item1.Insplace,
                                              InsStartDate = item1.InsStartDate,
                                              StepStartTimes= item1.InsStartDate.ToString(),
                                              InsCycle = item1.InsCycle,
                                              InsHeight = item1.InsHeight,
                                              InsBeamHgh = item1.InsBeamHgh,
                                              InsAtticLayer = item1.InsAtticLayer,
                                              InsForkExtension = item1.InsForkExtension,
                                              OfferMoney = Fc_Offer.OfferMoney,
                                              CompanyName = item.CompanyName
                                          };
            if (CompanyName != "")
            {
                list = list.Where(x => x.CompanyName.Contains(CompanyName));
            }
            if (InsShelftype != "")
            {
                list = list.Where(x => x.InsShelftype.Contains(InsShelftype));
            }
            return list.OrderByDescending(x=>x.OfferID).Skip(page.Value * count.Value).Take(count.Value).ToList();

        }
        public int ScheduleLists(String CompanyName, String InsShelftype)
        {
            IQueryable<ScheduleDM> list = from Fc_Offer in db.Offer
                                          join item in db.UserInfo on Fc_Offer.UserID equals item.UserID
                                          join item1 in db.Install on Fc_Offer.InstallID equals item1.InstallID
                                          where Fc_Offer.OfferState == OfferState.Yes
                                          select new ScheduleDM
                                          {
                                              OfferID = Fc_Offer.OfferID,//编号
                                              InsShelftype = item1.InsShelftype,//货架类型
                                              InsTonnage = item1.InsTonnage,//设计吨位
                                              InsMoney = item1.InsMoney,//安装价格
                                              Insplace = item1.Insplace,//安装地点
                                              InsStartDate = item1.InsStartDate,//开工日期
                                              InsCycle = item1.InsCycle,//安装周期
                                              InsHeight = item1.InsHeight,//立柱高度
                                              InsBeamHgh = item1.InsBeamHgh,//横梁层高
                                              InsAtticLayer = item1.InsAtticLayer,//阁楼层数
                                              InsForkExtension = item1.InsForkExtension,//货叉伸拉
                                              OfferMoney = Fc_Offer.OfferMoney,//报价
                                              CompanyName = item.CompanyName//公司名称
                                          };
            if (CompanyName != "")
            {
                list = list.Where(x => x.CompanyName.Contains(CompanyName));
            }
            if (InsShelftype != "")
            {
                list = list.Where(x => x.InsShelftype.Contains(InsShelftype));
            }
            return list.Count();
        }
        public IList<ScheduleDM> ScheduleDetial(String OfferID)
        {
            IQueryable<ScheduleDM> list = from Fc_Step in db.Step
                                          join item in db.Offer on OfferID equals item.OfferID
                                          join item1 in db.Install on item.InstallID equals item1.InstallID
                                          where Fc_Step.OfferID == OfferID
                                          orderby Fc_Step.StepStartTime ascending
                                          select new ScheduleDM
                                          {
                                              InsProjectState= item1.InsProjectState,
                                              StepID = Fc_Step.StepID,
                                              OfferID = Fc_Step.OfferID,
                                              StepName = Fc_Step.StepName,
                                              StepStartTime = Fc_Step.StepStartTime,
                                              StepEndTime = Fc_Step.StepEndTime,
                                              Tool = Fc_Step.Tool,
                                              StepLiable = Fc_Step.StepLiable,
                                              StepArtificial = Fc_Step.StepArtificial,
                                              people=Fc_Step.StepArtificial
                                          };
            

            return list.ToList();
        }

        public void Evaluate(double EvalSatisfied, double EvalQuality, double EvalReachRate, double EvalAccident, double EvalManagement, String OfferID = "", String EvalContent = "")
        {
            Fc_Evaluate info = new Fc_Evaluate();
            var list1 = db.Offer.Find(OfferID);
            var list2 = db.Install.Find(list1.InstallID);
            if (list2.InsProjectState != InsProjectState.Completed)
            {
                if (list2.InsProjectState == InsProjectState.Finished)
                {
                    throw new ArgumentException("该公司工程情况已评价，欢迎继续合作!");
                }
                throw new ArgumentException("工程善未完成暂时无法评价!");
            }
            if (String.IsNullOrEmpty(EvalContent))
            {
                throw new ArgumentException("请输入评价内容！");
            }
            else
            {
                info.EvaluateID = DateTime.Now.Ticks.ToString();
                info.OfferID = OfferID;
                info.EvalTime = DateTime.Now;
                info.EvalSatisfied = EvalSatisfied;
                info.EvalQuality = EvalQuality;
                info.EvalReachRate = EvalReachRate;
                info.EvalAccident = EvalAccident;
                info.EvalManagement = EvalManagement;
                info.EvalContent = EvalContent;
                list1.OfferGet = OfferGetState.Yes;
                list2.InsProjectState = InsProjectState.Finished;
            }
            db.Evaluate.Add(info);
            db.Offer.Attach(list1);
            db.Entry<Fc_Offer>(list1).State = System.Data.Entity.EntityState.Modified;
            db.Install.Add(list2);
            db.Entry<Fc_Install>(list2).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
