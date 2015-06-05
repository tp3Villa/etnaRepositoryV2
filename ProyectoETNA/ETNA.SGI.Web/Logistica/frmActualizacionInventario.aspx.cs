using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyCallback;
using ETNA.SGI.Entity.Logistica;
using ETNA.SGI.Bussiness.Logistica;
using Json;
using ETNA.SGI.Web.MasterPage;

namespace ETNA.SGI.Web.Logistica
{
    public partial class ActualizacionInventario : System.Web.UI.Page
    {
        /// <summary>
        /// Inicializa la carga de la página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadMetodos();
        }
        /// <summary>
        /// Procedimiento de registro de los manejadores de eventos de la página
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(ObtenerInventariosEventHandler);
            CallbackManager.Register(IniciarInventarioEventHandler);
            CallbackManager.Register(AjustarInventarioEventHandler);
            base.OnInit(e);
        }
        /// <summary>
        /// Carga de las listas de control de los formularios de la página
        /// </summary>
        protected void LoadMetodos()
        {
            CargarTipoInventarios();
            CargarAlmacenes();
        }
        /// <summary>
        /// Carga la lista de tipos de inventarios
        /// </summary>
        protected void CargarTipoInventarios()
        {
            try
            {
                ddlEstadoInventario.DataSource = new TipoBL().ObtenerTipoEstadoInventario();
                ddlEstadoInventario.DataValueField = "In_Id_Tipo";
                ddlEstadoInventario.DataTextField = "Vc_Nombre";
                ddlEstadoInventario.DataBind();

                ddlEstadoInventario.Items.Insert(0, new ListItem("------ Todos ------", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Carga la relación de almacenes autorizadas para el usuario autorizado
        /// </summary>
        protected void CargarAlmacenes()
        {
            try
            {
                string cod = LoginInfo.CodigoUsuario;

                ddlAlmacen.DataSource = new UsuarioAlmacenBL().ObtenerAlmacen(cod);
                ddlAlmacen.DataValueField = "In_idAlmacen";
                ddlAlmacen.DataTextField = "Vc_descripcionAlmacen";
                ddlAlmacen.DataBind();

                ddlAlmacen.Items.Insert(0, new ListItem("------ Todos ------", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Manejador para iniciar el inventario programado
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public string IniciarInventarioEventHandler(string arg)
        {
            string result = string.Empty;
            try
            {
                Hashtable data = JsonSerializer.FromJson<Hashtable>(arg);
                ProgramacionInventarioBE oBe = new ProgramacionInventarioBE()
                {
                    In_idProgInventario = int.Parse(data["IN_idProgInventario"].ToString())
                };

                result = new ProgramacionInventarioBL().IniciarInventario(oBe).ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToString();
        }
        /// <summary>
        /// Manejador para el control de ajuste de inventario
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public string AjustarInventarioEventHandler(string arg)
        {
            string result = string.Empty;
            try
            {
                Hashtable data = JsonSerializer.FromJson<Hashtable>(arg);
                ProgramacionInventarioBE oBe = new ProgramacionInventarioBE()
                {
                    In_idProgInventario = int.Parse(data["IN_idProgInventario"].ToString())
                };

                result = new ProgramacionInventarioBL().AjustarInventario(oBe).ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result.ToString();
        }
        /// <summary>
        /// Manejador para obtener la lista de inventarios
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public string ObtenerInventariosEventHandler(string arg)
        {
            try
            {

                Hashtable data = JsonSerializer.FromJson<Hashtable>(arg);
                ProgramacionInventarioBE oBe = new ProgramacionInventarioBE()
                {
                    In_idEstadoInventario = int.Parse(data["IN_estadoInventario"].ToString()),
                    In_idAlmacen = int.Parse(data["IN_almacen"].ToString())
                };

                List<ProgramacionInventarioBE> listInventarios = new ProgramacionInventarioBL().ObtenerInventarios(oBe);

                gvInventarios.DataSource = listInventarios;
                gvInventarios.DataBind();

                return JsonSerializer.ToJson(new
                {
                    resultado = gvInventarios.GetHtml(),
                    rows = listInventarios.Count.ToString()
                });
            }
            catch (Exception ex)
            {
                return JsonSerializer.ToJson(new
                {
                    resultado = ex.Message,
                    rows = 0
                });
            }
        }
    }
}