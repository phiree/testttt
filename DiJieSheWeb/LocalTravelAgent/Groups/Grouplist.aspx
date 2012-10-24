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
                var dateperiod = $(this).children().next().next().html();
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
            margin-left: 10px;
            width: 12px;
            height: 12px;
            float:right;
            border: 1px solid #000;
            margin-right: 2px;
            margin-top:4px;
            cursor: pointer;
        }
        .colorWord
        {
            display: block;
            margin-left: 2px;
            float:right;
            margin-right: 5px;
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
    <span class="colorWord">未开始的行程</span><span class="colorpicker" id="colorpicker3"></span>
    <span class="colorWord">进行中的行程</span><span class="colorpicker" id="colorpicker2"></span>
    <span class="colorWord">完成的行程</span><span class="colorpicker" id="colorpicker1"></span>
        </div>
        <asp:Repeater ID="rptGroups" runat="server">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <td>
                                编号
                            </td>
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
                                操作
                            </td>
                            
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody id="routeList">
                    <tr>
                        <td>
                            <%#Eval("No")%>
                        </td>
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
                           <a href='GroupEditBasicInfo.aspx?groupid=<%#Eval("id") %>'>修改基本信息</a>
<a href='GroupEditMember.aspx?groupid=<%#Eval("id") %>'>修改人员信息</a>
                           <a href='GroupEditRoute.aspx?groupid=<%#Eval("id") %>'>修改线路信息</a>
                        </td>
                        <td>
                            
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
