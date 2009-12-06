<%@ Assembly Name="ReturnOfSmartPart, Version=1.3.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AtributoInformacionGeneral.ascx.cs" Inherits="AtributoInformacionGeneral" %>

<script runat="server">

</script>
<table>
    <tr>
        <td>Identificador: </td>
        <td style="width: 478px"><asp:Label ID="LabeIdentificador" runat="server" Font-Bold="True" Text="Id"></asp:Label></td>
    </tr>
    <tr>
        <td>Autor: </td>
        <td style="width: 478px"><asp:Label ID="LabelAutor" runat="server" Font-Bold="True" Text="Autor"></asp:Label></td>
    </tr>
    <tr>
        <td>Version: </td>
        <td style="width: 478px"><asp:Label ID="LabelVersion" runat="server" Font-Bold="True" Text="Version"></asp:Label></td>
    </tr>
        <tr>
        <td>Fecha de creacion: </td>
        <td style="width: 478px"><asp:Label ID="LabelFechaCreacion" runat="server" Font-Bold="True" Text="Fecha de creacion"></asp:Label></td>
    </tr>
    <tr>
        <td>Fecha de vigencia desde: </td>
        <td style="width: 478px">
            <asp:Calendar ID="CalendarDesde" runat="server" BackColor="White" BorderColor="#999999"
            CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <WeekendDayStyle BackColor="#FFFFCC" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            </asp:Calendar>
        </td>
    </tr>
    <tr>
        <td>Fecha de vigencia hasta: </td>
        <td style="width: 478px">
            <asp:Calendar ID="CalendarHasta" runat="server" BackColor="White" BorderColor="#999999"
            CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <WeekendDayStyle BackColor="#FFFFCC" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            </asp:Calendar>
        </td>
    </tr>
    <tr>
        <td>Nombre: </td>
        <td style="width: 478px"><asp:TextBox ID="TextBoxNombre" runat="server" Width="330px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="height: 131px">Descripcion: </td>
        <td style="width: 478px; height: 131px"><asp:TextBox ID="TextBoxDescripcion" runat="server" Height="120px" Rows="5" TextMode="MultiLine" Width="332px"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Es modificable: </td>
        <td style="width: 478px;">
            &nbsp;<asp:CheckBox ID="CheckBoxModificable" runat="server" /></td>
    </tr>
</table>
<br />
<asp:Button ID="ButtonGuardar" runat="server" OnClick="ButtonGuardar_Click" Text="Guardar" />