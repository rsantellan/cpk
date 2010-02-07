<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertarFamilia.aspx.cs"
    Inherits="Familias_InsertarFamilia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingresar Familia</title>

    <script src="../js/observations.js" type="text/javascript"></script>
    <script src="../js/prototype.js" type="text/javascript"></script>
    <script src="../js/addFamily.js" type="text/javascript"></script>
    <link rel="Stylesheet" type="text/css" href="../css/1.css" />
    <link rel="Stylesheet" type="text/css" href="../css/Navigation.css" />
    <link rel="Stylesheet" type="text/css" href="../css/Observations.css" />
    <link rel="Stylesheet" type="text/css" href="../css/Botones.css" />
    <link rel="Stylesheet" type="text/css" href="../css/AddFamily.css" />
</head>
<body onunload="leave()">
    <ul id="nav">
        <li><a href="InsertarFamilia.aspx" class="linkNavegacion">Crear familia</a> </li>
        <li><a href="MantenimientoFamilias.aspx" class="linkNavegacion">Mantenimiento de familia</a></li>
        <li><a href="ProcesoDefinicionFamilias.aspx" class="linkNavegacion">Proceso de definición</a></li>
    </ul>
    <div id="container">
        <form id="form1" runat="server">
        <div>
            <div id="InformacionBasica" class="center">
                <label id="tituloInfoBasica">
                    Datos generales de familia</label>
                <table>
                    <tr>
                        <td>
                            Familia:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelFamilia" runat="server" Font-Bold="True" Text="Label"></asp:Label>
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
                            <asp:ScriptManager ID="ScriptManager1" runat="server" 
                                EnableScriptGlobalization="True">
                            </asp:ScriptManager>
                            <asp:TextBox ID="TextCalendarDesde" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="TextCalendarDesde_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="TextCalendarDesde">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCalendarDesde" runat="server"
                                ControlToValidate="TextCalendarDesde" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fecha de vigencia hasta:
                        </td>
                        <td style="width: 478px">
                            <asp:TextBox ID="TextBoxCalendarHasta" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="TextBoxCalendarHasta_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="TextBoxCalendarHasta">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo requerido"
                                ControlToValidate="TextBoxCalendarHasta"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TextBoxCalendarHasta"
                                ErrorMessage="La fecha hasta tiene que ser mayor que la fecha desde" 
                                MaximumValue="2" EnableClientScript="False" Enabled="False"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nombre Familia:
                        </td>
                        <td style="width: 478px">
                            <asp:TextBox ID="TextBoxNombre" runat="server" Width="132px" Height="28px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxNombre"
                                ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Grupo Familia:
                        </td>
                        <td style="width: 478px">
                            <asp:DropDownList ID="DropDownListGruposFamilia" runat="server" 
                                Font-Bold="False" Font-Size="Large" Height="28px" Width="132px">
                                <asp:ListItem>Universal life</asp:ListItem>
                                <asp:ListItem Value="Tradicional">Tradicional</asp:ListItem>
                                <asp:ListItem>Salud</asp:ListItem>
                                <asp:ListItem>Rentas</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            <div id="manejoAtributos">
            <label id="mostrarAtributos" >Servicios</label>
            <div id="listadoDeAtributos">
                <h1>Aca van el listado de atributos Silverlight</h1>
                <asp:Silverlight ID="Xaml2" runat="server" Source="~/ClientBin/SLAttr.xap" MinimumVersion="2.0.31005.0" Width="100%" Height="100%" />
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
        <div id="comentarios" class="divComentario">
            <label id="titulo">
                Comentarios</label>
            <br />
            <input id="agregarObservacion" type="button" value="agregar" onclick="showObservation()"
                class="btn" />
            <div id="formularioIngreso" class="formularioObservacion">
                <label id="labTarea">
                    Tarea</label>
                <input id="inputTarea" />
                <br />
                <label id="labObservacion">
                    Obsevacion</label>
                <textarea id="TextAreaObservacion" rows="2" cols="30"></textarea>
                <br />
                <input id="confirmarAgregar" type="button" value="insertar" onclick="addObservation()"
                    class="btn" />
            </div>
            <table id="observaciones" style="width: 100%;" runat="server">
                <tr>
                    <th>
                        Tarea
                    </th>
                    <th>
                        Observacion
                    </th>
                    <th>
                        Autor
                    </th>
                    <th>
                        Fecha
                    </th>
                    <th>
                    </th>
                </tr>
            </table>
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
