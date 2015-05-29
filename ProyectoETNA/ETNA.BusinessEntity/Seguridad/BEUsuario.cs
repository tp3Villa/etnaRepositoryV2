using System;
using System.Collections.Generic;
using System.Text;

namespace ETNA.BusinessEntity.Seguridad
{
    [Serializable]
    public class BEUsuario 
    {
        private string _IdUsuario;
        private string _Nombre;
        private string _Estado;
        private string _Correo;
        private string _NroAnexo;
        private int _IdPerfil;

        private bool _EsPerfilValidador;

        public string IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }

        public string NroAnexo
        {
            get { return _NroAnexo; }
            set { _NroAnexo = value; }
        }

        public int IdPerfil
        {
            get { return _IdPerfil; }
            set { _IdPerfil = value; }
        }

        /// <summary>
        /// Retorna un valor que indica si el perfil del usuario es uno de los roles autorizados para la validacion de contratos. Este es un atributo propio del Sistema de Contratos
        /// </summary>
        public bool EsPerfilValidador
        {
            get { return _EsPerfilValidador; }
            set { _EsPerfilValidador = value; }
        }

    }
}
