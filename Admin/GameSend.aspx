﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameSend.aspx.cs" Inherits="TestWeb.Admin.GameSend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <% Response.Write("<link href='/Styles/master.css?v=" + (DateTime.Now.Subtract(new DateTime())).TotalSeconds.ToString() + "' type='text/css' rel='stylesheet' />"); %>
    <script type="text/javascript" src="/Scripts/jquery-1.12.4.min.js"></script>
    <title></title>
</head>
<body>
    <div class="sendMsg">
        <div class="sendMsg-text"><asp:Literal ID="Msg" runat="server"></asp:Literal></div>
        <div class="sendMsg-notice">如果<span>5</span>秒之后没有自动跳转，请点击<a href="/Admin/GameManagement.aspx">这里</a>。</div>
    </div>
    <asp:Literal ID="ErrorMsg" runat="server"></asp:Literal>
    <script type="text/javascript">
        $(function () {
            var wHeight = $(window).height();
            var dHeight = $(".sendMsg").outerHeight();
            var top = (wHeight - dHeight) / 2;
            $(".sendMsg").css("margin-top", top + "px");

            var timerSpan = $(".sendMsg-notice span");
            var second = 5;
            var t;
            var changeSecond = function () {
                timerSpan.html(second);
                if (second == 0) window.location = "/Admin/GameManagement.aspx";
                //if (second == 0) window.location = "#";
                else second--;
            }

            changeSecond();
            t = setInterval(changeSecond, 1000);
        });
    </script>
</body>
</html>
