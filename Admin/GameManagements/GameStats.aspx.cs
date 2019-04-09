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
    public partial class GameStats : System.Web.UI.Page
    {
        private static int away;
        private static int home;
        private static int gameId;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Request.QueryString["id"] != null ? Int32.Parse(Request.QueryString["id"]) : 0;
            int awayId = Request.QueryString["away"] != null ? Int32.Parse(Request.QueryString["away"]) : 0;
            int homeId = Request.QueryString["home"] != null ? Int32.Parse(Request.QueryString["home"]) : 0;
            gameId = id;
            away = awayId;
            home = homeId;
            GameStatsEditLink.Text = "<a href='/Admin/GameManagements/GameStatsEdit.aspx?id=" + id.ToString() + "&away=" + awayId.ToString() + "&home=" + homeId.ToString() + "' target='rightFrame'>添加数据</a>";
            GameBll gb = new GameBll();
            List<PlayerGameStats> resultList = gb.GetPlayerGameStats(id);
            TeamBll tb = new TeamBll();
            AwayTableHeader.Text = (tb.GetSingleTeam(awayId)).CName;
            HomeTableHeader.Text = (tb.GetSingleTeam(homeId)).CName;
            if (resultList.Count > 0)
            {
                string awayHtml = "";
                string homeHtml = "";
                bool awayTbg = true;
                bool homeTbg = true;
                int awayNum = 0;
                int homeNum = 0;
                foreach (PlayerGameStats pgs in resultList)
                {
                    if (pgs.TeamId == awayId)
                    {
                        awayNum++;
                        awayHtml += HtmlStr(awayTbg, awayNum, pgs);
                        awayTbg = !awayTbg;
                    }
                    else
                    {
                        homeNum++;
                        homeHtml += HtmlStr(homeTbg, homeNum, pgs);
                        homeTbg = !homeTbg;
                    }
                }
                AwayTable.Text = awayHtml;
                HomeTable.Text = homeHtml;
            }
        }

        private static string HtmlStr(bool tbg, int num, PlayerGameStats obj)
        {
            string html = "";
            html += tbg ? "<tr class='tbg1'>" : "<tr class='tbg2'>";
            html += "<td>" + num.ToString() + "</td>";
            html += "<td>" + obj.FirstName_C + "-" + obj.LastName_C + "<br />" + obj.FirstName_E + " " + obj.LastName_E + "</td>";
            html += "<td>" + obj.PlayingTime.ToString() + "</td>";
            html += "<td>" + (obj.Starter ? "●" : "") + "</td>";
            html += "<td>" + obj.Points.ToString() + "</td>";
            html += "<td>" + obj.ShotsHit.ToString() + " / " + obj.Shots.ToString() + "</td>";
            html += "<td>" + obj.ThreePointsHit.ToString() + " / " + obj.ThreePoints.ToString() + "</td>";
            html += "<td>" + obj.FreeThrowHit.ToString() + " / " + obj.FreeThrow.ToString() + "</td>";
            html += "<td>" + obj.Rebound.ToString() + "</td>";
            html += "<td>" + obj.OffensiveRebound.ToString() + "</td>";
            html += "<td>" + obj.DefensiveRebound.ToString() + "</td>";
            html += "<td>" + obj.Block.ToString() + "</td>";
            html += "<td>" + obj.Assists.ToString() + "</td>";
            html += "<td>" + obj.Steals.ToString() + "</td>";
            html += "<td>" + obj.Faults.ToString() + "</td>";
            html += "<td>" + obj.Foul.ToString() + "</td>";
            html += "<td><a href='/Admin/GameManagements/GameStatsEdit.aspx?statsId=" + obj.StatsId.ToString() + "&id=" + gameId.ToString() + "&away=" + away.ToString() + "&home=" + home.ToString() + "' target='rightFrame'>编辑</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href='?statsId=" + obj.StatsId.ToString() + "' target='rightFrame' onclick='javascript:return confirm(\"确定要删除吗？\"))'>删除</a></td>";
            html += "</tr>";
            return html;
        }
    }
}