using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;         
using System.Configuration; 
using System.Data.SqlClient;


namespace Examen
{
    public partial class TipoArticulos : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["CadenadeConexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarTipos();
        }

        private void CargarTipos()
        {
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM TipoArticulo", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    gvTipo.DataSource = rdr;
                    gvTipo.DataBind();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO TipoArticulo (descripcion) VALUES (@desc)", con))
            {
                cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            txtDescripcion.Text = "";
            CargarTipos();
        }

        protected void gvTipo_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvTipo.EditIndex = e.NewEditIndex;
            CargarTipos();
        }

        protected void gvTipo_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvTipo.EditIndex = -1;
            CargarTipos();
        }

        protected void gvTipo_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvTipo.DataKeys[e.RowIndex].Value);
            string descripcion = ((System.Web.UI.WebControls.TextBox)gvTipo.Rows[e.RowIndex].Cells[1].Controls[0]).Text;

            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("UPDATE TipoArticulo SET descripcion=@desc WHERE id=@id", con))
            {
                cmd.Parameters.AddWithValue("@desc", descripcion);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            gvTipo.EditIndex = -1;
            CargarTipos();
        }

        protected void gvTipo_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvTipo.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM TipoArticulo WHERE id=@id", con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            CargarTipos();
        }
    }
}