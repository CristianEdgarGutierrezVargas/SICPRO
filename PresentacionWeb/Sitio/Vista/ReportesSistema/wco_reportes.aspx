<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wco_reportes.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ReportesSistema.wco_reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">

    <script type="text/javascript">    
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

    function UpdateDetailGridDireccion(s, e) {
        var index = e.visibleIndex;

        CallBDireccion.PerformCallback(index);
    }
    function OnEndCallbackDireccion(s, e) {

        pCDireccion.Hide();

    }


    $(document).ready(function () {
        var st = $(this).find("input[id*='hidtab']").val();
        if (st == null)
            st = 0;

        //$('[id$=tabs]').tabs({ selected: st });
        console.log(st);
        var someTabTriggerEl = document.querySelector('#' + st + '')
        var tab = new bootstrap.Tab(someTabTriggerEl)
        tab.show()
    });
       
    </script>
    <div class="post">
      <div>         
        <div class="container">
         <div class="row">
           <div class="col-md-12">      
               <h1 class="title"><b> <asp:Label ID="titulo" runat="server" Text="Reportes de Cobranza"></asp:Label></b></h1>                    
           </div>    
         </div> 
         <br />
         <div class="row">
          <div class="col-md-12">   
                <asp:HiddenField ID="hidtab" Value="v-pills-clientes-tab" runat="server" />

                <asp:Button ID="clientes_tab" style="display:none" runat="server" OnClick="clientes_tab_Click"/>
                <asp:Button ID="vcmto_tab" style="display:none" runat="server" OnClick="vcmto_tab_Click"/>
                <asp:Button ID="pagos_tab" style="display:none" runat="server" OnClick="pagos_tab_Click"/>
                <asp:Button ID="estado_tab" style="display:none" runat="server" OnClick="estado_tab_Click"/>
                <asp:Button ID="reimp_tab" style="display:none" runat="server" OnClick="reimp_tab_Click"/>
                <asp:Button ID="cobranzas_tab" style="display:none" runat="server" OnClick="cobranzas_tab_Click"/>
                <asp:Button ID="recibos_tab" style="display:none" runat="server" OnClick="recibos_tab_Click"/>

             <div class="d-flex align-items-start">
              <div class="nav flex-column nav-pills me-3" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                <button class="nav-link" onclick="document.getElementById('<%= clientes_tab.ClientID %>').click()" id="v-pills-clientes-tab" data-bs-toggle="pill" data-bs-target="#v-pills-clientes" type="button" role="tab" aria-controls="v-pills-clientes" aria-selected="true">Est. Cta. Clientes</button>
                <button class="nav-link" onclick="document.getElementById('<%= vcmto_tab.ClientID %>').click()" id="v-pills-vcmto-tab" data-bs-toggle="pill" data-bs-target="#v-pills-vcmto" type="button" role="tab" aria-controls="v-pills-vcmto" aria-selected="false">Vcmto. Días</button>
                <button class="nav-link" onclick="document.getElementById('<%= pagos_tab.ClientID %>').click()" id="v-pills-pagos-tab" data-bs-toggle="pill" data-bs-target="#v-pills-pagos" type="button" role="tab" aria-controls="v-pills-pagos" aria-selected="false">Pagos Pend. Cias.</button>
                <button class="nav-link" onclick="document.getElementById('<%= estado_tab.ClientID %>').click()" id="v-pills-estado-tab" data-bs-toggle="pill" data-bs-target="#v-pills-estado" type="button" role="tab" aria-controls="v-pills-estado" aria-selected="false">Est.Cta. Pago Cia.</button>
                <button class="nav-link" onclick="document.getElementById('<%= reimp_tab.ClientID %>').click()" id="v-pills-reimp-tab" data-bs-toggle="pill" data-bs-target="#v-pills-reimp" type="button" role="tab" aria-controls="v-pills-reimp" aria-selected="false">Reimp.Liq.Cob.</button>
                <button class="nav-link" onclick="document.getElementById('<%= cobranzas_tab.ClientID %>').click()" id="v-pills-cobranzas-tab" data-bs-toggle="pill" data-bs-target="#v-pills-cobranzas" type="button" role="tab" aria-controls="v-pills-cobranzas" aria-selected="false">Cobranzas a Fecha</button>
                <button class="nav-link" onclick="document.getElementById('<%= recibos_tab.ClientID %>').click()" id="v-pills-recibos-tab" data-bs-toggle="pill" data-bs-target="#v-pills-recibos" type="button" role="tab" aria-controls="v-pills-recibos" aria-selected="false">Recibos X Asignar</button>
              </div>
              <div class="tab-content" id="v-pills-tabContent">
                <div class="tab-pane fade" id="v-pills-clientes" role="tabpanel" aria-labelledby="v-pills-clientes-tab">...</div>
                <div class="tab-pane fade" id="v-pills-vcmto" role="tabpanel" aria-labelledby="v-pills-vcmto-tab">...</div>
                <div class="tab-pane fade" id="v-pills-pagos" role="tabpanel" aria-labelledby="v-pills-pagos-tab">...</div>
                <div class="tab-pane fade" id="v-pills-estado" role="tabpanel" aria-labelledby="v-pills-estado-tab">...</div>
                <div class="tab-pane fade" id="v-pills-reimp" role="tabpanel" aria-labelledby="v-pills-reimp-tab">...</div>
                <div class="tab-pane fade" id="v-pills-cobranzas" role="tabpanel" aria-labelledby="v-pills-cobranzas-tab">...</div>
                <div class="tab-pane fade" id="v-pills-recibos" role="tabpanel" aria-labelledby="v-pills-recibos-tab">...</div>
              </div>
            </div>
          </div>    
        </div> 
         <br />
        </div>
      </div>
    </div>

   

</asp:Content>
