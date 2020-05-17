using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        MySqlDataAdapter mySqlDataAdapter;

        public DBManager() { }
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

        //查询
        public DataTable Query()
        {
            String connsr = "server=" + this.server + " ;port=" + this.port + "; user=" + this.db_user + " ;password= " + this.db_pwd + ";database=" + database;
            this.connection = new MySqlConnection(connsr);
            connection.Open();
            String command = "select * from yoyo order by id";
            MySqlCommand mySqlCommand = new MySqlCommand(command, connection);
            this.mySqlDataAdapter = new MySqlDataAdapter(command, connection);
            DataSet dataSet = new DataSet();
            this.mySqlDataAdapter.Fill(dataSet, "yoyo");
            DataTable table = dataSet.Tables[0];
            connection.Close();
            return table;
        }

        //更新
        public void Update(DataTable dt)
        {
            String connsr = "server=" + this.server + " ;port=" + this.port + "; user=" + this.db_user + " ;password= " + this.db_pwd + ";database=" + database;
            this.connection = new MySqlConnection(connsr);
            connection.Open();
            /*String command = "insert into ";
            MySqlCommand mySqlCommand = new MySqlCommand(command, connection);*/
            MySqlCommandBuilder update = new MySqlCommandBuilder(this.mySqlDataAdapter);
            try
            {
                this.mySqlDataAdapter.Update(dt);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            connection.Close();
        }
    }
}

