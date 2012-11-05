<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="Grouplist.aspx.cs" Inherits="Groups_Grouplist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
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
    <div>
    <a href="GroupEditBasicInfo.aspx">新建团队</a> <a href="">从Excel导入新团队</a>
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
                                <a href="">从Excel文件更新</a>
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
