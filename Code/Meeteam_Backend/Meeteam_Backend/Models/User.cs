using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using SqlSugar;

namespace MeeTeam_Backend
{
    public class UserInfo
    {
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
            if (list[0] != null)
            {
                password = list[0].ToString();
                return password;
            }
            else
                return "0";
        }
    }
}
