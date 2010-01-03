﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoFamilias.aspx.cs" Inherits="MantenimientoAtributos" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mantenimiento de atributos</title>
    <link rel="Stylesheet" type="text/css" href="css/Navigation.css" />
    <link rel="Stylesheet" type="text/css" href="css/mantainAttribute.css" />
    <link rel="Stylesheet" type="text/css" href="css/1.css" />
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
        <li><a href="Atributos.aspx" class="linkNavegacion">Crear atributo</a> </li>
        <li><a href="MantenimientoAtributos.aspx" class="linkNavegacion">Mantenimiento de atributos</a></li>
    </ul>
    
    <div id="container">    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManagerAjax" runat="server" >
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="consulta">
    <div>
    
       <asp:Label ID="LabelTitulo" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Mantenimiento de atributos"></asp:Label>
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
                <asp:Label ID="LabelNombre" runat="server" Text="Nombre" Font-Bold="True"></asp:Label>
            </td>
            <td><asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="LabelAutor" runat="server" Text="Autor" Font-Bold="True"></asp:Label>
            </td>
            <td>
            <asp:DropDownList ID="DropDownListAutores" runat="server" 
                    DataSourceID="SqlDataSourceAutores" DataTextField="Autor" 
                    DataValueField="Autor">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceAutores" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:formFlowsConnectionString %>" 
                    SelectCommand="SELECT DISTINCT [Autor] FROM [AtributoInformacionGeneral]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="style3">
            </td>
            <td class="style1">
                <asp:Label ID="LabelEstado" runat="server" Text="Estado" Font-Bold="True"></asp:Label>
             </td>
             <td class="style1">
                <asp:DropDownList ID="DropDownListEstado" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="1">Vigente</asp:ListItem>
                    <asp:ListItem Value="0">No vigente</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style1">
                <asp:Label ID="LabelAreaResponsable" runat="server" Text="Area responsable" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListArea" runat="server" 
                    DataSourceID="SqlDataSourceAreas" DataTextField="Nombre" 
                    DataValueField="Nombre">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceAreas" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:formFlowsConnectionString %>" 
                    SelectCommand="SELECT DISTINCT [Nombre] FROM [Areas]"></asp:SqlDataSource>
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
                <asp:Label ID="LabelVersion" runat="server" Text="Ultima Version" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxVersion" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
     <div>
    
       <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="Filtros adicionales"></asp:Label>
    <table style="width:100%;" border="0">
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
                <asp:Label ID="LabelVigenciaInicioDesde" runat="server" 
                    Text="Fecha de Vigencia inicio desde" Font-Bold="True"></asp:Label>
            </td>
            <td>
                
                <asp:TextBox ID="TextBoxVigenciaDesde" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="TextBoxVigenciaInicio_CalendarExtender" 
                    runat="server" Enabled="True" TargetControlID="TextBoxVigenciaDesde">
                </cc1:CalendarExtender>
                
            </td>
            <td>
                <asp:Label ID="LabelVigenciaInicioHasta" runat="server" Text="Fecha de Vigencia inicio hasta" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxVigenciaHasta" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtenderVigenciaHasta" 
                    runat="server" Enabled="True" TargetControlID="TextBoxVigenciaHasta">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="style3">
            </td>
            <td class="style1">
                <asp:Label ID="LabelVigenciaFinDesde" runat="server" Text="Fecha de Vigencia fin desde" Font-Bold="True"></asp:Label>
             </td>
             <td class="style1">
                <asp:TextBox ID="TextBoxVigenciaFinDesde" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtenderVigenciaFinDesde" 
                    runat="server" Enabled="True" TargetControlID="TextBoxVigenciaFinDesde">
                </cc1:CalendarExtender>
            </td>
            <td class="style1">
                <asp:Label ID="LabelVigenciaFinHasta" runat="server" Text="Fecha de Vigencia fin hasta" Font-Bold="True"></asp:Label>
            </td>
            <td>
            <asp:TextBox ID="TextBoxVigenciaFinHasta" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtenderVigenciaFinHasta" 
                    runat="server" Enabled="True" TargetControlID="TextBoxVigenciaFinHasta">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Label ID="LabelCreacionDesde" runat="server" Text="Fecha creacion desde" Font-Bold="True"></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="TextBoxCreacionDesde" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtenderCreacionDesde" 
                    runat="server" Enabled="True" TargetControlID="TextBoxCreacionDesde">
                </cc1:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="LabelCreacionHasta" runat="server" Text="Fecha creacion hasta" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxCreacionHasta" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtenderCreacionHasta" 
                    runat="server" Enabled="True" TargetControlID="TextBoxCreacionHasta">
                </cc1:CalendarExtender>
            </td>
        </tr>
    </table>
    <br />
    <br />
         <asp:Button ID="ButtonBusqueda" runat="server" Text="Buscar" 
             CssClass="buttonSearch btn" onclick="ButtonBusqueda_Click" />
    </div>
    <div class="consulta">
        <asp:GridView ID="GridViewDatos" runat="server" AutoGenerateColumns="False" 
            EnableSortingAndPagingCallbacks="True"
            AllowPaging ="true"
            PageSize = "10" 
            onpageindexchanging="gridViewDatos_paging" 
            CssClass="results" >
            <Columns>
                <asp:HyperLinkField HeaderText="Modificar" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="Atributos.aspx?id={0}" DataTextField="ModificarMostrar"/>
                <asp:HyperLinkField HeaderText="Versionado" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="MantenimientoAtributosVersionado.aspx?id={0}" DataTextField="VersionadoMostrar"/>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" 
                    Visible="False" />
                <asp:BoundField DataField="ModificarMostrar" HeaderText="ModificarMostrar" 
                    Visible="False" />
                <asp:BoundField DataField="VersionadoMostrar" HeaderText="VersionadoMostrar" 
                    Visible="False" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Pilar" HeaderText="Pilar" />
                <asp:BoundField DataField="fecha_de_creacion" HeaderText="Fecha de creacion" />
                <asp:BoundField DataField="fecha_vigencia_desde" 
                    HeaderText="Fecha vigencia desde" />
                <asp:BoundField DataField="fecha_vigencia_hasta" 
                    HeaderText="Fecha vigencia hasta" />
                <asp:BoundField DataField="Version" HeaderText="Ultima Version" />
                <asp:BoundField DataField="Area" HeaderText="Area responsable" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="Autor" HeaderText="Autor" />
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
        © Develop by Maith Software.</p>
</div>
    </body>
</html>
