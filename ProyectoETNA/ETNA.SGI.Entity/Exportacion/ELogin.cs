using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETNA.SGI.Entity.Exportacion
{
    public class ELogin
    {
        string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        string pasw;
        public string Pasw
        {
            get { return pasw; }
            set { pasw = value; }
        }

        private string nom_Usuario;

        public string Nom_Usuario
        {
            get { return nom_Usuario; }
            set { nom_Usuario = value; }
        }
        private string tipo_Usuario;

        public string Tipo_Usuario
        {
            get { return tipo_Usuario; }
            set { tipo_Usuario = value; }
        }
        private string estado_Usuario;

        public string Estado_Usuario
        {
            get { return estado_Usuario; }
            set { estado_Usuario = value; }
        }
        private string filler1;

        public string Filler1
        {
            get { return filler1; }
            set { filler1 = value; }
        }


        public ELogin()
        { }
    }
}
