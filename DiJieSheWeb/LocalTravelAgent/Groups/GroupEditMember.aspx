<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupEditMember.aspx.cs" Inherits="LocalTravelAgent_Groups_GroupEditMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <link href="/Scripts/jqueryplugin/jqueryui/css/smoothness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <style type="text/css">
    </style>
    <script language="javascript" type="text/javascript">
        $(function () {

            var cookieName = "djsmetab";

            $("#tabs").tabs({
                active: $.cookie(cookieName),
                activate: function (event, ui) {
                    $.cookie(cookieName, ui.newTab.index(), { expires: 365 });
                }
            });
            $("#tabs").bind('tabsselect', function (event, ui) {
                    if (ui.index == "0") {
                        $("[id$='btnCss']").click();
                    }
            });

            $(".tablesorter").tablesorter();
            $(".IndexTable").orderIndex();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="navlist">
        <a runat="server" id="a_link_1" href="/LocalTravelAgent/Groups/GroupEditBasicInfo.aspx" >录入团队基本信息</a>
        <a runat="server" id="a_link_2" href="/LocalTravelAgent/Groups/GroupEditMember.aspx" class="selectstate">录入游客信息</a>
        <a runat="server" id="a_link_3" href="/LocalTravelAgent/Groups/GroupEditRoute.aspx">录入行程信息</a>
    </div>
    <div style="clear:both">
    </div>
    <h3 style="margin-left:15px;margin-top:30px">
        <b>
            团队名称:<%=CurrentGroup.Name %>游客列表</b></h3>
    <div class="tabintro">
        根据您方便，选择其中一种方式录入游客信息
    </div>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">直接录入</a></li>
            <li><a href="#tabs-2">文本录入</a></li>
            <li><a href="#tabs-3">Excel导入</a></li>
        </ul>
        <div id="tabs-1">
            <asp:Repeater runat="server" ID="rptMembers" OnItemCommand="rptMembers_ItemCommand">
                <HeaderTemplate>
                    <table class="tablesorter IndexTable" style="margin:0px">
        </table>
                    <table class="tablesorter InfoTable" style="width:650px;margin:0px;margin-top:2px">
                        <thead>
                        <tr>
                            <th>
                                类型
                            </th>
                            <th>
                                姓名
                            </th>
                            <th>
                                证件号码
                            </th>
                            <th>
                                联系电话
                            </th>
                            <th>
                                修改
                            </th>
                        </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("MemberType") %>
                        </td>
                        <td>
                            <%#Eval("RealName")%>
                        </td>
                        <td>
                            <%#Eval("IdCardNo")%><%#Eval("SpecialCardNo")%>
                        </td>
                        <td>
                            <%#Eval("PhoneNum")%>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnModifyMember" CommandArgument='<%#Eval("Id") %>'
                                CommandName="Edit" Text="修改" />
                                 <asp:Button runat="server" ID="btnDeleteMember"  OnClientClick="javascript:return confirm('确定删除?');"  CommandArgument='<%#Eval("Id") %>'
                                CommandName="Delete" Text="删除" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Button runat="server" ID="btnAddMember" OnClick="btnAddMember_Click" Text="增加成员" CssClass="btn" style="margin-top:15px" />
            <div style="display:none">
                <asp:Button ID="btnCss" runat="server" OnClick="btnCss_Click" />
            </div>
            <asp:Panel runat="server" ID="pnlMemberEdit" Visible="false">
                <fieldset>
                    <legend></legend>
                    <table>
                        <tr>
                            <td>
                                类型
                            </td>
                            <td>
                                <asp:RadioButtonList runat="server" ID="rblMemberType" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">成人游客</asp:ListItem>
                                    <asp:ListItem Value="2">儿童</asp:ListItem>
                                    <asp:ListItem Value="3">外宾</asp:ListItem>
                                    <asp:ListItem Value="4">港澳台</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                姓名
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="tbxName" ErrorMessage="必填" ForeColor="Red" 
                                    ValidationGroup="SaveMember"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                身份证号码
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxIdCardNo"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                其他证件号码
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxSpecialCardNo"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                联系电话
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="tbxPhone"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <asp:Button runat="server" OnClick="btnSaveMember_Click" ID="btnSave" Text="保存" 
                        CssClass="btn" ValidationGroup="SaveMember" />
                    <asp:Button runat="server" OnClick="btnCancel_Click" ID="btnCancel" Text="取消" CssClass="btn" />
                </fieldset>
            </asp:Panel>
        </div>
        <div id="tabs-2">
            
            <asp:TextBox TextMode="MultiLine" runat="server" ID="tbxSimple" CssClass="tbMemberSingleText" style="width:97%"></asp:TextBox>
            <asp:Button runat="server" ID="btnSaveSimple" OnClick="btnSave_Click" OnClientClick="javascript:return confirm('原有的团队成员信息将清除,是否继续?');"
                Text="保存" CssClass="btn" />
            <asp:Label runat="server" ID="lblSimpleMsg" ForeColor="green"></asp:Label>
            <div style="padding:10px 15px 10px 15px">
                <p style=" font-weight:bold">
                    文本录入格式要求
                </p>
                <p>
                    <span style="margin-bottom:10px; display:block;">
                        1)单个游客的资料用<color style=" color:#ED6942; font-weight:bold;">反斜杠\</color>分隔,
                    </span>
                    <span style="margin-bottom:10px;display:block;margin-left:12px">
                        按序依次为:<color style=" color:#ED6942; font-weight:bold;">成员类型</color>(成人游客,儿童，外宾，港澳台),<color style=" color:#ED6942; font-weight:bold;">姓名,证件号码</color>(身份证或者其他有效证件),<color style=" color:#ED6942; font-weight:bold;">联系电话</color>
                    </span>
                    <span style="margin-bottom:10px; display:block;">
                        2)每一行只录一名游客的信息，如果没有对应信息可以不录
                    </span>
                    <span style="margin-bottom:10px;display:block;margin-left:12px">
                        范例：成人游客\张晓华\51332919880321639X\13287839485（游客类型,姓名,证件号码,联系电话）
                    </span>
                    <span style="margin-bottom:10px;display:block;margin-left:48px">
                        外宾\Jim Green\CH1034123\13287839485（游客类型,姓名,证件号码,联系电话）
                    </span>
                    <span style="margin-bottom:10px;display:block;margin-left:48px">
                        儿童\李晓彤（游客类型,姓名）
                    </span>
                </p>
            </div>
        </div>
        <div id="tabs-3">
            <p>
                将游客信息从的Excel文件中导进系统.请下载模板文件,按照规范填入数据.</p>
            <p>
                <a href="">Excel模板文件下载</a>
            </p>
            <asp:TextBox TextMode="MultiLine" runat="server" ID="tbxExcel" CssClass="tbMemberSingleText" style="width:97%"></asp:TextBox>
            <p>
                <asp:FileUpload runat="server" ID="fuMemberExcel" />
                <asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="btnUpload_Click" CssClass="btn" />
                <asp:Label ID="Label1" runat="server" />
                <asp:Button runat="server" ID="Button1" OnClick="btnExcel_Click" CssClass="btn" OnClientClick="javascript:return confirm('原有的团队成员信息将清除,是否继续?');"
                    Text="保存" />
            </p>
        </div>
    </div>
</asp:Content>
