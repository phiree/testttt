<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="Grouplist.aspx.cs" Inherits="Groups_Grouplist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript">
        $(function () {
            var tbody = $("#routeList>tr");
            tbody.each(function () {
                //alert($(this).children().next().html());//显示日期
                //当前日期
                var myDate = new Date();
                var today = myDate.getFullYear() + "/" + (myDate.getMonth() + 1) + "/" + myDate.getDate();
                //行程日期
                var dateperiod = $(this).children().next().html();
                var date1 = Date.parse(dateperiod.split("-")[0]).toString(); //转成秒格式进行比较
                var date2 = Date.parse(dateperiod.split("-")[1]).toString(); //转成秒格式进行比较
                var tempday = Date.parse(today); //转成秒格式进行比较
                //日期比较
                if (tempday > date2) {
                    //完成的行程
                    $(this).parent().css("background-color", "Aqua");
                }
                if (date1 <= tempday && tempday <= date2) {
                    //进行中的行程
                    $(this).parent().css("background-color", "Yellow");
                }
                if (date1 > tempday) {
                    //没开始的行程
                    $(this).parent().css("background-color", "Red");
                }
            });
        });
    </script>--%>
    <style type="text/css">
        .colorpicker
        {
            display: block;
            margin-left: 10px;
            width: 12px;
            height: 12px;
            float: right;
            border: 1px solid #000;
            margin-right: 2px;
            margin-top: 4px;
            cursor: pointer;
        }
        .colorWord
        {
            display: block;
            margin-left: 2px;
            float: right;
            margin-right: 5px;
            cursor: pointer;
        }
        #colorpicker1
        {
            background-color: Aqua;
        }
        #colorpicker2
        {
            background-color: Yellow;
        }
        #colorpicker3
        {
            background-color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        团队列表
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            团队列表 <span class="colorWord">未开始的行程</span><span class="colorpicker" id="colorpicker3"></span>
            <span class="colorWord">进行中的行程</span><span class="colorpicker" id="colorpicker2"></span>
            <span class="colorWord">完成的行程</span><span class="colorpicker" id="colorpicker1"></span>
        </div>
        <asp:Repeater ID="rptGroups" runat="server" OnItemDataBound="rptGroups_ItemDataBound" OnItemCommand="rptGroups_ItemCommand">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbname" Runat="server" text="名称" CommandName="lbname"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbdate" Runat="server" text="时间" CommandName="lbdate"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lbdays" Runat="server" text="天数" CommandName="lbdays"></asp:LinkButton>
                            </td>
                            <td>
                                操作
                            </td>
                            <td>
                                备注
                            </td>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody id="routeList">
                    <tr>
                        <td>
                            <a href='/LocalTravelAgent/Groups/GroupDetail.aspx?id=<%#Eval("Id")%>'>
                                <%#Eval("Name")%></a>
                        </td>
                        <td>
                            <%#((DateTime)Eval("BeginDate")).ToShortDateString() %><%---<%#((DateTime)Eval("EndDate")).ToShortDateString()%>--%>
                        </td>
                        <td>
                            <%#((DateTime)Eval("EndDate")-(DateTime)Eval("BeginDate")).Days+1%>日游
                        </td>
                        <td>
                            <a href='GroupEditBasicInfo.aspx?groupid=<%#Eval("id") %>'>
                                修改</a>
                        </td>
                        <td>
                            <asp:LinkButton ID="lblMember_bz" Text="" runat="server" /><br />
                            <asp:LinkButton ID="lblRoute_bz" Text="" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
