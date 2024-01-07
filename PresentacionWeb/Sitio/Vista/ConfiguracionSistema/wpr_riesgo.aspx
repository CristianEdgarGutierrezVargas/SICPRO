<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_riesgo.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wpr_riesgo" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <!-- Inicio Contenido -->
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Registro de Nuevos Riesgos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122">
            </div>
            <div class="col-10">
                <div class="row p-2">
                    <div class="col-2">
                        <label>Código :</label>
                    </div>
                    <div class="col-2">
                        <asp:TextBox ID="cod_mod" runat="server" CssClass="w-50"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <label>Ramo :</label>
                    </div>
                    <div class="col-2">
                        <asp:TextBox ID="cod_ram" runat="server" CssClass="w-50"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <label>Póliza :</label>
                    </div>
                    <div class="col-2">
                        <asp:TextBox ID="cod_pol" runat="server" CssClass="w-50"></asp:TextBox>
                    </div>
                </div>
                <div class="row p-2">
                    <div class="col-2">
                        <label>Descripción :</label>
                    </div>
                    <div class="col-10">
                        <asp:TextBox ID="desc_riesgo" runat="server" CssClass="w-75"></asp:TextBox>
                    </div>
                </div>
                <div class="row p-2">
                    <div class="col-2">
                        <label>Cobertura :</label>
                    </div>
                    <div class="col-10">
                        <asp:DropDownList ID="cobertura" runat="server" CssClass="w-50">
                            <asp:ListItem Text="SELECCIONE UNA OPCIÓN" Value="" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="GENERAL" Value="GENE"></asp:ListItem>
                            <asp:ListItem Text="PERSONAL" Value="PERS"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row p-2">
                    <div class="col-4">
                    </div>
                    <div class="col-4">
                        <dx:ASPxButton ID="btnguardar" runat="server" Text="Guardar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnguardar_Click"></dx:ASPxButton>
                    </div>
                    <div class="col-4">
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
    <dx:ASPxPopupControl ID="popUpValidacion" runat="server" Modal="true" HeaderText="Validacion de datos" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpValidacion"
        CloseAction="None" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px" ShowCloseButton="false">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_button_2.jpg" ForeColor="White" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dx:PopupControlContentControl>
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/msg_icon_2.png">
                    </div>
                    <div class="col-9">
                        <div class="row">
                            <div class="col-12">
                                Los siguientes valores deben ser verificados antes de proseguir
                            </div>
                        </div>
                        <div class="row p-2">
                            <div class="col-12">
                                <dx:ASPxLabel ID="lblerror" runat="server" Text="" Style="color: #990000; font-weight: bold"></dx:ASPxLabel>
                            </div>
                        </div>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_button_2.jpg); background-size: contain; color: white; border: solid; padding: 3px" onclick="popUpValidacion.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>
</asp:Content>
