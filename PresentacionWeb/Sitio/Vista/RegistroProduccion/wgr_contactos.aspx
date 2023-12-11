<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_contactos.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wgr_contactos" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">


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
                            <td id="btnper">                                                
                                <dx:ASPxTextBox ID="nomraz" runat="server" Width="100%"></dx:ASPxTextBox>  
                            </td>
                                <td >    
                                    <button type="button" name="btnserper" data-bs-toggle="modal" data-bs-target="#modal_btnserper" id="btnserper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                    ...
                                </button>
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

</asp:Content>
