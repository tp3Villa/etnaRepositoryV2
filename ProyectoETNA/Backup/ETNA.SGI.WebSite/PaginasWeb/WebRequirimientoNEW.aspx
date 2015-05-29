<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebRequirimientoNEW.aspx.cs" Inherits="ETNA.SGI.WebSite.PaginasWeb.WebRequirimientoNEW" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphSistemaGeneral" runat="server">
<table width="100%">
        <tr>
            <td colspan="3" style="text-align: center; font-weight: normal; font-style: normal; font-family: Verdana; font-variant: normal;">
                <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="Small" ForeColor="DarkSlateBlue"
                    Style="left: 24px; position: relative; top: 0px" 
                    Text="Nuevo Requerimiento"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;&nbsp;
            </td>
           
        </tr>
        <tr>
            <td colspan="3" align="center">
                <table style="width:100%;">
                    <tr>
                        <td style="width: 29px">
                            &nbsp;</td>
                        <td style="width: 128px">
                            <asp:Label ID="Label3" runat="server" Text="Destino" ForeColor="#0000CC"></asp:Label>
                        </td>
                        <td style="width: 251px">
                            <asp:TextBox ID="TextBox2" runat="server" Width="172px"></asp:TextBox>
&nbsp;
                    <asp:ImageButton ID="btnBuscar" runat="server" 
                    ImageUrl="~/Imagenes/Buscar.ico" Height="18px" Width="20px" />
                        </td>
                        <td style="width: 109px" colspan="2">
                            <asp:Label ID="Label4" runat="server" Text="Fecha Entrega" ForeColor="#0000CC"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 29px">
                            &nbsp;</td>
                        <td style="width: 128px">
                            &nbsp;</td>
                        <td style="width: 251px">
                            &nbsp;</td>
                        <td style="width: 109px" colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 29px">
                            &nbsp;</td>
                        <td style="width: 128px">
                            <asp:Label ID="Label5" runat="server" Text="Observacion" ForeColor="#0000CC"></asp:Label>
                        </td>
                        <td colspan="4">
                            <textarea id="TextArea1" name="S1" style="width: 522px; height: 67px"></textarea></td>
                    </tr>
                    <tr>
                        <td style="width: 29px">
                            &nbsp;</td>
                        <td style="width: 128px">
                            &nbsp;</td>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 29px; height: 26px;">
                        </td>
                        <td style="width: 128px; height: 26px;">
                            <asp:Label ID="Label6" runat="server" Text="Producto" ForeColor="#0000CC"></asp:Label>
                        </td>
                        <td colspan="2" style="height: 26px">
                            <asp:Label ID="Label8" runat="server" Text="Producto" ForeColor="#0000CC"></asp:Label>
                        </td>
                        <td colspan="2" style="height: 26px">
                            <asp:Label ID="Label7" runat="server" Text="Cantidad" ForeColor="#0000CC"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    </tr>
                    <tr>
                        <td style="width: 29px">
                            &nbsp;</td>
                        <td style="width: 128px">
                            <asp:TextBox ID="TextBox3" runat="server" Width="83px"></asp:TextBox>
                        </td>
                        <td colspan="2">
                            &nbsp;
                            <asp:TextBox ID="TextBox6" runat="server" Width="218px"></asp:TextBox>
&nbsp;<asp:ImageButton ID="btnBuscar2" runat="server" 
                    ImageUrl="~/Imagenes/Buscar.ico" Height="16px" Width="16px" />
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="TextBox5" runat="server" Width="65px"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:ImageButton ID="btnBuscar1" runat="server" 
                    ImageUrl="~/Imagenes/HojitaNueva.BMP" Height="16px" Width="16px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 29px">
                            &nbsp;</td>
                        <td colspan="5" rowspan="2">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                     AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="Small">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:HyperLinkField
                            DataTextField="Cod_Cab_Req" HeaderText="Cod.Req" >
                        <ItemStyle Width="100px" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="Fec_Reg_Cab_Req" HeaderText="Fecha">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Pais_Cab_Req" HeaderText="Destino">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Pre_Tot_Cab_Req" HeaderText="Total">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 29px">
                            &nbsp;</td>
                    </tr>
                </table>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
