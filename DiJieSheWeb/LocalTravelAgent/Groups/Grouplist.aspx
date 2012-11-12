<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="Grouplist.aspx.cs" Inherits="Groups_Grouplist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <%--   <style type="text/css">
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
    </style>--%>
    <script type="text/javascript">
        $(function () {
            $(".tablesorter").tablesorter({ headers: { 3: { sorter: false }, 4: { sorter: false}} });
            $(".IndexTable").orderIndex();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        团队列表
    </div>
    <div style="clear: both">
    </div>
    <div class="detaillist">
        <div class="actiondiv">
            团队操作:<a href="GroupEditBasicInfo.aspx">新建团队</a> <a href="/LocalTravelAgent/Groups/GroupInfo.aspx">
                从Excel导入新团队</a>
        </div>
        <div class="detailtitle">
            团队列表
            <%--<span class="colorWord">未开始的行程</span><span class="colorpicker" id="colorpicker3"></span>
            <span class="colorWord">进行中的行程</span><span class="colorpicker" id="colorpicker2"></span>
            <span class="colorWord">完成的行程</span><span class="colorpicker" id="colorpicker1"></span>--%>
        </div>
        <div class="searchdiv">
            <asp:RadioButtonList runat="server" ID="cblState" OnSelectedIndexChanged="cblState_Changed" RepeatDirection="Horizontal"
                AutoPostBack="true">
                <asp:ListItem Value="1" Selected="True">尚未开始</asp:ListItem>
                <asp:ListItem Value="2">正在进行</asp:ListItem>
                <asp:ListItem Value="4">已经结束</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <asp:Repeater ID="rptGroups" runat="server" OnItemDataBound="rptGroups_ItemDataBound"
            OnItemCommand="rptGroups_ItemCommand">
            <HeaderTemplate>
                <table class="IndexTable tablesorter">
                </table>
                <table class="InfoTable tablesorter">
                    <thead>
                        <tr>
                            <th>
                                <asp:LinkButton ID="lbname" runat="server" Text="名称" CommandName="lbname"></asp:LinkButton>
                            </th>
                            <th>
                                <asp:LinkButton ID="lbdate" runat="server" Text="时间" CommandName="lbdate"></asp:LinkButton>
                            </th>
                            <th>
                                <asp:LinkButton ID="lbdays" runat="server" Text="天数" CommandName="lbdays"></asp:LinkButton>
                            </th>
                            <th>
                                操作
                            </th>
                            <th>
                                备注
                            </th>
                        </tr>
                    </thead>
                    <tbody id="routeList">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/LocalTravelAgent/Groups/GroupDetail.aspx?id=<%#Eval("Id")%>'>
                            <%#Eval("Name")%></a>
                    </td>
                    <td>
                        <%#((DateTime)Eval("BeginDate")).ToShortDateString() %>
                    </td>
                    <td>
                        <%#((DateTime)Eval("EndDate")-(DateTime)Eval("BeginDate")).Days+1%>日游
                    </td>
                    <td>
                       <asp:Panel runat="server" ID="pnlOperation">
                         <a href='GroupEditBasicInfo.aspx?groupid=<%#Eval("id") %>'>

                            修改</a> <a href='/LocalTravelAgent/Groups/GroupInfo.aspx?groupid=<%#Eval("id") %>'>从Excel文件更新</a>
                        <asp:Button runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="delete"
                            Text="删除" OnClientClick='javascript:return confirm("您确认要删除这个团队么?");' />
                            </asp:Panel>
                    </td>
                    <td>
                        <asp:LinkButton ID="lblMember_bz" Text="" runat="server" /><br />
                        <asp:LinkButton ID="lblRoute_bz" Text="" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <div class="">
            <asp:Label runat="server" ID="lblMsg"></asp:Label>
        </div>
    </div>
</asp:Content>
