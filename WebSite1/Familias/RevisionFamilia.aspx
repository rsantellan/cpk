<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RevisionFamilia.aspx.cs"
    Inherits="Familias_InsertarFamilia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Revision Familia</title>

    <script src="../js/prototype.js" type="text/javascript"></script>
    <link rel="Stylesheet" type="text/css" href="../css/1.css" />
    <link rel="Stylesheet" type="text/css" href="../css/Navigation.css" />
    <link rel="Stylesheet" type="text/css" href="../css/Observations.css" />
    <link rel="Stylesheet" type="text/css" href="../css/Botones.css" />
    <link rel="Stylesheet" type="text/css" href="../css/AddFamily.css" />
</head>
<body>
    <ul id="nav">
        <li><a href="InsertarFamilia.aspx" class="linkNavegacion">Crear familia</a> </li>
        <li><a href="MantenimientoFamilias.aspx" class="linkNavegacion">Mantenimiento de familia</a></li>
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
                            <asp:Label ID="LabelFechaVigenciaDesde" runat="server" Font-Bold="True" Text="Fecha desde"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fecha de vigencia hasta:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelFechaVigenciaHasta" runat="server" Font-Bold="True" Text="Fecha hasta"></asp:Label>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nombre Familia:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelNombreFamilia" runat="server" Font-Bold="True" 
                                Text="Familia"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Grupo Familia:
                        </td>
                        <td style="width: 478px">
                            <asp:Label ID="LabelGrupo" runat="server" Font-Bold="True" Text="Grupo"></asp:Label>
                        </td>
                    </tr>
                </table>
            <div id="manejoAtributos">
            <label id="mostrarAtributos" >Servicios</label>
            <div id="listadoDeAtributos">
                <asp:GridView ID="GridViewAtributos" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Atributo" HeaderText="Atributo" />
                        <asp:HyperLinkField HeaderText="Ver" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="InsertarFamilia.aspx?id={0}" DataTextField="verAtributo"/>
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                        <asp:BoundField DataField="verAtributo" HeaderText="verAtributo" Visible="False" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
            </div>
        </div>

        <div id="ocultos">
            <asp:HiddenField ID="HiddenFieldClass" runat="server" />
            <asp:HiddenField ID="HiddenFieldVersion" runat="server" />
        </div>
        <div id="divReglas" class="center">
            <h1>Aca van el listado de reglas</h1>
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
            &nbsp;
            <asp:Button ID="ButtonSalvar" runat="server" Text="Confirmar" class="btn" 
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
