using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using SqlSugar;

namespace MeeTeam_Backend
{   
    [SugarTable("user_info")]
    public class UserInfo
    {
           [SugarColumn(IsPrimaryKey = true)]
           public string user_id { get; set; }

           [SugarColumn(IsJson = true)]
           public string password { get; set; }
           public string register_time { get; set; }
           public char account_status { get; set; }
           public string user_name { get; set; }
           public char gender { get; set; }
           public string contact_info { get; set; }
           public string institution { get; set; }
           public string major { get; set; }
           public string grade { get; set; }
           public string introduction { get; set; }
           public int point { get; set; } //表中是number(38,0),int位数不足，暂时先不考虑大数

        public string get_Password(string user_id)
        {
            string password = null;
            dbORM dborm = new dbORM();
            SqlSugarClient db = dborm.getInstance();//获取数据库连接
            //查询
            var list = db.Queryable<User_Info>()
                .Select(it => it.password)
                .Where("user_id=@id", new { id = user_id })
                .ToList();
            if (list.Count>0&&list[0] != null  )
            {
                password = list[0].ToString();
                return password;
            }
            else
                return "0";
        }
    }
}
