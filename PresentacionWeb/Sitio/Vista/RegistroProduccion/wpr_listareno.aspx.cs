using DevExpress.Web;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{    
    public partial class wpr_listareno : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            CargaInicial();
        }

        #region Metodos

        private void CargaInicial()
        {

            var lstGrupo = _objConsumoRegistroProd.ObtenerGrupo();
            cmbGrupo.DataSource = lstGrupo;
            cmbGrupo.TextField = "desc_grupo";
            cmbGrupo.ValueField = "id_gru";
            cmbGrupo.DataBind();

            var itemLstGrupo = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbGrupo.Items.Add(itemLstGrupo);

            var lstTipoCartera = _objConsumoRegistroProd.listas1();
            cmbTipoCartera.DataSource = lstTipoCartera;
            cmbTipoCartera.TextField = "desc_param";
            cmbTipoCartera.ValueField = "id_par";
            cmbTipoCartera.DataBind();

            var itemTipoCartera = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbTipoCartera.Items.Add(itemTipoCartera);

            var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
            cmbEjecutivo.DataSource = lstFuncionarios;
            cmbEjecutivo.TextField = "nomraz";
            cmbEjecutivo.ValueField = "id_per";
            cmbEjecutivo.DataBind();

            var itemLstFuncionarios = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbEjecutivo.Items.Add(itemLstFuncionarios);

            var lstCiaAseguradora = _objConsumoRegistroProd.ObtenerListaCompania();
            cmbCiaAseg.DataSource = lstCiaAseguradora;
            cmbCiaAseg.TextField = "nomraz";
            cmbCiaAseg.ValueField = "id_spvs";
            cmbCiaAseg.DataBind();

            var itemLstCiaAseguradora = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbCiaAseg.Items.Add(itemLstCiaAseguradora);


            var lstAgenteCartera = _objConsumoRegistroProd.Persona(60);
            cmbAgente.DataSource = lstAgenteCartera;
            cmbAgente.TextField = "nomraz";
            cmbAgente.ValueField = "id_per";
            cmbAgente.DataBind();

            var itemLstAgenteCartera = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbAgente.Items.Add(itemLstAgenteCartera);

            var lstDivisa = _objConsumoRegistroProd.ParametroA("id_div");
            cmbDivisa.DataSource = lstDivisa;
            cmbDivisa.TextField = "abrev_param";
            cmbDivisa.ValueField = "id_par";
            cmbDivisa.DataBind();

            var itemLstDivisa = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbDivisa.Items.Add(itemLstDivisa);


            var lstPersonas = _objConsumoRegistroProd.ObtenerListaPersona();
            cmbAsegurado.DataSource = lstPersonas;
            cmbAsegurado.TextField = "nomraz";
            cmbAsegurado.ValueField = "id_per";
            cmbAsegurado.DataBind();

            var itemLstPersonas = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbAsegurado.Items.Add(itemLstPersonas);


        }

        #endregion

        protected void gridpoliza_DataBinding(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //this.msgboxpanel.Visible = false;
            //if (!this.vigencia.Checked & (this.num_poliza.Text == "") & (this.nomraz.Text == "") 
            //    & (this.nomco.Text == "") & (this.desc_producto.Text == "") & !this.porvencer.Checked)
            //{
            //    this.msgboxpanel.Visible = true;
            //    MessageBox messageBox = new MessageBox(base.Server.MapPath("msgbox1.tpl"));
            //    messageBox.SetTitle("Información");
            //    messageBox.SetIcon("msg_icon_2.png");
            //    messageBox.SetMessage("<p style='color:#990000; font-weight:bold'>Introduzca Criterios de Búsqueda</p>");
            //    messageBox.SetOKButton("msg_button_class1");
            //    this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
            //    this.lblmensaje.Text = "Introduzca Criterios de Búsqueda";
            //    return;
            //}
            //pr_poliza prPoliza = new pr_poliza();
            //string item = base.Request.QueryString["var"];
            //prPoliza.vigencia = this.vigencia;
            //if (!this.vigencia.Checked)
            //{
            //    prPoliza.vigencia.Checked = false;
            //}
            //else
            //{
            //    prPoliza.vigencia.Checked = true;
            //}
            //prPoliza.porvencer = this.porvencer;
            //if (!this.porvencer.Checked)
            //{
            //    prPoliza.porvencer.Checked = false;
            //}
            //else
            //{
            //    prPoliza.porvencer.Checked = true;
            //}
            //prPoliza.num_poliza = this.num_poliza;
            //prPoliza.id_perclie = this.id_per;
            //prPoliza.id_spvs1 = this.id_spvs;
            //prPoliza.id_producto = this.id_producto;
            //prPoliza.fc_inivig = this.fc_inivig;
            //prPoliza.fc_finivig = this.fc_finvig;
            //prPoliza.fc_finvig = this.fc_polizavencida;
            //prPoliza.lblmensaje = this.lblmensaje;
            //prPoliza.a = this.ap;
            //prPoliza.b = this.bp;
            //prPoliza.RecuperaTablaRen();


            var objTablaPolizaIn = new OC_ObtenerTablaPolizaIn();
            objTablaPolizaIn.num_poliza = num_poliza.Text;
            //objTablaPolizaIn.id_perclie = ;

            var lstTablaPoliza = _objConsumoRegistroProd.ObtenerTablaPolizaR(objTablaPolizaIn);
            this.gridpoliza.DataSource = lstTablaPoliza;
            this.gridpoliza.DataBind();
            //this.gridcontainer.Visible = true;
        }
    }
}