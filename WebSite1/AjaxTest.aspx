<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjaxTest.aspx.cs" Inherits="AjaxTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    </div>
    <asp:TextBox ID="TextBoxComun" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonComun" runat="server" Text="Comun" 
        onclick="ButtonComun_Click" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBoxComun" ErrorMessage="RequiredFieldValidator">Error</asp:RequiredFieldValidator>
    <br />
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:TextBox ID="TextBoxAjax" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonAjax" runat="server" Text="Comun" 
            onclick="ButtonAjax_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    
    </form>
</body>
</html>
