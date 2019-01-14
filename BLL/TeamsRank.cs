using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.DAL;
using TestWeb.Model;

namespace TestWeb.BLL
{
    public class TeamsRank
    {
        private List<Team> teamList = new List<Team>();
        private List<Game> gameList = new List<Game>();
        private List<TeamRanking> rankList = new List<TeamRanking>();

        public TeamsRank()
        {
            TeamListXml _teamData = new TeamListXml();
            teamList = _teamData.GetTeamList();

            GameListXml _gameData = new GameListXml();
            gameList = _gameData.GetGameList();

            int _win = 0;
            int _lose = 0;
            int _winAway = 0;
            int _loseAway = 0;
            int _winHome = 0;
            int _loseHome = 0;
            foreach (Team _team in teamList)
            {
                _win = 0;
                _lose = 0;
                _winAway = 0;
                _loseAway = 0;
                _winHome = 0;
                _loseHome = 0;
                TeamRanking _tempRanking = new TeamRanking();
                foreach (Game _game in gameList)
                {
                    if (_game.Result.IndexOf("-") >= 0)
                    {
                        string[] _result = _game.Result.Split('-');
                        int _awayScore = Int32.Parse(_result[0]);
                        int _homeScore = Int32.Parse(_result[1]);
                        if (_game.AwayEName == _team.EName)
                        {
                            if (_awayScore < _homeScore)
                            {
                                _lose++;
                                _loseAway++;
                            }
                            else
                            {
                                _win++;
                                _winAway++;
                            }
                        }
                        else if (_game.HomeEName == _team.EName)
                        {
                            if (_awayScore < _homeScore)
                            {
                                _win++;
                                _winHome++;
                            }
                            else
                            {
                                _lose++;
                                _loseHome++;
                            }
                        }
                    }
                }
                _tempRanking.EName = _team.EName;
                _tempRanking.CName = _team.CName;
                _tempRanking.Conference = _team.Conference;
                _tempRanking.Zone = _team.Zone;
                _tempRanking.Win = _win;
                _tempRanking.Lose = _lose;
                _tempRanking.WinAway = _winAway;
                _tempRanking.LoseAway = _loseAway;
                _tempRanking.WinHome = _winHome;
                _tempRanking.LoseHome = _loseHome;
                _tempRanking.WinDifferential = (float)(_win - _lose);
                rankList.Add(_tempRanking);
            }
        }

        private static List<TeamRanking> GetRankList(string words,List<TeamRanking> allList)
        {
            List<TeamRanking> _resultList = new List<TeamRanking>();

            //List<TeamRanking> _tempList = new List<TeamRanking>();
            if (words == "西部联盟" || words == "东部联盟")
            {
                foreach (TeamRanking _tempR in allList)
                {
                    if (_tempR.Conference == words) _resultList.Add(_tempR);
                }
            }
            else
            {
                foreach (TeamRanking _tempR in allList)
                {
                    if (_tempR.Zone == words) _resultList.Add(_tempR);
                }
            }
            _resultList.Sort(new Comparison<TeamRanking>(Compare));

            return _resultList;
        }

        private static int Compare(TeamRanking x, TeamRanking y)
        {
            if (x.WinDifferential > y.WinDifferential) return -1;
            else if (x.WinDifferential < y.WinDifferential) return 1;
            else
            {
                if (x.Win + x.Lose > y.Win + y.Lose) return 1;
                else if (x.Win + x.Lose < y.Win + y.Lose) return -1;
                else
                {
                    if (x.Win > y.Win) return -1;
                    else if (x.Win < y.Win) return 1;
                    else return 0;
                }
            }
        }

        public List<TeamRanking> GetWesternConference()
        {
            List<TeamRanking> resultList = new List<TeamRanking>();
            resultList = GetRankList("西部联盟", rankList);
            return resultList;
        }

        public List<TeamRanking> GetEasternConference()
        {
            List<TeamRanking> resultList = new List<TeamRanking>();
            resultList = GetRankList("东部联盟", rankList);
            return resultList;
        }

        public List<TeamRanking> GetPacificDivision()
        {
            List<TeamRanking> resultList = new List<TeamRanking>();
            resultList = GetRankList("太平洋赛区", rankList);
            return resultList;
        }

        public List<TeamRanking> GetNorthwestDivision()
        {
            List<TeamRanking> resultList = new List<TeamRanking>();
            resultList = GetRankList("西北赛区", rankList);
            return resultList;
        }

        public List<TeamRanking> GetSouthwestDivision()
        {
            List<TeamRanking> resultList = new List<TeamRanking>();
            resultList = GetRankList("西南赛区", rankList);
            return resultList;
        }

        public List<TeamRanking> GetSoutheastDivision()
        {
            List<TeamRanking> resultList = new List<TeamRanking>();
            resultList = GetRankList("东南赛区", rankList);
            return resultList;
        }

        public List<TeamRanking> GetCentralDivision()
        {
            List<TeamRanking> resultList = new List<TeamRanking>();
            resultList = GetRankList("中部赛区", rankList);
            return resultList;
        }

        public List<TeamRanking> GetAtlanticDivision()
        {
            List<TeamRanking> resultList = new List<TeamRanking>();
            resultList = GetRankList("大西洋赛区", rankList);
            return resultList;
        }

        public TeamRanking GetTeamRank(string team)
        {
            TeamRanking _resultRank = new TeamRanking();
            foreach (TeamRanking _tempRank in rankList)
            {
                if (_tempRank.EName == team) _resultRank = _tempRank;
            }
            return _resultRank;
        }
    }
}