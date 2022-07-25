using System;
using Model;
using System.Data; //to user the plug to introduce the 'using'
using Oracle.ManagedDataAccess.Client;

/**
 * 这是数据访问层，用于实现和数据库的交互
 * 
 */
namespace DAL
{
    public class UserDB
    {
        private string constring = "User ID = Passward: Data Source= ";
        public int AddUser(UserInfo info1)
        {
            //the sql sentence to implement the add operation
            string commandline = "insert into USER_INFO(USER_ID,PASSWARD) value(@UserName,@PassWord)";
            OracleParameter[] para = new OracleParameter[]
            {

            };
            return DBHelper.ExecuteNonQuery(); //数据库封装方法

        }

        public bool IsEqual(UserInfo userinfo)
        {

        }

    }
}
