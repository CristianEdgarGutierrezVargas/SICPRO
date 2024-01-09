<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.Login.Login" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-10">
                <div class="card card-body pt-4 pb-0 pe-4 ps-4">
                    <h6 class="  fw-bold">Inicio de Sesión</h6>
                    <div class="row">
                        <div class="col-3">
                            <img src="../../../UI/img/lock.gif" alt="" width="128" height="128" class="left">
                        </div>

                        <div class="col-7">
                            <div class="row mb-1">
                                <div class="col-4 pt-2 ps-1">
                                    <asp:Label runat="server" ID="lblusuario">Usuario :</asp:Label>
                                </div>
                                <div class="col-8">
                                    <dx:BootstrapTextBox ID="txtusuario" runat="server" NullText="Usuario">
                                        <CssClasses Input="form-control-sm fs-10" />
                                        <ValidationSettings>
                                            <RequiredField IsRequired="true" ErrorText="Campo Obligatorio" />
                                        </ValidationSettings>
                                    </dx:BootstrapTextBox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-4 pt-2 ps-1">
                                    <asp:Label runat="server" ID="lblcontraseña">Contraseña :</asp:Label>
                                </div>
                                <div class="col-8">
                                    <dx:BootstrapTextBox ID="txtpassword" runat="server" NullText="Contraseña" Password="true">
                                        <CssClasses Input="form-control-sm fs-10" />
                                        <ValidationSettings>
                                            <RequiredField IsRequired="true" ErrorText="Campo Obligatorio" />
                                        </ValidationSettings>
                                    </dx:BootstrapTextBox>

                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-4 pt-2 p-1">
                                    <asp:Label runat="server" ID="lblTiempo">Tiempo de Conexion:</asp:Label>
                                </div>
                                <div class="col-8">

                                    <dx:BootstrapComboBox ID="sesion" runat="server" DropDownStyle="DropDownList" NullText="Seleccione una opción" ValueType="System.String">
                                        <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                        <Items>
                                            <dx:BootstrapListEditItem Text="Sel. una Opción" Value="0" Selected />
                                            <dx:BootstrapListEditItem Text="30 Minutos" Value="30" />
                                            <dx:BootstrapListEditItem Text="60 Minutos" Value="60" />
                                            <dx:BootstrapListEditItem Text="90 Minutos" Value="90" />
                                        </Items>
                                    </dx:BootstrapComboBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="offset-4 col-8">
                                    
                                        <dx:BootstrapButton ID="btnAceptar" runat="server" AutoPostBack="false" Text="Aceptar" OnClick="btnAceptar_Click">
                                            <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                            <SettingsBootstrap RenderOption="None" />
                                        </dx:BootstrapButton>
                               </div>


                            </div>
                        </div>
                        <p class="border-top border-primary   mt-4 mb-3 pt-1">
                            <a ><asp:label runat="server" ID="lblmensaje" Text="" CssClass="text-danger mt-1"></asp:label></a>
                        </p>
                    </div>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
