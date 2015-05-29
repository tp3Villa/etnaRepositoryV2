<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2/AppMenu2.Master" AutoEventWireup="true" CodeBehind="WebNewSolicitudUtiles.aspx.cs" Inherits="ETNA.SGI.WebSite.PaginasWeb.WebNewSolicitudUtiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<script language ="javascript" type="text/jscript">
    closingvar = true
    window.onbeforeunload = exitcheck;
    function exitcheck() {
        ///control de cerrar la ventana///
        if (closingvar == true) {
            exitcheck = false
            //return "si decide continuar,abandonará la página pudiendo perder los cambios si no ha grabado ¡¡¡";  
            //window.opener.location=window.opener.location;    
        }
    }
    </script> 


    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Localize ID="Localize1" runat="server"></asp:Localize>
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
        BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" 
        Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" 
        TitleFormat="Month" Width="400px">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" 
            ForeColor="#333333" Height="10pt" />
        <DayStyle Width="14%" />
        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" 
            Font-Size="8pt" ForeColor="#333333" Width="1%" />
        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" 
            ForeColor="White" Height="14pt" />
        <TodayDayStyle BackColor="#CCCC99" />
    </asp:Calendar>
</asp:Content>
