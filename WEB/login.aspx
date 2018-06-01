<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WEB.login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Gentellela Alela! | </title>

    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="../vendors/animate.css/animate.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet">
</head>

<body class="login">



    <form runat="server">
        <asp:ScriptManager ID="ScriptManagerMaster" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelMaster" runat="server">
            <ContentTemplate>
                <div>
                    <a class="hiddenanchor" id="signup"></a>
                    <a class="hiddenanchor" id="signin"></a>

                    <div class="login_wrapper">
                        <div class="animate form login_form">
                            <section class="login_content">

                                <h1>Acceso</h1>
                                <div>
                                    <asp:TextBox ID="txtEmailLogin" runat="server" CssClass="form-control" placeholder="Email" MaxLength="60"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtPasswordLogin" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña" MaxLength="60"></asp:TextBox>
                                    <br />
                                </div>

                                <div>
                                    <a href="login.aspx#signup">
                                        <asp:Button ID="btnEntrar" CssClass="btn btn-default submit" runat="server" OnClick="btnEntrar_Click" Text="Entrar" /></a>
                                    <!--<a class="reset_pass" href="#">Lost your password?</a>-->
                                </div>

                                <div class="clearfix"></div>

                                <div class="separator">
                                    <p class="change_link">
                                        Nuevo en el sitio?
                  <a href="#signup" class="to_register">Crear una Cuenta </a>
                                    </p>

                                    <div class="clearfix"></div>
                                    <br />

                                    <div>
                                        <h1>Frutos Frescos!</h1>
                                        <p>©2016 Todos los derechos reservados.  Frutos Frescos. Terminos y condiciones</p>
                                    </div>
                                </div>

                            </section>
                        </div>

                        <div id="register" class="animate form registration_form">
                            <section class="login_content">

                                <h1>Crear Cuenta</h1>
                                <div>
                                    <asp:TextBox ID="txtRut" runat="server" CssClass="form-control" placeholder="Rut" MaxLength="60"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" MaxLength="60"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" MaxLength="60"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Dirección" MaxLength="60"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtComuna" runat="server" CssClass="form-control" placeholder="Comuna" MaxLength="60"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control" placeholder="Contraseña" MaxLength="60"></asp:TextBox>
                                </div>
                                <div>
                                    <a href="login.aspx#signup">
                                        <asp:Button ID="btnGuardar" CssClass="btn btn-default submit" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                    </a>
                                </div>

                                <div class="clearfix"></div>

                                <div class="separator">
                                    <p class="change_link">
                                        Ya eres miembro ?
                  <a href="#signin" class="to_register">Entrar </a>
                                    </p>

                                    <div class="clearfix"></div>
                                    <br />

                                    <div>
                                        <h1>Frutos Frescos!</h1>
                                        <p>©2016 Todos los derechos reservados.  Frutos Frescos. Terminos y condiciones</p>
                                    </div>
                                </div>

                            </section>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>

</body>
</html>
