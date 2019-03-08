<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameList.aspx.cs" Inherits="TestWeb.Admin.GameManagements.GameList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <% Response.Write("<link href='/Styles/admin_master.css?v=" + (DateTime.Now.Subtract(new DateTime())).TotalSeconds.ToString() + "' type='text/css' rel='stylesheet' />"); %>
    <script type="text/javascript" src="/Scripts/jquery-1.12.4.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="p30">
        <div class="breadCrumb"><a href="/Admin/Default.aspx" target="rightFrame">首页</a>&nbsp;&nbsp;&gt;&nbsp;&nbsp;<span>比赛时间</span></div>
        <div class="moreLink"><a href="/Admin/GameManagements/GameEdit.aspx" target="rightFrame">添加比赛</a></div>
        <div class="listTable">
            <table>
                <colgroup>
                    <col style="width:5%" />
                    <col style="width:10%" />
                    <col style="width:10%" />
                    <col style="width:10%" />
                    <col style="width:50%" />
                    <col style="width:15%" />
                </colgroup>
                <tr class="tbg0">
                    <th></th>
                    <th>比赛时间</th>
                    <th>客队</th>
                    <th>主队</th>
                    <th></th>
                    <th>管理操作</th>
                </tr>
                <!--
                <tr class="tbg1">
                    <td>1</td>
                    <td>2018-10-17 08:00</td>
                    <td>凯尔特人</td>
                    <td>湖人</td>
                    <td></td>
                    <td><a href="#" target="rightFrame">编辑</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="#" target="rightFrame">删除</a></td>
                </tr>
                <tr class="tbg2">
                    <td>1</td>
                    <td>2018-10-17 08:00</td>
                    <td>凯尔特人</td>
                    <td>湖人</td>
                    <td></td>
                    <td><a href="#" target="rightFrame">编辑</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="#" target="rightFrame">删除</a></td>
                </tr>
                -->
                <asp:Literal ID="GameListTable" runat="server"></asp:Literal>
            </table>
        </div>
        <div class="pageNumControl">
            <asp:Literal ID="PageNum" runat="server"></asp:Literal>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $(".listTable tr:gt(0)").mouseenter(function () {
                $(this).addClass("tbg3");
            }).mouseleave(function () {
                $(this).removeClass("tbg3");
            });
        });
    </script>
    </form>
</body>
</html>
