using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestWeb.BLL;
using TestWeb.Model;

namespace TestWeb.Admin
{
    public partial class GameEdit : System.Web.UI.Page
    {
        protected int Id;
        protected int Year;
        protected int Month;
        protected int Day;
        protected int Hour;
        protected int Minute;
        protected string Season;
        protected int Away;
        protected int Home;
        protected void Page_Load(object sender, EventArgs e)
        {
            Id = Request.QueryString["id"] != null && Int32.Parse(Request.QueryString["id"].ToString()) > 0 ? Int32.Parse(Request.QueryString["id"].ToString()) : 0;
            if (Id > 0)
            {
                GameBll gb = new GameBll();
                GameModel gameObj = gb.GetSingleGame(Id);
                Year = gameObj.Time.Year;
                Month = gameObj.Time.Month;
                Day = gameObj.Time.Day;
                Hour = gameObj.Time.Hour;
                Minute = gameObj.Time.Minute;
                Season = gameObj.Season;
                Away = gameObj.Away_ID;
                Home = gameObj.Home_ID;
            }
            TeamBll tb = new TeamBll();
            List<Team> teamList = tb.GetTeamList();
            string html = "";
            string zone = "";
            int count = teamList.Count;
            for (int i = 0; i < count; i++)
            {
                if (teamList[i].Zone != zone)
                {
                    html += "<optgroup label='" + teamList[i].Zone + "'>";
                    zone = teamList[i].Zone;
                }
                html += "<option value='" + teamList[i].Id.ToString() + "'>" + teamList[i].CName + "</option>";
                if (i == count - 1 || teamList[i + 1].Zone != zone)
                {
                    html += "</optgroup>";
                }
            }
            AwaySelect.Text = html;
            HomeSelect.Text = html;
        }
    }
}