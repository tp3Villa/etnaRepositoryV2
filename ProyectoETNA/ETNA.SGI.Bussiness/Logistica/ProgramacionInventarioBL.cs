using ETNA.BusinessEntity.Logistica;
using ETNA.DataAccess.Logistica;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessLogic.Logistica
{
    public class ProgramacionInventarioBL
    {
        public List<ProgramacionInventarioBE> Listar(int paramIdProgInventario = 0, int paramTipoInventario=-1)
        {
            try
            {
                ProgramacionInventarioDA objProgramacionInventarioDA = new ProgramacionInventarioDA();
                return objProgramacionInventarioDA.Listar(paramIdProgInventario, paramTipoInventario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ProgramacionInventarioBE objProgramacionInventarioBE)
        {
            try
            {
                ProgramacionInventarioDA objProgramacionInventarioDA = new ProgramacionInventarioDA();
                return objProgramacionInventarioDA.Insertar(objProgramacionInventarioBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(ProgramacionInventarioBE objProgramacionInventarioBE)
        {
            try
            {
                ProgramacionInventarioDA objProgramacionInventarioDA = new ProgramacionInventarioDA();
                return objProgramacionInventarioDA.Actualizar(objProgramacionInventarioBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int paramIdProgInventario)
        {
            try
            {
                ProgramacionInventarioDA objProgramacionInventarioDA = new ProgramacionInventarioDA();
                bool ExisteReferencia = objProgramacionInventarioDA.Existe_Inventario(paramIdProgInventario);
                if (ExisteReferencia == true)
                    return false;                    
                else
                    return objProgramacionInventarioDA.Eliminar(paramIdProgInventario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
