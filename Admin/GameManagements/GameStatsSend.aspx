<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameStatsSend.aspx.cs" Inherits="TestWeb.Admin.GameManagements.GameStatsSend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="p30">
        <div class="sendMsg">
            <div class="sendMsg-text"><asp:Literal ID="Msg" runat="server"></asp:Literal></div>
            <div class="sendMsg-notice">如果<span>5</span>秒之后没有自动跳转，请点击<a href="/Admin/GameManagements/GameStats.aspx" target="rightFrame">这里</a><asp:Literal ID="GameStatsLink" runat="server"></asp:Literal>。</div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            var wHeight = $(window).height() - 60;
            var dHeight = $(".sendMsg").outerHeight();
            var top = (wHeight - dHeight) / 2;
            $(".sendMsg").css("margin-top", top + "px");

            var timerSpan = $(".sendMsg-notice span");
            var second = 5;
            var t;
            var str = "<%=str %>";
            var changeSecond = function () {
                timerSpan.html(second);
                if (second == 0)
                    window.location = str;
                else second--;
            }

            changeSecond();
            t = setInterval(changeSecond, 1000);
        });
    </script>
    </form>
</body>
</html>
