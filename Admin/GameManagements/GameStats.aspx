<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameStats.aspx.cs" Inherits="TestWeb.Admin.GameManagements.GameStats" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <% Response.Write("<link href='/Styles/admin_master.css?v=" + (DateTime.Now.Subtract(new DateTime())).TotalSeconds.ToString() + "' type='text/css' rel='stylesheet' />"); %>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="p30">
        <div class="breadCrumb"><a href="/Admin/Default.aspx" target="rightFrame">首页</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<a href="/Admin/GameManagements/GameList.aspx" target="rightFrame">比赛时间</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<span>比赛数据</span></div>
        <div class="moreLink"><!--<a href="/Admin/GameManagements/GameStatsEdit.aspx" target="rightFrame">添加数据</a>--><asp:Literal ID="GameStatsEditLink" runat="server"></asp:Literal></div>
        <div class="listTable">
            <div class="listTable-header"><asp:Literal ID="AwayTableHeader" runat="server"></asp:Literal></div>
            <table>
                <colgroup>
                    <col style="width:5%;" />
                    <col style="width:15%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:10%;" />
                </colgroup>
                <tr class="tbg0">
                    <th></th>
                    <th>姓名</th>
                    <th>上场时间</th>
                    <th>首发</th>
                    <th>得分</th>
                    <th>命中/投篮</th>
                    <th>命中/三分</th>
                    <th>命中/罚球</th>
                    <th>篮板</th>
                    <th>前场篮板</th>
                    <th>后场篮板</th>
                    <th>盖帽</th>
                    <th>助攻</th>
                    <th>抢断</th>
                    <th>失误</th>
                    <th>犯规</th>
                    <th>管理操作</th>
                </tr>
                <asp:Literal ID="AwayTable" runat="server"></asp:Literal>
            </table>
        </div>
        <div class="listTable mt10">
            <div class="listTable-header"><asp:Literal ID="HomeTableHeader" runat="server"></asp:Literal></div>
            <table>
                <colgroup>
                    <col style="width:5%;" />
                    <col style="width:15%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:5%;" />
                    <col style="width:10%;" />
                </colgroup>
                <tr class="tbg0">
                    <th></th>
                    <th>姓名</th>
                    <th>上场时间</th>
                    <th>首发</th>
                    <th>得分</th>
                    <th>命中/投篮</th>
                    <th>命中/三分</th>
                    <th>命中/罚球</th>
                    <th>篮板</th>
                    <th>前场篮板</th>
                    <th>后场篮板</th>
                    <th>盖帽</th>
                    <th>助攻</th>
                    <th>抢断</th>
                    <th>失误</th>
                    <th>犯规</th>
                    <th>管理操作</th>
                </tr>
                <asp:Literal ID="HomeTable" runat="server"></asp:Literal>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
