using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.DAL;
using TestWeb.Model;

namespace TestWeb.BLL
{
    public class GameBll
    {
        private GameServer gameServer = new GameServer();
        //private List<GameModel> gameList = new List<GameModel>();
        private int winTotal = 0;
        private int loseTotal = 0;
        private int winAway = 0;
        private int loseAway = 0;
        private int winHome = 0;
        private int loseHome = 0;

        /// <summary>
        /// 获取所有比赛列表
        /// </summary>
        /// <returns></returns>
        public List<GameModel> GetGameList()
        {
            return gameServer.GetGameList();
        }

        /// <summary>
        /// 获取所有比赛列表（按时间顺序）
        /// </summary>
        /// <param name="desc">true为降序，false为升序</param>
        /// <returns></returns>
        public List<GameModel> GetGameList(bool desc)
        {
            if (desc) return gameServer.GetGameListDESC();
            else return gameServer.GetGameList();
        }

        /// <summary>
        /// 获取所有比赛总数
        /// </summary>
        /// <returns></returns>
        public int GetGameCount()
        {
            return gameServer.GetGameList().Count;
        }

        /// <summary>
        /// 获取某一支队伍的比赛列表
        /// </summary>
        /// <param name="teamId">队伍ID</param>
        /// <returns></returns>
        public List<GameModel> GetGameListSingleTeam(int teamId)
        {
            List<GameModel> returnList = gameServer.GetGameListTeam(teamId);
            foreach (GameModel tempGM in returnList)
            {
                if (tempGM.AwayPoints != "-1" || tempGM.HomePoints != "-1")
                {
                    if (tempGM.Away_ID == teamId)
                    {
                        if (Int32.Parse(tempGM.AwayPoints) < Int32.Parse(tempGM.HomePoints))
                        {
                            loseTotal++;
                            loseAway++;
                        }
                        else
                        {
                            winTotal++;
                            winAway++;
                        }
                    }
                    else if (tempGM.Home_ID == teamId)
                    {
                        if (Int32.Parse(tempGM.AwayPoints) < Int32.Parse(tempGM.HomePoints))
                        {
                            winTotal++;
                            winHome++;
                        }
                        else
                        {
                            loseTotal++;
                            loseHome++;
                        }
                    }
                }
            }
            return returnList;
        }

        public int WinTotal
        {
            get { return winTotal; }
        }
        public int LoseTotal
        {
            get { return loseTotal; }
        }
        public int WinAway
        {
            get { return winAway; }
        }
        public int LoseAway
        {
            get { return loseAway; }
        }
        public int WinHome
        {
            get { return winHome; }
        }
        public int LoseHome
        {
            get { return loseHome; }
        }

        /// <summary>
        /// 查询指定比赛的比分结果
        /// </summary>
        /// <param name="id">比赛ID</param>
        /// <returns></returns>
        public GameModel GetSingleGame(int id)
        {
            return gameServer.GetSingleGame(id);
        }

        /// <summary>
        /// 新增比赛
        /// </summary>
        /// <param name="season">赛季</param>
        /// <param name="time">比赛时间</param>
        /// <param name="away">客队ID</param>
        /// <param name="home">主队ID</param>
        /// <returns></returns>
        public int InsertNewGame(string season, DateTime time, string away, string home)
        {
            int awayId = Int32.Parse(away);
            int homeId = Int32.Parse(home);
            return gameServer.InsertGame(season, time, awayId, homeId);
        }

        /// <summary>
        /// 修改比赛
        /// </summary>
        /// <param name="id">比赛ID</param>
        /// <param name="season">赛季</param>
        /// <param name="time">比赛时间</param>
        /// <param name="away">客队ID</param>
        /// <param name="home">主队ID</param>
        /// <returns></returns>
        public int UpdateGame(int id, string season, DateTime time, string away, string home)
        {
            int awayId = Int32.Parse(away);
            int homeId = Int32.Parse(home);
            return gameServer.UpdateGame(id, season, time, awayId, homeId);
        }

        /// <summary>
        /// 删除比赛
        /// </summary>
        /// <param name="id">比赛ID</param>
        public void DeleteGame(int id)
        {
             //bool success = gameServer.DeleteGame(id) > 0 ? true : false;
            gameServer.DeleteGame(id);
        }

        /// <summary>
        /// 获取指定比赛的球员数据
        /// </summary>
        /// <param name="id">比赛ID</param>
        /// <returns></returns>
        public List<PlayerGameStats> GetPlayerGameStats(int id)
        {
            return gameServer.GetPlayerGameStats(id);
        }

        /// <summary>
        /// 获取某一条球员比赛数据
        /// </summary>
        /// <param name="id">数据ID</param>
        /// <returns></returns>
        public PlayerGameStats GetPlayerGameStatsSingle(int id)
        {
            return gameServer.GetPlayerGameStatsSingle(id);
        }

        /// <summary>
        /// 新增一条球员比赛数据
        /// </summary>
        /// <param name="str">球员数据字符串</param>
        /// <param name="gameId">比赛ID</param>
        /// <param name="playerId">球员ID</param>
        /// <returns></returns>
        public int InsertGamePlayerStats(PlayerGameStats pgs)
        {
            return gameServer.InsertGamePlayerStats(pgs);
        }

        public int UpdateGamePlayerStats(PlayerGameStats pgs)
        {
            return gameServer.UpdateGamePlayerStats(pgs);
        }
    }
}