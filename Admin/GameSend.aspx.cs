using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestWeb.BLL;

namespace TestWeb.Admin
{
    public partial class GameSend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string str = "";
            str += Convert.ToString(Request.Form["gameYear"]);
            str += "-" + Convert.ToString(Request.Form["gameMonth"]);
            str += "-" + Convert.ToString(Request.Form["gameDay"]);
            str += " " + Convert.ToString(Request.Form["gameHour"]);
            str += ":" + Convert.ToString(Request.Form["gameMinute"]);
            DateTime time = DateTime.Parse(str);
            string season = Convert.ToString(Request.Form["gameSeason"]);
            string away = Convert.ToString(Request.Form["gameAway"]);
            string home = Convert.ToString(Request.Form["gameHome"]);
            int id = Request.Form["gameId"] != null ? Int32.Parse(Request.Form["gameId"]) : 0;

            GameBll gb = new GameBll();
            int returnId = 0;
            int returnRows = 0;
            if (id > 0)
            {
                returnRows = gb.UpdateGame(id, season, time, away, home);
                Msg.Text = "修改成功！";
            }
            else
            {
                returnId = gb.InsertNewGame(season, time, away, home);
                if (returnId != -1)
                {
                    Msg.Text = "提交成功！";
                }
                else
                {
                    Msg.Text = "提交失败，这场比赛已存在记录！";
                }
            }
        }
    }
}