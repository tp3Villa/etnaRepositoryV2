//************************************************************
// FUNCIONES GENERALES
//************************************************************
// Cierra la ventana activa
//************************************************************
function Cerrar()
{
        self.close()
}
//************************************************************
// Funcion que permite saber si una variable existe dentro de la forma
//************************************************************
function js_ExisteElemento(forma,elemento)
{ for (var i = 0; i < forma.length; i++) {
       if (forma.elements[i].name == elemento) {
          return 1; }
 } return 0;
}
//************************************************************
// Verifica si es una cadena está vacía.
//************************************************************
function isEmpty(s)
{   return ((s == null) || (s.length == 0))
}
//************************************************************
// Verifica si es una cadena contiene sólo espacios en blanco,
// tabuladores, o retornos de linea)
//************************************************************
function isWhitespace (s)

{   var i;
     var whitespace = " \t\n\r";
    if (isEmpty(s)) return true;
    for (i = 0; i < s.length; i++)
    {
        var c = s.charAt(i);
        // si el caracter en que estoy no aparece en whitespace,
        // entonces retornar falso
        if (whitespace.indexOf(c) == -1) return false;
    }
    return true;
}
//************************************************************
// Quita todos los caracteres que que estan en "bag" de 
// la cadena "s".
//************************************************************
function stripCharsInBag (s, bag)
{   var i;
    var returnString = "";

    // Buscar por el string, si el caracter no esta en "bag",
    // agregarlo a returnString

    for (i = 0; i < s.length; i++)
    {   var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}
//************************************************************
// Quita espacios en blanco
//************************************************************
function trim(cadena)
{ cadenaE="";
  for (i=0;i<cadena.length;i++)
  {     letra=cadena.substring(i,i+1);
    if (letra!=' ') { cadenaE=cadenaE + letra; }
  }
  return(cadenaE);
}
//************************************************************
// Verifica si es un caracter es una letra.
//************************************************************
function isLetter (c)
{
var lowercaseLetters = "abcdefghijklmnopqrstuvwxyzáéíóúñü.,"
var uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZÁÉÍÓÚÑ"
    return( ( uppercaseLetters.indexOf( c ) != -1 ) ||
            ( lowercaseLetters.indexOf( c ) != -1 ) )
}
//************************************************************
// Verifica si un caracter es un número
//************************************************************
function isDigit (c)
{   return ((c >= "0") && (c <= "9"))
}
//************************************************************
// Verifica si una cadena contiene sólo letras o números
//************************************************************
function isAlphanumeric (s)
{   var i;
    for (i = 0; i < s.length; i++)
    {
        var c = s.charAt(i);
        if (! (isLetter(c) || isDigit(c) ) )
        return false;
    }
    return true;
}

//************************************************************
// Verifica si una cadena contiene  solo números
//************************************************************
function EsNumero(s)
{   var i;
    for (i = 0; i < s.length; i++)
    {
        var c = s.charAt(i);
        if (! (isDigit(c) ) || c=='.')
        return false;
    }
    return true;
}

//************************************************************
// Verifica si una cadena es un número real
//************************************************************
function EsReal(numero)
 {
   if(numero=="")
   {return false}
   Decimal=false
   numerostr="" + numero
   for (var i=0; i < numerostr.length; i++) {
   var caracter=numerostr.charAt(i)
   if (caracter== "." && !Decimal) {
      Decimal=true
      continue
   }

   if (caracter==",")
   {continue}

   if (caracter < "0" || caracter > "9") 
   { return false }
 }

 if (numero>9999999999999.99)
 { return false }
 return true
}

//************************************************************
// Verifica si una cadena contiene sólo letras.
//************************************************************
function isAlphabetic (s)
{   var i;
    for (i = 0; i < s.length; i++)
    {
        // Check that current character is letter.
        var c = s.charAt(i);
        if (!isLetter(c))
             return false;
    }
    return true;
}

//************************************************************
// Verifica si es una cadena es un nombre válido: tiene sólo 
// letras,números o espacios en blanco.
//************************************************************
function EsNombre (s)
{
     var whitespace = " \t\n\r";
     variable=stripCharsInBag( s, whitespace )
     return( isAlphabetic(variable) );
}


//************************************************************
// Verifica si es una cadena es una dirección de correo válida
//************************************************************
function EsEmail (s)
{
    if (isWhitespace(s)) return false;
    var i = 1;nro_arrobas=0;
    var sLength = s.length;
    while (i < sLength)
    { 
		if (s.charAt(i) == "@") {nro_arrobas++;}
		i++
    }
	
	if (nro_arrobas>=2) {return false;}	
    i = 1;
    var sLength = s.length;	
    while ((i < sLength) && (s.charAt(i) != "@"))
    { i++ }

   if ((i >= sLength) || (s.charAt(i) != "@"))  return false;
    else i += 2;
    while ((i < sLength) && (s.charAt(i) != "."))
    { i++ }

	var pospripun = i;
    if ((i >= sLength - 1) || (s.charAt(i) != ".")) {return false;}
    else 
	{
		var npuntos = 0;
		while (pospripun < sLength)
		{
			if (s.charAt(pospripun) == ".")
			{npuntos++;}
			pospripun++;
		}
		if (npuntos > 2) {return false;}
		else 
		{
			if (s.charAt(pospripun - 1) == ".") {return false;}
			else return true;
		}
	}
}

//**************************************************
//	verifica si la cadena tiene apostrofes
//*************************************************
function HayApostrofe(s)
{
    var i;
    for (i = 0; i < s.length; i++)
    {
        var c = s.charAt(i);
        if (c=="'")
        return true;
    }
    return false;
}

//************************************************************
// Verifica si una cadena es una dirección (ubicación) válida
//************************************************************
function EsDireccion (s)
{   var i;
    var whitespace = " \t\n\r";
    s=stripCharsInBag( s, whitespace )
    for (i = 0; i < s.length; i++)
    {
        var c = s.charAt(i);
        if (!(isLetter(c) || isDigit(c) || c=="."))
        return false;
    }
    return true;
}


 function fnumero(numero)
     { for (var i = 0; i < numero.length; i++)
         { var carac = numero.substring(i,i+1)
         if (carac < "0" || carac > "9")
          {
             return false;
          }
         }
     return true;
     }
//************************************************************
// Verifica si una cadena es un número de teléfono válido
//************************************************************
function EsTelefono (s)
{
    var modString;
    var phoneChars = "()-+ ";
    modString = stripCharsInBag( s, phoneChars );
      if (modString.length < 6 )
		{ return false; }
    variable =  fnumero(modString)
    return variable;
}

//************************************************************
// Verifica si una cadena es una fecha válida.
//************************************************************
function valida_fecha(o)
{
   if (o.value!='')
	{
	var dia=o.value.substr(0,2)
	var mes=o.value.substr(3,2)
	var ano=o.value.substr(6,4)
	if ((o.value.substr(2,1) != '/') || (o.value.substr(5,1) != '/')) 
	{
		return false;
	}
	if (! EsNumero(dia)) 	return false;
	if (! EsNumero(mes)) 	return false;
	if (! EsNumero(ano)) 	return false;
	if(dia.substring(0,1)=='0')
	{
		dia=dia.substring(1,2)
	}
	if(mes.substring(0,1)=='0')
	{
		mes=mes.substring(1,2)
	}
	if (mes < 1 || mes > 12)
	{
	   return false;
	}
	if (dia < 1 || dia > 31)
	{
	   return false;
	}
	if (ano < 1900 || ano > 9999)
	{
	   return false;
	}
	if(mes==2 && dia>29)   	//valida Febrero
	   return false;
	if ((ano%4)!=0 && dia ==29 && (mes==2)) // año bisiesto
		return false;
	if ((mes==4||mes==6||mes==9||mes==11)& dia>30) //Meses de 30 dias.
		return false;
	}	
	return true;
 }


//************************************************************
// Verifica si una cadena es válida como login o password
//************************************************************
function isLoginPass(inputVal)
{
    if (fnumero(inputVal))
    {
    	alert("Ingrese una cadena que contenga caracteres y numeros");
    	return false;
    }
    return isAlphanumeric(inputVal);
}

//************************************************************
// Verifica si una palabra se encuentra en una cadena
//************************************************************
function Pal_in_Cad (cadena, palabra)
{   var i, longpalabra, longcadena, fin;
	longcadena  = cadena.length;
	longpalabra = palabra.length;
    fin=0;
    i=0;
    if (longcadena >= longpalabra)
    {
		while ( !fin && i<longcadena)
		{
			if (palabra == cadena.substring(i,i+longpalabra))
			{	fin=1;
				return false;
			}
			i=i+1;
		}
	}
    return true;
}

//************************************************************
// Verifica si es una ruta y nombre de archivo completo
//************************************************************
function EsRutaNombreArch (s)
{   
    if (isWhitespace(s)) return false;
    var i = s.length-1;
    while ((i>=0) && (s.charAt(i) != "."))
    { i--;}
    if ((i <= 0) || (s.charAt(i) != "."))  return false;
    else i -= 1; 
    //if (!isLetter(s.charAt(i))) return false; 
    //para que el nombre del archivo tenga al menos una letra
    while ((i >= 0) && (s.charAt(i) != "\\"))
    { i--; }
    if ((i <= 0) || (s.charAt(i) != "\\"))  return false;
    else i -= 1;

    while ((i >= 0) && (s.charAt(i) != ":"))
    { i--;}
    if ((i != 1) || (s.charAt(1) != ":") || 
    (!isLetter(s.charAt(0))) || (s.charAt(2) != "\\") ) 
    return false;
    else return true;
}

/*******************************************************************/
/* Funciones para filtrar el ingreso de caracteres en campos de 
ingreso de datos */
/*******************************************************************/
function ingresoMayusculas()
{
	if((window.event.keyCode >= 97 && window.event.keyCode <= 122) 
	|| window.event.keyCode == 241)
	{
		window.event.keyCode -= 32;
	}	
}

function ingresoSoloMayusculas()
{
	if((window.event.keyCode >= 97 && window.event.keyCode <= 122) || 	window.event.keyCode == 241)
	{
		window.event.keyCode -= 32;
	}
	else if((window.event.keyCode < 65 || window.event.keyCode > 90) && window.event.keyCode != 209 && window.event.keyCode != 32)
	{
		window.event.keyCode = 0;
	}	
}
		
//Permite solo el ingreso de mayúsculas y dígitos
function ingresoSoloMayusculasYDigitos()
{        
	if((window.event.keyCode >= 97 && window.event.keyCode <= 122) || window.event.keyCode == 241 || window.event.keyCode == 154)
	{
		window.event.keyCode -= 32;
	}
	else if(((window.event.keyCode < 65 || window.event.keyCode > 90) && (window.event.keyCode < 48 
	    || window.event.keyCode > 57)) && window.event.keyCode != 209 
	&& window.event.keyCode != 32)
	{
		window.event.keyCode = 0;
	}	
}

function ConvertUpperCase()
{
	if((window.event.keyCode >= 97 && window.event.keyCode <= 122) || 	window.event.keyCode == 241)
	{
		window.event.keyCode -= 32;
	}
	else if (window.event.keyCode >= 126 && window.event.keyCode <= 254)
	{
		window.event.keyCode = 0;
	}	
}

//Permite validad direcciones
function ingresoSoloDirecciones()
{
	if((window.event.keyCode >= 97 && window.event.keyCode <= 122) || window.event.keyCode == 241 || window.event.keyCode == 154)
	{
		window.event.keyCode -= 32;
	}
	else if(((window.event.keyCode < 65 || window.event.keyCode > 90) && 
	        (window.event.keyCode < 48 || window.event.keyCode > 57)) && 
	            window.event.keyCode != 209 && window.event.keyCode != 32 && window.event.keyCode!=47)
	{
		window.event.keyCode = 0;
	}	
}

//Permite solo el ingreso de numeros y punto (.)
function ingresoNumeroDecimales()
{	
	if(window.event.keyCode != 46 && (window.event.keyCode != 44)&&
	(window.event.keyCode < 48 || window.event.keyCode > 57))
	{
		window.event.keyCode = 0;
	}
}

//Permite solo el ingreso de numeros
function ingresoNumeroEnteroPositivo()
{	
    if(window.event.keyCode == 13)
	{	    
		return;
	}	
	if(window.event.keyCode < 48 || window.event.keyCode > 57)
	{
		window.event.keyCode = 0;					
	}	
	
}
		
//Permite solo el ingreso de fechas en formato dd/mm/aaaa
function ingresoFecha(o)
{	
	if(window.event.keyCode < 48 || window.event.keyCode > 57)
	{
		window.event.keyCode = 0;
		return;
	}
	if(o.value.length == 1 || o.value.length == 4)
	{
		o.value += String.fromCharCode(window.event.keyCode) + "/";
		window.event.keyCode = 0;
		return;
	}
	else if(o.value.length==2 && o.value.substring(2,1)!="/" )
	{
		o.value = o.value.substring(0,2) + "/" + 
		String.fromCharCode(window.event.keyCode);
		window.event.keyCode = 0;
		return;
	}
	else if(o.value.length==5 && o.value.substring(5,1)!="/" )
	{
		o.value = o.value.substring(0,5) + "/" + 
		String.fromCharCode(window.event.keyCode);
		window.event.keyCode = 0;
		return;
	}
}

//Sumar 3 textos y poner resultado en un 4to
function suma(o,o1,o2,oT)
{
	var t=0;
	if (EsReal(o.value))
	{
		t+=parseFloat(o.value);
	}
	if (EsReal(o1.value))
	{
		t+=parseFloat(o1.value);
	}
	if (o2!=null)
	{
		if (EsReal(o2.value))
		{
			t+=parseFloat(o2.value);
		}
	}
	t=redondear(t,2)
	oT.value=t;
}

function redondear(cantidad, decimales) 
{
	var cantidad = parseFloat(cantidad);
	var decimales = parseFloat(decimales);
	decimales = (!decimales ? 2 : decimales);
	return Math.round(cantidad * Math.pow(10, decimales)) / 
	Math.pow(10, decimales);
}

function redondearObj(o,decimales) 
{
	var cantidad = parseFloat(o.value);
	o.value=redondear(cantidad,decimales)
}

function fechaActual(o)
{
var now = new Date();
var dia = now.getDay();
var mes = now.getMonth();
var fecha;

if(dia==0){fecha="Domingo, ";}
else if(dia==1){fecha="Lunes, ";}
else if(dia==2){fecha="Martes, ";}
else if(dia==3){fecha="Miércoles, ";}
else if(dia==4){fecha="Jueves, ";}
else if(dia==5){fecha="Viernes, ";}
else{fecha="Sábado, ";}

fecha = fecha + now.getDate() + " de ";

if(mes==0){fecha=fecha + "Enero";}
else if(mes==1){fecha=fecha + "Febrero";}
else if(mes==2){fecha=fecha + "Marzo";}
else if(mes==3){fecha=fecha + "Abril";}
else if(mes==4){fecha=fecha + "Mayo";}
else if(mes==5){fecha=fecha + "Junio";}
else if(mes==6){fecha=fecha + "Julio";}
else if(mes==7){fecha=fecha + "Agosto";}
else if(mes==8){fecha=fecha + "Septiembre";}
else if(mes==9){fecha=fecha + "Octubre";}
else if(mes==10){fecha=fecha + "Noviembre";}
else{fecha=fecha + "Diciembre";}

fecha = fecha + " del " + now.getYear();
o.value= fecha
}

//*******************************************************************
var popUp; 

function OpenCalendar(idname, postBack)
{
	popUp = window.open('../Calendar.aspx?formname=' + 
	document.forms[0].name + '&id=' + idname + '&selected=' + 
	document.forms[0].elements[idname].value + '&postBack=' + 
	postBack, 'popupcal', 'width=165,height=208,top=250,left=400');
}
//function SetDate(formName, id, newDate, postBack)
//{
//	eval('var theform = document.' + formName + ';');
//	popUp.close();
//	theform.elements[id].value = newDate;
//	if (postBack)
//		__doPostBack(id,'');
//}		
//*******************************************************************

function RellenaCeros(o)
{
if (o.value.length == 1)
{o.value = '0' + o.value;}
}

function Ceros(s)
{
if (s.length == 1)
{s = '0' + s;}
return s;
}

function ComparaFechaHoy(o)
{    
    var now = new Date();
    var dia = now.getDate().toString();
    var mes = now.getMonth()+1;
    mes = mes.toString();

    var ano = now.getYear().toString();
    var fechahoy = ano.toString() + Ceros(mes) + Ceros(dia);
    var fechatxt = o.value.substring(10,6) + o.value.substring(5,3) + o.value.substring(0,2);
    if (fechahoy>fechatxt) 
    {
	    alert("La fecha de plazo de respuesta no puede ser menor a la de hoy");
	    o.value=Ceros(dia) + "/" + Ceros(mes) + "/" + ano;
    }
}

function CompararFechas(fecha1, fecha2, tipocomparacion)
{    
    //Retorna verdadero segun el tipo de comparacion    
    
    var f1 = parseInt(fecha1.substring(10,6) + Ceros(fecha1.substring(5,3)) + Ceros(fecha1.substring(0,2)));
    var f2 = parseInt(fecha2.substring(10,6) + Ceros(fecha2.substring(5,3)) + Ceros(fecha2.substring(0,2))); 
    
    if (tipocomparacion == ">")    
    {
        if (f1>f2)     
	        return true;        
    }
    
    if (tipocomparacion == "<")    
    {
        if (f1<f2)     
	        return true;        
    }
    
    if (tipocomparacion == ">=")    
    {
        if (f1>=f2)     
	        return true;        
    }
    
    if (tipocomparacion == "<=")    
    {
        if (f1<=f2)     
	        return true;        
    }
    
      if (tipocomparacion == "!=")    
    {
        if (f1!=f2)     
	        return true;        
    }
           
    return false;
}

function calculoGanancia(o1,o2,o3,oT)
{
 var t=0;
 
  if (o1.value >= o3.value) {
    t  = (parseFloat(o1.value))*(-1) + (parseFloat(o3.value) + parseFloat(o2.value));
  }
  if (o1.value < o3.value) {
   t  = parseFloat(o1.value) + (parseFloat(o3.value) + parseFloat(o2.value));
  }

 t=redondear(t,2)
 oT.value=t;
}

function ingresoNumeroDecimalesNeg()
{	if(window.event.keyCode != 46 && (window.event.keyCode != 44)&&
	((window.event.keyCode < 48 && window.event.keyCode != 45) || window.event.keyCode > 57 ))
	{
		window.event.keyCode = 0;
	}
}



function imprimirPagina() 
{  
    window.print();
}

function EsHora(str)
{                    
    if (str.length!=5)     
    {
        alert("Ingrese la hora en formato hh:mm");
        return 0;
    }                
    
    //00:00
    a=str.charAt(0) //<=2
    b=str.charAt(1) //<4
    c=str.charAt(2) //:
    d=str.charAt(3) //<=5
    
    if ((a==2 && b>3) || (a>2)) 
        {
            alert("El valor que ingreso como hora no corresponde, ingrese un valor entre 00 y 23");
            return 0;
        }
        
    if (d>5) 
        {
            alert("El valor que ingreso en los minutos no corresponde, ingrese un valor entre 00 y 59");
            return 0;
        }
                
    if (c!=':') 
        {
            alert("Introduzca el caracter ':' como separador");
            return 0;
        }       
    
    return 1;    
}

function CompararHoras(hora1,hora2)
{
    //Hora Inicial
    a = parseInt(hora1.charAt(0)) + parseInt(hora1.charAt(1)) + parseInt(hora1.charAt(3)) + parseInt(hora1.charAt(4));
    //Hora Final
    b = parseInt(hora2.charAt(0)) + parseInt(hora2.charAt(1)) + parseInt(hora2.charAt(3)) + parseInt(hora2.charAt(4));        
    
    if (a > b)
        {return false;}
        
    return true;
    
}

function validar(e) 
{               
    // 1
    tecla = (document.all) ? e.keyCode : e.which; // 2
    if (tecla==8) return true; // 3
    patron =/[A-Za-z\s]/; // 4
    te = String.fromCharCode(tecla); // 5
    return patron.test(te); // 6
} 
