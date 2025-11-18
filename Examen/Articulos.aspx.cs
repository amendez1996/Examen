using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;         
using System.Configuration; 


namespace Examen
{
    public partial class Articulos : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["CadenadeConexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarBodegas();
                CargarTipos();
                CargarArticulos();
            }
        }

        private void CargarBodegas()
        {
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT id, nombre FROM Bodega", con))
            {
                con.Open();
                ddlBodega.DataSource = cmd.ExecuteReader();
                ddlBodega.DataTextField = "nombre";
                ddlBodega.DataValueField = "id";
                ddlBodega.DataBind();
            }
            ddlBodega.Items.Insert(0, new ListItem("--Seleccione Bodega--", "0"));
        }

        private void CargarTipos()
        {
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT id, descripcion FROM TipoArticulo", con))
            {
                con.Open();
                ddlTipo.DataSource = cmd.ExecuteReader();
                ddlTipo.DataTextField = "descripcion";
                ddlTipo.DataValueField = "id";
                ddlTipo.DataBind();
            }
            ddlTipo.Items.Insert(0, new ListItem("--Seleccione Tipo--", "0"));
        }

        private void CargarArticulos()
        {
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT a.id, a.descripcion, a.precio, a.cantidad, b.nombre AS bodega, t.descripcion AS tipo
                  FROM Articulo a
                  LEFT JOIN Bodega b ON a.idbodega = b.id
                  LEFT JOIN TipoArticulo t ON a.idtipo = t.id", con))
            {
                con.Open();
                gvArticulos.DataSource = cmd.ExecuteReader();
                gvArticulos.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Articulo (descripcion, precio, cantidad, idbodega, idtipo) VALUES (@desc, @precio, @cant, @idbodega, @idtipo)", con))
            {
                cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@precio", string.IsNullOrEmpty(txtPrecio.Text) ? 0 : Convert.ToDecimal(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@cant", string.IsNullOrEmpty(txtCantidad.Text) ? 0 : Convert.ToInt32(txtCantidad.Text));
                cmd.Parameters.AddWithValue("@idbodega", ddlBodega.SelectedValue);
                cmd.Parameters.AddWithValue("@idtipo", ddlTipo.SelectedValue);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            ddlBodega.SelectedIndex = 0;
            ddlTipo.SelectedIndex = 0;

            CargarArticulos();
        }

        protected void gvArticulos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvArticulos.EditIndex = e.NewEditIndex;
            CargarArticulos();
        }

        protected void gvArticulos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvArticulos.EditIndex = -1;
            CargarArticulos();
        }

        protected void gvArticulos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvArticulos.DataKeys[e.RowIndex].Value);
            string descripcion = ((TextBox)gvArticulos.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            decimal precio = Convert.ToDecimal(((TextBox)gvArticulos.Rows[e.RowIndex].Cells[2].Controls[0]).Text);
            int cantidad = Convert.ToInt32(((TextBox)gvArticulos.Rows[e.RowIndex].Cells[3].Controls[0]).Text);

            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Articulo SET descripcion=@desc, precio=@precio, cantidad=@cant WHERE id=@id", con))
            {
                cmd.Parameters.AddWithValue("@desc", descripcion);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@cant", cantidad);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            gvArticulos.EditIndex = -1;
            CargarArticulos();
        }

        protected void gvArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvArticulos.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Articulo WHERE id=@id", con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            CargarArticulos();
        }
    }
}
