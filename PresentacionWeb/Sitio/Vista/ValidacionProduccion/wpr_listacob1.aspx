<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_listacob1.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ValidacionProduccion.wpr_listacob1" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div id="content" class="container">



    

        <script type="text/javascript">    
            function UpdateDetailGrid(s, e) {
                var index = e.visibleIndex;
                
                CallBPersona.PerformCallback(index);
            }
            function OnEndCallbackPersona(s, e) {
             
                pCPersona.Hide();
            
            }  


           
        </script>

       

        <asp:Panel runat="server" ID="panel" CssClass="rounded">
            <div id="msgboxpanel" runat="server"></div>

            <div class="card p-3 bg-light rounded">
                <h6 class="text-info fw-bold fs-8">Listado de Polizas</h6>
                <div class="row">
                    <div class="col-5">
                        <div class="row">
                            <div class="col-4">
                                <asp:Label runat="server" ID="lblnumero" Text="N° de Poliza :" CssClass="fs-10"></asp:Label>
                            </div>
                            <div class="col-8">
                                <dx:BootstrapTextBox runat="server" ID="num_poliza" NullText="Número de Poliza" Text="%">
                                    <CssClasses Input="form-control-sm fs-10" />
                                </dx:BootstrapTextBox>
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col-4">
                                <asp:Label runat="server" ID="lblasegurado" Text="Asegurado :" CssClass="fs-10"></asp:Label>
                            </div>
                            <div class="col-8">
                                <div class="d-flex flex-row">
                                    <dx:BootstrapCallbackPanel ID="CallBPersona" ClientInstanceName="CallBPersona" runat="server" OnCallback="CallBPersona_Callback"  >
                                        <ClientSideEvents EndCallback="OnEndCallbackPersona"></ClientSideEvents>  
                                        <ContentCollection>
                                            <dx:ContentControl>
                                                <dx:BootstrapTextBox runat="server" ID="nomraz" NullText="" Width="150px">
                                                    <CssClasses Input="form-control-sm fs-10" />
                                                </dx:BootstrapTextBox>
                                                <asp:HiddenField runat="server" ID="id_per" Value="" />
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:BootstrapCallbackPanel>
                                    <dx:BootstrapButton ID="btnserper" runat="server" AutoPostBack="false" Text="..." OnClick="btnserper_Click">
                                        <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                        <SettingsBootstrap RenderOption="None" />
                                    </dx:BootstrapButton>
                                </div>

                                <asp:HiddenField runat="server" ID="a" Value="0" />
                                <asp:HiddenField runat="server" ID="b" Value="10" />
                                <asp:HiddenField runat="server" ID="ap" Value="0" />
                                <asp:HiddenField runat="server" ID="bp" Value="0" />
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col-4 pe-0">
                                <asp:Label runat="server" ID="lblcompania" Text="Cia Aseguradora:" CssClass="fs-10"></asp:Label>
                            </div>
                            <div class="col-8">
                                <div class="d-flex flex-row">
                                    <dx:BootstrapTextBox runat="server" ID="nomco" NullText="" Width="150px">
                                        <CssClasses Input="form-control-sm fs-10" />
                                    </dx:BootstrapTextBox>

                                    <dx:BootstrapButton ID="btnsercom" runat="server" AutoPostBack="false" Text="...">
                                        <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                        <SettingsBootstrap RenderOption="None" />
                                    </dx:BootstrapButton>
                                </div>
                                <asp:HiddenField runat="server" ID="id_spvs" Value="" />
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col-4">
                                <asp:Label runat="server" ID="lblproducto" Text="Producto :" CssClass="fs-10"></asp:Label>
                            </div>
                            <div class="col-8">
                                <div class="d-flex flex-row">
                                    <dx:BootstrapTextBox runat="server" ID="desc_producto" NullText="" Width="150px">
                                        <CssClasses Input="form-control-sm fs-10" />
                                    </dx:BootstrapTextBox>

                                    <dx:BootstrapButton ID="btnserprod" runat="server" AutoPostBack="false" Text="..." OnClick="btnserprod_Click">
                                        <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                        <SettingsBootstrap RenderOption="None" />
                                    </dx:BootstrapButton>
                                </div>
                                <asp:HiddenField runat="server" ID="id_producto" Value="" />
                            </div>
                        </div>
                        <div class="row mt-1 msg_button_class">
                            <div class="col-12 ">
                                <div class="d-flex flex-row-reverse ">
                                    <dx:BootstrapCheckBox ID="vigencia" runat="server"></dx:BootstrapCheckBox>
                                    <asp:Label runat="server" ID="chkLabel" Text="Por Vigencia" CssClass="fs-10 mt-1 me-1"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col-4">
                                <asp:Label runat="server" ID="lblfc_inivig" Text="Del" CssClass="fs-10"></asp:Label>

                            </div>
                            <div class="col-8">
                                <dx:BootstrapDateEdit ID="fc_inivig" runat="server">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                </dx:BootstrapDateEdit>
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col-4">
                                <asp:Label runat="server" ID="lblfc_finvig" Text="Al" CssClass="fs-10"></asp:Label>
                            </div>
                            <div class="col-8">
                                <dx:BootstrapDateEdit ID="fc_finvig" runat="server">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                </dx:BootstrapDateEdit>
                                <asp:HiddenField runat="server" ID="id_clamov" Value="" />
                            </div>
                        </div>
                        <div class="row mt-1 msg_button_class">
                            <div class="col-12 ">
                                <div class="d-flex flex-row-reverse ">
                                    <dx:BootstrapCheckBox ID="porvencer" runat="server"></dx:BootstrapCheckBox>
                                    <asp:Label runat="server" ID="Label1" Text="Por Vencer" CssClass="fs-10 mt-1 me-1"></asp:Label>
                                </div>
                            </div>

                        </div>
                        <div class="row mt-1">
                            <div class="col-4 pe-0">
                                <asp:Label runat="server" ID="lblcuotavencidas" Text="Polizas Vencidas:" CssClass="fs-10"></asp:Label>
                            </div>
                            <div class="col-8">
                                <dx:BootstrapDateEdit ID="fc_polizavencida" runat="server">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                </dx:BootstrapDateEdit>
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col-12 text-center">
                                <dx:BootstrapButton ID="btnnuevo" runat="server" AutoPostBack="false" Text="Nuevo">
                                    <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                    <SettingsBootstrap RenderOption="None" />
                                </dx:BootstrapButton>
                                <dx:BootstrapButton ID="btnbuscar" runat="server" AutoPostBack="false" Text="Buscar">
                                    <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                    <SettingsBootstrap RenderOption="None" />
                                </dx:BootstrapButton>
                            </div>
                        </div>
                    </div>
                    <div class="col-7">
                        <asp:Panel runat="server" ID="gridcontainer" Visible="false">
                            <dx:BootstrapGridView ID="gridpoliza" runat="server">
                                <CssClasses Control="grid" />
                                <Columns>
                                    <dx:BootstrapGridViewDateColumn Caption="N° Póliza" FieldName="id_poliza">
                                    </dx:BootstrapGridViewDateColumn>
                                    <dx:BootstrapGridViewDateColumn Caption="Cliente" FieldName="nomraz">
                                    </dx:BootstrapGridViewDateColumn>
                                    <dx:BootstrapGridViewDateColumn Caption="Ini. Vigencia" FieldName="fc_inivig">
                                    </dx:BootstrapGridViewDateColumn>
                                    <dx:BootstrapGridViewDateColumn Caption="Fin Vigencia" FieldName="fc_finvig">
                                    </dx:BootstrapGridViewDateColumn>
                                </Columns>
                            </dx:BootstrapGridView>
                        </asp:Panel>

                    </div>
                </div>


                <p class="links">
                    <asp:Label runat="server" ID="lblmensaje" Text="" CssClass="fs-10"></asp:Label>


                </p>
            </div>

        </asp:Panel>

        <dx:BootstrapPopupControl ID="pCPersona" runat="server" ClientInstanceName="pCPersona" ShowHeader="false" ShowFooter="true" Modal="true" CloseAction="None" SettingsBootstrap-Sizing="Small" >
            <SettingsAdaptivity Mode="Always" MaxWidth="500px" />
            <CssClasses Content="pt-1" />
            <ContentCollection>
                <dx:ContentControl>
                    <div class="row msg_button_class rounded-top-1">
                        <div class="col-12 fs-10 p-1 ">
                            <span>Busqueda de Persona por Nombre o Razón Social</span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                            <div class="row">
                                <div class="col-12 text-center mt-2">
                                    <img src="../../../UI/img/search_user.png" />
                                </div>
                                <div class="col-12 text-center mt-2">
                                    <dx:BootstrapTextBox runat="server" ID="nomraz1" ClientInstanceName="nomraz1" NullText="" Width="150px">
                                        <CssClasses Input="form-control-sm fs-10" />
                                    </dx:BootstrapTextBox>
                                </div>
                                <div class="col-12 text-center mt-2">
                                    <dx:BootstrapButton ID="btnserper1" runat="server" AutoPostBack="false" Text="-->" OnClick="btnserper1_Click">
                                        <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                        <SettingsBootstrap RenderOption="None" />
                                    </dx:BootstrapButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-8 mt-2">
                           
                            <dx:BootstrapGridView ID="grdPersonas" EnableCallBacks="true" runat="server" KeyFieldName="id_per" ClientInstanceName="grdPersonas" OnDataBinding="grdPersonas_DataBinding">
                                <Settings ShowColumnHeaders="false" ShowTitlePanel="true" />
                                <SettingsText Title="Lista de Personas" />
                                   <SettingsBehavior AllowFocusedRow="True" AllowClientEventsOnLoad="False" AllowSelectByRowClick="true" />
                                <ClientSideEvents  RowClick="UpdateDetailGrid" />
                                <SettingsBootstrap Striped="true" />
                                <CssClasses PanelHeading="msg_button_class p-1 fs-10 "  />
                                <SettingsPager NumericButtonCount="3">
                                    <PageSizeItemSettings Visible="false" Items="10, 20, 50" />
                                </SettingsPager>
                                <Columns>
                                    <dx:BootstrapGridViewDataColumn FieldName="nomraz" Width="200px" CssClasses-DataCell="fs-11"></dx:BootstrapGridViewDataColumn>

                                </Columns>

                            </dx:BootstrapGridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                        </div>
                    </div>
                </dx:ContentControl>
            </ContentCollection>
            <FooterContentTemplate>
                <dx:BootstrapButton runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" Text="Aceptar">
                    <SettingsBootstrap RenderOption="None" Sizing="Small" />
                    <CssClasses Control="msg_button_class" Text="fs-9" />
                </dx:BootstrapButton>
            </FooterContentTemplate>
        </dx:BootstrapPopupControl>
    </div>
</asp:Content>
