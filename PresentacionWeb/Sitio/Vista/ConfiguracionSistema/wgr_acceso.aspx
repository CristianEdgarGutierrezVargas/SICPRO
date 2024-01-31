<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_acceso.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wgr_acceso" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dxA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Permiso de Accesos a Usuarios</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122">
            </div>
            <span class="border border-3 rounded w-75 pt-2 mb-2">
                <div class="col-10">
                    <div class="row p-2">
                        <div class="col-3">
                            Rol de Sistema:
                        </div>
                        <div class="col-7">
                            <asp:DropDownList ID="id_rol" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Text="SELECCIONE UNA OPCIÓN" Value=" " Selected="True"></asp:ListItem>
                                <asp:ListItem Text="ASISTENTE DE PROD." Value="94"></asp:ListItem>
                                <asp:ListItem Text="USUARIO RECLAMOS" Value="35"></asp:ListItem>
                                <asp:ListItem Text="COBRADOR" Value="41"></asp:ListItem>
                                <asp:ListItem Text="USUARIO PRODUCCION" Value="94"></asp:ListItem>
                                <asp:ListItem Text="ADMIN CARTERA" Value="35"></asp:ListItem>
                                <asp:ListItem Text="USUARIO COBRANZAS" Value="94"></asp:ListItem>
                                <asp:ListItem Text="EMPLEADO INACTIVO" Value="35"></asp:ListItem>
                                <asp:ListItem Text="ADMINISTRADOR" Value="94"></asp:ListItem>
                                <asp:ListItem Text="RECLAMOS Y PRODUCCION" Value="35"></asp:ListItem>
                                <asp:ListItem Text="USUARIO COBRANZAS ADM" Value="94"></asp:ListItem>
                                <asp:ListItem Text="USUARIO CONTABILIDAD" Value="35"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-3">
                            Nivel Acesso a Menú:
                        </div>
                        <div class="col-7">
                            <asp:DropDownList ID="id_com" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Text="SELECCIONE UNA OPCIÓN" Value=" " Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Registro de Producción" Value="94"></asp:ListItem>
                                <asp:ListItem Text="Validación de Producción" Value="35"></asp:ListItem>
                                <asp:ListItem Text="Módulo de Cobranzas" Value="41"></asp:ListItem>
                                <asp:ListItem Text="Módulo de Comisiones" Value="94"></asp:ListItem>
                                <asp:ListItem Text="Módulo de Reclamos" Value="35"></asp:ListItem>
                                <asp:ListItem Text="Reportes del Sistema" Value="94"></asp:ListItem>
                                <asp:ListItem Text="Configuración del Sistema" Value="35"></asp:ListItem>
                                <asp:ListItem Text="Opciones del Sistema" Value="94"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-5">
                            <asp:ListBox ID="lstcomp" runat="server" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width:200px;"></asp:ListBox>
                        </div>
                        <div class="col-2">
                            <div class="row p-1">
                                <asp:Button ID="btnid" runat="server" Text=">" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width:50px;"></asp:Button>
                            </div>
                            <div class="row p-1">
                                <asp:Button ID="btnti" runat="server" Text=">>" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width:50px;"></asp:Button>
                            </div>
                            <div class="row p-1">
                                <asp:Button ID="btndi" runat="server" Text="<" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width:50px;"></asp:Button>
                            </div>
                            <div class="row p-1">
                                <asp:Button ID="btntd" runat="server" Text="<<" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width:50px;"></asp:Button>
                            </div>
                        </div>
                        <div class="col-4">
                            <asp:ListBox ID="ListBox1" runat="server" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width:200px;"></asp:ListBox>
                        </div>
                    </div>
                </div>
            </span>
        </div>
    </div>
</asp:Content>
