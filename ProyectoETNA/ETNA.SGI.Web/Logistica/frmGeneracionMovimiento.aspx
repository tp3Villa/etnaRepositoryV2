<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPrincipal.master" Theme="empresas"  AutoEventWireup="true" CodeBehind="frmGeneracionMovimiento.aspx.cs" Inherits="ETNA.Logistica.frmGeneracionMovimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <script language="javascript" type="text/javascript">
        //Permite solo el ingreso de numeros y punto (.)
        function SoloNumeros(e) {            
            var key = window.Event ? e.which : e.keyCode
            return ((key >= 48 && key <= 57) || (key == 8))
        }

    </script>
    <fieldset>
        <legend class="camposempresas">
            <img alt="" height="9" src="../Imagenes/flecha_submenu_e.gif" 
                width="10" />Generar Movimiento Almacén</legend>
        <table border="0" cellpadding="1" cellspacing="2" 
            style="MARGIN: auto; WIDTH: 868px">
            <tr>
                <td align="left" class="texto" style="width: 145px" valign="middle">
                    <asp:Button ID="btnGenerar" runat="server" CssClass="boton" 
                            Text="Generar Movimiento" Width="130px" TabIndex="7" OnClick="btnGenerar_Click"   />
                </td>
                <td align="right" style="height: 23px" valign="middle">
                    <asp:LinkButton ID="lnkRegresar" runat="server" Font-Bold="True" Font-Names="Arial Black"
                        Font-Size="12px" ForeColor="#426D5F" OnClick="lnkRegresar_Click" ToolTip="Volver a la pantalla anterior">Regresar</asp:LinkButton>
                </td>
            </tr>

            <tr style="height: 30px">
                <td align="left" class="texto" valign="middle" style="width: 153px">
                    <asp:Label ID="lblCaptionNumeroMovimiento" runat="server" Text=""></asp:Label>
                </td>
                <td align="left" class="texto" valign="middle">                     
                     <asp:Label ID="lblNumeroMovimiento" runat="server" Text="" Font-Bold="True" Font-Names="Arial" ></asp:Label>
                </td>
            </tr>


            <tr style="height: 30px">
                <td align="left" class="texto" valign="middle" style="width: 153px">
                    <asp:Label ID="Label1" runat="server" Text="Tipo de Movimiento"></asp:Label>
                </td>
                <td align="left" class="texto" valign="middle">                     
                     <asp:RadioButtonList ID="rbTipoMovimiento" runat="server" RepeatDirection="Horizontal">
                         <asp:ListItem Value="22">Ingreso</asp:ListItem>
                         <asp:ListItem Value="23">Salida</asp:ListItem>
                     </asp:RadioButtonList>                    
                </td>
            </tr>
            <tr style="height: 30px">
                <td align="left" class="texto" valign="middle" style="width: 153px">
                    <asp:Label ID="lblCaptionTipoDocAtender" runat="server" Text="Tipo de Documento a Atender"></asp:Label>
                </td>
                <td align="left" class="texto" valign="middle">
                                        &nbsp;<asp:Label ID="lblTipoDocumento" runat="server" Width="455px"></asp:Label>                    
                </td>
            </tr>
            <tr style="height: 30px">
                <td align="left" class="texto" style="width: 153px" valign="middle">
                    <asp:Label ID="lblCaptionNumeroDocAtender" runat="server" Text="Número Documento a Atender"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:Label ID="lblNumeroDocumento" runat="server" Width="447px"></asp:Label>
                    <asp:HiddenField ID="hdnidDocPendiente" runat="server"  />
                </td>
            </tr>
            <tr style="height: 30px">
                <td align="left" class="texto" style="width: 153px" valign="middle">
                    <asp:Label ID="Label6" runat="server" Text="Fecha Movimiento"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                                        <asp:Label ID="lblFechaMovimiento" runat="server" Width="451px"></asp:Label></td>
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
                    <asp:Label ID="Label8" runat="server" Text="Persona solicitante"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:Label ID="lblOrigen" runat="server" Width="450px"></asp:Label>                    

                </td>
            </tr>
            <tr style="height: 30px">
                <td align="left" class="texto" style="width: 153px" valign="middle">
                    <asp:Label ID="Label2" runat="server" Text="Area solicitante"></asp:Label></td>
                <td align="left" class="texto" valign="middle">
                    <asp:Label ID="lblCentroCosto" runat="server" Width="450px"></asp:Label>                    

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
            <tr style="height: 28px">
                <td align="left" class="texto" colspan="2" valign="middle">
                                <asp:GridView ID="gvListado" 
                                          runat="server" 
                                          AllowPaging="True"
                                          CellPadding="0" 
                                          AutoGenerateColumns="False"
                                          DataKeyNames="idProducto" 
                                          CssClass="Grilla"
                                          Width="97%"  >                                                                                                                   
                                     <PagerSettings FirstPageImageUrl="~/Imagenes/e_btn_first.png"                                 
                                    LastPageImageUrl="~/Imagenes/e_btn_last.png" Mode="NextPreviousFirstLast" 
                                    NextPageImageUrl="~/Imagenes/e_btn_next.png" 
                                    PreviousPageImageUrl="~/Imagenes/e_btn_previous.png" />            
                                    <Columns>                                                            
                                       
                                          <asp:TemplateField HeaderText="Item">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container, "DataItem.idDetalleDocPendiente")%>                                                
                                            </ItemTemplate>                                             
                                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                <HeaderStyle ForeColor="White" /> 
                                        </asp:TemplateField>                                                                         
                                       
                                         <asp:BoundField HeaderText="Código de Producto" DataField="codigoProducto" Visible="true">                                            
                                            <ItemStyle HorizontalAlign="Left" Wrap="False" Width="70px"/>
                                            <HeaderStyle ForeColor="White" /> 
                                        </asp:BoundField>

                                         <asp:TemplateField HeaderText="Descripción Producto">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container, "DataItem.descripcionProducto")%>
                                            </ItemTemplate> 
                                                <HeaderStyle ForeColor="White" /> 
                                        </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Unidad Medida">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container, "DataItem.descripcionUnidadMedida")%>
                                            </ItemTemplate> 
                                                <HeaderStyle ForeColor="White" /> 
                                        </asp:TemplateField>

                                        <asp:BoundField HeaderText="Cantidad Solicitada" DataField="cantidadPedida" Visible="true">                                            
                                            <ItemStyle HorizontalAlign="Left" Wrap="False" Width="70px"/>
                                            <HeaderStyle ForeColor="White" /> 
                                        </asp:BoundField>

                                        <asp:BoundField HeaderText="Cantidad Pendiente Atención" DataField="cantidadPendienteAtencion" Visible="true">                                            
                                            <ItemStyle HorizontalAlign="Left" Wrap="False" Width="70px"/>
                                            <HeaderStyle ForeColor="White" /> 
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Cantidad Atendida">
                                           
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCantidadAtendida" Width="80px"  runat="server" Text='<%#Eval("cantidadAtendida") %>' onkeypress="return SoloNumeros(event);"></asp:TextBox>                                                
                                            </ItemTemplate>
                                            <HeaderStyle ForeColor="White" /> 
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Lote Producto">
                                           
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlLote" runat="server"> 
                                                    <asp:ListItem Value="1">Lote 1</asp:ListItem>
                                                    <asp:ListItem Value="2">Lote 2</asp:ListItem>
                                                </asp:DropDownList>                                                
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

</asp:Content>
