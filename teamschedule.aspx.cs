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

namespace TestWeb
{
    public partial class teamschedule : System.Web.UI.Page
    {
        protected Team currentTeam = new Team();
        protected List<Game> currentList = new List<Game>();
        protected int winTotal = 0;
        protected int winHome = 0;
        protected int winAway = 0;
        protected int loseTotal = 0;
        protected int loseHome = 0;
        protected int loseAway = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string urlTeam="";
            if (Request.QueryString["team"] != null) urlTeam = Request.QueryString["team"].ToString();
            else urlTeam = "warriors";

            TeamsRank rankList = new TeamsRank();
            TeamRanking teamRank = rankList.GetTeamRank(urlTeam);
            GamesList allGameList = new GamesList();
            currentList = allGameList.GetAllList(urlTeam);
            TeamsGroup teamGroup = new TeamsGroup();

            winTotal = teamRank.Win;
            winHome = teamRank.WinHome;
            winAway = teamRank.WinAway;
            loseTotal = teamRank.Lose;
            loseHome = teamRank.LoseHome;
            loseAway = teamRank.LoseAway;
            currentTeam = teamGroup.GetTeam(urlTeam);
            /*
            XmlDocument teamListXml = new XmlDocument();
            teamListXml.Load(Server.MapPath("xml/teamList.xml"));
            XmlNodeList teams = teamListXml.GetElementsByTagName("team");

            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].ChildNodes[2].InnerText == urlTeam)
                {
                    currentTeam.ECity = teams[i].ChildNodes[0].InnerText;
                    currentTeam.CCity = teams[i].ChildNodes[1].InnerText;
                    currentTeam.EName = teams[i].ChildNodes[2].InnerText;
                    currentTeam.CName = teams[i].ChildNodes[3].InnerText;
                    break;
                }
            }
            Page.Title = currentTeam.CName + " 赛程";

            XmlDocument gameListXml = new XmlDocument();
            gameListXml.Load(Server.MapPath("xml/gameList.xml"));
            XmlNodeList games = gameListXml.GetElementsByTagName("game");
            for (int j = 0; j < games.Count; j++)
            {
                if (games[j].ChildNodes[1].Attributes["eName"].Value == urlTeam || games[j].ChildNodes[2].Attributes["eName"].Value == urlTeam)
                {
                    Game tempGame = new Game();
                    tempGame.DateYear = Int32.Parse(games[j].Attributes[0].Value);
                    tempGame.DateMonth = Int32.Parse(games[j].Attributes[1].Value);
                    tempGame.DateDay = Int32.Parse(games[j].Attributes[2].Value);
                    tempGame.Time = games[j].ChildNodes[0].InnerText;
                    tempGame.Away = games[j].ChildNodes[1].InnerText;
                    tempGame.AwayEName = games[j].ChildNodes[1].Attributes["eName"].Value;
                    tempGame.Home = games[j].ChildNodes[2].InnerText;
                    tempGame.HomeEName = games[j].ChildNodes[2].Attributes["eName"].Value;
                    tempGame.Result = games[j].ChildNodes[3].InnerText;
                    currentList.Add(tempGame);
                }
            }

            for (int k = 0; k < currentList.Count; k++)
            {
                //isWinAt((Game)currentList[k], urlTeam);
                Game tempGame = new Game();
                tempGame = (Game)currentList[k];
                if (tempGame.Result.IndexOf("-") >= 0)
                {
                    String[] _result = tempGame.Result.Split('-');
                    int _awayScore = Int32.Parse(_result[0]);
                    int _homeScore = Int32.Parse(_result[1]);
                    if (tempGame.AwayEName == urlTeam)
                    {
                        if (_awayScore < _homeScore)
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
                    else
                    {
                        if (_awayScore < _homeScore)
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
             */
        }
        /*
        protected static void isWinAt(Game g,string teamName)
        {
            String[] _result = g.Result.Split('-');
            int _awayScore = Int32.Parse(_result[0]);
            int _homeScore = Int32.Parse(_result[1]);
            if (g.Away == teamName)
            {
                if (_awayScore < _homeScore)
                {
                }
            }
        }
         */
    }
}