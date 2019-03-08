<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestWeb.Admin.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <% Response.Write("<link href='/Styles/admin_master.css?v=" + (DateTime.Now.Subtract(new DateTime())).TotalSeconds.ToString() + "' type='text/css' rel='stylesheet' />"); %>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="defultTable p30">
        <table>
            <colgroup>
                <col style="width:25%" />
                <col style="width:25%" />
                <col style="width:25%" />
                <col style="width:25%" />
            </colgroup>
            <tr>
                <th>比赛记录</th><td><asp:Literal ID="GameCount" runat="server"></asp:Literal>条</td>
                <th>赛果记录</th><td><asp:Literal ID="GameStatsCount" runat="server"></asp:Literal>条</td>
            </tr>
            <tr>
                <th>球员记录</th><td><asp:Literal ID="PlayerCount" runat="server"></asp:Literal>条</td>
                <th>球队成员记录</th><td><asp:Literal ID="TeamPlayerCount" runat="server"></asp:Literal>条</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
