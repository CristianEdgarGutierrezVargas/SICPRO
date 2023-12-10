using DevExpress.Web;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_polizacobranzain : System.Web.UI.Page
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
            var lstCuotasSession = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            var objPoliza = (pr_poliza)Session["POLIZA"];
            var objPolmov = (pr_polmov)Session["POLIZA_MOVIMIENTO"];

            var objPersona = _objConsumoRegistroProd.ObtenerPersona(objPoliza.id_perclie);
            var objPersonaAgente = _objConsumoRegistroProd.ObtenerPersona(objPoliza.id_percart);
            var objDireccion = _objConsumoRegistroProd.ObtenerDireccion(objPolmov.id_dir);
            var objGrupo = _objConsumoRegistroProd.ObtenerGrupo(objPoliza.id_gru);
            var objProducto = _objConsumoRegistroProd.ObtenerProducto(objPoliza.id_producto);
            var objParametroDivisa = _objConsumoRegistroProd.ObtenerParametro(objPolmov.id_div);

            var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
            cmbEjecutivo.DataSource = lstFuncionarios;
            cmbEjecutivo.TextField = "nomraz";
            cmbEjecutivo.ValueField = "id_per";
            cmbEjecutivo.DataBind();

            var itemLstFuncionarios = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbEjecutivo.Items.Add(itemLstFuncionarios);

            fc_emision.Date = objPolmov.fc_emision;
            fc_recepcion.Date = objPolmov.fc_recepcion;
            fc_inivig.Date = objPolmov.fc_inivig;
            lblfc_finvig.Text = objPolmov.fc_finvig.ToShortDateString();

            lblNroPoliza.Text = objPoliza.num_poliza;
            txtNroLiquidacion.Text = objPolmov.no_liquida;
            lblAsegurado.Text = objPersona.nomraz;
            lblDireccion.Text = objDireccion.direccion;
            lblGrupo.Text = objGrupo.desc_grupo;
            //lblCiaAseg.Text = ;

            lblProducto.Text = objProducto.desc_prod;

            var itemFuncionario = cmbEjecutivo.Items.FindByValue(objPolmov.id_perejec);
            if (itemFuncionario != null)
            {
                cmbEjecutivo.SelectedItem = itemFuncionario;
            }
            lblAgente.Text = objPersonaAgente.nomraz;
            lblTipoPoliza.Text = objPoliza.clase_poliza==true ? "Normal" : "Flotante";
            txtPrimaBruta.Text = Convert.ToString(objPolmov.prima_bruta);
            txtNumCuotas.Text = Convert.ToString(objPolmov.num_cuota);
            lblDivisa.Text = objParametroDivisa.desc_param;

            txtMatAseg.Text = objPolmov.mat_aseg;

            grdCuotasPoliza.DataSource = lstCuotasSession;
            grdCuotasPoliza.DataBind();
        }

        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            //LimpiarFormulario();
        }

        protected void btnCuotas_Click(object sender, EventArgs e)
        {
            //var numeroCuotas = Convert.ToDouble(txtNumCuotas.Text);
            //var lstCuotas = GetDataCuotas(numeroCuotas);
            //Session["LST_CUOTAS"] = lstCuotas;

            //grdCuotasPoliza.DataSource = lstCuotas;
            //grdCuotasPoliza.DataBind();

            ////int id = 0;
            ////lstCoutasTest.ForEach(s =>
            ////{
            ////    s.id_movimiento = 3;                
            ////    s.cuota = id++;
            ////});           
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            //pr_cobranzas prCobranza = new pr_cobranzas()
            //{
            //    id_spvs1 = this.id_spvs,
            //    prima_bruta = this.prima_bruta,
            //    id_producto = this.id_producto,
            //    tipo_cuota = this.tipo_cuota
            //};
            var objPoliza = (pr_poliza)Session["POLIZA"];
            var objPolmov = (pr_polmov)Session["POLIZA_MOVIMIENTO"];

            var id_spvs = objPoliza.id_spvs;
            var prima_bruta = Convert.ToDecimal(txtPrimaBruta.Text);
            var id_producto = objPoliza.id_producto;
            var tipo_cuota = objPolmov.tipo_cuota;// true = contado, false=credito

            txtPrimaNeta.Text = _objConsumoRegistroProd.Calculo2(prima_bruta, id_producto, id_spvs, tipo_cuota).ToString();
            txtPorcentaje.Text = _objConsumoRegistroProd.Porco1(id_producto, id_spvs).ToString();
            txtComision.Text = _objConsumoRegistroProd.Com3(prima_bruta, id_producto, id_spvs, tipo_cuota).ToString();
            //double.Parse(this.prima_neta.Text);
            //this.prima_neta.Text = string.Format("{0:n}", double.Parse(this.prima_neta.Text));
            //this.por_comision.Text = string.Format("{0:n}", double.Parse(this.por_comision.Text));
            //this.comision.Text = string.Format("{0:n}", double.Parse(this.comision.Text));
        }
    }
}