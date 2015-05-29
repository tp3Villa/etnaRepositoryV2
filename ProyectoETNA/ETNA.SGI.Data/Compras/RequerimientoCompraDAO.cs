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

    }
}
