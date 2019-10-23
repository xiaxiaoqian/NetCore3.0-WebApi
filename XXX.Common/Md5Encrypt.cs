using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Common
{
    /// <summary>
    /// MD5签名
    /// </summary>
    public class Md5Encrypt
    {
        public static string MD5(string str)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            byte[] result = md5.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (var b in result)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
