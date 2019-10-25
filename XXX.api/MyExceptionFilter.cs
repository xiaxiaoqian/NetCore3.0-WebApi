
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace XXX.api
{
    /// <summary>
    /// 自定义webapi异常处理
    /// </summary>
    public class MyExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// 发送异常时执行的代码
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            Models.RetModel ret = new Models.RetModel();
            ret.code = 0;
            ret.message = "接口开小差了";
            string errRet= Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            if (context.ExceptionHandled==false)
            {
                context.Result = new ContentResult
                {
                    Content = errRet,
                    StatusCode = StatusCodes.Status200OK,
                    ContentType="application/json"
                };
            }
            context.ExceptionHandled = true;
        }
        /// <summary>
        /// 异步发送异常时执行的代码
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }
    }
}
