<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_listacuotas.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wpr_listacuotas" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Lista de Polizas</h1>
            </div>
        </div>
        <div class="row">
            <%--            <div class="col-2">
                <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122">
            </div>--%>
            <div class="col-6">
                <div class="row p-2">
                    <div class="col-3">
                        N° de Poliza :
                    </div>
                    <div class="col-7">
                        <asp:TextBox ID="num_poliza" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 100%;"></asp:TextBox>
                    </div>
                    <div class="col-2">
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Asegurado :
                    </div>
                    <div class="col-7">
                        <asp:TextBox ID="nomraz" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 100%;"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <asp:HiddenField ID="id_per" runat="server" />
                        <dx:ASPxButton ID="btnserper" runat="server" Text="..." CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                            <ClientSideEvents Click="function(s, e) {
                                                                            popupBusquedaPersona.Show();
                                                                        }" />
                        </dx:ASPxButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Cia Aseguradora :
                    </div>
                    <div class="col-7">
                        <asp:TextBox ID="nomco" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 100%;"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <asp:HiddenField ID="id_spvs" runat="server" />
                        <dx:ASPxButton ID="btnsercom" runat="server" Text="..." CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                            <ClientSideEvents Click="function(s, e) {
                                                        popupBusquedaCompania.Show();
                                                    }" />
                        </dx:ASPxButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Producto :
                    </div>
                    <div class="col-7">
                        <asp:TextBox ID="desc_producto" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 100%;"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <asp:HiddenField ID="id_producto" runat="server" />
                        <dx:ASPxButton ID="btnserprod" runat="server" Text="..." CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnserprod_Click">
                            <%--<ClientSideEvents Click="function(s, e) {
                                                        popupBusquedaProducto.Show();
                                                    }" />--%>
                        </dx:ASPxButton>
                    </div>
                </div>
                <div class="row p-1 bg-primary bg-gradient text-white">
                    <div class="col-3">
                    </div>
                    <div class="col-6">
                    </div>
                    <div class="col-3">
                        <label class="form-check-label" for="flexCheckIndeterminate">
                            Por vigencia
                        </label>
                        <dx:ASPxCheckBox ID="vigencia" runat="server" class="form-check form-switch"></dx:ASPxCheckBox>
                    </div>
                </div>
                <div class="row p-2">
                    <div class="col-3">
                        Del:
                    </div>
                    <div class="col-7">
                        <dx:ASPxDateEdit ID="fc_inivig" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy" UseMaskBehavior="True">
                            <%--<CssClasses Button="btn-sm" Input="form-control-sm fs-10" />--%>
                        </dx:ASPxDateEdit>
                    </div>
                    <div class="col-2">
                    </div>
                </div>
                <div class="row p-2">
                    <div class="col-3">
                        Al:
                    </div>
                    <div class="col-7">
                        <dx:ASPxDateEdit ID="fc_finvig" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy" UseMaskBehavior="True">
                            <%--<CssClasses Button="btn-sm" Input="form-control-sm fs-10" />--%>
                        </dx:ASPxDateEdit>
                    </div>
                    <div class="col-2">
                    </div>
                </div>
                <div class="row p-1 bg-primary bg-gradient text-white">
                    <div class="col-3">
                    </div>
                    <div class="col-6">
                    </div>
                    <div class="col-3">
                        <label class="form-check-label" for="flexCheckIndeterminate">
                            Por Vencer
                        </label>
                        <dx:ASPxCheckBox ID="porvencer" runat="server" class="form-check form-switch"></dx:ASPxCheckBox>
                    </div>
                </div>
                <div class="row p-2">
                    <div class="col-3">
                        Polizas Vencidas :
                    </div>
                    <div class="col-7">
                        <dx:ASPxDateEdit ID="fc_polizavencida" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy" UseMaskBehavior="True">
                            <%--<CssClasses Button="btn-sm" Input="form-control-sm fs-10" />--%>
                        </dx:ASPxDateEdit>
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
                        <dx:ASPxButton ID="btnbuscar" runat="server" Text="Buscar" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnbuscar_Click"></dx:ASPxButton>
                    </div>

                </div>
            </div>
            <div class="col-6">
                <dx:ASPxGridView ID="gridpoliza" runat="server" OnDataBinding="grdPolizas_DataBinding" OnSelectionChanged="grdPolizas_SelectionChanged" EnableCallBacks="false" KeyFieldName="num_poliza"
                    Style="width: 100%; border-collapse: collapse;"
                    Font-Size="11px"
                    Font-Names="Arial, Helvetica, sans-serif"
                    Styles-Header-BackgroundImage-ImageUrl="~/UI/img/blue/captionbckg.gif"
                    Styles-Header-ForeColor="#15428b"
                    Styles-Header-Paddings-Padding="1"
                    Styles-Header-HorizontalAlign="Left"
                    Styles-Header-Font-Bold="true"
                    Styles-Cell-Paddings-Padding="0"
                    Styles-Cell-ForeColor="#15428b"
                    Visible="false">
                    <Columns>
                        <%--<dx:GridViewDataColumn Caption="ID." FieldName="id_per" Visible="false"></dx:GridViewDataColumn>--%>
                        <dx:GridViewDataColumn Caption="N° Póliza" FieldName="num_poliza" Visible="true"></dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Cliente" FieldName="nomraz" Visible="true"></dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Ini. Vigencia" FieldName="fc_inivig" Visible="true"></dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Fin Vigencia" FieldName="fc_finvig" Visible="true"></dx:GridViewDataColumn>
                    </Columns>
                    <SettingsPager PageSize="10" NumericButtonCount="1" CurrentPageNumberFormat="{0}">
                        <FirstPageButton Visible="true"></FirstPageButton>
                        <LastPageButton Visible="true"></LastPageButton>
                        <Summary Visible="false" />
                    </SettingsPager>
                    <SettingsBehavior ProcessSelectionChangedOnServer="true" AllowSelectByRowClick="true"></SettingsBehavior>
                </dx:ASPxGridView>
            </div>
        </div>

    </div>
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
                        <dx:ASPxCallbackPanel ID="pnlCallBackBuscaPersona" ClientInstanceName="pnlCallBackBuscaPersona" runat="server" Width="200px" OnCallback="pnlCallBackBuscaPersona_Callback" SettingsLoadingPanel-Delay="2000" EnableCallbackAnimation="true">
                            <PanelCollection>
                                <dx:PanelContent runat="server">
                                    <dx:ASPxGridView ID="grdListaPersona" runat="server" OnDataBinding="grdListaPersona_DataBinding" OnSelectionChanged="grdListaPersona_SelectionChanged" EnableCallBacks="false" KeyFieldName="id_per"
                                        Style="width: 340px; border-collapse: collapse;"
                                        Font-Size="11px"
                                        Font-Names="Arial, Helvetica, sans-serif"
                                        Styles-Header-BackgroundImage-ImageUrl="~/UI/img/blue/captionbckg.gif"
                                        Styles-Header-ForeColor="#15428b"
                                        Styles-Header-Paddings-Padding="1"
                                        Styles-Header-HorizontalAlign="Left"
                                        Styles-Header-Font-Bold="true"
                                        Styles-Cell-Paddings-Padding="0"
                                        Styles-Cell-ForeColor="#15428b">
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
    <dx:ASPxPopupControl ID="popupBusquedaCompania" runat="server" Modal="true" HeaderText="Busqueda de Compañias por Nombre o Razón Social" ShowFooter="true" PopupElementID="body" ClientInstanceName="popupBusquedaCompania"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_title_1.jpg" ForeColor="White" Font-Bold="true" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/search_user.png" width="48" height="48">
                        <dx:ASPxTextBox ID="nomco1" ClientInstanceName="nomco1" runat="server" AutoCompleteType="None" Size="12"></dx:ASPxTextBox>
                        <dx:ASPxButton ID="btnsercom_modal" runat="server" Text="Buscar" CssClass="msg_button_class" AutoPostBack="false">
                            <ClientSideEvents Click="function(s,e){
                             pnlCallBackBuscaCompania.PerformCallback(nomco1.GetValue());
                             }
                             " />
                        </dx:ASPxButton>
                    </div>
                    <div class="col-9">
                        <dx:ASPxCallbackPanel ID="pnlCallBackBuscaCompania" ClientInstanceName="pnlCallBackBuscaCompania" runat="server" Width="200px" SettingsLoadingPanel-Delay="2000" EnableCallbackAnimation="true" OnCallback="pnlCallBackBuscaCompania_Callback">
                            <PanelCollection>
                                <dx:PanelContent runat="server">
                                    <dx:ASPxGridView ID="grdListaCompania" runat="server" OnDataBinding="grdListaCompania_DataBinding" OnSelectionChanged="grdListaCompania_SelectionChanged" EnableCallBacks="false" KeyFieldName="id_spvs"
                                        Style="width: 340px; border-collapse: collapse;"
                                        Font-Size="11px"
                                        Font-Names="Arial, Helvetica, sans-serif"
                                        Styles-Header-BackgroundImage-ImageUrl="~/UI/img/blue/captionbckg.gif"
                                        Styles-Header-ForeColor="#15428b"
                                        Styles-Header-Paddings-Padding="1"
                                        Styles-Header-HorizontalAlign="Left"
                                        Styles-Header-Font-Bold="true"
                                        Styles-Cell-Paddings-Padding="0"
                                        Styles-Cell-ForeColor="#15428b">
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="ID." FieldName="id_spvs" Visible="false"></dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Lista de Compañias" FieldName="nomraz" Visible="true"></dx:GridViewDataColumn>
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
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popupBusquedaCompania.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="popupBusquedaProducto" runat="server" Modal="true" HeaderText="Busqueda de Productos" ShowFooter="true" PopupElementID="body" ClientInstanceName="popupBusquedaProducto"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_title_1.jpg" ForeColor="White" Font-Bold="true" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/search_user.png" width="48" height="48">
                        <dx:ASPxTextBox ID="desc_prod1" ClientInstanceName="desc_prod1" runat="server" AutoCompleteType="None" Size="12"></dx:ASPxTextBox>
                        <dx:ASPxButton ID="btnserprod_modal" runat="server" Text="Buscar" CssClass="msg_button_class" AutoPostBack="false">
                            <ClientSideEvents Click="function(s,e){
                                         pnlCallBackBuscaProducto.PerformCallback(desc_prod1.GetValue());
                                         }
                         " />
                        </dx:ASPxButton>
                    </div>
                    <div class="col-9">
                        <dx:ASPxCallbackPanel ID="pnlCallBackBuscaProducto" ClientInstanceName="pnlCallBackBuscaProducto" runat="server" Width="200px" SettingsLoadingPanel-Delay="2000" EnableCallbackAnimation="true" OnCallback="pnlCallBackBuscaProducto_Callback">
                            <PanelCollection>
                                <dx:PanelContent runat="server">
                                    <dx:ASPxGridView ID="grdListaProducto" runat="server" OnDataBinding="grdListaProducto_DataBinding" OnSelectionChanged="grdListaProducto_SelectionChanged" EnableCallBacks="false" KeyFieldName="id_producto"
                                        Style="width: 340px; border-collapse: collapse;"
                                        Font-Size="11px"
                                        Font-Names="Arial, Helvetica, sans-serif"
                                        Styles-Header-BackgroundImage-ImageUrl="~/UI/img/blue/captionbckg.gif"
                                        Styles-Header-ForeColor="#15428b"
                                        Styles-Header-Paddings-Padding="1"
                                        Styles-Header-HorizontalAlign="Left"
                                        Styles-Header-Font-Bold="true"
                                        Styles-Cell-Paddings-Padding="0"
                                        Styles-Cell-ForeColor="#15428b">
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="ID." FieldName="id_producto" Visible="false"></dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Lista de Productos" FieldName="desc_prod" Visible="true"></dx:GridViewDataColumn>
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
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popupBusquedaProducto.Hide()">ACEPTAR</button>
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
                        <p style="color: #990000; font-weight: bold">
                            <dx:ASPxLabel ID="lblerror" runat="server" Text=""></dx:ASPxLabel>
                        </p>
                        Para realizar la Busqueda de un Producto<br />
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_button_2.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popUpValidacion.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>
</asp:Content>
