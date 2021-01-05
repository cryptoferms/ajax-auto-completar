<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exibir.aspx.cs" Inherits="ajax_autocomplete.Exibir" %>
<%@ OutputCache Duration= '5' VaryByParam="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Select 2</title>
    <script src="Scripts/jquery-3.5.1.min.js"></script>
    <script src="Scripts/select2.min.js"></script>
    <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/> 
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.13/css/select2.min.css" />
    <script type="text/javascript">
        //Método antigo usando autocomplete
        $(document).ready(function () {
            $('#txtNome').autocomplete({
                source:'NomeHandler.ashx',
            });
        });
        //chamada da função na dropdown list SELECT 2
        $(document).ready(function () {
            $(".ddl").select2({
            /*Caso precise esconder a barra de pesquisa use o código abaixo, propriedade para esconder a barra de busca da dropdownlist
                minimumResultsForSearch: -1
            */
            });
        });
    </script>
    <style type="text/css">
        .ddl {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <%--<div>
            <h1>Auto completar usando ajax jquery</h1>
            <hr />
            Nome das Lojas : 
            <asp:TextBox ID="txtNome" runat="server" Width="155px"  ></asp:TextBox>
            <hr />
        </div>--%>
        <div>
            <h2>Select2 usando Select2 para busca e dropdownlist</h2>
            <hr />
            Nome clientes:
            <asp:DropDownList OnLoad="Page_Load" ID="DDLNome" runat="server" CssClass="ddl" AutoPostBack="true" OnSelectedIndexChanged="DDLNome_SelectedIndexChanged" DataTextField="Nome" Height="21px" Width="325px" DataValueField="Id"></asp:DropDownList>
        </div>
      <%--  <p>
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </p>--%>
    </form>
</body>
</html>
