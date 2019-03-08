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
        //protected List<Game> currentList = new List<Game>();
        protected List<GameModel> currentList = new List<GameModel>();
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
            /*
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
             */ 

            TeamBll tb = new TeamBll();
            GameBll gb = new GameBll();
            currentTeam = tb.GetSingleTeam(urlTeam);
            currentList = gb.GetGameListSingleTeam(currentTeam.Id);
            winTotal = gb.WinTotal;
            winHome = gb.WinHome;
            winAway = gb.WinAway;
            loseTotal = gb.LoseTotal;
            loseHome = gb.LoseHome;
            loseAway = gb.LoseAway;

            DateTime prevTime = new DateTime();
            string html = "";
            for (int i = 0; i < currentList.Count; i++)
            {
                if (currentList[i].Time.Month != prevTime.Month || currentList[i].Time.Year != prevTime.Year)
                {
                    html += "<div class='tsl-item'><div class='tsl-item-header'>" + currentList[i].Time.Year.ToString() + "年" + currentList[i].Time.Month.ToString() + "月</div><ul>";
                }
                html += "<li>";
                html += "<div class='tsl-i-date'>" + currentList[i].Time.Month.ToString() + "月" + currentList[i].Time.Day.ToString() + "日</div>";
                html += "<div class='tsl-i-time'>" + currentList[i].Time.ToString("HH:mm") + "</div>";
                html += "<div class='tsl-i-away'><div><img src='images/teams_logo/" + currentList[i].Away_E.ToLower() + ".png' /></div><span>" + currentList[i].Away + "</span></div>";
                html += "<div class='tsl-i-vs'></div>";
                html += "<div class='tsl-i-home'><div><img src='images/teams_logo/" + currentList[i].Home_E.ToLower() + ".png' /></div><span>" + currentList[i].Home + "</span></div>";
                if (currentList[i].AwayPoints == "-1" || currentList[i].HomePoints == "-1") html += "<div class='tsl-i-result'>未开始</div>";
                else
                {
                    if (currentList[i].Away_ID == currentTeam.Id)
                    {
                        html += Int32.Parse(currentList[i].AwayPoints) < Int32.Parse(currentList[i].HomePoints) ? "<div class='tsl-i-result tsl-lose'>" + currentList[i].AwayPoints + "-" + currentList[i].HomePoints + "</div>" : "<div class='tsl-i-result tsl-win'>" + currentList[i].AwayPoints + "-" + currentList[i].HomePoints + "</div>";
                    }
                    else if (currentList[i].Home_ID == currentTeam.Id)
                    {
                        html += Int32.Parse(currentList[i].AwayPoints) < Int32.Parse(currentList[i].HomePoints) ? "<div class='tsl-i-result tsl-win'>" + currentList[i].AwayPoints + "-" + currentList[i].HomePoints + "</div>" : "<div class='tsl-i-result tsl-lose'>" + currentList[i].AwayPoints + "-" + currentList[i].HomePoints + "</div>";
                    }
                }
                html += "</li>";
                if (i == currentList.Count - 1 || (currentList[i + 1].Time.Month != currentList[i].Time.Month || currentList[i + 1].Time.Year != currentList[i].Time.Year))
                {
                    html += "</ul></div>";
                }
                prevTime = DateTime.Parse(currentList[i].Time.ToString("d"));
            }
            TeamGameList.Text = html;
        }
    }
}