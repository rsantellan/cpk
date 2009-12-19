<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Atributos.aspx.cs" Inherits="Atributos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls" TagPrefix="asp"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crear atributo</title>
    <style type="text/css">
        .navegacion
        {
            margin-left: auto;
            margin-right: auto;
            width: 30%;
            background-color: #00FFCC;
            text-align: center;
        }
        .linkNavegacion
        {
        	font-size:1.2em;
        }
        .center
        {
        	margin: auto;
        	width: 640px;
        	height: 480px;
        }
    </style>
</head>
<body>
    <div class="navegacion">
        <a href="Atributos.aspx" class="linkNavegacion">Crear atributo</a> 
        <a href="MantenimientoAtributos.aspx" class="linkNavegacion">Mantenimiento de atributos</a>
    </div>
    
    <form id="form1" runat="server">
    <div id ="InformacionBasica" class="center">
    <table>
    <tr>
        <td>Identificador: </td>
        <td style="width: 478px">
            <asp:Label ID="LabelIdentificador" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>Autor: </td>
        <td style="width: 478px"><asp:Label ID="LabelAutor" runat="server" Font-Bold="True" Text="Autor"></asp:Label></td>
    </tr>
    <tr>
        <td>Version: </td>
        <td style="width: 478px"><asp:Label ID="LabelVersion" runat="server" Font-Bold="True" Text="Version"></asp:Label>
        </td>
    </tr>
        <tr>
        <td>Fecha de creacion: </td>
        <td style="width: 478px"><asp:Label ID="LabelFechaCreacion" runat="server" Font-Bold="True" Text="Fecha de creacion"></asp:Label></td>
    </tr>
    <tr>
        <td>Fecha de vigencia desde: </td>
        <td style="width: 478px">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:TextBox ID="TextCalendarDesde" runat="server"></asp:TextBox>
            <cc1:CalendarExtender
                ID="CalendarExtenderDesde" runat="server" TargetControlID="TextCalendarDesde">
            </cc1:CalendarExtender>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCalendarDesde" 
                runat="server" ControlToValidate="TextCalendarDesde" 
                ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Fecha de vigencia hasta: </td>
        <td style="width: 478px">
            <asp:TextBox ID="TextBoxCalendarHasta" runat="server"></asp:TextBox>
            <cc1:CalendarExtender
                ID="CalendarExtenderHasta" runat="server" TargetControlID="TextBoxCalendarHasta">
            </cc1:CalendarExtender>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Campo requerido" ControlToValidate="TextBoxCalendarHasta"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator2" runat="server" 
                ControlToValidate="TextBoxCalendarHasta" 
                ErrorMessage="La fecha hasta tiene que ser mayor que la fecha desde" 
                MaximumValue="2"></asp:RangeValidator>
        </td>
    </tr>
    <tr>
        <td>Nombre: </td>
        <td style="width: 478px"><asp:TextBox ID="TextBoxNombre" runat="server" Width="330px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="TextBoxNombre" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="height: 131px">Descripcion: </td>
        <td style="width: 478px; height: 131px"><asp:TextBox ID="TextBoxDescripcion" runat="server" Height="120px" Rows="5" TextMode="MultiLine" Width="332px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TextBoxDescripcion" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Es modificable: </td>
        <td style="width: 478px;">
            &nbsp;<asp:CheckBox ID="CheckBoxModificable" runat="server" />
        </td>
    </tr>
</table>
    </div>
    <div id="dinamico1">
        <div  style="height:auto"; margin: 0">
            <div style="margin: auto; width: 640px; height: 480px"> 
            <asp:Silverlight ID="Xaml1" runat="server" Source="~/ClientBin/SilverlightApplication2.xap" MinimumVersion="2.0.31005.0" Width="100%" Height="100%" />
        </div>
    </div>    
    </div>
    <div id="dinamico2">
        <h1>Dinamico 2</h1>
    </div>
    <div id="navegacion" class="center">
        <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" />
        <input id="ButtonAtras" type="button" value="<<Atras<<" onclick="goBack()" />
        <input id="ButtonAdelante" type="button" value=">>Adelante>>" onclick="goForward()" />
        <asp:Button ID="ButtonSalvar" runat="server" onclick="Button1_Click" Text="Salvar" />
    </div>

    
<script type="text/javascript">
    var place = 0;
    function goForward(){
        switch(place){
            case 0:
                place++;
                hideStuff('InformacionBasica');
                showStuff('dinamico1');
                break;
            case 1:
                place++;
                hideStuff('dinamico1');
                showStuff('dinamico2');
                showStuff('ButtonSalvar');
                hideStuff('ButtonAdelante');
                break;
        }
    }
    function goBack(){
        switch(place){
            case 1:
                showStuff('InformacionBasica');
                break;
            case 2:
                place--;
                hideStuff('dinamico2');
                showStuff('dinamico1');
                hideStuff('ButtonSalvar');
                showStuff('ButtonAdelante');
                break;
        }
    }
    window.onload = loadEvents;
    function loadEvents(){
        hideStuff('ButtonSalvar');
        hideStuff('dinamico1');
        hideStuff('dinamico2');
    }

    function getId(){
        return id;
    }
    
    
</script>

<script type="text/javascript">
	function showStuff(id) {
		document.getElementById(id).style.display = 'block';
	}
	function hideStuff(id) {
		document.getElementById(id).style.display = 'none';
	}
</script>
    </form>
</body>
</html>
