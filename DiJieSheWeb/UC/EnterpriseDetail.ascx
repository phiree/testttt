 <%@ Control Language="C#" AutoEventWireup="true" CodeFile="EnterpriseDetail.ascx.cs"
    Inherits="UC_EnterpriseDetail" %>
<table>
    <tr>
        <td>
            名称:
        </td>
        <td>
            <%=Ent.Name %>
        </td>
    </tr>
    <tr>
        <td>
            已认证:
        </td>
        <td>
            <%=Ent.IsVeryfied?"是":"否" %>
        </td>
    </tr>
    <tr>
        <td>
            电话:
        </td>
        <td>
            <%=Ent.Phone %>
        </td>
    </tr>
    <tr>
        <td>
            类型:
        </td>
        <td>
            <%=Ent.Type %>
        </td>
    </tr>
    <tr>
        <td>
            类型:
        </td>
        <td>
            <%=Ent.Address %>
        </td>
    </tr>
    <tr>
        <td>
            区域:
        </td>
        <td>
            <%=Ent.Area.Name %>
        </td>
    </tr>
    <tr>
        <td>
            负责人姓名:
        </td>
        <td>
            <%=Ent.ChargePersonName %>
        </td>
    </tr>
    <tr>
        <td>
            负责人电话:
        </td>
        <td>
            <%=Ent.ChargePersonPhone %>
        </td>
    </tr>
</table>
