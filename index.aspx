<%@ Page Title="NBA首页" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TestWeb.index" %>
<%@ Import Namespace="TestWeb.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<!-- 赛程 -->
<div class="todayGame">
    <div class="todayGame-date fl">
        <div>今日赛程</div>
        <div><% Response.Write(nowTime.Month.ToString() + "月" + nowTime.Day.ToString() + "日"); %></div>
    </div>
    <div class="todayGame-control fl">
        <div class="todayGame-btn tg-left tg-left-un fl"></div>
        <div class="todayGame-list fl">
            <div>
                <ul>
                    <%
                        if (todaygames.Count == 0) Response.Write("<li class='todayGame-none'>今日无比赛</li>");
                        else
                        {
                            foreach (GameModel _tempGameModel in todaygames)
                            {
                                if (_tempGameModel.AwayPoints == "-1" || _tempGameModel.HomePoints == "-1")
                                {
                         %>
                        <li>
                            <div class="todayGame-list-team">
                                <div class="tg-l-t-logo">
                                    <% Response.Write("<img src='/images/teams_logo/" + _tempGameModel.Away_E + ".png' alt='' />"); %>
                                </div>
                                <span><% Response.Write(_tempGameModel.Away); %></span>
                            </div>
                            <div class="todayGame-list-info">
                                <div class="tg-l-i-time"><% Response.Write(_tempGameModel.Time.ToString("HH:mm")); %></div>
                                <div class="tg-l-i-msg">未开始</div>
                            </div>
                            <div class="todayGame-list-team">
                                <div class="tg-l-t-logo">
                                    <% Response.Write("<img src='/images/teams_logo/" + _tempGameModel.Home_E + ".png' alt='' />"); %>
                                </div>
                                <span><% Response.Write(_tempGameModel.Home); %></span>
                            </div>
                        </li>
                        <%
                        }
                                else
                                {
                                     %>
                        <li>
                            <div class="todayGame-list-team">
                                <div class="tg-l-t-logo">
                                    <% Response.Write("<img src='/images/teams_logo/" + _tempGameModel.Away_E + ".png' alt='' />"); %>
                                </div>
                                <span><% Response.Write(_tempGameModel.Away); %></span>
                            </div>
                            <div class="todayGame-list-info">
                                <div class="tg-l-i-score">
                                    <%
                        Response.Write(Int32.Parse(_tempGameModel.AwayPoints) > Int32.Parse(_tempGameModel.HomePoints) ? "<span class='red'>" + _tempGameModel.AwayPoints + "</span>-<span>" + _tempGameModel.HomePoints + "</span>" : "<span>" + _tempGameModel.AwayPoints + "</span>-<span class='red'>" + _tempGameModel.HomePoints + "</span>");
                                     %>
                                </div>
                            </div>
                            <div class="todayGame-list-team">
                                <div class="tg-l-t-logo">
                                    <% Response.Write("<img src='/images/teams_logo/" + _tempGameModel.Home_E + ".png' alt='' />"); %>
                                </div>
                                <span><% Response.Write(_tempGameModel.Home); %></span>
                            </div>
                        </li>
                        <%
                        }
                            }
                        } %>
                </ul>
<%--                <ul>
                    <%
                        if (todayGames.Count == 0) Response.Write("<li class='todayGame-none'>今日无比赛</li>");
                        else
                        {
                            foreach (Game _teamGame in todayGames)
                            {
                                %>
                                <li>
                                    <div class="todayGame-list-team">
                                        <div class="tg-l-t-logo">
                                            <% Response.Write("<img src='/images/teams_logo/" + _teamGame.AwayEName + ".png' alt='' />"); %>
                                        </div>
                                        <span><% Response.Write(_teamGame.Away); %></span>
                                    </div>
                                    <div class="todayGame-list-info">
                            <%
                                string[] _time = _teamGame.Time.Split(':');
                                int gameHour = Int32.Parse(_time[0]);
                                int gameMinutes = Int32.Parse(_time[1]);
                                if (_teamGame.Result.IndexOf("-") >= 0)
                                {
                                    string[] _score = _teamGame.Result.Split('-');
                                    int awayScore = Int32.Parse(_score[0]);
                                    int homeScore = Int32.Parse(_score[1]);
                                    if (nowTime.Hour + 2 >= gameHour)
                                    {
                                        %>
                                        <div class="tg-l-i-score">
                                        <%
                                            if (awayScore > homeScore)
                                            {
                                                %>
                                                <div class="tg-l-i-score"><span class="red"><% Response.Write(awayScore.ToString()); %></span>-<span><% Response.Write(homeScore.ToString()); %></span></div>
                                                <%
                                            }
                                            else
                                            {
                                                %>
                                                <div class="tg-l-i-score"><span><% Response.Write(awayScore.ToString()); %></span>-<span class="red"><% Response.Write(homeScore.ToString()); %></span></div>
                                                <%
                                            }
                                         %>
                                        </div>
                                        <%
                                    }
                                    else
                                    {
                                        %>
                                        <div class="tg-l-i-score"><span class="red"><% Response.Write(awayScore.ToString()); %></span>-<span><% Response.Write(homeScore.ToString()); %></span></div>
                                        <div class="tg-l-i-msg">第3节</div>
                                        <%
                                    }
                                }
                                else
                                {
                                    %>
                                    <div class="tg-l-i-time"><% Response.Write(_teamGame.Time); %></div>
                                    <div class="tg-l-i-msg">未开始</div>
                                    <%
                                }
                                    %>
                                    </div>
                                    <div class="todayGame-list-team">
                                        <div class="tg-l-t-logo">
                                            <% Response.Write("<img src='/images/teams_logo/" + _teamGame.HomeEName + ".png' alt='' />"); %>
                                        </div>
                                        <span><% Response.Write(_teamGame.Home); %></span>
                                    </div>
                                </li>
                                <%
                            }
                        }
                         %>
                    <!--
                    <li>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/celtics.png" alt="" /></div>
                            <span>凯尔特人</span>
                        </div>
                        <div class="todayGame-list-info">
                            <div class="tg-l-i-score"><span class="red">129</span>-<span>110</span></div>
                        </div>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/mavericks.png" alt="" /></div>
                            <span>独行侠</span>
                        </div>
                    </li>
                    <li>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/celtics.png" alt="" /></div>
                            <span>凯尔特人</span>
                        </div>
                        <div class="todayGame-list-info">
                            <div class="tg-l-i-score"><span>129</span>-<span>110</span></div>
                            <div class="tg-l-i-msg">第3节</div>
                        </div>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/mavericks.png" alt="" /></div>
                            <span>独行侠</span>
                        </div>
                    </li>
                    <li>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/celtics.png" alt="" /></div>
                            <span>凯尔特人</span>
                        </div>
                        <div class="todayGame-list-info">
                            <div class="tg-l-i-time">17:30</div>
                            <div class="tg-l-i-msg">未开始</div>
                        </div>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/mavericks.png" alt="" /></div>
                            <span>独行侠</span>
                        </div>
                    </li>
                    <li>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/celtics.png" alt="" /></div>
                            <span>凯尔特人</span>
                        </div>
                        <div class="todayGame-list-info">
                            <div class="tg-l-i-time">17:30</div>
                            <div class="tg-l-i-msg">未开始</div>
                        </div>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/mavericks.png" alt="" /></div>
                            <span>独行侠</span>
                        </div>
                    </li>
                    <li>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/celtics.png" alt="" /></div>
                            <span>凯尔特人</span>
                        </div>
                        <div class="todayGame-list-info">
                            <div class="tg-l-i-time">17:30</div>
                            <div class="tg-l-i-msg">未开始</div>
                        </div>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/mavericks.png" alt="" /></div>
                            <span>独行侠</span>
                        </div>
                    </li>
                    <li>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/celtics.png" alt="" /></div>
                            <span>凯尔特人</span>
                        </div>
                        <div class="todayGame-list-info">
                            <div class="tg-l-i-time">18:30</div>
                            <div class="tg-l-i-msg">未开始</div>
                        </div>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/mavericks.png" alt="" /></div>
                            <span>独行侠</span>
                        </div>
                    </li>
                    <li>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/celtics.png" alt="" /></div>
                            <span>凯尔特人</span>
                        </div>
                        <div class="todayGame-list-info">
                            <div class="tg-l-i-time">20:30</div>
                            <div class="tg-l-i-msg">未开始</div>
                        </div>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/mavericks.png" alt="" /></div>
                            <span>独行侠</span>
                        </div>
                    </li>
                    <li>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/celtics.png" alt="" /></div>
                            <span>凯尔特人</span>
                        </div>
                        <div class="todayGame-list-info">
                            <div class="tg-l-i-time">20:30</div>
                            <div class="tg-l-i-msg">未开始</div>
                        </div>
                        <div class="todayGame-list-team">
                            <div class="tg-l-t-logo"><img src="/images/teams_logo/mavericks.png" alt="" /></div>
                            <span>独行侠</span>
                        </div>
                    </li>
                    -->
                </ul>
--%>            </div>
        </div>
        <div class="todayGame-btn tg-right fl"></div>
    </div>
</div>

<div class="layout">
    <div class="layout-left fl">
        <div class="focusNews">
            <!-- 焦点图 -->
            <div class="focus fl">
                <div class="focus-imgList">
                    <ul>
                        <li>
                            <div class="focus-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="湖人瓦格纳进球全队欢呼 詹皇称如学会骑车" /></a></div>
                            <div class="focus-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车1</a></div>
                        </li>
                        <li>
                            <div class="focus-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="湖人瓦格纳进球全队欢呼 詹皇称如学会骑车" /></a></div>
                            <div class="focus-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车2</a></div>
                        </li>
                        <li>
                            <div class="focus-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="湖人瓦格纳进球全队欢呼 詹皇称如学会骑车" /></a></div>
                            <div class="focus-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车3</a></div>
                        </li>
                        <li>
                            <div class="focus-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="湖人瓦格纳进球全队欢呼 詹皇称如学会骑车" /></a></div>
                            <div class="focus-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车4</a></div>
                        </li>
                        <li>
                            <div class="focus-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="湖人瓦格纳进球全队欢呼 詹皇称如学会骑车" /></a></div>
                            <div class="focus-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车5</a></div>
                        </li>
                    </ul>
                </div>
                <div class="focus-tag">
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                </div>
            </div>

            <!-- 新闻动态 -->
            <div class="news fl">
                <div class="layoutHeader">
                    <div class="fl">新闻动态</div>
                    <a href="#" target="_blank">更多...</a>
                </div>
                <div class="newsList">
                    <ul>
                        <li><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></li>
                        <li><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></li>
                        <li><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></li>
                        <li><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></li>
                        <li><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></li>
                        <li><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></li>
                        <li><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></li>
                        <li><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></li>
                        <li><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <!-- 最佳球员 -->
        <div class="mvp">
            <div class="mvp-tag">
                <div class="sel">1 月最佳球员</div>
                <div>12月2日~12月8日 周最佳球员</div>
            </div>
            <div class="mvp-table">
                <div class="mvp-item">
                    <div class="mvp-player">
                        <div class="mvp-player-photo">
                            <div class="mvpPhoto"><img src="/images/player/201935.png" alt="" /></div>
                            <div class="mvpInfo">
                                <div class="mvpInfo-name">詹姆斯·哈登</div>
                                <div class="mvpInfo-other">后卫 / 休斯顿 火箭</div>
                            </div>
                        </div>
                        <div class="mvp-player-record">
                            <div class="mvp-score">
                                 <div>场均得分</div>
                                 <span>30.9</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均篮板</div>
                                <span>2.7</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均助攻</div>
                                <span>8.4</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均盖帽</div>
                                <span>1.2</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均抢断</div>
                                <span>2.1</span>
                            </div>
                        </div>
                    </div>
                    <div class="mvp-player">
                        <div class="mvp-player-photo">
                            <div class="mvpPhoto"><img src="/images/player/201935.png" alt="" /></div>
                            <div class="mvpInfo">
                                <div class="mvpInfo-name">詹姆斯·哈登</div>
                                <div class="mvpInfo-other">后卫 / 休斯顿 火箭</div>
                            </div>
                        </div>
                        <div class="mvp-player-record">
                            <div class="mvp-score">
                                 <div>场均得分</div>
                                 <span>30.9</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均篮板</div>
                                <span>2.7</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均助攻</div>
                                <span>8.4</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均盖帽</div>
                                <span>1.2</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均抢断</div>
                                <span>2.1</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mvp-item hide">
                    <div class="mvp-player">
                        <div class="mvp-player-photo">
                            <div class="mvpPhoto"><img src="/images/player/201935.png" alt="" /></div>
                            <div class="mvpInfo">
                                <div class="mvpInfo-name">詹姆斯·哈登2</div>
                                <div class="mvpInfo-other">后卫 / 休斯顿 火箭</div>
                            </div>
                        </div>
                        <div class="mvp-player-record">
                            <div class="mvp-score">
                                 <div>场均得分</div>
                                 <span>30.9</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均篮板</div>
                                <span>2.7</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均助攻</div>
                                <span>8.4</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均盖帽</div>
                                <span>1.2</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均抢断</div>
                                <span>2.1</span>
                            </div>
                        </div>
                    </div>
                    <div class="mvp-player">
                        <div class="mvp-player-photo">
                            <div class="mvpPhoto"><img src="/images/player/201935.png" alt="" /></div>
                            <div class="mvpInfo">
                                <div class="mvpInfo-name">詹姆斯·哈登</div>
                                <div class="mvpInfo-other">后卫 / 休斯顿 火箭</div>
                            </div>
                        </div>
                        <div class="mvp-player-record">
                            <div class="mvp-score">
                                 <div>场均得分</div>
                                 <span>30.9</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均篮板</div>
                                <span>2.7</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均助攻</div>
                                <span>8.4</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均盖帽</div>
                                <span>1.2</span>
                            </div>
                            <div class="mvp-player-single">
                                <div>场均抢断</div>
                                <span>2.1</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="layout-right fl">
        <!-- 排名 -->
        <div class="classification">
            <div class="sel">联盟排名</div>
            <div>分区排名</div>
        </div>
        <div class="conference">
            <div class="conference-west sel">西部联盟</div>
            <div class="conference-east">东部联盟</div>
        </div>
        <div>
            <div class="ranking">
                <table>
                    <colgroup>
                        <col style="width:15%" />
                        <col style="width:12%" />
                        <col style="width:28%" />
                        <col style="width:10%" />
                        <col style="width:10%" />
                        <col style="width:25%" />
                    </colgroup>
                    <tr class="tableBg_0">
                        <th>排名</th><th>&nbsp;</th><th class="tl">球队</th><th>胜</th><th>负</th><th>胜场差</th>
                    </tr>
                    <%
                        bool bg = true;
                        string html = "";
                        float firstWinDifferential = 0;
                        for (int i = 0; i < westernConference.Count; i++)
                        {
                            TeamRanking tempRanking = westernConference[i];
                            html = "";
                            if (i == 0) firstWinDifferential = tempRanking.WinDifferential;
                            if (i == 7) html += "<tr class='" + (bg ? "tableBg_1" : "tableBg_2") + " tableLine'>";
                            else html += "<tr class='" + (bg ? "tableBg_1" : "tableBg_2") + "'>";
                            html += "<td>" + (i + 1).ToString() + "</td>";
                            html += "<td><div><img src='/images/teams_logo/" + tempRanking.EName + ".png' alt='' /></div></td>";
                            html += "<td class='tl'>" + tempRanking.CName + "</td>";
                            html += "<td>" + tempRanking.Win.ToString() + "</td>";
                            html += "<td>" + tempRanking.Lose.ToString() + "</td>";
                            html += "<td>" + ((firstWinDifferential - tempRanking.WinDifferential) / 2).ToString() + "</td>";
                            html += "</tr>";
                            bg = !bg;
                            Response.Write(html);
                        }
                         %>
                    <!--
                    <tr class="tableBg_1">
                        <td>1</td><td><div><img src="/images/teams_logo/celtics.png" alt="" /></div></td><td class="tl">凯尔特人</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_2">
                        <td>1</td><td><div><img src="/images/teams_logo/blazers.png" alt="" /></div></td><td class="tl">开拓者1</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_1">
                        <td>1</td><td><div><img src="/images/teams_logo/lakers.png" alt="" /></div></td><td class="tl">湖人</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_2">
                        <td>1</td><td><div><img src="/images/teams_logo/pelicans.png" alt="" /></div></td><td class="tl">鹈鹕</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_1">
                        <td>1</td><td><div><img src="/images/teams_logo/celtics.png" alt="" /></div></td><td class="tl">凯尔特人</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_2">
                        <td>1</td><td><div><img src="/images/teams_logo/blazers.png" alt="" /></div></td><td class="tl">开拓者</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_1">
                        <td>1</td><td><div><img src="/images/teams_logo/lakers.png" alt="" /></div></td><td class="tl">湖人</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_2 tableLine">
                        <td>1</td><td><div><img src="/images/teams_logo/pelicans.png" alt="" /></div></td><td class="tl">鹈鹕</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_1">
                        <td>1</td><td><div><img src="/images/teams_logo/celtics.png" alt="" /></div></td><td class="tl">凯尔特人</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_2">
                        <td>1</td><td><div><img src="/images/teams_logo/blazers.png" alt="" /></div></td><td class="tl">开拓者</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_1">
                        <td>1</td><td><div><img src="/images/teams_logo/lakers.png" alt="" /></div></td><td class="tl">湖人</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_2">
                        <td>1</td><td><div><img src="/images/teams_logo/pelicans.png" alt="" /></div></td><td class="tl">鹈鹕</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_1">
                        <td>1</td><td><div><img src="/images/teams_logo/celtics.png" alt="" /></div></td><td class="tl">凯尔特人</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_2">
                        <td>1</td><td><div><img src="/images/teams_logo/blazers.png" alt="" /></div></td><td class="tl">开拓者</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    <tr class="tableBg_1">
                        <td>1</td><td><div><img src="/images/teams_logo/lakers.png" alt="" /></div></td><td class="tl">湖人</td><td>32</td><td>25</td><td>12.9</td>
                    </tr>
                    -->
                </table>
            </div>
            <div class="ranking hide">
                <table>
                    <colgroup>
                        <col style="width:15%" />
                        <col style="width:12%" />
                        <col style="width:28%" />
                        <col style="width:10%" />
                        <col style="width:10%" />
                        <col style="width:25%" />
                    </colgroup>
                    <tr class="tableBg_0">
                        <th>排名</th><th>&nbsp;</th><th class="tl">球队</th><th>胜</th><th>负</th><th>胜场差</th>
                    </tr>
                    <%
                        bg = true;
                        html = "";
                        firstWinDifferential = 0;
                        for (int i = 0; i < easternConference.Count; i++)
                        {
                            TeamRanking tempRanking = easternConference[i];
                            html = "";
                            if (i == 0) firstWinDifferential = tempRanking.WinDifferential;
                            if (i == 7) html += "<tr class='" + (bg ? "tableBg_1" : "tableBg_2") + " tableLine'>";
                            else html += "<tr class='" + (bg ? "tableBg_1" : "tableBg_2") + "'>";
                            html += "<td>" + (i + 1).ToString() + "</td>";
                            html += "<td><div><img src='/images/teams_logo/" + tempRanking.EName + ".png' alt='' /></div></td>";
                            html += "<td class='tl'>" + tempRanking.CName + "</td>";
                            html += "<td>" + tempRanking.Win.ToString() + "</td>";
                            html += "<td>" + tempRanking.Lose.ToString() + "</td>";
                            html += "<td>" + ((firstWinDifferential - tempRanking.WinDifferential) / 2).ToString() + "</td>";
                            html += "</tr>";
                            bg = !bg;
                            Response.Write(html);
                        }
                         %>
                </table>
            </div>
            <div class="ranking hide">
                <div>
                    <div class="ranking-header"><% Response.Write(pacificDivision[0].Zone); %></div>
                    <table>
                        <colgroup>
                            <col style="width:15%" />
                            <col style="width:12%" />
                            <col style="width:28%" />
                            <col style="width:10%" />
                            <col style="width:10%" />
                            <col style="width:25%" />
                        </colgroup>
                        <tr class="tableBg_0">
                            <th>排名</th><th>&nbsp;</th><th class="tl">球队</th><th>胜</th><th>负</th><th>胜场差</th>
                        </tr>
                        <%
                            bg = true;
                            html = "";
                            firstWinDifferential = 0;
                            for (int i = 0; i < pacificDivision.Count; i++)
                            {
                                TeamRanking tempRanking = pacificDivision[i];
                                html = "";
                                if (i == 0) firstWinDifferential = tempRanking.WinDifferential;
                                html += "<tr class='" + (bg ? "tableBg_1" : "tableBg_2") + "'>";
                                html += "<td>" + (i + 1).ToString() + "</td>";
                                html += "<td><div><img src='/images/teams_logo/" + tempRanking.EName + ".png' alt='' /></div></td>";
                                html += "<td class='tl'>" + tempRanking.CName + "</td>";
                                html += "<td>" + tempRanking.Win.ToString() + "</td>";
                                html += "<td>" + tempRanking.Lose.ToString() + "</td>";
                                html += "<td>" + ((firstWinDifferential - tempRanking.WinDifferential) / 2).ToString() + "</td>";
                                html += "</tr>";
                                bg = !bg;
                                Response.Write(html);
                            }
                             %>
                    </table>
                </div>
                <div>
                    <div class="ranking-header"><% Response.Write(northwestDivision[0].Zone); %></div>
                    <table>
                        <colgroup>
                            <col style="width:15%" />
                            <col style="width:12%" />
                            <col style="width:28%" />
                            <col style="width:10%" />
                            <col style="width:10%" />
                            <col style="width:25%" />
                        </colgroup>
                        <tr class="tableBg_0">
                            <th>排名</th><th>&nbsp;</th><th class="tl">球队</th><th>胜</th><th>负</th><th>胜场差</th>
                        </tr>
                        <%
                            bg = true;
                            html = "";
                            firstWinDifferential = 0;
                            for (int i = 0; i < northwestDivision.Count; i++)
                            {
                                TeamRanking tempRanking = northwestDivision[i];
                                html = "";
                                if (i == 0) firstWinDifferential = tempRanking.WinDifferential;
                                html += "<tr class='" + (bg ? "tableBg_1" : "tableBg_2") + "'>";
                                html += "<td>" + (i + 1).ToString() + "</td>";
                                html += "<td><div><img src='/images/teams_logo/" + tempRanking.EName + ".png' alt='' /></div></td>";
                                html += "<td class='tl'>" + tempRanking.CName + "</td>";
                                html += "<td>" + tempRanking.Win.ToString() + "</td>";
                                html += "<td>" + tempRanking.Lose.ToString() + "</td>";
                                html += "<td>" + ((firstWinDifferential - tempRanking.WinDifferential) / 2).ToString() + "</td>";
                                html += "</tr>";
                                bg = !bg;
                                Response.Write(html);
                            }
                             %>
                    </table>
                </div>
                <div>
                    <div class="ranking-header"><% Response.Write(southwestDivision[0].Zone); %></div>
                    <table>
                        <colgroup>
                            <col style="width:15%" />
                            <col style="width:12%" />
                            <col style="width:28%" />
                            <col style="width:10%" />
                            <col style="width:10%" />
                            <col style="width:25%" />
                        </colgroup>
                        <tr class="tableBg_0">
                            <th>排名</th><th>&nbsp;</th><th class="tl">球队</th><th>胜</th><th>负</th><th>胜场差</th>
                        </tr>
                        <%
                            bg = true;
                            html = "";
                            firstWinDifferential = 0;
                            for (int i = 0; i < southwestDivision.Count; i++)
                            {
                                TeamRanking tempRanking = southwestDivision[i];
                                html = "";
                                if (i == 0) firstWinDifferential = tempRanking.WinDifferential;
                                html += "<tr class='" + (bg ? "tableBg_1" : "tableBg_2") + "'>";
                                html += "<td>" + (i + 1).ToString() + "</td>";
                                html += "<td><div><img src='/images/teams_logo/" + tempRanking.EName + ".png' alt='' /></div></td>";
                                html += "<td class='tl'>" + tempRanking.CName + "</td>";
                                html += "<td>" + tempRanking.Win.ToString() + "</td>";
                                html += "<td>" + tempRanking.Lose.ToString() + "</td>";
                                html += "<td>" + ((firstWinDifferential - tempRanking.WinDifferential) / 2).ToString() + "</td>";
                                html += "</tr>";
                                bg = !bg;
                                Response.Write(html);
                            }
                             %>
                    </table>
                </div>
            </div>
            <div class="ranking hide">
                <div>
                    <div class="ranking-header"><% Response.Write(southeastDivision[0].Zone); %></div>
                    <table>
                        <colgroup>
                            <col style="width:15%" />
                            <col style="width:12%" />
                            <col style="width:28%" />
                            <col style="width:10%" />
                            <col style="width:10%" />
                            <col style="width:25%" />
                        </colgroup>
                        <tr class="tableBg_0">
                            <th>排名</th><th>&nbsp;</th><th class="tl">球队</th><th>胜</th><th>负</th><th>胜场差</th>
                        </tr>
                        <%
                            bg = true;
                            html = "";
                            firstWinDifferential = 0;
                            for (int i = 0; i < southeastDivision.Count; i++)
                            {
                                TeamRanking tempRanking = southeastDivision[i];
                                html = "";
                                if (i == 0) firstWinDifferential = tempRanking.WinDifferential;
                                html += "<tr class='" + (bg ? "tableBg_1" : "tableBg_2") + "'>";
                                html += "<td>" + (i + 1).ToString() + "</td>";
                                html += "<td><div><img src='/images/teams_logo/" + tempRanking.EName + ".png' alt='' /></div></td>";
                                html += "<td class='tl'>" + tempRanking.CName + "</td>";
                                html += "<td>" + tempRanking.Win.ToString() + "</td>";
                                html += "<td>" + tempRanking.Lose.ToString() + "</td>";
                                html += "<td>" + ((firstWinDifferential - tempRanking.WinDifferential) / 2).ToString() + "</td>";
                                html += "</tr>";
                                bg = !bg;
                                Response.Write(html);
                            }
                             %>
                    </table>
                </div>
                <div>
                    <div class="ranking-header"><% Response.Write(centralDivision[0].Zone); %></div>
                    <table>
                        <colgroup>
                            <col style="width:15%" />
                            <col style="width:12%" />
                            <col style="width:28%" />
                            <col style="width:10%" />
                            <col style="width:10%" />
                            <col style="width:25%" />
                        </colgroup>
                        <tr class="tableBg_0">
                            <th>排名</th><th>&nbsp;</th><th class="tl">球队</th><th>胜</th><th>负</th><th>胜场差</th>
                        </tr>
                        <%
                            bg = true;
                            html = "";
                            firstWinDifferential = 0;
                            for (int i = 0; i < centralDivision.Count; i++)
                            {
                                TeamRanking tempRanking = centralDivision[i];
                                html = "";
                                if (i == 0) firstWinDifferential = tempRanking.WinDifferential;
                                html += "<tr class='" + (bg ? "tableBg_1" : "tableBg_2") + "'>";
                                html += "<td>" + (i + 1).ToString() + "</td>";
                                html += "<td><div><img src='/images/teams_logo/" + tempRanking.EName + ".png' alt='' /></div></td>";
                                html += "<td class='tl'>" + tempRanking.CName + "</td>";
                                html += "<td>" + tempRanking.Win.ToString() + "</td>";
                                html += "<td>" + tempRanking.Lose.ToString() + "</td>";
                                html += "<td>" + ((firstWinDifferential - tempRanking.WinDifferential) / 2).ToString() + "</td>";
                                html += "</tr>";
                                bg = !bg;
                                Response.Write(html);
                            }
                             %>
                    </table>
                </div>
                <div>
                    <div class="ranking-header"><% Response.Write(atlanticDivision[0].Zone); %></div>
                    <table>
                        <colgroup>
                            <col style="width:15%" />
                            <col style="width:12%" />
                            <col style="width:28%" />
                            <col style="width:10%" />
                            <col style="width:10%" />
                            <col style="width:25%" />
                        </colgroup>
                        <tr class="tableBg_0">
                            <th>排名</th><th>&nbsp;</th><th class="tl">球队</th><th>胜</th><th>负</th><th>胜场差</th>
                        </tr>
                        <%
                            bg = true;
                            html = "";
                            firstWinDifferential = 0;
                            for (int i = 0; i < atlanticDivision.Count; i++)
                            {
                                TeamRanking tempRanking = atlanticDivision[i];
                                html = "";
                                if (i == 0) firstWinDifferential = tempRanking.WinDifferential;
                                html += "<tr class='" + (bg ? "tableBg_1" : "tableBg_2") + "'>";
                                html += "<td>" + (i + 1).ToString() + "</td>";
                                html += "<td><div><img src='/images/teams_logo/" + tempRanking.EName + ".png' alt='' /></div></td>";
                                html += "<td class='tl'>" + tempRanking.CName + "</td>";
                                html += "<td>" + tempRanking.Win.ToString() + "</td>";
                                html += "<td>" + tempRanking.Lose.ToString() + "</td>";
                                html += "<td>" + ((firstWinDifferential - tempRanking.WinDifferential) / 2).ToString() + "</td>";
                                html += "</tr>";
                                bg = !bg;
                                Response.Write(html);
                            }
                             %>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>

<div class="cb"></div>

<!-- 数据王 -->
<div class="layout">
    <div class="layoutHeader">
        <div class="fl">数据王</div>
        <a href="#" target="_blank">更多...</a>
    </div>
    <div class="record">
        <div class="record-item">
            <div class="record-header">场均得分</div>
            <div class="record-first">
                <div class="record-first-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-first-info">
                    <div class="record-f-i-name">
                        <div>詹姆斯·哈登</div>
                        <div>后卫 / 火箭</div>
                    </div>
                    <div class="record-f-i-data">30.9</div>
                </div>
            </div>
            <div class="record-list">
                <div class="record-list-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-list-info">
                    <div>詹姆斯·哈登</div>
                    <div>后卫 / 火箭</div>
                </div>
                <div class="record-list-data">29.9</div>
            </div>
            <div class="record-list">
                <div class="record-list-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-list-info">
                    <div>詹姆斯·哈登</div>
                    <div>后卫 / 火箭</div>
                </div>
                <div class="record-list-data">21.9</div>
            </div>
        </div>
        <div class="record-item">
            <div class="record-header">场均得分</div>
            <div class="record-first">
                <div class="record-first-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-first-info">
                    <div class="record-f-i-name">
                        <div>詹姆斯·哈登</div>
                        <div>后卫 / 火箭</div>
                    </div>
                    <div class="record-f-i-data">30.9</div>
                </div>
            </div>
            <div class="record-list">
                <div class="record-list-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-list-info">
                    <div>詹姆斯·哈登</div>
                    <div>后卫 / 火箭</div>
                </div>
                <div class="record-list-data">29.9</div>
            </div>
            <div class="record-list">
                <div class="record-list-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-list-info">
                    <div>詹姆斯·哈登</div>
                    <div>后卫 / 火箭</div>
                </div>
                <div class="record-list-data">21.9</div>
            </div>
        </div>
        <div class="record-item">
            <div class="record-header">场均得分</div>
            <div class="record-first">
                <div class="record-first-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-first-info">
                    <div class="record-f-i-name">
                        <div>詹姆斯·哈登</div>
                        <div>后卫 / 火箭</div>
                    </div>
                    <div class="record-f-i-data">30.9</div>
                </div>
            </div>
            <div class="record-list">
                <div class="record-list-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-list-info">
                    <div>詹姆斯·哈登</div>
                    <div>后卫 / 火箭</div>
                </div>
                <div class="record-list-data">29.9</div>
            </div>
            <div class="record-list">
                <div class="record-list-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-list-info">
                    <div>詹姆斯·哈登</div>
                    <div>后卫 / 火箭</div>
                </div>
                <div class="record-list-data">21.9</div>
            </div>
        </div>
        <div class="record-item">
            <div class="record-header">场均得分</div>
            <div class="record-first">
                <div class="record-first-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-first-info">
                    <div class="record-f-i-name">
                        <div>詹姆斯·哈登</div>
                        <div>后卫 / 火箭</div>
                    </div>
                    <div class="record-f-i-data">30.9</div>
                </div>
            </div>
            <div class="record-list">
                <div class="record-list-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-list-info">
                    <div>詹姆斯·哈登</div>
                    <div>后卫 / 火箭</div>
                </div>
                <div class="record-list-data">29.9</div>
            </div>
            <div class="record-list">
                <div class="record-list-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-list-info">
                    <div>詹姆斯·哈登</div>
                    <div>后卫 / 火箭</div>
                </div>
                <div class="record-list-data">21.9</div>
            </div>
        </div>
        <div class="record-item">
            <div class="record-header">场均得分</div>
            <div class="record-first">
                <div class="record-first-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-first-info">
                    <div class="record-f-i-name">
                        <div>詹姆斯·哈登</div>
                        <div>后卫 / 火箭</div>
                    </div>
                    <div class="record-f-i-data">30.9</div>
                </div>
            </div>
            <div class="record-list">
                <div class="record-list-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-list-info">
                    <div>詹姆斯·哈登</div>
                    <div>后卫 / 火箭</div>
                </div>
                <div class="record-list-data">29.9</div>
            </div>
            <div class="record-list">
                <div class="record-list-photo"><img src="/images/player/201935.png" alt="" /></div>
                <div class="record-list-info">
                    <div>詹姆斯·哈登</div>
                    <div>后卫 / 火箭</div>
                </div>
                <div class="record-list-data">21.9</div>
            </div>
        </div>
    </div>
</div>

<!-- 精彩时刻 -->
<div class="layout">
    <div class="layoutHeader">
        <div class="fl">精彩时刻</div>
        <a href="#" target="_blank">更多...</a>
    </div>
    <div class="imgList">
        <ul>
            <li>
                <div class="imgList-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="" /></a></div>
                <div class="imgList-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></div>
            </li>
            <li>
                <div class="imgList-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="" /></a></div>
                <div class="imgList-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></div>
            </li>
            <li>
                <div class="imgList-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="" /></a></div>
                <div class="imgList-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></div>
            </li>
            <li>
                <div class="imgList-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="" /></a></div>
                <div class="imgList-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></div>
            </li>
            <li>
                <div class="imgList-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="" /></a></div>
                <div class="imgList-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></div>
            </li>
            <li>
                <div class="imgList-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="" /></a></div>
                <div class="imgList-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></div>
            </li>
            <li>
                <div class="imgList-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="" /></a></div>
                <div class="imgList-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></div>
            </li>
            <li>
                <div class="imgList-img"><a href="#" target="_blank"><img src="/temp/temp_0.jpg" alt="" /></a></div>
                <div class="imgList-title"><a href="#" target="_blank">湖人瓦格纳进球全队欢呼 詹皇称如学会骑车</a></div>
            </li>
        </ul>

        <div class="cb"></div>
    </div>
</div>
<script type="text/javascript">
    $(function () {
        // 赛程
        var todayGame = $(".todayGame-list");
        var todayGame_leftBtn = $(".tg-left");
        var todayGame_rightBtn = $(".tg-right");
        var scrollPx = 0;
        var pageIndex = 0;
        var list = todayGame.find("li");
        var widthSingle = todayGame.find("li:first").outerWidth(true);
        var widthTotal = list.length * widthSingle;
        todayGame.children("div").width(widthTotal);
        var pageItem = 3;
        var maxScrollPx = widthTotal - parseInt(list.css("margin-right")) - todayGame.width();
        var maxPageIndex = Math.ceil(list.length / pageItem);
        var currentScroll = 0;
        var scrollList = function () {
            currentScroll = pageIndex * pageItem * list.outerWidth(true);
            if (currentScroll > maxScrollPx) currentScroll = maxScrollPx;
            todayGame.scrollLeft(currentScroll);
        }

        if (todayGame.children("div").width() > todayGame.width()) {
            todayGame_leftBtn.click(function () {
                pageIndex--;
                if (pageIndex < 0) pageIndex = 0;
                if (pageIndex == 0 && !$(this).hasClass("tg-left-un")) $(this).addClass("tg-left-un");
                else if (pageIndex > 0) $(this).removeClass("tg-left-un");
                if (pageIndex == maxPageIndex && !todayGame_rightBtn.hasClass("tg-right-un")) todayGame_rightBtn.addClass("tg-right-un");
                else if (pageIndex < maxPageIndex) todayGame_rightBtn.removeClass("tg-right-un");
                scrollList();
            });

            todayGame_rightBtn.click(function () {
                pageIndex++;
                if (pageIndex > maxPageIndex - 1) pageIndex = maxPageIndex - 1;
                if (pageIndex == maxPageIndex - 1 && !$(this).hasClass("tg-right-un")) $(this).addClass("tg-right-un");
                else if (pageIndex < maxPageIndex - 1) $(this).removeClass("tg-right-un");
                if (pageIndex == 0 && !todayGame_leftBtn.hasClass("tg-left-un")) todayGame_leftBtn.addClass("tg-left-un");
                else if (pageIndex > 0) todayGame_leftBtn.removeClass("tg-left-un");
                scrollList();
            });
        } else {
            todayGame_rightBtn.addClass("tg-right-un");
        }

        // 焦点图
        var focusDiv = $(".focus");
        var focusImg = $(".focus-imgList li");
        var focusTag = $(".focus-tag span");
        var focusIndex = 0;
        var prevFocusIndex = 0;
        var focusT;

        focusImg.first().show();
        focusTag.first().addClass("sel");
        var changeFocusImg = function () {
            focusImg.filter(":visible").hide();
            focusImg.eq(focusIndex).fadeIn("fast");
            focusTag.filter(".sel").removeClass("sel");
            focusTag.eq(focusIndex).addClass("sel");
        }

        var autoChange = function () {
            focusIndex++;
            if (focusIndex >= focusImg.length) focusIndex = 0;
            changeFocusImg();
        }

        focusT = setInterval(autoChange, 4000);

        focusDiv.mouseenter(function () {
            clearInterval(focusT);
        }).mouseleave(function () {
            focusT = setInterval(autoChange, 4000);
        });

        focusTag.click(function () {
            if (!$(this).hasClass("sel")) {
                focusIndex = focusTag.index($(this));
                changeFocusImg();
            }
        });

        // 最佳球员
        var mvp_tag = $(".mvp-tag div");
        var mvp_table = $(".mvp-item");
        var mvpIndex = 0;
        mvp_tag.click(function () {
            if (!$(this).hasClass("sel")) {
                mvpIndex = mvp_tag.index($(this));
                mvp_tag.filter(".sel").removeClass("sel");
                $(this).addClass("sel");
                mvp_table.filter(":visible").hide();
                mvp_table.eq(mvpIndex).fadeIn("normal");
            }
        });

        // 排名
        var classification = $(".classification div");
        var conference = $(".conference div");
        var ranking = $(".ranking");
        var classifiIndex = 0;
        var conferenceIndex = 0;
        var currentClassfiIndex = 0;
        var currentConferenceIndex = 0;

        classification.click(function () {
            classifiIndex = classification.index($(this));
            conferenceIndex = conference.index(conference.filter(".sel"));
            if (!(classifiIndex == currentClassfiIndex && conferenceIndex == currentConferenceIndex)) {
                changeTable(classifiIndex, conferenceIndex);
                classification.removeClass("sel");
                $(this).addClass("sel");
                currentClassfiIndex = classifiIndex;
            }
        });

        conference.click(function () {
            classifiIndex = classification.index(classification.filter(".sel"));
            conferenceIndex = conference.index($(this));
            if (!(classifiIndex == currentClassfiIndex && conferenceIndex == currentConferenceIndex)) {
                changeTable(classifiIndex, conferenceIndex);
                conference.removeClass("sel");
                $(this).addClass("sel");
                currentConferenceIndex = conferenceIndex;
            }
        });

        var changeTable = function (classifiI, conferenceI) {
            if (classifiI == 0 && conferenceI == 0) {
                ranking.hide();
                ranking.eq(0).show();
            } else if (classifiI == 0 && conferenceI == 1) {
                ranking.hide();
                ranking.eq(1).show();
            } else if (classifiI == 1 && conferenceI == 0) {
                ranking.hide();
                ranking.eq(2).show();
            } else {
                ranking.hide();
                ranking.eq(3).show();
            }
        }

        // 精彩时刻
        $(".imgList li").mouseenter(function () {
            $(this).children(".imgList-title").fadeIn("fast");
        }).mouseleave(function () {
            $(this).children(".imgList-title").hide();
        });
    });
</script>
</asp:Content>
