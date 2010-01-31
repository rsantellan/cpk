<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoFamiliaVersionado.aspx.cs"
    Inherits="MantenimientoAtributos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Versionado de familia</title>
    <link rel="Stylesheet" type="text/css" href="../css/Navigation.css" />
    <link rel="Stylesheet" type="text/css" href="../css/mantainAttributeVersion.css" />
    <link rel="Stylesheet" type="text/css" href="../css/1.css" />
</head>
<body>
<ul id="nav">
        <li><a href="InsertarFamilia.aspx" class="linkNavegacion">Crear familia</a> </li>
        <li><a href="MantenimientoFamilias.aspx" class="linkNavegacion">Mantenimiento de familia</a></li>
        <li><a href="ProcesoDefinicionFamilias.aspx" class="linkNavegacion">Proceso de definición</a></li>
    </ul>
    
    <div id="container"> 
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManagerAjax" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="consulta">
                <div>
                    <asp:Label ID="LabelTitulo" runat="server" Font-Bold="True" Font-Size="Large" 
                        Text="Versionado de familias"></asp:Label>
                </div>
                <table style="width: 100%;">
                    <tr>
                        <td class="style2">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="LabelAutor" runat="server" Font-Bold="True" Text="Autor"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListAutores" runat="server" 
                                DataSourceID="SqlDataSourceAutores" DataTextField="Autor" 
                                DataValueField="Autor">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourceAutores" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:formFlowsConnectionStringFamily %>" 
                                SelectCommand="SELECT DISTINCT [Autor] FROM [FamiliaInformacionGeneral]">
                            </asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:Label ID="LabelVersion" runat="server" Font-Bold="True" 
                                Text="Version"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxVersion" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                        </td>
                        <td class="style1">
                            <asp:Label ID="LabelVigenciaInicioDesde" runat="server" Font-Bold="True" 
                                Text="Fecha de Vigencia inicio desde"></asp:Label>
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="TextBoxVigenciaDesde" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="TextBoxVigenciaInicio_CalendarExtender" 
                                runat="server" Enabled="True" TargetControlID="TextBoxVigenciaDesde">
                            </cc1:CalendarExtender>
                        </td>
                        <td class="style1">
                            <asp:Label ID="LabelVigenciaInicioHasta" runat="server" Font-Bold="True" 
                                Text="Fecha de Vigencia inicio hasta"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxVigenciaHasta" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtenderVigenciaHasta" runat="server" 
                                Enabled="True" TargetControlID="TextBoxVigenciaHasta">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                            <asp:Label ID="LabelEstado" runat="server" Font-Bold="True" Text="Estado"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                            <asp:DropDownList ID="DropDownListEstado" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="0">En curso</asp:ListItem>
                                <asp:ListItem Value="1">Rechazado</asp:ListItem>
                                <asp:ListItem Value="2">Aceptado</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <div>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="Filtros adicionales"></asp:Label>
                    <table style="width: 100%;" border="0">
                        <tr>
                            <td class="style2">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="LabelCreacionDesde" runat="server" Font-Bold="True" 
                                    Text="Fecha creacion desde"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxCreacionDesde" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtenderCreacionDesde" runat="server" 
                                    Enabled="True" TargetControlID="TextBoxCreacionDesde">
                                </cc1:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LabelCreacionHasta" runat="server" Font-Bold="True" 
                                    Text="Fecha creacion hasta"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxCreacionHasta" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtenderCreacionHasta" runat="server" 
                                    Enabled="True" TargetControlID="TextBoxCreacionHasta">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                            </td>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        
                    </table>
                    <br />
                    <br />
                    <asp:Button ID="ButtonBusqueda" runat="server" Text="Buscar" CssClass="buttonSearch btn"
                        OnClick="ButtonBusqueda_Click" />
                </div>
                <div>
                    <asp:GridView ID="GridViewDatos" runat="server" AllowPaging="True" 
                        EnableSortingAndPagingCallbacks="True"
                        onpageindexchanging="gridViewDatos_paging" 
                        CssClass="results" AutoGenerateColumns="False">
                        <%--<Columns><asp:CommandField ShowSelectButton="True" SelectText="Pick" /></Columns>--%>
                        <Columns>
                            <asp:HyperLinkField HeaderText="Modificar" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Atributos.aspx?id={0}"
                                DataTextField="ModificarMostrar" />
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" 
                                                    Visible="False" />
                            <asp:BoundField DataField="ModificarMostrar" HeaderText="ModificarMostrar" 
                                Visible="False" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Fecha de creacion" HeaderText="Fecha de creacion" />
                            <asp:BoundField />
                            <asp:BoundField DataField="Fecha vigencia desde" 
                                HeaderText="Fecha vigencia desde" />
                            <asp:BoundField DataField="Fecha vigencia hasta" 
                                HeaderText="Fecha vigencia hasta" />
                            <asp:BoundField DataField="Version" HeaderText="Version" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            <asp:BoundField DataField="Vigente" HeaderText="Vigente" />
                            <asp:BoundField DataField="Autor" HeaderText="Autor" />
                            <asp:BoundField DataField="Ver" HeaderText="Ver" 
                                Visible="False" />
                            <asp:HyperLinkField HeaderText="" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="VerFamilia.aspx?id={0}" DataTextField="Ver"/>
                
                            </Columns>
                        </asp:GridView>
                </div>
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
