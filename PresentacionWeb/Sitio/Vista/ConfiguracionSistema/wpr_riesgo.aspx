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
                <div class="container">
                    <div class="row">
                        <div class="col-4">
                            <label>Código :</label>
                            <asp:TextBox ID="cod_mod" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <label>Ramo :</label>
                            <asp:TextBox ID="cod_ram" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <label>Póliza :</label>
                            <asp:TextBox ID="cod_pol" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row p-2"></div>
                    <div class="row">
                        <div class="col-3">
                            <label>Descripción :</label>
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="desc_riesgo" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row p-2"></div>
                    <div class="row">
                        <div class="col-3">
                            <label>Cobertura :</label>
                        </div>
                        <div class="col-9">
                            <asp:DropDownList ID="cobertura" runat="server" Style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Text="SELECCIONE UNA OPCIÓN" Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="GENERAL" Value="GENE"></asp:ListItem>
                                <asp:ListItem Text="PERSONAL" Value="PERS"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row p-2"></div>
                    <div class="row">
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
                            <p class="links">
                                <a class="error">
                                    <dx:ASPxLabel ID="lblmensaje" runat="server" Text=""></dx:ASPxLabel>
                                    <%--<span id="cpmaster_lblmensaje" class="error"></span>--%></a>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Fin Contenido -->
    <dx:ASPxPopupControl ID="popUpValidacion" runat="server" Modal="true" HeaderText="Validacion de datos" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpValidacion"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_button_2.jpg" ForeColor="White" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dx:PopupControlContentControl>
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/msg_icon_2.png">
                    </div>
                    <div class="col-9">
                        <br>
                        Los siguientes valores deben ser verificados antes de proseguir<br />
                        <p style="color: #990000; font-weight: bold">
                            <dx:ASPxLabel ID="lblerror" runat="server" Text=""></dx:ASPxLabel>
                        </p>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_button_2.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popUpValidacion.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="popUpConfirmacion" runat="server" Modal="true" HeaderText="Confirmacion" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpConfirmacion"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_title_1" ForeColor="White" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dx:PopupControlContentControl>
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/msg_icon_1.png">
                    </div>
                    <div class="col-9">
                        <br>
                        <p style="color: #0A416B; font-weight: bold">
                            <dx:ASPxLabel ID="lblMensaje" runat="server" Text=""></dx:ASPxLabel>
                        </p>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1); background-size: contain; color: white; border: solid; padding: 2px" onclick="popUpConfirmacion.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>
</asp:Content>
