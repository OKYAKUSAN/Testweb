using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.DAL;
using TestWeb.Model;

namespace TestWeb.BLL
{
    public class TeamBll
    {
        TeamServer ts = new TeamServer();
        List<Team> allTeam = new List<Team>();

        public TeamBll()
        {
            allTeam = ts.GetTeamList();
        }

        /// <summary>
        /// 获取所有球队列表
        /// </summary>
        /// <returns></returns>
        public List<Team> GetTeamList()
        {
            return allTeam;
        }

        /// <summary>
        /// 获取西部联盟球队列表
        /// </summary>
        /// <returns></returns>
        public List<Team> GetWesternTeamList()
        {
            List<Team> returnList = new List<Team>();
            foreach (Team temp in allTeam)
            {
                if (temp.Conference == "西部联盟") returnList.Add(temp);
            }
            return returnList;
        }

        /// <summary>
        /// 获取东部联盟球队列表
        /// </summary>
        /// <returns></returns>
        public List<Team> GetEasternTeamList()
        {
            List<Team> returnList = new List<Team>();
            foreach (Team temp in allTeam)
            {
                if (temp.Conference == "东部联盟") returnList.Add(temp);
            }
            return returnList;
        }

        /// <summary>
        /// 获取太平洋赛区球队列表
        /// </summary>
        /// <returns></returns>
        public List<Team> GetPacificTeamList()
        {
            List<Team> returnList = new List<Team>();
            foreach (Team temp in allTeam)
            {
                if (temp.Zone == "太平洋赛区") returnList.Add(temp);
            }
            return returnList;
        }

        /// <summary>
        /// 获取西北赛区球队列表
        /// </summary>
        /// <returns></returns>
        public List<Team> GetNorthwestTeamList()
        {
            List<Team> returnList = new List<Team>();
            foreach (Team temp in allTeam)
            {
                if (temp.Zone == "西北赛区") returnList.Add(temp);
            }
            return returnList;
        }

        /// <summary>
        /// 获取西南赛区球队列表
        /// </summary>
        /// <returns></returns>
        public List<Team> GetSouthwestTeamList()
        {
            List<Team> returnList = new List<Team>();
            foreach (Team temp in allTeam)
            {
                if (temp.Zone == "西南赛区") returnList.Add(temp);
            }
            return returnList;
        }

        /// <summary>
        /// 获取东南赛区球队列表
        /// </summary>
        /// <returns></returns>
        public List<Team> GetSoutheastTeamList()
        {
            List<Team> returnList = new List<Team>();
            foreach (Team temp in allTeam)
            {
                if (temp.Zone == "东南赛区") returnList.Add(temp);
            }
            return returnList;
        }

        /// <summary>
        /// 获取中部赛区球队列表
        /// </summary>
        /// <returns></returns>
        public List<Team> GetCentralTeamList()
        {
            List<Team> returnList = new List<Team>();
            foreach (Team temp in allTeam)
            {
                if (temp.Zone == "中部赛区") returnList.Add(temp);
            }
            return returnList;
        }

        /// <summary>
        /// 获取大西洋赛区球队列表
        /// </summary>
        /// <returns></returns>
        public List<Team> GetAtlanticTeamList()
        {
            List<Team> returnList = new List<Team>();
            foreach (Team temp in allTeam)
            {
                if (temp.Zone == "大西洋赛区") returnList.Add(temp);
            }
            return returnList;
        }
    }
}