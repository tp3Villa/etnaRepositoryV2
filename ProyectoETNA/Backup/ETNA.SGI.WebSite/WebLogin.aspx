<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebLogin.aspx.cs" Inherits="ETNA.SGI.WebSite.WebLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
</head>

<body>

    <form id="form1" runat="server">
        <table  style="width: 65%; background-color:#FFFFFF;"  cellpadding="0" cellspacing="0">
            <tr  style="background:#1B3477">
                <td colspan="2">
                    <asp:Image ID="Image1" runat="server" Height="61px" Width="25%" ImageUrl="~/Imagenes/BatETNA.jpg"/>
                    <asp:Image ID="Image2" runat="server" Height="61px" Width="74%" ImageUrl="~/Imagenes/4x4.jpg"/>
               </td>
            </tr>
            <tr>
            <td colspan ="2" style="height: 15px">
            </td>
            </tr>
            <tr>
            <td colspan ="2" style="height: 15px">
            </td>
            </tr>
             <tr>
                <td colspan="2" align="left">  
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <img alt="" src="Imagenes/accesar_cuenta.jpg" />
                </td>
            </tr>
            <tr>
            <td colspan ="2">
            </td>
            </tr>
                <tr style="background:#E2E2E2">
                    <td colspan="2"  align="center" style="height: 29px">
                        <span style="font-size: 8pt; font-family: Helvetica">Para poder ingresar al sistema ingrese su cuenta y<br /> contraseña.</span>
                    </td>
                </tr>
                <tr style="background:#E2E2E2">
                <td colspan ="2" style="height: 15px">
                </td>
                </tr>
              <tr align="right" style="background:#E2E2E2">
                    <td style="height: 22px">
                        <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Italic="False" ForeColor="DarkSlateBlue" Text="Usuario:   " Font-Size="Medium"></asp:Label>
                        <asp:TextBox ID="txtusu" runat="server" ></asp:TextBox>
                   </td>
                   <td style="width:33%">
                   </td>
              </tr>
                <tr style="background:#E2E2E2">
                <td colspan ="2" style="height: 15px">
                </td>
                </tr>
                
             <tr style="background:#E2E2E2">
                 <td style="width:50%" align="right" >
                    <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Italic="False" ForeColor="DarkSlateBlue" Text="Password:" Font-Size="Medium"></asp:Label>
                    <asp:TextBox ID="txtpas" runat="server"  TextMode="Password" Width="148px"></asp:TextBox> 
                    </td>
                   <td align="left"> 
                   <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/ingresar.jpg" OnClick="btnAceptar_Click" />
                   </td>
                </tr>
                <tr style="background:#E2E2E2">
                <td colspan ="2" style="height: 15px">
                </td>
                </tr>
            <tr>
            <td colspan ="2" style="height: 15px">
            </td>
            </tr>
            <tr>
            <td colspan ="2" style="height: 15px">
            </td>
            </tr>
            <tr>
            <td colspan ="2" style="height: 15px">
            </td>
            </tr>
            <tr>
            <td colspan ="2" style="height: 15px">
            </td>
            </tr>
            <tr>
            <td colspan ="2" style="height: 15px">
            </td>
            </tr>
            <tr>
            <td colspan ="2" style="height: 15px">
            </td>
            </tr>
            <tr align="right">
                <td colspan="2" style="height: 148px">
                   <asp:Image ID="Image3" runat="server" Height="156px" ImageUrl="~/Imagenes/fondocam.jpg"/>
                </td>
            </tr>
            <tr>
                <td align="center" style="background-color:#1B3477; height: 20px  ;" colspan="2">
                    <span style="font-size: 8pt; color: #e9e9e9; font-family: Arial;">Copyright Lima Caucho S.A. 2008 - All Rights Reserved</span>
                </td>
            </tr>
            
        </table>
    </form>

</body>
</html>
