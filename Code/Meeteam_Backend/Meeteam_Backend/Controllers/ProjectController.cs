using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using SqlSugar;
using MeeTeam_Backend;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Meeteam_Backend.Controllers
{
    [Route("/[Controller]/[action]")]
    [ApiController]
    [EnableCors("any")]
    public class ProjectController : ControllerBase
    {
        //上传项目
        [HttpPost]
        public bool AddProject(string project_id, string project_name, string project_background, string project_introduction, string project_content, string project_status, string due, string project_progress)
        {
            //获取数据库连接
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();

            Project pos = new Project();
            pos.project_id = project_id;
            pos.project_name = project_name;
            pos.project_background = project_background;
            pos.project_introduction = project_introduction;
            pos.project_content = project_content;
            pos.project_status = project_status;
            pos.create_time = DateTime.Now.ToString("g"); //2009/10/30 20:40;
            pos.admin_id = "system";
            pos.audit_result = "0";
            pos.audit_status = "0";
            pos.audit_reason = null;
            pos.due = due;
            pos.project_progress = project_progress;

            int count = db.Insertable(pos).ExecuteCommand();
            if (count == 1)
                return true;
            else
                return false;
        }
        //查询全部组队需求，返回一个对象
        [HttpGet]
        public List<Project> SelectAllProject()
        {
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
            try
            {
                List<Project> agrlist = db.Queryable<Project>().ToList();
                return agrlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //查询id的项目
        [HttpGet]
        public string get_by_id(string id)
        {
            Project project = new Project();
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
            //搜索条件，感觉可以改成检索的方式
            project = db.Queryable<Project>().Where(it => it.project_id == id).First();
            return JsonSerializer.Serialize(project);
        }
        //删除项目
        [HttpDelete]
        public bool deleteProject(string project_id)
        {
            //获取数据库连接
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();
            //删除
            try
            {
                int count = db.Deleteable<Project>().In(project_id).ExecuteCommand();
                if (count == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //查询项目
        [HttpGet]

        /*测试用例
{
  "project_id": "",
  "project_name": "",
  "publisher": "",
  "project_progess": "规划阶段",
  "audit_status": "1",
  "hav_require": "",
  "require_id": "",
  "require_status": "",
  "team_type": ""
}
         */
        public string project_query(string s)
        {
            Project_Query q = JsonSerializer.Deserialize<Project_Query>(s);
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();
            List<Project> res = new List<Project>();
            //三表联查
            var query = db.Queryable<Project, User_Project, Grouping_Requirement>(
                (p, up, gr) => new JoinQueryInfos(
                    JoinType.Left, p.project_id == up.project_id,
                    JoinType.Full, p.project_id == gr.project_id));
            if (q.project_id != null && q.project_id != "")
                query.Where((p, up, gr) => p.project_id == q.project_id);
            if (q.project_name != null && q.project_name != "")
                query.Where((p, up, gr) => p.project_name.Contains(q.project_name));
            if (q.publisher != null && q.publisher != "")
                query.Where((p, up, gr) => up.user_id.Contains(q.publisher) && up.duty == "发布者");
            if (q.project_progress != null && q.project_progress != "")
                query.Where((p, up, gr) => p.project_progress == q.project_progress);
            if (q.hav_require == "1")
                query.Where((p, up, gr) => SqlFunc.HasValue(gr.project_id));
            else if (q.hav_require == "0")
                query.Where((p, up, gr) => SqlFunc.IsNullOrEmpty(gr.project_id));
            if (q.require_id != null && q.require_id != "")
                query.Where((p, up, gr) => gr.require_id == q.require_id);
            if (q.require_status != null && q.require_status != "")
                query.Where((p, up, gr) => gr.require_status == q.require_status);
            if (q.team_type != null && q.team_type != "")
                query.Where((p, up, gr) => gr.team_type == q.team_type);
            if (q.audit_status != null && q.audit_status != "")
                query.Where((p, up, gr) => p.audit_status == q.audit_status);
            var json = query.Clone().Select<ViewMode>().Distinct().ToJson();
            return json;
        }
    }

    public class ViewMode:Project
    {
        public string User_Projectuser_id { get; set; }//按发布者查询
        public string Grouping_Requirementrequire_id { get; set; }//按需求id查询（唯一）
        public string Grouping_Requirementrequire_status { get; set; }//按需求状态查询
        public string Grouping_Requirementteam_type { get; set; }//按组队类型查询
    }
}