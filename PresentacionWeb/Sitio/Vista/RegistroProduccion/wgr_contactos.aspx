<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_contactos.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wgr_contactos" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">

        <script type="text/javascript"> 
        var isDetailRowExpanded = new Array();
        function OnRowClick(s, e) {
            if (isDetailRowExpanded[e.visibleIndex] != true)
                s.ExpandDetailRow(e.visibleIndex);
            else
                s.CollapseDetailRow(e.visibleIndex);
        }
        function OnDetailRowExpanding(s, e) {
            isDetailRowExpanded[e.visibleIndex] = true;
        }
        function OnDetailRowCollapsing(s, e) {
            isDetailRowExpanded[e.visibleIndex] = false;
        }

        function OnRowDblClick(s, e) {
            var index = e.visibleIndex;

            CallBGridPoliza.PerformCallback(index);
        }
        function UpdateDetailGrid(s, e) {
            var index = e.visibleIndex;

            CallBPersona.PerformCallback(index);
        }
        function OnEndCallbackPersona(s, e) {

            pCPersona.Hide();

        }

        function UpdateDetailGridCompania(s, e) {
            var index = e.visibleIndex;

            CallBCompania.PerformCallback(index);
        }
        function OnEndCallbackCompania(s, e) {

            pCCompania.Hide();

        }
        function UpdateDetailGridProducto(s, e) {
            var index = e.visibleIndex;

            CallBProducto.PerformCallback(index);
        }
        function OnEndCallbackProducto(s, e) {

            pCProducto.Hide();

        }
        </script>
    <div class="post">
        <div id="ctl00_cpmaster_panel">
	
            <div class="container">
                <div class="row">
                    <div class="col-md-3">
                         <h1 class="title"> Registro de Contactos</h1>
                         <div class="entry">
                             <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122" class="left">
                         </div>
                    </div>
                    
                    <div class="col-md-8">
                        <br /><br />
                      <table width="100%" cellpadding="0" cellspacing="0" >
                        <tbody>
                        <%--<tr>
                            <td style="height: 18px; width: 70px;">
                                <input type="hidden" name="ctl00$cpmaster$id_perclie" id="ctl00_cpmaster_id_perclie" value="4546936">
                            </td>
                            <td style="height: 18px; width: 200px;" align="center">
                                <span id="ctl00_cpmaster_direccion"></span>
                                <input type="hidden" name="ctl00$cpmaster$id_dir" id="ctl00_cpmaster_id_dir" value="3009">
                            </td>
                            <td style="width: 70px; height: 18px">
                                &nbsp;
                            </td>
                            <td style="width: 4px; height: 18px">
                                <input type="hidden" name="ctl00$cpmaster$a" id="ctl00_cpmaster_a" value="0">
                                <input type="hidden" name="ctl00$cpmaster$b" id="ctl00_cpmaster_b" value="10">
                                <input type="hidden" name="ctl00$cpmaster$id_per" id="ctl00_cpmaster_id_per">
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="width: 70px">
                                <span id="ctl00_cpmaster_lblnombre">Nombre  :</span>
                            </td>
<%--                            <td id="btnper">                                                
                                <dx:ASPxTextBox ID="nomraz" runat="server" Width="100%"></dx:ASPxTextBox>  
                            </td>--%>
                            <td >    
                                  <div class="d-flex flex-row">
                                    <dx:BootstrapCallbackPanel ID="CallBPersona" ClientInstanceName="CallBPersona" runat="server" OnCallback="CallBPersona_Callback">
                                        <ClientSideEvents EndCallback="OnEndCallbackPersona"></ClientSideEvents>
                                        <ContentCollection>
                                            <dx:ContentControl>
                                                <dx:BootstrapTextBox runat="server" ID="nomraz" NullText="" Width="250px">
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
                                </td>
                        </tr>
                        <tr>
                            <td style="height: 24px; width: 70px;">
                                <span id="ctl00_cpmaster_lbllugar">Lugar :</span>
                            </td>
                            <td style="height: 24px; width: 200px;">
                                <dx:ASPxComboBox ID="cmb_id_emis" runat="server" ValueType="System.Int32" Width="100%"></dx:ASPxComboBox>                                                    
                            </td>
                            <td style="height: 24px; width: 100px" colspan="2">
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 70px">
                                <span id="ctl00_cpmaster_lblrelacion">Relación :</span>
                            </td>
                            <td colspan="2">
                                <dx:ASPxTextBox ID="relacion" runat="server" Width="100%"></dx:ASPxTextBox>                                                    
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" style="height: 22px">
                                                                                                     
                                    <dx:ASPxButton ID="btnDirecciones" runat="server" Text="Direcciones" CssClass="msg_button_class" OnClick="btnDirecciones_Click"></dx:ASPxButton>

                                    <dx:ASPxButton ID="btnGuardar" runat="server" Text="Guardar" CssClass="msg_button_class" OnClick="btnGuardar_Click"></dx:ASPxButton>
                                                               
                                    <dx:ASPxButton ID="btnSalir" runat="server" Text="Salir" CssClass="msg_button_class" OnClick="btnSalir_Click"></dx:ASPxButton>

                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" style="height: 22px">
                                <div class="gridcontainer" style="width: 500px">
                                    <div>
                                        <dx:ASPxGridView ID="grdContactos" KeyFieldName="id_dir" runat="server" Width="100%"
                                           OnDataBinding="grdContactos_DataBinding" OnRowCommand="grdContactos_RowCommand">
                                            <Columns>     
                                                 <dx:GridViewDataTextColumn FieldName="id_dir" Caption ="Opciones" VisibleIndex="0">
                                                    <DataItemTemplate>
                                                        <dx:ASPxButton ID="btn" runat="server" Text="Seleccionar" Font-Size="x-Small"></dx:ASPxButton>
                                                    </DataItemTemplate>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="id_dir" Caption="Codigo" />  
                                                <dx:GridViewDataTextColumn FieldName="id_per" Caption="Codigo" Visible="false"/>  
                                                <dx:GridViewDataTextColumn FieldName="nomraz" Caption="Nombre" />  
                                                <dx:GridViewDataTextColumn FieldName="relacion" Caption="Relacion"/>   
                                            </Columns>
                                             <SettingsPager Mode="ShowPager" PageSize="10" />
                                        </dx:ASPxGridView>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </tbody></table>
                    </div>
   
                </div>
            </div>                
                <p class="links">
                    <a class="error">
                        <asp:Label ID="lblmensaje" runat="server" Text="" CssClass="error"></asp:Label> 
                    </a>
                </p>
            
        </div>
    </div>


    <dx:BootstrapPopupControl ID="pCPersona" runat="server" ClientInstanceName="pCPersona" ShowHeader="false" ShowFooter="true" Modal="true" CloseAction="None" SettingsBootstrap-Sizing="Small">
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
                        <ClientSideEvents RowClick="UpdateDetailGrid" />
                        <SettingsBootstrap Striped="true" />
                        <CssClasses PanelHeading="msg_button_class p-1 fs-10 " />
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

</asp:Content>
