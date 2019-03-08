using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestWeb.BLL;
using TestWeb.Model;
using TestWeb.Helper;

namespace TestWeb.Admin.GameManagements
{
    public partial class GameList : System.Web.UI.Page
    {
        protected List<GameModel> showList = new List<GameModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            GameBll gb = new GameBll();
            List<GameModel> gameList = gb.GetGameList(true);
            int showListCount = 15;
            string url = HttpContext.Current.Request.Url.AbsolutePath;
            int page = Request.QueryString["page"] == null ? 1 : Int32.Parse(Request.QueryString["page"]);
            int maxPage = gameList.Count % showListCount == 0 ? gameList.Count / showListCount : gameList.Count / showListCount + 1;
            PageNum.Text = HtmlHelper.PageNumAdminControl(url, "rightFrame", page, maxPage);

            int startShowIndex = (page - 1) * 15;
            int endShowIndex = page == maxPage ? gameList.Count - 1 : page * 15 - 1;
            string html = "";
            bool tbg = true;
            for (int i = startShowIndex; i <= endShowIndex; i++)
            {
                html += tbg ? "<tr class='tbg1'>" : "<tr class='tbg2'>";
                html += "<td>" + (i + 1).ToString() + "</td>";
                html += "<td>" + gameList[i].Time.ToString("yyyy-MM-dd HH:mm") + "</td>";
                html += "<td>" + gameList[i].Away + "</td>";
                html += "<td>" + gameList[i].Home + "</td>";
                html += "<td></td>";
                html += "<td>";
                html += "<a href='/Admin/GameManagements/GameEdit.aspx?id=" + gameList[i].Id.ToString() + "' target='rightFrame'>编辑</a>";
                html += "&nbsp;&nbsp;|&nbsp;&nbsp;<a href='/Admin/GameManagements/GameStats.aspx?id=" + gameList[i].Id.ToString() + "&away=" + gameList[i].Away_ID.ToString() + "&home=" + gameList[i].Home_ID.ToString() + "' target='rightFrame'>比赛数据</a>";
                html += "&nbsp;&nbsp;|&nbsp;&nbsp;<a href='/Admin/GameManagements/GameDelete.aspx?id=" + gameList[i].Id.ToString() + "' target='rightFrame' onclick=\"javascript:return confirm('确定要删除吗？')\">删除</a>";
                html += "</td>";
                html += "</tr>";
                tbg = !tbg;
            }
            GameListTable.Text = html;
        }
    }
}