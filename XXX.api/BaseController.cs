using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace XXX.api
{
    /// <summary>
    /// 自定义路由模版
    /// 用于解决swagger文档No operations defined in spec!问题
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        
    }
}
