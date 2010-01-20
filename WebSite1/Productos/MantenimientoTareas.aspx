<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoTareas.aspx.cs" Inherits="MantenimientoAtributos" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mantenimiento de productos</title>
    <link rel="Stylesheet" type="text/css" href="../css/Navigation.css" />
    <link rel="Stylesheet" type="text/css" href="../css/mantainAttribute.css" />
    <link rel="Stylesheet" type="text/css" href="../css/1.css" />
    <script runat="server">

  void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
  {
    if(e.Row.RowType == DataControlRowType.DataRow)
    {
      e.Row.Cells[1].Text = "<i>" + e.Row.Cells[1].Text + "</i>";
    }

  }

</script>

</head>
<body>
<ul id="nav">
        <li><a href="InsertarProducto.aspx" class="linkNavegacion">Crear Producto </a>&nbsp;</li>
        <li><a href="MantenimientoProductos.aspx" class="linkNavegacion">Mantenimiento de 
            producto </a></li>
                <li><a href="InsertarTarea.aspx" class="linkNavegacion">Crear tarea</a></li>
        <li><a href="MantenimientoTareas.aspx" class="linkNavegacion">Mantenimiento de tareas</a></li>    
    </ul>
    
    <div id="container">    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManagerAjax" runat="server" 
        EnableScriptGlobalization="True" >
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="consulta">
    <div>
    
       <asp:Label ID="LabelTitulo" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Mantenimiento de familia"></asp:Label>
    </div>
    <table style="width:100%;">
        <tr>
            <td class="style2">
                
            </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Label ID="LabelTarea" runat="server" Text="Tarea" Font-Bold="True"></asp:Label>
            </td>
            <td><asp:TextBox ID="TextBoxTarea" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="LabelTaskTitulo" runat="server" Font-Bold="True" Text="Titulo"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxTaskTitulo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
            </td>
            <td class="style1">
                <asp:Label ID="LabelAutor" runat="server" Font-Bold="True" Text="Autor"></asp:Label>
             </td>
             <td class="style1">
                 <asp:DropDownList ID="DropDownListAutores" runat="server" 
                     DataSourceID="SqlDataSourceAutoresProducto" DataTextField="Autor" 
                     DataValueField="Autor">
                 </asp:DropDownList>
                 <asp:SqlDataSource ID="SqlDataSourceAutoresProducto" runat="server" 
                     ConnectionString="<%$ ConnectionStrings:formFlowsConnectionString %>" 
                     SelectCommand="SELECT DISTINCT [Autor] FROM [ProductoTareas]">
                 </asp:SqlDataSource>
            </td>
            <td class="style1">
                <asp:Label ID="LabelResponsables" runat="server" Font-Bold="True" 
                    Text="Responsables"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListResponsables" runat="server" 
                    DataSourceID="SqlDataSourceResponsables" DataTextField="Responsable" 
                    DataValueField="Responsable">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceResponsables" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:formFlowsConnectionString %>" 
                    SelectCommand="SELECT DISTINCT [Responsable] FROM [ProductoTareas]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
     <div>
         <asp:Button ID="ButtonBusqueda" runat="server" Text="Buscar" 
             CssClass="buttonSearch btn" onclick="ButtonBusqueda_Click" />
    </div>
    <div class="consulta">
        <asp:GridView ID="GridViewDatos" runat="server" AutoGenerateColumns="False" 
            EnableSortingAndPagingCallbacks="True"
            AllowPaging ="True" 
            onpageindexchanging="gridViewDatos_paging" 
            CssClass="results" >
            <Columns>
                <asp:HyperLinkField HeaderText="Modificar" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="InsertarTarea.aspx?id={0}" DataTextField="ModificarMostrar"/>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" 
                    Visible="False" />
                <asp:BoundField DataField="ModificarMostrar" HeaderText="ModificarMostrar" 
                    Visible="False" />
                <asp:BoundField DataField="Tarea" HeaderText="Tarea" />
                <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                <asp:BoundField DataField="fecha_de_creacion" HeaderText="Fecha de creacion" />
                <asp:BoundField DataField="Autor" HeaderText="Autor" />
                <asp:BoundField DataField="Responsable" HeaderText="Responsable" />
                <asp:BoundField DataField="Habilitada" HeaderText="Habilitada" />
            </Columns>
        </asp:GridView>
    </div>
    <asp:Label ID="LabelError" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Green"
                    Text="No hay datos" Visible="False" CssClass="errorMessage"></asp:Label>
    </ContentTemplate>
    
    </asp:UpdatePanel>
    </form>
        </div>
    <div id="footer">
<p class="validate">		</p>
<p>
        © Develop by Maith Software.</div>
    </body>
</html>
