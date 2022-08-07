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
    [Route("/[Controller]/[action]")]
    [ApiController]
    [EnableCors("any")]

    public class ProjectController : ControllerBase
    {
        //新建项目
        [HttpPost]
        public bool AddProject(string project_id, string project_name, string project_background, string project_info, string project_content, string project_status, string project_stime, string project_etime, string project_progress)
        {
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
                                                    //添加

            try
            {
                Project pos = new Project();
                pos.project_id = project_id;
                pos.project_name = project_name;
                pos.project_background = project_background;
                pos.project_info = project_info;
                pos.project_content = project_content;
                pos.project_status = project_status;
                pos.project_stime = project_stime;
                pos.project_etime = project_etime;
                pos.project_progress = project_progress;
                if (db.Insertable(pos).ExecuteCommand() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //获取全部项目
        [HttpGet]
        public List<Project> SelectAllProject()
        {
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
            try
            {
                List<Project> plist = db.Queryable<Project>().ToList();
                return plist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        //获取单条项目信息
        public Project get_by_project_id(string project_id)
        {
            Project project = new Project();
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
            project = db.Queryable<Project>().Where(it => it.project_id == project_id).First();
            return project;
        }
        //删除项目
        [HttpDelete]
        public bool deleteProject(string project_id)
        {
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接                                      //删除
            try
            {
                int count = db.Deleteable<Grouping_Requirement>().In(project_id).ExecuteCommand();
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

