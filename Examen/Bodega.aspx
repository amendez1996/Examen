<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bodega.aspx.cs" Inherits="Examen.Bodega" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Catalogo de Bodega</h2>
       </div>
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>

        </div>
        <div>
            <label> codigo: </label>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Bodega"/>
        </div>
    </form>
</body>
</html>
