<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupEditBasicInfo.aspx.cs" Inherits="LocalTravelAgent_Groups_GroupEditBasicInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../Content/themes/base/minified/jquery-ui.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.9.2.min.js"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $("#<%=tbxDateBegin.ClientID %>").datepicker({ minDate:new Date() });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="navlist">
        <a runat="server" id="a_link_1" href="/LocalTravelAgent/Groups/GroupEditBasicInfo.aspx"  class="selectstate">录入团队基本信息</a>
        <a runat="server" id="a_link_2" href="/LocalTravelAgent/Groups/GroupEditMember.aspx">录入游客信息</a>
        <a runat="server" id="a_link_3" href="/LocalTravelAgent/Groups/GroupEditRoute.aspx">录入行程信息</a>
    </div>
    
    <%--<div class="detail_titlebg">
        新增团队
    </div>--%>
    <div class="navstate">
        
    </div>
    <div class="detaillist">
        <table class="comTable">
            <tr>
                <td>
                    团队名称
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxName"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" ControlToValidate="tbxName" Display="Dynamic" runat="server" ErrorMessage="请填写团队名称"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td>
                    开始时间
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxDateBegin"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  Display="Dynamic" runat="server" ControlToValidate="tbxDateBegin"  ErrorMessage="请输入开始时间"></asp:RequiredFieldValidator> </td>
            </tr>
            <tr>
                <td>
                    总天数
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxDateAmount"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  Display="Dynamic"  ControlToValidate="tbxDateAmount" runat="server" 
                    ValidationExpression="\d+" ErrorMessage="请输入数字"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"   Display="Dynamic"  ControlToValidate="tbxDateAmount" runat="server" ErrorMessage="请输入游玩天数"></asp:RequiredFieldValidator>  </td>
            </tr>
            <tr>
                <td>
                    导游
                </td>
                <td>
                    <asp:CheckBoxList runat="server" ID="cbxGuides" CssClass="rbl" style="margin:0px 0px 5px 0px"></asp:CheckBoxList>
                     <span><a href="/LocalTravelAgent/GuideList.aspx">增加/管理导游</a></span>
                </td>
            </tr>
              <tr>
                <td>
                    司机
                </td>
                <td>
                    <asp:CheckBoxList runat="server" ID="cbxDrivers"></asp:CheckBoxList>
                    <span><a href="/LocalTravelAgent/DriverList.aspx"> 增加/管理司机</a></span>
                </td>
            </tr>
             
        </table>
        <asp:Button runat="server" ID="btnSaveBasicInfo" OnClick="btnBasicInfo_Click" Text="保存" CssClass="btn" style="margin-left:350px" />
       <asp:Label runat="server" ID="lblMsg"></asp:Label>
        <%--<asp:Panel runat="server" ID="pnlLinks">
            <a href="GroupEditMember.aspx?groupid=<%=groupId %>">编辑成员信息</a>
             <a href="GroupEditRoute.aspx?groupid=<%=groupId %>">
                编辑行程信息</a>
        </asp:Panel>--%>
    </div>
</asp:Content>
