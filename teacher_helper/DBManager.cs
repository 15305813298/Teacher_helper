using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace teacher_helper
{
    public class DBManager
    {
        private String user, pwd;
        private String server = "127.0.0.1";
        private String database = "teacher";
        private String port = "3306";
        private String db_user = "root";
        private String db_pwd = "111";
        private MySqlConnection connection;

        DBManager() { }
        public DBManager(String usr, String password)
        {
            this.user = usr;
            this.pwd = password;
        }
        public Boolean LoginQuery()
        {
            Boolean flag = false;
            String connsr = "server=" + this.server + " ;port=" + this.port + "; user=" + this.db_user + " ;password= " + this.db_pwd + ";database=" + database;
            this.connection = new MySqlConnection(connsr);
            connection.Open();
            String command = "select * from teacher_user";
            MySqlCommand mySqlCommand = new MySqlCommand(command, connection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                string str2 = mySqlDataReader["UserName"].ToString();
                string str3 = mySqlDataReader["Password"].ToString();
                if (str2.Trim() == user & str3.Trim() == pwd)
                    flag = true;
            }
            mySqlDataReader.Close();
            connection.Close();
            return flag;
        }
    }
}

