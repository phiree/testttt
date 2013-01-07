<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="DjsEdit.aspx.cs" Inherits="LocalTravelAgent_DjsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <% if (false)
       { %>
    <script src="/Scripts/jquery-1.6.4-vsdoc.js" type="text/javascript"></script>
    <% } %>
    <link href="/Content/themes/base/minified/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/json2.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/jquery-ui-1.9.2.min.js"></script>
    <script src="/Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.messages_zh.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validation.net.webforms.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/ContainerToJson.js" type="text/javascript"></script>
    <script src="/Scripts/Common.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        单位信息
    </div>
    <div class="detaillist">
        <table border="0" cellpadding="0" cellspacing="0" class="comTable">
            <tr>
                <td>
                    单位名称:
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="80%" Enabled="false" />
                </td>
                <td>
                    行政辖区
                </td>
                <td>
                <asp:Label runat="server" ID="lblArea"></asp:Label>
                   <asp:DropDownList ID="ddlArea" Visible=false runat="server" Width="80%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    单位电话:
                </td>
                <td>
                    <asp:TextBox ID="txtTel" runat="server" Width="80%" />
                </td>
                <td>
                    负责人姓名:
                </td>
                <td>
                    <asp:TextBox ID="txtCPN" runat="server" Width="80%" />
                </td>
            </tr>
            <tr>
                <td>
                    负责人电话:
                </td>
                <td>
                    <asp:TextBox ID="txtCPP" runat="server" Width="80%" />
                </td>
                <td>
                    负责人邮箱
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="80%" />
                </td>
            </tr>
            <tr>
                <td>
                    邮寄地址:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtAddress" runat="server" Width="92%" CssClass="required" />
                </td>
            </tr>
            <tr>
                
            </tr>
        </table>
    <div style="text-align:center">
    <asp:Button ID="btnSave" Text="保存" runat="server" ValidationGroup="vgGroup" OnClick="btnSave_Click"  CssClass="btn2 submit"
        />
    </div>
    </div>
</asp:Content>
