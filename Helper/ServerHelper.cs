using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TestWeb.Helper
{
    public static class ServerHelper
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["connstring"].ToString());
        static SqlCommand cmd = conn.CreateCommand();

        /// <summary>
        /// 获取查询数据库结果列表
        /// </summary>
        /// <param name="cmdStr">Transact-SQL查询语句</param>
        /// <returns>DataSet类型查询结果列表</returns>
        public static DataSet GetQueryResultList(string cmdStr)
        {
            cmd.CommandText = cmdStr;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet resultDs = new DataSet();
            da.Fill(resultDs);
            conn.Close();
            return resultDs;
        }
    }
}