<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameEdit.aspx.cs" Inherits="TestWeb.Admin.GameEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<form method="post" action="/Admin/GameSend.aspx">
<% 
    if (Id > 0)
    {
        Response.Write("<input type='hidden' value='" + Id.ToString() + "' id='gameId' name='gameId' />");
    }
     %>
<div class="formTable">
    <div class="formItems">
        <div class="formHeader">比赛时间</div>
        <div class="formControl gameDate">
            <div>
                <select id="gameYear" name="gameYear">
                    <option value="">请选择</option>
                </select>
                <span>年</span>
            </div>
            <div>
                <select id="gameMonth" disabled="disabled" name="gameMonth">
                    <option value="">请选择</option>
                </select>
                <span>月</span>
            </div>
            <div>
                <select id="gameDay" disabled="disabled" name="gameDay">
                    <option value="">请选择</option>
                </select>
                <span>日</span>
            </div>
            <div>
                <select id="gameHour" name="gameHour">
                    <option value="">请选择</option>
                </select>
                <span>时</span>
            </div>
            <div>
                <select id="gameMinute" name="gameMinute">
                    <option value="">请选择</option>
                </select>
                <span>分</span>
            </div>
            <div class="red">*</div>
        </div>
        <div class="formMsg">请选择完整时间</div>
    </div>
    <div class="formItems">
        <div class="formHeader">赛季</div>
        <div class="formControl gameSeason">
            <input type="text" placeholder="请输入赛季名称，如：2018-19" id="gameSeason" name="gameSeason" />
            <div class="red">*</div>
        </div>
        <div class="formMsg">请按格式填写，如：XXXX-XX</div>
    </div>
    <div class="formItems">
        <div class="formHeader">比赛队伍</div>
        <div class="formControl gameTeam">
            <div>
                <span>客队</span>
                <select id="gameAway" name="gameAway">
                    <option>请选择</option>
                    <asp:Literal ID="AwaySelect" runat="server"></asp:Literal>
                </select>
            </div>
            <div>
                <span>主队</span>
                <select id="gameHome" name="gameHome">
                    <option>请选择</option>
                    <asp:Literal ID="HomeSelect" runat="server"></asp:Literal>
                </select>
            </div>
            <div class="red">*</div>
        </div>
        <div class="formMsg">请选择队伍</div>
    </div>
    <div class="formItems">
        <div class="formHeader"></div>
        <div class="formControl gameSubmit"><input type="submit" value="提交" id="gameSubmit" /></div>
    </div>
</div>
</form>
<script type="text/javascript">
    $(function () {
        var formYear = $("#gameYear");
        var formMonth = $("#gameMonth");
        var formDay = $("#gameDay");
        var formHour = $("#gameHour");
        var formMinute = $("#gameMinute");
        var formSeason = $("#gameSeason");
        var formAway = $("#gameAway");
        var formHome = $("#gameHome");
        var year, month, day, hour, minute, season, id, away, home;
        var today = (new Date()).getFullYear();
        if(<%=Id %>>0){
            year=<%=Year %>;
            month=<%=Month %>;
            day=<%=Day %>;
            hour=<%=Hour %>;
            minute=<%=Minute %>;
            season="<%=Season %>";
            id=<%=Id %>;
            away=<%=Away %>;
            home=<%=Home %>;
        }
        for(var h=2018;h<=today;h++){
            if(year==h) formYear.append("<option value='" + h + "' selected='selected'>" + h + "</option>");
            else formYear.append("<option value='" + h + "'>" + h + "</option>");
        }
        formYear.change(function () {
            if ($(this).val() == "") {
                formMonth.find("option:first").attr("selected", true);
                formMonth.attr("disabled", "disabled");
                formDay.find("option:first").attr("selected", true);
                formDay.attr("disabled", "disabled");
            } else {
                formMonth.removeAttr("disabled");
            }
        });
        for (var i = 1; i <= 12; i++) {
            if(month==i) {
                formMonth.append("<option value='" + i + "' selected='selected'>" + i + "</option>");
                formMonth.removeAttr("disabled");
            }
            else formMonth.append("<option value='" + i + "'>" + i + "</option>");
        }
        var days = 30;
        var selectMonth;
        formMonth.change(function () {
            //formDay.find("option:first").attr(["selected": true,"disabled":"disabled"]);
            formDay.find("option:first").attr("selected", true);
            formDay.find("option:gt(0)").remove();
            selectMonth = $(this).val();
            if (selectMonth == "") {
                formDay.attr("disabled", "disabled");
            } else {
                formDay.removeAttr("disabled");
                if (selectMonth == "1" || selectMonth == "3" || selectMonth == "5" || selectMonth == "7" || selectMonth == "8" || selectMonth == "10" || selectMonth == "12") days = 31;
                else if (selectMonth == "4" || selectMonth == "6" || selectMonth == "9" || selectMonth == "11") days = 30;
                else {
                    var intMonth = parseInt(selectMonth);
                    if (intMonth % 400 == 0 || (intMonth % 4 == 0 && intMonth % 100 != 0)) days = 29;
                    else days = 28;
                }
            }
            for (var j = 1; j <= days; j++) {
                formDay.append("<option value='" + j + "'>" + j + "</option>");
            }
        });

        selectMonth = month;
        if (selectMonth == "1" || selectMonth == "3" || selectMonth == "5" || selectMonth == "7" || selectMonth == "8" || selectMonth == "10" || selectMonth == "12") days = 31;
        else if (selectMonth == "4" || selectMonth == "6" || selectMonth == "9" || selectMonth == "11") days = 30;
        else {
            var intMonth = parseInt(selectMonth);
            if (intMonth % 400 == 0 || (intMonth % 4 == 0 && intMonth % 100 != 0)) days = 29;
            else days = 28;
        }
        for(var m=1;m<=days;m++){
            if(day==m) {
                formDay.append("<option value='" + m + "' selected='selected'>" + m + "</option>");
                formDay.removeAttr("disabled");
            }
            else formDay.append("<option value='" + m + "'>" + m + "</option>");
        }

        for (var k = 0; k < 24; k++) {
            if (k < 10) {
                if(hour==k) formHour.append("<option value='0" + k + "' selected='selected'>0" + k + "</option>");
                else formHour.append("<option value='0" + k + "'>0" + k + "</option>");
            }
            else {
                if(hour==k) formHour.append("<option value='" + k + "' selected='selected'>" + k + "</option>");
                else formHour.append("<option value='" + k + "'>" + k + "</option>");
            }
        }
        for (var l = 0; l < 60; l++) {
            if (l < 10) {
                if(minute==l) formMinute.append("<option value='0" + l + "' selected='selected'>0" + l + "</option>");
                else formMinute.append("<option value='0" + l + "'>0" + l + "</option>");
            }
            else {
                if(minute==l) formMinute.append("<option value='" + l + "' selected='selected'>" + l + "</option>");
                else formMinute.append("<option value='" + l + "'>" + l + "</option>");
            }
        }

        if(<%=Id %>>0) formSeason.val(season);

        formAway.find("option:gt(0)").each(function(){
            if($(this).val()==away) {
                $(this).attr("selected","selected");
            }
        });
        formHome.find("option:gt(0)").each(function(){
            if($(this).val()==home) {
                $(this).attr("selected","selected");
            }
        });

        $("#gameSubmit").click(function () {
            var submit = true;
            if (formYear.val() == "" || formMonth.val() == "" || formDay.val() == "" || formHour.val() == "" || formMinute.val() == "") {
                formYear.parents(".formControl").next().show();
                submit = false;
            } else {
                formYear.parents(".formControl").next().hide();
            }
            console.log("isSeasonRight return " + isSeasonRight());
            if (!isSeasonRight()) {
                formSeason.parents(".formControl").next().show();
                submit = false;
            } else {
                formSeason.parents(".formControl").next().hide();
            }
            if (formAway.val() == "" || formHome.val() == "" || formAway.val() == formHome.val()) {
                formAway.parents(".formControl").next().show();
                submit = false;
            } else {
                formAway.parents(".formControl").next().hide();
            }
            return submit;
        });
        var isSeasonRight = function () {
            if (formSeason.val() != "") {
                var str = formSeason.val().split("-");
                console.log(str.length + "," + str[0] + "," + str[1] + "," + parseInt(str[0]) % 100 + "," + (parseInt(str[1]) - 1));
                console.log((parseInt(str[0]) % 100 != parseInt(str[1]) - 1));
                if (str.length != 2) return false;
                else if (str[0].length != 4 || str[1].length != 2) return false;
                else if (parseInt(str[0]) % 10000 < 1000 || parseInt(str[0]) % 10000 > 2050) return false;
                else if (parseInt(str[1]) % 100 > 99) return false;
                else if (parseInt(str[0]) % 100 != parseInt(str[1]) - 1) return false;
                else return true;
            } else return false;
        }
    });
</script>
</asp:Content>
