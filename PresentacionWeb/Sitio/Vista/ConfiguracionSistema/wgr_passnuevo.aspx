<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_passnuevo.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wgr_passnuevo" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <!-- Inicio Contenido -->
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Registro de Nuevos Usuarios</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122">
            </div>
            <div class="col-10">
                <div class="container">
                    <div class="row">
                        <div class="col-3">
                            <label>Loggin :</label>
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="login" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label>Rol de Sistema :</label>
                        </div>
                        <div class="col-9">
                            <asp:DropDownList ID="id_rol" runat="server" Style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label>Usuario :</label>
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="nomraz" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 200px;"></asp:TextBox>
                            <asp:HiddenField ID="id_per" runat="server" />
                            <dx:ASPxButton ID="btnserper" runat="server" AutoPostBack="False" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;"
                                Text="...">
                                <ClientSideEvents Click="function(s, e) {
                                                                            popupBusquedaPersona.Show();
                                                                        }" />
                            </dx:ASPxButton>
                            <%--<button type="button" name="btnserper2" id="btnserper2" class="msg_button_class" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" onclick="popUpValidacion.Show()">...</button>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                        </div>
                        <div class="col-4">
                            <dx:ASPxButton ID="btnguardar" runat="server" Text="Guardar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnguardar_Click"></dx:ASPxButton>
                            <dx:ASPxButton ID="btnmodificar" runat="server" Text="Guardar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnmodificar_Click" Visible="false"></dx:ASPxButton>
                        </div>
                        <div class="col-4">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <div class="col-11">
                            <dx:ASPxGridView ID="grdusuarios" runat="server" Settings-ShowTitlePanel="true" SettingsText-Title="Lista de Usuarios" OnDataBinding="grdusuarios_DataBinding"
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
                                            <asp:ImageButton runat="server" ImageUrl="~/UI/img/front.png" CommandName="UPDATE" CommandArgument='<%# Eval("id_per") %>'  OnClick="Selectgrdusuarios_Click"/>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="ID." FieldName="id_per"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Nombre" FieldName="nomraz"></dx:GridViewDataColumn>
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
                                    <span id="cpmaster_lblmensaje" class="error"></span></a>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Fin Contenido -->
    <dx:ASPxPopupControl ID="popupBusquedaPersona" runat="server" Modal="true" HeaderText="Busqueda de Persona por Nombre o Razón Social" ShowFooter="true" PopupElementID="body" ClientInstanceName="popupBusquedaPersona"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_title_1.jpg" ForeColor="White" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/search_user.png" width="48" height="48">
                        <dx:ASPxTextBox ID="nomraz1" ClientInstanceName="nomraz1" runat="server" AutoCompleteType="None" Size="12"></dx:ASPxTextBox>
                        <dx:ASPxButton ID="btnserper_modal" runat="server" Text="->" CssClass="msg_button_class" AutoPostBack="false">
                            <ClientSideEvents Click="function(s,e){
                                        pnlCallBackBuscaPersona.PerformCallback(nomraz1.GetValue());
                                        }
                                        " />
                        </dx:ASPxButton>
                    </div>
                    <div class="col-9">
                        <dx:ASPxCallbackPanel ID="pnlCallBackBuscaPersona" ClientInstanceName="pnlCallBackBuscaPersona" runat="server" Width="200px" OnCallback="pnlCallBackBuscaPersona_Callback" SettingsLoadingPanel-Delay="2000" EnableCallbackAnimation="true" >
                            <PanelCollection>
                                <dx:PanelContent runat="server">
                                    <dx:ASPxGridView ID="grdListaPersona" runat="server" OnDataBinding="grdListaPersona_DataBinding" OnSelectionChanged="grdListaPersona_SelectionChanged"  EnableCallBacks="false"  KeyFieldName="id_per"
                                        Style="width: 340px; border-collapse: collapse;"
                                        Font-Size="11px"
                                        Font-Names="Arial, Helvetica, sans-serif"
                                        Styles-Header-BackgroundImage-ImageUrl="~/UI/img/blue/captionbckg.gif"
                                        Styles-Header-ForeColor="#15428b"
                                        Styles-Header-Paddings-Padding="1"
                                        Styles-Header-HorizontalAlign="Left"
                                        Styles-Header-Font-Bold="true"
                                        Styles-Cell-Paddings-Padding="0"
                                        Styles-Cell-ForeColor="#15428b"
                                        >
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="ID." FieldName="id_per" Visible="false"></dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Lista de Personas" FieldName="nomraz" Visible="true"></dx:GridViewDataColumn>
                                        </Columns>
                                        <SettingsPager PageSize="10" NumericButtonCount="1" CurrentPageNumberFormat="{0}">
                                            <FirstPageButton Visible="true"></FirstPageButton>
                                            <LastPageButton Visible="true"></LastPageButton>
                                            <Summary Visible="false" />
                                        </SettingsPager>
                                        <SettingsBehavior ProcessSelectionChangedOnServer="true" AllowSelectByRowClick="true"></SettingsBehavior>  
                                    </dx:ASPxGridView>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxCallbackPanel>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popupBusquedaPersona.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>

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
