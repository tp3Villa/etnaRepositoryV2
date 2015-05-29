﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34209
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.34209.
// 
#pragma warning disable 1591

namespace ETNA.swSeguridad {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WSSeguridadSoap", Namespace="http://mpr.org/")]
    public partial class WSSeguridad : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AutenticaUsuarioOperationCompleted;
        
        private System.Threading.SendOrPostCallback getCadenaConexionUsuarioOperationCompleted;
        
        private System.Threading.SendOrPostCallback esAutorizadoOperationCompleted;
        
        private System.Threading.SendOrPostCallback Cambiar_ClaveOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WSSeguridad() {
            this.Url = global::ETNA.Properties.Settings.Default.SGR_swSeguridad_WSSeguridad;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event AutenticaUsuarioCompletedEventHandler AutenticaUsuarioCompleted;
        
        /// <remarks/>
        public event getCadenaConexionUsuarioCompletedEventHandler getCadenaConexionUsuarioCompleted;
        
        /// <remarks/>
        public event esAutorizadoCompletedEventHandler esAutorizadoCompleted;
        
        /// <remarks/>
        public event Cambiar_ClaveCompletedEventHandler Cambiar_ClaveCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mpr.org/AutenticaUsuario", RequestNamespace="http://mpr.org/", ResponseNamespace="http://mpr.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool AutenticaUsuario(string p_Tx_Usuario_ID, string p_Tx_Clave, string p_Tx_Aplicacion_ID, out string p_Mensaje) {
            object[] results = this.Invoke("AutenticaUsuario", new object[] {
                        p_Tx_Usuario_ID,
                        p_Tx_Clave,
                        p_Tx_Aplicacion_ID});
            p_Mensaje = ((string)(results[1]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void AutenticaUsuarioAsync(string p_Tx_Usuario_ID, string p_Tx_Clave, string p_Tx_Aplicacion_ID) {
            this.AutenticaUsuarioAsync(p_Tx_Usuario_ID, p_Tx_Clave, p_Tx_Aplicacion_ID, null);
        }
        
        /// <remarks/>
        public void AutenticaUsuarioAsync(string p_Tx_Usuario_ID, string p_Tx_Clave, string p_Tx_Aplicacion_ID, object userState) {
            if ((this.AutenticaUsuarioOperationCompleted == null)) {
                this.AutenticaUsuarioOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAutenticaUsuarioOperationCompleted);
            }
            this.InvokeAsync("AutenticaUsuario", new object[] {
                        p_Tx_Usuario_ID,
                        p_Tx_Clave,
                        p_Tx_Aplicacion_ID}, this.AutenticaUsuarioOperationCompleted, userState);
        }
        
        private void OnAutenticaUsuarioOperationCompleted(object arg) {
            if ((this.AutenticaUsuarioCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AutenticaUsuarioCompleted(this, new AutenticaUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mpr.org/getCadenaConexionUsuario", RequestNamespace="http://mpr.org/", ResponseNamespace="http://mpr.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getCadenaConexionUsuario(string p_Tx_Usuario_ID) {
            object[] results = this.Invoke("getCadenaConexionUsuario", new object[] {
                        p_Tx_Usuario_ID});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getCadenaConexionUsuarioAsync(string p_Tx_Usuario_ID) {
            this.getCadenaConexionUsuarioAsync(p_Tx_Usuario_ID, null);
        }
        
        /// <remarks/>
        public void getCadenaConexionUsuarioAsync(string p_Tx_Usuario_ID, object userState) {
            if ((this.getCadenaConexionUsuarioOperationCompleted == null)) {
                this.getCadenaConexionUsuarioOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetCadenaConexionUsuarioOperationCompleted);
            }
            this.InvokeAsync("getCadenaConexionUsuario", new object[] {
                        p_Tx_Usuario_ID}, this.getCadenaConexionUsuarioOperationCompleted, userState);
        }
        
        private void OngetCadenaConexionUsuarioOperationCompleted(object arg) {
            if ((this.getCadenaConexionUsuarioCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getCadenaConexionUsuarioCompleted(this, new getCadenaConexionUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mpr.org/esAutorizado", RequestNamespace="http://mpr.org/", ResponseNamespace="http://mpr.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool esAutorizado(string p_Tx_Usuario_ID, string p_Tx_Funcion_ID, string p_Tx_Aplicacion_ID, out string p_Tx_Mensaje) {
            object[] results = this.Invoke("esAutorizado", new object[] {
                        p_Tx_Usuario_ID,
                        p_Tx_Funcion_ID,
                        p_Tx_Aplicacion_ID});
            p_Tx_Mensaje = ((string)(results[1]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void esAutorizadoAsync(string p_Tx_Usuario_ID, string p_Tx_Funcion_ID, string p_Tx_Aplicacion_ID) {
            this.esAutorizadoAsync(p_Tx_Usuario_ID, p_Tx_Funcion_ID, p_Tx_Aplicacion_ID, null);
        }
        
        /// <remarks/>
        public void esAutorizadoAsync(string p_Tx_Usuario_ID, string p_Tx_Funcion_ID, string p_Tx_Aplicacion_ID, object userState) {
            if ((this.esAutorizadoOperationCompleted == null)) {
                this.esAutorizadoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnesAutorizadoOperationCompleted);
            }
            this.InvokeAsync("esAutorizado", new object[] {
                        p_Tx_Usuario_ID,
                        p_Tx_Funcion_ID,
                        p_Tx_Aplicacion_ID}, this.esAutorizadoOperationCompleted, userState);
        }
        
        private void OnesAutorizadoOperationCompleted(object arg) {
            if ((this.esAutorizadoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.esAutorizadoCompleted(this, new esAutorizadoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://mpr.org/Cambiar_Clave", RequestNamespace="http://mpr.org/", ResponseNamespace="http://mpr.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Cambiar_Clave(string p_Tx_Usuario_ID, string p_Tx_Clave_Antigua, string p_Tx_Clave, string p_Tx_Confirma_Clave, out string p_Tx_Mensaje) {
            object[] results = this.Invoke("Cambiar_Clave", new object[] {
                        p_Tx_Usuario_ID,
                        p_Tx_Clave_Antigua,
                        p_Tx_Clave,
                        p_Tx_Confirma_Clave});
            p_Tx_Mensaje = ((string)(results[1]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void Cambiar_ClaveAsync(string p_Tx_Usuario_ID, string p_Tx_Clave_Antigua, string p_Tx_Clave, string p_Tx_Confirma_Clave) {
            this.Cambiar_ClaveAsync(p_Tx_Usuario_ID, p_Tx_Clave_Antigua, p_Tx_Clave, p_Tx_Confirma_Clave, null);
        }
        
        /// <remarks/>
        public void Cambiar_ClaveAsync(string p_Tx_Usuario_ID, string p_Tx_Clave_Antigua, string p_Tx_Clave, string p_Tx_Confirma_Clave, object userState) {
            if ((this.Cambiar_ClaveOperationCompleted == null)) {
                this.Cambiar_ClaveOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCambiar_ClaveOperationCompleted);
            }
            this.InvokeAsync("Cambiar_Clave", new object[] {
                        p_Tx_Usuario_ID,
                        p_Tx_Clave_Antigua,
                        p_Tx_Clave,
                        p_Tx_Confirma_Clave}, this.Cambiar_ClaveOperationCompleted, userState);
        }
        
        private void OnCambiar_ClaveOperationCompleted(object arg) {
            if ((this.Cambiar_ClaveCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Cambiar_ClaveCompleted(this, new Cambiar_ClaveCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void AutenticaUsuarioCompletedEventHandler(object sender, AutenticaUsuarioCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AutenticaUsuarioCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AutenticaUsuarioCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string p_Mensaje {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void getCadenaConexionUsuarioCompletedEventHandler(object sender, getCadenaConexionUsuarioCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getCadenaConexionUsuarioCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getCadenaConexionUsuarioCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void esAutorizadoCompletedEventHandler(object sender, esAutorizadoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class esAutorizadoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal esAutorizadoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string p_Tx_Mensaje {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void Cambiar_ClaveCompletedEventHandler(object sender, Cambiar_ClaveCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Cambiar_ClaveCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Cambiar_ClaveCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string p_Tx_Mensaje {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
}

#pragma warning restore 1591