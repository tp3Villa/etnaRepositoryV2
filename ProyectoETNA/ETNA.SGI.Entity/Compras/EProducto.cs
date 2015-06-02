using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Compras
{
    public class EProducto
    {
        private int idProducto;

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
        private int codCategoria;

        public int CodCategoria
        {
            get { return codCategoria; }
            set { codCategoria = value; }
        }
        private string desCategoria;

        public string DesCategoria
        {
            get { return desCategoria; }
            set { desCategoria = value; }
        }
               
        private int codMarca;

        public int CodMarca
        {
            get { return codMarca; }
            set { codMarca = value; }
        }
        private string desMarca;

        public string DesMarca
        {
            get { return desMarca; }
            set { desMarca = value; }
        }

        
        private string descripcionProducto;

        public string DescripcionProducto
        {
            get { return descripcionProducto; }
            set { descripcionProducto = value; }
        }
        private string tipoUnidadMedida;

        public string TipoUnidadMedida
        {
            get { return tipoUnidadMedida; }
            set { tipoUnidadMedida = value; }
        }
    }
}
