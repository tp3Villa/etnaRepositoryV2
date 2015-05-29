<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPrincipal.master" AutoEventWireup="true" CodeBehind="frmTomaInventario.aspx.cs" Inherits="ETNA.Logistica.frmTomaInventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <fieldset>
        <legend class="camposempresas">
            Toma de Inventario - Iniciado
        </legend>

        <table border="0" cellpadding="1" cellspacing="2" style="MARGIN: auto; WIDTH: 868px">
            <tr style="height: 23px">
                <td style="width: 200px" valign="middle">
                </td>
                <td style="width: 220px" valign="middle">
                </td>
                 <td>
                </td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" valign="middle" style="width: 200px">
                    <asp:Label ID="lblNomAlmacen" runat="server" Text="Nombre de Almacen"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:TextBox ID="txtNomAlmacen" runat="server"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" valign="middle" style="width: 200px">
                    <asp:Label ID="lblNroInventario" runat="server" Text="Número de Inventario"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:TextBox ID="txtNroInventario" runat="server"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr style="height: 23px">
                <td style="width: 200px"></td>
                <td></td>
                <td></td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" valign="middle" style="width: 200px">
                    <asp:Label ID="lblTipoInventario" runat="server" Text="Tipo de Inventario"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:DropDownList ID="ddlTipoInventario" runat="server">
                        <asp:ListItem Value="1">Tipo 2</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" valign="middle" style="width: 200px">
                    <asp:Label ID="lblFechaProgramada" runat="server" Text="Fecha Programada"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:TextBox ID="txtFechaProgramada" maxlength="10" runat="server" TextMode="Date"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" valign="middle" style="width: 200px">
                    <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha y hora de inicio"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:TextBox ID="txtFechaInicio" maxlength="10" runat="server" TextMode="DateTime"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" valign="middle" style="width: 200px">
                    <asp:Label ID="lblFechaFin" runat="server" Text="Fecha y hora de fin"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:TextBox ID="txtFechaFin" maxlength="10" runat="server" TextMode="DateTime"></asp:TextBox>
                </td>
                <td></td>
            </tr>
        </table>

        <table border="0" cellpadding="1" cellspacing="2" style="MARGIN: auto; WIDTH: 868px">
            <tr style="height: 23px">
                <td style="width: 350px" valign="middle">
                </td>
                <td style="width: 220px" valign="middle">
                </td>
                 <td>
                </td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" valign="middle">
                    <asp:Label ID="lblTotalInventaria" runat="server" Text="Total de productos y ubicaciones a inventariar"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:TextBox ID="txtTotalInventaria" runat="server"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" valign="middle">
                    <asp:Label ID="lblTotalInventariadas" runat="server" Text="Total de productos y ubicaciones inventariadas"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:TextBox ID="txtTotalInventariadas" runat="server"></asp:TextBox>
                </td>
                <td></td>
            </tr>
        </table>
        <table border="0" cellpadding="1" cellspacing="2" style="MARGIN: auto; WIDTH: 868px">
            <tr style="height: 23px">
                <td>
                </td>
                <td style="width: 150px" valign="middle">
                </td>
                 <td style="width: 500px" valign="middle">
                </td>
            </tr>
            <tr style="height: 28px">
                <td>
                </td>
                <td align="left" class="texto" valign="middle">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="100px" Height="28px"/>
                </td>
                <td align="left" class="texto" valign="middle">
                    <asp:Button ID="btnGenerar" runat="server" Text="Generar Cálculo de Diferencia de Inventario" Width="300px" Height="28px"/>
                </td>
            </tr>
            <tr style="height: 23px">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
