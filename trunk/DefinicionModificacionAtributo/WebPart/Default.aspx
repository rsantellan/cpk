<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebPart._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:WebPartManager ID="WebPartManager1" runat="server">
    </asp:WebPartManager>
    <div>
    
        <br />
        Esto es una prueba de web parts e Infopath 2007<br />
        <br />
        <table class="style1">
            <tr>
                <td>
                    <asp:WebPartZone ID="SideBarZone" runat="server" HeaderText="Barra lateral">
                    </asp:WebPartZone>
                </td>
                <td>
                    <asp:WebPartZone ID="MainZone" runat="server" HeaderText="Zona principal">
                    </asp:WebPartZone>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
