<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Select2Clientes.aspx.cs" Inherits="ajax_autocomplete.Select2Clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select2 dos clientes</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="Scripts/select2.js"></script>
    <script src="Scripts/select2.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#DDLCliente").select2({
                placeholder: "Selecionar Lojas",
                $ajax: {
                    url: 'ClientesService.asmx/Getallclientes',
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    data: '{}',
                    success: function (data) {
                        var clientesDDL = $('#DDLCliente');
                        clientesDDL.empty();
                    },
                },
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Usando Select 2 em uma DropDownList</h1>
        </div>
        <div>
            <hr />
            Nome clientes:
            <asp:DropDownList ID="DDLCliente" runat="server" Height="36px" Width="225px">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>


<%-- //$(document).ready(function () {
        //    $.ajax({
        //        type: "POST",
        //        contentType: 'application/json; charset=utf-8',
        //        url: 'ClientesService.asmx/GetallClientes',
        //        data: "{}",
        //        dataType: "json",
        //        success: function (result) {
        //            $('#DDLCliente').empty();
        //            $('#DDLCliente').append("<option value='0'>--Select--</option>");
        //            $.each(result.d, function (key, value) {
        //                $('#DDLCliente').append($("<option></option>").val(value.Nome));
        //            });
        //        },
        //        error: function ajaxError(result) {
        //            alert(result.status + ' : ' + result.statusText);
        //        }

        //    });
        //});--%>