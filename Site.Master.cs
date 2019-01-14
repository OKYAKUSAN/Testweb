using System;
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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        //protected string cssUrl = "";
        protected List<Team> pacificDivision = new List<Team>();
        protected List<Team> northwestDivision = new List<Team>();
        protected List<Team> southwestDivision = new List<Team>();
        protected List<Team> southeastDivision = new List<Team>();
        protected List<Team> centralDivision = new List<Team>();
        protected List<Team> atlanticDivision = new List<Team>();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            cssUrl = "~/Styles/master.css?v=" + Guid.NewGuid();
            string text = "";
            XmlDocument teamListXml = new XmlDocument();
            teamListXml.Load(Server.MapPath("xml/teamList.xml"));
            XmlNodeList teamNameList = teamListXml.GetElementsByTagName("team");

            int tempIndex = 0;
            int tempBackground = 1;
            for (int i = 0; i < 6; i++)
            {
                if(i!=3) text += "<div class='area'><div class='area-header'>" + divisionArea(i) + "</div>";
                else text += "<div class='area areaLine'><div class='area-header'>" + divisionArea(i) + "</div>";
                tempBackground = 1;
                for (int j = 0; j < 5; j++)
                {
                    if(tempBackground%2 != 0) text += "<a href='teamschedule.aspx?team=" + teamNameList[tempIndex].ChildNodes[2].InnerText + "'><div><img src='images/teams_logo/" + teamNameList[tempIndex].ChildNodes[2].InnerText + ".png' alt='" + teamNameList[tempIndex].ChildNodes[2].InnerText + "' /></div><span>" + teamNameList[tempIndex].ChildNodes[3].InnerText + "</span></a>";
                    else text += "<a href='teamschedule.aspx?team=" + teamNameList[tempIndex].ChildNodes[2].InnerText + "' class='area_bg'><div><img src='images/teams_logo/" + teamNameList[tempIndex].ChildNodes[2].InnerText + ".png' alt='" + teamNameList[tempIndex].ChildNodes[2].InnerText + "' /></div><span>" + teamNameList[tempIndex].ChildNodes[3].InnerText + "</span></a>";
                    tempIndex++;
                    tempBackground++;
                }
                text += "</div>";
            }

            teamList.Text = text;
             */

            TeamsGroup teamsGroup = new TeamsGroup();
            pacificDivision = teamsGroup.GetGroup("太平洋赛区");
            northwestDivision = teamsGroup.GetGroup("西北赛区");
            southwestDivision = teamsGroup.GetGroup("西南赛区");
            southeastDivision = teamsGroup.GetGroup("东南赛区");
            centralDivision = teamsGroup.GetGroup("中部赛区");
            atlanticDivision = teamsGroup.GetGroup("大西洋赛区");
        }

        /*
        private static string divisionArea(int i)
        {
            switch (i)
            {
                case 0:
                    return "太平洋赛区";
                case 1:
                    return "西北赛区";
                case 2:
                    return "西南赛区";
                case 3:
                    return "东南赛区";
                case 4:
                    return "中部赛区";
                default:
                    return "大西洋赛区";
            }
        }
         */
    }
}
