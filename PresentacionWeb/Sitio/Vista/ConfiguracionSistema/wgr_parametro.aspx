<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_parametro.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wgr_parametro" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <!-- Inicio Contenido -->
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Registro de Parámetros</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122">
            </div>
            <div class="col-10">
                <div class="row p-1">
                    <div class="col-2">
                        <label>Columna :</label>
                    </div>
                    <div class="col-4">
                        <asp:TextBox ID="columna" runat="server" CssClass="w-50"></asp:TextBox>
                    </div>
                </div>
                 <div class="row p-1">
                    <div class="col-2">
                        <label>Descripción :</label>
                    </div>
                    <div class="col-5">
                        <asp:TextBox ID="desc_param" runat="server" CssClass="w-75"></asp:TextBox>
                    </div>
                </div>
                <div class="row p-1">
                    <div class="col-2">
                        <label>Abreviación :</label>
                    </div>
                    <div class="col-4">
                        <asp:TextBox ID="abrev_param" runat="server" CssClass="w-50"></asp:TextBox>
                    </div>
                </div>
                <div class="row p-1">
                    <div class="col-2">
                        <label>Valor :</label>
                    </div>
                    <div class="col-4">
                        <asp:TextBox ID="valor_param" runat="server" CssClass="w-50"></asp:TextBox>
                    </div>
                </div>
               
                <div class="row p-2">
                    <div class="col-3">
                    </div>
                    <div class="col-4">
                        <dx:ASPxButton ID="btnnuevo"    runat="server" Text="Nuevo" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnnuevo_Click"></dx:ASPxButton>
                        <dx:ASPxButton ID="btnguardar"  runat="server" Text="Guardar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnguardar_Click"></dx:ASPxButton>
                        <dx:ASPxButton ID="btneliminar" runat="server" Text="Eliminar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btneliminar_Click"></dx:ASPxButton>
                    </div>
                    <div class="col-5">
                    </div>
                </div>
                 <div class="row p-0">
                    <div class="col-2">
                        <label>Seleccionar Columna :</label>
                    </div>
                    <div class="col-4">
                        <asp:DropDownList ID="cobertura" runat="server" CssClass="w-50">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <dx:ASPxLabel ID="lblmensaje" runat="server" Text="" CssClass="error"></dx:ASPxLabel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Fin Contenido -->
</asp:Content>
