using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Service;
using ShelfWeb.Filter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ShelfWeb.Ashx
{
    /// <summary>
    /// UploadPicture 的摘要说明
    /// </summary>
    public class UploadPicture : BaseResposity, IHttpHandler
    {
        int Code;

        public String InputStream { get; set; }

        public String OutStream { get; set; }

        public enum PicType
        {
            UserImage,
            CompanyQualification,
            CompanyClimbCard,
            CompanyWelderCard,
            CompanyForkliftCard,
            CompanyElectricianCard,
            CompanySafeCard,
            CompanyInsuranceCard,
            CompanyLicense,
        }

        public void ProcessRequest(HttpContext context)
        {
            #region 进参数
            StreamReader sr = new StreamReader(context.Request.InputStream);
            InputStream = sr.ReadToEnd();
            #endregion
            PicType pictype = JsonConvert.DeserializeObject<PicType>(context.Request.Params[0]);
            string UserID = JsonConvert.DeserializeObject<string>(context.Request.Params[1]);
            if (context.Request.Files.Count > 0)
            {
                var file = context.Request.Files[0];
                string uploadPath = "/Image/" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "/";
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(context.Server.MapPath(uploadPath));
                }
                string name = DateTime.Now.ToString("yyyyMMddHHmmssff") + ".png";
                string filepath = context.Server.MapPath(uploadPath) + name;
                file.SaveAs(filepath);

                SaveInDatabase(uploadPath + name, pictype, UserID);
            }
            OutStream = JsonConvert.SerializeObject(Code);
            context.Response.Write(OutStream);
        }
        private void SaveInDatabase(string uploadPath, PicType type,String UserID)
        {
            try
            {
                var item = (from user in db.UserInfo
                            where user.UserID == UserID
                            select user).FirstOrDefault();
                if (item == null)
                {
                    Code = 0;//操作失败
                }
                else
                {
                    switch (type)
                    {
                        case PicType.UserImage:
                            item.UserImage = uploadPath;
                            break;
                        case PicType.CompanyClimbCard:
                            item.CompanyClimbCard = uploadPath;
                            break;
                        case PicType.CompanyElectricianCard:
                            item.CompanyElectricianCard = uploadPath;
                            break;
                        case PicType.CompanyForkliftCard:
                            item.CompanyForkliftCard = uploadPath;
                            break;
                        case PicType.CompanyInsuranceCard:
                            item.CompanyInsuranceCard = uploadPath;
                            break;
                        case PicType.CompanyLicense:
                            item.CompanyLicense = uploadPath;
                            break;
                        case PicType.CompanyQualification:
                            item.CompanyQualification = uploadPath;
                            break;
                        case PicType.CompanySafeCard:
                            item.CompanySafeCard = uploadPath;
                            break;
                        case PicType.CompanyWelderCard:
                            item.CompanyWelderCard = uploadPath;
                            break;
                        default:
                            Code = 0;
                            break;
                    }
                    db.UserInfo.Attach(item);
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Code = 1;
                }
            }
            catch (Exception e)
            {
                Code = 0;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}