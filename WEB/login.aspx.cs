using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace WEB
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Productor p = new Productor();
                p.rut = this.txtRut.Text.Trim();
                p.nombre = this.txtNombre.Text.Trim();
                p.email = this.txtEmail.Text.Trim();
                p.direccion = this.txtDireccion.Text.Trim();
                p.comuna = findComunaByName(this.txtComuna.Text.Trim());
                p.fecha_registro = DateTime.Now;
                if (p.comuna != 0)
                {
                    if (p.save())
                    {
                        Usuario us = new Usuario();
                        us.email = p.email;
                        us.password = util.GetSHA1(this.txtPassword.Text.Trim());
                        us.perfil = 1;
                        if (us.save())
                        {
                            HttpCookie myCookie = new HttpCookie("user");
                            myCookie.Value = p.rut;
                            myCookie.Expires = DateTime.Now.AddDays(1000);
                            Response.Cookies.Add(myCookie);
                            string script = @"<script type='text/javascript'>
                            alert('{0}');
                            </script>";

                            script = string.Format(script, "Vendedor registrado con exito");

                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                            Response.Redirect("index.aspx", false);
                        }
                    }
                    else
                    {
                        string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";

                        script = string.Format(script, "No se ha podido insertar el usuario vuelva a intentarlo");

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                }

            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";

                script = string.Format(script, "No se ha podido insertar el usuario vuelva a intentarlo");

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

        private decimal findComunaByName(string text)
        {
            try
            {
                return Comuna.findName(text).id;
            }
            catch (Exception ex)
            {
                string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";

                script = string.Format(script, "No se ha encontrado la comuna, intente con otra");

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return 0;
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            usu.email = txtEmailLogin.Text.Trim();
            usu.password = util.GetSHA1(txtPasswordLogin.Text.Trim());
            if (usu.login() != null)
            {
                Productor p = Productor.findProductorByEmail(usu.email);
                if (p != null)
                {
                    HttpCookie myCookie = new HttpCookie("user");
                    myCookie.Value = p.rut;
                    myCookie.Expires = DateTime.Now.AddDays(1000);
                    Response.Cookies.Add(myCookie);
                    Response.Write("<SCRIPT>alert('Login con exito')</SCRIPT>");
                    Response.Redirect("index.aspx");
                }
                else
                {
                    string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";

                    script = string.Format(script, "Credeciales incorrectas, vuelva a intentarlo");

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }

            }
            else
            {
                string script = @"<script type='text/javascript'>
                            alert('{0}');
                        </script>";

                script = string.Format(script, "Credeciales incorrectas, vuelva a intentarlo");

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
    }
}