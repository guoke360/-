using Service.Models;
using ShelfWeb.Models;
using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelfWeb.ViewMapper
{
    /// <summary>
    /// 视图模型转换器负责人：王莉雯、孙铭丹
    /// </summary>
    public class RequireMapper
    {
        public static IList<VMRequire> Offerlist(IList<RequireDM> offerlist)
        {
            IList<VMRequire> item = new List<VMRequire>();
            int i = 1;
            int No;
            foreach (var aa in offerlist)
            {
                No = i++;
                item.Add(Offer(aa, No));
            }
            return item;
        }

        public static VMRequire Offer(RequireDM Offers, int No)
        {
            VMRequire item1 = new VMRequire();
            item1.No = No;
            item1.OfferID = Offers.OfferID;
            item1.InstallID = Offers.InstallID;
            item1.CompanyName = Offers.CompanyName;
            item1.InsName = Offers.InsName;
            item1.InsPhone = Offers.InsPhone;
            item1.OfferMoney = Offers.OfferMoney;
            switch (Offers.OfferState)
            {
                case OfferState.Yes:
                    item1.OfferStates = "是";
                    break;
                case OfferState.No:
                    item1.OfferStates = "否";
                    break;
                case OfferState.None:
                    item1.OfferStates = "否";
                    break;
            }
            return item1;
        }

        public static IList<VMRequirelist> RequireList(IList<RequireDM> requireList, UrlHelper Url)
        {
            IList<VMRequirelist> item = new List<VMRequirelist>();
            int i = 1;
            int No;
            foreach (var aa in requireList)
            {
                No = i++;
                item.Add(RequireListInfo(aa, No, Url));
            }
            return item;
        }

        public static VMRequirelist RequireListInfo(RequireDM requireListInfos,int No,UrlHelper Url)
        {
            VMRequirelist item1 = new VMRequirelist();
            item1.No = No;
            item1.InstallID=requireListInfos.InstallID;
            item1.InsShelftype = requireListInfos.InsShelftype;
            item1.InsTonnage = requireListInfos.InsTonnage + requireListInfos.InsTonUnit;
            item1.InsMoney = requireListInfos.InsMoney + requireListInfos.InsMoneyCom;
            item1.Insplace = requireListInfos.Insplace;
            item1.InsStartDate = Convert.ToDateTime(requireListInfos.InsStartDate).ToString("yyyy-MM-dd");
            item1.InsCycle = requireListInfos.InsCycle+ requireListInfos.InsCycleUnit;
            item1.InsHeight = requireListInfos.InsHeight+ requireListInfos.InsHghUnit;
            item1.InsBeamHgh = requireListInfos.InsBeamHgh + requireListInfos.InsStyHghUnit;
            item1.InsAtticLayer = requireListInfos.InsAtticLayer + "层";
            item1.InsForkExtension = requireListInfos.InsForkExtension + requireListInfos.InsStretchCom;
            item1.Pass = Url.Action("RequireAuditing", "RequireMag", new { id = item1.InstallID });
            item1.Look = Url.Action("RequireBidding", "RequireMag", new { id = item1.InstallID });
            //item1.Look = "RequireBidding?InstallID=" + item1.InstallID+"";
            switch (requireListInfos.OfferState)
            {
                case OfferState.Yes:
                    item1.InsState = "有";
                    break;
                case OfferState.None:
                    item1.InsState = "无";
                    break;
            }
            switch (requireListInfos.InsProjectState)
            {
                case InsProjectState.NoAudited:
                    item1.InsProjectState = "未审核";
                    item1.State = true;
                    item1.Statef = false;
                    break;
                case InsProjectState.Audited:
                    item1.InsProjectState = "审核通过";
                    item1.Statef = true;
                    item1.State = false;
                    break;
                case InsProjectState.AuditedFail:
                    item1.InsProjectState = "审核失败";
                    item1.Statef = true;
                    item1.State = false;
                    break;
                case InsProjectState.NoInstalled:
                    item1.InsProjectState = "待安装";
                    item1.Statef = true;
                    item1.State = false;
                    break;
                case InsProjectState.Installed:
                    item1.InsProjectState = "在安装";
                    item1.Statef = true;
                    item1.State = false;
                    break;
                case InsProjectState.Completed:
                    item1.InsProjectState = "已完成";
                    item1.Statef = true;
                    item1.State = false;
                    break;
                case InsProjectState.Finished:
                    item1.InsProjectState = "已完结";
                    item1.Statef = true;
                    item1.State = false;
                    break;
            }
            return item1;
        }
    }
}