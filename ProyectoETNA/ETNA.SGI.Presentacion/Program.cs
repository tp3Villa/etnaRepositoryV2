﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ETNA.SGI.Presentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSplash());
        }

        public static string Usuario = "";
        public static string Nombre = "";
        public static string CodCli = "";
        public static string CodReq = "";
        public static int CodPersonal;
    }
}
