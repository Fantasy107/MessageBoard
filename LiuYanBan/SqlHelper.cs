using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiuYanBan
{
    public class SqlHelper
    {
        private static string connstr = ConfigurationManager.ConnectionStrings["dbconnstr"].ConnectionString;
       
        /// <summary>
        /// 返回一个受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql,params SqlParameter[] parameters)
        {
            using(SqlConnection conn=new SqlConnection(connstr))
            {
                conn.Open();
                using(SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
               }
            }
        }
        /// <summary>
        /// 返回一个有且只有一行一列的数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql,params SqlParameter[] parameters)
        {
            using(SqlConnection conn=new SqlConnection(connstr))
            {
                conn.Open();
                using(SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                   return  cmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 返回一个表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataSet(string sql,params SqlParameter[] parameters)
        {
            using(SqlConnection conn=new SqlConnection(connstr))
            {
                conn.Open();
                using(SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }
    }
}