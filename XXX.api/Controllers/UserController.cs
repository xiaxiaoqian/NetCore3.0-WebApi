using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace XXX.api.Controllers
{
    /// <summary>
    /// 用户接口
    /// </summary>
    //[Route("api/[controller]/[action]")]
    //[ApiController]
    public class UserController : BaseController
    {
        /// <summary>
        /// 测试接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return Ok("hello");
        }
        /// <summary>
        /// 增加一个用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUser([FromBody]Models.User.AddUserP model)
        {
            var r = Bo.UserBo.AddUser(model);
            return Ok(r);
        }
    }
}