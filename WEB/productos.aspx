<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="productos.aspx.cs" Inherits="WEB.productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>Frutos Secos</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- page content -->
    <div class="right_col" role="main">
        <div class="title_right">
            <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Buscar por nombre">
                    <span class="input-group-btn">
                        <button class="btn btn-default" type="button">Go!</button>
                    </span>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="dashboard_graph">

                    <div class="table-responsive">
                        <asp:GridView ID="dgv_productos" runat="server" CssClass="table table-striped jambo_table bulk_action" OnRowCommand="dgv_productos_RowCommand" EmptyDataText="Sin datos" AutoGenerateColumns="false" HeaderStyle-CssClass="column-title" RowStyle-CssClass="column-title">
                            <Columns>

                                <asp:BoundField DataField="id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                <asp:TemplateField HeaderStyle-CssClass="header headerSortUp" SortExpression="nombre" ItemStyle-Width="400" HeaderText='Nombre'>
                                    <ItemTemplate>
                                        <%#Eval("nombre")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText='Cantidad' HeaderStyle-CssClass='column-title¿' SortExpression="Cantidad">
                                    <ItemTemplate>
                                        <%#Eval("cantidad")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText='Precio' HeaderStyle-CssClass="column-title" SortExpression="precio">
                                    <ItemTemplate>
                                        <%#Eval("precio")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText='Tipo' HeaderStyle-CssClass="column-title" SortExpression="tipo">
                                    <ItemTemplate>
                                        <%#Eval("tipo")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText='Acciones' HeaderStyle-CssClass="column-title" SortExpression="acciones">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbUpdate" runat="server" CommandName="modificar" CommandArgument='<%# Eval("id") %>' Text="Update" CssClass="btn btn-success btn-sm"> <span aria-hidden="true" class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                        <asp:LinkButton ID="lbDelete" runat="server" CommandName="eliminar" CommandArgument='<%# Eval("id") %>' Text="Delete" CssClass="btn btn-danger btn-sm"><span aria-hidden="true" class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>


                    <div class="clearfix"></div>

                </div>
            </div>
        </div>
        <br />
        <div class="clearfix"></div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Formulario de Ingresos <small>Productos</small></h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <br />
                        <div id="demo-form2" class="form-horizontal form-label-left">


                            <div class="form-group">
                                <label class="control-label col-md-4 col-sm-3 col-xs-12" for="first-name">
                                    Nombre Producto <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control col-md-7 col-xs-12" required="required" MaxLength="60"></asp:TextBox>
                                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="hidden"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-4 col-sm-3 col-xs-12" for="first-name">
                                    Cantidad <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:TextBox ID="txtCantidad" runat="server" class="form-control col-md-7 col-xs-12" required="required" MaxLength="60"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-4 col-sm-3 col-xs-12" for="first-name">
                                    Precio<span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                                    <asp:TextBox ID="txtPrecio" runat="server" class="form-control has-feedback-left" required="required" MaxLength="60"></asp:TextBox>
                                    <span class="fa fa-dollar form-control-feedback left" aria-hidden="true"></span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-4 col-sm-3 col-xs-12" for="first-name">
                                    Tipo Producto <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:DropDownList ID="ddlTipoProducto" CssClass="form-control" runat="server" AutoPostBack="true">
                                        <asp:ListItem Text="Seleccionar" Value="-1" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-4 col-sm-3 col-xs-12" for="first-name">
                                    Descripción <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <asp:TextBox ID="txtDescripcion" TextMode="multiline" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                                    <asp:Button ID="btnClear" CssClass="btn btn-primary" runat="server" Text="Cancelar" OnClick="btnClear_Click" />
                                    <asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>


        <br />
    </div>
    <!-- /page content -->
</asp:Content>
