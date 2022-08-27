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
    public class FacoriteController : ControllerBase
    {
        //上传项目
        [HttpPost]
        public bool AddFacorite(string facorite_id, string owner_id, string project_id)
        {
            //获取数据库连接
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();

            Facorite pos = new Facorite();
            pos.facorite_id = facorite_id;
            pos.owner_id = owner_id;
            pos.project_id = project_id;
            pos.facorite_time = DateTime.Now.ToString("g"); //2009/10/30 20:40;
            pos.facorite_state = "1";
            int count = db.Insertable(pos).ExecuteCommand();
            if (count == 1)
                return true;
            else
                return false;
        }
        //通过user_id查询收藏
        [HttpGet]
        public List<Facorite> GetFacorite(string user_id)
        {
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
            try
            {
                List<Facorite> agrlist = db.Queryable<Facorite>().Where(it => it.owner_id == user_id).ToList();
                return agrlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //查询全部收藏，返回一个对象
        [HttpGet]
        public List<Facorite> SelectAllGroupRequirement()
        {
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
            try
            {
                List<Facorite> agrlist = db.Queryable<Facorite>().ToList();
                return agrlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //查询全部评论，返回一个对象
    }
}
