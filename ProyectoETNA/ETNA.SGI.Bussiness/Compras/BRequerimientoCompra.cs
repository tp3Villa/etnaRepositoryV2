using ETNA.SGI.Data.Compras;
using ETNA.SGI.Entity.Compras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace ETNA.SGI.Bussiness.Compras
{
    public class BRequerimientoCompra : BBase
    {

        private static BRequerimientoCompra bRequerimientoCompra;

        public static BRequerimientoCompra getInstance()
        {
            if (bRequerimientoCompra == null)
            {
                bRequerimientoCompra = new BRequerimientoCompra();
            }
            return bRequerimientoCompra;
        }

        private RequerimientoCompraDAO dRequerimientoCompra;

        public BRequerimientoCompra()
        {
            this.dRequerimientoCompra = ObjFactoryDAO.getRequerimientoCompraDAO();
        } 

        public DataTable ObtenerListadoRequerimientoCompraCotizacion(ERequerimientoCompra eRequerimientoCompra)
        {
            return dRequerimientoCompra.DGetAllRequerimientoCompraCotizacion(eRequerimientoCompra);
        }

        //Listado Requerimientos frmCotizacion
        public DataTable ObtenerListadoRequerimientoCompraCotizacion_Final(ERequerimientoCompra eRequerimientoCompra)
        {
            return dRequerimientoCompra.DGetAllRequerimientoCompraCotizacion_Final(eRequerimientoCompra);
        }

        public DataTable ObtenerListadoRequerimientoCompraOrdenCompra(ERequerimientoCompra eRequerimientoCompra)
        {
            return dRequerimientoCompra.DGetAllRequerimientoCompraOrdenCompra(eRequerimientoCompra);
        }

        public DataTable ObtenerRequerimientoDetalleCompraCotizacion(string CodReq)
        {
            return dRequerimientoCompra.DGetAllRequerimientoCompraCotizacionDetalle(CodReq);
        }

        public DataTable ObtenerListadoDetallePorCodigoRequerimientoCompra(int codRequerimientoCompra)
        {
            return dRequerimientoCompra.DGetAllDetalleByCodRequerimientoCompra(codRequerimientoCompra);
        }
        
        /* METODOS RICHARD */
        public DataTable ListarPorCodigoPersonal(string usuarioRegistro)
        {
            return dRequerimientoCompra.ListarPorCodigoPersonal(usuarioRegistro);
        }

        public DataTable ListarPorCodigoPersonalYEstado(string usuarioRegistro, int codEstado)
        {
            return dRequerimientoCompra.ListarPorCodigoPersonalYEstado(usuarioRegistro, codEstado);
        }

        public DataTable ListaDetallePorCodigoRequerimiento(int codRequerimiento)
        {
            return dRequerimientoCompra.ListaDetallePorCodigoRequerimiento(codRequerimiento);
        }

        public DataTable ListarPorCodigoReqYEstado(int codRequerimiento, int codEstado)
        {
            return dRequerimientoCompra.ListarPorCodigoReqYEstado(codRequerimiento, codEstado);
        }

        // Registrar Requerimiento
        public int Registrar(ERequerimientoCompra eRequerimientoCompra, List<ERequerimientoCompraDetalle> listaERequerimientoCompraDetalle)
        {
            return dRequerimientoCompra.Registrar(eRequerimientoCompra, listaERequerimientoCompraDetalle);
        }
        
        // Actualizar Requerimiento
        public int Actualizar(ERequerimientoCompra eRequerimientoCompra, List<ERequerimientoCompraDetalle> listaERequerimientoCompraDetalle)
        {
            return dRequerimientoCompra.Actualizar(eRequerimientoCompra, listaERequerimientoCompraDetalle);
        }


        //Actualiza estado Requerimiento
        public int ActualizarEstado(int CodCotizacion, int CodEstado)
        {
            return dRequerimientoCompra.ActualizarEstado(CodCotizacion, CodEstado);
        }
    }
}
