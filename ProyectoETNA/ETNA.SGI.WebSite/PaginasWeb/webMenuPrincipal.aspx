<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2/AppMenu.Master" AutoEventWireup="true" CodeBehind="webMenuPrincipal.aspx.cs" Inherits="ETNA.SGI.WebSite.PaginasWeb.webMenuPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">






    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                     AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="Small">
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <br />
    <asp:ImageButton ID="btnRequerimiento" runat="server" 
        ImageUrl="~/Imagenes/Editar.gif" onclick="ImageButton1_Click" 
        onprerender="ImageButton1_PreRender" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

