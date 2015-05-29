<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPrincipal.master" Theme="empresas" AutoEventWireup="true" CodeBehind="frmConsultaMovimientosAlmacen.aspx.cs" Inherits="ETNA.Logistica.frmConsultaMovimientosAlmacen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">


     <fieldset>
        <legend class="camposempresas">
            <img alt="" height="9" src="../Imagenes/flecha_submenu_e.gif" 
                width="10" />Movimientos Generados (Entrada / Salida) </legend>
        <table border="0" cellpadding="1" cellspacing="2" 
            style="MARGIN: auto; WIDTH: 868px">
            <tr>
                <td align="left" class="texto" style="width: 145px" valign="middle">
                </td>
                <td align="right" style="height: 23px" valign="middle">
                    
                </td>
            </tr>
            
            <tr style="height: 28px">
                <td align="left" class="texto" style="width: 145px" valign="middle">
                    <asp:Label ID="Label9" runat="server" Text="Tipo de Movimiento"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:DropDownList ID="ddlTipoMovimiento" runat="server">
                        <asp:ListItem Value="-1">Todos</asp:ListItem>
                        <asp:ListItem Value="22">MOVIMIENTO DE INGRESO</asp:ListItem>
                        <asp:ListItem Value="23">MOVIMIENTO DE SALIDA</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" style="width: 145px" valign="middle">
                </td>
                <td align="left" class="texto" valign="middle">
                    <asp:Button ID="btnBuscar" runat="server" CssClass="boton" 
                            Text="Buscar" Width="130px" TabIndex="7" OnClick="btnBuscar_Click"  /></td>
            </tr>
            <tr style="height: 28px">
                <td align="left" class="texto" style="width: 145px" valign="middle">
                </td>
                <td align="left" class="texto" valign="middle">
                    <asp:UpdatePanel ID="upMensaje" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Width="698px"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            
                            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
                            
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        </fieldset>
        
       
   
<asp:UpdatePanel ID="upListadoPlanillaConcepto" runat="server">
    <ContentTemplate>
    <fieldset>
        <legend class="camposempresas">
            <img alt="" height="9" src="../Imagenes/flecha_submenu_e.gif" 
                width="10" />Resultados de la Búsqueda</legend>
            <table cellspacing="0" class="pager">
            <tbody><tr><td style="height: 19px"><asp:Label ID="lblResultado" Runat="Server" 
                CssClass="textoresultado"></asp:Label> </td><td class="textoresultado2" style="height: 19px"></td></tr></tbody>
        </TABLE>
    <table border="0" cellpadding="1" cellspacing="2"   style="MARGIN: auto; WIDTH: 900px">    
    <tr>
        <td>
    <asp:GridView ID="gvListado" 
                runat="server" 
                AllowPaging="True"
                CellPadding="0" 
                AutoGenerateColumns="False" 
                CssClass="Grilla" 
                DataKeyNames="correlativo"
                Width="100%" 
        >         
        <PagerSettings FirstPageImageUrl="~/Imagenes/e_btn_first.png"                                 
        LastPageImageUrl="~/Imagenes/e_btn_last.png" Mode="NextPreviousFirstLast" 
        NextPageImageUrl="~/Imagenes/e_btn_next.png" 
        PreviousPageImageUrl="~/Imagenes/e_btn_previous.png" />   
                                    
        <Columns>  
                                                                                                
                                        
            <asp:TemplateField HeaderText="Número Documento ">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container, "DataItem.numeroDocAlmacen")%>                                                
                </ItemTemplate>                                             
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                    <HeaderStyle ForeColor="White" /> 
            </asp:TemplateField>                                                                         
                                       
            <asp:TemplateField HeaderText="Tipo Movimiento">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container, "DataItem.descripcionTipoMovimiento")%>
                </ItemTemplate> 
                    <HeaderStyle ForeColor="White" /> 
            </asp:TemplateField>
                                        
            <asp:TemplateField HeaderText="Fecha">
                <ItemTemplate>                    
                    <%# string.Format("{0:dd/MM/yyyy}", DataBinder.Eval(Container, "DataItem.fechaDocumento"))%>
                </ItemTemplate> 
                    <HeaderStyle ForeColor="White" /> 
            </asp:TemplateField>                                       
                                        
           <asp:TemplateField HeaderText="Almacén">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container, "DataItem.descripcionAlmacen")%>
                </ItemTemplate> 
                    <HeaderStyle ForeColor="White" /> 
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Doc. Pendiente">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container, "DataItem.numeroDocPendiente")%>
                </ItemTemplate> 
                    <HeaderStyle ForeColor="White" /> 
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Descripción Doc. Pendiente">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container, "DataItem.descripcionDocumentoPendiente")%>
                </ItemTemplate> 
                    <HeaderStyle ForeColor="White" /> 
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <a id="lnkProgramar"  href="frmGeneracionMovimiento.aspx?correlativo=<%#DataBinder.Eval(Container,"DataItem.correlativo")%> &IdAccion=2" >
                          Consultar                                  
                    </a>                    
                </ItemTemplate> 
                    <HeaderStyle ForeColor="White" /> 
            </asp:TemplateField>

                                                                                                                     
        </Columns>                                        
                                                                                                               
        <EmptyDataTemplate>"No hay registros"</EmptyDataTemplate>                                                                                                                    
        <RowStyle CssClass="celdaimpar" />
        <PagerStyle CssClass="celdapagina" HorizontalAlign="Center" />
        <HeaderStyle CssClass="celdatitulo" />
        <AlternatingRowStyle CssClass="celdapar" />
                                    
    </asp:GridView>
                               
    </td>
    </tr>
    </table>
    </fieldset>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
