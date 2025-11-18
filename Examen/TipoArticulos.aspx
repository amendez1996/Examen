<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TipoArticulos.aspx.cs" Inherits="Examen.TipoArticulos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Tipo de Artículos</title>
    <link href="CSS/Estilo.css" rel="stylesheet" />
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        .formulario {
            margin-bottom: 20px;
        }
        input[type="text"] {
            padding: 5px;
            margin-right: 10px;
        }
        input[type="submit"], .btn {
            padding: 5px 10px;
            cursor: pointer;
        }
        .gridview {
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="formulario">
            <h2>Agregar Tipo de Artículo</h2>
            <asp:TextBox ID="txtDescripcion" runat="server" Placeholder="Descripción"></asp:TextBox>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn" />
        </div>

        <div class="gridview">
            <h2>Tipos de Artículos Registrados</h2>
            <asp:GridView ID="gvTipo" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                OnRowEditing="gvTipo_RowEditing" OnRowUpdating="gvTipo_RowUpdating"
                OnRowCancelingEdit="gvTipo_RowCancelingEdit" OnRowDeleting="gvTipo_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>