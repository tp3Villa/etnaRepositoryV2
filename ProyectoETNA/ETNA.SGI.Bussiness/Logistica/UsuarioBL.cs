using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETNA.SGI.Data.Logistica;
using ETNA.SGI.Entity.Logistica;

namespace ETNA.SGI.Bussiness.Logistica
{
    public class UsuarioBL
    {
        private static UsuarioDA objUsuario;

        public UsuarioBL()
        {
            objUsuario = new UsuarioDA();
        }

        public string ValidarUsuario(string usuario, string password)
        {
            return objUsuario.ValidarUsuario(usuario, password);
        }

        public PersonaBE ObtenerInfoUsuarioLogin(string codigo)
        {
            return objUsuario.ObtenerInfoUsuarioLogin(codigo);
        }
    }
}
