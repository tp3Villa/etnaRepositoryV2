<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2/AppMaster.Master" AutoEventWireup="true" CodeBehind="WebLogin2aspx.aspx.cs" Inherits="ETNA.SGI.WebSite.WebLogin2aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">
                                    <br />
                                    <br />
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/BatETNA3.gif" />
                                    <br />
                                    <br />
                                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="#CC0000" 
                                        Text="Label"></asp:Label>
                                    <br />
                                    <br />
                                </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%-- Left sidebar content placeholder. Again the 
								individual boxes are created by using a <div> and 
								assigning a class to it: 'sidebarcontainer'. 
								Follow the structure of the sample content below:
								
								<div class="sidebarcontainer">
									<h4>Headline</h4>
									<p>Content</p>
								</div>								
								--%>
								<div class="sidebarcontainer" style="width: 123px">
									<h4>
                                        <asp:Login ID="Login1" runat="server" BackColor="#efefef" BorderColor="#efefef" BorderPadding="4"
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333"
                Height="153px" TextLayout="TextOnTop" Width="123px">
                <TextBoxStyle Font-Size="0.8em" />
                <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px"
                    Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                <LayoutTemplate>
                    <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" style="width: 123px; height: 153px">
                                    <tr>
                                        <td align="center" style="font-weight: bold; font-size: 0.9em; color: white; height: 17px;
                                            background-color: #990000">
                                            Iniciar sesión</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">usuario:</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 27px">
                                            <asp:TextBox ID="UserName" runat="server" Font-Size="9pt" Height="15px" Width="104px"></asp:TextBox>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" Font-Size="9pt" Height="14px" TextMode="Password"
                                                Width="103px"></asp:TextBox>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="LoginButton" runat="server" BackColor="White" BorderColor="#CC9966"
                                                BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="Verdana"
                                                Font-Size="0.8em" ForeColor="#990000" OnClick="LoginButton_Click" Text="Inicio de sesión"
                                                ValidationGroup="ctl00$Login1" style="height: 18px" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="lblvalida" runat="server" Visible="False"></asp:Label></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            </asp:Login>
            
            
            
            
            
            
                                        </h4>										
									<br />
								</div>
</asp:Content>


