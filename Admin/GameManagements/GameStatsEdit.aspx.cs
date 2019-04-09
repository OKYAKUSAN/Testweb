using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestWeb.BLL;
using TestWeb.Model;

namespace TestWeb.Admin.GameManagements
{
    public partial class GameStatsEdit : System.Web.UI.Page
    {
        protected int statsId;
        protected string playerName;
        protected int playerId;
        protected int teamId;
        protected int playingTime;
        protected int points;
        protected int shots;
        protected int shotsHit;
        protected int threePoints;
        protected int threePointsHit;
        protected int freeThrow;
        protected int freeThrowHit;
        protected int offensiveRebound;
        protected int defensiveRebound;
        protected int block;
        protected int assists;
        protected int steals;
        protected int foul;
        protected int faults;
        protected bool starter;
        protected void Page_Load(object sender, EventArgs e)
        {
            statsId = Request.QueryString["statsId"] != null ? Int32.Parse(Request.QueryString["statsId"]) : 0;
            int gameId = Request.QueryString["id"] != null ? Int32.Parse(Request.QueryString["id"]) : 0;
            int away = Request.QueryString["away"] != null ? Int32.Parse(Request.QueryString["away"]) : 0;
            int home = Request.QueryString["home"] != null ? Int32.Parse(Request.QueryString["home"]) : 0;

            GameStatsLink.Text = "<a href='/Admin/GameManagements/GameStats.aspx?id=" + gameId.ToString() + "&away=" + away.ToString() + "&home=" + home.ToString() + "' target='rightFrame'>比赛数据</a>";
            BackBtn.Text = "<input type='button' value='返回' onclick=\"javascript:window.location='/Admin/GameManagements/GameStats.aspx?id=" + gameId.ToString() + "&away=" + away.ToString() + "&home=" + home.ToString() + "'\" />";
            GameStatsId.Text = "<input type='hidden' id='statsId' name='statsId' value='" + statsId.ToString() + "' /><input type='hidden' id='gameId' name='gameId' value='" + gameId.ToString() + "' />";
            AwayId.Text = "<input type='hidden' id='awayId' name='awayId' value='" + away.ToString() + "' />";
            HomeId.Text = "<input type='hidden' id='homeId' name='homeId' value='" + home.ToString() + "' />";

            PlayerBll pb = new PlayerBll();
            List<Player> playerList = pb.GetAllPlayer();
            string html = "";
            for (char i = 'A'; i <= 'Z'; i = (char)++i)
            {
                List<Player> wordPlayerList = GetWordPlayerList(playerList, i);
                html += "<div class='fixedPlayerList-item'><ul>";
                foreach (Player tempP in wordPlayerList)
                {
                    html += "<li>";
                    html += "<div class='fixedPlayerList-cName'>" + tempP.FirstName_C + "-" + tempP.LastName_C + "</div>";
                    html += "<div class='fixedPlayerList-eName'>" + tempP.FirstName_E + " " + tempP.LastName_E + "</div>";
                    html += "<span class='hide'>" + tempP.Id.ToString() + "</span>";
                    html += "</li>";
                }
                html += "</ul></div>";
            }
            PlayerList.Text = html;

            TeamBll tb = new TeamBll();
            Team tempTeam = new Team();
            html = "";
            tempTeam = tb.GetSingleTeam(away);
            html += "<option value='" + tempTeam.Id.ToString() + "'>" + tempTeam.CName + "</option>";
            tempTeam = tb.GetSingleTeam(home);
            html += "<option value='" + tempTeam.Id.ToString() + "'>" + tempTeam.CName + "</option>";
            GameTeam.Text = html;

            if (statsId == 0)
            {
                GameListEdit.Text = "新增数据";
            }
            else
            {
                GameListEdit.Text = "修改数据";
                GameBll gb = new GameBll();
                PlayerGameStats pgs = gb.GetPlayerGameStatsSingle(statsId);
                playerName = pgs.FirstName_C + "-" + pgs.LastName_C;
                playerId = pgs.PlayerId;
                teamId = pgs.TeamId;
                playingTime = pgs.PlayingTime;
                points = pgs.Points;
                shots = pgs.Shots;
                shotsHit = pgs.ShotsHit;
                threePoints = pgs.ThreePoints;
                threePointsHit = pgs.ThreePointsHit;
                freeThrow = pgs.FreeThrow;
                freeThrowHit = pgs.FreeThrowHit;
                offensiveRebound = pgs.OffensiveRebound;
                defensiveRebound = pgs.DefensiveRebound;
                block = pgs.Block;
                assists = pgs.Assists;
                steals = pgs.Steals;
                foul = pgs.Foul;
                faults = pgs.Faults;
                starter = pgs.Starter;
            }
        }

        private static List<Player> GetWordPlayerList(List<Player> list, char word)
        {
            List<Player> resultList = new List<Player>();
            foreach (Player tempP in list)
            {
                if (tempP.LastName_E[0] == word) resultList.Add(tempP);
            }
            return resultList;
        }
    }
}