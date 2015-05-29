<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ETNA.Seguridad.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ETNA - Sistema Integrado</title>
    <link href="../Estilos/General.css" type="text/css" rel="stylesheet"/>
    <link href="../Estilos/HMIS_StyleSheet.css" type="text/css" rel="stylesheet"/>        
           
   <%-- <script language="javascript" type="text/javascript">
        
        color de fondo anterior: <body style="background-color: #ecf0f5; height: 95%"> 
              
    </script>    --%>
    
        <script language="JavaScript" type="text/javascript" >
            if (history.forward(1)){location.replace(history.forward(1))} 
        </script>
    
    
</head>
<body style="background-color: #afc5de; height: 95%">
    <form id="form1" runat="server" target="_self" defaultfocus="txtIdUsuario">
        <table style="width: 100%; height: 100%" cellspacing="0" cellpadding="0">
            <tr>
                <td align="center" style="width: 85%; height: 100%">
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <%--<img src="../Imagenes/cabecera.jpg" width="765" height="94" alt="" />--%>
                                <%--<img src="../Imagenes/banner.jpg" width="765" height="94" alt="" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td background="../Imagenes/gebrok1.jpg" valign="bottom" style="height: 129px" width="765">
                                <table width="80%" border="0">
                                    <tr>
                                        <td width="55%" style="height: 21px">
                                        </td>
                                        <td align="center" style="height: 21px">
                                            <asp:Label ID="lblError" runat="server" CssClass="Etiqueta" ForeColor="Red" Font-Names="Arial"
                                                Font-Size="11px">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    
                    <table width="765" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td style="height: 200px; width: 450px">                                
                                <%--<img src="../Imagenes/imagen_index.jpg" width="350" height="151" alt="" />--%>                                
                                <img src="../Imagenes/login2.jpg" width="450px" height="200" alt="" />
                            </td>
                            <td valign="bottom" background="../Imagenes/bkg2.jpg" style="height: 151px">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                        </td>
                                        <td class="Etiqueta">
                                            Usuario:</td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIdUsuario" Width="90%" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvIdUsuario" runat="server" 
                                                ErrorMessage="(*)" ControlToValidate="txtIdUsuario"
                                                CssClass="Validacion">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10">
                                        </td>
                                        <td width="80" height="10">
                                        </td>
                                        <td width="10" height="10">
                                        </td>
                                        <td height="10">
                                        </td>
                                        <td width="30" height="10">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td class="Etiqueta">
                                            Clave:</td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtClave" Width="90%" runat="server" TextMode="Password"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvClave" runat="server" ErrorMessage="(*)" ControlToValidate="txtclave"
                                                CssClass="Validacion"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10">
                                        </td>
                                        <td width="80" height="10">
                                        </td>
                                        <td width="10" height="10">
                                        </td>
                                        <td height="10">
                                        </td>
                                        <td width="30" height="10">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:ImageButton ID="ibtnIngresar" runat="server" 
                                                ImageUrl="../Imagenes/entrar.gif" OnClick="ibtnIngresar_Click">
                                            </asp:ImageButton></td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <td width="86" style="height: 151px">
                                    <%--<img src="../Imagenes/gebrok3.jpg" width="86" height="151" alt="" />--%>
                                    &nbsp;
                                </td>
                        </tr>
                    </table>
                    <table width="765" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <%--<img src="../Imagenes/gebrok4.jpg" width="765" height="68" alt="" />--%>
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>       
    </form>
</body>
</html>
