<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="Grouplist.aspx.cs" Inherits="Groups_Grouplist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
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
    </script>
    <style type="text/css">
        .colorpicker
        {
            display: block;
            width: 12px;
            height: 12px;
            float: left;
            border: 1px solid #000;
            margin-right: 2px;
            cursor: pointer;
        }
        #colorpicker1
        {
            background-color:Aqua;
            }
        #colorpicker2
        {
            background-color:Yellow;
            }
        #colorpicker3
        {
            background-color:red;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        团队列表
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            团队列表
        </div>
        <asp:Repeater ID="rptGroups" runat="server">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <td>
                                名称
                            </td>
                            <td>
                                时间
                            </td>
                            <td>
                                人数
                            </td>
                            <td>
                                集合点
                            </td>
                            <td>
                                返程点
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
                            <%#((DateTime)Eval("BeginDate")).ToShortDateString() + "-" + ((DateTime)Eval("EndDate")).ToShortDateString()%>
                        </td>
                        <td>
                            <%#int.Parse(Eval("AdultsAmount").ToString()) + int.Parse(Eval("AdultsAmount").ToString())%>
                        </td>
                        <td>
                            <%#Eval("Gether")%>
                        </td>
                        <td>
                            <%#Eval("BackPlace")%>
                        </td>
                    </tr>
                </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    <span class="colorpicker" id="colorpicker1"></span>完成的行程<br />
    <span class="colorpicker" id="colorpicker2"></span>进行中的行程<br />
    <span class="colorpicker" id="colorpicker3"></span>未开始的行程<br />
    </div>
</asp:Content>
