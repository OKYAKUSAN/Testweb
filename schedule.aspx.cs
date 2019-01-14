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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // head
            string time = "";
            time = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月";
            CalendarAsp.Text = time;

            // claendar
            string claendarList = "";
            DateTime claendar = new DateTime();
            claendar = DateTime.Parse("2018-10-01");
            int maxDate = 30;
            int tempYear;
            int tempMonth;
            bool lastDay = false;
            for (int i = 0; i < 7; i++)
            {
                tempYear = claendar.Year;
                tempMonth = claendar.Month;
                lastDay = false;
                if (tempMonth == 1 || tempMonth == 3 || tempMonth == 5 || tempMonth == 7 || tempMonth == 8 || tempMonth == 10 || tempMonth == 12) maxDate = 31;
                else if (tempMonth == 4 || tempMonth == 6 || tempMonth == 9 || tempMonth == 11) maxDate = 30;
                else if (tempMonth == 2)
                {
                    if ((tempYear % 4 == 0 && tempYear % 100 != 0) || tempYear % 400 == 0) maxDate = 29;
                    else maxDate = 28;
                }
                claendarList += "<div class='calendar-list-item'><div class='calendar-l-i-header'>" + claendar.Year.ToString() + "年" + claendar.Month.ToString() + "月</div><table><col style='width:14.2%;' /><col style='width:14.2%;' /><col style='width:14.2%;' /><col style='width:14.2%;' /><col style='width:14.2%;' /><col style='width:14.2%;' /><col style='' /><tr class='bgEEE'><th>日</th><th>一</th><th>二</th><th>三</th><th>四</th><th>五</th><th>六</th></tr>";
                do
                {
                    claendarList += "<tr>";
                    for (int j = 0; j < 7; j++)
                    {
                        if ((int)claendar.DayOfWeek == j)
                        {
                            claendarList += "<td>" + claendar.Day.ToString() + "</td>";
                            if (claendar.Day < maxDate) claendar = claendar.AddDays(1);
                            else if (claendar.Day == maxDate) lastDay = true;
                        }
                        else
                        {
                            claendarList += "<td></td>";
                        }
                    }
                    claendarList += "</tr>";
                } while (!lastDay);
                claendarList += "</table></div>";
                claendar = claendar.AddDays(1);
            }
            ClaendarList.Text = claendarList;

            // gameList
            /*
            XmlTextReader gameListXml = new XmlTextReader("xml/gameList.xml");
            string testGame = "";
            while (gameListXml.Read())
            {
                testGame += gameListXml.GetAttribute("year");
            }
            gameList.Text = testGame;
            */
            GamesList allGameList = new GamesList();
            List<Game> gameListObj = allGameList.GetAllList();
            /*
            XmlDocument gameListXml = new XmlDocument();
            gameListXml.Load(Server.MapPath("xml/gameList.xml"));
            XmlNodeList gameL = gameListXml.GetElementsByTagName("game");
            Game[] gameListObj = new Game[gameL.Count];
            for (int m = 0; m < gameL.Count; m++)
            {
                gameListObj[m] = new Game();
                gameListObj[m].DateYear = Int32.Parse(gameL[m].Attributes[0].Value);
                gameListObj[m].DateMonth = Int32.Parse(gameL[m].Attributes[1].Value);
                gameListObj[m].DateDay = Int32.Parse(gameL[m].Attributes[2].Value);
                gameListObj[m].Time = gameL[m].ChildNodes[0].InnerText;
                gameListObj[m].Away = gameL[m].ChildNodes[1].InnerText;
                gameListObj[m].AwayEName = gameL[m].ChildNodes[1].Attributes["eName"].Value;
                gameListObj[m].Home = gameL[m].ChildNodes[2].InnerText;
                gameListObj[m].HomeEName = gameL[m].ChildNodes[2].Attributes["eName"].Value;
                gameListObj[m].Result = gameL[m].ChildNodes[3].InnerText;
            }
             * */
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int prevYear = year;
            int prevMonth = month;
            int prevDay = 0;
            int nextYear = year;
            int nextMonth = month;
            int nextDay = 0;
            string html = "";
            //gameList.Text = gameL[1].Attributes[1].Name;
            for (int i = 0; i < gameListObj.Count; i++)
            {
                if (month == gameListObj[i].DateMonth && year == gameListObj[i].DateYear)
                {
                    if ((i + 1) < gameListObj.Count)
                    {
                        nextYear = gameListObj[i + 1].DateYear;
                        nextMonth = gameListObj[i + 1].DateMonth;
                        nextDay = gameListObj[i + 1].DateDay;
                    }
                    else
                    {
                        nextDay++;
                    }
                    if (gameListObj[i].DateDay != prevDay)
                    {
                        html += "<div class='gamelist-item'><div class='gamelist-item-header'>" + gameListObj[i].DateMonth.ToString() + "月" + gameListObj[i].DateDay + "日</div><ul>";
                    }
                    html += "<li>";
                    html += "<div class='gamelist-i-time'>" + gameListObj[i].Time + "</div>";
                    html += "<div class='gamelist-i-away'><div><img src='images/teams_logo/" + gameListObj[i].AwayEName + ".png' /></div><span>" + gameListObj[i].Away + "</span></div>";
                    html += "<div class='gamelist-i-vs'></div>";
                    html += "<div class='gamelist-i-home'><div><img src='images/teams_logo/" + gameListObj[i].HomeEName + ".png' /></div><span>" + gameListObj[i].Home + "</span></div>";
                    html += "<div class='gamelist-i-result'>" + gameListObj[i].Result + "</div>";
                    html += "</li>";
                    if ((i + 1) >= gameListObj.Count || (nextDay != gameListObj[i].DateDay || nextMonth != gameListObj[i].DateMonth || nextYear != gameListObj[i].DateYear))
                    {
                        html += "</ul></div>";
                    }
                    prevYear = gameListObj[i].DateYear;
                    prevMonth = gameListObj[i].DateMonth;
                    prevDay = gameListObj[i].DateDay;
                }
            }
            gameList.Text = html;
        }
    }
}
