<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TarifaProducto.aspx.cs"
    Inherits="Familias_InsertarFamilia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingresar Tarifa Producto</title>

    <script src="../js/observations.js" type="text/javascript"></script>
    <script src="../js/prototype.js" type="text/javascript"></script>
    <script src="../js/budgetProduct.js" type="text/javascript"></script>
    <link rel="Stylesheet" type="text/css" href="../css/1.css" />
    <link rel="Stylesheet" type="text/css" href="../css/Navigation.css" />
    <link rel="Stylesheet" type="text/css" href="../css/Observations.css" />
    <link rel="Stylesheet" type="text/css" href="../css/Botones.css" />
    <link rel="Stylesheet" type="text/css" href="../css/addProductValue.css" />
</head>
<body onunload="leave()">
    <ul id="nav">
        <li><a href="InsertarProducto.aspx" class="linkNavegacion">Crear Producto</a> </li>
        <li><a href="MantenimientoProductos.aspx" class="linkNavegacion">Mantenimiento de producto</a></li>
    </ul>
    <div id="container">
        <form id="form1" runat="server">
        <div>
            <div id="InformacionBasica" class="center">
                <label id="tituloInfoBasica">
                    Datos generales de producto</label>
                <table>
                    <tr>
                        <td>
                            Producto:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelProducto" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                            <asp:HiddenField ID="HiddenFieldIdentificador" runat="server" />
                            <asp:HiddenField ID="HiddenFieldId" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Autor:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelAutor" runat="server" Font-Bold="True" Text="Autor"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Version:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelVersion" runat="server" Font-Bold="True" Text="Version"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fecha de creacion:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelFechaCreacion" runat="server" Font-Bold="True" Text="Fecha de creacion"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fecha de vigencia desde:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelVigenciaDesde" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fecha de vigencia hasta:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelVigenciaHasta" runat="server" Text="Label"></asp:Label>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nombre Producto:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelNombreProducto" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descripcion:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelDescripcionProducto" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Familia:
                        </td>
                        <td>
                            <asp:Label ID="LabelFamiliaProducto" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Grupo Familia:
                        </td>
                        <td>
                            &nbsp;<asp:Label ID="LabelGrupoFamiliaProducto" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Condicionado:
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListCondicionado" runat="server" 
                                DataSourceID="SqlDataSourceCondicionado" DataTextField="Nombre" 
                                DataValueField="Nombre" Enabled="False">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourceCondicionado" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:formFlowsConnectionString %>" 
                                SelectCommand="SELECT DISTINCT [Nombre] FROM [Condicionado]">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Coverturas:
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <th>Cobertura</th>
                                    <th>Incluir</th>
                                </tr> 
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelCobertura1" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxCobertura1" runat="server" Enabled="False" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelCobertura2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxCobertura2" runat="server" Enabled="False" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelCobertura3" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxCobertura3" runat="server" Enabled="False" />
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelCobertura4" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxCobertura4" runat="server" Enabled="False" />
                                    </td>    
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:Label ID="LabelCargaTarifas" runat="server" Text="Modo de carga de tarifas"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelCargaTarifasModo" runat="server" Text="Manual"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:Label ID="LabelFormulario" runat="server" Text="Carga"></asp:Label>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <th>Edad</th>
                                    <th>Sexo</th>
                                    <th>Tarifa</th>
                                </tr>
                                <tr>
                                    <td>18-40</td>
                                    <td>F</td>
                                    <td><asp:TextBox ID="TextBoxFemeninoAdulto" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>41-70</td>
                                    <td>F</td>
                                    <td><asp:TextBox ID="TextBoxFemeninoAdultoMayor" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>18-40</td>
                                    <td>M</td>
                                    <td><asp:TextBox ID="TextBoxMasculinoAdulto" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>41-70</td>
                                    <td>F</td>
                                    <td><asp:TextBox ID="TextBoxMasculinoAdultoMayor" runat="server"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            <div id="manejoAtributos">
            <label id="mostrarAtributos" >Servicios</label>
            <div id="listadoDeAtributos">
                <h1>Aca van el listado de atributos</h1>
            </div>
        </div>
            </div>
        </div>

        <div id="ocultos">
            <asp:HiddenField ID="HiddenFieldClass" runat="server" />
            <asp:HiddenField ID="HiddenFieldVersion" runat="server" />
        </div>
        <div id="divReglas">
        <h1>Esto es el div de reglas</h1>
        </div>
        <div id="divResolucion" class="center">
             
            <asp:Label ID="LabelResolucion" runat="server" Font-Bold="True" 
                Text="*Resolucion"></asp:Label>
            <asp:DropDownList ID="DropDownListResolution" runat="server">
                <asp:ListItem Value="Aceptado">Aprueba</asp:ListItem>
                <asp:ListItem Value="Rechazado">Requiere modificación</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="LabelObservacion" runat="server" Text="*Observacion"></asp:Label>
            <asp:TextBox ID="TextBoxObservacion" runat="server" Height="88px" 
                TextMode="MultiLine" Width="274px"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorObservacion" 
                runat="server" ControlToValidate="TextBoxObservacion" 
                ErrorMessage="Necesita ingresar una observacion"></asp:RequiredFieldValidator>
             
        </div>
        
        <div id="navegacion" class="center cssNavegacion">
            <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" CausesValidation="False"
                class="btn" onclick="ButtonCancelar_Click" />
            <input id="ButtonAtras" type="button" value="<<Atras<<" onclick="goBack()" class="btn" />
            <input id="ButtonAdelante" type="button" value=">>Adelante>>" onclick="goForward()"
                class="btn" />
            <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" class="btn" 
                onclick="ButtonSalvar_Click" />
        </div>
        </form>
    </div>
    <div id="footer">
        <p class="validate">
        </p>
        <p>
            © Develop by Maith Software.</p>
    </div>
</body>
</html>
