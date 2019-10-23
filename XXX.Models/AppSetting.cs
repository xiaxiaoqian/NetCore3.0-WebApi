using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Models
{
    /// <summary>
    /// AppSettings参数
    /// </summary>
    public class AppSetting
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string xxxDB { get; set; }
        /// <summary>
        /// 接口是否需要签名验证，true需要，false不需要
        /// </summary>
        public static string IsSign { get; set; }
    }
}
