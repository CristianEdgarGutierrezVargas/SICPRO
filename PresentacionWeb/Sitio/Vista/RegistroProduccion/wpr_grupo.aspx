<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_grupo.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wpr_grupo" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
        <!-- Inicio Contenido -->
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Registro de Grupos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122">
            </div>
            <div class="col-10">
                <div class="container">
                    <div class="row">
                        <div class="col-2">
                            <label>Descripcion :</label>
                        </div>
                        <div class="col-10">
                            <asp:TextBox ID="txtDescripcionGrupo" class="form-control" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;"></asp:TextBox>
                        </div>
                    </div>
                    <br /><br />
                    <div class="row">
                        <div class="col-4">
                        </div>
                        <div class="col-1">
                            <dx:ASPxButton ID="btnNuevo" runat="server" Text="Nuevo" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnNuevo_Click"></dx:ASPxButton>                        
                        </div>
                        <div class="col-1">
                            <dx:ASPxButton ID="btnguardar" runat="server" Text="Guardar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnguardar_Click"></dx:ASPxButton>
                        </div>
                        <div class="col-1">
                            <dx:ASPxButton ID="btnEliminar" runat="server" Text="Eliminar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnEliminar_Click"></dx:ASPxButton>                        
                        </div>
                        <div class="col-4">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <div class="col-11">
                            <dx:ASPxGridView ID="grdGrupos" runat="server" Settings-ShowTitlePanel="true" SettingsText-Title="Lista de Grupos" OnDataBinding="grdGrupos_DataBinding"
                                Style="width: 450px; border-collapse: collapse;"
                                Font-Size="11px"
                                Font-Names="Arial, Helvetica, sans-serif"
                                Styles-Header-BackgroundImage-ImageUrl="~/UI/img/blue/captionbckg.gif"
                                Styles-Header-ForeColor="#15428b"
                                Styles-Header-Paddings-Padding="1"
                                Styles-Header-HorizontalAlign="Center"
                                Styles-TitlePanel-BackgroundImage-ImageUrl="~/UI/img/blue/captionbckg.gif"
                                Styles-TitlePanel-ForeColor="#15428b"
                                Styles-TitlePanel-Font-Bold="true"
                                Styles-TitlePanel-HorizontalAlign="Left"
                                Styles-TitlePanel-Paddings-Padding="1"
                                Styles-Cell-Paddings-Padding="0">
                                <Columns>
                                    <dx:GridViewDataColumn>
                                        <DataItemTemplate>
                                            <asp:ImageButton runat="server" ImageUrl="~/UI/img/front.png" CommandName="UPDATE" CommandArgument='<%# Eval("id_gru") %>'  OnClick="Selectgrdusuarios_Click"/>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Codigo" FieldName="id_gru"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Descripcion" FieldName="desc_grupo"></dx:GridViewDataColumn>
                                </Columns>
                                
                                <SettingsPager PageSize="5" CurrentPageNumberFormat="{0}">
                                    <FirstPageButton Visible="true"></FirstPageButton>
                                    <LastPageButton Visible="true"></LastPageButton>
                                    <Summary Visible="false" />
                                </SettingsPager>
                            </dx:ASPxGridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <p class="links">
                                <a class="error">
                                     <dx:ASPxLabel ID="lblMensajeError" runat="server" Text=""></dx:ASPxLabel>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Fin Contenido -->
    
     <dx:ASPxPopupControl ID="popUpConfirmacion" runat="server" Modal="true" HeaderText="Confirmacion" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpConfirmacion"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_title_1" ForeColor="White" >
            <BackgroundImage ImageUrl="../../../UI/img/msg_title_1"></BackgroundImage>
         </HeaderStyle>
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
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1); background-color:navy; background-size: contain; color: white; border: solid; padding: 2px" onclick="popUpConfirmacion.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>

        </a>

</asp:Content>
