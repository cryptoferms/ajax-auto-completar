<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exibir.aspx.cs" Inherits="ajax_autocomplete.Exibir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
    <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtNome').autocomplete({
                source: 'NomeHandler.ashx'
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> Auto completar usando ajax jquery</h1>
            <hr />
            Nome das Lojas : 
            <asp:TextBox ID="txtNome" runat="server" Width="155px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
