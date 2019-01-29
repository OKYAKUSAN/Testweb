using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using TestWeb.Model;
using TestWeb.BLL;
using TestWeb.DAL;

namespace TestWeb
{
    public partial class index : System.Web.UI.Page
    {
        protected List<TeamRanking> westernConference = new List<TeamRanking>();
        protected List<TeamRanking> easternConference = new List<TeamRanking>();
        protected List<TeamRanking> pacificDivision = new List<TeamRanking>();
        protected List<TeamRanking> northwestDivision = new List<TeamRanking>();
        protected List<TeamRanking> southwestDivision = new List<TeamRanking>();
        protected List<TeamRanking> southeastDivision = new List<TeamRanking>();
        protected List<TeamRanking> centralDivision = new List<TeamRanking>();
        protected List<TeamRanking> atlanticDivision = new List<TeamRanking>();
        protected List<Game> todayGames = new List<Game>();
        protected DateTime nowTime = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
            TeamsRank rankList = new TeamsRank();
            westernConference = rankList.GetWesternConference();
            easternConference = rankList.GetEasternConference();
            pacificDivision = rankList.GetPacificDivision();
            northwestDivision = rankList.GetNorthwestDivision();
            southwestDivision = rankList.GetSouthwestDivision();
            southeastDivision = rankList.GetSoutheastDivision();
            centralDivision = rankList.GetCentralDivision();
            atlanticDivision = rankList.GetAtlanticDivision();

            GamesList allGamesList = new GamesList();
            todayGames = allGamesList.GetTodayGames(nowTime);
            /*
            XmlDocument gameListXml = new XmlDocument();
            gameListXml.Load(Server.MapPath("xml/gameList.xml"));
            XmlNodeList games = gameListXml.GetElementsByTagName("game");

            XmlDocument teamListXml = new XmlDocument();
            teamListXml.Load(Server.MapPath("xml/teamList.xml"));
            XmlNodeList teams = teamListXml.GetElementsByTagName("team");

            ArrayList allTeamRankingList = GetTeamRankingData(teams, games);

            for (int i = 0; i < allTeamRankingList.Count; i++)
            {
                TeamRanking currentTR = (TeamRanking)allTeamRankingList[i];
                if (currentTR.Conference == "西部联盟") westernConference.Add(currentTR);
                else easternConference.Add(currentTR);

                switch (currentTR.Zone)
                {
                    case "太平洋赛区":
                        pacificDivision.Add(currentTR);
                        break;
                    case "西北赛区":
                        northwestDivision.Add(currentTR);
                        break;
                    case "西南赛区":
                        southwestDivision.Add(currentTR);
                        break;
                    case "东南赛区":
                        southeastDivision.Add(currentTR);
                        break;
                    case "中部赛区":
                        centralDivision.Add(currentTR);
                        break;
                    case "大西洋赛区":
                        atlanticDivision.Add(currentTR);
                        break;
                    default:
                        break;
                }
            }

            westernConference = ListSort(westernConference);
            easternConference = ListSort(easternConference);
            pacificDivision = ListSort(pacificDivision);
            northwestDivision = ListSort(northwestDivision);
            southwestDivision = ListSort(southwestDivision);
            southeastDivision = ListSort(southeastDivision);
            centralDivision = ListSort(centralDivision);
            atlanticDivision = ListSort(atlanticDivision);
             */
        }
        /*
        private static ArrayList GetTeamGameList(string teamname, XmlNodeList allGames)
        {
            ArrayList teamGameList = new ArrayList();
            for (int i = 0; i < allGames.Count; i++)
            {
                if (allGames[i].ChildNodes[1].Attributes["eName"].Value == teamname || allGames[i].ChildNodes[2].Attributes["eName"].Value == teamname)
                {
                    Game tempGame = new Game();
                    tempGame.DateYear = Int32.Parse(allGames[i].Attributes[0].Value);
                    tempGame.DateMonth = Int32.Parse(allGames[i].Attributes[1].Value);
                    tempGame.DateDay = Int32.Parse(allGames[i].Attributes[2].Value);
                    tempGame.Time = allGames[i].ChildNodes[0].InnerText;
                    tempGame.Away = allGames[i].ChildNodes[1].InnerText;
                    tempGame.AwayEName = allGames[i].ChildNodes[1].Attributes["eName"].Value;
                    tempGame.Home = allGames[i].ChildNodes[2].InnerText;
                    tempGame.HomeEName = allGames[i].ChildNodes[2].Attributes["eName"].Value;
                    tempGame.Result = allGames[i].ChildNodes[3].InnerText;
                    teamGameList.Add(tempGame);
                }
            }

            return teamGameList;
        }

        private static ArrayList GetTeamRankingData(XmlNodeList teamList, XmlNodeList gameList)
        {
            ArrayList rankingList = new ArrayList();
            int win = 0;
            int lose = 0;
            for (int i = 0; i < teamList.Count; i++)
            {
                TeamRanking tempTeamRanking = new TeamRanking();
                win = 0;
                lose = 0;
                ArrayList tempTeamGameList = new ArrayList();
                tempTeamGameList = GetTeamGameList(teamList[i].ChildNodes[2].InnerText, gameList);
                for (int j = 0; j < tempTeamGameList.Count; j++)
                {
                    Game tempGame = (Game)tempTeamGameList[j];
                    if (tempGame.Result.IndexOf('-') >= 0)
                    {
                        String[] _result = tempGame.Result.Split('-');
                        int _awayScore = Int32.Parse(_result[0]);
                        int _homeScore = Int32.Parse(_result[1]);
                        if (teamList[i].ChildNodes[2].InnerText == tempGame.AwayEName)
                        {
                            if (_awayScore < _homeScore) lose++;
                            else win++;
                        }
                        else
                        {
                            if (_awayScore < _homeScore) win++;
                            else lose++;
                        }
                    }
                }
                tempTeamRanking.EName = teamList[i].ChildNodes[2].InnerText;
                tempTeamRanking.CName = teamList[i].ChildNodes[3].InnerText;
                tempTeamRanking.Conference = teamList[i].ChildNodes[4].InnerText;
                tempTeamRanking.Zone = teamList[i].ChildNodes[5].InnerText;
                tempTeamRanking.Win = win;
                tempTeamRanking.Lose = lose;
                tempTeamRanking.WinDifferential = win - lose;
                rankingList.Add(tempTeamRanking);
            }
            return rankingList;
        }

        private static ArrayList ListSort(ArrayList list)
        {
            int _count = list.Count;
            ArrayList resultList = new ArrayList();
            for (int i = 0; i < _count; i++)
            {
                TeamRanking sourceTeamRanking = (TeamRanking)list[i];
                if (i != 0)
                {
                    int _resultCount = resultList.Count;
                    for (int j = 0; j < _resultCount; j++)
                    {
                        TeamRanking resultTeamRanking = (TeamRanking)resultList[j];
                        if (sourceTeamRanking.WinDifferential >= resultTeamRanking.WinDifferential)
                        {
                            //resultList.Insert(j, sourceTeamRanking);
                            //break;
                            if (sourceTeamRanking.WinDifferential == resultTeamRanking.WinDifferential)
                            {
                                if (sourceTeamRanking.Win > resultTeamRanking.Win)
                                {
                                    resultList.Insert(j, sourceTeamRanking);
                                    break;
                                }
                                else if (sourceTeamRanking.Win == resultTeamRanking.Win)
                                {
                                    if (sourceTeamRanking.Lose <= resultTeamRanking.Lose)
                                    {
                                        resultList.Insert(j, sourceTeamRanking);
                                        break;
                                    }
                                    else
                                    {
                                        if (j == _resultCount - 1) resultList.Add(sourceTeamRanking);
                                        else continue;
                                    }
                                }
                                else
                                {
                                    if (j == _resultCount - 1) resultList.Add(sourceTeamRanking);
                                    else continue;
                                }
                            }
                            else
                            {
                                resultList.Insert(j, sourceTeamRanking);
                                break;
                            }
                        }
                        else
                        {
                            if (j == _resultCount - 1) resultList.Add(sourceTeamRanking);
                            else continue;
                        }
                    }
                }
                else
                {
                    resultList.Add(sourceTeamRanking);
                }
            }

            return resultList;
        }
         */
    }
}