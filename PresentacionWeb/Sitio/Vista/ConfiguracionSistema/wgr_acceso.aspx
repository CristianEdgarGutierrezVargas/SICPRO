<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_acceso.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wgr_acceso" %>


<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

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
                            <asp:DropDownList ID="id_rol" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnSelectedIndexChanged="id_rol_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-3">
                            Nivel Acesso a Menú:
                        </div>
                        <div class="col-7">
                            <asp:DropDownList ID="id_com" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnSelectedIndexChanged="id_com_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-5">
                            <asp:ListBox ID="lstcomp" runat="server" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width:200px;" Rows="10"></asp:ListBox>
                        </div>
                        <div class="col-2">
                            <div class="row p-1">
                                <asp:Button ID="btnid" runat="server" Text=">" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width:50px;" OnClick="btnid_Click"></asp:Button>
                            </div>
                            <div class="row p-1">
                                <asp:Button ID="btnti" runat="server" Text=">>" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width:50px;" OnClick="btnti_Click"></asp:Button>
                            </div>
                            <div class="row p-1">
                                <asp:Button ID="btndi" runat="server" Text="<" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width:50px;" OnClick="btndi_Click"></asp:Button>
                            </div>
                            <div class="row p-1">
                                <asp:Button ID="btntd" runat="server" Text="<<" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width:50px;" OnClick="btntd_Click"></asp:Button>
                            </div>
                        </div>
                        <div class="col-4">
                            <asp:ListBox ID="lstcompo" runat="server" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width:200px;" Rows="10"></asp:ListBox>
                        </div>
                    </div>
                </div>
            </span>
        </div>
    </div>
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
</asp:Content>
