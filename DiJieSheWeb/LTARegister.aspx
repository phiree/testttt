<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LTARegister.aspx.cs" Inherits="LTARegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="x-ua-compatible" content="ie=8" />
    <script src="Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <link href="/theme/bp/screen.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="/theme/bp/print.css" rel="stylesheet" type="text/css" media="print" />
    <link href="/theme/default/css/public.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="LTA_main">
            <div class="LTA_mainTop">
                <h3>
                    浙江旅游&nbsp;&nbsp;单位管理平台
                </h3>
                <div class="fwtel">
                    平台服务电话
                    <p>0571-87801108</p>
                </div>
            </div>
            <div class="LTA_mainInfo">
                <h2 >新地接社申请<span>(带*为必填)</span></h2>
                <table border="0" cellpadding="5px" cellspacing="5px">
                    <tr>
                        <td style="width:40px;">
                            单位名称:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDJSName" runat="server" Width="95%" ></asp:TextBox>*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="必填" ControlToValidate="txtDJSName" Display="Dynamic" 
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            所属区域:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlProvince_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlCity_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlCountry" runat="server">
                            </asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            单位地址:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDJSAddress" runat="server" Width="95%"></asp:TextBox>*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ErrorMessage="必填" ControlToValidate="txtDJSAddress" Display="Dynamic" 
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            联系人姓名:
                        </td>
                        <td>
                            <asp:TextBox ID="txtLinkName" runat="server" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            联系电话:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTel" runat="server" Width="95%"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ErrorMessage="联系电话格式不对" ControlToValidate="txtTel" Display="Dynamic" 
                                ForeColor="Red" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            电子邮箱:
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Width="95%"></asp:TextBox>*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="必填" ControlToValidate="txtEmail" Display="Dynamic" 
                                ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="电子邮箱格式不对" ControlToValidate="txtEmail" Display="Dynamic" 
                                ForeColor="Red" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            营业执照上传:
                        </td>
                        <td>
                            <asp:FileUpload ID="fuLicence" runat="server" />*
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="XY">
                                <p>浙江旅游单位管理平台&nbsp;协议</p>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center">
                            <asp:CheckBox ID="ckSelect" runat="server" Checked="true" />同意单位管理平台协议
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center">
                            <asp:Button ID="BtnRegister" runat="server" Text="申请加入" CssClass="btn2" 
                                style="margin-top:20px" onclick="BtnRegister_Click" />
                        </td>
                    </tr>
                </table>
            </div>
    </div>
    </form>
</body>
</html>
