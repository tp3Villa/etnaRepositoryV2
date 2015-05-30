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
        public List<ERequerimientoCompra> ListarPorCodigoPersonal(int codPersonal)
        {
            return null;// RequerimientoDAO.ListarPorCodigoPersonal(codPersonal);
        }

        public List<ERequerimientoCompra> ListarPorCodigoPersonalYEstado(int codPersonal, int codEstado)
        {
            return null;//RequerimientoDAO.ListarPorCodigoPersonalYEstado(codPersonal, codEstado);
        }

        public List<ERequerimientoCompraDetalle> ListaDetallePorCodigoRequerimiento(int codRequerimiento)
        {
            return null;//RequerimientoDAO.ListaDetallePorCodigoRequerimiento(codRequerimiento);
        }

        public List<ECotizacion> ListaDetallePorCodigoRequerimientoCotizacion(int codRequerimiento)
        {
            return null;//RequerimientoDAO.ListaDetallePorCodigoRequerimientoCotizacion(codRequerimiento);
        }

        public void Registrar(ERequerimientoCompra reqCab, List<ERequerimientoCompraDetalle> reqDets)
        {
            //int codigo = RequerimientoDAO.RegistrarCabecera(reqCab);
            //foreach (ERequerimientoCompraDetalle reqDet in reqDets)
            //{
            //    reqDet.CodRequerimiento = codigo;
            //    RequerimientoDAO.RegistrarDetalle(reqDet);
            //}
        }

        public void Actualizar(ERequerimientoCompra reqCab, List<ERequerimientoCompraDetalle> reqDets)
        {
            //RequerimientoDAO.ActualizarCabecera(reqCab);
            //RequerimientoDAO.EliminarDetalle(reqCab.Codigo);
            //foreach (ERequerimientoCompraDetalle reqDet in reqDets)
            //{
            //    RequerimientoDAO.RegistrarDetalle(reqDet);
            //}
        }

        public void ActualizarEstado(int codRequerimiento, int codEstado)
        {
            //RequerimientoDAO.ActualizarEstado(codRequerimiento, codEstado);
        }
    }
}
