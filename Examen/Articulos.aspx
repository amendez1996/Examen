<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="Examen.Articulos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Artículos</title>
    <link href="CSS/Estilo.css" rel="stylesheet" />
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        .formulario {
            margin-bottom: 20px;
        }
        input[type="text"], input[type="number"], select {
            padding: 5px;
            margin-right: 10px;
        }
        .btn {
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
            <h2>Agregar Artículo</h2>
            <asp:TextBox ID="txtDescripcion" runat="server" Placeholder="Descripción"></asp:TextBox>
            <asp:TextBox ID="txtPrecio" runat="server" Placeholder="Precio" TextMode="Number"></asp:TextBox>
            <asp:TextBox ID="txtCantidad" runat="server" Placeholder="Cantidad" TextMode="Number"></asp:TextBox>
            <asp:DropDownList ID="ddlBodega" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="ddlTipo" runat="server"></asp:DropDownList>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn" OnClick="btnAgregar_Click" />
        </div>

        <div class="gridview">
            <h2>Artículos Registrados</h2>
            <asp:GridView ID="gvArticulos" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                OnRowEditing="gvArticulos_RowEditing" OnRowUpdating="gvArticulos_RowUpdating"
                OnRowCancelingEdit="gvArticulos_RowCancelingEdit" OnRowDeleting="gvArticulos_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="bodega" HeaderText="Bodega" />
                    <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
