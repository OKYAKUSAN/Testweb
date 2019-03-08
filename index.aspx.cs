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
        protected List<GameModel> todaygames = new List<GameModel>();

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

            GameBll gb = new GameBll();
            todaygames = gb.GetGameList();
        }
    }
}