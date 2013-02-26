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
                            <a href="/default.aspx">网站管理系统后台</a>
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
                                        <div class="default_left">
                                            <p>
                                                感谢您使用 subway总店后台管理系统平台介绍</p>
                                            <h3>
                                                系统简介</h3>
                                            <div class="intro_info">
                                                &nbsp;&nbsp;&nbsp;&nbsp;《 subway后台管理系统平台》是一套为subway总店后台打造的一款网站系统。本系统经过了周密的项目调查、分析，根据商业模式设计产品功能，系统功能强大、操作简单，并完美体现和满足商业模式对系统的功能要求。<br />
                                                《subway后台管理系统平台》并采取本系统由前台订餐和后台管理两部分组成。前台订餐模块为顾客提供了点餐，预定服务，外送服务。后台管理模块由食材管理、会员管理、账单管理、标签管理、广告设置等部分组成，为网站提供了简单便捷的管理方式。<br />
                                                《subway后台管理系统平台》为准备运营subway提供了一个高效、快速、专业的网站建设解决方案。有效的为投资者减少投资、节省开发时间，大大降低项目风险和投资门槛，使其能够把99%的时间和精力放在网站的运营上。
                                            </div>
                                            <h3>
                                                系统特点</h3>
                                            <div class="intro_info">
                                                &nbsp;&nbsp;&nbsp;&nbsp;项目为先：以项目为出发地，技术服从项目，以商业模式为依据进行产品研发，根据运营需求进行代码实现。<br />
                                                技术先进：本系统采用新的技术，保证在大数据、高并发运行状态下的系统稳定、可靠。
                                                <br />
                                                功能强大：系统功能强大，简答易用，真正做到了智能化管理。
                                                <br />
                                                高度集成：系统与支付平台、短信平台、财务平台高度集成。极大的丰富了产品的功能，为项目管理提供极大便利。
                                            </div>
                                        </div>
                                        <div class="default_right">
                                            <div class="introbd">
                                                <p>
                                                    最新动态</p>
                                                <ul>
                                                    <li>subway后台管理系统平台正在加紧开发</li>
                                                    <li>subway后台管理系统平台正在加紧开发</li>
                                                    <li>subway后台管理系统平台正在加紧开发</li>
                                                    <li>subway后台管理系统平台正在加紧开发</li>
                                                    <li>subway后台管理系统平台正在加紧开发</li>
                                                    <li>subway后台管理系统平台正在加紧开发</li>
                                                </ul>
                                            </div>
                                            <div class="introbd" style="margin-top: 30px;">
                                                <p>
                                                    程序说明</p>
                                                <div class="introbd_div">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;《subway后台管理系统平台》是一套为subway项目量身打造的一款网站系统。本系统经过了周密的项目调查、分析，根据商业模式设计产品功能，系统功能强大、操作简单，并完美体现和满足商业模式对系统的功能要求。<br />
                                                    《subway后台管理系统平台》并采取本系统由前台订餐和后台管理两部分组成。前台订餐模块为顾客提供了点餐，预定服务，外送服务。后台管理模块由食材管理、会员管理、账单管理、标签管理、广告设置等部分组成，为网站提供了简单便捷的管理方式。<br />
                                                    《subway后台管理系统平台》为准备运营subway提供了一个高效、快速、专业的网站建设解决方案。有效的为投资者减少投资、节省开发时间，大大降低项目风险和投资门槛，使其能够把99%的时间和精力放在网站的运营上。
                                                </div>
                                            </div>
                                        </div>
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
