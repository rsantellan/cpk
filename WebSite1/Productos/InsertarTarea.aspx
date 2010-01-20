<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertarTarea.aspx.cs" Inherits="Familias_InsertarFamilia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingresar Tarea</title>

    <script src="../js/prototype.js" type="text/javascript"></script>

    <script src="../js/addTask.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="../css/1.css" />
    <link rel="Stylesheet" type="text/css" href="../css/Navigation.css" />
    <link rel="Stylesheet" type="text/css" href="../css/Botones.css" />
    <link rel="Stylesheet" type="text/css" href="../css/addTask.css" />
</head>
<body>
    <ul id="nav">
        <li><a href="InsertarProducto.aspx" class="linkNavegacion">Crear Producto</a> </li>
        <li><a href="MantenimientoProductos.aspx" class="linkNavegacion">Mantenimiento de producto</a></li>
        <li><a href="InsertarTarea.aspx" class="linkNavegacion">Crear tarea</a></li>
        <li><a href="MantenimientoTareas.aspx" class="linkNavegacion">Mantenimiento de tareas</a></li>
    </ul>
    <div id="container">
        <form id="form1" runat="server">
        <div>
            <div id="InformacionBasica" class="center">
                <table>
                    <tr>
                        <td>
                            Tarea:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelTarea" runat="server" Font-Bold="True" Text="Label"></asp:Label>
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
                            Fecha de creacion:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelFechaCreacion" runat="server" Font-Bold="True" Text="Fecha de creacion"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Titulo:
                        </td>
                        <td style="width: 478px">
                            <asp:TextBox ID="TextBoxTitulo" runat="server" Width="132px" Height="28px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxTitulo"
                                ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descripcion:
                        </td>
                        <td style="width: 478px">
                            <asp:TextBox ID="TextBoxDescripcion" runat="server" Height="74px" 
                                TextMode="MultiLine" Width="184px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Responsable:
                        </td>
                        <td style="width: 478px">
                            <asp:DropDownList ID="DropDownListResponsable" runat="server" 
                                DataSourceID="SqlDataSourceResponsables" DataTextField="Nombre" 
                                DataValueField="Nombre">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourceResponsables" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:formFlowsConnectionString %>" 
                                SelectCommand="SELECT DISTINCT [Nombre] FROM [ACGrupos]">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Habilitada:
                        </td>
                        <td style="width: 478px">
                            <asp:CheckBox ID="CheckBoxHabilitada" runat="server" />
                        </td>
                    </tr>
                </table>
                <div id="ocultos">
                    <asp:HiddenField ID="HiddenFieldClass" runat="server" />
                    <asp:HiddenField ID="HiddenFieldVersion" runat="server" />
                </div>
            </div>
        </div>
        <div id="navegacion" class="center cssNavegacion">
            <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" CausesValidation="False"
                class="btn" OnClick="ButtonCancelar_Click" />
            &nbsp;
            <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" class="btn" OnClick="ButtonSalvar_Click" />
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
