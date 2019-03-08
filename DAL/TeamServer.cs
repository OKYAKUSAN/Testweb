using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TestWeb.Helper;
using TestWeb.Model;

namespace TestWeb.DAL
{
    public class TeamServer
    {
        //SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["connstring"].ToString());
        string cmdStr = "";

        /// <summary>
        /// 从数据库获取所有队伍列表
        /// </summary>
        /// <returns></returns>
        public List<Team> GetTeamList()
        {
            cmdStr = "select Team.ID_T, Team.City_C, Team.Name_C, Team.City_E, Team.Name_E, Zone.Name_C as ZoneName, Conference.Name_C as ConferenceName from Team, Zone, Conference where Team.Zone=Zone.ID_Z and Zone.ConferenceID=Conference.ID_C";
            DataSet ds = ServerHelper.GetQueryResultList(cmdStr);
            List<Team> resultList = new List<Team>();
            foreach (DataRow drTemp in ds.Tables[0].Rows)
            {
                Team resultTemp = new Team();
                resultTemp.Id = Int32.Parse(drTemp["ID_T"].ToString());
                resultTemp.ECity = drTemp["City_E"].ToString();
                resultTemp.CCity = drTemp["City_C"].ToString();
                resultTemp.EName = drTemp["Name_E"].ToString();
                resultTemp.CName = drTemp["Name_C"].ToString();
                resultTemp.Conference = drTemp["ConferenceName"].ToString();
                resultTemp.Zone = drTemp["ZoneName"].ToString();
                resultList.Add(resultTemp);
            }
            return resultList;
        }


    }
}