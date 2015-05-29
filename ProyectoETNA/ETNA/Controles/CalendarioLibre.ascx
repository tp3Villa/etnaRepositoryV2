<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalendarioLibre.ascx.cs" 
    Inherits="SGCA.CalendarioLibre" %>

    <link href="../Estilos/General.css" type="text/css" rel="stylesheet" />
    <script src="../JavaScript/popCalendar.js" type="text/javascript"></script>    
       
    <script src="../JavaScript/validacion.js" type="text/javascript"></script>

<table cellspacing="3" cellpadding="0" border="0">
    <tr>
        <td>
            <input class="CajaTextoFecha" id="txtFecha" type="text" runat="server" size="6" 
                onkeypress="ingresoFecha(this)" 
                onblur="if (valida_fecha(this)==false) {alert('Fecha incorrecta'); this.value=''; this.focus(); }"/>                
        </td>
        <td>
            <img id="imgFecha" alt="Seleccionar fecha" src="../Imagenes/calendario.gif"
                runat="server" />
        </td>
        <td>            
        </td>
    </tr>
</table>

