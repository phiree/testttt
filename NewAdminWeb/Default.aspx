<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/Content/default.css" rel="stylesheet" type="text/css" />
    <script src="/js/default.js" type="text/javascript"></script>
    <script src="/js/jquery.cookie.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">
    <ext:RegionPanel ID="PanelForm" runat="server" ShowBorder="false">
        <Regions>
            <ext:Region ID="Region1" runat="server" Position="Top" ShowHeader="false" Margins="0 0 0 0"
                Layout="Fit" Height="105px">
                <Items>
                    <ext:ContentPanel ID="ContentPanel1" runat="server" CssClass="header" EnableBackgroundColor="true"
                        BodyStyle="background-color:White" ShowBorder="false" ShowHeader="false">
                        <div class="title">
                            <a href="/default.aspx">网站后台管理系统</a>
                        </div>
                        <div class="logininfo">
                            管理员：<asp:LoginName ID="LoginName1" runat="server" /> 您好,感谢登录使用！
                        </div>
                    </ext:ContentPanel>
                </Items>
                <Toolbars>
                    <ext:Toolbar ID="Toolbar1" Position="Bottom" runat="server">
                        <Items>
                            <ext:Button ID="btnUserManager" runat="server" IconUrl="~/icon/user_edit.png" Text="用户管理">
                                <Menu>
                                    <ext:MenuButton runat="server" ID="MenuButton1" Text="用户管理" IconUrl="~/icon/user_go.png">
                                        <Menu>
                                            <ext:MenuHyperLink runat="server" ID="MenuHyperLink1" IconUrl="~/icon/user_edit.png"
                                                Text="信息修改" Target="_blank" NavigateUrl="">
                                            </ext:MenuHyperLink>
                                            <ext:MenuHyperLink runat="server" ID="MenuHyperLink2" IconUrl="~/icon/user_edit.png"
                                                Text="密码修改" Target="_blank" NavigateUrl="">
                                            </ext:MenuHyperLink>
                                        </Menu>
                                    </ext:MenuButton>
                                    <ext:MenuButton runat="server" ID="MenuButton2" Text="更换用户" IconUrl="~/icon/user_b.png">
                                    </ext:MenuButton>
                                    <ext:MenuButton runat="server" ID="MenuButton3" Text="注销" IconUrl="~/icon/user_delete.png">
                                    </ext:MenuButton>
                                </Menu>
                            </ext:Button>
                            <ext:ToolbarFill ID="ToolbarFill1" runat="server">
                            </ext:ToolbarFill>
                            <ext:ToolbarText ID="ToolbarText3" Text="菜单类型:" runat="server" CssStyle="margin:0 5px 0 5px">
                            </ext:ToolbarText>
                            <ext:DropDownList ID="ddlMenuType"  Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlMenuType_SelectedIndexChanged"
                                runat="server">
                                <ext:ListItem Text="树菜单" Selected="true" Value="tree" />
                                <ext:ListItem Text="手风琴菜单" Value="accordion" />
                            </ext:DropDownList>
                            <ext:ToolbarText ID="ToolbarText1" Text="主题:" runat="server" CssStyle="margin:0 5px 0 5px">
                            </ext:ToolbarText>
                            <ext:DropDownList ID="ddlTheme" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged"
                                runat="server">
                                <ext:ListItem Text="Blue" Selected="true" Value="blue" />
                                <ext:ListItem Text="Gray" Value="gray" />
                                <ext:ListItem Text="Access" Value="access" />
                                <ext:ListItem Text="Blueen（自定义）" Value="blueen" />
                                <ext:ListItem Text="First（自定义）" Value="first" />
                                <ext:ListItem Text="Second（自定义）" Value="second" />
                                <ext:ListItem Text="Fourth（自定义）" Value="fourth" />
                            </ext:DropDownList>
                            <%--<ext:Timer ID="Timer1" runat="server" Interval="1" OnTick="Timer1_Tick">
                            </ext:Timer>--%>
                            <ext:ToolbarText ID="ToolbarText2" Text="时间:" runat="server" CssStyle="margin:0 5px 0 5px">
                            </ext:ToolbarText>
                            <ext:Label ID="lblTime" runat="server" Label="Label">
                            </ext:Label>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
            </ext:Region>
            <ext:Region ID="Region2" Split="true" EnableSplitTip="true" CollapseMode="Mini" Width="200px"
                Margins="0 0 0 0" ShowHeader="true" Title="菜单" EnableLargeHeader="false" Icon="Outline"
                EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
            </ext:Region>
            <ext:Region ID="Region3" runat="server" Position="Center" ShowHeader="false" Layout="Fit"
                Margins="0 0 0 0">
                <Items>
                    <ext:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" AutoPostBack="false" ShowBorder="false"
                        runat="server" EnableFrame="true">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="欢迎界面" Layout="Fit" Icon="House" runat="server">
                                <Items>
                                    <ext:ContentPanel ID="ContentPanel2" runat="server" BodyPadding="5px" EnableBackgroundColor="false"
                                        ShowBorder="false" ShowHeader="false">
                                        <p class="welcome">欢迎使用Tourol.cn网站后台管理系统</p>
                                    </ext:ContentPanel>
                                </Items>
                            </ext:Tab>
                        </Tabs>
                    </ext:TabStrip>
                </Items>
            </ext:Region>
        </Regions>
    </ext:RegionPanel>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="/menu.xml"></asp:XmlDataSource>
</asp:Content>
