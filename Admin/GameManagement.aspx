<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameManagement.aspx.cs" Inherits="TestWeb.Admin.GameManagement" %>
<%@ Import Namespace="TestWeb.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<!--
<form method="post" action="">
<div class="formTable">
    <div class="formItems">
        <div class="formHeader">比赛时间</div>
        <div class="formControl gameDate">
            <div>
                <select id="gameYear">
                    <option>请选择</option>
                    <option>2018</option>
                </select>
                <span>年</span>
            </div>
            <div>
                <select id="gameMonth">
                    <option>请选择</option>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                    <option>6</option>
                    <option>7</option>
                    <option>8</option>
                    <option>9</option>
                    <option>10</option>
                    <option>11</option>
                    <option>12</option>
                </select>
                <span>月</span>
            </div>
            <div>
                <select id="gameDay">
                    <option>请选择</option>
                </select>
                <span>日</span>
            </div>
            <div>
                <select>
                    <option>请选择</option>
                    <option>0</option>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                    <option>6</option>
                    <option>7</option>
                    <option>8</option>
                    <option>9</option>
                    <option>10</option>
                    <option>11</option>
                    <option>12</option>
                    <option>13</option>
                    <option>14</option>
                    <option>15</option>
                    <option>16</option>
                    <option>17</option>
                    <option>18</option>
                    <option>19</option>
                    <option>20</option>
                    <option>21</option>
                    <option>22</option>
                    <option>23</option>
                </select>
                <span>时</span>
            </div>
            <div>
                <select>
                    <option>请选择</option>
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
            <input type="text" placeholder="请输入赛季名称，如：2018-19" id="season" />
            <div class="red">*</div>
        </div>
        <div class="formMsg">请按格式填写，如：XXXX-XX</div>
    </div>
    <div class="formItems">
        <div class="formHeader">比赛队伍</div>
        <div class="formControl gameTeam">
            <div>
                <span>客队</span>
                <select>
                    <option>请选择</option>
                </select>
            </div>
            <div>
                <span>主队</span>
                <select>
                    <option>请选择</option>
                </select>
            </div>
            <div class="red">*</div>
        </div>
        <div class="formMsg">请选择队伍</div>
    </div>
    <div class="formItems">
        <div class="formHeader"></div>
        <div class="formControl gameSubmit"><input type="submit" value="提交" /></div>
    </div>
</div>
</form>
-->
<div class="gameManageBtn">
    <a href="/Admin/GameEdit.aspx">添加</a>
</div>
<div class="gameList">
    <table>
        <colgroup>
            <col style="width:20%;" />
            <col style="width:10%;" />
            <col style="width:10%;" />
            <col style="width:45%;" />
            <col style="width:15%;" />
        </colgroup>
        <tr class="tableBg_0">
            <th>时间</th><th>客队</th><th>主队</th><th></th><th></th>
        </tr>
        <!--
        <tr class="tableBg_1">
            <td>2018-10-17 08:00</td><td>76人</td><td>凯尔特人</td><td></td><td><a href="#">编辑</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="#">删除</a></td>
        </tr>
        <tr class="tableBg_2">
            <td>2018-10-17 08:00</td><td>76人</td><td>凯尔特人</td><td></td><td><a href="#">编辑</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="#">删除</a></td>
        </tr>
        <tr class="tableBg_1">
            <td>2018-10-17 08:00</td><td>76人</td><td>凯尔特人</td><td></td><td><a href="#">编辑</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="#">删除</a></td>
        </tr>
        <tr class="tableBg_2">
            <td>2018-10-17 08:00</td><td>76人</td><td>凯尔特人</td><td></td><td><a href="#">编辑</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href="#">删除</a></td>
        </tr>
        -->
        <asp:Literal ID="GameListTable" runat="server"></asp:Literal>
    </table>
    <!--
    <div class="pageNum">
        <span class="unable">上一页</span>
        <a href="#">1</a>
        <span>...</span>
        <a href="#">11</a>
        <span class="red">12</span>
        <a href="#">13</a>
        <a href="#">14</a>
        <a href="#">15</a>
        <a href="#">16</a>
        <a href="#">17</a>
        <a href="#">18</a>
        <a href="#">19</a>
        <a href="#">20</a>
        <span>...</span>
        <a href="#">51</a>
        <a href="#">下一页</a>
    </div>
    -->
    <asp:Literal ID="PageNum" runat="server"></asp:Literal>
</div>
</asp:Content>
