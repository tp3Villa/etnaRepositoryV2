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
        List<ERequerimientoCompra> ListarPorCodigoPersonal(int codPersonal);

        List<ERequerimientoCompra> ListarPorCodigoPersonalYEstado(int codPersonal, int codEstado);

        List<ERequerimientoCompraDetalle> ListaDetallePorCodigoRequerimiento(int codRequerimiento);

        List<ECotizacionDetalle> ListaDetallePorCodigoRequerimientoCotizacion(int codRequerimiento);

        int RegistrarCabecera(ERequerimientoCompra reqCab);

        void RegistrarDetalle(ERequerimientoCompraDetalle reqDet);

        void ActualizarCabecera(ERequerimientoCompra reqCab);

        void EliminarDetalle(int codRequerimiento);

        void ActualizarEstado(int codRequerimiento, int codEstado);

    }
}
