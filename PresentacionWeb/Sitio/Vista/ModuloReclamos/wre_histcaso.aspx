<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wre_histcaso.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloReclamos.wre_histcaso" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Seguimiento de Casos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/poliza.gif" alt="" width="122" height="122">
            </div>
            <span class="border border-3 rounded w-75 pt-2">
                <div class="col-10">
                    <div class="row p-2">
                        <div class="col-2">
                            Nº de Caso / Año:
                        </div>
                        <div class="col-3">
                            <asp:TextBox ID="id_caso" runat="server"  CssClass="form-control fs-10"></asp:TextBox>
                        </div>
                        <div class="col-1">
                            /
                        </div>
                        <div class="col-4">
                            <asp:DropDownList ID="anio_caso" runat="server" CssClass="form-control-sm fs-10 w-100">
                                <asp:ListItem Value="-1" Text="SEL. UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="2023" Text="2023"></asp:ListItem>
                                <asp:ListItem Value="2024" Text="2024"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-2">
                            <asp:ImageButton runat="server" ImageUrl="~/UI/img/view.png" ID="btnser" CommandName="UPDATE" BorderStyle="Groove" CssClass="rounded-3" BorderColor="#999999" OnClick="btnser_Click"/>
                        </div>
                    </div>
                    <div class="row p-1">
                        <div class="col-2">
                            Cliente:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="cpmaster_nomraz" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>

                    <div class="row p-1">
                        <div class="col-2">
                            Poliza:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="cpmaster_num_poliza" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-1">
                        <div class="col-2">
                            Producto :
                        </div>
                        <div class="col-7">
                            <asp:Label ID="cpmaster_desc_prod" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-1">
                        <div class="col-2">
                            Compañía :
                        </div>
                        <div class="col-7">
                            <asp:Label ID="cpmaster_nomraz2" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-1">
                        <div class="col-2">
                            Objeto Asegurado:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="cpmaster_mat_aseg" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-1">
                        <div class="col-2">
                            Identificador Unico:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="cpmaster_uni_obj" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-1">
                        <div class="col-2">
                            Fecha de Denuncia:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="cpmaster_fc_denuncia" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-1">
                        <div class="col-2">
                            Circunstancias:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="cpmaster_circunstancia" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-1">
                        <div class="col-2">
                            Monto Aproximado:
                        </div>
                        <div class="col-3">
                            <asp:Label ID="cpmaster_monto_aprox1" runat="server" Text="0.00"></asp:Label>
                        </div>
                        <div class="col-1">
                            <asp:Label ID="cpmaster_divisa" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-3">
                        </div>
                    </div>

                    <div class="row p-1">
                        <div class="col-2">
                            Ultimo Estado:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="cpmaster_desc_param" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-1">
                        <div class="col-2">
                            Fecha de Registro:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="cpmaster_fc_iniestado" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-1">
                        <div class="col-2">
                            Observaciones:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="cpmaster_obs_histcaso1" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-1">
                        <div class="col-2">
                            Nuevo Estado:
                        </div>
                        <div class="col-7">

                            <asp:DropDownList ID="id_estca" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SEL. UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="74" Text="EN PREVICOR"></asp:ListItem>
                                <asp:ListItem Value="75" Text="EN CLIENTE"></asp:ListItem>
                                <asp:ListItem Value="76" Text="EN COMPAÑIA"></asp:ListItem>
                                <asp:ListItem Value="77" Text="EN LIQUIDACION"></asp:ListItem>
                                <asp:ListItem Value="78" Text="EN AJUSTE"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-1">
                        <div class="col-2">
                            Observaciones:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="circunstancia" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 50px; width: 300px;" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                        </div>
                        <div class="col-2">
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="btnnuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnnuevo_Click"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="btnsalir" runat="server" Text="Salir" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnsalir_Click"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                        </div>

                    </div>
                </div>
            </span>
        </div>
        <p class="links">
            <asp:Label ID="cpmaster_lblmensaje" runat="server" Text="Introduzca Valores" CssClass="error"></asp:Label>
        </p>
    </div>
</asp:Content>
