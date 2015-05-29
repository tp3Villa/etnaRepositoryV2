using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using ETNA.BusinessEntity.Seguridad; 

namespace ETNA
{

    public sealed class Persistencia<T>
    {

        private static BusinessEntity.ArrayGenerics<T> _ArrayGenerics;

        public static BusinessEntity.ArrayGenerics<T> ArrayGenerics
        {
            get 
            { 
                return Persistencia<T>._ArrayGenerics; 
            }
            set 
            { 
                Persistencia<T>._ArrayGenerics = value; 
            }
        }        
    }

    [Serializable]
    public sealed class Comun
    {

        private static string _UrlPagina;
        //private static string _StatusLogin = "StatusLogin";
        //private static System.Xml.XmlDocument _XmlMenu; 
        public static Exception LastError;

        public static string StatusLogin
        {
            get { return Convert.ToString(HttpContext.Current.Session["StatusLogin"]); }         
        }

        public static BEUsuario BEUsuario
        {
            get { return ((BEUsuario)(HttpContext.Current.Session["BEUsuario"])); }
        }
        

        public static string UrlPagina
        {
            get { return _UrlPagina; }
            set { _UrlPagina = value; }
        }

        public static string ddMMyyyy        
        {   
            get { return string.Format("{0:dddd dd/MM/yyyy}", DateTime.Today); }
        }

        public static string UrlWSSeguridad
        {
            get { return ETNA.Properties.Settings.Default.UrlWSSeguridad; }
        }

        public static string ServidorReportes
        {
            get { return ETNA.Properties.Settings.Default.Tx_Servidor_De_Informes; }
        }

        public static string QueryString(string _key)
        {
            return HttpContext.Current.Request.QueryString[_key];
        }

        public static string IdApplication
        {
            get { return ETNA.Properties.Settings.Default.IdApplication; }
        }

        public static string IPProxy
        {
            get { return ETNA.Properties.Settings.Default.IPProxy; }
        }


        public static int PuertoProxy
        {
            get { return ETNA.Properties.Settings.Default.PuertoProxy ; }
        }

        public static string UserProxy
        {
            get { return ETNA.Properties.Settings.Default.UserProxy; }
        }

        public static string PassProxy
        {
            get { return ETNA.Properties.Settings.Default.PassProxy; }
        }

        public static string DomProxy
        {
            get { return ETNA.Properties.Settings.Default.DomProxy; }
        }

        public static string NumeroRegistrosInicialPorPagina
        {
            get { return ETNA.Properties.Settings.Default.NumeroRegistrosInicialPorPagina; }
        }

        public static string NumeroRegistrosPorPagina
        {
            get { return ETNA.Properties.Settings.Default.NumeroRegistrosPorPagina; }
        }


        public static string GetValueConfig(string _key)
        {
            System.Configuration.Configuration _rootWebConfig;

            _rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/ETNA");
            if (_rootWebConfig.AppSettings.Settings.Count > 0)
            {
                System.Configuration.KeyValueConfigurationElement _customSetting;
                _customSetting = _rootWebConfig.AppSettings.Settings[_key];
                if (_customSetting.Value != null)
                    return _customSetting.Value;
            }
            return null;

        }

        public static string ExtraerValor(object _Campo)
        {
            string _RetornarValor = string.Empty;
            if (string.IsNullOrEmpty(Convert.ToString(_Campo)))
            {
                _RetornarValor = string.Empty;
            }
            else
            {
                _RetornarValor = _Campo.ToString().Trim();
                //verificamos si el tipo de datos es Fecha para extraer el formato dd/mm/yyyy
                if (_Campo.GetType() == typeof(DateTime))
                {
                    DateTime dt = (DateTime)_Campo;
                    _RetornarValor = dt.ToShortDateString();
                }
            }
                
            
           
            return _RetornarValor;
        }

        public static void DesHabilitarTextBox(System.Web.UI.MasterPage  _Master)
        {
            //Deshabilitamos los controles TextBox
            TextBox txt;
            Control ctl = _Master.FindControl("cphMaster");
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    txt = (TextBox)c;
                    txt.Enabled = false;
                }
            }
        }

        public static void DesHabilitarDropDownList(System.Web.UI.MasterPage _Master)
        {
            //Deshabilitamos los controles DropDownList
            DropDownList ddl;
            Control ctl = _Master.FindControl("cphMaster");
            foreach (Control c in ctl.Controls)
            {
                if (c is DropDownList)
                {
                    ddl = (DropDownList)c;
                    ddl.Enabled = false;
                }
            }
        }

        public static void DesHabilitarCalendario(System.Web.UI.MasterPage _Master)
        {
            //Deshabilitamos los controles Calendario

            TextBox txt=new TextBox();
            Control ctlCalendario;
            foreach (Control ctl in _Master.FindControl("cphMaster").Controls)
            {
                if (ctl is UserControl)
                {
                    ctlCalendario = (Control) ctl;
                    txt = (TextBox)ctlCalendario.FindControl("txtFecha");
                    if(txt!=null)
                        txt.Enabled = false;
                    
                }
            }

        }

    }    

}
