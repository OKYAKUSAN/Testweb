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
    public partial class GameStatsSend : System.Web.UI.Page
    {
        protected string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            PlayerGameStats pgs = new PlayerGameStats();
            pgs.StatsId = Request.Form["statsId"] != null ? Int32.Parse(Request.Form["statsId"]) : 0;
            pgs.PlayerId = Int32.Parse(Request.Form["gamePlayerId"]);
            pgs.GameId = Int32.Parse(Request.Form["gameId"]);
            pgs.AwayTeamId = Int32.Parse(Request.Form["awayId"]);
            pgs.HomeTeamId = Int32.Parse(Request.Form["homeId"]);
            pgs.TeamId = Int32.Parse(Request.Form["gameTeam"]);
            pgs.PlayingTime = Int32.Parse(Request.Form["gamePlayingTime"]);
            pgs.Points = Int32.Parse(Request.Form["gamePoints"]);
            pgs.Shots = Int32.Parse(Request.Form["gameShots"]);
            pgs.ShotsHit = Int32.Parse(Request.Form["gameShotsHit"]);
            pgs.ThreePoints = Int32.Parse(Request.Form["gameThreePoints"]);
            pgs.ThreePointsHit = Int32.Parse(Request.Form["gameThreePointsHit"]);
            pgs.FreeThrow = Int32.Parse(Request.Form["gameFreeThrow"]);
            pgs.FreeThrowHit = Int32.Parse(Request.Form["gameFreeThrowHit"]);
            pgs.OffensiveRebound = Int32.Parse(Request.Form["gameOffensiveRebound"]);
            pgs.DefensiveRebound = Int32.Parse(Request.Form["gameDefensiveRebound"]);
            pgs.Block = Int32.Parse(Request.Form["gameBlock"]);
            pgs.Assists = Int32.Parse(Request.Form["gameAssists"]);
            pgs.Steals = Int32.Parse(Request.Form["gameSteals"]);
            pgs.Foul = Int32.Parse(Request.Form["gameFoul"]);
            pgs.Faults = Int32.Parse(Request.Form["gameFaults"]);
            pgs.Starter = Request.Form["gameStarter"] == "checked" ? true : false;
            str += "/Admin/GameManagements/GameStats.aspx?id=" + pgs.GameId.ToString() + "&away=" + pgs.AwayTeamId.ToString() + "&home=" + pgs.HomeTeamId.ToString();
            GameStatsLink.Text = "<a href='" + str + "' target='rightFrame'>这里</a>";
            GameBll gb = new GameBll();
            int result;
            if (pgs.StatsId == 0)
            {
                result = gb.InsertGamePlayerStats(pgs);
                if (result == -1) Msg.Text = "添加未成功，记录已存在！";
                else Msg.Text = "添加成功！";
            }
            else
            {
                result = gb.UpdateGamePlayerStats(pgs);
                if (result == 0) Msg.Text = "修改失败，没有此记录！";
                else Msg.Text = "修改成功！";
            }
        }
    }
}