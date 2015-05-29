<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPrincipal.master" AutoEventWireup="true" CodeBehind="frmActUbiProducto.aspx.cs" Inherits="ETNA.Logistica.frmActUbiProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <fieldset>
        <legend class="camposempresas">
            Actualizar Ubicación del Producto
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
                <td align="left" class="texto" valign="middle">
                    <asp:Label ID="lblCodProducto" runat="server" Text="Código del Producto"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:TextBox ID="txtCodProducto" runat="server"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnLiberarUbicaciones" runat="server" Text="Liberar ubicaciones" Width="150px" Height="28px"/>
                </td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" valign="middle">
                    <asp:Label ID="lblAlmacen" runat="server" Text="Almacén"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:DropDownList ID="ddlAlmacen" runat="server">
                        <asp:ListItem Value="1">Almacén 1</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" valign="middle">
                    <asp:Label ID="lblTipoAlmacen" runat="server" Text="Tipo de almacén"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:DropDownList ID="ddlTipoAlmacen" runat="server">
                        <asp:ListItem Value="1">Tipo 1</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr style="height: 23px">
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <table border="0" cellpadding="1" cellspacing="2"   style="MARGIN: auto; WIDTH: 868px"> 
            <tr>
                <td align="center">
                    <asp:GridView ID="gvProducto" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="864px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Seleccione"></asp:TemplateField>
                            <asp:TemplateField HeaderText="Fila"></asp:TemplateField>
                            <asp:TemplateField HeaderText="Columna"></asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </td>
            </tr>
            <tr style="height: 23px">
                <td></td>
            </tr>
            <tr style="height: 28px">
                <td align="right">
                    <asp:Button ID="btnActUbicacion" runat="server" Text="Actualizar ubicación" Width="200px" Height="28px"/>
                </td>
            </tr>
            <tr style="height: 23px">
                <td></td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
