using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace ETNA.SGI.Data.Compras
{
    public interface RequerimientoCompraDAO
    {
        DataTable DGetAllRequerimientoCompraCotizacion(ERequerimientoCompra eRequerimientoCompra);

        DataTable DGetAllRequerimientoCompraCotizacion_Final(ERequerimientoCompra eRequerimientoCompra);

        DataTable DGetAllRequerimientoCompraCotizacionDetalle(string codReq);

        DataTable DGetAllRequerimientoCompraOrdenCompra(ERequerimientoCompra eRequerimientoCompra);

        DataTable DGetAllDetalleByCodRequerimientoCompra(int codRequerimientoCompra);

        /* METODOS RICHARD*/
        DataTable ListarPorCodigoPersonal(string usuarioRegistro);

        DataTable ListarPorCodigoPersonalYEstado(string usuarioRegistro, int codEstado);

        DataTable ListarPorCodigoReqYEstado(int codRequerimiento, int codEstado);


        /* FALTANNNNNNN ACTUALIZAR */
        void EliminarDetalle(int codRequerimiento);
        /* FALTANNNNNNN ACTUALIZAR */

        int Registrar(ERequerimientoCompra eRequerimientoCompra, List<ERequerimientoCompraDetalle> listaERequerimientoCompraDetalle);

        //Actualizar datos Cotizacion
        int Actualizar(ERequerimientoCompra eRequerimientoCompra, List<ERequerimientoCompraDetalle> listaERequerimientoCompraDetalle);


        //Actualiza estado Requerimiento
        int ActualizarEstado(int ActualizarEstado, int CodEstado);

        DataTable ListaDetallePorCodigoRequerimiento(int codRequerimiento);
    }
}
