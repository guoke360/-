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
    public class ScheduleServiceApp : BaseResposity, IScheduleApp
    {
        public class ScheduleDMApp
        {

            public string StepID { get; set; }
            public string OfferID { get; set; }
            public string StepName { get; set; }
            public DateTime? StepStartTime { get; set; }
            public DateTime? StepEndTime { get; set; }
            public string Tool { get; set; }
            public string StepLiable { get; set; }
            public string StepArtificial { get; set; }
            public StepState StepState { get; set; }
            public int msg { get; set; }
        }

        public Fc_Offer OfferAdd(String OfferID)
        {
            Fc_Offer add = new Fc_Offer();
            var adds = db.Step.Where(x => x.OfferID == OfferID).FirstOrDefault();
            add.OfferDateStart = DateTime.Now;
            db.SaveChanges();
            db.Entry<Fc_Offer>(add).State = System.Data.Entity.EntityState.Modified;
            return add;

        }

        public Fc_Step ScheduleProcess(String OfferID, int StepDate)
        {
            var process = db.Step.Where(x => x.StepDate == StepDate).Where(z => z.OfferID.Equals(OfferID)).FirstOrDefault();
            return process;
        }

        public IList<ScheduleDMApp> ScheduleList(String UserID, String OfferID, int StepDate, int? page = 0, int? count = 10)
        {

            IQueryable<ScheduleDMApp> list = from Fc_Step in db.Step
                                             join item in db.Offer on Fc_Step.OfferID equals item.OfferID
                                             join item1 in db.UserInfo on item.UserID equals item1.UserID
                                             where item1.UserID == UserID
                                             where Fc_Step.StepDate == StepDate
                                             where item.OfferID == OfferID
                                             select new ScheduleDMApp
                                             {
                                                 StepName = Fc_Step.StepName,
                                                 Tool = Fc_Step.Tool,
                                                 StepLiable = Fc_Step.StepLiable,
                                                 StepArtificial = Fc_Step.StepArtificial,
                                             };

            return list.OrderBy(x => x.OfferID).Skip(page.Value * count.Value).Take(count.Value).ToList();
        }

        public Fc_Step ScheduleAddQ(String OfferID, int StepDate, StepState StepState)
        {
            var adds = db.Step.Where(x => x.StepDate == StepDate).Where(y => y.StepDate.Equals(StepDate)).Where(z => z.OfferID.Equals(OfferID)).FirstOrDefault();
            return adds;

        }

        public ScheduleDMApp ScheduleAdd(String OfferID, String StepID, DateTime? StepStartTime, String StepName, String Tool, String StepLiable, String StepArtificial, int StepDate)
        {
            ScheduleDMApp schedules = new ScheduleDMApp();
            if (String.IsNullOrEmpty(StepName))
            {
                schedules.msg = 0;//请输入工序名
            }
            if (String.IsNullOrEmpty(Tool))
            {
                schedules.msg = 1;//请输入工具
            }
            if (String.IsNullOrEmpty(StepLiable))
            {
                schedules.msg = 2;//请输入负责人
            }
            if (String.IsNullOrEmpty(StepArtificial))
            {
                schedules.msg = 3;//请输入人工
            }
            else
            {
                Fc_Step schedule = new Fc_Step();
                schedule.StepName = StepName;
                schedule.Tool = Tool;
                schedule.StepLiable = StepLiable;
                schedule.StepArtificial = StepArtificial;
                schedule.StepState = StepState.No;
                schedule.StepDate = StepDate;
                if (String.IsNullOrEmpty(StepID))
                {
                    schedule.StepID = DateTime.Now.ToString("yyyyMMddHHmmssffffff");
                    schedule.StepStartTime = DateTime.Now;
                }
                else
                {
                    schedule.StepID = StepID;
                    schedule.StepStartTime = StepStartTime;
                }
                schedule.OfferID = OfferID;
                db.Step.Add(schedule);
                db.SaveChanges();
                db.Entry<Fc_Step>(schedule).State = System.Data.Entity.EntityState.Modified;
                schedules.msg = 4;//添加成功
            }
            return schedules;
        }

        public ScheduleDMApp ScheduleDelete(String StepID)
        {
            ScheduleDMApp schedules = new ScheduleDMApp();
            var schedule = db.Step.Where(x => x.StepID == StepID).FirstOrDefault();
            if (!String.IsNullOrEmpty(schedules.ToString()))
            {
                db.Step.Remove(schedule);
                db.SaveChanges();
                schedules.msg = 0;//删除成功
            }
            else
            {
                schedules.msg = 1;//删除失败
            }
            return schedules;
        }

        public ScheduleDMApp ScheduleFinish(String StepID)
        {
            ScheduleDMApp schedules = new ScheduleDMApp();
            var schedule = db.Step.Where(x => x.StepID == StepID).FirstOrDefault();
            schedule.StepState = StepState.Yes;
            schedule.StepEndTime = DateTime.Now;
            db.SaveChanges();
            schedules.msg = 0;//操作成功
            db.Entry<Fc_Step>(schedule).State = System.Data.Entity.EntityState.Modified;
            return schedules;
        }
    }
}
