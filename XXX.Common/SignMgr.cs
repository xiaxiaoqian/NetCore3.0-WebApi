using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXX.Models;

namespace XXX.Common
{
    /// <summary>
    /// 签名管理
    /// </summary>
    public class SignMgr
    {
        /// <summary>
        /// 验证用户请求参数
        /// 签名生成的通用步骤如下：
        /// 第一步，设所有发送或者接收到的数据为集合M，将集合M内非空参数值的参数按照参数名ASCII码从小到大排序（字典序），使用URL键值对的格式（即key1=value1&key2=value2…）拼接成字符串stringA。
        /// 特别注意以下重要规则：
        /// ◆ 参数名ASCII码从小到大排序（字典序）；
        /// ◆ 如果参数的值为空不参与签名；
        /// ◆ 参数名区分大小写；
        /// ◆ 验证调用返回或微信主动通知签名时，传送的sign参数不参与签名，将生成的签名与该sign值作校验。
        /// ◆ 微信接口可能增加字段，验证签名时必须支持增加的扩展字段
        /// 第二步，在stringA最后拼接上key得到stringSignTemp字符串，并对stringSignTemp进行MD5运算，再将得到的字符串所有字符转换为大写，得到sign值signValue。
        /// 例如
        /// stringA="key1=value1&key2=value2";
        /// stringSignTemp=stringA+"&key=xxxxxxxxxxxxxxxx"
        /// sign=MD5(stringSignTemp).ToUper()
        /// </summary>
        /// <param name="p">参数中需要包含sign字段，用来验证签名是否正确</param>
        /// <returns></returns>
        public static bool ParamVerify(Object p)
        {
            //获取是否签名字段
            string isSign = AppSettings.GetAppSeting("IsSign");
            //获取MD5签名字段
            string secretKey = AppSettings.GetAppSeting("Md5Key");
            if (isSign == "false")
            {
                return true;
            }
            try
            {
                Type t = p.GetType();
                var propertys = t.GetProperties();
                string sign = "";
                string temp = "";
                var orderPropertys = propertys.OrderBy(p => p.Name); //ASCII码从小到大排序（字典序）
                foreach (var item in orderPropertys)
                {
                    string name = item.Name;
                    object oValue = item.GetValue(p);
                    string value = "";
                    if (oValue != null)//如果参数不为空则拼接参数
                    {
                        value = oValue.ToString();
                        //判断参数是否为sign，sign不参与签名
                        if (name != "sign")
                        {
                            temp += name + "=" + value + "&";
                        }
                        else
                        {
                            sign = value;
                        }
                    }
                }

                temp +="key=" +secretKey;
                string md = Md5Encrypt.MD5(temp);
                if (sign != "" && sign.ToUpper() == md.ToUpper())
                {
                    //签名验证成功
                    return true;
                }
                else
                {
                    //签名失败
                    return false;
                }
            }
            catch (Exception ex)
            {
                //签名异常信息
                return false;
            }
        }

        
    }
}
