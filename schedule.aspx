<%@ Page Title="NBA 2018-2019赛季 常规赛赛程" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="schedule.aspx.cs" Inherits="TestWeb._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <!-- calendar -->
    <div class="calendar">
        <div class="calendar-header"><asp:Literal ID="CalendarAsp" runat="server" /></div>
        <div class="calendar-list">
            <div style="width:2788px;">
                <asp:Literal ID="ClaendarList" runat="server" />
            </div>
        </div>
    </div>

    <!-- gamelist -->
    <div class="gamelist">
        <asp:Literal ID="gameList" runat="server" />
    </div>
    <script type="text/javascript">
        $(function () {
            $(".gamelist").delegate(".gamelist-item-header", "click", function () {
                $(this).next().slideToggle("fast");
            });
        });
    </script>

</asp:Content>
