<%@ Page Title="赛程" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="teamschedule.aspx.cs" Inherits="TestWeb.teamschedule" %>
<%@ Import Namespace="TestWeb.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="teamschedule-header">
        <div class="teamlogo fl">
            <div class="teamlogo-img fl">
                <% 
                    string team = "";
                    if (Request.QueryString["team"] != null) team = Request.QueryString["team"].ToString();
                    else team = "warriors";
                    if (team != "" && team != null) Response.Write("<img src='/images/teams_logo/b_" + team + ".svg' alt='' />");
                    else Response.Write("<img src='/images/teams_logo/b_warriors.svg' alt='' />");
                %>
            </div>
            <div class="teamlogo-info fl">
                <div class="teamlogo-cname"><%= currentTeam.CCity + "&nbsp;&nbsp;&nbsp;&nbsp;" + currentTeam.CName%></div>
                <div class="teamlogo-ename"><%= currentTeam.ECity + "&nbsp;&nbsp;&nbsp;&nbsp;" + currentTeam.EName%></div>
            </div>
        </div>
        <div class="teamrecord fl">
            <table class="teamrecord-table">
                <colgroup>
                    <col style="width:20%;" />
                    <col style="width:40%;" />
                    <col style="width:40%;" />
                </colgroup>
                <tr>
                    <th></th><th>胜负场</th><th>胜率</th>
                </tr>
                <tr>
                    <th>总场</th>
                    <td class="record-total"><% Response.Write((winTotal.ToString() + "-" + loseTotal.ToString())); %></td>
                    <td>
                        <%
                            if (winTotal + loseTotal != 0)
                            {
                                double totalProbability = Math.Round(((double)winTotal / ((double)winTotal + (double)loseTotal) * 100), 1);
                                Response.Write(totalProbability.ToString() + "%");
                            }
                            else
                            {
                                Response.Write("-");
                            }
                        %>
                    </td>
                </tr>
                <tr>
                    <th>主场</th>
                    <td class="record-home"><% Response.Write(winHome.ToString() + "-" + loseHome.ToString()); %></td>
                    <td>
                        <%
                            if (winHome + loseHome != 0)
                            {
                                double homeProbability = Math.Round(((double)winHome / ((double)winHome + (double)loseHome) * 100), 1);
                                Response.Write(homeProbability.ToString() + "%");
                            }
                            else
                            {
                                Response.Write("-");
                            }
                        %>
                    </td>
                </tr>
                <tr>
                    <th>客场</th>
                    <td class="record-away"><% Response.Write(winAway.ToString() + "-" + loseAway.ToString()); %></td>
                    <td>
                        <% 
                            if (winAway + loseAway != 0)
                            {
                                double awayProbability = Math.Round(((double)winAway / ((double)winAway + (double)loseAway) * 100), 1);
                                Response.Write(awayProbability.ToString() + "%");
                            }
                            else
                            {
                                Response.Write("-");
                            }
                        %>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <!-- gamelist -->
    <%--<div class="teamschedulelist">
        <%
            int prevYear = 0;
            int prevMonth = 0;
            int nextYear = 0;
            int nextMonth = 0;
            for (int i = 0; i < currentList.Count; i++)
            {
                Game tempObj = currentList[i];
                if (i + 1 < currentList.Count)
                {
                    nextYear = tempObj.DateYear;
                    nextMonth = tempObj.DateMonth;
                }
                else if (i + 1 == currentList.Count)
                {
                    nextYear = 0;
                    nextMonth = 0;
                }
                if (tempObj.DateYear != prevYear || tempObj.DateMonth != prevMonth)
                {
        %>
                    <div class="tsl-item"><div class="tsl-item-header"><% Response.Write(tempObj.DateYear.ToString() + "年" + tempObj.DateMonth + "月"); %></div><ul>
        <%
                }
        %>
        <li>
            <div class="tsl-i-date"><% Response.Write(tempObj.DateMonth.ToString() + "月" + tempObj.DateDay.ToString() + "日"); %></div>
            <div class="tsl-i-time"><% Response.Write(tempObj.Time); %></div>
            <div class="tsl-i-away"><div><% Response.Write("<img src='images/teams_logo/"+tempObj.AwayEName+".png' />"); %></div><span><% Response.Write(tempObj.Away); %></span></div>
            <div class="tsl-i-vs"></div>
            <div class="tsl-i-home"><div><% Response.Write("<img src='images/teams_logo/" + tempObj.HomeEName + ".png' />"); %></div><span><% Response.Write(tempObj.Home); %></span></div>
            <%
                if (tempObj.Result.IndexOf("-") >= 0)
                {
                    String[] _result = tempObj.Result.Split('-');
                    int _awayResult = Int32.Parse(_result[0]);
                    int _homwResult = Int32.Parse(_result[1]);
                    if (currentTeam.EName == tempObj.AwayEName)
                    {
                        if (_awayResult < _homwResult) Response.Write("<div class='tsl-i-result tsl-lose'>" + tempObj.Result + "</div>");
                        else Response.Write("<div class='tsl-i-result tsl-win'>" + tempObj.Result + "</div>");
                    }
                    else
                    {
                        if (_awayResult < _homwResult) Response.Write("<div class='tsl-i-result tsl-win'>" + tempObj.Result + "</div>");
                        else Response.Write("<div class='tsl-i-result tsl-lose'>" + tempObj.Result + "</div>");
                    }
                }
                else
                {
                    Response.Write("<div class='tsl-i-result'>" + tempObj.Result + "</div>");
                }
            %>
        </li>
        <%
                prevYear = tempObj.DateYear;
                prevMonth = tempObj.DateMonth;
                if((i + 1 < currentList.Count && (((Game)currentList[i+1]).DateYear != nextYear || ((Game)currentList[i+1]).DateMonth != nextMonth))||i+1==currentList.Count)
                {
        %>
        </ul>
        </div>
        <%
                }
            }
        %>
    </div>--%>

    <div class="teamschedulelist">
        <asp:Literal ID="TeamGameList" runat="server"></asp:Literal>
    </div>
</asp:Content>
