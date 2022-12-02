using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Player.Model
{
    internal class DataProvider
    {
        private static string connectionStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=MediaPlayerDB;Integrated Security=True";
        // SqlConnection connect = new SqlConnection(conn);
        public static SqlDataReader ExecuteReader(String commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            //using (SqlConnection conn = new SqlConnection(connectionStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(commandText, conn))
            //    {
            //        cmd.CommandType = commandType;
            //        cmd.Parameters.AddRange(parameters);                    
            //        conn.Open();
            //        SqlDataReader reader = cmd.ExecuteReader();
            //        return reader;
            //    }
            //}
            SqlConnection conn = new SqlConnection(connectionStr);
            
                SqlCommand cmd = new SqlCommand(commandText, conn);
                
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader;
                
            
        }

    }
}
