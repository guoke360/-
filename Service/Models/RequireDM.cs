using Resposity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    /// <summary>
    /// 负责人：王莉雯、孙铭丹
    /// </summary>
    public class RequireDM
    {
        public string InstallID { get; set; }
        public string UserID { get; set; }
        public string InsShelftype { get; set; }
        public string InsTonnage { get; set; }
        public string InsTonUnit { get; set; }
        public string Insplace { get; set; }
        public DateTime? InsStartDate { get; set; }
        public string InsCycle { get; set; }
        public string InsCycleUnit { get; set; }
        public string InsHeight { get; set; }
        public string InsHghUnit { get; set; }
        public string InsBeamHgh { get; set; }
        public string InsStyHghUnit { get; set; }
        public string InsAtticLayer { get; set; }
        public string InsForkExtension { get; set; }
        public string InsStretchCom { get; set; }
        public string InsMoney { get; set; }
        public string InsMoneyCom { get; set; }
        public string InsName { get; set; }
        public string InsPhone { get; set; }
        public InsProjectState InsProjectState { get; set; }
        public string InsRemark { get; set; }
        public string InsNO { get; set; }

        public string OfferID { get; set; }
        public string OfferMoney { get; set; }
        public DateTime? OfferTime { get; set; }
        public OfferState OfferState { get; set; }
        public DateTime? OfferDateStart { get; set; }
        public DateTime? OfferDateEnd { get; set; }
        public bool OfferGet { get; set; }

        public string CompanyName { get; set; }

    }
}
