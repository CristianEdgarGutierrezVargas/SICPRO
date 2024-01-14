<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_reportes.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ReportesSistema.wpr_reportes" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
       <div class="post">
         <div>         
           <div class="container">
            <div class="row">
              <div class="col-md-12">      
                  <h1 class="title"> <asp:Label ID="titulo" runat="server" Text="Renovacion de Polizas"></asp:Label></h1>
                  <div class="entry">
                      <img src="../../../UI/img/edit.png" alt="" width="128" height="128" class="left">
                  </div>      
              </div>    
            </div>  
            <div class="row">
              <div class="col-md-12"> 
                <dx:BootstrapTabControl runat="server" ActiveTabIndex="2" CssClasses-Tab="dxTab" CssClasses-ActiveTab="dxActTab">
                    <Tabs>
                        <dx:BootstrapTab Text="Clientes">
                        </dx:BootstrapTab>
                        <dx:BootstrapTab Text="Grupos">
                        </dx:BootstrapTab>
                        <dx:BootstrapTab Text="Proy. Cartera">
                        </dx:BootstrapTab>
                        <dx:BootstrapTab Text="Produccion General">
                        </dx:BootstrapTab>
                        <dx:BootstrapTab Text="Reimp. Memos">
                        </dx:BootstrapTab>
                    </Tabs>
                </dx:BootstrapTabControl>
              </div>    
            </div> 
           </div>
         </div>
       </div>
</asp:Content>
