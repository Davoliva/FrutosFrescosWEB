using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WEB
{
    public partial class tipo_producto : System.Web.UI.Page
    {
        private string rut;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] != null)
            {
                rut = Request.Cookies["user"].Value;
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            cargarGrilla();
        }

        private void cargarGrilla()
        {
            DataTable _tabla = new DataTable();
            _tabla.Columns.Add("id");
            _tabla.Columns.Add("nombre");
            TipoProducto tp = new TipoProducto();

            foreach (var item in tp.getAll())
            {
                _tabla.Rows.Add(new Object[] { item.id, item.nombre });
            }


            dgv_tipo_productos.DataSource = _tabla;
            dgv_tipo_productos.DataBind();

        }

        protected void dgv_tipo_productos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "modificar")
            {
                TipoProducto tp = new TipoProducto();
                tp.id = Convert.ToDecimal(e.CommandArgument);
                tp = tp.getById();
                txtId.Text = tp.id.ToString();
                txtNombre.Text = tp.nombre;
            }
            if (e.CommandName == "eliminar")
            {
                decimal id = Convert.ToDecimal(e.CommandArgument);
                TipoProducto tp = new TipoProducto();
                tp.id = id;
                tp.delete();
                cargarGrilla();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!txtId.Text.Equals(string.Empty))
            {
                try
                {
                    TipoProducto tp = new TipoProducto();
                    tp.id = Convert.ToDecimal(txtId.Text.Trim());
                    tp.nombre = txtNombre.Text.Trim();
                    tp.update();
                    clear();
                    cargarGrilla();
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                try
                {
                    TipoProducto tp = new TipoProducto();
                    decimal ultimoid = new TipoProducto().getAll().Last().id;
                    tp.nombre = txtNombre.Text.Trim();
                    tp.id = ultimoid + 1;

                    tp.save();

                    cargarGrilla();
                    clear();

                }
                catch (Exception ex)
                {

                }
            }

        }

        private void clear()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }
    }
}