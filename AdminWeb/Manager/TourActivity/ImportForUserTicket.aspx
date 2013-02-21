<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="ImportForUserTicket.aspx.cs" Inherits="Manager_TourActivity_ImportForUserTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div class="notice">
        <div class="notice">
            <span>是否使用存储过程:</span><span class="alert"><%=SiteConfig.ImportUsingProc %></span>
        </div>
        <div class="notice">
            <span>使用的远程数据库:</span><span class="alert"><%=SiteConfig.SyncServerConnection %></span>
        </div>
        <div class="notice">
            <span>使用的同步表名:</span><span class="alert"><%=SiteConfig.SyncTableName %></span>
        </div>
    </div>
    <div>
    excel文件:    <asp:FileUpload runat="server" ID="fuExcel"   />
        <asp:Label runat="server" ID="lblSelectedFileName"></asp:Label>
        <asp:Button Text="查看" ID="btnViewExcel"
            runat="server" OnClick="btnViewExcel_Click" />
       活动代码:<asp:TextBox runat="server" ID="tbxActivityCode"></asp:TextBox>  
       合作商代码:<asp:TextBox runat="server" ID="tbxPartnerCode"></asp:TextBox>  
       
          <asp:Button Text="导入" ID="btnImport"
            runat="server" OnClick="btnImport_Click" />
        <asp:Repeater runat="server" ID="rptExcel">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            序号
                        </td>
                        <td>
                            身份证号码
                        </td>
                        <td>
                            电话号码
                        </td>
                        <td>
                            姓名
                        </td>
                        <td>
                            门票代码
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Container.ItemIndex %>
                    </td>
                    <td>
                        <%#Eval("postcode") %>
                    </td>
                    <td>
                        <%#Eval("mobile") %>
                    </td>
                    <td>
                        <%#Eval("truename")%>
                    </td>
                    <td>
                       
                            <%#Eval("gid") %>
                       
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
