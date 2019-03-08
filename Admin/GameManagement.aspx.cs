using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestWeb.BLL;
using TestWeb.Model;
using TestWeb.Helper;

namespace TestWeb.Admin
{
    public partial class GameManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int page = Request.QueryString["page"] != null ? Int32.Parse(Request.QueryString["page"].ToString()) : 1;
            string url = HttpContext.Current.Request.Url.AbsolutePath;

            GameBll gb = new GameBll();
            List<GameModel>allGameList = gb.GetGameList(true);
            int maxPage = allGameList.Count / 20 + (allGameList.Count % 20 > 0 ? 1 : 0);
            int showStartIndex = 20 * (page - 1);
            int showEndIndex = 20 * page > allGameList.Count - 1 ? allGameList.Count - 1 : 20 * page;
            string html = "";
            bool bgColor = true;
            for (int i = showStartIndex; i <= showEndIndex; i++)
            {
                html += "<tr class='tableBg_" + (bgColor ? "1" : "2") + "'>";
                bgColor = !bgColor;
                html += "<td>" + allGameList[i].Time.ToString("yyyy-MM-dd HH:mm") + "</td>";
                html += "<td>" + allGameList[i].Away + "</td>";
                html += "<td>" + allGameList[i].Home + "</td>";
                html += "<td></td>";
                html += "<td><a href='/Admin/GameEdit.aspx?id=" + allGameList[i].Id.ToString() + "'>编辑</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href='#'>赛果</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href='/Admin/GameDelete.aspx?id=" + allGameList[i].Id.ToString() + "'>删除</a></td>";
                html += "</tr>";
            }
            GameListTable.Text = html;
            PageNum.Text = HtmlHelper.PageNumControl(url, 12, 48);
        }
    }
}