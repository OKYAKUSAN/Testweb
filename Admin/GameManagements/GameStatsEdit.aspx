<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameStatsEdit.aspx.cs" Inherits="TestWeb.Admin.GameManagements.GameStatsEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <% Response.Write("<link href='/Styles/admin_master.css?v=" + (DateTime.Now.Subtract(new DateTime())).TotalSeconds.ToString() + "' type='text/css' rel='stylesheet' />"); %>
    <script type="text/javascript" src="/Scripts/jquery-1.12.4.min.js"></script>
    <script type="text/javascript" src="/Scripts/stopPropagation.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" action="/Admin/GameManagements/GameStatsSend.aspx" method="post" target="rightFrame">
        <asp:Literal ID="GameStatsId" runat="server"></asp:Literal>
        <asp:Literal ID="AwayId" runat="server"></asp:Literal>
        <asp:Literal ID="HomeId" runat="server"></asp:Literal>
        <div class="p30">
            <div class="breadCrumb"><a href="/Admin/Default.aspx" target="rightFrame">首页</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<a href="/Admin/GameManagements/GameList.aspx" target="rightFrame">比赛时间</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<asp:Literal ID="GameStatsLink" runat="server"></asp:Literal>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<asp:Label ID="GameListEdit" runat="server"></asp:Label></div>
            <div class="mt10">
                <table class="formTable">
                    <colgroup>
                        <col style="width:150px;" />
                        <col style="width:auto;" />
                    </colgroup>
                    <tr class="tbg0"><th colspan="2">球员单场记录</th></tr>
                    <tr>
                        <th class="tr">球员</th>
                        <td>
                            <div class="formList">
                                <div class="formItem">
                                    <div class="formItem-text">
                                        <input type="text" class="gamePlayer" id="gamePlayer" name="gamePlayer" placeholder="点击选择球员" />
                                        <input type="hidden" id="gamePlayerId" name="gamePlayerId" value="" />
                                    </div>
                                </div>
                                <div class="formMsg">请选择队员</div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th class="tr">所属球队</th>
                        <td>
                            <div class="formList">
                                <div class="formItem">
                                    <div class="formItem-select">
                                        <select id="gameTeam" name="gameTeam">
                                            <option value="">-</option>
                                            <asp:Literal ID="GameTeam" runat="server"></asp:Literal>
                                        </select>
                                    </div>
                                </div>
                                <div class="formMsg">请选择球队</div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th class="tr">个人数据</th>
                        <td>
                            <div class="formList">
                                <div class="formItem gameStatsData">
                                    <div class="formItem-statsText">
                                        <label for="gamePlayingTime">上场时间</label>
                                        <input type="text" id="gamePlayingTime" name="gamePlayingTime" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gamePoints">得&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;分</label>
                                        <input type="text" id="gamePoints" name="gamePoints" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameShots">投&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;篮</label>
                                        <input type="text" id="gameShots" name="gameShots" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameShotsHit">投篮命中</label>
                                        <input type="text" id="gameShotsHit" name="gameShotsHit" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameThreePoints">三&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;分</label>
                                        <input type="text" id="gameThreePoints" name="gameThreePoints" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameThreePointsHit">三分命中</label>
                                        <input type="text" id="gameThreePointsHit" name="gameThreePointsHit" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameFreeThrow">罚&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;球</label>
                                        <input type="text" id="gameFreeThrow" name="gameFreeThrow" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameFreeThrowHit">罚球命中</label>
                                        <input type="text" id="gameFreeThrowHit" name="gameFreeThrowHit" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameOffensiveRebound">前场篮板</label>
                                        <input type="text" id="gameOffensiveRebound" name="gameOffensiveRebound" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameDefensiveRebound">后场篮板</label>
                                        <input type="text" id="gameDefensiveRebound" name="gameDefensiveRebound" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameBlock">盖&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;帽</label>
                                        <input type="text" id="gameBlock" name="gameBlock" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameAssists">助&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;攻</label>
                                        <input type="text" id="gameAssists" name="gameAssists" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameSteals">抢&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;断</label>
                                        <input type="text" id="gameSteals" name="gameSteals" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameFoul">犯&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;规</label>
                                        <input type="text" id="gameFoul" name="gameFoul" value="0" />
                                    </div>
                                    <div class="formItem-statsText">
                                        <label for="gameFaults">失&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;误</label>
                                        <input type="text" id="gameFaults" name="gameFaults" value="0" />
                                    </div>
                                </div>
                                <div class="formMsg">请输入正确数值</div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th class="tr">首发</th>
                        <td>
                            <div class="formList">
                                <div class="formItem">
                                    <div class="formItem-checkbox">
                                        <input type="checkbox" id="gameStarter" name="gameStarter" value="1" />
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <td class="formTableBtn"><input type="submit" id="gameSubmit" value="提交" /><asp:Literal ID="BackBtn" runat="server"></asp:Literal></td>
                    </tr>
                </table>
                <div class="fixedBox hide">
                    <div class="fixedBox-main">
                        <div class="fixedPlayerList-word"><span class="sel">A</span><span>B</span><span>C</span><span>D</span><span>E</span><span>F</span><span>G</span><span>H</span><span>I</span><span>J</span><span>K</span><span>L</span><span>M</span><span>N</span><span>O</span><span>P</span><span>Q</span><span>R</span><span>S</span><span>T</span><span>U</span><span>V</span><span>W</span><span>X</span><span>Y</span><span>Z</span></div>
                        <div class="fixedPlayerList-list">
                            <!--
                            <div class="fixedPlayerList-item">
                                <ul>
                                    <li>
                                        <div class="fixedPlayerList-cName">达里奥-萨里奇1</div>
                                        <div class="fixedPlayerList-eNmae">Dario Saric</div>
                                        <span class="hide">1</span>
                                    </li>
                                </ul>
                            </div>
                            -->
                            <asp:Literal ID="PlayerList" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            var fixedPlayerList = $(".fixedBox");
            var gamePlayer = $("#gamePlayer");
            var gameTeam = $("#gameTeam");
            var gamePlayerId = $("#gamePlayerId");
            var gameStats = $(".formItem-statsText input");
            var wordList = $(".fixedPlayerList-word span");
            var itemList = $(".fixedPlayerList-item");
            var wordIndex = -1;
            var winW;
            var winH;
            var xPos;
            var yPos;
            
            gamePlayer.click(function () {
                winW = $(window).width();
                winH = $(window).height();
                xPos = (winW - fixedPlayerList.outerWidth()) / 2;
                yPos = (winH - fixedPlayerList.outerHeight()) / 2;
                //fixedPlayerList.show();
                fixedPlayerList.css({ "left": xPos + "px", "top": yPos + "px" });
                //$(this).val("1");
                $(this).blur();
            });
            $(".fixedPlayerList-list li").click(function () {
                gamePlayer.val($(this).find(".fixedPlayerList-cName").html());
                gamePlayerId.val($(this).find("span").html());
                fixedPlayerList.hide();
            });
            wordList.click(function () {
                if (wordIndex != wordList.index($(this))) {
                    wordIndex = wordList.index($(this));
                    wordList.filter(".sel").removeClass("sel");
                    $(this).addClass("sel");
                    itemList.filter(":visible").hide();
                    itemList.eq(wordIndex).show();
                }
            });

            stopPropagationInit("gamePlayer", "fixedBox");

            gameStats.blur(function () {
                var num = parseInt($(this).val());
                if (isNaN(num)) $(this).val("0");
                else $(this).val(num);
            });

            $("#gameSubmit").click(function () {
                var submit = true;
                if (gamePlayer.val() == "") {
                    gamePlayer.parents(".formItem").next().show();
                    submit = false;
                } else {
                    gamePlayer.parents(".formItem").next().hide();
                }
                if (gameTeam.val() == "") {
                    gameTeam.parents(".formItem").next().show();
                    submit = false;
                } else {
                    gameTeam.parents(".formItem").next().hide();
                }
                return submit;
            });

            <% if(statsId>0)
            { %>
            var playerName = "<%=playerName %>";
            var playerId=<%=playerId %>;
            var teamId=<%=teamId %>;
            var playingTime=<%=playingTime %>;
            var points=<%=points %>;
            var shots=<%=shots %>;
            var shotsHit=<%=shotsHit %>;
            var threePoints=<%=threePoints %>;
            var threePointsHit=<%=threePointsHit %>;
            var freeThrow=<%=freeThrow %>;
            var freeThrowHit=<%=freeThrowHit %>;
            var offensiveRebound=<%=offensiveRebound %>;
            var defensiveRebound=<%=defensiveRebound %>;
            var block=<%=block %>;
            var assists=<%=assists %>;
            var steals=<%=steals %>;
            var foul=<%=foul %>;
            var faults=<%=faults %>;
            gamePlayer.val(playerName);
            gamePlayerId.val(playerId);
            gameTeam.find("option:gt(0)").each(function(){
                if($(this).val()==teamId) $(this).attr("selected","selected");
            });
            $("#gamePlayingTime").val(playingTime);
            $("#gamePoints").val(points);
            $("#gameShots").val(shots);
            $("#gameShotsHit").val(shotsHit);
            $("#gameThreePoints").val(threePoints);
            $("#gameThreePointsHit").val(threePointsHit);
            $("#gameFreeThrow").val(freeThrow);
            $("#gameFreeThrowHit").val(freeThrowHit);
            $("#gameOffensiveRebound").val(offensiveRebound);
            $("#gameDefensiveRebound").val(defensiveRebound);
            $("#gameBlock").val(block);
            $("#gameAssists").val(assists);
            $("#gameSteals").val(steals);
            $("#gameFoul").val(foul);
            $("#gameFaults").val(faults);
            <% if(starter) 
            {
            %>
            $("#gameStarter").attr("checked","checked");
            <%}} %>
        });
    </script>
</body>
</html>
