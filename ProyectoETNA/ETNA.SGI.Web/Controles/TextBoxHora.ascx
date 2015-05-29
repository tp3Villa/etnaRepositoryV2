<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextBoxHora.ascx.cs" Inherits="SGCA.Controles.TextBoxHora" %>

    <link href="../Estilos/General.css" type="text/css" rel="stylesheet" />
    <script src="../JavaScript/popCalendar.js" type="text/javascript"></script>       

<table cellspacing="3" cellpadding="0" border="0">
    <tr>
        <td>
            <input class="CajaTextoFecha" id="txtHora" type="text" runat="server" size="8" />
        </td>        
        <td>
            <asp:RequiredFieldValidator ID="rfvHora" runat="server" ControlToValidate="txtHora"
                ErrorMessage="(*)" CssClass="Validacion" SetFocusOnError="true"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revHora" runat="server" ErrorMessage="(hh:mm)" 
                ControlToValidate="txtHora"
                ValidationExpression="^((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [ap]m))$|^([01]\d|2[0-3])"
                CssClass="Validacion" SetFocusOnError="true"></asp:RegularExpressionValidator>
        </td>
        <%--    ValidationExpression="^((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))$|^([01]\d|2[0-3])"    --%>
    </tr>
</table>


