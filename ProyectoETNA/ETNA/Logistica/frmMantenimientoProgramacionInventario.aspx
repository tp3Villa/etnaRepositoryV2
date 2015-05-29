<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPrincipal.master" Theme="empresas" AutoEventWireup="true" CodeBehind="frmMantenimientoProgramacionInventario.aspx.cs" Inherits="ETNA.Logistica.frmMantenimientoProgramacionInventario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">

    <fieldset>
        <legend class="camposempresas">
            <img alt="" height="9" src="../Imagenes/flecha_submenu_e.gif" 
                width="10" />Generar Movimiento Almacén</legend>
        <table border="0" cellpadding="1" cellspacing="2" 
            style="MARGIN: auto; WIDTH: 868px">
            <tr>
                <td align="left" class="texto" style="width: 145px" valign="middle">
                    <asp:Button ID="btnGrabar" runat="server" CssClass="boton" 
                            Text="Grabar" Width="130px" TabIndex="7" OnClick="btnGrabar_Click"   />
                </td>
                <td align="right" style="height: 23px" valign="middle">
                    <asp:LinkButton ID="lnkRegresar" runat="server" Font-Bold="True" Font-Names="Arial Black"
                        Font-Size="12px" ForeColor="#426D5F" OnClick="lnkRegresar_Click" ToolTip="Volver a la pantalla anterior">Regresar</asp:LinkButton>
                </td>
            </tr>

            <tr style="height: 30px">
                <td align="left" class="texto" valign="middle" style="width: 153px">
                    <asp:Label ID="lblCaptionIdProgramacion" runat="server" Text=""></asp:Label>
                </td>
                <td align="left" class="texto" valign="middle">                     
                     <asp:Label ID="lblIdProgramacion" runat="server" Text="" Font-Bold="True" Font-Names="Arial" ></asp:Label>
                </td>
            </tr>


            <tr style="height: 30px">
                <td align="left" class="texto" valign="middle" style="width: 153px">
                    <asp:Label ID="Label1" runat="server" Text="Fecha Programada"></asp:Label>                     
                </td>
                <td align="left" class="texto" valign="middle">                     
                     <asp:TextBox ID="txtFechaProgramada" runat="server"></asp:TextBox>                    
                     <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFechaProgramada"
                        Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                </td>
            </tr>
            <tr style="height: 30px">
                <td align="left" class="texto" valign="middle" style="width: 153px">
                    <asp:Label ID="lblCaptionTipoDocAtender" runat="server" Text="Responsable"></asp:Label>
                </td>
                <td align="left" class="texto" valign="middle">
                     <asp:DropDownList ID="ddlResponsable" runat="server">                        
                    </asp:DropDownList>                   
                </td>
            </tr>
          
            
            <tr style="height: 30px">
                <td align="left" class="texto" style="width: 153px" valign="middle">
                    <asp:Label ID="Label7" runat="server" Text="Almacén"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:DropDownList ID="ddlAlmacen" runat="server">                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 30px">
                <td align="left" class="texto" style="width: 153px" valign="middle">
                    <asp:Label ID="Label8" runat="server" Text="Tipo Inventario"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:DropDownList ID="ddlTipoInventario" runat="server">
                        <asp:ListItem Value="36">ANUAL</asp:ListItem>
                        <asp:ListItem Value="37">MENSUAL</asp:ListItem>
                        <asp:ListItem Value="38">CICLICO</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
            <tr style="height: 30px">
                <td align="left" class="texto" style="width: 153px" valign="middle">
                    <asp:Label ID="Label2" runat="server" Text="Estado Inventario"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:Label ID="lblEstadoInventario" runat="server" Width="450px" Text="PENDIENTE"></asp:Label>                    

                </td>
            </tr>
            <tr >
                <td align="left" class="texto" style="width: 153px" valign="middle">
                </td>
                <td align="left" class="texto" valign="middle">
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"
                                        Width="513px" Font-Bold="True" Font-Names="Arial" Font-Size="10px"></asp:Label>
                </td>
            </tr>
            
        </table>
        </fieldset>

</asp:Content>
