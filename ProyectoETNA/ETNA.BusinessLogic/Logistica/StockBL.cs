using ETNA.BusinessEntity.Logistica;
using ETNA.DataAccess.Logistica;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessLogic.Logistica
{
    public class StockBL
    {
        public bool Actualizar(int paramIdAlmacen, List<DetalleDocumentoAlmacenBE> paramDetalleDocumentoAlmacenBE, int paramTipoMovimiento)
        {
            bool OperacionExitosa = true;
            try
            {
                StockDA objStockDA = new StockDA();
                int cantidadIngreso = 0;
                int cantidadSalida = 0;
                foreach (var item in paramDetalleDocumentoAlmacenBE)
                {
                    if (paramTipoMovimiento == 22) //Ingreso
                    {
                        cantidadIngreso = item.cantidad;
                        cantidadSalida = 0;
                    }
                    else
                    {
                        cantidadIngreso = 0;
                        cantidadSalida = item.cantidad;
                    }
                    OperacionExitosa = objStockDA.Actualizar(paramIdAlmacen, item.idProducto, cantidadIngreso, cantidadSalida);
                }

            }
            catch (Exception ex)
            {
                OperacionExitosa = false;
                throw ex;
            }
            return OperacionExitosa;
        }

        public StockBE Consultar(int paramIdAlmacen, int paramIdProducto)
        {
            try
            {
                StockDA objStockDA = new StockDA();
                return objStockDA.Consultar(paramIdAlmacen, paramIdProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
