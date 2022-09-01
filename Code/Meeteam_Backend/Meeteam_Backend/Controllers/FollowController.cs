using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using System.Data;
using System.Collections;
using SqlSugar;
using MeeTeam_Backend;

namespace Meeteam_Backend.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    [EnableCors("any")]
    public class FollowController : ControllerBase
    {
        [HttpGet]
        public List<User_User> getRe(string MyID, string ID)
        {
            User_User my = new User_User();
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
            var relation = db.Queryable<User_User>()
                .Where(it => it.main_user_id == MyID && it.related_user_id == ID)
                .ToList();
            return relation;
        }
        

        [HttpGet]
        public int pullRe(string MyID, string ID, string relationship)
        {
            User_User my = new User_User();
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接

            if (relationship == "关注")//对方没有关注我，我试图关注对方
                my.relation = MyID + "关注了" + ID;
            else if (relationship == ID + "关注了" + MyID)//对方已经关注了我，我试图与其互关
                my.relation = "互关";
            else if (relationship == "已关注")//取消单方面的关注
                my.relation = "";
            else if (relationship == "互关")//互关但是我试图取消关注
                my.relation = ID + "关注了" + MyID;
            return db.Storageable(my).ExecuteCommand();
        }
    }
}
