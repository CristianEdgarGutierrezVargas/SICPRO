using DevExpress.Web;
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
    public partial class wpr_polizacobranzain : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Page.IsPostBack && base.Request.QueryString["var"] != "")
            {
                long idPoliza = Convert.ToInt64(base.Request.QueryString["var"]);
                long idMov = Convert.ToInt64(base.Request.QueryString["val"]);
                string mov = Convert.ToString(base.Request.QueryString["ver"]);
                Movimiento(mov);
                //this.Buscar(num, num1);
                //this.id_poliza.Value = num.ToString();
                //this.id_mov.Value = num1.ToString();

                CargaInicial(idPoliza, idMov);
            }
            
        }

        #region Metodos

        private void Movimiento(string mov)
        {
            if (mov == "44")
            {
                titulo.Text = "Datos de Poliza Incluida (Módulo de Cobranzas)";
                //this.id_clamov.Value = "44";
            }
        }
        private void CargaInicial(long idPoliza, long idMov)
        {
            var objResponse = _objConsumoRegistroProd.ObtenerPolizaI(idPoliza, idMov);
            Session["vcb_veripoliza1"] = objResponse;

            pr_poliza objPoliza = new pr_poliza();
            objPoliza.id_poliza = objResponse.id_poliza;
            objPoliza.num_poliza = objResponse.num_poliza;
            objPoliza.id_producto = objResponse.id_producto;
            objPoliza.id_perclie = objResponse.id_perclie;
            objPoliza.id_spvs = objResponse.id_spvs;
            objPoliza.id_gru = objResponse.id_gru;
            objPoliza.clase_poliza = objResponse.clase_poliza;
            objPoliza.estado = objResponse.estado;
            objPoliza.fc_reg = objResponse.fc_recepcion;
            objPoliza.id_percart = objResponse.id_percart;
            //objPoliza.id_suc = objResponse.id_suc;

            var objPolmov = new pr_polmov();
            objPolmov.id_poliza = objResponse.id_poliza;
            objPolmov.id_movimiento = objResponse.id_movimiento;
            objPolmov.id_perejec = objResponse.id_perejec;
            objPolmov.fc_emision = objResponse.fc_emision;
            objPolmov.fc_inivig = objResponse.fc_inivig;

            objPolmov.fc_finvig = objResponse.fc_finvig;
            objPolmov.prima_bruta = objResponse.prima_bruta;
            objPolmov.prima_neta = objResponse.prima_neta;
            objPolmov.por_comision = objResponse.por_comision;
            objPolmov.comision = objResponse.comision;

            objPolmov.id_div = objResponse.id_div;
            objPolmov.tipo_cuota = objResponse.tipo_cuota;
            objPolmov.num_cuota = objResponse.num_cuota;
            objPolmov.id_clamov = objResponse.id_poliza;
            //objPolmov.estado = objResponse.estado;

            objPolmov.id_dir = objResponse.id_dir;
            objPolmov.fc_recepcion = objResponse.fc_recepcion;
            objPolmov.mat_aseg = objResponse.mat_aseg;
            //objPolmov.fc_reg = objResponse.fc_reg;
            objPolmov.no_liquida = objResponse.no_liquida;
            objPolmov.id_mom = objResponse.id_mom;


            //fc_inivig.Date = objResponse.fc_inivig;
            //lblfc_finvig.Text = objResponse.fc_finvig.ToShortDateString();
            //fc_emision.Date = objResponse.fc_emision;
            //fc_recepcion.Date = objResponse.fc_recepcion;
            //lblNroPoliza.Text = objResponse.num_poliza;
            //txtNroLiquidacion.Text = objResponse.no_liquida;
            //id_mom.Value = dataTable.Rows[0]["id_mom"].ToString();
            //id_perclie.Value = dataTable.Rows[0]["id_perclie"].ToString();
            //NomCliente1(id_perclie.Value);
            //id_dir.Value = dataTable.Rows[0]["id_dir"].ToString();
            //NomDireccion1(int.Parse(id_dir.Value));
            //id_gru1.Value = dataTable.Rows[0]["id_gru"].ToString();
            //NomGrupo(id_gru1.Value);
            //id_div1.Value = dataTable.Rows[0]["id_div"].ToString();
            //NomDivisa(int.Parse(id_div1.Value));
            //id_spvs1.Value = dataTable.Rows[0]["id_spvs"].ToString();
            //NomCompania(int.Parse(id_spvs1.Value));
            //id_producto.Value = dataTable.Rows[0]["id_producto"].ToString();
            //NomProducto1(id_producto.Value);
            //id_percart1.Value = dataTable.Rows[0]["id_percart"].ToString();
            //NombreAgente(id_percart1.Value);
            //gr_persona gr_persona2 = new gr_persona();
            //gr_persona2.id_rol = id_perejec;
            //gr_persona2.Persona(30);
            //id_perejec.Text = dataTable.Rows[0]["id_perejec"].ToString();
            //txtPrimaBruta.Text = Convert.ToString(objResponse.prima_bruta); //string.Format("{0:n}", double.Parse(dataTable.Rows[0]["prima_bruta"].ToString()));
            //txtPrimaNeta.Text = Convert.ToString(objResponse.prima_neta); //string.Format("{0:n}", double.Parse(dataTable.Rows[0]["prima_neta"].ToString()));
            //txtPorcentaje.Text = Convert.ToString(objResponse.por_comision); //string.Format("{0:n}", double.Parse(dataTable.Rows[0]["por_comision"].ToString()));
            //txtComision.Text = Convert.ToString(objResponse.comision);// string.Format("{0:n}", double.Parse(dataTable.Rows[0]["comision"].ToString()));
            //txtNumCuotas.Text = Convert.ToString(objResponse.num_cuota);
            //if (Convert.ToBoolean(objResponse.clase_poliza))
            //{
            //    lblTipoPoliza.Text = "Normal";
            //}
            //else
            //{
            //    lblTipoPoliza.Text = "Flotante";
            //}

            //if (Convert.ToBoolean(objResponse.tipo_cuota))
            //{
            //    tipo_cuota.Items[0].Selected = true;
            //}
            //else
            //{
            //    tipo_cuota.Items[1].Selected = true;
            //}

            //txtMatAseg.Text = objResponse.mat_aseg;

            List<pr_cuotapoliza> lstCuotasSession = new List<pr_cuotapoliza>();

            Session["LST_CUOTAS"] = lstCuotasSession;
            Session["POLIZA"] = objPoliza;
            Session["POLIZA_MOVIMIENTO"] = objPolmov;

            //var lstCuotasSession = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            //var objPoliza = (pr_poliza)Session["POLIZA"];
            //var objPolmov = (pr_polmov)Session["POLIZA_MOVIMIENTO"];

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