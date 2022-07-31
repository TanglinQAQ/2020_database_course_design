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

namespace MeeTeam_Back.Controllers
{
    [Route("/[Controller]/[action]")]
    [ApiController]
    [EnableCors("any")]

    public class GroupRequirementController : ControllerBase
    {
        //添加组队需求
        [HttpPost]
        public bool AddGroupRequirement(String require_id, String purpose, String team_type, String team_limit, String details, String require_status, String originator_id, String project_id)
        {
            UserDB db = new UserDB();
            OracleCommand cmd;
            if (db.connectOracle())
            {
                DateTime release_time = DateTime.Now;//不需要传递日期
                cmd = db.con.CreateCommand();
                cmd.CommandText = string.Format("insert into GROUPING_REQUIREMENT values('{0}', to_date('{1}','yyyy/mm/dd hh24:mi:ss'),'{2}','{3}','{4}','{5}','{6}','{7}', '{8}')", require_id, release_time, purpose, team_type, team_limit, details, require_status, originator_id, project_id);
                int row = cmd.ExecuteNonQuery();
                db.con.Close();
                if (row == 1)
                    return true;
                else
                    return false;
            }
            return true;
        }
        //查询全部组队需求，返回一个对象
        [HttpGet]
        public ArrayList SelectAllGroupRequirement()
        {
            UserDB db = new UserDB();
            OracleCommand cmd;
            ArrayList grlist = new ArrayList();
            if (db.connectOracle())
            {
                cmd = db.con.CreateCommand();
                cmd.CommandText = string.Format("select * from  GROUPING_REQUIREMENT");
                OracleDataReader odr = cmd.ExecuteReader();
                if (odr.HasRows)
                {
                    //GroupRequirement[] grlist; //接收所有数据的数组
                    //List<GroupRequirement> _list = new List<GroupRequirement>(grlist);
                    //循环接收
                    while (odr.Read())
                    {
                        GroupRequirement demo = new GroupRequirement();
                        demo.require_id = odr["require_id"].ToString();
                        demo.release_time =Convert.ToDateTime(odr["release_time"]);
                        demo.purpose = odr["purpose"].ToString();
                        demo.team_type = odr["team_type"].ToString();
                        demo.team_limit = odr["team_limit"].ToString();
                        demo.details = odr["details"].ToString();
                        demo.require_status = odr["require_status"].ToString();
                        demo.originator_id = odr["originator_id"].ToString();
                        demo.project_id = odr["project_id"].ToString();
                        grlist.Add(demo);
                    }
                }
                db.con.Close();
            }
            return grlist;
        }
        //删除组队需求
        [HttpDelete]
        public bool deleteGroupRequirement(String require_id)
        {
            UserDB db = new UserDB();
            OracleCommand cmd;
            ArrayList grlist = new ArrayList();
            if (db.connectOracle())
            {
                cmd = db.con.CreateCommand();
                cmd.CommandText = string.Format("delete from GROUPING_REQUIREMENT where require_id='"+ require_id+"';");
                int row = cmd.ExecuteNonQuery();//返回变化的行数
                db.con.Close();
                if (row == 1)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
