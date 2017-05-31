using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Helper
    {
        public string md5(string Password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bt = Encoding.Default.GetBytes(Password);
            byte[] resualt = md5.ComputeHash(bt);
            string pwds = BitConverter.ToString(resualt).Replace("-", "");
            Password = pwds;
            return Password;
        }
    }

}
