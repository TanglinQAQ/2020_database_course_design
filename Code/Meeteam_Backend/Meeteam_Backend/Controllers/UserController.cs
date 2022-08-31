﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeeTeam_Back;
using Oracle.ManagedDataAccess.Client;
using Microsoft.AspNetCore.Cors;
using SqlSugar;
using System.Data;
using System.Collections;
using MeeTeam_Backend;

namespace Meeteam_Backend.Controllers
{
    [Route("/[Controller]/[action]")]
    [ApiController]
    [EnableCors("any")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        //添加浏览历史
        public bool AddViewHistory(string user_id, string project_id)
        {
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接

            try
            {
                Browsehistory bh = new Browsehistory();
                bh.user_id = user_id;
                bh.project_id = project_id;
                bh.browse_time = DateTime.Now.ToString();
                int count = db.Insertable(bh).ExecuteCommand();
                if (count == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
