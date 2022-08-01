﻿using Microsoft.AspNetCore.Http;
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
    [Route("/[Controller]/[action]")]
    [ApiController]
    [EnableCors("any")]

    public class GroupRequirementController : ControllerBase
    {
        //添加组队需求
        [HttpPost]
        public bool AddGroupRequirement(string require_id, string purpose, string team_type, string team_limit, string details, string require_status, string originator_id, string project_id)
        {
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
                                                    //添加
            Grouping_Requirement pos = new Grouping_Requirement();
            pos.require_id = require_id;
            pos.release_time = DateTime.Now.ToString("g"); //2009/10/30 20:40
            pos.purpose = purpose;
            pos.team_type = team_type;
            pos.team_limit = team_limit;
            pos.details = details;
            pos.require_status = require_status;
            pos.originator_id = originator_id;
            pos.project_id = project_id;
            int count = db.Insertable(pos).ExecuteCommand();
            if (count == 1)
                return true;
            else
                return false;
        }
        //查询全部组队需求，返回一个对象
        [HttpGet]
        public List<Grouping_Requirement> SelectAllGroupRequirement()
        {
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
            List<Grouping_Requirement> agrlist = db.Queryable<Grouping_Requirement>().ToList();
            return agrlist;
        }
        //查询个人用户的组队需求，返回一个对象
        [HttpGet]
        public List<Grouping_Requirement> SelectuserGroupRequirement(string userid)
        {
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
            List<Grouping_Requirement> agrlist = db.Queryable<Grouping_Requirement>().Where(it => it.originator_id == userid).ToList();
            return agrlist;
        }
        //删除组队需求
        [HttpDelete]
        public bool deleteGroupRequirement(string require_id)
        {
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
                                                    //删除
            try
            {
                int count = db.Deleteable<Grouping_Requirement>().In(require_id).ExecuteCommand();
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

