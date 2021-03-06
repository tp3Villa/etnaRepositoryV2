﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="frmConsultaMovimientosAlmacen.aspx.cs" Inherits="ETNA.SGI.Web.Logistica.frmConsultaMovimientosAlmacen" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="frmConsultaMovimientosAlmacen.js"></script>

    <div class="row" style="margin-bottom: 4%">
        <div class="col-md-12">
            <fieldset>
                <legend>Movimientos de Almacén</legend>
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Estado de Atención</label>
                            <asp:DropDownList ID="ddlEstadoAtencion" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Almacén</label>
                            <asp:DropDownList ID="ddlAlmacen" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Tipo de Movimiento</label>
                            <asp:DropDownList ID="ddlTipoMovimiento" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <button class="btn btn-primary" onclick="return Buscar()" style="width: 100%;">BUSCAR</button>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <div id="divgvMovimientos">
                                <asp:GridView ID="gvMovimientos" AutoGenerateColumns="False" runat="server" CssClass="table table-striped table-bordered table-hover">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Documento">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container, "DataItem.Ch_numeroDocPendiente")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Solicitud">
                                            <ItemTemplate>
                                                <%# string.Format("{0:dd/MM/yyyy}", DataBinder.Eval(Container, "DataItem.Dt_fechaDocumento"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tipo de Mov.">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container, "DataItem.Vc_tipoMovimiento")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Almacén">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container, "DataItem.Vc_almacen")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container, "DataItem.Vc_situacionAtencion")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Atender">
                                            <ItemTemplate>
                                                <a class="fa fa-pencil-square-o fa-custom" href="javascript:AtenderDocumento('<%#DataBinder.Eval(Container, "DataItem.In_idDocPendiente")%>', '<%#DataBinder.Eval(Container, "DataItem.Vc_situacionAtencion")%>')"></a>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"/>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <div id="divgvMovimientosEmpty">
                                <table class="table table-striped table-bordered table-hover">
                                    <thead style="background-color: white;">
                                        <tr>
                                            <th>Documento
                                            </th>
                                            <th>Fecha Solicitud
                                            </th>
                                            <th>Tipo de Mov.
                                            </th>
                                            <th>Almacén
                                            </th>
                                            <th>Estado
                                            </th>
                                            <th>Atender
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td colspan="6" style="text-align: center;">
                                                <label id="lblMovimientosVacio">
                                                </label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>

    <div class="modal fade" id="modalMensaje">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">ETNA - MOVIMIENTOS DE ALMACÉN</h4>
                </div>
                <div class="modal-body">
                    <div id="mensaje"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info" data-dismiss="modal">ACEPTAR</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
</asp:Content>
