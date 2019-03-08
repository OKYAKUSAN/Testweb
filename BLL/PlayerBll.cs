using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.DAL;
using TestWeb.Model;

namespace TestWeb.BLL
{
    public class PlayerBll
    {
        PlayerServer ps = new PlayerServer();
        List<Player> allPlayer = new List<Player>();

        public PlayerBll()
        {
            allPlayer = ps.GetAllPlayerList();
        }

        /// <summary>
        /// 获取所有球员
        /// </summary>
        /// <returns></returns>
        public List<Player> GetAllPlayer()
        {
            return allPlayer;
        }

        /// <summary>
        /// 获取球员总数
        /// </summary>
        /// <returns></returns>
        public int GetPlayerCount()
        {
            return allPlayer.Count;
        }

        /// <summary>
        /// 获取指定球员信息
        /// </summary>
        /// <param name="id">球员ID</param>
        /// <returns></returns>
        public Player GetPlayer(int id)
        {
            return ps.GetPlayer(id);
        }

        public void GetPlayerStats(int id)
        {
            PlayerServer ps = new PlayerServer();
            List<PlayerGameStats> statsList = new List<PlayerGameStats>();
            statsList = ps.GetPlayerStats(id);
            string season = "";
            string team = "";
            int count = statsList.Count;
            int games = 0;
            int starter = 0;
            int playingGame = 0;
            int points = 0;
            int shots = 0;
            int shotsHit = 0;
            int threePoints = 0;
            int threePointsHit = 0;
            int freeThrow = 0;
            int freeThrowHit = 0;
            int offensiveRebound = 0;
            int defensiveRebound = 0;
            int rebound = 0;
            int block = 0;
            int assists = 0;
            int steals = 0;
            int foul = 0;
            int faults = 0;
            for (int i = 0; i < count; i++)
            {
                if (season != statsList[i].Season || team != statsList[i].Team)
                {
                    games = 0;
                    starter = 0;
                    playingGame = 0;
                    points = 0;
                    shots = 0;
                    shotsHit = 0;
                    threePoints = 0;
                    threePointsHit = 0;
                    freeThrow = 0;
                    freeThrowHit = 0;
                    offensiveRebound = 0;
                    defensiveRebound = 0;
                    rebound = 0;
                    block = 0;
                    assists = 0;
                    steals = 0;
                    foul = 0;
                    faults = 0;
                }
                if (statsList[i].PlayingTime > 0)
                {
                    games++;
                    starter = statsList[i].Starter ? ++starter : starter;
                    playingGame += statsList[i].PlayingTime;
                    points += statsList[i].Points;
                    shots += statsList[i].Shots;
                    shotsHit += statsList[i].ShotsHit;
                    threePoints += statsList[i].ThreePoints;
                    threePointsHit += statsList[i].ThreePointsHit;
                    freeThrow += statsList[i].FreeThrow;
                    freeThrowHit += statsList[i].FreeThrowHit;
                    offensiveRebound += statsList[i].OffensiveRebound;
                    defensiveRebound += statsList[i].DefensiveRebound;
                    rebound += statsList[i].Rebound;
                    block += statsList[i].Block;
                    assists += statsList[i].Assists;
                    steals += statsList[i].Steals;
                    foul += statsList[i].Foul;
                    faults += statsList[i].Faults;
                }
                season = statsList[i].Season;
                team = statsList[i].Team;
            }
        }
    }
}