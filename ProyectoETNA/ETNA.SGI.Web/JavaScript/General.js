function DeshabilitarClickDerecho(){ 
    return false;
}

function DeshabilitarTeclaF11()
{  
    if(window.event && window.event.keyCode == 122)
        { window.event.keyCode = 505;} 
        
    if(window.event && window.event.keyCode == 505)
        {return false;}  
}



function ConfirmarEliminacion(Boton){
    if(BuscarRadioChecked(Boton) == true){
        var Posicion = (Boton.src).indexOf("Off");
        if (Posicion == -1){
            if (confirm("Esta seguro que desea eliminar el registro seleccionado ?") == true){
                return true;
            }
            else{
	            return false;   
            }
        }
        else{
 	        return false;
        }
    }
    else{
        return false;
    }
}

function BuscarRadioChecked(Boton)
{
    if((Boton.src).indexOf("Off") == -1)
    {
        var f = document.forms.length;
        var i = 0;
        var pos = -1;
        while(pos == -1 && i < f)
        {
            var e = document.forms[i].elements.length;
            var j = 0;
            var k = 0;
            while(pos == -1 && j < e){
                if(document.forms[i].elements[j].type == 'radio')
                {
                    if(document.forms[i].elements[j].checked == true)
                        return true;
                    k++;
                }
                j++;
            }
            i++;
        }
        if(k > 0)
        {
            alert('Debe seleccionar un registro!');
        }
        else
        {
            alert('No hay registros!');
        }
        return false;
    }
    else
    {
        return false;
    }
}

function BuscarCheckBoxChecked(Boton){
    if((Boton.src).indexOf("Off") == -1){
        var f = document.forms.length;
        var i = 0;
        var pos = -1;
        while(pos == -1 && i < f){
            var e = document.forms[i].elements.length;
            var j = 0;
            var k = 0;
            while(pos == -1 && j < e){
                if(document.forms[i].elements[j].type == 'checkbox'){
                    if(document.forms[i].elements[j].checked == true)
                        return true;
                    k++;
                }
                j++;
            }
            i++;
        }
        if(k > 0){
            alert('Debe seleccionar un registro!');
        }
        else{
            alert('No hay registros!');
        }
        return false;
    }
    else{
        return false;
    }
}

function EjecutarValidators(){
    if(typeof(Page_ClientValidate) == 'function'){
        Page_ClientValidate();
    }
}

function AbrirVentanaTelefono(Pagina){
    var Cadena;

    Cadena = window.showModalDialog(Pagina, null, 'center:yes;resizable:no;help:no;status:no;dialogWidth:600px;dialogHeight:400px');

    document.all['ctl00_cphMaster_ddlTelefono'].options.length = 0;

    if(Cadena != ''){
        var Telefonos = Cadena.split('@');
        var i = 0;

        for(i=0; i<Telefonos.length-1; i++){
            document.all['ctl00_cphMaster_ddlTelefono'].options[document.all['ctl00_cphMaster_ddlTelefono'].length] = new Option(Telefonos[i], Telefonos[i]);
        }
    }
}

function AbrirVentanaContacto(Pagina){
    var Cadena;

    Cadena = window.showModalDialog(Pagina, null, 'center:yes;resizable:no;help:no;status:no;dialogWidth:900px;dialogHeight:400px');

    document.all['ctl00_cphMaster_ddlContacto'].options.length = 0;

    if(Cadena != ''){
        var Contactos = Cadena.split('@');
        var i = 0;
        var item;

        for(i=0; i<Contactos.length-1; i++){
            item = Contactos[i].split('|');
            document.all['ctl00_cphMaster_ddlContacto'].options[document.all['ctl00_cphMaster_ddlContacto'].length] = new Option(item[0], item[1]);
        }

        document.all['ctl00_cphMaster_txtRamo'].value = Cadena;
        __doPostBack('ctl00_cphMaster_ddlDepartamento', '');
    }
}

function AbrirVentanaRamo(Pagina){
    var Cadena;

    Cadena = window.showModalDialog(Pagina, null, 'center:yes;resizable:no;help:no;status:no;dialogWidth:450px;dialogHeight:400px');

    if(Cadena != null){
        document.all['ctl00_cphMaster_txtRamo'].value = Cadena;
        __doPostBack('ctl00_cphMaster_ddlDepartamento', '');
    }
}

function AbrirVentanaPoliza(Pagina){
    var Cadena;

    Cadena = window.showModalDialog(Pagina, null, 'center:yes;resizable:no;help:no;status:no;dialogWidth:650px;dialogHeight:400px');

    //        var Cadena = FormBusqueda      + '@' + [0]
    //                     IdTipoPersona     + '@' + [1]  __doPostBack
    //                     IdTitulo          + '@' + [2]  __doPostBack
    //                     Nombre            + '@' + [3]
    //                     ApellidoPaterno   + '@' + [4]
    //                     ApellidoMaterno   + '@' + [5]
    //                     IdSexo            + '@' + [6]  __doPostBack
    //                     FechaNacimiento   + '@' + [7]
    //                     IdTipoDocumento   + '@' + [8]  __doPostBack
    //                     Documento         + '@' + [9]
    //                     IdUbigeo          + '@' + [10] __doPostBack
    //                     DireccionCobranza + '@' + [11]
    //                     IdTelefono        + '@' + [12] __doPostBack
    //                     IdTipoTelefono;           [13] __doPostBack

    if(Cadena == null){
        document.all['ctl00_cphMaster_txtCliente'].value = '';    
    }
    else{
        document.all['ctl00_cphMaster_txtCliente'].value = Cadena;
        __doPostBack('ctl00_cphMaster_ddlTipoPersona', '');
    }
}

function AbrirVentanaCliente(Pagina){
    var Cadena;

    Cadena = window.showModalDialog(Pagina, null, 'center:yes;resizable:no;help:no;status:no;dialogWidth:650px;dialogHeight:400px');

    //        var Cadena = FormBusqueda      + '@' + [0]
    //                     IdCliente         + '@' + [1]  __doPostBack
    //                     NombreCliente;            [2]

    if(Cadena == null){
        document.all['ctl00_cphMaster_txtCliente'].value = '';
    }
    else{
        document.all['ctl00_cphMaster_txtCliente'].value = Cadena;
        __doPostBack('ctl00_cphMaster_ddlTipoPersona', '');
    }
}

function AbrirVentanaClienteX(Pagina){
    var Cadena;

    Cadena = window.showModalDialog(Pagina, null, 'center:yes;resizable:no;help:no;status:no;dialogWidth:650px;dialogHeight:500px');

    //        var Cadena = FormBusqueda      + '@' + [0]
    //                     IdCliente         + '@' + [1]  __doPostBack
    //                     NombreCliente;            [2]

    return Cadena;
}

function AbrirVentanaClienteGenerico(pagina,controlPostBack,controlResultado){
    var cadena;

    cadena = window.showModalDialog(pagina, null, 'center:yes;resizable:no;help:no;status:no;dialogWidth:650px;dialogHeight:400px');

    //        var Cadena = FormBusqueda      + '@' + [0]
    //                     IdCliente         + '@' + [1]  __doPostBack
    //                     NombreCliente;            [2]

    if(cadena == null){
        document.all[controlResultado].value = '';    
    }
    else if(controlPostBack != ''){
        document.all[controlResultado].value = cadena;
        __doPostBack(controlPostBack, '');
    }
    else{
        Cargar(cadena);
    }
}

function AbrirVentanaAseguradoGenerico(pagina,controlPostBack,controlResultado){
    var cadena;

    cadena = window.showModalDialog(pagina, null, 'center:yes;resizable:no;help:no;status:no;dialogWidth:650px;dialogHeight:400px');

    //        var Cadena = FormBusqueda      + '@' + [0]
    //                     IdCliente         + '@' + [1]  __doPostBack
    //                     NombreCliente;            [2]

    if(cadena == null){
        document.all[controlResultado].value = '';    
    }
    else if(controlPostBack != ''){
        document.all[controlResultado].value = cadena;
        __doPostBack(controlPostBack, '');
    }
    else{
        Cargar2(cadena);
    }
}

function ExpandirColapsar(Fila){
    var imagen='img' + Fila;

    if(document.getElementById(Fila).style.display=='none'){
        document.getElementById(Fila).style.display = '';
        document.getElementById(imagen).src='../imagenes/colapsar.gif';
    }
    else
    {
        document.getElementById(Fila).style.display = 'none';
        document.getElementById(imagen).src='../imagenes/expandir.gif';
    }
}

function ContadorTexto(txt, maxlength){
    if(txt.value.length > maxlength){
        txt.value = txt.value.substring(0, maxlength);
    }
}

function ConfirmarExclusion(Boton, IdControl){
    if(BuscarRadioCheckedExcluir(Boton, IdControl) == true){
        var Posicion = (Boton.src).indexOf("Off");
        if (Posicion == -1){
            if (confirm("Esta seguro que desea excluir el registro seleccionado ?") == true){
                return true;
            }
            else{
	            return false;
            }
        }
        else{
 	        return false;
        }
    }
    else{
        return false;
    }
}

function BuscarRadioCheckedExcluir(Boton, IdControl){
    if((Boton.src).indexOf("Off") == -1){
        var f = document.forms.length;
        var i = 0;
        var pos = -1;
        var Cadena;
        while(pos == -1 && i < f){
            var e = document.forms[i].elements.length;
            var j = 0;
            var k = 0;
            while(pos == -1 && j < e){
                if(document.forms[i].elements[j].type == 'radio'){
                    Cadena = document.forms[i].elements[j].id.split('_');
                    if(Cadena[2] == IdControl){
                        if(document.forms[i].elements[j].checked == true)
                            return true;
                        k++;
                    }
                }
                j++;
            }
            i++;
        }
        if(k > 0){
            alert('Debe seleccionar un registro!');
        }
        else{
            alert('No hay registros!');
        }
        return false;
    }
    else{
        return false;
    }
}

function BuscarCheckBoxCheckedTrue(IdControl){
    var f = document.forms.length;
    var i = 0;
    var pos = -1;
    var Cadena;
    while(pos == -1 && i < f){
        var e = document.forms[i].elements.length;
        var j = 0;
        var k = 0;
        while(pos == -1 && j < e){
            if(document.forms[i].elements[j].type == 'checkbox'){
                Cadena = document.forms[i].elements[j].id.split('_');
                if(Cadena[2] == IdControl){
                    if(document.forms[i].elements[j].checked == true)
                        return true;
                    k++;
                }
            }
            j++;
        }
        i++;
    }
    return false;
}

///////////////////////////////////////////////////////////
//Codigo Lizet
///////////////////////////////////////////////////////////
function AbrirVentana(Operacion,OperacionPago,Moneda){
    var cadena;
    var ConfiguracionPagina = 'center:yes;resizable:no;help:no;status:no;dialogWidth:650px;dialogHeight:380px';
    var Pagina = 'OperacionPago.aspx?idOperacion='+ Operacion +'&IdOperacionPago='+ OperacionPago + '&NombreMoneda='+Moneda;
   cadena = window.showModalDialog(Pagina, null, ConfiguracionPagina);
    
  __doPostBack('Obj');
}

function AbrirVentanaCotizacionCompararArchivo(idSolicitud,indice){
    var cadena;
    var ConfiguracionPagina = 'center:yes;resizable:no;help:no;status:no;dialogWidth:650px;dialogHeight:300px';
    var Pagina = 'CotizacionCompararArchivo.aspx?IdSolicitud='+ idSolicitud + "&Indice=" + indice;
    cadena = window.showModalDialog(Pagina, null, ConfiguracionPagina);
  //__doPostBack('Obj');
}

function AbrirVentanaCotizacionAdjuntardePC(idSolicitud,idAseguradora){
    var cadena;
    var ConfiguracionPagina = 'center:yes;resizable:no;help:no;status:no;dialogWidth:650px;dialogHeight:380px';
    var Pagina = 'CargarArchivo.aspx?IdSolicitud=' + idSolicitud + '&IdAseguradora=' + idAseguradora;
    cadena = window.showModalDialog(Pagina, null, ConfiguracionPagina);
  __doPostBack('refrescar');
}

function AbrirVentanaCotizacionAdjuntarDeCorreo(idSolicitud,idAseguradora){
    var cadena;
    var ConfiguracionPagina = 'center:yes;resizable:no;help:no;status:no;dialogWidth:650px;dialogHeight:380px';
    var Pagina = 'CotizacionAdjuntarDeCorreo.aspx?IdSolicitud=' + idSolicitud + '&IdAseguradora=' + idAseguradora;
    cadena = window.showModalDialog(Pagina, null, ConfiguracionPagina);
  __doPostBack('refrescar');
}

function AbrirVentanaCotizacionAceptar(idSolicitud,idAseguradora){
    var cadena;
    var ConfiguracionPagina = 'center:yes;resizable:no;help:no;status:no;scroll:no;dialogWidth:350px;dialogHeight:130px';
    var Pagina = 'CotizacionAceptar.aspx?IdSolicitud=' + idSolicitud + '&IdAseguradora=' + idAseguradora;
    cadena = window.showModalDialog(Pagina, null, ConfiguracionPagina);
  __doPostBack('refrescar');
}

function ImprimirDoc(){
    var objeto = document.getElementsByTagName('TABLE');
	for(i = 0; i < objeto.length; i++){
    objeto(i).style.visibility = 'hidden';
    }
    document.all.item('TbImprimir').style.visibility='visible';
    document.all.item('TbImprimir').style.position='absolute';
    document.all.item('TbImprimir').style.visibility = 'visible';
    document.all.item('TbImprimir').style.background='white';
    document.all.item('TbImprimir').style.top = '0px' ;
    document.all.item('TbImprimir').style.left = '0px' ;
    document.all.item('tabHeaderImprimir').style.display = '';
    
    var hijos = document.all.item('TbImprimir').getElementsByTagName('TABLE');
	for(i = 0; i < hijos.length; i++){
    hijos(i).style.visibility = 'visible';
    }
	if (!factory.object){
	    alert("Lo Sentimos, no se puede Imprimir por favor comuniquese\ncon el adminsitrador del Sistema.")
		}
	else{
	    factory.printing.header = ''
		factory.printing.footer = ''
 		factory.printing.leftMargin = 25
		factory.printing.topMargin = 25
		factory.printing.rightMargin = 0
		factory.printing.bottomMargin = 25
		factory.printing.portrait = false
		}
        if (factory.printing.Print(false)){
		}
		var objeto = document.getElementsByTagName('TABLE');
	    for(i = 0; i < objeto.length; i++){
            objeto(i).style.visibility = 'visible';
        }
	document.all.item('TbImprimir').style.position='static';
    document.all.item('tabHeaderImprimir').style.display = 'none';
    
      __doPostBack('Obj');
}
function ImprimirDocumento(){
        if (!factory.object){
					alert("Lo Sentimos, no se puede Imprimir por favor comuniquese\ncon el adminsitrador del Sistema.")
				}
				else{
					factory.printing.header = ''
					factory.printing.footer = ''
					factory.printing.portrait = false
					factory.printing.leftMargin = 25
					factory.printing.topMargin = 25
					factory.printing.rightMargin = 0
					factory.printing.bottomMargin = 25
				}
				factory.printing.Print(false)
}

function MostrarArchivo(rutaArchivo){
    alert(rutaArchivo);
    alert(decodeURIComponent(rutaArchivo));
    window.open(rutaArchivo,'');    
}

function Valueddl(nameobj)
{
    cbo = document.getElementById(nameobj);
    return cbo.options[cbo.selectedIndex].value;
}

function Textddl(nameobj)
{
    cbo = document.getElementById(nameobj);
    var t = cbo.options[cbo.selectedIndex].text;             
    return t;                
}

function ValueListBox(nameobj)
{            
    cbo = document.getElementById(nameobj);
    if (cbo.selectedIndex == '-1')
        return 0;
    
    return cbo.options[cbo.selectedIndex].value;
}

function ModoIngresoInterlocutor(nameobj)
{    
    //1= Indica que el nombre del interlocutor es seleccionable. 
    //0= Indica que el nombre del interlocutor se debe ingresar.
    var dato = Textddl(nameobj);
    dato = dato.substring(dato.length - 1)
    return dato;
}

function AbrirFrmConsulta(CodigoConsulta,ControlDestinoCodigo,ControlDestinoDescripcion,ValorMostrar,Condiciones,Ancho,Alto)
{        
    //ValorMostrar (Valor a mostrar en el control destino): 
    // --> C :Codigo , D : Descripcion , A : Ambos en el formato (Codigo - Descripcion)    
    // --> 1 :Codigo y  Descripcion en controles destinos distintos , 2 : Ambos en el formato (Codigo - Descripcion) en un mismo control destino    
        
    OpenCenterPopUp("../Busquedas/Consultas.aspx?CodigoConsulta="+CodigoConsulta+"&ControlDestinoCodigo="+ControlDestinoCodigo+"&ControlDestinoDescripcion="+ControlDestinoDescripcion+"&ValorMostrar="+ValorMostrar+"&Condiciones="+Condiciones+"",null,Ancho,Alto);            
    
    
} 
function OpenCenterPopUp(url, name, width, height)
{
    var TopLeftX=screen.width / 2 - width/2;
    var TopLeftY=screen.height / 2 - height/2;
    window.open(url,name,'top='+TopLeftY+', left='+TopLeftX+', width='+width+',height='+height+',directories=no,location=no,menubar=no,scrollbars=no,status=no,toolbar=no,resizable=no');											
}

