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
    public class PlayerServer
    {
        string cmdStr = "";

        /// <summary>
        /// 从数据库获取所有球员列表
        /// </summary>
        /// <returns></returns>
        public List<Player> GetAllPlayerList()
        {
            cmdStr = "";
            cmdStr += "select * from Player order by LastName_E";
            DataSet resultList = ServerHelper.GetQueryResultList(cmdStr);
            List<Player> playerList = new List<Player>();
            foreach (DataRow dr in resultList.Tables[0].Rows)
            {
                Player tempPlayer = new Player();
                tempPlayer = PlyaerPackage(dr);
                playerList.Add(tempPlayer);
            }
            return playerList;
        }

        /// <summary>
        /// 从数据库获取指定球员信息
        /// </summary>
        /// <param name="id">球员ID</param>
        /// <returns></returns>
        public Player GetPlayer(int id)
        {
            cmdStr = "";
            cmdStr += "select * from Player where ID_P=" + id.ToString();
            DataSet resultPlayer = ServerHelper.GetQueryResultList(cmdStr);
            Player tempPlayer = new Player();
            foreach (DataRow dr in resultPlayer.Tables[0].Rows)
            {
                tempPlayer = PlyaerPackage(dr);
            }
            return tempPlayer;
        }

        public void GetAllTeamMember()
        {
            cmdStr = "";
            cmdStr += "select tm.ID_TM, p.ID_P, p.FirstName_C, p.LastName_C, p.FirstName_E, p.LastName_E";
        }

        /// <summary>
        /// 从数据库获取指定球员所有比赛的单场数据
        /// </summary>
        /// <param name="id">球员ID</param>
        /// <returns></returns>
        public List<PlayerGameStats> GetPlayerStats(int id)
        {
            cmdStr = "";
            cmdStr += "select P.ID_P, P.FirstName_E, P.LastName_E, P.FirstName_C, P.LastName_C, G.Season, G.GameTime, T_a.Name_C as AwayTeam, T_b.Name_C as HomeTeam, T.Name_C, GPS.Starter ,GPS.PlayingTime, GPS.Points, GPS.Shots, GPS.ShotsHit, GPS.ThreePoints, GPS.ThreePointsHit, GPS.FreeThrow, GPS.FreeThrowHit,GPS.OffensiveRebound, GPS.DefensiveRebound, GPS.Block, GPS.Assists, GPS.Steals, GPS.Foul, GPS.Faults";
            cmdStr += " from Player as P, TeamMember as TM, GamePlayerStats as GPS, Team as T, Game as G";
            cmdStr += " inner join Team T_a on G.Away=T_a.ID_T";
            cmdStr += " inner join Team T_b on G.Home=T_b.ID_T";
            cmdStr += " where GPS.Game=G.ID_G and GPS.Player=TM.ID_TM and TM.Player=P.ID_P and GPS.Team=T.ID_T and P.ID_P=" + id.ToString();
            DataSet resultStats = ServerHelper.GetQueryResultList(cmdStr);
            List<PlayerGameStats> returnList = new List<PlayerGameStats>();
            foreach (DataRow dr in resultStats.Tables[0].Rows)
            {
                PlayerGameStats tempPlayerStats = new PlayerGameStats();
                tempPlayerStats = PlayerGameStatsPackage(dr);
                returnList.Add(tempPlayerStats);
            }
            return returnList;
        }

        private static Player PlyaerPackage(DataRow dr)
        {
            Player packagePlayer = new Player();
            packagePlayer.Id = Int32.Parse(dr["ID_P"].ToString());
            packagePlayer.FirstName_E = dr["FirstName_E"].ToString();
            packagePlayer.LastName_E = dr["LastName_E"].ToString();
            packagePlayer.FirstName_C = dr["FirstName_C"].ToString();
            packagePlayer.LastName_C = dr["LastName_C"].ToString();
            packagePlayer.Birthday = DateTime.Parse(dr["Birthday"].ToString());
            packagePlayer.Position = dr["Position"].ToString();
            packagePlayer.PlayingAge = Int32.Parse(dr["PlayingAge"].ToString());
            packagePlayer.Retire = Convert.ToString(dr["Retire"].ToString()) != "" ? DateTime.Parse(dr["Retire"].ToString()) : new DateTime();
            packagePlayer.Photo = dr["Photo"].ToString();
            packagePlayer.Height = float.Parse(dr["Pheight"].ToString());
            packagePlayer.Weight = float.Parse(dr["Pweight"].ToString());
            return packagePlayer;
        }

        private static PlayerGameStats PlayerGameStatsPackage(DataRow dr)
        {
            PlayerGameStats packagePlayerGameStats = new PlayerGameStats();
            packagePlayerGameStats.PlayerId = Int32.Parse(dr["ID_P"].ToString());
            packagePlayerGameStats.FirstName_E = dr["FirstName_E"].ToString();
            packagePlayerGameStats.LastName_E = dr["LastName_E"].ToString();
            packagePlayerGameStats.FirstName_C = dr["FirstName_C"].ToString();
            packagePlayerGameStats.LastName_C = dr["LastName_C"].ToString();
            packagePlayerGameStats.Season = dr["Season"].ToString();
            packagePlayerGameStats.Time = DateTime.Parse(dr["GameTime"].ToString());
            packagePlayerGameStats.AwayTeam = dr["AwayTeam"].ToString();
            packagePlayerGameStats.HomeTeam = dr["HomeTeam"].ToString();
            packagePlayerGameStats.Team = dr["Name_C"].ToString();
            packagePlayerGameStats.Starter = Int32.Parse(dr["Starter"].ToString()) == 1;
            packagePlayerGameStats.PlayingTime = Int32.Parse(dr["PlayingTime"].ToString());
            packagePlayerGameStats.Points = Int32.Parse(dr["Points"].ToString());
            packagePlayerGameStats.Shots = Int32.Parse(dr["Shots"].ToString());
            packagePlayerGameStats.ShotsHit = Int32.Parse(dr["ShotsHit"].ToString());
            packagePlayerGameStats.ShotsHitRate = ((float)packagePlayerGameStats.ShotsHit) / ((float)packagePlayerGameStats.Shots) * 100;
            packagePlayerGameStats.ThreePoints = Int32.Parse(dr["ThreePoints"].ToString());
            packagePlayerGameStats.ThreePointsHit = Int32.Parse(dr["ThreePointsHit"].ToString());
            packagePlayerGameStats.ThreePointsHitRate = ((float)packagePlayerGameStats.ThreePointsHit) / ((float)packagePlayerGameStats.ThreePoints) * 100;
            packagePlayerGameStats.FreeThrow = Int32.Parse(dr["FreeThrow"].ToString());
            packagePlayerGameStats.FreeThrowHit = Int32.Parse(dr["FreeThrowHit"].ToString());
            packagePlayerGameStats.FreeThrowHitRate = ((float)packagePlayerGameStats.FreeThrowHit) / ((float)packagePlayerGameStats.FreeThrow) * 100;
            packagePlayerGameStats.OffensiveRebound = Int32.Parse(dr["OffensiveRebound"].ToString());
            packagePlayerGameStats.DefensiveRebound = Int32.Parse(dr["DefensiveRebound"].ToString());
            packagePlayerGameStats.Rebound = packagePlayerGameStats.OffensiveRebound + packagePlayerGameStats.DefensiveRebound;
            packagePlayerGameStats.Block = Int32.Parse(dr["Block"].ToString());
            packagePlayerGameStats.Assists = Int32.Parse(dr["Assists"].ToString());
            packagePlayerGameStats.Steals = Int32.Parse(dr["Steals"].ToString());
            packagePlayerGameStats.Foul = Int32.Parse(dr["Foul"].ToString());
            packagePlayerGameStats.Faults = Int32.Parse(dr["Faults"].ToString());
            return packagePlayerGameStats;
        }
    }
}