<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPrincipal.master" Theme="empresas"  AutoEventWireup="true" CodeBehind="frmActualizarInventario.aspx.cs" Inherits="ETNA.Logistica.frmActualizarInventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">

    <fieldset>
        <legend class="camposempresas">
            Actualización de Inventario
        </legend>
        <table border="0" cellpadding="1" cellspacing="2" 
            style="MARGIN: auto; WIDTH: 868px">
            <tr style="height: 23px">
                <td style="width: 120px" valign="middle">
                </td>
                <td style="width: 217px" valign="middle">
                </td>
                 <td style="width: 120px" valign="middle">
                </td>
                 <td style="width: 217px" valign="middle">
                </td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" valign="middle" style="width: 120px">
                    <asp:Label ID="lblFec" runat="server" Text="Fecha"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:TextBox ID="txtFecha" maxlength="10" runat="server" TextMode="Date"></asp:TextBox>
                </td>
                <td align="left" class="texto" valign="middle" style="width: 120px">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
                </td>
                <td align="left" class="texto" valign="middle">
                    <asp:DropDownList ID="ddlEstado" runat="server">
                        <asp:ListItem Value="1">Contabilizado</asp:ListItem>
                        <asp:ListItem Value="2" Selected="True">Pendiente</asp:ListItem>
                        <asp:ListItem Value="3">Finalizado</asp:ListItem>
                        <asp:ListItem Value="4">Cancelado</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" valign="middle" style="width: 120px">
                    <asp:Label ID="lblSupervisor" runat="server" Text="Supervisor"></asp:Label>
                </td>
                <td align="left" class="texto" valign="middle">
                    <asp:DropDownList ID="ddlSupervisor" runat="server">
                        <asp:ListItem Value="1">José Ríos</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 120px">
                </td>
                <td>
                </td>
            </tr>
            <tr style="height: 23px">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="1" cellspacing="2"   style="MARGIN: auto; WIDTH: 868px"> 
            <tr>
        <td align="center">
            <asp:GridView ID="gvInventario" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="864px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="#Inventario"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Selección"></asp:TemplateField>
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
    </table>
        <table border="0" cellpadding="1" cellspacing="2" style="MARGIN: auto; WIDTH: 868px">
            <tr style="height: 23px">
                <td valign="middle">
                </td>
                <td style="width: 300px" valign="middle">
                </td>
                 <td style="width: 300px" valign="middle">
                </td>
            </tr>
            <tr style="height: 28px">
                <td>
                </td>
                <td align="right" class="texto" valign="middle">
                    <asp:Button ID="btnIniciar" runat="server" Text="Iniciar toma de inventario" Width="230px" Height="28px"/>
                </td>
                <td align="right" class="texto" valign="middle">
                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar al menú del sistema" Width="230px" Height="28px"/>
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
