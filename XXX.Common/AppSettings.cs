using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Common
{
    public class AppSettings
    {
        private static IConfigurationSection appSection = null;
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSeting(string key)
        {
            if (appSection.GetSection(key)!=null)
            {
                return appSection.GetSection(key).Value;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 设置配置文件
        /// </summary>
        /// <param name="section"></param>
        public static void SetAppSetting(IConfigurationSection section)
        {
            appSection = section;
        }
    }
}
