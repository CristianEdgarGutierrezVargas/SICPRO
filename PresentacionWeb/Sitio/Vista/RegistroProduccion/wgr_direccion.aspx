<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_direccion.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wgr_direccion" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">

            <div class="post">
                <div>                    

                <script type="text/javascript" src="scripts/fieldScripts.js"></script>

                <div class="post">

                    <div id="ctl00_cpmaster_panel">
	
                            <h1 class="title">
                                Registro de Direcciones</h1>
                            <div class="entry">
                                <img src="../../../UI/img/direccion.png" alt="" width="128" height="128" class="left">
                                <div>
                                    <table width="520" cellpadding="0" cellspacing="0">
                                        <tbody>                                        
                                            <tr>
                                                <td style="width: 70px">
                                                    <span id="ctl00_cpmaster_lblcontraseña">Dirección :</span>
                                                </td>
                                                <td style="width: 120px">
                                                    <dx:ASPxTextBox ID="direccion" runat="server" Width="100%">
                                                        <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" RequiredField-IsRequired="true" ValidationGroup="form_wgr_direccion">
                                                            <RequiredField ErrorText="Este campo es requerido" IsRequired="True"></RequiredField>
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>  
                                                </td>
                                                <td style="width: 70px">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 80px">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="ctl00_cpmaster_Label1">Tipo :</span>
                                                </td>
                                                <td>     
                                                    <dx:ASPxComboBox ID="cmb_tpdir" runat="server" ValueType="System.String" Width="100%">
                                                        <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ValidationGroup="form_wgr_direccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                                            <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </td>
                                                <td>
                                                    <span id="ctl00_cpmaster_Label9">Lugar :</span>
                                                </td>
                                                <td>
                                                    <dx:ASPxComboBox ID="cmb_id_emis" runat="server" ValueType="System.String" Width="100%">
                                                        <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ValidationGroup="form_wgr_direccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                                            <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="ctl00_cpmaster_Label2">Teléfono :</span>
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="telf_dir" runat="server" Width="100%"></dx:ASPxTextBox>                                                  
                                                </td>
                                                <td>
                                                    <span id="ctl00_cpmaster_Label3">N° Interno :</span>
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="int_dire" runat="server" Width="100%"></dx:ASPxTextBox>                                                  
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="ctl00_cpmaster_Label4">Celular :</span>
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="telf_cel" runat="server" Width="100%"></dx:ASPxTextBox>                                                 
                                                </td>
                                                <td>
                                                    <span id="ctl00_cpmaster_Label5">Fax :</span>
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="telf_fax" runat="server" Width="100%"></dx:ASPxTextBox>                                                  
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="ctl00_cpmaster_Label6">E-Mail :</span>
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="email" runat="server" Width="100%"></dx:ASPxTextBox>                                                  
                                                </td>
                                                <td>
                                                    <span id="ctl00_cpmaster_Label7">N° Casilla :</span>
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="casilla" runat="server" Width="100%"></dx:ASPxTextBox>                                                 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="ctl00_cpmaster_Label8">Sitio Web :</span>
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="web" runat="server" Width="100%"></dx:ASPxTextBox>                                                  
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center" style="height: 22px">
                                               
                                                    <dx:ASPxButton ID="btnPersona" runat="server" Text="Persona" CssClass="msg_button_class" OnClick="btnPersona_Click"></dx:ASPxButton>
                                           
                                                    <dx:ASPxButton ID="btnNuevo" runat="server" Text="Nuevo" CssClass="msg_button_class" OnClick="btnNuevo_Click"></dx:ASPxButton>

                                                    <dx:ASPxButton ID="btnGuardar" runat="server" Text="Guardar" CssClass="msg_button_class" OnClick="btnGuardar_Click" ValidationGroup="form_wgr_direccion"></dx:ASPxButton>
                                                             
                                                    <dx:ASPxButton ID="btnContactos" runat="server" Text="Contactos" CssClass="msg_button_class" OnClick="btnContactos_Click"></dx:ASPxButton>

                                                    <dx:ASPxButton ID="btnSalir" runat="server" Text="Salir" CssClass="msg_button_class" OnClick="btnSalir_Click"></dx:ASPxButton>


                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4" style="height: 22px">
                                                    <div class="gridcontainer" style="width: 500px">
                                                        <div>
                                                             <dx:ASPxGridView ID="grdDirecciones" KeyFieldName="id_dir" runat="server" Width="100%"
                                                                OnDataBinding="grdDirecciones_DataBinding" OnRowCommand="grdDirecciones_RowCommand">
                                                                 <Columns>     
                                                                      <dx:GridViewDataTextColumn FieldName="id_dir" Caption ="Opciones" VisibleIndex="0">
                                                                         <DataItemTemplate>
                                                                             <dx:ASPxButton ID="btn" runat="server" Text="Seleccionar"></dx:ASPxButton>
                                                                         </DataItemTemplate>
                                                                     </dx:GridViewDataTextColumn>
                                                                     <dx:GridViewDataTextColumn FieldName="id_dir" Caption="Codigo" />  
                                                                     <dx:GridViewDataTextColumn FieldName="direccion" Caption="Direccion"/>  
                                                                     <dx:GridViewDataTextColumn FieldName="desc_param" Caption="Descripcion"/>  
                                                                 </Columns>
                                                                  <SettingsPager Mode="ShowPager" PageSize="10" />
                                                             </dx:ASPxGridView>
	                                                    </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <p class="links">
                                <a class="error">
                                    <asp:Label ID="lblmensaje" runat="server" Text="" CssClass="error"></asp:Label>  
                                </a>
                            </p>
            
            </div>
                </div>

                </div>
            </div>

</asp:Content>
