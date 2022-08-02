using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;


namespace MeeTeam_Backend.Controllers
{
    //路由规则http://根目录/[Controller]/[action]
    //返回的，开头2代表正确，最后4表示没有数据
    [Route("/[Controller]/[action]")]
    [ApiController]
    [EnableCors("any")]
    public class LoginController : ControllerBase
    {
        //登陆
        [HttpGet]
        public bool login(string user_id,string password)
        {
            UserInfo info = new UserInfo();
            string real_psw = info.get_Password(user_id);
            if (real_psw == null || real_psw != password)
                return false;
            else
                return true;
        }
    }
}
