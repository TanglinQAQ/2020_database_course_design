using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace MeeTeam_Back
{
    public class UserInfo
    {
        public string get_Password(string user_id)
        {
            string password = null;
            UserDB db = new UserDB();
            if (db.connectOracle())
            {
                OracleCommand cmd = db.con.CreateCommand();
                cmd.CommandText = "select PASSWORD from USER_INFO where USER_ID='" + user_id + "'";
                OracleDataReader odr = cmd.ExecuteReader();
                while (odr.Read())
                {
                    password = odr["PASSWORD"].ToString();
                }
                db.con.Close();
                return password;
            }
            else
            {
                return null;
            }
        }
    }

}
