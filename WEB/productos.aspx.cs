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
    public partial class productos : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                cargarGrilla();
                cargarTipoProducto();
            }
        }

        private void cargarGrilla()
        {
            DataTable _tabla = new DataTable();
            _tabla.Columns.Add("id");
            _tabla.Columns.Add("nombre");
            _tabla.Columns.Add("cantidad");
            _tabla.Columns.Add("precio");
            _tabla.Columns.Add("tipo");
            Producto p = new Producto();

            foreach (var item in p.findByProductor(rut))
            {
                _tabla.Rows.Add(new Object[] { item.id, item.nombre, item.cantidad, item.precio, TipoProducto.getByIdStatic(item.tipo_producto).nombre });
            }


            dgv_productos.DataSource = _tabla;
            dgv_productos.DataBind();
        }

        private void cargarTipoProducto()
        {
            try
            {
                TipoProducto tp = new TipoProducto();
                foreach (var item in tp.getAll())
                {
                    ListItem li = new ListItem(item.nombre.ToString(), item.id.ToString());
                    this.ddlTipoProducto.Items.Add(li);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ddlTipoProducto.SelectedValue.Equals("-1"))
            {
                string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";

                script = string.Format(script, "Seleccione un tipo de producto");

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            else
            {
                try
                {
                    if (!txtCodigo.Text.Equals(string.Empty))
                    {
                        Producto p = new Producto();
                        p.id = Convert.ToDecimal(txtCodigo.Text.Trim());
                        p.productor = rut;
                        p.nombre = txtNombre.Text.Trim();
                        p.cantidad = Convert.ToDecimal(txtCantidad.Text.Trim());
                        p.precio = Convert.ToDecimal(txtPrecio.Text.Trim());
                        p.tipo_producto = Convert.ToDecimal(ddlTipoProducto.SelectedValue);
                        p.descripcion = txtDescripcion.Text.Trim();
                        p.update();
                        string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";

                        script = string.Format(script, "Producto modificado con exito");

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        clear();
                        cargarGrilla();
                    }
                    else
                    {
                        Producto p = new Producto();
                        p.id = Producto.getLastId();
                        p.productor = rut;
                        p.nombre = txtNombre.Text.Trim();
                        p.cantidad = Convert.ToDecimal(txtCantidad.Text.Trim());
                        p.precio = Convert.ToDecimal(txtPrecio.Text.Trim());
                        p.tipo_producto = Convert.ToDecimal(ddlTipoProducto.SelectedValue);
                        p.descripcion = txtDescripcion.Text.Trim();
                        p.save();
                        string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";

                        script = string.Format(script, "Producto guardado con exito");

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        clear();
                        cargarGrilla();
                    }
                }
                catch (Exception ex)
                {
                    string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";

                    script = string.Format(script, "Se ha producido un error, " + ex.Message);

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
        }

        private void clear()
        {
            this.txtCantidad.Text = "";
            this.ddlTipoProducto.SelectedIndex = 0;
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
            this.txtNombre.Text = "";
            this.txtPrecio.Text = "";
        }

        protected void dgv_productos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "modificar")
            {
                Producto p = new Producto();
                p.id = Convert.ToDecimal(e.CommandArgument);
                p = p.getById();
                txtCodigo.Text = p.id.ToString();
                txtCodigo.Enabled = false;
                txtNombre.Text = p.nombre;
                txtCantidad.Text = p.cantidad.ToString(); ;
                txtPrecio.Text = p.precio.ToString(); ;
                txtDescripcion.Text = p.descripcion;

                ddlTipoProducto.ClearSelection();
                foreach (ListItem item in ddlTipoProducto.Items)
                {
                    if (item.Value.Equals(p.tipo_producto.ToString()))
                    {
                        item.Selected = true;
                    }
                }
            }
            if (e.CommandName == "eliminar")
            {
                try
                {
                    decimal id = Convert.ToDecimal(e.CommandArgument);
                    Producto p = new Producto();
                    p.id = id;
                    p.delete();
                    string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";

                    script = string.Format(script, "Producto eliminado con exito!");

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    cargarGrilla();

                }
                catch (Exception ex)
                {
                    string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";

                    script = string.Format(script, "Se ha producido un error, " + ex.Message);

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }

            }
        }
    }
}