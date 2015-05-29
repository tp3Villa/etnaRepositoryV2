<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPrincipal.master" AutoEventWireup="true" CodeBehind="frmSolicitudReposicionStock.aspx.cs" Inherits="ETNA.Logistica.frmSolicitudReposicionStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <style type="text/css">
        .Initial
        {
            display: block;
            padding: 4px 18px 4px 18px;
            float: left;
            background: url("../Imagenes/SelectedButton.png") no-repeat right top;
            color: black;
            font-weight: bold;
        }
        .Initial:hover
        {
            color: white;
            background: url("../Imagenes/InitialImage.png") no-repeat right top;
        }
        .Clicked
        {
            float: left;
            display: block;
            background: url("../Imagenes/InitialImage.png") no-repeat right top;
            padding: 4px 18px 4px 18px;
            color: black;
            font-weight: bold;
            color: white;
        }
    </style>
    <fieldset>
        <legend class="camposempresas">
            Solicitar reposición de stock
        </legend>

        <table border="0" cellpadding="1" cellspacing="2" style="MARGIN: auto; WIDTH: 868px">
            <tr style="height: 23px">
                <td style="width: 200px" valign="middle">
                </td>
                <td style="width: 200px" valign="middle">
                </td>
                <td style="width: 220px" valign="middle">
                </td>
                 <td>
                </td>
            </tr>
            <tr style="height: 28px">
                <td></td>
                <td align="left" class="texto" valign="middle">
                    <asp:Label ID="lblCodProducto" runat="server" Text="Código de producto"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:TextBox ID="txtCodProducto" runat="server"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnBuscarProducto" runat="server" Text="Buscar producto" Width="150px" Height="28px"/>
                </td>
            </tr>
            <tr style="height: 28px">
                <td></td>
                <td align="left" class="texto" valign="middle">
                    <asp:Label ID="lblNomProducto" runat="server" Text="Nombre de producto"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:TextBox ID="txtNomProducto" runat="server"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr style="height: 23px">
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <table width="80%" align="center">
        <tr>
            <td>
                <asp:Button Text="Productos con bajo stock" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server"
                    OnClick="Tab1_Click" />
                <asp:Button Text="Resultados de búsqueda" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server"
                    OnClick="Tab2_Click" />
                <asp:MultiView ID="MainView" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                            <tr>
                                <td>
                                    <asp:GridView ID="gvBajoStock" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="100%">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Código"></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre"></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cantidad"></asp:TemplateField>
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
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                            <tr>
                                <td>
                                    <asp:GridView ID="gvResultados" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="100%">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Código"></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre"></asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cantidad"></asp:TemplateField>
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
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr style="height: 23px">
            <td>
            </td>
        </tr>
        <tr style="height: 28px">
            <td align="right" class="texto" valign="middle">
                <asp:Button ID="btnRealizarPedido" runat="server" Text="Realizar Pedido" Width="230px" Height="28px"/>
            </td>
        </tr>
        <tr style="height: 23px">
            <td>
            </td>
        </tr>
    </table>
    </fieldset>
</asp:Content>
