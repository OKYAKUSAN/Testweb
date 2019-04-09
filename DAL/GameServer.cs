using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TestWeb.Helper;
using TestWeb.Model;

namespace TestWeb.DAL
{
    public class GameServer
    {
        string cmdStr = "";

        /// <summary>
        /// 从数据库获取所有比赛列表
        /// </summary>
        /// <returns></returns>
        public List<GameModel> GetGameList()
        {
            cmdStr = "";
            cmdStr += "select Game.ID_G, Game.Season, Game.GameTime, Game.Away as Away_ID, T_a.Name_C as Away, T_a.Name_E as Away_E, Game.Home as Home_ID, T_h.Name_C as Home, T_h.Name_E as Home_E, r.AwayPoints, r.HomePoints ";
            cmdStr += "from Game left join (";
            cmdStr += "select ISNULL(a.ID_G,h.ID_G) ID_G, ISNULL(a.Season,h.Season) Season, ISNULL(a.GameTime,h.GameTime) GameTime, ISNULL(a.Away,h.Away) Away, ISNULL(a.Home,h.Home) Home, ISNULL(a.AwayPoints,0) AwayPoints, ISNULL(h.HomePoints,0) HomePoints ";
            cmdStr += "from (";
            cmdStr += "select G.ID_G, G.Season, G.GameTime, T_a.Name_C as Away, T_h.Name_C as Home, sum(GPS1.Points) as AwayPoints from Game as G inner join Team T_a on G.Away=T_a.ID_T inner join Team T_h on G.Home=T_h.ID_T inner join GamePlayerStats GPS1 on G.Away=GPS1.Team and GPS1.Game=G.ID_G group by G.ID_G, G.Season, G.GameTime, T_a.Name_C, T_h.Name_C";
            cmdStr += ") a full join (";
            cmdStr += "select G.ID_G, G.Season, G.GameTime, T_a.Name_C as Away, T_h.Name_C as Home, sum(GPS2.Points) as HomePoints from Game as G inner join Team T_a on G.Away=T_a.ID_T inner join Team T_h on G.Home=T_h.ID_T inner join GamePlayerStats GPS2 on G.Home=GPS2.Team and GPS2.Game=G.ID_G group by  G.ID_G, G.Season, G.GameTime, T_a.Name_C, T_h.Name_C";
            cmdStr += ") h on a.ID_G=h.ID_G";
            cmdStr += ") r on Game.ID_G=r.ID_G ";
            cmdStr += "inner join Team T_a on T_a.ID_T=Game.Away ";
            cmdStr += "inner join Team T_h on T_h.ID_T=Game.Home ";
            cmdStr += "order by Game.GameTime";
            DataSet ds = ServerHelper.GetQueryResultList(cmdStr);
            List<GameModel> returnList = new List<GameModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                GameModel tempGame = new GameModel();
                tempGame = GamePackage(dr);
                returnList.Add(tempGame);
            }
            return returnList;
        }

        /// <summary>
        /// 从数据库获取所有比赛列表(按时间降序)
        /// </summary>
        /// <returns></returns>
        public List<GameModel> GetGameListDESC()
        {
            cmdStr = "";
            cmdStr += "select Game.ID_G, Game.Season, Game.GameTime, Game.Away as Away_ID, T_a.Name_C as Away, T_a.Name_E as Away_E, Game.Home as Home_ID, T_h.Name_C as Home, T_h.Name_E as Home_E, r.AwayPoints, r.HomePoints ";
            cmdStr += "from Game left join (";
            cmdStr += "select ISNULL(a.ID_G,h.ID_G) ID_G, ISNULL(a.Season,h.Season) Season, ISNULL(a.GameTime,h.GameTime) GameTime, ISNULL(a.Away,h.Away) Away, ISNULL(a.Home,h.Home) Home, ISNULL(a.AwayPoints,0) AwayPoints, ISNULL(h.HomePoints,0) HomePoints ";
            cmdStr += "from (";
            cmdStr += "select G.ID_G, G.Season, G.GameTime, T_a.Name_C as Away, T_h.Name_C as Home, sum(GPS1.Points) as AwayPoints from Game as G inner join Team T_a on G.Away=T_a.ID_T inner join Team T_h on G.Home=T_h.ID_T inner join GamePlayerStats GPS1 on G.Away=GPS1.Team and GPS1.Game=G.ID_G group by G.ID_G, G.Season, G.GameTime, T_a.Name_C, T_h.Name_C";
            cmdStr += ") a full join (";
            cmdStr += "select G.ID_G, G.Season, G.GameTime, T_a.Name_C as Away, T_h.Name_C as Home, sum(GPS2.Points) as HomePoints from Game as G inner join Team T_a on G.Away=T_a.ID_T inner join Team T_h on G.Home=T_h.ID_T inner join GamePlayerStats GPS2 on G.Home=GPS2.Team and GPS2.Game=G.ID_G group by  G.ID_G, G.Season, G.GameTime, T_a.Name_C, T_h.Name_C";
            cmdStr += ") h on a.ID_G=h.ID_G";
            cmdStr += ") r on Game.ID_G=r.ID_G ";
            cmdStr += "inner join Team T_a on T_a.ID_T=Game.Away ";
            cmdStr += "inner join Team T_h on T_h.ID_T=Game.Home ";
            cmdStr += "order by Game.GameTime desc";
            DataSet ds = ServerHelper.GetQueryResultList(cmdStr);
            List<GameModel> returnList = new List<GameModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                GameModel tempGame = new GameModel();
                tempGame = GamePackage(dr);
                returnList.Add(tempGame);
            }
            return returnList;
        }

        /// <summary>
        /// 从数据库查询指定日期区间的比赛列表
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期（不包含当日）</param>
        /// <returns></returns>
        public List<GameModel> GetGameListTime(DateTime startDate, DateTime endDate)
        {
            cmdStr = "";
            cmdStr += "select Game.ID_G, Game.Season, Game.GameTime, Game.Away as Away_ID, T_a.Name_C as Away, T_a.Name_E as Away_E, Game.Home as Home_ID, T_h.Name_C as Home, T_h.Name_E as Home_E, r.AwayPoints, r.HomePoints ";
            cmdStr += "from Game left join (";
            cmdStr += "select ISNULL(a.ID_G,h.ID_G) ID_G, ISNULL(a.Season,h.Season) Season, ISNULL(a.GameTime,h.GameTime) GameTime, ISNULL(a.Away,h.Away) Away, ISNULL(a.Home,h.Home) Home, ISNULL(a.AwayPoints,0) AwayPoints, ISNULL(h.HomePoints,0) HomePoints ";
            cmdStr += "from (";
            cmdStr += "select G.ID_G, G.Season, G.GameTime, T_a.Name_C as Away, T_h.Name_C as Home, sum(GPS1.Points) as AwayPoints from Game as G inner join Team T_a on G.Away=T_a.ID_T inner join Team T_h on G.Home=T_h.ID_T inner join GamePlayerStats GPS1 on G.Away=GPS1.Team and GPS1.Game=G.ID_G group by G.ID_G, G.Season, G.GameTime, T_a.Name_C, T_h.Name_C";
            cmdStr += ") a full join (";
            cmdStr += "select G.ID_G, G.Season, G.GameTime, T_a.Name_C as Away, T_h.Name_C as Home, sum(GPS2.Points) as HomePoints from Game as G inner join Team T_a on G.Away=T_a.ID_T inner join Team T_h on G.Home=T_h.ID_T inner join GamePlayerStats GPS2 on G.Home=GPS2.Team and GPS2.Game=G.ID_G group by  G.ID_G, G.Season, G.GameTime, T_a.Name_C, T_h.Name_C";
            cmdStr += ") h on a.ID_G=h.ID_G";
            cmdStr += ") r on Game.ID_G=r.ID_G ";
            cmdStr += "inner join Team T_a on T_a.ID_T=Game.Away ";
            cmdStr += "inner join Team T_h on T_h.ID_T=Game.Home ";
            cmdStr += "where Game.GameTime>='" + startDate.Year.ToString() + "-" + startDate.Month.ToString() + "-" + startDate.Day.ToString() + "' and Game.GameTime<='" + endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString() + "' ";
            cmdStr += "order by Game.GameTime";
            DataSet ds = ServerHelper.GetQueryResultList(cmdStr);
            List<GameModel> returnList = new List<GameModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                GameModel tempGame = new GameModel();
                tempGame = GamePackage(dr);
                returnList.Add(tempGame);
            }
            return returnList;
        }

        /// <summary>
        /// 从数据库查询指定队伍相关的比赛列表
        /// </summary>
        /// <param name="id">队伍ID</param>
        /// <returns></returns>
        public List<GameModel> GetGameListTeam(int id)
        {
            cmdStr = "";
            cmdStr += "select Game.ID_G, Game.Season, Game.GameTime, Game.Away as Away_ID, T_a.Name_C as Away, T_a.Name_E as Away_E, Game.Home as Home_ID, T_h.Name_C as Home, T_h.Name_E as Home_E, r.AwayPoints, r.HomePoints ";
            cmdStr += "from Game left join (";
            cmdStr += "select ISNULL(a.ID_G,h.ID_G) ID_G, ISNULL(a.Season,h.Season) Season, ISNULL(a.GameTime,h.GameTime) GameTime, ISNULL(a.Away,h.Away) Away, ISNULL(a.Home,h.Home) Home, ISNULL(a.AwayPoints,0) AwayPoints, ISNULL(h.HomePoints,0) HomePoints ";
            cmdStr += "from (";
            cmdStr += "select G.ID_G, G.Season, G.GameTime, T_a.Name_C as Away, T_h.Name_C as Home, sum(GPS1.Points) as AwayPoints from Game as G inner join Team T_a on G.Away=T_a.ID_T inner join Team T_h on G.Home=T_h.ID_T inner join GamePlayerStats GPS1 on G.Away=GPS1.Team and GPS1.Game=G.ID_G group by G.ID_G, G.Season, G.GameTime, T_a.Name_C, T_h.Name_C";
            cmdStr += ") a full join (";
            cmdStr += "select G.ID_G, G.Season, G.GameTime, T_a.Name_C as Away, T_h.Name_C as Home, sum(GPS2.Points) as HomePoints from Game as G inner join Team T_a on G.Away=T_a.ID_T inner join Team T_h on G.Home=T_h.ID_T inner join GamePlayerStats GPS2 on G.Home=GPS2.Team and GPS2.Game=G.ID_G group by  G.ID_G, G.Season, G.GameTime, T_a.Name_C, T_h.Name_C";
            cmdStr += ") h on a.ID_G=h.ID_G";
            cmdStr += ") r on Game.ID_G=r.ID_G ";
            cmdStr += "inner join Team T_a on T_a.ID_T=Game.Away ";
            cmdStr += "inner join Team T_h on T_h.ID_T=Game.Home ";
            cmdStr += "where Game.Away=" + id.ToString() + " or Game.Home=" + id.ToString() + " ";
            cmdStr += "order by Game.GameTime";
            DataSet ds = ServerHelper.GetQueryResultList(cmdStr);
            List<GameModel> returnList = new List<GameModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                GameModel tempGame = new GameModel();
                tempGame = GamePackage(dr);
                returnList.Add(tempGame);
            }
            return returnList;
        }

        /// <summary>
        /// 从数据库查询指定比赛比分数据
        /// </summary>
        /// <param name="id">比赛ID</param>
        /// <returns></returns>
        public GameModel GetSingleGame(int id)
        {
            cmdStr = "";
            cmdStr += "select Game.ID_G, Game.Season, Game.GameTime, Game.Away as Away_ID, T_a.Name_C as Away, T_a.Name_E as Away_E, Game.Home as Home_ID, T_h.Name_C as Home, T_h.Name_E as Home_E, r.AwayPoints, r.HomePoints ";
            cmdStr += "from Game left join (";
            cmdStr += "select ISNULL(a.ID_G,h.ID_G) ID_G, ISNULL(a.Season,h.Season) Season, ISNULL(a.GameTime,h.GameTime) GameTime, ISNULL(a.Away,h.Away) Away, ISNULL(a.Home,h.Home) Home, ISNULL(a.AwayPoints,0) AwayPoints, ISNULL(h.HomePoints,0) HomePoints ";
            cmdStr += "from (";
            cmdStr += "select G.ID_G, G.Season, G.GameTime, T_a.Name_C as Away, T_h.Name_C as Home, sum(GPS1.Points) as AwayPoints from Game as G inner join Team T_a on G.Away=T_a.ID_T inner join Team T_h on G.Home=T_h.ID_T inner join GamePlayerStats GPS1 on G.Away=GPS1.Team and GPS1.Game=G.ID_G group by G.ID_G, G.Season, G.GameTime, T_a.Name_C, T_h.Name_C";
            cmdStr += ") a full join (";
            cmdStr += "select G.ID_G, G.Season, G.GameTime, T_a.Name_C as Away, T_h.Name_C as Home, sum(GPS2.Points) as HomePoints from Game as G inner join Team T_a on G.Away=T_a.ID_T inner join Team T_h on G.Home=T_h.ID_T inner join GamePlayerStats GPS2 on G.Home=GPS2.Team and GPS2.Game=G.ID_G group by  G.ID_G, G.Season, G.GameTime, T_a.Name_C, T_h.Name_C";
            cmdStr += ") h on a.ID_G=h.ID_G";
            cmdStr += ") r on Game.ID_G=r.ID_G ";
            cmdStr += "inner join Team T_a on T_a.ID_T=Game.Away ";
            cmdStr += "inner join Team T_h on T_h.ID_T=Game.Home ";
            cmdStr += "where Game.ID_G=" + id.ToString();
            DataSet ds = ServerHelper.GetQueryResultList(cmdStr);
            GameModel returnGame = new GameModel();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                returnGame = GamePackage(dr);
            }
            return returnGame;
        }

        /// <summary>
        /// 从数据库查询指定比赛球员数据
        /// </summary>
        /// <param name="id">比赛ID</param>
        /// <returns></returns>
        public List<PlayerGameStats> GetPlayerGameStats(int id)
        {
            cmdStr = "";
            cmdStr += "select gps.ID_GPS, Player.ID_P, Player.FirstName_C, Player.LastName_C, Player.FirstName_E, Player.LastName_E,";
            cmdStr += "Game.ID_G, Game.Season, Game.GameTime, Game.Away, T_a.Name_C as AwayName, Game.Home, T_h.Name_C as HomeName, T_t.ID_T as TeamId, T_t.Name_C as TeamName,";
            cmdStr += "gps.PlayingTime, gps.Starter, gps.Points, gps.Shots, gps.ShotsHit, gps.ThreePoints, gps.ThreePointsHit, gps.FreeThrow, gps.FreeThrowHit, gps.OffensiveRebound, gps.DefensiveRebound, gps.Block, gps.Assists, gps.Steals, gps.Faults, gps.Foul";
            cmdStr += " from GamePlayerStats as gps inner join Team T_t on gps.Team=T_t.ID_T,";
            cmdStr += "Player, TeamMember, Game";
            cmdStr += " inner join Team T_a on Game.Away=T_a.ID_T";
            cmdStr += " inner join Team T_h on Game.Home=T_h.ID_T";
            cmdStr += " where gps.Player=TeamMember.ID_TM and TeamMember.Player=Player.ID_P and gps.Game=Game.ID_G and gps.Game=" + id.ToString();
            cmdStr += " order by T_t.ID_T, gps.Starter desc";
            DataSet ds = ServerHelper.GetQueryResultList(cmdStr);
            List<PlayerGameStats> pgsList = new List<PlayerGameStats>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                PlayerGameStats tempPGS = PackageHelper.PackagePlayerGameStats(dr);
                pgsList.Add(tempPGS);
            }
            return pgsList;
        }

        /// <summary>
        /// 从数据库查询某一条球员数据
        /// </summary>
        /// <param name="id">数据ID</param>
        /// <returns></returns>
        public PlayerGameStats GetPlayerGameStatsSingle(int id)
        {
            cmdStr = "";
            cmdStr += "select gps.ID_GPS, Player.ID_P, Player.FirstName_C, Player.LastName_C, Player.FirstName_E, Player.LastName_E,";
            cmdStr += "Game.ID_G, Game.Season, Game.GameTime, Game.Away, T_a.Name_C as AwayName, Game.Home, T_h.Name_C as HomeName, T_t.ID_T as TeamId, T_t.Name_C as TeamName,";
            cmdStr += "gps.PlayingTime, gps.Starter, gps.Points, gps.Shots, gps.ShotsHit, gps.ThreePoints, gps.ThreePointsHit, gps.FreeThrow, gps.FreeThrowHit, gps.OffensiveRebound, gps.DefensiveRebound, gps.Block, gps.Assists, gps.Steals, gps.Faults, gps.Foul";
            cmdStr += " from GamePlayerStats as gps inner join Team T_t on gps.Team=T_t.ID_T,";
            cmdStr += "Player, TeamMember, Game";
            cmdStr += " inner join Team T_a on Game.Away=T_a.ID_T";
            cmdStr += " inner join Team T_h on Game.Home=T_h.ID_T";
            cmdStr += " where gps.Player=TeamMember.ID_TM and TeamMember.Player=Player.ID_P and gps.Game=Game.ID_G and gps.ID_GPS=" + id.ToString();
            DataSet ds = ServerHelper.GetQueryResultList(cmdStr);
            PlayerGameStats returnPGS = PackageHelper.PackagePlayerGameStats(ds.Tables[0].Rows[0]);
            return returnPGS;
        }

        /// <summary>
        /// 向数据库插入新增比赛记录
        /// </summary>
        /// <param name="time">比赛时间</param>
        /// <param name="season">赛季</param>
        /// <param name="away">客队ID</param>
        /// <param name="home">主队ID</param>
        /// <returns></returns>
        public int InsertGame(string season, DateTime time, int away, int home)
        {
            cmdStr = "";
            cmdStr += "if not exists(select * from Game where Season='" + season + "' and GameTime='" + time.ToString("yyyy-MM-dd HH:mm") + "' and Away=" + away.ToString() + " and Home=" + home.ToString() + ")";
            cmdStr += "insert into Game ";
            cmdStr += "values ('" + season + "','" + time.ToString("yyyy-MM-dd HH:mm") + "'," + away + "," + home + ")";
            cmdStr += ";select @@IDENTITY as Id";
            return ServerHelper.ExecuteScalar(cmdStr);
        }

        /// <summary>
        /// 修改数据库中比赛记录
        /// </summary>
        /// <param name="id">比赛ID</param>
        /// <param name="season">赛季</param>
        /// <param name="time">比赛时间</param>
        /// <param name="away">主队ID</param>
        /// <param name="home">客队ID</param>
        /// <returns></returns>
        public int UpdateGame(int id,string season,DateTime time,int away,int home)
        {
            cmdStr = "";
            cmdStr += "update Game set Season='" + season + "'";
            cmdStr += ",GameTime='" + time.ToString("yyyy-MM-dd HH:mm") + "'";
            cmdStr += ",Away=" + away.ToString();
            cmdStr += ",Home=" + home.ToString();
            cmdStr += " where ID_G=" + id.ToString();
            return ServerHelper.ExecuteNonQuery(cmdStr);
        }

        /// <summary>
        /// 删除数据库中比赛记录
        /// </summary>
        /// <param name="id">比赛ID</param>
        /// <returns></returns>
        public int DeleteGame(int id)
        {
            cmdStr = "";
            cmdStr += "delete from Game where ID_G=" + id.ToString();
            return ServerHelper.ExecuteNonQuery(cmdStr);
        }

        /// <summary>
        /// 向数据库插入新增比赛球员数据记录
        /// </summary>
        /// <param name="pgs">PlayerGameStats实例</param>
        /// <returns></returns>
        public int InsertGamePlayerStats(PlayerGameStats pgs)
        {
            cmdStr = "";
            cmdStr += "if not exists(select * from GamePlayerStats where Game=" + pgs.GameId.ToString() + " and Player=" + pgs.PlayerId.ToString() + ")";
            cmdStr += "insert into GamePlayerStats values (" + pgs.GameId.ToString() + "," + pgs.TeamMemberId.ToString() + "," + pgs.Points.ToString() + "," + pgs.Shots.ToString() + "," + pgs.ShotsHit.ToString() + "," + pgs.ThreePoints.ToString() + "," + pgs.ThreePointsHit.ToString() + "," + pgs.FreeThrow.ToString() + "," + pgs.FreeThrowHit.ToString() + "," + pgs.OffensiveRebound.ToString() + "," + pgs.DefensiveRebound.ToString() + "," + pgs.Block.ToString() + "," + pgs.Assists.ToString() + "," + pgs.Steals.ToString() + "," + pgs.Foul.ToString() + "," + pgs.Faults.ToString() + "," + (pgs.Starter ? "1" : "0") + "," + pgs.PlayingTime.ToString() + "," + pgs.TeamId.ToString() + ")";
            cmdStr += ";select @@IDENTITY as Id";
            return ServerHelper.ExecuteScalar(cmdStr);
        }

        /// <summary>
        /// 修改数据库中球员比赛数据
        /// </summary>
        /// <param name="pgs">PlayerGameStats对象</param>
        /// <returns></returns>
        public int UpdateGamePlayerStats(PlayerGameStats pgs)
        {
            cmdStr = "";
            cmdStr += "update GamePlayerStats set Game=" + pgs.GameId.ToString();
            cmdStr += ",Player=" + pgs.TeamMemberId.ToString();
            cmdStr += ",Points=" + pgs.Points.ToString();
            cmdStr += ",Shots=" + pgs.Shots.ToString();
            cmdStr += ",ShotsHit" + pgs.ShotsHit.ToString();
            cmdStr += ",ThreePoints" + pgs.ThreePoints.ToString();
            cmdStr += ",ThreePointsHit" + pgs.ThreePointsHit.ToString();
            cmdStr += ",FreeThrow" + pgs.FreeThrow.ToString();
            cmdStr += ",FreeThrowHit" + pgs.FreeThrowHit.ToString();
            cmdStr += ",OffensiveRebound" + pgs.OffensiveRebound.ToString();
            cmdStr += ",DefensiveRebound" + pgs.DefensiveRebound.ToString();
            cmdStr += ",Block=" + pgs.Block.ToString();
            cmdStr += ",Assists=" + pgs.Assists.ToString();
            cmdStr += ",Steals=" + pgs.Steals.ToString();
            cmdStr += ",Foul=" + pgs.Foul.ToString();
            cmdStr += ",Faults=" + pgs.Faults.ToString();
            cmdStr += ",Starter=" + (pgs.Starter ? "1" : "0");
            cmdStr += ",PlayingTime=" + pgs.PlayingTime.ToString();
            cmdStr += ",Team=" + pgs.TeamId.ToString();
            cmdStr += " where ID_GPS=" + pgs.StatsId.ToString();
            return ServerHelper.ExecuteNonQuery(cmdStr);
        }

        private static GameModel GamePackage(DataRow dr)
        {
            GameModel packageGame = new GameModel();
            packageGame.Id = Int32.Parse(dr["ID_G"].ToString());
            packageGame.Season = dr["Season"].ToString();
            packageGame.Time = DateTime.Parse(dr["GameTime"].ToString());
            packageGame.Away_ID = Int32.Parse(dr["Away_ID"].ToString());
            packageGame.Away = dr["Away"].ToString();
            packageGame.Away_E = dr["Away_E"].ToString();
            packageGame.Home_ID = Int32.Parse(dr["Home_ID"].ToString());
            packageGame.Home = dr["Home"].ToString();
            packageGame.Home_E = dr["Home_E"].ToString();
            packageGame.AwayPoints = Convert.ToString(dr["AwayPoints"]) == "" ? "-1" : dr["AwayPoints"].ToString();
            packageGame.HomePoints = Convert.ToString(dr["HomePoints"]) == "" ? "-1" : dr["HomePoints"].ToString();
            return packageGame;
        }
    }
}