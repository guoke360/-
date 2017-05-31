using Common;
using Resposity.Constaint;
using Resposity.Entities;
using Resposity.Enum;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Method
{
    /// <summary>
    /// 负责人：王清乐
    /// </summary>
    public class PersonalService : BaseResposity, IPersonal
    {

        public PersonalDM LoginUser(String UserName, String UserPassword)
        {
            if (db.UserInfo.Where(x => x.UserName.Equals(UserName)).Count() > 0)
            {
                PersonalDM user = new PersonalDM();
                var result = (from a in db.UserInfo
                              where a.UserName == UserName && a.UserPassword == UserPassword
                              select a).FirstOrDefault();
                if (String.IsNullOrEmpty(UserName))
                {
                    throw new ArgumentException("请输入用户名！");
                }
                if (String.IsNullOrEmpty(UserPassword))
                {
                    throw new ArgumentException("请输入密码！");
                }
                if (result != null)
                {
                    if (result.UserState == UserState.Able)
                    {
                        user.UserID = result.UserID;
                        user.UserRealName = result.UserRealName;
                        user.UserName = result.UserName;
                        user.UserState = result.UserState;
                        user.UserLevel = result.UserLevel;
                        user.UserRole = result.UserCategory;
                        return user;
                    }
                    else
                    {
                        throw new ArgumentException("该用户尚未启用！");
                    }
                }
                else
                {
                    throw new ArgumentException("密码不正确！");
                }
            }
            else
            {
                throw new ArgumentException("用户名不正确！");
            }
        }

        public void Personal(String UserID, String OldPassword, String UserPassword, String SurePassword)
        {
            Helper pass = new Helper();
            if (String.IsNullOrEmpty(OldPassword))
            {
                throw new ArgumentException("请输入原密码！");
            }
            if (String.IsNullOrEmpty(UserPassword))
            {
                throw new ArgumentException("请输入新密码！");
            }
            if (UserPassword.Length < 6)
            {
                throw new ArgumentException("密码长度至少6位！");
            }
            if (String.IsNullOrEmpty(SurePassword))
            {
                throw new ArgumentException("请输入确定密码！");
            }
            if (SurePassword.Length < 6)
            {
                throw new ArgumentException("密码长度至少6位！");
            }
            if (SurePassword != UserPassword)
            {
                throw new ArgumentException("两次密码输入不一致！");
            }
            BD_UserInfo passwordcheck = db.UserInfo.Find(UserID);
            if (passwordcheck != null)
            {
                if (pass.md5(OldPassword) != passwordcheck.UserPassword)
                {
                    throw new ArgumentException("原密码错误！");
                }
                else
                {
                    passwordcheck.UserPassword = pass.md5(UserPassword);
                    db.UserInfo.Attach(passwordcheck);
                    db.Entry<BD_UserInfo>(passwordcheck).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                throw new ArgumentException("用户不存在！");
            }
        }
    }
}