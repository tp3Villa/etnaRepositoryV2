<%@ Page Language="C#" 
         MasterPageFile="~/MasterPage/MasterPrincipal.master" 
         Theme="empresas" 
         AutoEventWireup="true" 
         CodeBehind="Error.aspx.cs" 
         Inherits="ETNA.Error" 
         Title="ETNA - Error" %>
         
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    
    <table>
        <tr>
            <td valign="middle" align="center">
                <asp:Image ID="imgInfo" runat="server" ImageUrl="../imagenes/info.gif"></asp:Image>
            </td>
        </tr>
        <tr>
            <td class="Error">
                Ha ocurrido una operación no válida.</td>
        </tr>
        <tr title="Detalle" onclick="ExpandirColapsar(this.title)">
            <td class="SubTitulo">
                <img id="imgDetalle" alt="" src="../imagenes/colapsar.gif" />&nbsp;&nbsp;Detalle</td>
        </tr>
        <tr id="Detalle">
            <td>
                <asp:Label ID="lblError" runat="server" Width="100%" CssClass="Error"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="hlkRegresar" runat="server" CssClass="Enlace" NavigateUrl="javascript:history.back();">Regresar</asp:HyperLink></td>
        </tr>
    </table>    
    
</asp:Content>
